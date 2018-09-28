namespace Contabilidad
{
    partial class frmConfigurarConexion
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
            this.label4 = new System.Windows.Forms.Label();
            this.chkAutWindows = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.grpAutSqlServer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAutSqlServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password:";
            // 
            // chkAutWindows
            // 
            this.chkAutWindows.AutoSize = true;
            this.chkAutWindows.Location = new System.Drawing.Point(19, 189);
            this.chkAutWindows.Name = "chkAutWindows";
            this.chkAutWindows.Size = new System.Drawing.Size(192, 17);
            this.chkAutWindows.TabIndex = 19;
            this.chkAutWindows.Text = "Utilizar Autentificación de Windows";
            this.chkAutWindows.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(83, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(174, 20);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.Text = "LT2012socios";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(83, 26);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(174, 20);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.Text = "sa";
            // 
            // grpAutSqlServer
            // 
            this.grpAutSqlServer.Controls.Add(this.txtPassword);
            this.grpAutSqlServer.Controls.Add(this.label4);
            this.grpAutSqlServer.Controls.Add(this.txtUsuario);
            this.grpAutSqlServer.Controls.Add(this.label3);
            this.grpAutSqlServer.Location = new System.Drawing.Point(13, 84);
            this.grpAutSqlServer.Name = "grpAutSqlServer";
            this.grpAutSqlServer.Size = new System.Drawing.Size(275, 89);
            this.grpAutSqlServer.TabIndex = 18;
            this.grpAutSqlServer.TabStop = false;
            this.grpAutSqlServer.Text = "Autentificación Sql Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Usuario:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(152, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 39);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfigurar.Location = new System.Drawing.Point(63, 226);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(83, 39);
            this.btnConfigurar.TabIndex = 16;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(105, 45);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(174, 20);
            this.txtBaseDatos.TabIndex = 15;
            this.txtBaseDatos.Text = "SHIOL_DATOS";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(105, 16);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(174, 20);
            this.txtServidor.TabIndex = 14;
            this.txtServidor.Text = "LAWN\\SERVER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Base de Datos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Servidor:";
            // 
            // frmConfigurarConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 272);
            this.ControlBox = false;
            this.Controls.Add(this.chkAutWindows);
            this.Controls.Add(this.grpAutSqlServer);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfigurar);
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmConfigurarConexion";
            this.Text = "Configurar Conexión";
            this.Load += new System.EventHandler(this.frmConfigurarConexion_Load);
            this.grpAutSqlServer.ResumeLayout(false);
            this.grpAutSqlServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAutWindows;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.GroupBox grpAutSqlServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.TextBox txtBaseDatos;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}