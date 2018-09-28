using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using BE;
using System.Configuration;

namespace Contabilidad
{
  public partial class frmAsientos : Form
  {
    private BLEstablecimiento objBLEstablecimiento;
    private BLHotel objBLHotel;
    public frmAsientos(bool Antiguo)
    {
      InitializeComponent();
      objBLEstablecimiento = new BLEstablecimiento();
      objBLHotel = new BLHotel();
      if (Antiguo == true)
      {
          btnEstadosCuenta1.Visible = true;
          btnLibros1.Visible = true;
          btnVoucher1.Visible = true;
      }
    }

      

    private void frmAsientos_Load(object sender, EventArgs e)
    {
        //MessageBox.Show(ConfigurationManager);
        //AppSettingsReader configura = new AppSettingsReader();
        //configura.GetValue(
        //leer datos predeterminados
      
        this.loadEstablecimientos();

        Int32 settingEmpresaId = 0;
        try
        {
            settingEmpresaId = Convert.ToInt32(ConfigurationManager.AppSettings["empresaId"]);
        }
        catch
        {
            settingEmpresaId = 0;
        }

        if (settingEmpresaId != 0)
        {
            cbxEmpresa.SelectedValue = settingEmpresaId;
          

        }

        txtPeriodo.Text = ConfigurationManager.AppSettings["periodo"];

    }
    private void frmAsientos_Resize(object sender, EventArgs e)
    {
      Point pMedio = new Point(this.Width / 2, this.Height / 2);
      gbxUser.Location = new Point(pMedio.X - (gbxUser.Width / 2), gbxUser.Location.Y);
    }
    private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Char.IsDigit(e.KeyChar))
      {
        e.Handled = false;
      }
      else if (Char.IsControl(e.KeyChar))
      {
        e.Handled = false;
      }
      else if (Char.IsSeparator(e.KeyChar))
      {
        e.Handled = false;
      }
      else
      {
        e.Handled = true;
      }
    }

    public void loadEstablecimientos()
    {
      this.cbxEmpresa.DataSource = objBLEstablecimiento.getEstablecimientosAll();
      this.cbxEmpresa.DisplayMember = "NombreEstablecimiento";
      this.cbxEmpresa.ValueMember = "EstablecimientoId";
    }

    private void cbxEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
    {
        try
        {
            Int32 valor = Convert.ToInt32(cbxEmpresa.SelectedValue);
        }
        catch
        {
            return;
        }

      ComboBox _cbxEmpresa = (ComboBox)sender;
      _cbxEmpresa.SelectionLength = cbxEmpresa.Text.Length;
      if (_cbxEmpresa.SelectionLength > 0)
      {

          try
          {
              cDatos.EstablecimientoID = Convert.ToInt32(cbxEmpresa.SelectedValue);
              this.Text = this.Text; //+ cDatos.EstablecimientoID.ToString();
              this.Refresh();
          }
          catch
          {
          }

        this.cbxSucursal.DataSource = objBLHotel.getHoteles(Convert.ToInt32(_cbxEmpresa.SelectedValue));
        this.cbxSucursal.DisplayMember = "NombreHotel";
        this.cbxSucursal.ValueMember = "HotelID";
        try
        {
            
            Int32 settingSucursalId = Convert.ToInt32(ConfigurationManager.AppSettings["sucursalId"]);
            cbxSucursal.SelectedValue = settingSucursalId;
        }
        catch
        {
            
            //cbxSucursal.SelectedValue = null;
        }
        

      }
    }

    private void cbxSucursal_SelectionChangeCommitted(object sender, EventArgs e) {
        cDatos.HotelID = Convert.ToInt32(cbxSucursal.SelectedValue);
    }


    private void btnVer_Click(object sender, EventArgs e)
    {
      
    }

    private void btnLibros_Click(object sender, EventArgs e)
    {
      
    }

    private void btnVoucher_Click(object sender, EventArgs e)
    {

    }

    private void cbxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
    {

        cbxEmpresa_SelectionChangeCommitted(sender, e);

        
    }

    private void cbxSucursal_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            cDatos.EstablecimientoID = Convert.ToInt32(cbxEmpresa.SelectedValue);
            
            cDatos.Establecimiento = cbxEmpresa.Text;

            
            
        }
        catch
        {
            cDatos.EstablecimientoID = 0;
            cDatos.Establecimiento = "";
        }
        try
        {
            cDatos.HotelID = Convert.ToInt32(cbxSucursal.SelectedValue);
            cDatos.Hotel = cbxSucursal.Text;
        }
        catch
        {
            cDatos.HotelID = 0;
            cDatos.Hotel = "";
        }
        try
        {
            cDatos.Periodo = Convert.ToInt32(txtPeriodo.Text);
        }
        catch
        {
            cDatos.Periodo = 0;
        }


        if ((cDatos.EstablecimientoID != 0) && (cDatos.HotelID != 0) && (cDatos.Periodo >= 1990 && cDatos.Periodo<= DateTime.Now.Year))
        {
            Configuration objConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            objConfig.AppSettings.Settings["empresaId"].Value = cbxEmpresa.SelectedValue.ToString();

            objConfig.AppSettings.Settings["sucursalId"].Value = cbxSucursal.SelectedValue.ToString();

            objConfig.AppSettings.Settings["periodo"].Value = txtPeriodo.Text;

            objConfig.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");

            this.Close();
        }
        else
        {
            MessageBox.Show("Elija datos válidos.");
        }



    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnEstadosCuenta1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPeriodo.Text) && cbxEmpresa.SelectedValue != null && cbxSucursal.SelectedValue != null)
        {
            Int32 empresaId = Convert.ToInt32(cbxEmpresa.SelectedValue);
            String empresa = cbxEmpresa.Text;
            Int32 sucursalId = Convert.ToInt32(cbxSucursal.SelectedValue);
            String sucursal = cbxSucursal.Text;
            Int32 periodoId = Convert.ToInt32(txtPeriodo.Text);

            frmAsientosList _frmAsientosList = new frmAsientosList(empresaId, empresa, sucursalId, sucursal, periodoId);
            _frmAsientosList.MdiParent = this.MdiParent;
            _frmAsientosList.Height = this.Height;
            _frmAsientosList.Width = (Int32)(this.Width * 0.90);
            _frmAsientosList.ShowDialog();
        } 
    }

    private void btnLibros1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPeriodo.Text) && cbxEmpresa.SelectedValue != null && cbxSucursal.SelectedValue != null)
        {
            Int32 empresaId = Convert.ToInt32(cbxEmpresa.SelectedValue);
            String empresa = cbxEmpresa.Text;
            Int32 sucursalId = Convert.ToInt32(cbxSucursal.SelectedValue);
            String sucursal = cbxSucursal.Text;
            Int32 periodoId = Convert.ToInt32(txtPeriodo.Text);

            frmLibros _frmLibroDiario = new frmLibros(empresaId, empresa, sucursalId, sucursal, periodoId);
            _frmLibroDiario.MdiParent = this.MdiParent;
            _frmLibroDiario.Height = this.Height;
            _frmLibroDiario.Width = (Int32)(this.Width * 0.90);
            _frmLibroDiario.ShowDialog();
        }
    }

    private void btnVoucher1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPeriodo.Text) && cbxEmpresa.SelectedValue != null && cbxSucursal.SelectedValue != null)
        {

            Int32 empresaId = Convert.ToInt32(cbxEmpresa.SelectedValue);
            String empresa = cbxEmpresa.Text;
            Int32 sucursalId = Convert.ToInt32(cbxSucursal.SelectedValue);
            String sucursal = cbxSucursal.Text;
            Int32 periodoId = Convert.ToInt32(txtPeriodo.Text);

            frmVoucher _frmVoucher = new frmVoucher(empresaId, empresa, sucursalId, sucursal, periodoId);
            _frmVoucher.MdiParent = this.MdiParent;
            _frmVoucher.Height = this.Height;
            _frmVoucher.Width = (Int32)(this.Width * 0.90);
            _frmVoucher.ShowDialog();
        }
    }

      }
}
