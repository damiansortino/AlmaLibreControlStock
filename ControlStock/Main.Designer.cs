
namespace ControlStock
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corregirStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasRealizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.verCajasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCajaActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCajasAnterioresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verIPDelServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutaDeInstalaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathImgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirAppSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarProductosToolStripMenuItem,
            this.agregarProductoToolStripMenuItem,
            this.corregirStockToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // buscarProductosToolStripMenuItem
            // 
            this.buscarProductosToolStripMenuItem.Name = "buscarProductosToolStripMenuItem";
            this.buscarProductosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.buscarProductosToolStripMenuItem.Text = "Buscar Productos";
            this.buscarProductosToolStripMenuItem.Click += new System.EventHandler(this.buscarProductosToolStripMenuItem_Click);
            // 
            // agregarProductoToolStripMenuItem
            // 
            this.agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            this.agregarProductoToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.agregarProductoToolStripMenuItem.Text = "Agregar Producto";
            // 
            // corregirStockToolStripMenuItem
            // 
            this.corregirStockToolStripMenuItem.Name = "corregirStockToolStripMenuItem";
            this.corregirStockToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.corregirStockToolStripMenuItem.Text = "Corregir Stock";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaVentaToolStripMenuItem,
            this.ventasRealizadasToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // nuevaVentaToolStripMenuItem
            // 
            this.nuevaVentaToolStripMenuItem.Enabled = false;
            this.nuevaVentaToolStripMenuItem.Name = "nuevaVentaToolStripMenuItem";
            this.nuevaVentaToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.nuevaVentaToolStripMenuItem.Text = "Nueva Venta";
            this.nuevaVentaToolStripMenuItem.Click += new System.EventHandler(this.nuevaVentaToolStripMenuItem_Click);
            // 
            // ventasRealizadasToolStripMenuItem
            // 
            this.ventasRealizadasToolStripMenuItem.Name = "ventasRealizadasToolStripMenuItem";
            this.ventasRealizadasToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.ventasRealizadasToolStripMenuItem.Text = "Ventas Realizadas";
            this.ventasRealizadasToolStripMenuItem.Click += new System.EventHandler(this.ventasRealizadasToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 24);
            this.toolStripMenuItem1.Text = "Preventa";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCajasToolStripMenuItem,
            this.cerrarCajaToolStripMenuItem,
            this.verCajaActualToolStripMenuItem,
            this.verCajasAnterioresToolStripMenuItem});
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(57, 24);
            this.toolStripMenuItem2.Text = "Caja";
            // 
            // verCajasToolStripMenuItem
            // 
            this.verCajasToolStripMenuItem.Name = "verCajasToolStripMenuItem";
            this.verCajasToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.verCajasToolStripMenuItem.Text = "Iniciar Caja";
            this.verCajasToolStripMenuItem.Click += new System.EventHandler(this.verCajasToolStripMenuItem_Click);
            // 
            // cerrarCajaToolStripMenuItem
            // 
            this.cerrarCajaToolStripMenuItem.Name = "cerrarCajaToolStripMenuItem";
            this.cerrarCajaToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.cerrarCajaToolStripMenuItem.Text = "Cerrar Caja";
            this.cerrarCajaToolStripMenuItem.Click += new System.EventHandler(this.cerrarCajaToolStripMenuItem_Click);
            // 
            // verCajaActualToolStripMenuItem
            // 
            this.verCajaActualToolStripMenuItem.Name = "verCajaActualToolStripMenuItem";
            this.verCajaActualToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.verCajaActualToolStripMenuItem.Text = "Ver Caja Actual";
            // 
            // verCajasAnterioresToolStripMenuItem
            // 
            this.verCajasAnterioresToolStripMenuItem.Name = "verCajasAnterioresToolStripMenuItem";
            this.verCajasAnterioresToolStripMenuItem.Size = new System.Drawing.Size(244, 24);
            this.verCajasAnterioresToolStripMenuItem.Text = "Ver Cajas Anteriores";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.BackgroundImage = global::ControlStock.Properties.Resources.logo;
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verIPDelServidorToolStripMenuItem,
            this.connectionStringToolStripMenuItem,
            this.rutaDeInstalaciónToolStripMenuItem,
            this.mediosDePagoToolStripMenuItem,
            this.pathImgToolStripMenuItem,
            this.abrirAppSettingsToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // verIPDelServidorToolStripMenuItem
            // 
            this.verIPDelServidorToolStripMenuItem.Name = "verIPDelServidorToolStripMenuItem";
            this.verIPDelServidorToolStripMenuItem.Size = new System.Drawing.Size(390, 24);
            this.verIPDelServidorToolStripMenuItem.Text = "Ver IP del Servidor";
            this.verIPDelServidorToolStripMenuItem.Click += new System.EventHandler(this.verIPDelServidorToolStripMenuItem_Click);
            // 
            // connectionStringToolStripMenuItem
            // 
            this.connectionStringToolStripMenuItem.Name = "connectionStringToolStripMenuItem";
            this.connectionStringToolStripMenuItem.Size = new System.Drawing.Size(390, 24);
            this.connectionStringToolStripMenuItem.Text = "Base de Datos";
            this.connectionStringToolStripMenuItem.Click += new System.EventHandler(this.connectionStringToolStripMenuItem_Click);
            // 
            // rutaDeInstalaciónToolStripMenuItem
            // 
            this.rutaDeInstalaciónToolStripMenuItem.Enabled = false;
            this.rutaDeInstalaciónToolStripMenuItem.Name = "rutaDeInstalaciónToolStripMenuItem";
            this.rutaDeInstalaciónToolStripMenuItem.Size = new System.Drawing.Size(390, 24);
            this.rutaDeInstalaciónToolStripMenuItem.Text = "ConnectionString";
            // 
            // mediosDePagoToolStripMenuItem
            // 
            this.mediosDePagoToolStripMenuItem.Enabled = false;
            this.mediosDePagoToolStripMenuItem.Name = "mediosDePagoToolStripMenuItem";
            this.mediosDePagoToolStripMenuItem.Size = new System.Drawing.Size(390, 24);
            this.mediosDePagoToolStripMenuItem.Text = "Medios de Pago";
            this.mediosDePagoToolStripMenuItem.Click += new System.EventHandler(this.mediosDePagoToolStripMenuItem_Click);
            // 
            // pathImgToolStripMenuItem
            // 
            this.pathImgToolStripMenuItem.Name = "pathImgToolStripMenuItem";
            this.pathImgToolStripMenuItem.Size = new System.Drawing.Size(390, 24);
            this.pathImgToolStripMenuItem.Text = "Path Img (Seleccionar archivo logo.ico)";
            // 
            // abrirAppSettingsToolStripMenuItem
            // 
            this.abrirAppSettingsToolStripMenuItem.Enabled = false;
            this.abrirAppSettingsToolStripMenuItem.Name = "abrirAppSettingsToolStripMenuItem";
            this.abrirAppSettingsToolStripMenuItem.Size = new System.Drawing.Size(390, 24);
            this.abrirAppSettingsToolStripMenuItem.Text = "Abrir AppSettings";
            this.abrirAppSettingsToolStripMenuItem.Click += new System.EventHandler(this.abrirAppSettingsToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ControlStock.Properties.Resources.logo;
            this.ClientSize = new System.Drawing.Size(1110, 373);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alma Libre - Software";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corregirStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasRealizadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutaDeInstalaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem verCajasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCajaActualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCajasAnterioresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verIPDelServidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathImgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirAppSettingsToolStripMenuItem;
    }
}

