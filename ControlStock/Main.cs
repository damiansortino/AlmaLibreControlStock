using System;
using System.Net;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void connectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PruebaConexion conectar = new PruebaConexion();
            conectar.MdiParent = this;
            conectar.Show();

        }

        private void buscarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerProductos buscaproductos = new VerProductos();
            buscaproductos.MdiParent = this;
            buscaproductos.Show();
        }

        private void ventasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerVentas verventas = new VerVentas();
            verventas.MdiParent = this;
            verventas.Show();
        }
        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblSubtotal nuevaventa = new lblSubtotal();
            nuevaventa.MdiParent = this;
            nuevaventa.Show();
        }

        private void mediosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMediosDePago mdpform = new frmMediosDePago();
            mdpform.MdiParent = this;
            mdpform.Show();
        }

        private void verCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarCaja iniciarcaja = new IniciarCaja();
            iniciarcaja.MdiParent = ParentForm;
            iniciarcaja.Show();
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarCaja cierredecaja = new CerrarCaja();
            cierredecaja.MdiParent = ParentForm;
            cierredecaja.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MessageBox.Show("bienvenid@s" + Environment.NewLine + Environment.NewLine
                + "Mejoras de la actualización!!!" + Environment.NewLine
                + Environment.NewLine + "*Se agregó la funcionalidad del boton" +
                " 'Eliminar Producto'" + Environment.NewLine + "*Se corrigió un error" +
                " al agregar productos, el boton se habilita solo cuando el código de" +
                " producto es corecto" + Environment.NewLine + "*Solucion a los problemas" +
                " con los centavos" + Environment.NewLine + "*Nuevo botón, ventas del día");
        }

        private void verIPDelServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            MessageBox.Show("Tú IP Local Es: " + localIP);
        }

        private void pathImgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popup_Path_Img nuevo = new popup_Path_Img();
            nuevo.MdiParent = ParentForm;
            nuevo.Show();
        }

        private void abrirAppSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirAppSetting = new OpenFileDialog();
            abrirAppSetting.ShowDialog();

            abrirAppSetting.OpenFile();
        }
    }
}
