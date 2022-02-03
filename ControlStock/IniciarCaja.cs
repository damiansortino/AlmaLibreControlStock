using ControlStock.Clases;
using System;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class IniciarCaja : Form
    {
        public IniciarCaja()
        {
            InitializeComponent();
        }

        ConectionDB conexion = new ConectionDB();

        private void btnCajaInicialCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void IniciarCaja_Load(object sender, EventArgs e)
        {
            cbSucursales.DataSource = conexion.BuscaSucursalActiva();
            cbSucursales.DisplayMember = "NombreSucursal";
        }
        private void btnAceptarCajaInicial_Click(object sender, EventArgs e)
        {
            ConectionDB conexion = new ConectionDB();
            int sucuridparaenviar = 0;
            foreach (Sucursal item in conexion.BuscaSucursal())
            {
                if (item.NombreSucursal == cbSucursales.Text) sucuridparaenviar = item.SucursalId;
            }
            conexion.IniciarCaja(double.Parse(tbCajaInicial.Text)
                , sucuridparaenviar);
            this.Close();
        }

        private void tbCajaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void cbSucursales_Leave(object sender, EventArgs e)
        {

            /*
            if (cbSucursales.Text == )
            {
                MessageBox.Show("Esta sucursal tiene una caja abierta");
            }
            */
        }
    }
}
