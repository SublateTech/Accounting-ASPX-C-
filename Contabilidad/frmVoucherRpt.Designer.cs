namespace Contabilidad
{
  partial class frmVoucherRpt
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
        this.crvVoucher = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
        this.SuspendLayout();
        // 
        // crvVoucher
        // 
        this.crvVoucher.ActiveViewIndex = -1;
        this.crvVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.crvVoucher.Cursor = System.Windows.Forms.Cursors.Default;
        this.crvVoucher.Dock = System.Windows.Forms.DockStyle.Fill;
        this.crvVoucher.Location = new System.Drawing.Point(0, 0);
        this.crvVoucher.Name = "crvVoucher";
        this.crvVoucher.SelectionFormula = "";
        this.crvVoucher.Size = new System.Drawing.Size(860, 542);
        this.crvVoucher.TabIndex = 0;
        this.crvVoucher.ViewTimeSelectionFormula = "";
        this.crvVoucher.Load += new System.EventHandler(this.crvVoucher_Load_1);
        // 
        // frmVoucherRpt
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
        this.ClientSize = new System.Drawing.Size(860, 542);
        this.Controls.Add(this.crvVoucher);
        this.Name = "frmVoucherRpt";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Reporte Voucher";
        this.Load += new System.EventHandler(this.frmVoucherRpt_Load);
        this.ResumeLayout(false);

    }

    #endregion

    private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVoucher;
  }
}