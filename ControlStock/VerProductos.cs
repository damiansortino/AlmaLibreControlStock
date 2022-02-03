using ControlStock.Clases;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class VerProductos : Form
    {
        ConectionDB conexion = new ConectionDB();

        public VerProductos()
        {
            InitializeComponent();
        }

        private void VerProductos_Load(object sender, System.EventArgs e)
        {
            ActualizarAutocompletados();

        }

        private void ActualizarAutocompletados()
        {
            AutoCompleteStringCollection listasolonombres = new AutoCompleteStringCollection();
            AutoCompleteStringCollection listasolomarcas = new AutoCompleteStringCollection();

            foreach (Producto prod in conexion.BuscarProductos())
            {
                if (prod.FechaBaja == null)
                    listasolonombres.Add(prod.Nombre);
                listasolomarcas.Add(prod.Marca);
            }
            tbNombre.AutoCompleteCustomSource = listasolonombres;
            tbMarca.AutoCompleteCustomSource = listasolomarcas;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            List<Producto> resultados_de_busqueda = new List<Producto>();
            int caso = 100;

            if (!(tbNombre.Text == "")) { caso = 0; }
            if (!(tbMarca.Text == "")) { caso = 1; }
            if (!(tbCodigo.Text == "")) { caso = 2; }

            switch (caso)
            {
                case 0:
                    foreach (Producto prod in conexion.BuscarProductos())
                    {
                        if (prod.Nombre.ToUpper().Contains(tbNombre.Text.ToUpper()))
                        {
                            resultados_de_busqueda.Add(prod);
                        }
                    }
                    break;
                case 1:
                    foreach (Producto prod in conexion.BuscarProductos())
                    {
                        if (prod.Marca.ToUpper().Contains(tbMarca.Text.ToUpper()))
                        {
                            resultados_de_busqueda.Add(prod);
                        }
                    }
                    break;
                case 2:
                    foreach (Producto prod in conexion.BuscarProductos())
                    {
                        if (prod.Codigo.ToUpper().Contains(tbCodigo.Text.ToUpper()))
                        {
                            resultados_de_busqueda.Add(prod);
                        }
                    }
                    break;

                default:
                    break;
            }

            if (resultados_de_busqueda.Count == 0) { MessageBox.Show("No se encontraron productos"); }

            for (int i = 0; i < resultados_de_busqueda.Count; i++)
            {
                resultados_de_busqueda[i].PrecioUnitario = resultados_de_busqueda[i].PrecioUnitario
                    + ((resultados_de_busqueda[i].PrecioUnitario * resultados_de_busqueda[i]
                    .Rentabilidad) / 100);
            }

            ProductosDGV(resultados_de_busqueda);
            ActualizarAutocompletados();
        }

        private void ProductosDGV(List<Producto> mostrar)
        {
            dgvMuestraResultados.DataSource = null;
            dgvMuestraResultados.DataSource = mostrar;


            dgvMuestraResultados.Columns[0].Visible = false;
            dgvMuestraResultados.Columns[1].Visible = false;
            dgvMuestraResultados.Columns[4].Visible = false;
            dgvMuestraResultados.Columns[7].Visible = false;
            dgvMuestraResultados.Columns[6].Visible = false;
            dgvMuestraResultados.Columns[8].Visible = false;
            dgvMuestraResultados.Columns[5].HeaderText = "Precio";
            dgvMuestraResultados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMuestraResultados.Visible = true;
        }
        private void StockDGV(int filtro)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("SucursalId");
            tabla.Columns.Add("Sucursal");

            string sucur = "";

            foreach (Stock stock in conexion.BuscaStock())
            {
                if (stock.ProductoId == filtro)
                {
                    foreach (Sucursal item in conexion.BuscaSucursal())
                    {
                        if (item.SucursalId == stock.SucursalId) sucur = item.NombreSucursal;
                    }
                    tabla.Rows.Add(stock.Cantidad, stock.SucursalId, sucur);
                }
            }

            dgvStock.DataSource = null;
            dgvStock.Visible = false;
            dgvStock.DataSource = tabla;
            dgvStock.Columns[1].Visible = false;
            dgvStock.Visible = true;
        }

        #region Proteccion_Multibusqueda


        private void tbMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbNombre.Text = "";
            tbCodigo.Text = "";

        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbMarca.Text = "";
            tbNombre.Text = "";


        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbMarca.Text = "";
            tbCodigo.Text = "";
        }
        #endregion

        private void dgvMuestraResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto seleccionado = (Producto)dgvMuestraResultados.CurrentRow.DataBoundItem;
            StockDGV(seleccionado.ProductoId);
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}