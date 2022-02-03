using ControlStock.Clases;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class PruebaConexion : Form
    {
        public PruebaConexion()
        {
            InitializeComponent();
        }

        private void btnPruebaDB_Click(object sender, System.EventArgs e)
        {
            ConectionDB pruebaconexion = new ConectionDB();
            pruebaconexion.TestConexion();
            this.Close();

        }
    }
}
