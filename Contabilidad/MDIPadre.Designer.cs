//using System.Configuration;
namespace Contabilidad
{
    partial class MDIPadre
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.asientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asientosAnteriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAsientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAsientos = new System.Windows.Forms.Button();
            this.btnTransferencias = new System.Windows.Forms.Button();
            this.btnLibros = new System.Windows.Forms.Button();
            this.btnCuentas = new System.Windows.Forms.Button();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.btnProcesos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImportarExportar = new System.Windows.Forms.Button();
            this.btnInterfaces = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asientosToolStripMenuItem,
            this.asientosAnteriorToolStripMenuItem,
            this.transferenciasToolStripMenuItem,
            this.registrarAsientosToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(50, 20);
            this.fileMenu.Text = "&Menú";
            // 
            // asientosToolStripMenuItem
            // 
            this.asientosToolStripMenuItem.Name = "asientosToolStripMenuItem";
            this.asientosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.asientosToolStripMenuItem.Text = "Asientos";
            this.asientosToolStripMenuItem.Click += new System.EventHandler(this.asientosToolStripMenuItem_Click);
            // 
            // asientosAnteriorToolStripMenuItem
            // 
            this.asientosAnteriorToolStripMenuItem.Name = "asientosAnteriorToolStripMenuItem";
            this.asientosAnteriorToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.asientosAnteriorToolStripMenuItem.Text = "Asientos [Anterior]";
            this.asientosAnteriorToolStripMenuItem.Click += new System.EventHandler(this.asientosAnteriorToolStripMenuItem_Click);
            // 
            // transferenciasToolStripMenuItem
            // 
            this.transferenciasToolStripMenuItem.Name = "transferenciasToolStripMenuItem";
            this.transferenciasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.transferenciasToolStripMenuItem.Text = "Transferencias";
            this.transferenciasToolStripMenuItem.Click += new System.EventHandler(this.transferenciasToolStripMenuItem_Click);
            // 
            // registrarAsientosToolStripMenuItem
            // 
            this.registrarAsientosToolStripMenuItem.Name = "registrarAsientosToolStripMenuItem";
            this.registrarAsientosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.registrarAsientosToolStripMenuItem.Text = "Registrar Asientos";
            this.registrarAsientosToolStripMenuItem.Click += new System.EventHandler(this.registrarAsientosToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 678);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1026, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 500, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(627, 17);
            this.toolStripStatusLabel1.Text = "Compilado 01/06/2016";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAsientos
            // 
            this.btnAsientos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAsientos.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnAsientos.Location = new System.Drawing.Point(12, 136);
            this.btnAsientos.Name = "btnAsientos";
            this.btnAsientos.Size = new System.Drawing.Size(134, 46);
            this.btnAsientos.TabIndex = 4;
            this.btnAsientos.Text = "Asientos";
            this.btnAsientos.UseVisualStyleBackColor = false;
            this.btnAsientos.Visible = false;
            this.btnAsientos.Click += new System.EventHandler(this.btnAsientos_Click);
            // 
            // btnTransferencias
            // 
            this.btnTransferencias.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTransferencias.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnTransferencias.Location = new System.Drawing.Point(12, 295);
            this.btnTransferencias.Name = "btnTransferencias";
            this.btnTransferencias.Size = new System.Drawing.Size(134, 46);
            this.btnTransferencias.TabIndex = 5;
            this.btnTransferencias.Text = "Transferencias";
            this.btnTransferencias.UseVisualStyleBackColor = false;
            this.btnTransferencias.Visible = false;
            this.btnTransferencias.Click += new System.EventHandler(this.btnTransferencias_Click);
            // 
            // btnLibros
            // 
            this.btnLibros.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLibros.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnLibros.Location = new System.Drawing.Point(12, 242);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Size = new System.Drawing.Size(134, 46);
            this.btnLibros.TabIndex = 7;
            this.btnLibros.Text = "Libros";
            this.btnLibros.UseVisualStyleBackColor = false;
            this.btnLibros.Visible = false;
            this.btnLibros.Click += new System.EventHandler(this.btnLibros_Click);
            // 
            // btnCuentas
            // 
            this.btnCuentas.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCuentas.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnCuentas.Location = new System.Drawing.Point(12, 189);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(134, 46);
            this.btnCuentas.TabIndex = 6;
            this.btnCuentas.Text = "Análisis de cuentas";
            this.btnCuentas.UseVisualStyleBackColor = false;
            this.btnCuentas.Visible = false;
            this.btnCuentas.Click += new System.EventHandler(this.btnCuentas_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(24, 35);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(990, 38);
            this.lblEmpresa.TabIndex = 9;
            this.lblEmpresa.Text = "FIGTUR S.A.";
            // 
            // lblSucursal
            // 
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(25, 104);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(533, 29);
            this.lblSucursal.TabIndex = 10;
            this.lblSucursal.Text = "BUSINESS TOWER HOTEL";
            this.lblSucursal.Visible = false;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(25, 74);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(450, 28);
            this.lblPeriodo.TabIndex = 11;
            this.lblPeriodo.Text = "2012";
            // 
            // btnProcesos
            // 
            this.btnProcesos.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnProcesos.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnProcesos.Location = new System.Drawing.Point(12, 348);
            this.btnProcesos.Name = "btnProcesos";
            this.btnProcesos.Size = new System.Drawing.Size(134, 46);
            this.btnProcesos.TabIndex = 12;
            this.btnProcesos.Text = "Procesos";
            this.btnProcesos.UseVisualStyleBackColor = false;
            this.btnProcesos.Visible = false;
            this.btnProcesos.Click += new System.EventHandler(this.btnProcesos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.BackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.Location = new System.Drawing.Point(14, 618);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(134, 46);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImportarExportar
            // 
            this.btnImportarExportar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnImportarExportar.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnImportarExportar.Location = new System.Drawing.Point(12, 401);
            this.btnImportarExportar.Name = "btnImportarExportar";
            this.btnImportarExportar.Size = new System.Drawing.Size(134, 46);
            this.btnImportarExportar.TabIndex = 15;
            this.btnImportarExportar.Text = "Importar/Exportar";
            this.btnImportarExportar.UseVisualStyleBackColor = false;
            this.btnImportarExportar.Click += new System.EventHandler(this.btnImportarExportar_Click);
            // 
            // btnInterfaces
            // 
            this.btnInterfaces.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnInterfaces.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnInterfaces.Location = new System.Drawing.Point(12, 454);
            this.btnInterfaces.Name = "btnInterfaces";
            this.btnInterfaces.Size = new System.Drawing.Size(134, 46);
            this.btnInterfaces.TabIndex = 16;
            this.btnInterfaces.Text = "Interfaces";
            this.btnInterfaces.UseVisualStyleBackColor = false;
            this.btnInterfaces.Click += new System.EventHandler(this.btnInterfaces_Click);
            // 
            // MDIPadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1026, 700);
            this.Controls.Add(this.btnInterfaces);
            this.Controls.Add(this.btnImportarExportar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesos);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.btnLibros);
            this.Controls.Add(this.btnCuentas);
            this.Controls.Add(this.btnTransferencias);
            this.Controls.Add(this.btnAsientos);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIPadre";
            this.Text = "SHIOL - CONTABILIDAD";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIPadre_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAsientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asientosAnteriorToolStripMenuItem;
        private System.Windows.Forms.Button btnAsientos;
        private System.Windows.Forms.Button btnTransferencias;
        private System.Windows.Forms.Button btnLibros;
        private System.Windows.Forms.Button btnCuentas;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Button btnProcesos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImportarExportar;
        private System.Windows.Forms.Button btnInterfaces;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}



