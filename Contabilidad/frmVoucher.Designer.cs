namespace Contabilidad
{
  partial class frmVoucher
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
            this.gbxBusqueda = new System.Windows.Forms.GroupBox();
            this.txtHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtDesde = new System.Windows.Forms.MaskedTextBox();
            this.btnHasta = new System.Windows.Forms.Button();
            this.btnDesde = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboAreas = new Telerik.WinControls.UI.RadDropDownList();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUnidadNegocio = new Telerik.WinControls.UI.RadDropDownList();
            this.rbCuentas = new System.Windows.Forms.RadioButton();
            this.rbSubDiario = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarCtaFinal = new System.Windows.Forms.Button();
            this.btnBuscarCtaInicial = new System.Windows.Forms.Button();
            this.lblCuentaFinal_ID = new System.Windows.Forms.Label();
            this.lblCuentaInicial_ID = new System.Windows.Forms.Label();
            this.txtCuentaFinal = new System.Windows.Forms.TextBox();
            this.txtCuentaInicial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCuentaFinal = new System.Windows.Forms.Label();
            this.lblCuentaInicial = new System.Windows.Forms.Label();
            this.cbxCuentaFinal_1 = new Telerik.WinControls.UI.RadDropDownList();
            this.cbxCuentaInicial_1 = new Telerik.WinControls.UI.RadDropDownList();
            this.cboFormato = new Telerik.WinControls.UI.RadDropDownList();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxMoneda = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkSubdiario = new System.Windows.Forms.CheckBox();
            this.btnAsientos = new Telerik.WinControls.UI.RadButton();
            this.cbxSubdiario = new Telerik.WinControls.UI.RadDropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dtpDesde1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.chkNoCuadrados = new System.Windows.Forms.CheckBox();
            this.chkCuadrados = new System.Windows.Forms.CheckBox();
            this.btnEliminarTodos = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new Telerik.WinControls.UI.RadButton();
            this.dgvAsientos = new System.Windows.Forms.DataGridView();
            this.calFecha = new System.Windows.Forms.MonthCalendar();
            this.tabVouchers = new System.Windows.Forms.TabControl();
            this.tpDetalle = new System.Windows.Forms.TabPage();
            this.tpResumen = new System.Windows.Forms.TabPage();
            this.dgvConsolidado = new System.Windows.Forms.DataGridView();
            this.gbxBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadNegocio)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCuentaFinal_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCuentaInicial_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAsientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSubdiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde1)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).BeginInit();
            this.tabVouchers.SuspendLayout();
            this.tpDetalle.SuspendLayout();
            this.tpResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsolidado)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxBusqueda
            // 
            this.gbxBusqueda.Controls.Add(this.txtHasta);
            this.gbxBusqueda.Controls.Add(this.txtDesde);
            this.gbxBusqueda.Controls.Add(this.btnHasta);
            this.gbxBusqueda.Controls.Add(this.btnDesde);
            this.gbxBusqueda.Controls.Add(this.label10);
            this.gbxBusqueda.Controls.Add(this.cboAreas);
            this.gbxBusqueda.Controls.Add(this.label9);
            this.gbxBusqueda.Controls.Add(this.cboUnidadNegocio);
            this.gbxBusqueda.Controls.Add(this.rbCuentas);
            this.gbxBusqueda.Controls.Add(this.rbSubDiario);
            this.gbxBusqueda.Controls.Add(this.groupBox2);
            this.gbxBusqueda.Controls.Add(this.cboFormato);
            this.gbxBusqueda.Controls.Add(this.label8);
            this.gbxBusqueda.Controls.Add(this.cbxMoneda);
            this.gbxBusqueda.Controls.Add(this.label5);
            this.gbxBusqueda.Controls.Add(this.label4);
            this.gbxBusqueda.Controls.Add(this.checkSubdiario);
            this.gbxBusqueda.Controls.Add(this.btnAsientos);
            this.gbxBusqueda.Controls.Add(this.cbxSubdiario);
            this.gbxBusqueda.Controls.Add(this.label3);
            this.gbxBusqueda.Controls.Add(this.label2);
            this.gbxBusqueda.Controls.Add(this.label1);
            this.gbxBusqueda.Controls.Add(this.dtpHasta1);
            this.gbxBusqueda.Controls.Add(this.dtpDesde1);
            this.gbxBusqueda.Location = new System.Drawing.Point(4, 0);
            this.gbxBusqueda.Name = "gbxBusqueda";
            this.gbxBusqueda.Size = new System.Drawing.Size(1294, 157);
            this.gbxBusqueda.TabIndex = 0;
            this.gbxBusqueda.TabStop = false;
            this.gbxBusqueda.Text = "Búsqueda";
            this.gbxBusqueda.Enter += new System.EventHandler(this.gbxBusqueda_Enter);
            // 
            // txtHasta
            // 
            this.txtHasta.BackColor = System.Drawing.Color.White;
            this.txtHasta.Location = new System.Drawing.Point(129, 50);
            this.txtHasta.Mask = "00/00/0000";
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(86, 20);
            this.txtHasta.TabIndex = 1;
            this.txtHasta.ValidatingType = typeof(System.DateTime);
            this.txtHasta.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtFecha_MaskInputRejected);
            this.txtHasta.Enter += new System.EventHandler(this.Control_Recibe_Foco);
            this.txtHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFecha_KeyPress);
            // 
            // txtDesde
            // 
            this.txtDesde.BackColor = System.Drawing.Color.White;
            this.txtDesde.Location = new System.Drawing.Point(130, 26);
            this.txtDesde.Mask = "00/00/0000";
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(86, 20);
            this.txtDesde.TabIndex = 0;
            this.txtDesde.ValidatingType = typeof(System.DateTime);
            this.txtDesde.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtFecha_MaskInputRejected);
            this.txtDesde.Enter += new System.EventHandler(this.Control_Recibe_Foco);
            this.txtDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFecha_KeyPress);
            // 
            // btnHasta
            // 
            this.btnHasta.Location = new System.Drawing.Point(215, 50);
            this.btnHasta.Name = "btnHasta";
            this.btnHasta.Size = new System.Drawing.Size(32, 20);
            this.btnHasta.TabIndex = 64;
            this.btnHasta.Text = "...";
            this.btnHasta.UseVisualStyleBackColor = true;
            this.btnHasta.Click += new System.EventHandler(this.btnHasta_Click);
            // 
            // btnDesde
            // 
            this.btnDesde.Location = new System.Drawing.Point(216, 26);
            this.btnDesde.Name = "btnDesde";
            this.btnDesde.Size = new System.Drawing.Size(32, 20);
            this.btnDesde.TabIndex = 63;
            this.btnDesde.Text = "...";
            this.btnDesde.UseVisualStyleBackColor = true;
            this.btnDesde.Click += new System.EventHandler(this.btnDesde_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Area:";
            // 
            // cboAreas
            // 
            this.cboAreas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAreas.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboAreas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cboAreas.Location = new System.Drawing.Point(397, 132);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(200, 20);
            this.cboAreas.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Unidad de Negocio";
            // 
            // cboUnidadNegocio
            // 
            this.cboUnidadNegocio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUnidadNegocio.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboUnidadNegocio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cboUnidadNegocio.Location = new System.Drawing.Point(128, 130);
            this.cboUnidadNegocio.Name = "cboUnidadNegocio";
            this.cboUnidadNegocio.Size = new System.Drawing.Size(200, 20);
            this.cboUnidadNegocio.TabIndex = 4;
            // 
            // rbCuentas
            // 
            this.rbCuentas.AutoSize = true;
            this.rbCuentas.Location = new System.Drawing.Point(361, 52);
            this.rbCuentas.Name = "rbCuentas";
            this.rbCuentas.Size = new System.Drawing.Size(64, 17);
            this.rbCuentas.TabIndex = 19;
            this.rbCuentas.Text = "Cuentas";
            this.rbCuentas.UseVisualStyleBackColor = true;
            // 
            // rbSubDiario
            // 
            this.rbSubDiario.AutoSize = true;
            this.rbSubDiario.Checked = true;
            this.rbSubDiario.Location = new System.Drawing.Point(362, 25);
            this.rbSubDiario.Name = "rbSubDiario";
            this.rbSubDiario.Size = new System.Drawing.Size(74, 17);
            this.rbSubDiario.TabIndex = 18;
            this.rbSubDiario.TabStop = true;
            this.rbSubDiario.Text = "SubDiario:";
            this.rbSubDiario.UseVisualStyleBackColor = true;
            this.rbSubDiario.CheckedChanged += new System.EventHandler(this.rbSubDiario_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarCtaFinal);
            this.groupBox2.Controls.Add(this.btnBuscarCtaInicial);
            this.groupBox2.Controls.Add(this.lblCuentaFinal_ID);
            this.groupBox2.Controls.Add(this.lblCuentaInicial_ID);
            this.groupBox2.Controls.Add(this.txtCuentaFinal);
            this.groupBox2.Controls.Add(this.txtCuentaInicial);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblCuentaFinal);
            this.groupBox2.Controls.Add(this.lblCuentaInicial);
            this.groupBox2.Controls.Add(this.cbxCuentaFinal_1);
            this.groupBox2.Controls.Add(this.cbxCuentaInicial_1);
            this.groupBox2.Location = new System.Drawing.Point(378, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 72);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuentas";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnBuscarCtaFinal
            // 
            this.btnBuscarCtaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCtaFinal.Location = new System.Drawing.Point(569, 39);
            this.btnBuscarCtaFinal.Name = "btnBuscarCtaFinal";
            this.btnBuscarCtaFinal.Size = new System.Drawing.Size(22, 22);
            this.btnBuscarCtaFinal.TabIndex = 26;
            this.btnBuscarCtaFinal.Text = "@";
            this.btnBuscarCtaFinal.UseVisualStyleBackColor = true;
            this.btnBuscarCtaFinal.Click += new System.EventHandler(this.btnBuscarCtaFinal_Click);
            // 
            // btnBuscarCtaInicial
            // 
            this.btnBuscarCtaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCtaInicial.Location = new System.Drawing.Point(569, 12);
            this.btnBuscarCtaInicial.Name = "btnBuscarCtaInicial";
            this.btnBuscarCtaInicial.Size = new System.Drawing.Size(22, 22);
            this.btnBuscarCtaInicial.TabIndex = 25;
            this.btnBuscarCtaInicial.Text = "@";
            this.btnBuscarCtaInicial.UseVisualStyleBackColor = true;
            this.btnBuscarCtaInicial.Click += new System.EventHandler(this.btnBuscarCtaInicial_Click);
            // 
            // lblCuentaFinal_ID
            // 
            this.lblCuentaFinal_ID.AutoSize = true;
            this.lblCuentaFinal_ID.BackColor = System.Drawing.Color.Blue;
            this.lblCuentaFinal_ID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCuentaFinal_ID.Location = new System.Drawing.Point(496, 46);
            this.lblCuentaFinal_ID.Name = "lblCuentaFinal_ID";
            this.lblCuentaFinal_ID.Size = new System.Drawing.Size(19, 13);
            this.lblCuentaFinal_ID.TabIndex = 24;
            this.lblCuentaFinal_ID.Text = "00";
            this.lblCuentaFinal_ID.Visible = false;
            // 
            // lblCuentaInicial_ID
            // 
            this.lblCuentaInicial_ID.AutoSize = true;
            this.lblCuentaInicial_ID.BackColor = System.Drawing.Color.Blue;
            this.lblCuentaInicial_ID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCuentaInicial_ID.Location = new System.Drawing.Point(496, 18);
            this.lblCuentaInicial_ID.Name = "lblCuentaInicial_ID";
            this.lblCuentaInicial_ID.Size = new System.Drawing.Size(19, 13);
            this.lblCuentaInicial_ID.TabIndex = 23;
            this.lblCuentaInicial_ID.Text = "00";
            this.lblCuentaInicial_ID.Visible = false;
            // 
            // txtCuentaFinal
            // 
            this.txtCuentaFinal.Location = new System.Drawing.Point(93, 42);
            this.txtCuentaFinal.Name = "txtCuentaFinal";
            this.txtCuentaFinal.Size = new System.Drawing.Size(87, 20);
            this.txtCuentaFinal.TabIndex = 20;
            this.txtCuentaFinal.TextChanged += new System.EventHandler(this.txtCuentaFinal_TextChanged);
            // 
            // txtCuentaInicial
            // 
            this.txtCuentaInicial.Location = new System.Drawing.Point(93, 15);
            this.txtCuentaInicial.Name = "txtCuentaInicial";
            this.txtCuentaInicial.Size = new System.Drawing.Size(87, 20);
            this.txtCuentaInicial.TabIndex = 19;
            this.txtCuentaInicial.TextChanged += new System.EventHandler(this.txtCuentaInicial_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cuenta Final :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cuenta Inicial :";
            // 
            // lblCuentaFinal
            // 
            this.lblCuentaFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblCuentaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCuentaFinal.Location = new System.Drawing.Point(186, 43);
            this.lblCuentaFinal.Name = "lblCuentaFinal";
            this.lblCuentaFinal.Size = new System.Drawing.Size(379, 18);
            this.lblCuentaFinal.TabIndex = 22;
            // 
            // lblCuentaInicial
            // 
            this.lblCuentaInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblCuentaInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCuentaInicial.Location = new System.Drawing.Point(186, 16);
            this.lblCuentaInicial.Name = "lblCuentaInicial";
            this.lblCuentaInicial.Size = new System.Drawing.Size(379, 18);
            this.lblCuentaInicial.TabIndex = 21;
            // 
            // cbxCuentaFinal_1
            // 
            this.cbxCuentaFinal_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCuentaFinal_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cbxCuentaFinal_1.Location = new System.Drawing.Point(313, 45);
            this.cbxCuentaFinal_1.Name = "cbxCuentaFinal_1";
            this.cbxCuentaFinal_1.Size = new System.Drawing.Size(74, 20);
            this.cbxCuentaFinal_1.TabIndex = 17;
            this.cbxCuentaFinal_1.Visible = false;
            // 
            // cbxCuentaInicial_1
            // 
            this.cbxCuentaInicial_1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCuentaInicial_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cbxCuentaInicial_1.Location = new System.Drawing.Point(313, 16);
            this.cbxCuentaInicial_1.Name = "cbxCuentaInicial_1";
            this.cbxCuentaInicial_1.Size = new System.Drawing.Size(74, 20);
            this.cbxCuentaInicial_1.TabIndex = 16;
            this.cbxCuentaInicial_1.Visible = false;
            // 
            // cboFormato
            // 
            this.cboFormato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFormato.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboFormato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cboFormato.Location = new System.Drawing.Point(128, 105);
            this.cboFormato.Name = "cboFormato";
            this.cboFormato.Size = new System.Drawing.Size(200, 20);
            this.cboFormato.TabIndex = 3;
            this.cboFormato.SelectedValueChanged += new System.EventHandler(this.cboFormato_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Formato:";
            // 
            // cbxMoneda
            // 
            this.cbxMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxMoneda.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbxMoneda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cbxMoneda.Location = new System.Drawing.Point(128, 77);
            this.cbxMoneda.Name = "cbxMoneda";
            this.cbxMoneda.Size = new System.Drawing.Size(200, 20);
            this.cbxMoneda.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Moneda :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(874, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Imprimir subdiario :";
            // 
            // checkSubdiario
            // 
            this.checkSubdiario.AutoSize = true;
            this.checkSubdiario.Location = new System.Drawing.Point(972, 134);
            this.checkSubdiario.Name = "checkSubdiario";
            this.checkSubdiario.Size = new System.Drawing.Size(15, 14);
            this.checkSubdiario.TabIndex = 4;
            this.checkSubdiario.UseVisualStyleBackColor = true;
            // 
            // btnAsientos
            // 
            this.btnAsientos.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAsientos.Location = new System.Drawing.Point(993, 58);
            this.btnAsientos.Name = "btnAsientos";
            this.btnAsientos.Size = new System.Drawing.Size(63, 61);
            this.btnAsientos.TabIndex = 5;
            this.btnAsientos.Text = "Buscar";
            this.btnAsientos.Click += new System.EventHandler(this.btnAsientos_Click);
            // 
            // cbxSubdiario
            // 
            this.cbxSubdiario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSubdiario.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbxSubdiario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.cbxSubdiario.Location = new System.Drawing.Point(479, 23);
            this.cbxSubdiario.Name = "cbxSubdiario";
            this.cbxSubdiario.Size = new System.Drawing.Size(365, 20);
            this.cbxSubdiario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hasta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subdiario :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = " Desde :";
            // 
            // dtpHasta1
            // 
            this.dtpHasta1.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta1.Location = new System.Drawing.Point(128, 50);
            this.dtpHasta1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpHasta1.Name = "dtpHasta1";
            this.dtpHasta1.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpHasta1.Size = new System.Drawing.Size(103, 20);
            this.dtpHasta1.TabIndex = 1;
            this.dtpHasta1.TabStop = false;
            this.dtpHasta1.Text = "viernes, 14 de octubre de 2011";
            this.dtpHasta1.Value = new System.DateTime(2011, 10, 14, 0, 0, 0, 0);
            this.dtpHasta1.Visible = false;
            // 
            // dtpDesde1
            // 
            this.dtpDesde1.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde1.Location = new System.Drawing.Point(128, 27);
            this.dtpDesde1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDesde1.Name = "dtpDesde1";
            this.dtpDesde1.NullDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDesde1.Size = new System.Drawing.Size(103, 20);
            this.dtpDesde1.TabIndex = 0;
            this.dtpDesde1.TabStop = false;
            this.dtpDesde1.Text = "jueves, 13 de octubre de 2011";
            this.dtpDesde1.Value = new System.DateTime(2011, 10, 13, 0, 0, 0, 0);
            this.dtpDesde1.Visible = false;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnExportarExcel);
            this.pnlButton.Controls.Add(this.btnNuevo);
            this.pnlButton.Controls.Add(this.chkNoCuadrados);
            this.pnlButton.Controls.Add(this.chkCuadrados);
            this.pnlButton.Controls.Add(this.btnEliminarTodos);
            this.pnlButton.Controls.Add(this.btnEliminar);
            this.pnlButton.Controls.Add(this.btnImprimir);
            this.pnlButton.Location = new System.Drawing.Point(12, 543);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1286, 50);
            this.pnlButton.TabIndex = 5;
            this.pnlButton.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlButton_Paint);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(1009, 9);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(129, 30);
            this.btnExportarExcel.TabIndex = 29;
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(547, 9);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(94, 29);
            this.btnNuevo.TabIndex = 28;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // chkNoCuadrados
            // 
            this.chkNoCuadrados.AutoSize = true;
            this.chkNoCuadrados.Checked = true;
            this.chkNoCuadrados.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoCuadrados.Location = new System.Drawing.Point(140, 17);
            this.chkNoCuadrados.Name = "chkNoCuadrados";
            this.chkNoCuadrados.Size = new System.Drawing.Size(137, 17);
            this.chkNoCuadrados.TabIndex = 27;
            this.chkNoCuadrados.Text = "Asientos No Cuadrados";
            this.chkNoCuadrados.UseVisualStyleBackColor = true;
            this.chkNoCuadrados.CheckedChanged += new System.EventHandler(this.chkNoCuadrados_CheckedChanged);
            // 
            // chkCuadrados
            // 
            this.chkCuadrados.AutoSize = true;
            this.chkCuadrados.Checked = true;
            this.chkCuadrados.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCuadrados.Location = new System.Drawing.Point(18, 17);
            this.chkCuadrados.Name = "chkCuadrados";
            this.chkCuadrados.Size = new System.Drawing.Size(120, 17);
            this.chkCuadrados.TabIndex = 26;
            this.chkCuadrados.Text = "Asientos Cuadrados";
            this.chkCuadrados.UseVisualStyleBackColor = true;
            this.chkCuadrados.CheckedChanged += new System.EventHandler(this.chkCuadrados_CheckedChanged);
            // 
            // btnEliminarTodos
            // 
            this.btnEliminarTodos.Location = new System.Drawing.Point(399, 9);
            this.btnEliminarTodos.Name = "btnEliminarTodos";
            this.btnEliminarTodos.Size = new System.Drawing.Size(105, 30);
            this.btnEliminarTodos.TabIndex = 8;
            this.btnEliminarTodos.Text = "Eliminar Todos";
            this.btnEliminarTodos.UseVisualStyleBackColor = true;
            this.btnEliminarTodos.Click += new System.EventHandler(this.btnEliminarTodos_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(288, 9);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 30);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImprimir.Location = new System.Drawing.Point(822, 6);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(138, 33);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dgvAsientos
            // 
            this.dgvAsientos.AllowUserToAddRows = false;
            this.dgvAsientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientos.Location = new System.Drawing.Point(7, 3);
            this.dgvAsientos.Name = "dgvAsientos";
            this.dgvAsientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientos.Size = new System.Drawing.Size(1280, 342);
            this.dgvAsientos.TabIndex = 7;
            this.dgvAsientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsientos_CellContentClick);
            this.dgvAsientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsientos_CellDoubleClick);
            // 
            // calFecha
            // 
            this.calFecha.Location = new System.Drawing.Point(67, 169);
            this.calFecha.Name = "calFecha";
            this.calFecha.TabIndex = 62;
            this.calFecha.Visible = false;
            this.calFecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calFecha_DateChanged);
            // 
            // tabVouchers
            // 
            this.tabVouchers.Controls.Add(this.tpDetalle);
            this.tabVouchers.Controls.Add(this.tpResumen);
            this.tabVouchers.Location = new System.Drawing.Point(4, 169);
            this.tabVouchers.Name = "tabVouchers";
            this.tabVouchers.SelectedIndex = 0;
            this.tabVouchers.Size = new System.Drawing.Size(1300, 374);
            this.tabVouchers.TabIndex = 65;
            this.tabVouchers.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabVouchers_Selecting);
            // 
            // tpDetalle
            // 
            this.tpDetalle.Controls.Add(this.dgvAsientos);
            this.tpDetalle.Location = new System.Drawing.Point(4, 22);
            this.tpDetalle.Name = "tpDetalle";
            this.tpDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalle.Size = new System.Drawing.Size(1292, 348);
            this.tpDetalle.TabIndex = 0;
            this.tpDetalle.Text = "Detallle";
            this.tpDetalle.UseVisualStyleBackColor = true;
            // 
            // tpResumen
            // 
            this.tpResumen.Controls.Add(this.dgvConsolidado);
            this.tpResumen.Location = new System.Drawing.Point(4, 22);
            this.tpResumen.Name = "tpResumen";
            this.tpResumen.Padding = new System.Windows.Forms.Padding(3);
            this.tpResumen.Size = new System.Drawing.Size(1292, 348);
            this.tpResumen.TabIndex = 1;
            this.tpResumen.Text = "Resumen";
            this.tpResumen.UseVisualStyleBackColor = true;
            // 
            // dgvConsolidado
            // 
            this.dgvConsolidado.AllowUserToAddRows = false;
            this.dgvConsolidado.AllowUserToDeleteRows = false;
            this.dgvConsolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsolidado.Location = new System.Drawing.Point(6, 6);
            this.dgvConsolidado.Name = "dgvConsolidado";
            this.dgvConsolidado.Size = new System.Drawing.Size(1280, 336);
            this.dgvConsolidado.TabIndex = 0;
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1310, 601);
            this.Controls.Add(this.tabVouchers);
            this.Controls.Add(this.calFecha);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.gbxBusqueda);
            this.Name = "frmVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            this.gbxBusqueda.ResumeLayout(false);
            this.gbxBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadNegocio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCuentaFinal_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCuentaInicial_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAsientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSubdiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpHasta1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDesde1)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientos)).EndInit();
            this.tabVouchers.ResumeLayout(false);
            this.tpDetalle.ResumeLayout(false);
            this.tpResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsolidado)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxBusqueda;
    private Telerik.WinControls.UI.RadButton btnAsientos;
    private Telerik.WinControls.UI.RadDropDownList cbxSubdiario;
    private Telerik.WinControls.UI.RadDateTimePicker dtpHasta1;
    private Telerik.WinControls.UI.RadDateTimePicker dtpDesde1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnlButton;
    private Telerik.WinControls.UI.RadButton btnImprimir;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox checkSubdiario;
    private Telerik.WinControls.UI.RadDropDownList cbxMoneda;
    private System.Windows.Forms.Label label5;
    private Telerik.WinControls.UI.RadDropDownList cboFormato;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.RadioButton rbCuentas;
    private System.Windows.Forms.RadioButton rbSubDiario;
    private System.Windows.Forms.GroupBox groupBox2;
    private Telerik.WinControls.UI.RadDropDownList cbxCuentaFinal_1;
    private System.Windows.Forms.Label label6;
    private Telerik.WinControls.UI.RadDropDownList cbxCuentaInicial_1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label9;
    private Telerik.WinControls.UI.RadDropDownList cboUnidadNegocio;
    private System.Windows.Forms.Label label10;
    private Telerik.WinControls.UI.RadDropDownList cboAreas;
    private System.Windows.Forms.Button btnEliminarTodos;
    private System.Windows.Forms.Button btnEliminar;
    private System.Windows.Forms.CheckBox chkNoCuadrados;
    private System.Windows.Forms.CheckBox chkCuadrados;
    private System.Windows.Forms.DataGridView dgvAsientos;
    private System.Windows.Forms.Label lblCuentaInicial;
    private System.Windows.Forms.TextBox txtCuentaFinal;
    private System.Windows.Forms.TextBox txtCuentaInicial;
    private System.Windows.Forms.Label lblCuentaFinal;
    private System.Windows.Forms.Label lblCuentaFinal_ID;
    private System.Windows.Forms.Label lblCuentaInicial_ID;
    private System.Windows.Forms.Button btnBuscarCtaFinal;
    private System.Windows.Forms.Button btnBuscarCtaInicial;
    private System.Windows.Forms.Button btnNuevo;
    private System.Windows.Forms.MonthCalendar calFecha;
    private System.Windows.Forms.Button btnHasta;
    private System.Windows.Forms.Button btnDesde;
    private System.Windows.Forms.TabControl tabVouchers;
    private System.Windows.Forms.TabPage tpDetalle;
    private System.Windows.Forms.TabPage tpResumen;
    private System.Windows.Forms.DataGridView dgvConsolidado;
    private System.Windows.Forms.Button btnExportarExcel;
    private System.Windows.Forms.MaskedTextBox txtHasta;
    private System.Windows.Forms.MaskedTextBox txtDesde;
  }
}