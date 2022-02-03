
namespace ControlStock
{
    partial class PruebaConexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPruebaDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPruebaDB
            // 
            this.btnPruebaDB.Location = new System.Drawing.Point(48, 31);
            this.btnPruebaDB.Name = "btnPruebaDB";
            this.btnPruebaDB.Size = new System.Drawing.Size(250, 83);
            this.btnPruebaDB.TabIndex = 0;
            this.btnPruebaDB.Text = "Ejecutar Prueba de Conexion";
            this.btnPruebaDB.UseVisualStyleBackColor = true;
            this.btnPruebaDB.Click += new System.EventHandler(this.btnPruebaDB_Click);
            // 
            // PruebaConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 166);
            this.Controls.Add(this.btnPruebaDB);
            this.Name = "PruebaConexion";
            this.Text = "PruebaConexion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPruebaDB;
    }
}