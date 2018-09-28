namespace Contabilidad
{
  partial class frmTransferenciaVentas
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
        this.dtpDesde = new System.Windows.Forms.DateTimePicker();
        this.dtpHasta = new System.Windows.Forms.DateTimePicker();
        this.label2 = new System.Windows.Forms.Label();
        this.btnTransferir = new System.Windows.Forms.Button();
        this.btnCancelar = new System.Windows.Forms.Button();
        this.pgBar = new System.Windows.Forms.ProgressBar();
        this.bgWorker = new System.ComponentModel.BackgroundWorker();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 25);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(41, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Desde:";
        this.label1.Click += new System.EventHandler(this.label1_Click);
        // 
        // dtpDesde
        // 
        this.dtpDesde.Location = new System.Drawing.Point(59, 23);
        this.dtpDesde.Name = "dtpDesde";
        this.dtpDesde.Size = new System.Drawing.Size(271, 20);
        this.dtpDesde.TabIndex = 1;
        this.dtpDesde.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
        // 
        // dtpHasta
        // 
        this.dtpHasta.Location = new System.Drawing.Point(59, 64);
        this.dtpHasta.Name = "dtpHasta";
        this.dtpHasta.Size = new System.Drawing.Size(271, 20);
        this.dtpHasta.TabIndex = 3;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 67);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(38, 13);
        this.label2.TabIndex = 2;
        this.label2.Text = "Hasta:";
        // 
        // btnTransferir
        // 
        this.btnTransferir.Location = new System.Drawing.Point(114, 103);
        this.btnTransferir.Name = "btnTransferir";
        this.btnTransferir.Size = new System.Drawing.Size(64, 46);
        this.btnTransferir.TabIndex = 4;
        this.btnTransferir.Text = "Transferir";
        this.btnTransferir.UseVisualStyleBackColor = true;
        this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
        // 
        // btnCancelar
        // 
        this.btnCancelar.Location = new System.Drawing.Point(184, 103);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new System.Drawing.Size(64, 46);
        this.btnCancelar.TabIndex = 5;
        this.btnCancelar.Text = "Cancelar";
        this.btnCancelar.UseVisualStyleBackColor = true;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        // 
        // pgBar
        // 
        this.pgBar.Location = new System.Drawing.Point(4, 155);
        this.pgBar.Name = "pgBar";
        this.pgBar.Size = new System.Drawing.Size(335, 14);
        this.pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.pgBar.TabIndex = 13;
        this.pgBar.Visible = false;
        // 
        // bgWorker
        // 
        this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
        this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
        // 
        // frmTransferenciaVentas
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(351, 177);
        this.Controls.Add(this.pgBar);
        this.Controls.Add(this.btnCancelar);
        this.Controls.Add(this.btnTransferir);
        this.Controls.Add(this.dtpHasta);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.dtpDesde);
        this.Controls.Add(this.label1);
        this.Name = "frmTransferenciaVentas";
        this.Text = "Transferencia de Ventas";
        this.Load += new System.EventHandler(this.frmTransferenciaVentas_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnTransferir;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.ProgressBar pgBar;
    private System.ComponentModel.BackgroundWorker bgWorker;
  }
}