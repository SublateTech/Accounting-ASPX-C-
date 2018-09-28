namespace Contabilidad
{
    partial class frmProcesos
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
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lvwTransferencias = new System.Windows.Forms.ListView();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.grpPlanillas = new System.Windows.Forms.GroupBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpDiferenciaCambio = new System.Windows.Forms.GroupBox();
            this.tipoVentaLB = new System.Windows.Forms.Label();
            this.tipoCompraLB = new System.Windows.Forms.Label();
            this.tituloVentaLB = new System.Windows.Forms.Label();
            this.tituloCompraLB = new System.Windows.Forms.Label();
            this.fechaFinLB = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaDC = new System.Windows.Forms.DateTimePicker();
            this.grpTransferencias = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPlanillas.SuspendLayout();
            this.grpDiferenciaCambio.SuspendLayout();
            this.grpTransferencias.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(288, 197);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(335, 14);
            this.pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgBar.TabIndex = 20;
            this.pgBar.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(478, 131);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 46);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // lvwTransferencias
            // 
            this.lvwTransferencias.HideSelection = false;
            this.lvwTransferencias.Location = new System.Drawing.Point(11, 6);
            this.lvwTransferencias.Name = "lvwTransferencias";
            this.lvwTransferencias.Size = new System.Drawing.Size(249, 214);
            this.lvwTransferencias.TabIndex = 23;
            this.lvwTransferencias.UseCompatibleStateImageBehavior = false;
            this.lvwTransferencias.View = System.Windows.Forms.View.Details;
            
            this.lvwTransferencias.Click += new System.EventHandler(this.lvwTransferencias_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(363, 131);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(109, 46);
            this.btnTransferir.TabIndex = 24;
            this.btnTransferir.Text = "Iniciar";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click_1);
            // 
            // grpPlanillas
            // 
            this.grpPlanillas.Controls.Add(this.cboYear);
            this.grpPlanillas.Controls.Add(this.cboMonth);
            this.grpPlanillas.Controls.Add(this.label3);
            this.grpPlanillas.Controls.Add(this.label4);
            this.grpPlanillas.Location = new System.Drawing.Point(277, 11);
            this.grpPlanillas.Name = "grpPlanillas";
            this.grpPlanillas.Size = new System.Drawing.Size(362, 83);
            this.grpPlanillas.TabIndex = 27;
            this.grpPlanillas.TabStop = false;
            this.grpPlanillas.Text = "Planillas";
            // 
            // cboYear
            // 
            this.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(71, 42);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(278, 21);
            this.cboYear.TabIndex = 26;
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(70, 17);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(280, 21);
            this.cboMonth.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Año:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Mes:";
            // 
            // grpDiferenciaCambio
            // 
            this.grpDiferenciaCambio.Controls.Add(this.tipoVentaLB);
            this.grpDiferenciaCambio.Controls.Add(this.tipoCompraLB);
            this.grpDiferenciaCambio.Controls.Add(this.tituloVentaLB);
            this.grpDiferenciaCambio.Controls.Add(this.tituloCompraLB);
            this.grpDiferenciaCambio.Controls.Add(this.fechaFinLB);
            this.grpDiferenciaCambio.Controls.Add(this.label5);
            this.grpDiferenciaCambio.Controls.Add(this.dtpFechaDC);
            this.grpDiferenciaCambio.Location = new System.Drawing.Point(275, 12);
            this.grpDiferenciaCambio.Name = "grpDiferenciaCambio";
            this.grpDiferenciaCambio.Size = new System.Drawing.Size(356, 113);
            this.grpDiferenciaCambio.TabIndex = 29;
            this.grpDiferenciaCambio.TabStop = false;
            this.grpDiferenciaCambio.Text = "Diferencia de Cambio";
            this.grpDiferenciaCambio.Visible = false;
            // 
            // tipoVentaLB
            // 
            this.tipoVentaLB.AutoSize = true;
            this.tipoVentaLB.Location = new System.Drawing.Point(131, 87);
            this.tipoVentaLB.Name = "tipoVentaLB";
            this.tipoVentaLB.Size = new System.Drawing.Size(28, 13);
            this.tipoVentaLB.TabIndex = 34;
            this.tipoVentaLB.Text = "0.00";
            // 
            // tipoCompraLB
            // 
            this.tipoCompraLB.AutoSize = true;
            this.tipoCompraLB.Location = new System.Drawing.Point(131, 66);
            this.tipoCompraLB.Name = "tipoCompraLB";
            this.tipoCompraLB.Size = new System.Drawing.Size(28, 13);
            this.tipoCompraLB.TabIndex = 31;
            this.tipoCompraLB.Text = "0.00";
            // 
            // tituloVentaLB
            // 
            this.tituloVentaLB.AutoSize = true;
            this.tituloVentaLB.Location = new System.Drawing.Point(57, 87);
            this.tituloVentaLB.Name = "tituloVentaLB";
            this.tituloVentaLB.Size = new System.Drawing.Size(68, 13);
            this.tituloVentaLB.TabIndex = 33;
            this.tituloVentaLB.Text = "Tipo Venta : ";
            // 
            // tituloCompraLB
            // 
            this.tituloCompraLB.AutoSize = true;
            this.tituloCompraLB.Location = new System.Drawing.Point(49, 65);
            this.tituloCompraLB.Name = "tituloCompraLB";
            this.tituloCompraLB.Size = new System.Drawing.Size(76, 13);
            this.tituloCompraLB.TabIndex = 32;
            this.tituloCompraLB.Text = "Tipo Compra : ";
            // 
            // fechaFinLB
            // 
            this.fechaFinLB.AutoSize = true;
            this.fechaFinLB.Location = new System.Drawing.Point(130, 41);
            this.fechaFinLB.Name = "fechaFinLB";
            this.fechaFinLB.Size = new System.Drawing.Size(0, 13);
            this.fechaFinLB.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fecha:";
            // 
            // dtpFechaDC
            // 
            this.dtpFechaDC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDC.Location = new System.Drawing.Point(171, 38);
            this.dtpFechaDC.Name = "dtpFechaDC";
            this.dtpFechaDC.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDC.TabIndex = 0;
            // 
            // grpTransferencias
            // 
            this.grpTransferencias.Controls.Add(this.dtpHasta);
            this.grpTransferencias.Controls.Add(this.label2);
            this.grpTransferencias.Controls.Add(this.dtpDesde);
            this.grpTransferencias.Controls.Add(this.label1);
            this.grpTransferencias.Location = new System.Drawing.Point(274, 16);
            this.grpTransferencias.Name = "grpTransferencias";
            this.grpTransferencias.Size = new System.Drawing.Size(362, 83);
            this.grpTransferencias.TabIndex = 30;
            this.grpTransferencias.TabStop = false;
            this.grpTransferencias.Text = "Transferencias";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(69, 47);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(271, 20);
            this.dtpHasta.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(69, 20);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(271, 20);
            this.dtpDesde.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Desde:";
            // 
            // frmProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 228);
            this.Controls.Add(this.grpDiferenciaCambio);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.lvwTransferencias);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpTransferencias);
            this.Controls.Add(this.grpPlanillas);
            this.Name = "frmProcesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesos";
            this.Load += new System.EventHandler(this.frmProcesos_Load);
            this.grpPlanillas.ResumeLayout(false);
            this.grpPlanillas.PerformLayout();
            this.grpDiferenciaCambio.ResumeLayout(false);
            this.grpDiferenciaCambio.PerformLayout();
            this.grpTransferencias.ResumeLayout(false);
            this.grpTransferencias.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar pgBar;
    private System.Windows.Forms.Button btnCancelar;
    private System.ComponentModel.BackgroundWorker bgWorker;
    private System.Windows.Forms.ListView lvwTransferencias;
    private System.Windows.Forms.Button btnTransferir;
    private System.Windows.Forms.GroupBox grpPlanillas;
    private System.Windows.Forms.ComboBox cboYear;
    private System.Windows.Forms.ComboBox cboMonth;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox grpDiferenciaCambio;
    private System.Windows.Forms.GroupBox grpTransferencias;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker dtpFechaDC;
    private System.Windows.Forms.Label tituloVentaLB;
    private System.Windows.Forms.Label tituloCompraLB;
    private System.Windows.Forms.Label fechaFinLB;
    private System.Windows.Forms.Label tipoVentaLB;
    private System.Windows.Forms.Label tipoCompraLB;
  }
}