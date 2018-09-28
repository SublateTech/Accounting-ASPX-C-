using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using BL;
using System.Configuration;

namespace Contabilidad
{
  public partial class frmLogin : RadForm
  {
    private BLUser objBLUser;
    public frmLogin()
    {
      InitializeComponent();
      objBLUser = new BLUser();
    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
      //this.txtUsuario.Select();
      this.cargarUsuarios();

      String last_user = ConfigurationManager.AppSettings["last_user"];

      cboUsuarios.Text = last_user;

 

    }

    private void cargarUsuarios()
    {
        BLUser usuarios = new BLUser();
        DataTable datos = usuarios.fnUsuariosAll();
        DataView vista = datos.AsDataView();
        vista.RowFilter = "Estado=0";
        vista.Sort = "NombreUsuario";
        cboUsuarios.DataSource = vista;
        cboUsuarios.DisplayMember = "NombreUsuario";
        cboUsuarios.ValueMember = "UsuarioId";
    }


    private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
        this.Login();
    }
    private void btnSalir_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Abort;
      this.Close();
    }

    private void btnIngresar_Click(object sender, EventArgs e)
    {
      this.Login();
    }
    private void Login()
    {
        try
        {
            string user = cboUsuarios.Text.Trim();
            string password = this.txtContrasena.Text.Trim();

            if (user == "" || password == "")
            {
                this.DialogResult = DialogResult.Cancel;
                RadMessageBox.Show("Debe ingresar todos los datos", "Información:", MessageBoxButtons.OK, RadMessageIcon.Info);
                this.txtContrasena.Text = "";
                this.cboUsuarios.Focus();
                this.cboUsuarios.SelectAll();
                return;
            }
            else
            {
                if (objBLUser.login(user, password))
                {
                    cDatos.UsuarioID = objBLUser.usuarioId(user);

                    Configuration objConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    objConfig.AppSettings.Settings["last_user"].Value = cboUsuarios.Text;

                    objConfig.Save(ConfigurationSaveMode.Modified);

                    ConfigurationManager.RefreshSection("appSettings");
                    
                    this.Close();

                    this.DialogResult = DialogResult.OK;


                    //verificar si se habilita totalmente el módulo;
                BL.BLHotel moduloContabilidad = new BL.BLHotel();
                if (moduloContabilidad.estaHabilitado() == true)
                {
                    frmAsientos asientos = new frmAsientos(false);

                    asientos.ShowDialog();
                }
                else
                {
                    /*poner los datos por defecto desde parametros*/
                    BLEstablecimiento objEsta = new BLEstablecimiento();
                    DataTable datosDefecto = objEsta.getEstablecimientoHotel();
                    cDatos.EstablecimientoID = Convert.ToInt32(datosDefecto.Rows[0]["EstablecimientoID"]);

                    cDatos.Establecimiento = Convert.ToString(datosDefecto.Rows[0]["NombreEstablecimiento"]);

                    cDatos.HotelID =Convert.ToInt32(datosDefecto.Rows[0]["HotelID"]);
            cDatos.Hotel =Convert.ToString(datosDefecto.Rows[0]["NombreHotel"]);

            cDatos.Periodo = DateTime.Now.Year;

                }

                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    RadMessageBox.Show("Los datos ingresados son incorrectos", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
                    this.txtContrasena.Text = "";
                    this.cboUsuarios.Focus();
                    this.cboUsuarios.SelectAll();
                    return;
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }


    }

  }
}
