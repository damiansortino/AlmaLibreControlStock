
namespace ControlStock
{
    partial class VerVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMuestraVentas = new System.Windows.Forms.DataGridView();
            this.btnVentasSemana = new System.Windows.Forms.Button();
            this.btnVentasTodas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVentasDia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestraVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMuestraVentas
            // 
            this.dgvMuestraVentas.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Bisque;
            this.dgvMuestraVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMuestraVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMuestraVentas.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvMuestraVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMuestraVentas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMuestraVentas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMuestraVentas.Location = new System.Drawing.Point(0, 108);
            this.dgvMuestraVentas.Name = "dgvMuestraVentas";
            this.dgvMuestraVentas.ReadOnly = true;
            this.dgvMuestraVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMuestraVentas.Size = new System.Drawing.Size(919, 362);
            this.dgvMuestraVentas.TabIndex = 0;
            this.dgvMuestraVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMuestraVentas_CellClick);
            // 
            // btnVentasSemana
            // 
            this.btnVentasSemana.BackColor = System.Drawing.Color.White;
            this.btnVentasSemana.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Bisque;
            this.btnVentasSemana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.btnVentasSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasSemana.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasSemana.Location = new System.Drawing.Point(12, 23);
            this.btnVentasSemana.Name = "btnVentasSemana";
            this.btnVentasSemana.Size = new System.Drawing.Size(131, 79);
            this.btnVentasSemana.TabIndex = 1;
            this.btnVentasSemana.Text = "Ventas de la semana";
            this.btnVentasSemana.UseVisualStyleBackColor = false;
            this.btnVentasSemana.Click += new System.EventHandler(this.btnVentasSemana_Click);
            // 
            // btnVentasTodas
            // 
            this.btnVentasTodas.BackColor = System.Drawing.Color.White;
            this.btnVentasTodas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Bisque;
            this.btnVentasTodas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.btnVentasTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasTodas.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasTodas.Location = new System.Drawing.Point(172, 25);
            this.btnVentasTodas.Name = "btnVentasTodas";
            this.btnVentasTodas.Size = new System.Drawing.Size(132, 77);
            this.btnVentasTodas.TabIndex = 7;
            this.btnVentasTodas.Text = "Todas las ventas";
            this.btnVentasTodas.UseVisualStyleBackColor = false;
            this.btnVentasTodas.Click += new System.EventHandler(this.btnVentasTodas_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Bisque;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(756, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 71);
            this.button1.TabIndex = 8;
            this.button1.Text = "Mostrar detalle de la venta seleccionada";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVentasDia
            // 
            this.btnVentasDia.BackColor = System.Drawing.Color.White;
            this.btnVentasDia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Bisque;
            this.btnVentasDia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.btnVentasDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasDia.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasDia.Location = new System.Drawing.Point(328, 24);
            this.btnVentasDia.Name = "btnVentasDia";
            this.btnVentasDia.Size = new System.Drawing.Size(131, 79);
            this.btnVentasDia.TabIndex = 9;
            this.btnVentasDia.Text = "Ventas del día";
            this.btnVentasDia.UseVisualStyleBackColor = false;
            this.btnVentasDia.Click += new System.EventHandler(this.btnVentasDia_Click);
            // 
            // VerVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 470);
            this.Controls.Add(this.btnVentasDia);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVentasTodas);
            this.Controls.Add(this.btnVentasSemana);
            this.Controls.Add(this.dgvMuestraVentas);
            this.Name = "VerVentas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VerVentas";
            this.Load += new System.EventHandler(this.VerVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMuestraVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMuestraVentas;
        private System.Windows.Forms.Button btnVentasSemana;
        private System.Windows.Forms.Button btnVentasTodas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVentasDia;
    }
}