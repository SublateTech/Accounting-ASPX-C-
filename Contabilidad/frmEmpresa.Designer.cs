namespace Contabilidad
{
  partial class frmEmpresa
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
      this.dgvEmpresas = new System.Windows.Forms.DataGridView();
      this.txtRazonSocial = new System.Windows.Forms.TextBox();
      this.txtRuc = new System.Windows.Forms.TextBox();
      this.txtCategoriaId = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).BeginInit();
      this.SuspendLayout();
      // 
      // dgvEmpresas
      // 
      this.dgvEmpresas.AllowUserToAddRows = false;
      this.dgvEmpresas.AllowUserToDeleteRows = false;
      this.dgvEmpresas.AllowUserToResizeRows = false;
      this.dgvEmpresas.BackgroundColor = System.Drawing.Color.White;
      this.dgvEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvEmpresas.GridColor = System.Drawing.Color.White;
      this.dgvEmpresas.Location = new System.Drawing.Point(0, 66);
      this.dgvEmpresas.MultiSelect = false;
      this.dgvEmpresas.Name = "dgvEmpresas";
      this.dgvEmpresas.ReadOnly = true;
      this.dgvEmpresas.RowHeadersWidth = 30;
      this.dgvEmpresas.Size = new System.Drawing.Size(639, 312);
      this.dgvEmpresas.TabIndex = 3;
      this.dgvEmpresas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresas_CellContentDoubleClick);
      this.dgvEmpresas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmpresas_RowHeaderMouseDoubleClick);
      this.dgvEmpresas.KeyPress+=new System.Windows.Forms.KeyPressEventHandler(dgvEmpresas_KeyPress);
      // 
      // txtRazonSocial
      // 
      this.txtRazonSocial.Location = new System.Drawing.Point(34, 33);
      this.txtRazonSocial.Name = "txtRazonSocial";
      this.txtRazonSocial.Size = new System.Drawing.Size(219, 20);
      this.txtRazonSocial.TabIndex = 0;
      this.txtRazonSocial.KeyPress+=new System.Windows.Forms.KeyPressEventHandler(txtRazonSocial_KeyPress);
      // 
      // txtRuc
      // 
      this.txtRuc.Location = new System.Drawing.Point(286, 33);
      this.txtRuc.Name = "txtRuc";
      this.txtRuc.Size = new System.Drawing.Size(179, 20);
      this.txtRuc.TabIndex = 1;
      this.txtRuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuc_KeyPress);
      // 
      // txtCategoriaId
      // 
      this.txtCategoriaId.Location = new System.Drawing.Point(494, 33);
      this.txtCategoriaId.Name = "txtCategoriaId";
      this.txtCategoriaId.Size = new System.Drawing.Size(115, 20);
      this.txtCategoriaId.TabIndex = 2;
      this.txtCategoriaId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoriaId_KeyPress);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(31, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(76, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Razon Social :";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(283, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Ruc :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(491, 14);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "CategoriaId :";
      // 
      // frmEmpresa
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
      this.ClientSize = new System.Drawing.Size(640, 378);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtCategoriaId);
      this.Controls.Add(this.txtRuc);
      this.Controls.Add(this.txtRazonSocial);
      this.Controls.Add(this.dgvEmpresas);
      this.Name = "frmEmpresa";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Empresas";
      this.Load += new System.EventHandler(this.frmEmpresa_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dgvEmpresas;
    private System.Windows.Forms.TextBox txtRazonSocial;
    private System.Windows.Forms.TextBox txtRuc;
    private System.Windows.Forms.TextBox txtCategoriaId;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
  }
}