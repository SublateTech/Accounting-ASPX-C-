namespace PruebaProyectoCsharp
{
    partial class MDI_Form
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.PageContabilidad = new Telerik.WinControls.UI.RadPageViewPage();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.btnProcesos = new Telerik.WinControls.UI.RadButton();
            this.btnTransferencias = new Telerik.WinControls.UI.RadButton();
            this.btnLibros = new Telerik.WinControls.UI.RadButton();
            this.btnCuentas = new Telerik.WinControls.UI.RadButton();
            this.btnAsientos = new Telerik.WinControls.UI.RadButton();
            this.PageSocios = new Telerik.WinControls.UI.RadPageViewPage();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_salir = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.PageContabilidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAsientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.PageContabilidad);
            this.radPageView1.Controls.Add(this.PageSocios);
            this.radPageView1.Location = new System.Drawing.Point(0, 71);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.PageContabilidad;
            this.radPageView1.Size = new System.Drawing.Size(614, 438);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.ThemeName = "Office2010Blue";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Left;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Horizontal;
            // 
            // PageContabilidad
            // 
            this.PageContabilidad.Controls.Add(this.radButton3);
            this.PageContabilidad.Controls.Add(this.btnProcesos);
            this.PageContabilidad.Controls.Add(this.btnTransferencias);
            this.PageContabilidad.Controls.Add(this.btnLibros);
            this.PageContabilidad.Controls.Add(this.btnCuentas);
            this.PageContabilidad.Controls.Add(this.btnAsientos);
            this.PageContabilidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.PageContabilidad.Location = new System.Drawing.Point(116, 12);
            this.PageContabilidad.Name = "PageContabilidad";
            this.PageContabilidad.Size = new System.Drawing.Size(486, 414);
            this.PageContabilidad.Text = "CONTABILIDAD";
            // 
            // radButton3
            // 
            this.radButton3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.radButton3.Location = new System.Drawing.Point(249, 279);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(234, 132);
            this.radButton3.TabIndex = 7;
            this.radButton3.Text = "????";
            this.radButton3.ThemeName = "TelerikMetroBlue";
            // 
            // btnProcesos
            // 
            this.btnProcesos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnProcesos.Location = new System.Drawing.Point(3, 279);
            this.btnProcesos.Name = "btnProcesos";
            this.btnProcesos.Size = new System.Drawing.Size(234, 132);
            this.btnProcesos.TabIndex = 4;
            this.btnProcesos.Text = "PROCESOS";
            this.btnProcesos.ThemeName = "TelerikMetroBlue";
            // 
            // btnTransferencias
            // 
            this.btnTransferencias.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnTransferencias.Location = new System.Drawing.Point(249, 141);
            this.btnTransferencias.Name = "btnTransferencias";
            this.btnTransferencias.Size = new System.Drawing.Size(234, 132);
            this.btnTransferencias.TabIndex = 6;
            this.btnTransferencias.Text = "TRANSFERENCIAS";
            this.btnTransferencias.ThemeName = "TelerikMetroBlue";
            // 
            // btnLibros
            // 
            this.btnLibros.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnLibros.Location = new System.Drawing.Point(3, 141);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Size = new System.Drawing.Size(234, 132);
            this.btnLibros.TabIndex = 2;
            this.btnLibros.Text = "LIBROS";
            this.btnLibros.ThemeName = "TelerikMetroBlue";
            // 
            // btnCuentas
            // 
            this.btnCuentas.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnCuentas.Location = new System.Drawing.Point(249, 3);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(234, 132);
            this.btnCuentas.TabIndex = 5;
            this.btnCuentas.Text = "CUENTAS";
            this.btnCuentas.ThemeName = "TelerikMetroBlue";
            // 
            // btnAsientos
            // 
            this.btnAsientos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnAsientos.Location = new System.Drawing.Point(3, 3);
            this.btnAsientos.Name = "btnAsientos";
            this.btnAsientos.Size = new System.Drawing.Size(234, 132);
            this.btnAsientos.TabIndex = 0;
            this.btnAsientos.Text = "ASIENTOS";
            this.btnAsientos.ThemeName = "TelerikMetroBlue";
            this.btnAsientos.Click += new System.EventHandler(this.btnAsientos_Click);
            // 
            // PageSocios
            // 
            this.PageSocios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.PageSocios.Location = new System.Drawing.Point(116, 12);
            this.PageSocios.Name = "PageSocios";
            this.PageSocios.Size = new System.Drawing.Size(486, 414);
            this.PageSocios.Text = "SOCIOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "FIGTUR S.A. 2010 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Business Tower";
            // 
            // B_salir
            // 
            this.B_salir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.B_salir.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.B_salir.Location = new System.Drawing.Point(472, 12);
            this.B_salir.Name = "B_salir";
            this.B_salir.Size = new System.Drawing.Size(130, 53);
            this.B_salir.TabIndex = 3;
            this.B_salir.Text = "SALIR";
            this.B_salir.ThemeName = "TelerikMetroBlue";
            // 
            // MDI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 610);
            this.Controls.Add(this.B_salir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radPageView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MDI_Form";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "radRibbonBar1";
            this.ThemeName = "Office2010Blue";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.PageContabilidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAsientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage PageContabilidad;
        private Telerik.WinControls.UI.RadPageViewPage PageSocios;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton B_salir;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadButton btnAsientos;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton btnProcesos;
        private Telerik.WinControls.UI.RadButton btnTransferencias;
        private Telerik.WinControls.UI.RadButton btnLibros;
        private Telerik.WinControls.UI.RadButton btnCuentas;
    }
}
