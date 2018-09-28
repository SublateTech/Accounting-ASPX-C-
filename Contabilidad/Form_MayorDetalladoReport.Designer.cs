namespace Contabilidad
{
    partial class Form_MayorDetalladoReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MayorDetalladoReport));
            this.crvLibros = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            
            this.SuspendLayout();
            // 
            // crvLibros
            // 
            this.crvLibros.ActiveViewIndex = -1;
            this.crvLibros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.crvLibros.CachedPageNumberPerDoc = 10;
            this.crvLibros.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLibros.Location = new System.Drawing.Point(0, 0);
            this.crvLibros.Name = "crvLibros";
            this.crvLibros.SelectionFormula = "";
            this.crvLibros.ShowGroupTreeButton = false;
            this.crvLibros.ShowRefreshButton = false;
            this.crvLibros.Size = new System.Drawing.Size(1236, 459);
            this.crvLibros.TabIndex = 6;
            this.crvLibros.ToolPanelWidth = 100;
            this.crvLibros.ViewTimeSelectionFormula = "";
            // 
            // Form_MayorDetalladoReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 459);
            this.Controls.Add(this.crvLibros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MayorDetalladoReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mayor Detallado";
            this.Load += new System.EventHandler(this.Form_MayorDetalladoReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLibros;
    }
}