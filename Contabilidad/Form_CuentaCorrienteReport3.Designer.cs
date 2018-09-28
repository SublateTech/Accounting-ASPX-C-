namespace Contabilidad
{
    partial class Form_CuentaCorrienteReport3
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
            this.crvLibros = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLibros
            // 
            this.crvLibros.ActiveViewIndex = -1;
            this.crvLibros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLibros.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLibros.Location = new System.Drawing.Point(0, 0);
            this.crvLibros.Name = "crvLibros";
            this.crvLibros.Size = new System.Drawing.Size(1285, 499);
            this.crvLibros.TabIndex = 0;
            // 
            // Form_CuentaCorrienteReport3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 499);
            this.Controls.Add(this.crvLibros);
            this.Name = "Form_CuentaCorrienteReport3";
            this.Text = "Cuenta Corriente";
            this.Load += new System.EventHandler(this.Form_CuentaCorrienteReport3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLibros;
    }
}