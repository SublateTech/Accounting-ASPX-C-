namespace Contabilidad
{
  partial class frmTransferencias
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
            this.grpTransferencias = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPlanillas = new System.Windows.Forms.GroupBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMensajeTransfiriendo = new System.Windows.Forms.Label();
            this.grpTransferencias.SuspendLayout();
            this.grpPlanillas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgBar
            // 
            this.pgBar.ForeColor = System.Drawing.Color.OrangeRed;
            this.pgBar.Location = new System.Drawing.Point(263, 164);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(375, 12);
            this.pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgBar.TabIndex = 20;
            this.pgBar.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(478, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 46);
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
            this.lvwTransferencias.Size = new System.Drawing.Size(249, 333);
            this.lvwTransferencias.TabIndex = 23;
            this.lvwTransferencias.UseCompatibleStateImageBehavior = false;
            this.lvwTransferencias.View = System.Windows.Forms.View.Details;
            this.lvwTransferencias.Click += new System.EventHandler(this.lvwTransferencias_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTransferir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferir.Location = new System.Drawing.Point(363, 102);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(109, 46);
            this.btnTransferir.TabIndex = 24;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = false;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click_1);
            // 
            // grpTransferencias
            // 
            this.grpTransferencias.Controls.Add(this.dtpHasta);
            this.grpTransferencias.Controls.Add(this.label2);
            this.grpTransferencias.Controls.Add(this.dtpDesde);
            this.grpTransferencias.Controls.Add(this.label1);
            this.grpTransferencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTransferencias.Location = new System.Drawing.Point(274, 6);
            this.grpTransferencias.Name = "grpTransferencias";
            this.grpTransferencias.Size = new System.Drawing.Size(362, 83);
            this.grpTransferencias.TabIndex = 25;
            this.grpTransferencias.TabStop = false;
            this.grpTransferencias.Text = "Transferencias";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Desde:";
            // 
            // grpPlanillas
            // 
            this.grpPlanillas.Controls.Add(this.cboYear);
            this.grpPlanillas.Controls.Add(this.cboMonth);
            this.grpPlanillas.Controls.Add(this.label3);
            this.grpPlanillas.Controls.Add(this.label4);
            this.grpPlanillas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlanillas.Location = new System.Drawing.Point(271, 6);
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
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Enabled = false;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(71, 42);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(278, 21);
            this.cboYear.TabIndex = 26;
            this.cboYear.Visible = false;
            // 
            // cboMonth
            // 
            this.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(70, 17);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(280, 21);
            this.cboMonth.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(22, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Año:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Mes:";
            // 
            // lblMensajeTransfiriendo
            // 
            this.lblMensajeTransfiriendo.AutoSize = true;
            this.lblMensajeTransfiriendo.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensajeTransfiriendo.Location = new System.Drawing.Point(391, 179);
            this.lblMensajeTransfiriendo.Name = "lblMensajeTransfiriendo";
            this.lblMensajeTransfiriendo.Size = new System.Drawing.Size(122, 13);
            this.lblMensajeTransfiriendo.TabIndex = 28;
            this.lblMensajeTransfiriendo.Text = "Transfiriendo registros ...";
            this.lblMensajeTransfiriendo.Visible = false;
            // 
            // frmTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 351);
            this.Controls.Add(this.lblMensajeTransfiriendo);
            this.Controls.Add(this.grpPlanillas);
            this.Controls.Add(this.grpTransferencias);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.lvwTransferencias);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmTransferencias";
            this.Text = "Transferencias";
            this.Load += new System.EventHandler(this.frmTransferencias_Load);
            this.grpTransferencias.ResumeLayout(false);
            this.grpTransferencias.PerformLayout();
            this.grpPlanillas.ResumeLayout(false);
            this.grpPlanillas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ProgressBar pgBar;
    private System.Windows.Forms.Button btnCancelar;
    private System.ComponentModel.BackgroundWorker bgWorker;
    private System.Windows.Forms.ListView lvwTransferencias;
    private System.Windows.Forms.Button btnTransferir;
    private System.Windows.Forms.GroupBox grpTransferencias;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox grpPlanillas;
    private System.Windows.Forms.ComboBox cboYear;
    private System.Windows.Forms.ComboBox cboMonth;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblMensajeTransfiriendo;
  }
}