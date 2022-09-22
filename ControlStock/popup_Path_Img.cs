using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class popup_Path_Img : Form
    {
        public popup_Path_Img()
        {
            InitializeComponent();
        }

        private void btn_AbrirPath_Click(object sender, EventArgs e)
        {
            ofd_abrir.ShowDialog();
        }

        //ver este asunto
        private void ofd_abrir_FileOk(object sender, CancelEventArgs e)
        {
            lbl_Path.Text = ofd_abrir.FileName.ToString().Substring(0, ofd_abrir.FileName.ToString().Length-8);
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["Img_Folder"] = lbl_Path.Text;
            ConfigurationManager.AppSettings["imgAlmaLibreTiket"] = ConfigurationManager.AppSettings["Img_Folder"] + "logo_almalibre.jpg";
            ConfigurationManager.RefreshSection("AppSettings");


            this.Close();
        }

        private void popup_Path_Img_Load(object sender, EventArgs e)
        {
            lbl_Path.Text = ConfigurationManager.AppSettings["Img_Folder"];
        }
    }
}
