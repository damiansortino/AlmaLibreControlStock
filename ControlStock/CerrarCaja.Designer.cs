
namespace ControlStock
{
    partial class CerrarCaja
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
            this.lbDeberiaTener = new System.Windows.Forms.Label();
            this.tbCierreCaja = new System.Windows.Forms.TextBox();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el monto en efectivo actual de su caja";
            // 
            // lbDeberiaTener
            // 
            this.lbDeberiaTener.AutoSize = true;
            this.lbDeberiaTener.Location = new System.Drawing.Point(409, 50);
            this.lbDeberiaTener.Name = "lbDeberiaTener";
            this.lbDeberiaTener.Size = new System.Drawing.Size(0, 13);
            this.lbDeberiaTener.TabIndex = 1;
            // 
            // tbCierreCaja
            // 
            this.tbCierreCaja.Location = new System.Drawing.Point(259, 47);
            this.tbCierreCaja.Name = "tbCierreCaja";
            this.tbCierreCaja.Size = new System.Drawing.Size(128, 20);
            this.tbCierreCaja.TabIndex = 2;
            this.tbCierreCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCierreCaja_KeyPress);
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Location = new System.Drawing.Point(132, 88);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarCaja.TabIndex = 3;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(412, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(259, 6);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(121, 21);
            this.cbSucursales.TabIndex = 7;
            this.cbSucursales.Leave += new System.EventHandler(this.cbSucursales_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sucursal";
            // 
            // CerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 156);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.tbCierreCaja);
            this.Controls.Add(this.lbDeberiaTener);
            this.Controls.Add(this.label1);
            this.Name = "CerrarCaja";
            this.Text = "CerrarCaja";
            this.Load += new System.EventHandler(this.CerrarCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDeberiaTener;
        private System.Windows.Forms.TextBox tbCierreCaja;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label label2;
    }
}