using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Telerik.WinControls;
using System.Data.SqlClient;
using BL;
using AD;

namespace Contabilidad
{
  public partial class frmLibros : Form
  {
    private Int32 empresaId;
    private String empresa;
    private Int32 sucursalId;
    private String sucursal;
    private Int32 periodoId;
    private String rucParam;
    private String direccParam;
    private BLMoneda objBLMoneda;
    private BLAlmacen objBLAlmacen;

    BLComprobador objCnx = new BLComprobador();
    Traza tr = new Traza();
    public frmLibros()
    {
      InitializeComponent();
    }

      public void ListMes ()
    {
          string[] mes =new  string [12];
          mes[0] = "Enero";
          mes[1] = "Febrero";
          mes[2] = "Marzo";
          mes[3] = "Abril";
          mes[4] = "Mayo";
          mes[5] = "Junio";
          mes[6] = "Julio";
          mes[7] = "Agosto";
          mes[8] = "Setiembre";
          mes[9] = "Octubre";
          mes[10] = "Noviembre";
          mes[11] = "Diciembre";
         
          //for (int i = 0; i < mes.Length; i++)
          //{
          //    cboMeses.Items.Add(mes[i]);      
          //}

          cboMeses.DataSource = mes;


    }
    public frmLibros(Int32 _empresaId, String _empresa, Int32 _sucursalId, String _sucursal, Int32 _periodoId)
    {
      InitializeComponent();
      empresaId = _empresaId;
      empresa = _empresa;
      sucursalId = _sucursalId;
      sucursal = _sucursal;
      periodoId = _periodoId;

      objBLMoneda = new BLMoneda();
      objBLAlmacen = new BLAlmacen();
    }
    private void frmLibroDiario_Load(object sender, EventArgs e)
    {
      
      this.cbxMoneda.DataSource = objBLMoneda.getMoneda();
      this.cbxMoneda.DisplayMember = "Nombre";
      this.cbxMoneda.ValueMember = "monedaid";

      this.cbxAlmacen.DataSource = objBLAlmacen.almacenesAll();
      this.cbxAlmacen.DisplayMember = "NombreAlmacen";
      this.cbxAlmacen.ValueMember = "AlmacenId";

      this.dtpDesde.Value = DateTime.Now;
      this.dtpHasta.Value = DateTime.Now;
      this.checkExcel.Visible = false;
      this.label4.Visible = false;

      SqlConnection sqlconn = new SqlConnection(Connection.connectionString());
      sqlconn.Open();
      SqlCommand command_resultado_busqueda = new SqlCommand(" EXEC SWP_ParametroReporte ", sqlconn);
      SqlDataReader dataReader_resultado_busqueda = command_resultado_busqueda.ExecuteReader();
      while ((dataReader_resultado_busqueda.Read()))
      {
          rucParam = dataReader_resultado_busqueda.GetValue(1).ToString();
          direccParam = dataReader_resultado_busqueda.GetValue(2).ToString();
      }
      ListMes();
    }

