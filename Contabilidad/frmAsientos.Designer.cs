namespace Contabilidad
{
  partial class frmAsientos
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
            this.gbxUser = new System.Windows.Forms.GroupBox();
            this.btnVoucher1 = new System.Windows.Forms.Button();
            this.btnLibros1 = new System.Windows.Forms.Button();
            this.btnEstadosCuenta1 = new System.Windows.Forms.Button();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.cbxSucursal = new System.Windows.Forms.ComboBox();
            this.cbxEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxUser
            // 
            this.gbxUser.Controls.Add(this.btnVoucher1);
            this.gbxUser.Controls.Add(this.btnLibros1);
            this.gbxUser.Controls.Add(this.btnEstadosCuenta1);
            this.gbxUser.Controls.Add(this.txtPeriodo);
            this.gbxUser.Controls.Add(this.cbxSucursal);
            this.gbxUser.Controls.Add(this.cbxEmpresa);
            this.gbxUser.Controls.Add(this.label3);
            this.gbxUser.Controls.Add(this.label2);
            this.gbxUser.Controls.Add(this.label1);
            this.gbxUser.Location = new System.Drawing.Point(10, 8);
            this.gbxUser.Name = "gbxUser";
            this.gbxUser.Size = new System.Drawing.Size(355, 178);
            this.gbxUser.TabIndex = 1;
            this.gbxUser.TabStop = false;
            this.gbxUser.Text = "Datos de la empresa";
            // 
            // btnVoucher1
            // 
            this.btnVoucher1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoucher1.Enabled = false;
            this.btnVoucher1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucher1.Location = new System.Drawing.Point(534, 56);
            this.btnVoucher1.Name = "btnVoucher1";
            this.btnVoucher1.Size = new System.Drawing.Size(62, 60);
            this.btnVoucher1.TabIndex = 8;
            this.btnVoucher1.Text = "Voucher";
            this.btnVoucher1.UseVisualStyleBackColor = false;
            this.btnVoucher1.Click += new System.EventHandler(this.btnVoucher1_Click);
            // 
            // btnLibros1
            // 
            this.btnLibros1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLibros1.Enabled = false;
            this.btnLibros1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibros1.Location = new System.Drawing.Point(466, 56);
            this.btnLibros1.Name = "btnLibros1";
            this.btnLibros1.Size = new System.Drawing.Size(62, 60);
            this.btnLibros1.TabIndex = 7;
            this.btnLibros1.Text = "Libros";
            this.btnLibros1.UseVisualStyleBackColor = false;
            this.btnLibros1.Click += new System.EventHandler(this.btnLibros1_Click);
            // 
            // btnEstadosCuenta1
            // 
            this.btnEstadosCuenta1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEstadosCuenta1.Enabled = false;
            this.btnEstadosCuenta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadosCuenta1.Location = new System.Drawing.Point(398, 56);
            this.btnEstadosCuenta1.Name = "btnEstadosCuenta1";
            this.btnEstadosCuenta1.Size = new System.Drawing.Size(62, 60);
            this.btnEstadosCuenta1.TabIndex = 6;
            this.btnEstadosCuenta1.Text = "Cuentas";
            this.btnEstadosCuenta1.UseVisualStyleBackColor = false;
            this.btnEstadosCuenta1.Click += new System.EventHandler(this.btnEstadosCuenta1_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(144, 116);
            this.txtPeriodo.MaxLength = 4;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(121, 20);
            this.txtPeriodo.TabIndex = 2;
            this.txtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(144, 88);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(199, 21);
            this.cbxSucursal.TabIndex = 1;
            this.cbxSucursal.SelectedIndexChanged += new System.EventHandler(this.cbxSucursal_SelectedIndexChanged);
            // 
            // cbxEmpresa
            // 
            this.cbxEmpresa.FormattingEnabled = true;
            this.cbxEmpresa.Location = new System.Drawing.Point(144, 56);
            this.cbxEmpresa.Name = "cbxEmpresa";
            this.cbxEmpresa.Size = new System.Drawing.Size(199, 21);
            this.cbxEmpresa.TabIndex = 0;
            this.cbxEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbxEmpresa_SelectedIndexChanged);
            this.cbxEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cbxEmpresa_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sucursal :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Periodo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa :";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(126, 192);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(84, 35);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(213, 192);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAsientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(379, 234);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbxUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAsientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asientos Contables";
            this.Load += new System.EventHandler(this.frmAsientos_Load);
            this.Resize += new System.EventHandler(this.frmAsientos_Resize);
            this.gbxUser.ResumeLayout(false);
            this.gbxUser.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox gbxUser;
    private System.Windows.Forms.TextBox txtPeriodo;
    private System.Windows.Forms.ComboBox cbxSucursal;
    private System.Windows.Forms.ComboBox cbxEmpresa;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnAceptar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnEstadosCuenta1;
    private System.Windows.Forms.Button btnLibros1;
    private System.Windows.Forms.Button btnVoucher1;
  }
}