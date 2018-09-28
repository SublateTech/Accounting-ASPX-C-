namespace Contabilidad
{
  partial class frmLogin
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
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnIngresar = new Telerik.WinControls.UI.RadButton();
            this.lblUsuario = new Telerik.WinControls.UI.RadLabel();
            this.lblContrasena = new Telerik.WinControls.UI.RadLabel();
            this.txtContrasena = new Telerik.WinControls.UI.RadTextBox();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIngresar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrasena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContrasena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.AllowShowFocusCues = true;
            this.btnSalir.Location = new System.Drawing.Point(200, 112);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(62, 60);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.AllowShowFocusCues = true;
            this.btnIngresar.Location = new System.Drawing.Point(109, 112);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(62, 60);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Location = new System.Drawing.Point(52, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 14);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContrasena
            // 
            this.lblContrasena.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasena.Location = new System.Drawing.Point(52, 65);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(63, 14);
            this.lblContrasena.TabIndex = 9;
            this.lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(121, 65);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(153, 20);
            this.txtContrasena.TabIndex = 1;
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasena_KeyPress);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsuarios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(121, 21);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(153, 21);
            this.cboUsuarios.TabIndex = 10;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 183);
            this.ControlBox = false;
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIngresar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContrasena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContrasena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btnSalir;
    private Telerik.WinControls.UI.RadButton btnIngresar;
    private Telerik.WinControls.UI.RadLabel lblUsuario;
    private Telerik.WinControls.UI.RadLabel lblContrasena;
    private Telerik.WinControls.UI.RadTextBox txtContrasena;
    private System.Windows.Forms.ComboBox cboUsuarios;
  }
}