    private void btnDiarioResumido_Click(object sender, EventArgs e)
    {
      DateTime fechaInicio = this.dtpDesde.Value;
      DateTime fechaFin = this.dtpHasta.Value;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      //MessageBox.Show(fechaInicio.ToShortDateString());

      if (fechaFin >= fechaInicio)
      {
        try
        {

            Form_DiarioResumidoReport _Form_DiarioResumidoRep = new Form_DiarioResumidoReport();
            _Form_DiarioResumidoRep.fechaInicio = this.dtpDesde.Value;
            _Form_DiarioResumidoRep.fechaFin = this.dtpHasta.Value;
            _Form_DiarioResumidoRep.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
            _Form_DiarioResumidoRep.checkExcel = checkExcel.Checked;
            _Form_DiarioResumidoRep.monedaNom = cbxMoneda.Text;
            _Form_DiarioResumidoRep.rucParam = rucParam;
            _Form_DiarioResumidoRep.direccParam = direccParam;

            _Form_DiarioResumidoRep.empresaId = empresaId;
            _Form_DiarioResumidoRep.empresa = empresa;
            _Form_DiarioResumidoRep._sucursalId = sucursalId;
            _Form_DiarioResumidoRep._sucursal = sucursal;
            _Form_DiarioResumidoRep.periodoId = periodoId;
            //_Form_DiarioResumidoRep.Height = this.Height;
            //_Form_DiarioResumidoRep.Width = (Int32)(this.Width * 0.90);
            _Form_DiarioResumidoRep.Show();


          //if (checkExcel.Checked)
          //{
          //  reports.rptLibroDiarioExcel _rptLibroDiario = new reports.rptLibroDiarioExcel();
          //  //pase 13
          //  //_rptLibroDiario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  //_rptLibroDiario.DataSourceConnections[0].SetConnection(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["bd"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"]);

          //  //_rptLibroDiario.SetParameterValue("@MonedaID", monedaId);
          //  //_rptLibroDiario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  //_rptLibroDiario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  //_rptLibroDiario.SetParameterValue("@Detallado", 0);
          //  //_rptLibroDiario.SetParameterValue("@EmpresaID", empresaId);
          //  //_rptLibroDiario.SetParameterValue("@Ejercicio", periodoId);
          //  //_rptLibroDiario.SetParameterValue("name_report", "Libro Diario");
          //  //_rptLibroDiario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  //_rptLibroDiario.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  //_rptLibroDiario.SetParameterValue("empresa", empresa);
          //  //_rptLibroDiario.SetParameterValue("periodo", periodoId);
          //  //_rptLibroDiario.SetParameterValue("ruc", "20303368877");
          //  //_rptLibroDiario.SetParameterValue("ruc", rucParam);
          //  //_rptLibroDiario.SetParameterValue("address", "Av. Guardia Civil #727 San Borja");
          //  //_rptLibroDiario.SetParameterValue("address", direccParam);
          //  //crvLibros.ReportSource = _rptLibroDiario;
          //}
          //else
          //{
          //  reports.rptLibroDiario _rptLibroDiario = new reports.rptLibroDiario();
          //  //pase 14
          //  //_rptLibroDiario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
          //  //_rptLibroDiario.DataSourceConnections[0].SetConnection("FOYER", "Shiol_datos", "sa", "Prince1");

          //  //_rptLibroDiario.SetParameterValue("@MonedaID", monedaId);
          //  //_rptLibroDiario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  //_rptLibroDiario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  //_rptLibroDiario.SetParameterValue("@Detallado", 0);
          //  //_rptLibroDiario.SetParameterValue("@EmpresaID", empresaId);
          //  //_rptLibroDiario.SetParameterValue("@Ejercicio", periodoId);
          //  //_rptLibroDiario.SetParameterValue("name_report", "Libro Diario");
          //  //_rptLibroDiario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  //_rptLibroDiario.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  //_rptLibroDiario.SetParameterValue("empresa", empresa);
          //  //_rptLibroDiario.SetParameterValue("periodo", periodoId);
          //  //_rptLibroDiario.SetParameterValue("ruc", rucParam);
          //  //_rptLibroDiario.SetParameterValue("address", direccParam);
          //  //crvLibros.ReportSource = _rptLibroDiario;
          //}
                      
          ////Form_DiarioResumidoReport _Form_DiarioResumidoRep = new Form_DiarioResumidoReport(cDatos.EstablecimientoID, cDatos.Establecimiento, cDatos.HotelID, cDatos.Hotel, cDatos.Periodo);
          ////_Form_DiarioResumidoRep.MdiParent = this.MdiParent;
          ////_Form_DiarioResumidoRep.Show();

            
        }
        catch
        {
          RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }

    private void btnDiarioDetallado_Click(object sender, EventArgs e)
    {
        string valormes = (cboMeses.SelectedIndex + 1).ToString();
        string f = "01/" + valormes + "/" + periodoId ;
        DateTime f1 = Convert.ToDateTime(f);
        DateTime f2;
        if (f1.Month + 1 < 13)
        { 
            f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1);
           // f2 = new DateTime(f1.Year, f1.Month , 3).AddDays(-1); 
        }
        else
        { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }


      DateTime fechaInicio = f1;
      DateTime fechaFin = f2;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      //MessageBox.Show(fechaInicio.ToShortDateString());
      

      if (fechaFin >= fechaInicio)
      {
        try
        {
           
//          if (checkExcel.Checked)
//          {
//            reports.rptLibroDiarioExcel _rptLibroDiario = new reports.rptLibroDiarioExcel();
//              //pase 01
            
//            _rptLibroDiario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());


//            //_rptLibroDiario.DataSourceConnections[0].SetConnection(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["bd"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"]);

//            _rptLibroDiario.SetParameterValue("@MonedaID", monedaId);
//            _rptLibroDiario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
//            _rptLibroDiario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
//            _rptLibroDiario.SetParameterValue("@Detallado", 1);
//            _rptLibroDiario.SetParameterValue("@EmpresaID", empresaId);
//            _rptLibroDiario.SetParameterValue("@Ejercicio", periodoId);
//            _rptLibroDiario.SetParameterValue("name_report", "Libro Diario");
//            _rptLibroDiario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
//            _rptLibroDiario.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
//            _rptLibroDiario.SetParameterValue("empresa", empresa);
//            _rptLibroDiario.SetParameterValue("periodo", periodoId);
//            _rptLibroDiario.SetParameterValue("ruc", rucParam);
//            _rptLibroDiario.SetParameterValue("address", direccParam);
//            crvLibros.ReportSource = _rptLibroDiario;
//          }
//          else
//          {
//            reports.rptLibroDiario _rptLibroDiario = new reports.rptLibroDiario();
//            //pase 02

//            _rptLibroDiario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
////            _rptLibroDiario.DataSourceConnections[0].SetConnection(ConfigurationManager.AppSettings["server"], ConfigurationManager.AppSettings["bd"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"]);

//            _rptLibroDiario.SetParameterValue("@MonedaID", monedaId);
//            _rptLibroDiario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
//            _rptLibroDiario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
//            _rptLibroDiario.SetParameterValue("@Detallado", 1);
//            _rptLibroDiario.SetParameterValue("@EmpresaID", empresaId);
//            _rptLibroDiario.SetParameterValue("@Ejercicio", periodoId);
//            _rptLibroDiario.SetParameterValue("name_report", "Libro Diario");
//            _rptLibroDiario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
//            _rptLibroDiario.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
//            _rptLibroDiario.SetParameterValue("empresa", empresa);
//            _rptLibroDiario.SetParameterValue("periodo", periodoId);
//            _rptLibroDiario.SetParameterValue("ruc", rucParam);
//            _rptLibroDiario.SetParameterValue("address", direccParam);
//            crvLibros.ReportSource = _rptLibroDiario;
//          }
           
          Form_DiarioDetalladoReport _Form_DiarioDetalladoRep = new Form_DiarioDetalladoReport();
          _Form_DiarioDetalladoRep.fechaInicio = f1;
          _Form_DiarioDetalladoRep.fechaFin = f2;
          _Form_DiarioDetalladoRep.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
          _Form_DiarioDetalladoRep.checkExcel = checkExcel.Checked;
          _Form_DiarioDetalladoRep.checkVertical =cbVertical.Checked;
          _Form_DiarioDetalladoRep.monedaNom = cbxMoneda.Text;
          _Form_DiarioDetalladoRep.rucParam = rucParam;
          _Form_DiarioDetalladoRep.direccParam = direccParam;
          _Form_DiarioDetalladoRep.empresaId = empresaId;
          _Form_DiarioDetalladoRep.empresa = empresa;
          _Form_DiarioDetalladoRep._sucursalId = sucursalId;
          _Form_DiarioDetalladoRep._sucursal = sucursal;
          _Form_DiarioDetalladoRep.periodoId = periodoId;
          //_Form_DiarioDetalladoRep.Height = this.Height;
          //_Form_DiarioDetalladoRep.Width = (Int32)(this.Width * 0.90);
          _Form_DiarioDetalladoRep.Show();
          
        }
        catch(Exception ex)
        {
           // tr.Trazas("erroreeeeeeeee");
            //RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
            MessageBox.Show(ex.ToString());
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }

    }

    private void btnMayorResumido_Click(object sender, EventArgs e)
    {
      DateTime fechaInicio = this.dtpDesde.Value;
      DateTime fechaFin = this.dtpHasta.Value;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      //MessageBox.Show(fechaInicio.ToShortDateString());

      if (fechaFin >= fechaInicio)
      {
        try
        {
          //if (checkExcel.Checked)
          //{
          //  reports.rptLibroMayorExcel _rptLibroMayor = new reports.rptLibroMayorExcel();
          //  //pase 03
          //  _rptLibroMayor.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  _rptLibroMayor.SetParameterValue("@MonedaID", monedaId);
          //  _rptLibroMayor.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Detallado", 0);
          //  _rptLibroMayor.SetParameterValue("@EmpresaID", empresaId);
          //  _rptLibroMayor.SetParameterValue("@Ejercicio", periodoId);
          //  _rptLibroMayor.SetParameterValue("@EstablecimientoID", sucursalId);
          //  _rptLibroMayor.SetParameterValue("name_report", "Libro Mayor");
          //  _rptLibroMayor.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  _rptLibroMayor.SetParameterValue("empresa", empresa);
          //  _rptLibroMayor.SetParameterValue("periodo", periodoId);
          //  _rptLibroMayor.SetParameterValue("ruc", rucParam);
          //  _rptLibroMayor.SetParameterValue("address", direccParam);
          //  crvLibros.ReportSource = _rptLibroMayor;
          //}
          //else
          //{
          //  reports.rptLibroMayor _rptLibroMayor = new reports.rptLibroMayor();
          //  //pase 04
          //  _rptLibroMayor.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  _rptLibroMayor.SetParameterValue("@MonedaID", monedaId);
          //  _rptLibroMayor.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Detallado", 0);
          //  _rptLibroMayor.SetParameterValue("@EmpresaID", empresaId);
          //  _rptLibroMayor.SetParameterValue("@Ejercicio", periodoId);
          //  _rptLibroMayor.SetParameterValue("@EstablecimientoID", sucursalId);
          //  _rptLibroMayor.SetParameterValue("name_report", "Libro Mayor");
          //  _rptLibroMayor.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  _rptLibroMayor.SetParameterValue("empresa", empresa);
          //  _rptLibroMayor.SetParameterValue("periodo", periodoId);
          //  _rptLibroMayor.SetParameterValue("ruc", rucParam);
          //  _rptLibroMayor.SetParameterValue("address", direccParam);
          //  crvLibros.ReportSource = _rptLibroMayor;
          //}

          Form_MayorResumidoReport _Form_MayorResumidoRep = new Form_MayorResumidoReport();
          _Form_MayorResumidoRep.fechaInicio = this.dtpDesde.Value;
          _Form_MayorResumidoRep.fechaFin = this.dtpHasta.Value;
          _Form_MayorResumidoRep.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
          _Form_MayorResumidoRep.checkExcel = checkExcel.Checked;
          _Form_MayorResumidoRep.monedaNom = cbxMoneda.Text;
          _Form_MayorResumidoRep.rucParam = rucParam;
          _Form_MayorResumidoRep.direccParam = direccParam;
          _Form_MayorResumidoRep.empresaId = empresaId;
          _Form_MayorResumidoRep.empresa = empresa;
          _Form_MayorResumidoRep._sucursalId = sucursalId;
          _Form_MayorResumidoRep._sucursal = sucursal;
          _Form_MayorResumidoRep.periodoId = periodoId;
          //_Form_MayorResumidoRep.Height = this.Height;
          //_Form_MayorResumidoRep.Width = (Int32)(this.Width * 0.90);
          _Form_MayorResumidoRep.Show();
        }
        catch
        {
          RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }

    private void btnMayorDetallado_Click(object sender, EventArgs e)
    {
        string valormes = (cboMeses.SelectedIndex + 1).ToString();
        string f = "01/" + valormes + "/" + periodoId;
        DateTime f1 = Convert.ToDateTime(f);
        DateTime f2;
        if (f1.Month + 1 < 13)
        { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
        else
        { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }
      DateTime fechaInicio = f1;
      DateTime fechaFin = f2;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      //MessageBox.Show(fechaInicio.ToShortDateString());

      if (fechaFin >= fechaInicio)
      {
        try
        {
          //if (checkExcel.Checked)
          //{
          //  reports.rptLibroMayorExcel _rptLibroMayor = new reports.rptLibroMayorExcel();
          //  //pase 05
          //  _rptLibroMayor.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  _rptLibroMayor.SetParameterValue("@MonedaID", monedaId);
          //  _rptLibroMayor.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Detallado", 1);
          //  _rptLibroMayor.SetParameterValue("@EmpresaID", empresaId);
          //  _rptLibroMayor.SetParameterValue("@Ejercicio", periodoId);
          //  _rptLibroMayor.SetParameterValue("@EstablecimientoID", sucursalId);
          //  _rptLibroMayor.SetParameterValue("name_report", "Libro Mayor");
          //  _rptLibroMayor.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  _rptLibroMayor.SetParameterValue("empresa", empresa);
          //  _rptLibroMayor.SetParameterValue("periodo", periodoId);
          //  _rptLibroMayor.SetParameterValue("ruc", rucParam);
          //  _rptLibroMayor.SetParameterValue("address", direccParam);
          //  crvLibros.ReportSource = _rptLibroMayor;
          //}
          //else
          //{
          //  reports.rptLibroMayor _rptLibroMayor = new reports.rptLibroMayor();
          //  //pase 06
          //  _rptLibroMayor.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  _rptLibroMayor.SetParameterValue("@MonedaID", monedaId);
          //  _rptLibroMayor.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("@Detallado", 1);
          //  _rptLibroMayor.SetParameterValue("@EmpresaID", empresaId);
          //  _rptLibroMayor.SetParameterValue("@Ejercicio", periodoId);
          //  _rptLibroMayor.SetParameterValue("@EstablecimientoID", sucursalId);
          //  _rptLibroMayor.SetParameterValue("name_report", "Libro Mayor");
          //  _rptLibroMayor.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  _rptLibroMayor.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  _rptLibroMayor.SetParameterValue("empresa", empresa);
          //  _rptLibroMayor.SetParameterValue("periodo", periodoId);
          //  _rptLibroMayor.SetParameterValue("ruc", rucParam);
          //  _rptLibroMayor.SetParameterValue("address", direccParam);
          //  crvLibros.ReportSource = _rptLibroMayor;
          //}
          Form_MayorDetalladoReport _Form_MayorDetalladoRep = new Form_MayorDetalladoReport();
          _Form_MayorDetalladoRep.fechaInicio = f1;
          _Form_MayorDetalladoRep.fechaFin = f2;
          _Form_MayorDetalladoRep.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
          _Form_MayorDetalladoRep.checkExcel = checkExcel.Checked;
          _Form_MayorDetalladoRep.checkVertical = cbVertical.Checked;
          _Form_MayorDetalladoRep.monedaNom = cbxMoneda.Text;
          _Form_MayorDetalladoRep.rucParam = rucParam;
          _Form_MayorDetalladoRep.direccParam = direccParam;
          _Form_MayorDetalladoRep.empresaId = empresaId;
          _Form_MayorDetalladoRep.empresa = empresa;
          _Form_MayorDetalladoRep._sucursalId = sucursalId;
          _Form_MayorDetalladoRep._sucursal = sucursal;
          _Form_MayorDetalladoRep.periodoId = periodoId;
          //_Form_MayorDetalladoRep.Height = this.Height;
          //_Form_MayorDetalladoRep.Width = (Int32)(this.Width * 0.90);
          _Form_MayorDetalladoRep.Show();         
          
        }
        catch
        {
          RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }

    private void btnCtaCteResumido_Click(object sender, EventArgs e)
    {
        string valormes = (cboMeses.SelectedIndex + 1).ToString();
        string f = "01/" + valormes + "/" + periodoId;
        DateTime f1 = Convert.ToDateTime(f);
        DateTime f2;
        if (f1.Month + 1 < 13)
        { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
        else
        { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }

      DateTime fechaInicio = f1;
      DateTime fechaFin = f2;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      
      if (fechaFin >= fechaInicio)
      {
        try
        {
            
          //if (checkExcel.Checked)
          //{
          //  reports.rptLibroCajaCuentaCorrienteExcel _rptLibroCtaCorriente = new reports.rptLibroCajaCuentaCorrienteExcel();
          //  //pase 07
          //  _rptLibroCtaCorriente.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  _rptLibroCtaCorriente.SetParameterValue("@MonedaID", monedaId);
          //  _rptLibroCtaCorriente.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  _rptLibroCtaCorriente.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  _rptLibroCtaCorriente.SetParameterValue("@Detallado", 0);
          //  _rptLibroCtaCorriente.SetParameterValue("@EmpresaID", empresaId);
          //  _rptLibroCtaCorriente.SetParameterValue("@Ejercicio", periodoId);
          //  //_rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", sucursalId);
          //  _rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", empresaId);
          //  _rptLibroCtaCorriente.SetParameterValue("name_report", "Libro Caja y Bancos(Mov Cta Corriente)");
          //  _rptLibroCtaCorriente.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  _rptLibroCtaCorriente.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  _rptLibroCtaCorriente.SetParameterValue("empresa", empresa);
          //  _rptLibroCtaCorriente.SetParameterValue("periodo", periodoId);
          //  _rptLibroCtaCorriente.SetParameterValue("ruc", rucParam);
          //  _rptLibroCtaCorriente.SetParameterValue("address", direccParam);
          //  crvLibros.ReportSource = _rptLibroCtaCorriente;
          //}
          //else
          //{
          //  reports.rptLibroCajaCuentaCorriente _rptLibroCtaCorriente = new reports.rptLibroCajaCuentaCorriente();
          //  //pase 08
          //  _rptLibroCtaCorriente.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //  _rptLibroCtaCorriente.SetParameterValue("@MonedaID", monedaId);
          //  _rptLibroCtaCorriente.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //  _rptLibroCtaCorriente.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //  _rptLibroCtaCorriente.SetParameterValue("@Detallado", 0);
          //  _rptLibroCtaCorriente.SetParameterValue("@EmpresaID", empresaId);
          //  _rptLibroCtaCorriente.SetParameterValue("@Ejercicio", periodoId);
          //  //_rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", sucursalId);
          //  _rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", empresaId);
          //  _rptLibroCtaCorriente.SetParameterValue("name_report", "Libro Caja y Bancos(Mov Cta Corriente)");
          //  _rptLibroCtaCorriente.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //  _rptLibroCtaCorriente.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //  _rptLibroCtaCorriente.SetParameterValue("empresa", empresa);
          //  _rptLibroCtaCorriente.SetParameterValue("periodo", periodoId);
          //  _rptLibroCtaCorriente.SetParameterValue("ruc", rucParam);
          //  _rptLibroCtaCorriente.SetParameterValue("address", direccParam);
          //  crvLibros.ReportSource = _rptLibroCtaCorriente;
          //}
           
         
          if(chka3.Checked== true)
          {
              
              Form_CuentaCorrienteReport3 _Form_CuentaCorrienteRepa3 = new Form_CuentaCorrienteReport3();
              _Form_CuentaCorrienteRepa3.fechaInicio = f1;
              _Form_CuentaCorrienteRepa3.fechaFin = f2;
              _Form_CuentaCorrienteRepa3.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
              _Form_CuentaCorrienteRepa3.checkExcel = checkExcel.Checked;
              _Form_CuentaCorrienteRepa3.monedaNom = cbxMoneda.Text;
              _Form_CuentaCorrienteRepa3.rucParam = rucParam;
              _Form_CuentaCorrienteRepa3.direccParam = direccParam;
              _Form_CuentaCorrienteRepa3.empresaId = empresaId;
              _Form_CuentaCorrienteRepa3.empresa = empresa;
              _Form_CuentaCorrienteRepa3._sucursalId = sucursalId;
              _Form_CuentaCorrienteRepa3._sucursal = sucursal;
              _Form_CuentaCorrienteRepa3.periodoId = periodoId;
              _Form_CuentaCorrienteRepa3.Show();
              
          
          
          }
          else
          {
              Form_CuentaCorrienteReport _Form_CuentaCorrienteRep = new Form_CuentaCorrienteReport();
              _Form_CuentaCorrienteRep.fechaInicio = f1;
              _Form_CuentaCorrienteRep.fechaFin = f2;
              _Form_CuentaCorrienteRep.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
              _Form_CuentaCorrienteRep.checkExcel = checkExcel.Checked;
              _Form_CuentaCorrienteRep.monedaNom = cbxMoneda.Text;
              _Form_CuentaCorrienteRep.rucParam = rucParam;
              _Form_CuentaCorrienteRep.direccParam = direccParam;
              _Form_CuentaCorrienteRep.empresaId = empresaId;
              _Form_CuentaCorrienteRep.empresa = empresa;
              _Form_CuentaCorrienteRep._sucursalId = sucursalId;
              _Form_CuentaCorrienteRep._sucursal = sucursal;
              _Form_CuentaCorrienteRep.periodoId = periodoId;
              _Form_CuentaCorrienteRep.Show();
              
          }

          
        }
        catch(Exception ex)
        {
            //tr.Trazas("erroreeeeeeeee");
            //RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
            MessageBox.Show(ex.ToString());
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }
    private void btnCtaEfectivo_Click(object sender, EventArgs e)
    {

      
        //tr.Trazas("Inicioooo");
        //cuenta efectivo
        string valormes = (cboMeses.SelectedIndex + 1).ToString();
        string f = "01/" + valormes + "/" + periodoId;
        DateTime f1 = Convert.ToDateTime(f);
        DateTime f2;
        if (f1.Month + 1 < 13)
        { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
        else
        { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }
      DateTime fechaInicio = f1;
      DateTime fechaFin = f2;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      //tr.Trazas("2");
      if (fechaFin >= fechaInicio)
      {
        try
        {
          //if(checkExcel.Checked)
          //{
          //  reports.rptLibroBancosExcel _rptLibroBancos = new reports.rptLibroBancosExcel();
          //  //pase 09
          //  _rptLibroBancos.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //_rptLibroBancos.SetParameterValue("@MonedaID", monedaId);
          //_rptLibroBancos.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //_rptLibroBancos.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //_rptLibroBancos.SetParameterValue("@Detallado", 1);
          //_rptLibroBancos.SetParameterValue("@EmpresaID", empresaId);
          //_rptLibroBancos.SetParameterValue("@Ejercicio", periodoId);
          ////_rptLibroBancos.SetParameterValue("@EstablecimientoID", sucursalId);
          //_rptLibroBancos.SetParameterValue("@EstablecimientoID", empresaId);
          //_rptLibroBancos.SetParameterValue("name_report", "Libro Caja y Bancos(Mov Cta Efectivo)");
          //_rptLibroBancos.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //_rptLibroBancos.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //_rptLibroBancos.SetParameterValue("empresa", empresa);
          //_rptLibroBancos.SetParameterValue("periodo", periodoId);
          //_rptLibroBancos.SetParameterValue("ruc", rucParam);
          //_rptLibroBancos.SetParameterValue("address", direccParam);
          //crvLibros.ReportSource = _rptLibroBancos;
          //}
          //else
          //{
          //reports.rptLibroBancos _rptLibroBancos = new reports.rptLibroBancos();
          ////pase 10
          //_rptLibroBancos.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //_rptLibroBancos.SetParameterValue("@MonedaID", monedaId);
          //_rptLibroBancos.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //_rptLibroBancos.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //_rptLibroBancos.SetParameterValue("@Detallado", 1);
          //_rptLibroBancos.SetParameterValue("@EmpresaID", empresaId);
          //_rptLibroBancos.SetParameterValue("@Ejercicio", periodoId);
          ////_rptLibroBancos.SetParameterValue("@EstablecimientoID", sucursalId);
          //_rptLibroBancos.SetParameterValue("@EstablecimientoID", empresaId);
          //_rptLibroBancos.SetParameterValue("name_report", "Libro Caja y Bancos(Mov Cta Efectivo)");
          //_rptLibroBancos.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //_rptLibroBancos.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //_rptLibroBancos.SetParameterValue("empresa", empresa);
          //_rptLibroBancos.SetParameterValue("periodo", periodoId);
          //_rptLibroBancos.SetParameterValue("ruc", rucParam);
          //_rptLibroBancos.SetParameterValue("address", direccParam);
          //crvLibros.ReportSource = _rptLibroBancos;
          //}
            //tr.Trazas("3");
     

            if(chka3.Checked== true)
            {
                Form_CuentaEfectivoReporta3 _Form_CuentaEfectivoReport = new Form_CuentaEfectivoReporta3();
                //tr.Trazas("4");
                _Form_CuentaEfectivoReport.fechaInicio = f1;
                //tr.Trazas("5");
                _Form_CuentaEfectivoReport.fechaFin = f2;
                //tr.Trazas("6");
                _Form_CuentaEfectivoReport.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
                _Form_CuentaEfectivoReport.checkExcel = checkExcel.Checked; //tr.Trazas("8");
                _Form_CuentaEfectivoReport.monedaNom = cbxMoneda.Text; //tr.Trazas("9");
                _Form_CuentaEfectivoReport.rucParam = rucParam; //tr.Trazas("10");
                _Form_CuentaEfectivoReport.direccParam = direccParam; //tr.Trazas("11");
                _Form_CuentaEfectivoReport.empresaId = empresaId; //tr.Trazas("12");
                _Form_CuentaEfectivoReport.empresa = empresa; //tr.Trazas("13");
                _Form_CuentaEfectivoReport._sucursalId = sucursalId; //tr.Trazas("14");
                _Form_CuentaEfectivoReport._sucursal = sucursal; //tr.Trazas("15");
                _Form_CuentaEfectivoReport.periodoId = periodoId; //tr.Trazas("16");
                //_Form_CuentaEfectivoReport.Height = this.Height;
                //_Form_CuentaEfectivoReport.Width = (Int32)(this.Width * 0.90);
                _Form_CuentaEfectivoReport.Show(); //tr.Trazas("finmnnnnnn");

            }
            else
            {
                Form_CuentaEfectivoReport _Form_CuentaEfectivoReport = new Form_CuentaEfectivoReport();
                //tr.Trazas("4");
                _Form_CuentaEfectivoReport.fechaInicio = f1;
                //tr.Trazas("5");
                _Form_CuentaEfectivoReport.fechaFin = f2;
                //tr.Trazas("6");
                _Form_CuentaEfectivoReport.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
                _Form_CuentaEfectivoReport.checkExcel = checkExcel.Checked; //tr.Trazas("8");
                _Form_CuentaEfectivoReport.monedaNom = cbxMoneda.Text; //tr.Trazas("9");
                _Form_CuentaEfectivoReport.rucParam = rucParam; //tr.Trazas("10");
                _Form_CuentaEfectivoReport.direccParam = direccParam; //tr.Trazas("11");
                _Form_CuentaEfectivoReport.empresaId = empresaId; //tr.Trazas("12");
                _Form_CuentaEfectivoReport.empresa = empresa; //tr.Trazas("13");
                _Form_CuentaEfectivoReport._sucursalId = sucursalId; //tr.Trazas("14");
                _Form_CuentaEfectivoReport._sucursal = sucursal; //tr.Trazas("15");
                _Form_CuentaEfectivoReport.periodoId = periodoId; //tr.Trazas("16");
                //_Form_CuentaEfectivoReport.Height = this.Height;
                //_Form_CuentaEfectivoReport.Width = (Int32)(this.Width * 0.90);
                _Form_CuentaEfectivoReport.Show(); //tr.Trazas("finmnnnnnn");
            }



        }
        catch(Exception ex)
        {
            //tr.Trazas("erroreeeeeeeee");
          //RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
            MessageBox.Show(ex.ToString());
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }
    private void btnHuespedes_Click(object sender, EventArgs e)
    {
        string valormes = (cboMeses.SelectedIndex + 1).ToString();
        string f = "01/" + valormes + "/" + periodoId;
        DateTime f1 = Convert.ToDateTime(f);
        DateTime f2;
        if (f1.Month + 1 < 13)
        { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
        else
        { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }
      DateTime fechaInicio = f1;
      DateTime fechaFin = f2;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);

      if (fechaFin >= fechaInicio)
      {
        try
        {
          //reports.rptHuespedes _rptHuespedes = new reports.rptHuespedes();
          ////pase 11
          //_rptHuespedes.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //_rptHuespedes.SetParameterValue("@MonedaID", monedaId);
          //_rptHuespedes.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //_rptHuespedes.SetParameterValue("@Hasta", fechaFin.ToShortDateString());

          //_rptHuespedes.SetParameterValue("name_report", "Registro de Huespedes");
          //_rptHuespedes.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //_rptHuespedes.SetParameterValue("currency", "Expresado en " + cbxMoneda.Text);
          //_rptHuespedes.SetParameterValue("empresa", empresa);
          //_rptHuespedes.SetParameterValue("periodo", periodoId);
          //_rptHuespedes.SetParameterValue("ruc", rucParam);
          //_rptHuespedes.SetParameterValue("address", direccParam);
          //crvLibros.ReportSource = _rptHuespedes;

          //Nuevo reporte
          Form_HuespedesReport _Form_HuespedesRepo = new Form_HuespedesReport();
          _Form_HuespedesRepo.fechaInicio = f1;
          _Form_HuespedesRepo.fechaFin = f2;
          _Form_HuespedesRepo.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
          _Form_HuespedesRepo.checkExcel = checkExcel.Checked;
          _Form_HuespedesRepo.monedaNom = cbxMoneda.Text;
          _Form_HuespedesRepo.rucParam = rucParam;
          _Form_HuespedesRepo.direccParam = direccParam;
          _Form_HuespedesRepo.empresaId = empresaId;
          _Form_HuespedesRepo.empresa = empresa;
          _Form_HuespedesRepo._sucursalId = sucursalId;
          _Form_HuespedesRepo._sucursal = sucursal;
          _Form_HuespedesRepo.periodoId = periodoId;
          //_Form_HuespedesRepo.Height = this.Height;
          //_Form_HuespedesRepo.Width = (Int32)(this.Width * 0.90);
          _Form_HuespedesRepo.Show();
        }
        catch
        {
          RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }
    private void btnInventario_Click(object sender, EventArgs e)
    {
        string valormes = (cboMeses.SelectedIndex + 1).ToString();
        string f = "01/" + valormes + "/" + periodoId;
        DateTime f1 = Convert.ToDateTime(f);
        DateTime f2;
        if (f1.Month + 1 < 13)
        { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
        else
        { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }

      DateTime fechaInicio = f1;
      DateTime fechaFin = f2;
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);

      if (fechaFin >= fechaInicio)
      {
        try
        {
          //reports.rptInventarioPermanente _rptInventario = new reports.rptInventarioPermanente();
          ////pase 12
          //_rptInventario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

          //_rptInventario.SetParameterValue("@InicioMes", fechaInicio.ToShortDateString());
          //_rptInventario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
          //_rptInventario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
          //_rptInventario.SetParameterValue("@AlmacenID", Convert.ToInt32(cbxAlmacen.SelectedValue));

          //_rptInventario.SetParameterValue("name_report", "Registro de Inventario Permanente Valorizado");
          //_rptInventario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
          //_rptInventario.SetParameterValue("empresa", empresa);
          //_rptInventario.SetParameterValue("periodo", periodoId);
          //_rptInventario.SetParameterValue("ruc", rucParam);
          //_rptInventario.SetParameterValue("address", direccParam);
          //crvLibros.ReportSource = _rptInventario;
            //Nuevo reporte
          Form_InventarioReport _Form_InventarioRepo = new Form_InventarioReport();
          _Form_InventarioRepo.fechaInicio = f1;
          _Form_InventarioRepo.fechaFin = f2;
          _Form_InventarioRepo.monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
          _Form_InventarioRepo.checkExcel = checkExcel.Checked;
          _Form_InventarioRepo.monedaNom = cbxMoneda.Text;
          _Form_InventarioRepo.rucParam = rucParam;
          _Form_InventarioRepo.direccParam = direccParam;
          _Form_InventarioRepo.empresaId = empresaId;
          _Form_InventarioRepo.empresa = empresa;
          _Form_InventarioRepo._sucursalId = sucursalId;
          _Form_InventarioRepo._sucursal = sucursal;
          _Form_InventarioRepo.AlmacenId = Convert.ToInt32(cbxAlmacen.SelectedValue);
          _Form_InventarioRepo.periodoId = periodoId;
          //_Form_InventarioRepo.Height = this.Height;
          //_Form_InventarioRepo.Width = (Int32)(this.Width * 0.90);
          _Form_InventarioRepo.Show();
        }
        catch
        {
          RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
      }
      else
      {
        RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }

    

    
  }
}
