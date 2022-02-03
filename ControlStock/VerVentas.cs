using ControlStock.Clases;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class VerVentas : Form
    {
        public VerVentas()
        {
            InitializeComponent();
        }


        private void dgvMuestraVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                dgvMuestraVentas.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnVentasSemana_Click(object sender, System.EventArgs e)
        {
            dgvMuestraVentas.DataSource = null;
            ConectionDB conexion = new ConectionDB();
            List<Comprobante> ultimasventas = new List<Comprobante>();
            foreach (Comprobante item in conexion.BuscaComprobantes())
            {
                if (item.FechaAlta >= System.DateTime.Now.AddDays(-8) && (item.TipoComprobanteId == 1))
                {
                    ultimasventas.Add(item);
                }
            }

            MostrarVentasDGV(ultimasventas);
        }


        private void btnVentasTodas_Click(object sender, System.EventArgs e)
        {
            dgvMuestraVentas.DataSource = null;
            ConectionDB conexion = new ConectionDB();
            List<Comprobante> ultimasventas = new List<Comprobante>();

            foreach (Comprobante comp in conexion.BuscaComprobantes())
            {
                if (comp.TipoComprobanteId == 1) ultimasventas.Add(comp);
            }
            MostrarVentasDGV(ultimasventas);
        }

        private void MostrarVentasDGV(List<Comprobante> lista)
        {
            if (lista.Count <= 0)
            {
                MessageBox.Show("No existen registros de venta con el filtro aplicado");
            }
            else
            {
                lista.Reverse();
                dgvMuestraVentas.DataSource = null;
                dgvMuestraVentas.DataSource = lista;

                dgvMuestraVentas.Columns[0].Visible = false;
                dgvMuestraVentas.Columns[5].Visible = false;
                dgvMuestraVentas.Columns[6].Visible = false;
                dgvMuestraVentas.Columns[7].Visible = false;
                dgvMuestraVentas.Columns[8].Visible = false;
                dgvMuestraVentas.Columns[9].Visible = false;
                dgvMuestraVentas.Columns[10].Visible = false;
                dgvMuestraVentas.Columns[11].Visible = false;
                dgvMuestraVentas.Columns[12].Visible = false;
                dgvMuestraVentas.Columns[13].Visible = false;
                dgvMuestraVentas.Columns[14].Visible = false;
                dgvMuestraVentas.Columns[15].Visible = false;
                dgvMuestraVentas.Columns[16].Visible = false;
                dgvMuestraVentas.Columns[17].HeaderText = "Vendedora";
                dgvMuestraVentas.Columns[4].HeaderText = "Fecha";

            }
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            //nuevo formulario para ver detalle de la venta
            Comprobante seleccionado = (Comprobante)dgvMuestraVentas.CurrentRow.DataBoundItem;

            DetalleVenta detalledelaventa = new DetalleVenta(seleccionado);
            detalledelaventa.MdiParent = ParentForm;

            detalledelaventa.Show();

        }

        private void VerVentas_Load(object sender, System.EventArgs e)
        {

        }

        private void btnVentasDia_Click(object sender, System.EventArgs e)
        {
            dgvMuestraVentas.DataSource = null;
            ConectionDB conexion = new ConectionDB();
            List<Comprobante> ultimasventas = new List<Comprobante>();
            foreach (Comprobante item in conexion.BuscaComprobantes())
            {
                if (item.FechaAlta.Date == System.DateTime.Today && (item.TipoComprobanteId == 1))
                {
                    ultimasventas.Add(item);
                }
            }

            MostrarVentasDGV(ultimasventas);
        }
    }
}
