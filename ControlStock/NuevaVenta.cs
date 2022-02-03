using ControlStock.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class lblSubtotal : Form
    {
        public lblSubtotal()
        {
            InitializeComponent();
        }

        ConectionDB conexion = new ConectionDB();
        List<DetalleProductosVenta> productosagregados = new List<DetalleProductosVenta>();
        List<DetalleFactura> detallesDB = new List<DetalleFactura>();
        Comprobante comprobante = new Comprobante();

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NuevaVenta_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
        }
        private void LlenarComboBox()
        {
            ConectionDB conexion = new ConectionDB();
            List<string> clientes = new List<string>();
            List<string> usuarios = new List<string>();
            List<string> sucursales = new List<string>();

            foreach (Cliente client in conexion.BuscaCliente())
            {
                clientes.Add(client.RazonSocial);
            }
            foreach (Usuario user in conexion.BuscaUsuario())
            {
                usuarios.Add(user.UserName);
            }
            foreach (Sucursal suc in conexion.BuscaSucursalActiva())
            {
                sucursales.Add(suc.NombreSucursal);
            }

            CBxCliente.DataSource = clientes;
            CBxUsuario.DataSource = usuarios;
            cbSucursal.DataSource = sucursales;

            //llenar los textbox del producto

            TxBDescuentoProducto.Text = "0";
            TxBCantidadProducto.Text = "1";
            TxBPrecioProducto.Text = "0";
            lblSubtotalGeneral.Text = "0";
            lblTotalVenta.Text = "0";
            tbPrecompra.Text = "0";
            tbDescuentoTotalVenta.Text = "0";

            //llenar los textbox del total venta
            tbTarjeta1.Text = "0";
            tbTarjeta2.Text = "0";
            tbTarjetaDebito.Text = "0";
            tbTransferencia.Text = "0";
            tbGedNet.Text = "0";
            tbMercadoPago.Text = "0";
            tbEfectivo.Text = "0";

        }

        private void tbTarjeta1_Enter(object sender, EventArgs e)
        {
            CalcularImporte(0);
        }

        private void CalcularImporte(int v)
        {

            switch (v)
            {
                case 0:
                    double caso0 = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta2.Text) - double.Parse
                        (tbTarjetaDebito.Text) - double.Parse(tbTransferencia.Text)
                        - double.Parse(tbGedNet.Text) - double.Parse(tbMercadoPago.Text)
                        - double.Parse(tbEfectivo.Text));

                    tbTarjeta1.Text = caso0.ToString();

                    if (conexion.BuscaMediosPagos().Tarjeta1 != 0)
                    {
                        lblRecargoTarjeta1.Text = "Debería cobrar $ " + (caso0 + ((conexion.BuscaMediosPagos().Tarjeta1 * caso0) / 100)).ToString();
                        lblRecargoTarjeta1.Visible = true;
                    }

                    break;
                case 1:
                    double caso1 = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta1.Text) - double.Parse(tbTarjetaDebito.Text)
                        - double.Parse(tbTransferencia.Text) - double.Parse(tbGedNet.Text)
                        - double.Parse(tbMercadoPago.Text)
                        - double.Parse(tbEfectivo.Text));
                    tbTarjeta2.Text = caso1.ToString();

                    if (conexion.BuscaMediosPagos().Tarjeta2 != 0)
                    {
                        lblRecargoTarjeta2.Text = "Debería cobrar $ " + (caso1 + ((conexion.BuscaMediosPagos().Tarjeta2 * caso1) / 100)).ToString();
                        lblRecargoTarjeta2.Visible = true;
                    }


                    break;
                case 2:
                    double caso2 = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta2.Text) - double.Parse(tbTarjeta1.Text)
                        - double.Parse(tbTransferencia.Text) - double.Parse(tbGedNet.Text)
                        - double.Parse(tbMercadoPago.Text) - double.Parse(tbEfectivo.Text));
                    tbTarjetaDebito.Text = caso2.ToString();

                    if (conexion.BuscaMediosPagos().TarjetaDebito != 0)
                    {
                        lblRecargoDebito.Text = "Debería cobrar $ " + (caso2 + ((conexion.BuscaMediosPagos().TarjetaDebito * caso2) / 100)).ToString();
                        lblRecargoDebito.Visible = true;
                    }


                    break;
                case 3:
                    double caso3 = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta2.Text) - double.Parse(tbTarjetaDebito.Text)
                        - double.Parse(tbTarjeta1.Text) - double.Parse(tbGedNet.Text)
                        - double.Parse(tbMercadoPago.Text) - double.Parse(tbEfectivo.Text));
                    tbTransferencia.Text = caso3.ToString();

                    if (conexion.BuscaMediosPagos().TrnsfBancaria != 0)
                    {
                        lblRecargoMP.Text = "Debería cobrar $ " + (caso3 + ((conexion.BuscaMediosPagos().Mercadopago * caso3) / 100)).ToString();
                        lblRecargoMP.Visible = true;
                    }


                    break;
                case 4:
                    double caso4 = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta2.Text) - double.Parse(tbTarjetaDebito.Text)
                        - double.Parse(tbTransferencia.Text) - double.Parse(tbGedNet.Text)
                        - double.Parse(tbTarjeta1.Text) - double.Parse(tbEfectivo.Text));
                    tbMercadoPago.Text = caso4.ToString();

                    if (conexion.BuscaMediosPagos().Mercadopago != 0)
                    {
                        lblRecargoTransferencia.Text = "Debería cobrar $ " + (caso4 + ((conexion.BuscaMediosPagos().TrnsfBancaria * caso4) / 100)).ToString();
                        lblRecargoTransferencia.Visible = true;
                    }
                    break;
                case 5:
                    double caso5 = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta2.Text) - double.Parse(tbTarjetaDebito.Text)
                        - double.Parse(tbTransferencia.Text) - double.Parse(tbTarjeta1.Text)
                        - double.Parse(tbMercadoPago.Text) - double.Parse(tbEfectivo.Text));
                    tbGedNet.Text = caso5.ToString();

                    if (conexion.BuscaMediosPagos().Gednet != 0)
                    {
                        lblRecargoGedNet.Text = "Debería cobrar $ " + (caso5 + ((conexion.BuscaMediosPagos().Gednet * caso5) / 100)).ToString();
                        lblRecargoGedNet.Visible = true;
                    }

                    break;
                case 6:
                    tbEfectivo.Text = (double.Parse(lblTotalVenta.Text)
                        - double.Parse(tbTarjeta2.Text) - double.Parse(tbTarjetaDebito.Text)
                        - double.Parse(tbTransferencia.Text) - double.Parse(tbGedNet.Text)
                        - double.Parse(tbMercadoPago.Text) - double.Parse(tbTarjeta1.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void TxBCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                List<Producto> productos = conexion.BuscarProductos();
                if (TxBCodigoProducto.TextLength >= 4)
                {
                    foreach (var producto in productos)
                    {
                        if (producto.Codigo.Contains(TxBCodigoProducto.Text))
                        {
                            TxBDescripcionProducto.Text = producto.Nombre;
                            double precio = producto.PrecioUnitario + ((producto.PrecioUnitario * producto.Rentabilidad) / 100);
                            TxBPrecioProducto.Text = precio.ToString();

                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar 4 caracteres como mínimo para buscar el producto");
                }
            }
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (TxBCodigoProducto.TextLength >= 4)
            {
                foreach (var prod in conexion.BuscarProductos())
                {
                    if (prod.Codigo.Contains(TxBCodigoProducto.Text))
                    {
                        //muestra el producto agregado en el datagridview

                        dgvProductosVenta.DataSource = null;
                        DetalleProductosVenta nuevodet = new DetalleProductosVenta();
                        nuevodet.Codigo = prod.Codigo;
                        nuevodet.Cantidad = int.Parse(TxBCantidadProducto.Text);
                        nuevodet.NombreProducto = prod.Nombre;
                        nuevodet.Precio = double.Parse(TxBPrecioProducto.Text);
                        nuevodet.Subtotal = double.Parse(tbSubtotal.Text);
                        nuevodet.Bonificacion = double.Parse(TxBDescuentoProducto.Text);
                        nuevodet.Marca = prod.Marca;
                        nuevodet.Talle = prod.Talle;
                        nuevodet.Color = prod.Color;
                        productosagregados.Add(nuevodet);
                        dgvProductosVenta.DataSource = productosagregados;

                        //crea el detalle de producto individual para enviar a la base de datos
                        DetalleFactura detfact = new DetalleFactura();
                        detfact.Cantidad = nuevodet.Cantidad;
                        detfact.Subtotal = nuevodet.Subtotal;
                        detfact.Bonificacion = nuevodet.Bonificacion;
                        detfact.FechaAlta = DateTime.Now;
                        detfact.ProductoId = prod.ProductoId;
                        detfact.CadenaBusquedaProducto = prod.Codigo;

                        detallesDB.Add(detfact);
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete los campos antes de agregar el producto");
                return;
            }

            TxBDescuentoProducto.Text = "0";
            TxBCantidadProducto.Text = "1";
            TxBPrecioProducto.Text = "0";
            TxBDescripcionProducto.Text = "";
            TxBCodigoProducto.Text = "";
            tbSubtotal.Text = "";

            /*lblSubtotalGeneral.Text = (double.Parse(lblSubtotalGeneral.Text) +
                double.Parse(tbSubtotal.Text)).ToString();*/


            double subtotgral = 0;
            foreach (DataGridViewRow item in dgvProductosVenta.Rows )
            {
                subtotgral = subtotgral + (double.Parse(item.Cells[1].Value.ToString()) * double.Parse(item.Cells[3].Value.ToString()));
            }
            lblSubtotalGeneral.Text = subtotgral.ToString();


            lblTotalVenta.Text = ((double.Parse(lblSubtotalGeneral.Text) - double.Parse(tbDescuentoTotalVenta.Text)) - double.Parse(tbPrecompra.Text)).ToString();

            cbSucursal.Enabled = false;
            CBxCliente.Enabled = false;
            CBxUsuario.Enabled = false;
            btnAgregarProducto.Enabled = false;
            TxBCodigoProducto.Focus();
        }
        private void TxBCantidadProducto_Leave(object sender, EventArgs e)
        {
            double subtotal = (double.Parse(TxBPrecioProducto.Text) *
                int.Parse(TxBCantidadProducto.Text)) - (double.Parse(TxBDescuentoProducto.Text));
            tbSubtotal.Text = subtotal.ToString();



        }
        private void TxBCodigoProducto_Leave(object sender, EventArgs e)
        {
            //obtengo el id de la sucursal
            int suc = 0;
            foreach (Sucursal sucur in conexion.BuscaSucursal())
            {
                if (sucur.NombreSucursal == cbSucursal.Text) suc = sucur.SucursalId;
            }

            List<Stock> listastock = conexion.BuscaStock().FindAll(x => x.SucursalId == suc);
            List<Producto> productosx = new List<Producto>();


            foreach (Producto item in conexion.BuscarProductos().FindAll(x => x.FechaBaja == null))
            {
                foreach (Stock item2 in listastock)
                {
                    if (item.ProductoId == item2.ProductoId) productosx.Add(item);
                }
            }

            if (TxBCodigoProducto.TextLength >= 4)
            {
                foreach (var producto in productosx)
                {
                    if (producto.Codigo.Contains(TxBCodigoProducto.Text))
                    {
                        TxBDescripcionProducto.Text = producto.Nombre;
                        double precio = producto.PrecioUnitario + ((producto.PrecioUnitario * producto.Rentabilidad) / 100);
                        int precioint = (int)precio;
                        TxBPrecioProducto.Text = precioint.ToString();

                        break;
                    }
                }
            }
            if (TxBPrecioProducto != null) btnAgregarProducto.Enabled = true;
        }
        private void TxBDescuentoProducto_Leave(object sender, EventArgs e)
        {
            double subtotal = (double.Parse(TxBPrecioProducto.Text) *
                int.Parse(TxBCantidadProducto.Text)) - (double.Parse(TxBDescuentoProducto.Text));

            tbSubtotal.Text = subtotal.ToString();

            if (TxBDescuentoProducto.Text == null) TxBDescuentoProducto.Text = "0";
        }
        private void tbDescuentoTotalVenta_Leave(object sender, EventArgs e)
        {
            if (tbDescuentoTotalVenta.Text == "") tbDescuentoTotalVenta.Text = "0";
            lblTotalVenta.Text = ((double.Parse(lblSubtotalGeneral.Text)
                - double.Parse(tbDescuentoTotalVenta.Text)) - double.Parse(tbPrecompra.Text)).ToString();
        }
        private void tbPrecompra_Leave(object sender, EventArgs e)
        {
            if (tbPrecompra.Text == "") tbPrecompra.Text = "0";
            lblTotalVenta.Text = ((double.Parse(lblSubtotalGeneral.Text)
                - double.Parse(tbDescuentoTotalVenta.Text)) - double.Parse(tbPrecompra.Text)).ToString();
        }
        private void tbTarjeta2_Enter(object sender, EventArgs e)
        {
            CalcularImporte(1);
        }
        private void tbTarjetaDebito_Enter(object sender, EventArgs e)
        {
            CalcularImporte(2);
        }
        private void tbMercadoPago_Enter(object sender, EventArgs e)
        {
            CalcularImporte(4);
        }
        private void tbTransferencia_Enter(object sender, EventArgs e)
        {
            CalcularImporte(3);
        }
        private void tbGedNet_Enter(object sender, EventArgs e)
        {
            CalcularImporte(5);
        }
        private void tbEfectivo_Enter(object sender, EventArgs e)
        {
            CalcularImporte(6);
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {
            int suc = 0;
            foreach (Sucursal sucur in conexion.BuscaSucursal())
            {
                if (sucur.NombreSucursal == cbSucursal.Text) suc = sucur.SucursalId;
            }

            if (conexion.UltimaCaja(suc).FechaCierreCaja == null)
            {
                btnCrearVenta.Enabled = false;

                int sucursalid = 0;
                string sucursalidstring = "";

                foreach (var sucur in conexion.BuscaSucursal())
                {
                    if (sucur.NombreSucursal == cbSucursal.Text) sucursalid = sucur.SucursalId;
                }
                sucursalidstring = sucursalid.ToString();

                do
                {
                    sucursalidstring = "0" + sucursalidstring;
                } while (sucursalidstring.Length < 3);

                int contador = 1;
                string contadorstring = "";
                foreach (Comprobante comp in conexion.BuscaComprobantes())
                {
                    if (comp.codigo.Contains("XV") && (comp.codigo.Substring(2
                        , 3).Contains(sucursalid.ToString()))) contador++;
                }
                contadorstring = contador.ToString();
                do
                {
                    contadorstring = "0" + contadorstring;
                } while (contadorstring.Length < 6);


                comprobante.codigo = "XV" + sucursalidstring + "-" + contadorstring;
                comprobante.Importe = double.Parse(lblTotalVenta.Text);
                comprobante.Bonificacion = double.Parse(tbDescuentoTotalVenta.Text);
                comprobante.FechaAlta = DateTime.Now;

                int clienteid = 0;

                foreach (var client in conexion.BuscaCliente())
                {
                    if (client.RazonSocial == CBxCliente.Text) clienteid = client.PersonaJuridicaId;
                }

                comprobante.PersonaJuridicaId = clienteid;
                comprobante.TipoComprobanteId = 1;

                comprobante.SucursalId = sucursalid;
                comprobante.Efectivo = double.Parse(tbEfectivo.Text);
                comprobante.Tarjeta1 = double.Parse(tbTarjeta1.Text);
                comprobante.Tarjeta2 = double.Parse(tbTarjeta2.Text);
                comprobante.TarjDebito = double.Parse(tbTarjetaDebito.Text);
                comprobante.Transferencia = double.Parse(tbTransferencia.Text);
                comprobante.GedNet = double.Parse(tbGedNet.Text);
                comprobante.MercadoPago = double.Parse(tbMercadoPago.Text);
                comprobante.UserName = CBxUsuario.Text;

                //validar y crear la venta

                if ((dgvProductosVenta.DataSource != null) && (double.Parse(lblTotalVenta.Text)
                    == double.Parse(tbTarjeta1.Text) + double.Parse(tbTarjeta2.Text)
                    + double.Parse(tbTarjetaDebito.Text) + double.Parse(tbTransferencia.Text)
                    + double.Parse(tbGedNet.Text) + double.Parse(tbMercadoPago.Text)
                    + double.Parse(tbEfectivo.Text)))
                {
                    try
                    {
                        conexion.NuevaVenta(comprobante, detallesDB);
                        DialogResult resultado = MessageBox.Show("Su venta ha sido guardada, ¿desea imprimir un comprobante?", "Terminar", MessageBoxButtons.OKCancel);

                        if (resultado == DialogResult.OK)
                        {
                            foreach (Comprobante item in conexion.BuscaComprobantes())
                            {
                                if (comprobante.codigo == item.codigo)
                                    comprobante.ComprobanteId = item.ComprobanteId;
                            }

                            DetalleVenta imprimir = new DetalleVenta(comprobante);
                            imprimir.MdiParent = ParentForm;
                            imprimir.Show();
                        }
                        else
                        {
                            this.Close();
                        }
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Error al intentar cargar la venta");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede continuar con la venta, compruebe los datos cargados");
                }

            }
            else
            {
                MessageBox.Show("Debe iniciar la caja antes de realizar la venta");
            }
        }

        #region ComprobacionesForm;
        private void tbTarjeta1_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbTarjeta1.TextLength < 1) tbTarjeta1.Text = "0";
        }

        private void tbTarjeta2_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbTarjeta2.TextLength < 1) tbTarjeta2.Text = "0";

        }

        private void tbTarjetaDebito_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbTarjetaDebito.TextLength < 1) tbTarjetaDebito.Text = "0";

        }

        private void tbMercadoPago_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbMercadoPago.TextLength < 1) tbMercadoPago.Text = "0";

        }

        private void tbTransferencia_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbTransferencia.TextLength < 1) tbTransferencia.Text = "0";

        }

        private void tbGedNet_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbGedNet.TextLength < 1) tbGedNet.Text = "0";
        }

        private void tbEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbEfectivo.TextLength < 1) tbEfectivo.Text = "0";
        }

        private void tbDescuentoTotalVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbDescuentoTotalVenta.TextLength < 1) tbDescuentoTotalVenta.Text = "0";
        }

        private void tbPrecompra_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbPrecompra.TextLength < 1) tbPrecompra.Text = "0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBxCliente_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cbSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxBDescuentoProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxBDescuentoProducto.TextLength < 1) TxBDescuentoProducto.Text = "0";

        }

        private void TxBCantidadProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxBCantidadProducto.TextLength < 1) TxBCantidadProducto.Text = "1";
        }

        #endregion

        private void cbSucursal_Leave(object sender, EventArgs e)
        {
            int suc = 0;
            foreach (Sucursal sucur in conexion.BuscaSucursal())
            {
                if (sucur.NombreSucursal == cbSucursal.Text) suc = sucur.SucursalId;
            }

            if (conexion.UltimaCaja(suc).FechaCierreCaja != null)
            {
                lbEstadoCaja.Text = "Antes debe iniciar la caja de esa sucursal";
            }
            else
            {
                lbEstadoCaja.Text = "Caja abierta";
            }

            lbEstadoCaja.Visible = true;
        }

        private void TxBPrecioProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxBCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxBDescuentoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbTarjeta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }


        }

        private void tbTarjeta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbTarjetaDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbMercadoPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbTransferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbGedNet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void tbEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnLimpiarMedios_Click(object sender, EventArgs e)
        {
            tbTarjeta1.Text = "0";
            tbTarjeta2.Text = "0";
            tbTarjetaDebito.Text = "0";
            tbTransferencia.Text = "0";
            tbGedNet.Text = "0";
            tbMercadoPago.Text = "0";
            tbEfectivo.Text = "0";

            foreach (Label item in pnlabelsRecargos.Controls)
            {
                item.Visible = false;
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            //quita el producto del datagriidview
            productosagregados = productosagregados.FindAll(x => x.Codigo
            != (string)dgvProductosVenta.CurrentRow.Cells[0].Value);

            //quita el producto de la lista para enviar a base de datos

            List<DetalleFactura> filtrado = detallesDB.FindAll(x=>x.CadenaBusquedaProducto.Contains((string)dgvProductosVenta.CurrentRow.Cells[0].Value));
            detallesDB = detallesDB.FindAll(x=>x.ProductoId != filtrado[0].ProductoId);

            dgvProductosVenta.DataSource = null;
            dgvProductosVenta.DataSource = productosagregados;
        }
    }
}