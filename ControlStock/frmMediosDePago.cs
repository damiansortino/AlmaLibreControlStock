using ControlStock.Clases;
using System;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class frmMediosDePago : Form
    {
        ConectionDB conexion = new ConectionDB();

        public frmMediosDePago()
        {
            InitializeComponent();
        }

        private void frmMediosDePago_Load(object sender, EventArgs e)
        {
            MedioPago mediopago = LeerMediosPago();
            tbTarjeta1.Text = mediopago.Tarjeta1.ToString();
            tbTrjeta2.Text = mediopago.Tarjeta2.ToString();
            tbTarjetaDebito.Text = mediopago.TarjetaDebito.ToString();
            tbTransfBancaria.Text = mediopago.TrnsfBancaria.ToString();
            tbMercadopago.Text = mediopago.Mercadopago.ToString();
            tbGednet.Text = mediopago.Gednet.ToString();
        }

        private void btnActualizarRecargos_Click(object sender, EventArgs e)
        {
            MedioPago mediopago = new MedioPago();

            mediopago.Tarjeta1 = float.Parse(tbTarjeta1.Text);
            mediopago.Tarjeta2 = float.Parse(tbTrjeta2.Text);
            mediopago.TarjetaDebito = float.Parse(tbTarjetaDebito.Text);
            mediopago.TrnsfBancaria = float.Parse(tbTransfBancaria.Text);
            mediopago.Mercadopago = float.Parse(tbMercadopago.Text);
            mediopago.Gednet = float.Parse(tbGednet.Text);

            ActualizarMediosPago(mediopago);
            MessageBox.Show("Recargos actualizados correctamente");
            this.Close();
        }

        private MedioPago LeerMediosPago()
        {
            return conexion.BuscaMediosPagos();
        }

        private void ActualizarMediosPago(MedioPago medio)
        {
            conexion.ActualizaMP(medio);
        }
    }
}
