
namespace ControlStock
{
    partial class popup_Path_Img
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(popup_Path_Img));
            this.btn_AbrirPath = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_Path = new System.Windows.Forms.Label();
            this.ofd_abrir = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btn_AbrirPath
            // 
            this.btn_AbrirPath.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_AbrirPath.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AbrirPath.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_AbrirPath.Location = new System.Drawing.Point(164, 22);
            this.btn_AbrirPath.Name = "btn_AbrirPath";
            this.btn_AbrirPath.Size = new System.Drawing.Size(191, 38);
            this.btn_AbrirPath.TabIndex = 0;
            this.btn_AbrirPath.Text = "Buscar Carpeta";
            this.btn_AbrirPath.UseVisualStyleBackColor = false;
            this.btn_AbrirPath.Click += new System.EventHandler(this.btn_AbrirPath_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_ok.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_ok.Location = new System.Drawing.Point(33, 263);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(146, 40);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancelar.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Cancelar.Location = new System.Drawing.Point(379, 263);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(146, 40);
            this.btn_Cancelar.TabIndex = 2;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Path.Location = new System.Drawing.Point(12, 103);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(55, 25);
            this.lbl_Path.TabIndex = 3;
            this.lbl_Path.Text = "Ruta";
            // 
            // ofd_abrir
            // 
            this.ofd_abrir.FileName = "openFileDialog1";
            this.ofd_abrir.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_abrir_FileOk);
            // 
            // popup_Path_Img
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ControlStock.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btn_Cancelar;
            this.ClientSize = new System.Drawing.Size(559, 324);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_AbrirPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "popup_Path_Img";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "popup_Path_Img";
            this.Load += new System.EventHandler(this.popup_Path_Img_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AbrirPath;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.OpenFileDialog ofd_abrir;
    }
}