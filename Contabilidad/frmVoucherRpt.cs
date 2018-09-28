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

namespace Contabilidad
{
  public partial class frmVoucherRpt : Form
  {
    private String subdiarioId;
    private String asientoContableId;
    private Int32 monedaId;
    private String moneda;
    private DateTime desde;
    private DateTime hasta;
    private String empresa;
    private Int32 periodoId;
    private string RS;

    public frmVoucherRpt(String _subdiarioId, String _asientoContableId, Int32 _monedaId, String _moneda, DateTime _desde, DateTime _hasta, String _empresa, Int32 _periodoId,string Empresa_)
    {
      InitializeComponent();
      subdiarioId = _subdiarioId;
      asientoContableId = _asientoContableId;
      monedaId = _monedaId;
      desde = _desde;
      hasta = _hasta;
      moneda = _moneda;
      empresa = _empresa;
      periodoId = _periodoId;
      RS = Empresa_;
    }

    private void frmVoucherRpt_Load(object sender, EventArgs e)
    {
      try
      {
          reports.rptVoucher_2 _rptVoucher = new reports.rptVoucher_2();
          BL.BLComprobador objCnx=new BL.BLComprobador();
          _rptVoucher.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

        


        _rptVoucher.SetParameterValue("@SubdiarioID", subdiarioId);
        _rptVoucher.SetParameterValue("@AsientoContableID", asientoContableId);
        _rptVoucher.SetParameterValue("@MonedaID", monedaId);
        _rptVoucher.SetParameterValue("@Desde", desde.ToShortDateString());
        _rptVoucher.SetParameterValue("@Hasta", hasta.ToShortDateString());
        _rptVoucher.SetParameterValue("@EmpresaID",empresa);
        _rptVoucher.SetParameterValue("@Ejercicio", periodoId);

        _rptVoucher.SetParameterValue("name_report", "Voucher de Diario");
        _rptVoucher.SetParameterValue("date_range", desde.ToShortDateString() + " - " + hasta.ToShortDateString());
        _rptVoucher.SetParameterValue("currency", "Expresado en " + moneda);
        _rptVoucher.SetParameterValue("empresa", RS);
        _rptVoucher.SetParameterValue("periodo", periodoId);
        _rptVoucher.SetParameterValue("ruc", "20303368877");
        _rptVoucher.SetParameterValue("address", "Av. Guardia Civil #727 San Borja");

        crvVoucher.ReportSource = _rptVoucher;
      }
      catch
      {
        RadMessageBox.Show("Ha ocurrido un error inesperado", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
      }
    }

    private void crvVoucher_Load(object sender, EventArgs e)
    {

    }

    private void crvVoucher_Load_1(object sender, EventArgs e)
    {

    }
  }
}
