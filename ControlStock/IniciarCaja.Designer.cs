
namespace ControlStock
{
    partial class IniciarCaja
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCajaInicial = new System.Windows.Forms.TextBox();
            this.btnAceptarCajaInicial = new System.Windows.Forms.Button();
            this.btnCajaInicialCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el monto de caja inicial";
            // 
            // tbCajaInicial
            // 
            this.tbCajaInicial.Location = new System.Drawing.Point(277, 61);
            this.tbCajaInicial.Name = "tbCajaInicial";
            this.tbCajaInicial.Size = new System.Drawing.Size(154, 20);
            this.tbCajaInicial.TabIndex = 1;
            this.tbCajaInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCajaInicial_KeyPress);
            // 
            // btnAceptarCajaInicial
            // 
            this.btnAceptarCajaInicial.Location = new System.Drawing.Point(118, 120);
            this.btnAceptarCajaInicial.Name = "btnAceptarCajaInicial";
            this.btnAceptarCajaInicial.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarCajaInicial.TabIndex = 2;
            this.btnAceptarCajaInicial.Text = "Aceptar";
            this.btnAceptarCajaInicial.UseVisualStyleBackColor = true;
            this.btnAceptarCajaInicial.Click += new System.EventHandler(this.btnAceptarCajaInicial_Click);
            // 
            // btnCajaInicialCancelar
            // 
            this.btnCajaInicialCancelar.Location = new System.Drawing.Point(277, 120);
            this.btnCajaInicialCancelar.Name = "btnCajaInicialCancelar";
            this.btnCajaInicialCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCajaInicialCancelar.TabIndex = 3;
            this.btnCajaInicialCancelar.Text = "Cancelar";
            this.btnCajaInicialCancelar.UseVisualStyleBackColor = true;
            this.btnCajaInicialCancelar.Click += new System.EventHandler(this.btnCajaInicialCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sucursal";
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(277, 15);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(121, 21);
            this.cbSucursales.TabIndex = 5;
            this.cbSucursales.Leave += new System.EventHandler(this.cbSucursales_Leave);
            // 
            // IniciarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 200);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCajaInicialCancelar);
            this.Controls.Add(this.btnAceptarCajaInicial);
            this.Controls.Add(this.tbCajaInicial);
            this.Controls.Add(this.label1);
            this.Name = "IniciarCaja";
            this.Text = "IniciarCaja";
            this.Load += new System.EventHandler(this.IniciarCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCajaInicial;
        private System.Windows.Forms.Button btnAceptarCajaInicial;
        private System.Windows.Forms.Button btnCajaInicialCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSucursales;
    }
}