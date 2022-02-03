using ControlStock.Clases;
using System;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class CerrarCaja : Form
    {
        public CerrarCaja()
        {
            InitializeComponent();
        }

        ConectionDB conexion = new ConectionDB();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            int sucuridparaenviar = 0;

            foreach (Sucursal item in conexion.BuscaSucursal())
            {
                if (item.NombreSucursal == cbSucursales.Text) sucuridparaenviar = item.SucursalId;

            }

            string difcaja = "";
            double diferenciacaja = 0;

            Caja actual = new Caja();

            actual = conexion.UltimaCaja(sucuridparaenviar);

            if (actual.MontoCaja < double.Parse(tbCierreCaja.Text))
            {
                difcaja = "sobrante";
                diferenciacaja = double.Parse(tbCierreCaja.Text) - actual.MontoCaja;
            }
            else
            {
                if (actual.MontoCaja > double.Parse(tbCierreCaja.Text)) difcaja = "faltante";
                diferenciacaja = actual.MontoCaja - double.Parse(tbCierreCaja.Text);
            }

            if (actual.MontoCaja == double.Parse(tbCierreCaja.Text))
            {
                actual.FechaCierreCaja = DateTime.Now;
                conexion.CerrarCaja(actual);
                MessageBox.Show("Caja Cerrada Correctamente");
                this.Close();
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Ud está cerrando su caja" +
                    " con un " + difcaja + " de: $ " + diferenciacaja + " ¿Continuar" +
                    " cerrando de todos modos? ", "Atención!", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Exclamation);

                if (resultado == DialogResult.OK)
                {
                    if (difcaja == "sobrante")
                    {
                        actual.MontoCaja = actual.MontoCaja + diferenciacaja;
                    }
                    else
                    {
                        actual.MontoCaja = actual.MontoCaja - diferenciacaja;
                    }

                    actual.FechaCierreCaja = DateTime.Now;
                    conexion.CerrarCaja(actual);
                    MessageBox.Show("Caja Cerrada Correctamente", "Caja Cerrada"
                        , MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void CerrarCaja_Load(object sender, EventArgs e)
        {
            cbSucursales.DataSource = conexion.BuscaSucursalActiva();
            cbSucursales.DisplayMember = "NombreSucursal";
        }

        private void cbSucursales_Leave(object sender, EventArgs e)
        {
            int sucuridparaenviar = 0;

            foreach (Sucursal item in conexion.BuscaSucursalActiva())
            {
                if (item.NombreSucursal == cbSucursales.Text) sucuridparaenviar = item.SucursalId;

            }
            lbDeberiaTener.Text = "Debería tener $ " + conexion.UltimaCaja
                            (sucuridparaenviar).MontoCaja + " en su caja.";
            lbDeberiaTener.Visible = true;

        }

        private void tbCierreCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
