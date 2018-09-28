namespace Contabilidad
{
    partial class frmValidaCompraSunat
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
            this.radGridValidaCompraSunat = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGridValidaCompraSunat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridValidaCompraSunat.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridValidaCompraSunat
            // 
            this.radGridValidaCompraSunat.BackColor = System.Drawing.SystemColors.Control;
            this.radGridValidaCompraSunat.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridValidaCompraSunat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridValidaCompraSunat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridValidaCompraSunat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridValidaCompraSunat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridValidaCompraSunat.Location = new System.Drawing.Point(0, 0);
            // 
            // radGridValidaCompraSunat
            // 
            this.radGridValidaCompraSunat.MasterTemplate.AllowAddNewRow = false;
            this.radGridValidaCompraSunat.MasterTemplate.EnableGrouping = false;
            this.radGridValidaCompraSunat.Name = "radGridValidaCompraSunat";
            this.radGridValidaCompraSunat.ReadOnly = true;
            this.radGridValidaCompraSunat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridValidaCompraSunat.ShowGroupPanel = false;
            this.radGridValidaCompraSunat.Size = new System.Drawing.Size(1234, 331);
            this.radGridValidaCompraSunat.TabIndex = 0;
            this.radGridValidaCompraSunat.Text = "radGridView1";
            // 
            // frmValidaCompraSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 331);
            this.Controls.Add(this.radGridValidaCompraSunat);
            this.Name = "frmValidaCompraSunat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valida Compra Sunat";
            this.Load += new System.EventHandler(this.frmValidaCompraSunat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridValidaCompraSunat.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridValidaCompraSunat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridValidaCompraSunat;
    }
}