using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ControlStock.Clases
{
    public class ConectionDB
    {
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;


        public void TestConexion()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                ConfigurationManager.RefreshSection("connectionStrings");
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Conectado con éxito a la base de datos");

                }
                conn.Close();
            }
            catch (System.Exception)
            {
                MessageBox.Show("La conexión tiene problemas, contáctese con el administrador del sistema");
            }
        }

        public void IniciarCaja(double cajainicial, int sucurid)
        {
            if (UltimaCaja(sucurid).FechaCierreCaja == null)
            {
                MessageBox.Show("Error, primero debe cerrar la caja anterior");
            }
            else
            {
                try
                {

                    ConectarDB();

                    string concatenado = "INSERT INTO caja (fechaCaja, montoCaja" +
                        ", SucursalId) VALUES (@fechacaja, @montocaja, @sucursalid)";

                    comando.Parameters.AddWithValue("@fechacaja", DateTime.Now);
                    comando.Parameters.AddWithValue("@montocaja", cajainicial);
                    comando.Parameters.AddWithValue("@sucursalid", sucurid);

                    comando.CommandText = concatenado;
                    comando.ExecuteNonQuery();

                    DesconectarDB();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


                MessageBox.Show("Caja iniciada exitosamente");
            }
        }
        public List<Caja> BuscarCajas()
        {
            ConectarDB();

            List<Caja> listacaja = new List<Caja>();

            comando.CommandText = "SELECT [CajaId], [fechaCaja], [fechaCierreCaja]" +
                ", [montoCaja], [SucursalId] FROM[baselaymar].[dbo].[caja]";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Caja aux = new Caja();
                aux.CajaId = lector.GetInt32(0);
                aux.FechaCaja = lector.GetDateTime(1);
                if (lector.IsDBNull(2))
                {
                    aux.FechaCierreCaja = null;
                }
                else
                {
                    aux.FechaCierreCaja = lector.GetDateTime(2);
                }

                aux.MontoCaja = lector.GetDouble(3);
                aux.SucursalId = lector.GetInt32(4);
                listacaja.Add(aux);
            }

            DesconectarDB();
            return listacaja;
        }
        public void CerrarCaja(Caja cajadecierre)
        {
            if (UltimaCaja(cajadecierre.SucursalId).FechaCierreCaja != null)
            {
                MessageBox.Show("La caja ya se encuentra cerrada", "Caja Cerrada"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //cierre caja
                    ConectarDB();
                    string concatenado = "UPDATE caja SET montoCaja=@monto" +
                        ", fechaCierreCaja=@fechacierre WHERE [CajaId]=@cajaid;";

                    comando.Parameters.AddWithValue("@monto", cajadecierre.MontoCaja);
                    comando.Parameters.AddWithValue("@fechacierre", cajadecierre.FechaCierreCaja);
                    comando.Parameters.AddWithValue("@cajaid", cajadecierre.CajaId);

                    comando.CommandText = concatenado;
                    comando.ExecuteNonQuery();
                    DesconectarDB();

                    //programar movimiento de caja

                    //se debe generar un movimiento de caja que sume o reste
                    //dependiendo de si hay faltante o sobrante par aluego poder listar
                    //los movimientos de caja sin inconsistencias.


                    //AjusteCaja();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    DesconectarDB();
                }
            }
        }

        public Caja UltimaCaja(int sucursalcaja)
        {
            Caja ultima = new Caja();

            foreach (Caja item in BuscarCajas())
            {
                if (item.SucursalId == sucursalcaja) ultima = item;
            }
            return ultima;
        }

        public void ActualizarCaja(int cajaid, double monto)
        {
            try
            {
                string concatenado = "UPDATE caja SET montoCaja=@monto" +
                " WHERE [CajaId]=@cajaid;";

                double cajadb = 0;

                foreach (Caja item in BuscarCajas())
                {
                    if (item.CajaId == cajaid) cajadb = item.MontoCaja;
                }

                comando.Parameters.AddWithValue("@monto", cajadb + monto);
                comando.Parameters.AddWithValue("@cajaid", cajaid);

                ConectarDB();
                comando.CommandText = concatenado;
                comando.ExecuteNonQuery();
                DesconectarDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DesconectarDB();
            }

        }
        public void ActualizaMP(MedioPago medio)
        {
            try
            {
                string concatenado = "UPDATE medioPago SET tarjeta1=@primero" +
                    ", tarjeta2=@segundo, tarjetadebito=@tercero, transferenciabancaria=@cuarto" +
                    ", mercadopago=@quinto, gednet=@sexto WHERE [Id]='1';";

                comando.Parameters.AddWithValue("@primero", medio.Tarjeta1);
                comando.Parameters.AddWithValue("@segundo", medio.Tarjeta2);
                comando.Parameters.AddWithValue("@tercero", medio.TarjetaDebito);
                comando.Parameters.AddWithValue("@cuarto", medio.TrnsfBancaria);
                comando.Parameters.AddWithValue("@quinto", medio.Mercadopago);
                comando.Parameters.AddWithValue("@sexto", medio.Gednet);

                ConectarDB();
                comando.CommandText = concatenado;
                comando.ExecuteNonQuery();
                DesconectarDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DesconectarDB();
            }

        }

        public MedioPago BuscaMediosPagos()
        {
            MedioPago mpDB = new MedioPago();
            string comand = "SELECT [Id],[tarjeta1],[tarjeta2],[tarjetadebito]" +
                ",[transferenciabancaria],[mercadopago],[gednet] FROM[baselaymar]" +
                ".[dbo].[medioPago] WHERE Id='1'";


            ConectarDB();
            comando.CommandText = comand;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                mpDB.Tarjeta1 = lector.GetDouble(1);
                mpDB.Tarjeta2 = lector.GetDouble(2);
                mpDB.TarjetaDebito = lector.GetDouble(3);
                mpDB.TrnsfBancaria = lector.GetDouble(4);
                mpDB.Mercadopago = lector.GetDouble(5);
                mpDB.Gednet = lector.GetDouble(6);
            }

            DesconectarDB();
            return mpDB;
        }

        private void ConectarDB()
        {
            try
            {
                ConfigurationManager.RefreshSection("connectionStrings");
                conexion.ConnectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
                conexion.Open();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Alerta, la conexión con la base de datos tiene problemas, deberá reiniciar el programa para intentar reparar la conexión.");
            }
        }
        private void DesconectarDB()
        {
            conexion.Close();
        }

        public List<Producto> BuscarProductos()
        {
            ConectarDB();

            List<Producto> listaproductos = new List<Producto>();

            comando.CommandText = "SELECT [ProductoId],[nombre]" +
            ",[descripcion],[precioUnitario],[fechaAlta],[fechaBaja],[porcentajeRentabilidad]" +
            ",[talle],[color],[marca],[ProveedorId],[codigo] FROM[baselaymar].[dbo].[producto]";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                if (lector.IsDBNull(5))
                {
                    Producto aux = new Producto();
                    aux.ProductoId = lector.GetInt32(0);
                    aux.Nombre = lector.GetString(1);
                    if (lector.IsDBNull(2))
                    {
                        aux.Descripcion = "";
                    }
                    else
                    {
                        aux.Descripcion = lector.GetString(2);
                    }

                    aux.PrecioUnitario = lector.GetDouble(3);
                    aux.FechaAlta = lector.GetDateTime(4);
                    aux.FechaBaja = null;
                    aux.Rentabilidad = lector.GetDouble(6);

                    if (lector.IsDBNull(7))
                    {
                        aux.Talle = "0";
                    }
                    else
                    {
                        aux.Talle = lector.GetString(7);
                    }
                    if (lector.IsDBNull(8))
                    {
                        aux.Color = "0";
                    }
                    else
                    {
                        aux.Color = lector.GetString(8);
                    }
                    if (lector.IsDBNull(9))
                    {
                        aux.Marca = "0";
                    }
                    else
                    {
                        aux.Marca = lector.GetString(9);
                    }
                    aux.ProveedorId = lector.GetInt32(10);

                    if (lector.IsDBNull(11))
                    {
                        aux.Codigo = "0";
                    }
                    else
                    {
                        aux.Codigo = lector.GetString(11);
                    }
                    listaproductos.Add(aux);
                }
            }

            DesconectarDB();
            return listaproductos;
        }
        public List<Stock> BuscaStock()
        {
            List<Stock> listastock = new List<Stock>();
            ConectarDB();

            comando.CommandText = "SELECT [StockId],[cantidad],[SucursalId]" +
                ",[ProductoId] FROM[baselaymar].[dbo].[stock]";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Stock nuevostock = new Stock();
                nuevostock.StockId = lector.GetInt32(0);
                nuevostock.Cantidad = lector.GetInt32(1);
                nuevostock.SucursalId = lector.GetInt32(2);
                nuevostock.ProductoId = lector.GetInt32(3);

                listastock.Add(nuevostock);
            }
            DesconectarDB();
            return listastock;
        }
        public int BuscaStockEspecifica(int productoid, int sucursalid)
        {
            List<Stock> listastock = BuscaStock();
            listastock = listastock.FindAll(x => x.ProductoId == productoid);
            listastock = listastock.FindAll(x => x.SucursalId == sucursalid);
            int StockId = listastock[0].StockId;

            return StockId;
        }

        public List<Sucursal> BuscaSucursal()
        {
            List<Sucursal> listasucursal = new List<Sucursal>();
            ConectarDB();
            comando.CommandText = "SELECT [SucursalId],[nombreSucursal],[fechaAlta]" +
                ",[fechaBaja] FROM[baselaymar].[dbo].[sucursal]";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Sucursal nuevasucursal = new Sucursal();
                nuevasucursal.SucursalId = lector.GetInt32(0);
                nuevasucursal.NombreSucursal = lector.GetString(1);
                nuevasucursal.FechaAlta = lector.GetDateTime(2);

                if (lector.IsDBNull(3))
                {
                    nuevasucursal.FechaBaja = null;
                }
                else
                {
                    nuevasucursal.FechaBaja = lector.GetDateTime(3);
                }

                listasucursal.Add(nuevasucursal);
            }
            DesconectarDB();

            return listasucursal;
        }

        public List<Sucursal> BuscaSucursalActiva()
        {
            List<Sucursal> listasucursal = new List<Sucursal>();
            ConectarDB();
            comando.CommandText = "SELECT [SucursalId],[nombreSucursal],[fechaAlta]" +
                ",[fechaBaja] FROM[baselaymar].[dbo].[sucursal]";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Sucursal nuevasucursal = new Sucursal();
                nuevasucursal.SucursalId = lector.GetInt32(0);
                nuevasucursal.NombreSucursal = lector.GetString(1);
                nuevasucursal.FechaAlta = lector.GetDateTime(2);

                if (lector.IsDBNull(3))
                {
                    nuevasucursal.FechaBaja = null;
                }
                else
                {
                    nuevasucursal.FechaBaja = lector.GetDateTime(3);
                }

                listasucursal.Add(nuevasucursal);
            }
            DesconectarDB();

            listasucursal = listasucursal.FindAll(x => x.FechaBaja == null);
            return listasucursal;
        }

        public List<Comprobante> BuscaComprobantes()
        {
            List<Comprobante> listacomp = new List<Comprobante>();
            ConectarDB();
            comando.CommandText = "SELECT [ComprobanteId],[codigo],[importe]" +
                ",[bonificacion],[fechaAlta],[fechaBaja],[PersonaJuridicaId]" +
                ",[TipoComprobanteId],[SucursalId],[efectivo],[tarjeta],[UserName]" +
                ",[Tarjeta1],[Tarjeta2],[TarjDebito],[Transferencia],[GedNet]" +
                ",[Mercadopago] FROM[baselaymar].[dbo].[comprobante]";
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Comprobante aux = new Comprobante();

                aux.ComprobanteId = lector.GetInt32(0);
                aux.codigo = lector.GetString(1);
                aux.Importe = lector.GetDouble(2);
                aux.Bonificacion = lector.GetDouble(3);
                aux.FechaAlta = lector.GetDateTime(4);
                if (lector.IsDBNull(5))
                {
                    aux.FechaBaja = null;
                }
                else
                {
                    aux.FechaBaja = lector.GetDateTime(5);
                }
                aux.PersonaJuridicaId = lector.GetInt32(6);
                aux.TipoComprobanteId = lector.GetInt32(7);
                aux.SucursalId = lector.GetInt32(8);
                aux.Efectivo = lector.GetDouble(9);
                aux.Tarjeta = lector.GetDouble(10);
                if (lector.IsDBNull(11))
                {
                    aux.UserName = "";
                }
                else
                {
                    aux.UserName = lector.GetString(11);
                }

                if (lector.IsDBNull(12))
                {
                    aux.Tarjeta1 = 0;
                }
                else
                {
                    aux.Tarjeta1 = lector.GetDouble(12);
                }

                if (lector.IsDBNull(13))
                {
                    aux.Tarjeta2 = 0;
                }
                else
                {
                    aux.Tarjeta2 = lector.GetDouble(13);
                }

                if (lector.IsDBNull(14))
                {
                    aux.TarjDebito = 0;
                }
                else
                {
                    aux.TarjDebito = lector.GetDouble(14);
                }

                if (lector.IsDBNull(15))
                {
                    aux.Transferencia = 0;
                }
                else
                {
                    aux.Transferencia = lector.GetDouble(15);
                }

                if (lector.IsDBNull(16))
                {
                    aux.GedNet = 0;
                }
                else
                {
                    aux.GedNet = lector.GetDouble(16);
                }
                if (lector.IsDBNull(17))
                {
                    aux.MercadoPago = 0;
                }
                else
                {
                    aux.MercadoPago = lector.GetDouble(17);
                }

                listacomp.Add(aux);
            }
            DesconectarDB();
            return listacomp;
        }
        public List<DetalleFactura> BuscaDetalleFactura()
        {
            List<DetalleFactura> listadetfact = new List<DetalleFactura>();
            ConectarDB();
            comando.CommandText = "SELECT [DetalleFacturaId],[cantidad],[subtotal],[bonificacion]" +
                ",[fechaAlta],[fechaBaja],[ProductoId],[cadenaBusquedaProducto],[ComprobanteId]" +
                " FROM[baselaymar].[dbo].[detalleFactura]";
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                DetalleFactura aux = new DetalleFactura();

                aux.DetalleFacturaId = lector.GetInt32(0);
                aux.Cantidad = lector.GetInt32(1);
                aux.Subtotal = lector.GetDouble(2);
                aux.Bonificacion = lector.GetDouble(3);
                aux.FechaAlta = lector.GetDateTime(4);
                if (lector.IsDBNull(5))
                {
                    aux.FechaBaja = null;
                }
                else
                {
                    aux.FechaBaja = lector.GetDateTime(5);
                }
                aux.ProductoId = lector.GetInt32(6);

                if (lector.IsDBNull(7))
                {
                    aux.CadenaBusquedaProducto = "";
                }
                else
                {
                    aux.CadenaBusquedaProducto = lector.GetString(7);
                }

                aux.ComprobanteId = lector.GetInt32(8);

                listadetfact.Add(aux);

            }
            DesconectarDB();
            return listadetfact;
        }
        public List<Cliente> BuscaCliente()
        {
            List<Cliente> listaclientes = new List<Cliente>();
            ConectarDB();
            comando.CommandText = "SELECT [PersonaJuridicaId],[cuit],[razonSocial]" +
                ",[nombreFantasia],[direccion1],[direccion2],[numeroTelefono1]" +
                ",[numeroTelefono2],[fechaAlta],[fechaBaja],[Discriminator],[ClienteId]" +
                ",[ProveedorId],[porcentajeRentabilidad] FROM[baselaymar].[dbo].[personaJuridica]";

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Cliente nuevocliente = new Cliente();
                nuevocliente.PersonaJuridicaId = lector.GetInt32(0);
                nuevocliente.RazonSocial = lector.GetString(2);
                nuevocliente.FechaAlta = lector.GetDateTime(8);

                if (lector.IsDBNull(9))
                {
                    nuevocliente.FechaBaja = null;
                }
                else
                {
                    nuevocliente.FechaBaja = lector.GetDateTime(9);
                }




                if (lector.IsDBNull(11))
                {
                    nuevocliente.ClienteId = "";
                }
                else
                {
                    nuevocliente.ClienteId = lector.GetString(11);
                }

                listaclientes.Add(nuevocliente);

            }

            listaclientes = listaclientes.FindAll(x => x.ClienteId != "");

            DesconectarDB();
            return listaclientes;
        }
        public List<Usuario> BuscaUsuario()
        {
            List<Usuario> listausuarios = new List<Usuario>();
            ConectarDB();
            comando.CommandText = "SELECT [Id],[UserName] FROM[baselaymar].[dbo].[AspNetUsers]";
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Usuario nuevousuario = new Usuario();
                nuevousuario.Id = lector.GetString(0);
                nuevousuario.UserName = lector.GetString(1);
                listausuarios.Add(nuevousuario);
            }
            DesconectarDB();
            return listausuarios;
        }

        public void NuevaVenta(Comprobante comprobante, List<DetalleFactura> listadetalle)
        {
            Comprobante comprobante_comun = comprobante;
            int caja_comun = 0;

            //Crea el comprobante de venta
            try
            {
                #region ComprobantedeVenta

                ConectarDB();

                string concatenado = "INSERT INTO comprobante (codigo, importe, bonificacion" +
                    ", fechaAlta, PersonaJuridicaId, TipoComprobanteId" +
                    ", SucursalId, efectivo, tarjeta, UserName, Tarjeta1, Tarjeta2" +
                    ", TarjDebito, Transferencia, GedNet, Mercadopago) VALUES (@cod" +
                    ", @importe, @bonificacion, @fechaAlta, @personajuridicaid" +
                    ", @tipocomprobanteid, @sucursalid, @efectivo, @tarjeta, @username" +
                    ", @tarjeta1, @tarjeta2, @tarjdebito, @transferencia, @gednet, @mercadopago)";

                comando.Parameters.AddWithValue("@cod", comprobante.codigo);
                comando.Parameters.AddWithValue("@importe", comprobante.Importe);
                comando.Parameters.AddWithValue("@bonificacion", comprobante.Bonificacion);
                comando.Parameters.AddWithValue("@fechaAlta", comprobante.FechaAlta);
                comando.Parameters.AddWithValue("@personajuridicaid", comprobante.PersonaJuridicaId);
                comando.Parameters.AddWithValue("@tipocomprobanteid", comprobante.TipoComprobanteId);
                comando.Parameters.AddWithValue("@sucursalid", comprobante.SucursalId);
                comando.Parameters.AddWithValue("@efectivo", comprobante.Efectivo);
                comando.Parameters.AddWithValue("@tarjeta", comprobante.Tarjeta);
                comando.Parameters.AddWithValue("@username", comprobante.UserName);
                comando.Parameters.AddWithValue("@tarjeta1", comprobante.Tarjeta1);
                comando.Parameters.AddWithValue("@tarjeta2", comprobante.Tarjeta2);
                comando.Parameters.AddWithValue("@tarjdebito", comprobante.TarjDebito);
                comando.Parameters.AddWithValue("@transferencia", comprobante.Transferencia);
                comando.Parameters.AddWithValue("@gednet", comprobante.GedNet);
                comando.Parameters.AddWithValue("@mercadopago", comprobante.MercadoPago);
                comando.CommandText = concatenado;
                comando.ExecuteNonQuery();

                DesconectarDB();

                foreach (Comprobante item in BuscaComprobantes())
                {
                    if (comprobante.codigo == item.codigo)
                        comprobante_comun.ComprobanteId = item.ComprobanteId;
                }

                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Error creando el comprobante de la venta en DB");
            }
            //Crea el/los detalles de la venta
            try
            {
                #region Detallesdeventa
                int ultcomp = UltimoComprobanteVenta();
                int i = 0;

                foreach (DetalleFactura detalle in listadetalle)
                {
                    ConectarDB();

                    string instruccion = "INSERT into detalleFactura (cantidad, subtotal" +
                    ", bonificacion, fechaAlta, ProductoId, cadenaBusquedaProducto" +
                    ", ComprobanteId) VALUES (@cantidad" + i + ", @subtotal" + i + ", @bonif" + i + ", @fechAlta" + i + "" +
                    ", @productoid" + i + ", @cadenabusquedaproducto" + i + ", @comprobanteid" + i + ")";

                    comando.CommandText = instruccion;

                    comando.Parameters.AddWithValue("@cantidad" + i, detalle.Cantidad);
                    comando.Parameters.AddWithValue("@subtotal" + i, detalle.Subtotal);
                    comando.Parameters.AddWithValue("@bonif" + i, detalle.Bonificacion);
                    comando.Parameters.AddWithValue("@fechAlta" + i, detalle.FechaAlta);
                    comando.Parameters.AddWithValue("@productoid" + i, detalle.ProductoId);
                    comando.Parameters.AddWithValue("@cadenabusquedaproducto" + i, detalle.CadenaBusquedaProducto);
                    comando.Parameters.AddWithValue("@comprobanteid" + i, ultcomp);
                    comando.ExecuteNonQuery();
                    DesconectarDB();
                    i++;
                }
                #endregion

            }
            catch (Exception)
            {
                MessageBox.Show("Error creando el/los detalles de la venta");
            }
            //Actualizar Stock
            try
            {
                #region ActualizarStock

                foreach (DetalleFactura item in listadetalle)
                {
                    ActualizarStock(item.ProductoId, item.Cantidad, comprobante.SucursalId);
                }

                #endregion

            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando Stock");
            }
            //Actualizar Caja
            try
            {
                #region ActualizarCaja

                foreach (Caja item in BuscarCajas())
                {
                    if (comprobante.SucursalId == item.SucursalId) caja_comun = item.CajaId;
                }

                ActualizarCaja(caja_comun, comprobante_comun.Efectivo);
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Error Actualizando Caja DB");
            }

            //Actualizar MovimientoStock
            try
            {

                NuevoMovimientoStock(comprobante_comun);

            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando Movimiento de Stock DB");
            }
            //Actualizar MovimientoCaja
            try
            {
                NuevoMovimientoCaja(comprobante_comun, caja_comun);
            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando MovimientoCaja DB");
            }
        }

        public void NuevoMovimientoStock(Comprobante comprobante)
        {
            try
            {
                List<DetalleFactura> detalles = BuscaDetalleFactura().FindAll(x => x.ComprobanteId
                == comprobante.ComprobanteId);

                int f = 300;
                string comandostring = "";
                foreach (DetalleFactura item in detalles)
                {
                    f++;

                    comandostring = "INSERT into movimientoStock (cantidad, entra" +
                        ", sale, fechaAlta, StockId, ComprobanteId, TipomovimientoStockId)" +
                        " VALUES (@alpha" + f + ", @entra" + f + ", @sale" + f + ", @beta" + f + "" +
                    ", @stockid" + f + ", @comprobanteid" + f + ", @tipomovimientostockid" + f + ")";


                    comando.Parameters.AddWithValue("@alpha" + f, item.Cantidad);
                    comando.Parameters.AddWithValue("@entra" + f, false);
                    comando.Parameters.AddWithValue("@sale" + f, true);
                    comando.Parameters.AddWithValue("@beta" + f, comprobante.FechaAlta);
                    comando.Parameters.AddWithValue("@stockid" + f
                        , BuscaStockEspecifica(item.ProductoId, comprobante.SucursalId));
                    comando.Parameters.AddWithValue("@comprobanteid" + f, comprobante.ComprobanteId);
                    comando.Parameters.AddWithValue("@tipomovimientostockid" + f, 3);

                    comando.CommandText = comandostring;
                    ConectarDB();
                    comando.ExecuteNonQuery();
                    DesconectarDB();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.Data.ToString());
            }
        }
        public void NuevoMovimientoCaja(Comprobante comprobante, int cajid)
        {
            string comandostring = "";
            comandostring = "INSERT into movimientoCaja (entra, sale" +
                    ", fechaAlta, importe, tipoMovimientoCajaId" +
                    ", CajaId, ComprobanteId) VALUES (@uno, @dos, @tres, @cuatro, @cinco, @seis, @siete)";

            comando.Parameters.AddWithValue("@uno", true);
            comando.Parameters.AddWithValue("@dos", false);
            comando.Parameters.AddWithValue("@tres", comprobante.FechaAlta);
            comando.Parameters.AddWithValue("@cuatro", comprobante.Efectivo);
            comando.Parameters.AddWithValue("@cinco", 3);
            comando.Parameters.AddWithValue("@seis", cajid);
            comando.Parameters.AddWithValue("@siete", comprobante.ComprobanteId);

            comando.CommandText = comandostring;
            ConectarDB();
            comando.ExecuteNonQuery();
            DesconectarDB();
        }

        public void ActualizarStock(int productoid, int cantidad, int sucursalid)
        {

            int cantidadactual = 0;
            foreach (Stock item in BuscaStock())
            {
                if (item.ProductoId == productoid && item.SucursalId == sucursalid)
                    cantidadactual = item.Cantidad;
            }
            string concatenado = "UPDATE stock SET Cantidad=@cant" + productoid
                + " WHERE [ProductoId]=@productid" + productoid + " and" +
                " [SucursalId]=@sucid" + productoid + ";";

            comando.Parameters.AddWithValue("@cant" + productoid, cantidadactual - cantidad);
            comando.Parameters.AddWithValue("@productid" + productoid, productoid);
            comando.Parameters.AddWithValue("@sucid" + productoid, sucursalid);

            ConectarDB();
            comando.CommandText = concatenado;
            comando.ExecuteNonQuery();
            DesconectarDB();
        }

        public int UltimoComprobanteVenta()
        {
            int ultimo = 0;
            ConectarDB();
            comando.CommandText = "SELECT [ComprobanteId] FROM[baselaymar].[dbo]" +
                ".[comprobante] WHERE [TipoComprobanteId]='1'";

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ultimo = lector.GetInt32(0);
            }

            DesconectarDB();

            return ultimo;
        }
    }
}