using ControlStock.Clases;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class DetalleVenta : Form
    {
        List<Producto> detalledeproductos = new List<Producto>();

        List<DetalleFactura> detalle = new List<DetalleFactura>();

        List<DetalleProductosVenta> impresion_detallada = new List<DetalleProductosVenta>();
        Comprobante comprobantedeventa;


        public DetalleVenta()
        {
            InitializeComponent();
        }

        public DetalleVenta(Comprobante verdetalle)
        {
            InitializeComponent();

            dtgvDetalleVentaProductos.DataSource = mostrardetalles(verdetalle.ComprobanteId);

            impresion_detallada = mostrardetalles(verdetalle.ComprobanteId);
            comprobantedeventa = verdetalle;

            lblTarjeta1.Text = verdetalle.Tarjeta1.ToString();
            lblTarjeta2.Text = verdetalle.Tarjeta2.ToString();
            lblMercadopago.Text = verdetalle.MercadoPago.ToString();
            lblTransfBancaria.Text = verdetalle.Transferencia.ToString();
            lblGedNet.Text = verdetalle.GedNet.ToString();

            lblComprobante.Text = verdetalle.codigo;
            ConectionDB conexion = new ConectionDB();
            foreach (Cliente cliente in conexion.BuscaCliente())
            {
                if (cliente.PersonaJuridicaId == verdetalle.PersonaJuridicaId)
                {
                    lblCliente.Text = cliente.RazonSocial;
                }
            }

            lblFecha.Text = verdetalle.FechaAlta.ToString();
            lblVendedor.Text = verdetalle.UserName;


            foreach (Sucursal suc in conexion.BuscaSucursal())
            {
                if (suc.SucursalId == verdetalle.SucursalId)
                {
                    lblSucursal.Text = suc.NombreSucursal;
                }
            }

            double subtotal = 0;

            foreach (DetalleProductosVenta prod in mostrardetalles(verdetalle.ComprobanteId))
            {
                subtotal = (subtotal + (prod.Cantidad * prod.Precio)) - prod.Bonificacion;
            }

            lblSubtotal.Text = "$ " + subtotal.ToString();
            lblBonificacion.Text = "$ - " + verdetalle.Bonificacion.ToString();
            lblImporteTotal.Text = "$ " + (subtotal - (verdetalle.Bonificacion)).ToString();

            lblTarjetas.Text = "$ " + verdetalle.Tarjeta.ToString();
            lblEfectivo.Text = "$ " + verdetalle.Efectivo.ToString();
            lblTotal.Text = "$ " + verdetalle.Importe.ToString();

        }


        private void btnCerrarVentanaVenta_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void DetalleVenta_Load(object sender, System.EventArgs e)
        {

        }

        private List<DetalleProductosVenta> mostrardetalles(int comprobanteid)
        {
            ConectionDB conexion = new ConectionDB();

            List<DetalleProductosVenta> lista = new List<DetalleProductosVenta>();
            List<DetalleFactura> listadetallefactura = new List<DetalleFactura>();

            foreach (DetalleFactura detalle in conexion.BuscaDetalleFactura())
            {
                if (detalle.ComprobanteId == comprobanteid)
                {
                    listadetallefactura.Add(detalle);
                }
            }

            foreach (DetalleFactura detalleFactura in listadetallefactura)
            {
                foreach (Producto prod in conexion.BuscarProductos())
                {
                    if (detalleFactura.ProductoId == prod.ProductoId)
                    {
                        DetalleProductosVenta nuevodetalle = new DetalleProductosVenta();
                        nuevodetalle.Codigo = prod.Codigo;
                        nuevodetalle.Cantidad = detalleFactura.Cantidad;
                        nuevodetalle.NombreProducto = prod.Nombre;
                        nuevodetalle.Precio = prod.PrecioUnitario + (prod.PrecioUnitario * prod.Rentabilidad) / 100;
                        nuevodetalle.Subtotal = nuevodetalle.Precio * nuevodetalle.Cantidad;
                        nuevodetalle.Bonificacion = detalleFactura.Bonificacion;
                        nuevodetalle.Marca = prod.Marca;
                        nuevodetalle.Talle = prod.Talle;
                        nuevodetalle.Color = prod.Color;
                        lista.Add(nuevodetalle);
                    }

                }

            }
            return lista;
        }

        private void btnImprimirVentanaVenta_Click(object sender, System.EventArgs e)
        {
            printDocument = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument.PrinterSettings = ps;
            printDocument.PrintPage += Imprimir;
            printDocument.Print();
            this.Close();
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            string numerodeticket = comprobantedeventa.codigo;
            string vendedora = comprobantedeventa.UserName;

            List<int> cantproductos = new List<int>();

            foreach (DetalleProductosVenta comp in impresion_detallada)
            {
                cantproductos.Add(comp.Cantidad);
            }

            Font font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            Font font2 = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            int espacio = 18;
            int y = 5;

            /*
            string pathescritorio = @"C:\Users\ASUS\Desktop\Alma_Libre_Escritorio\";
            string filepath = pathescritorio + @"Alma_Libre\ImprimirVentas\Img\logo_almalibre.jpg";
            */
            ConfigurationManager.RefreshSection("AppSettings");


            string pathimg = @ConfigurationManager.AppSettings["imgAlmaLibreTiket"];

            Image img = Image.FromFile(pathimg);
            e.Graphics.DrawImage(img, new Rectangle(35, 0, 184, 123));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));

            e.Graphics.DrawString("Nº de Comprobante: " + numerodeticket, font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Dir: Rivadavia 20 (Segundo Local)", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Palmira - San Martín - Mza", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Teléfono: 2634639211", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Instagram: almalibre_2", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Vendedora: " + vendedora, font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Fecha: " + comprobantedeventa.FechaAlta.ToString(), font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));

            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            int i = 0;
            double total = 0;
            foreach (int cantidprod in cantproductos)
            {
                e.Graphics.DrawString(cantidprod + "  " + impresion_detallada[i].Codigo + "   " + impresion_detallada[i].NombreProducto + "   $ " + impresion_detallada[i].Subtotal, font2, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
                total = total + impresion_detallada[i].Subtotal;
                i++;
            }
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Subtotal: $ " + total.ToString(), font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));

            e.Graphics.DrawString("Descuentos: $ - " + (total - (comprobantedeventa.Tarjeta + comprobantedeventa.Efectivo)).ToString(), font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));

            e.Graphics.DrawString("Tarjetas: $ " + comprobantedeventa.Tarjeta.ToString(), font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("Efectivo: $ " + comprobantedeventa.Efectivo.ToString(), font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));
            e.Graphics.DrawString("******** NO VÁLIDO COMO FACTURA ********", font, Brushes.Black, new RectangleF(0, y += espacio, 500, 30));

        }
    }
}
