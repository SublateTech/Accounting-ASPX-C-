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
using System.Globalization;

namespace Contabilidad
{
    public partial class Form_DiarioResumidoReport : Form
    {
        BLComprobador objCnx = new BLComprobador();
        public DateTime fechaInicio; 
        public DateTime fechaFin;
        public Int32 monedaId;
        public Boolean checkExcel;
        public String monedaNom;
        public String rucParam;
        public String direccParam;
        public Int32 empresaId;
        public String empresa;
        public Int32 _sucursalId;
        public String _sucursal;
        public Int32 periodoId;
        private BLMoneda objBLMoneda;
        private BLAlmacen objBLAlmacen;

        public Form_DiarioResumidoReport()
        {
            InitializeComponent();
            objBLMoneda = new BLMoneda();
            objBLAlmacen = new BLAlmacen();
        }

        private void Form_DiarioResumidoReport_Load(object sender, EventArgs e)
        {
            if (fechaFin >= fechaInicio)
            {
                try
                {
                    if (checkExcel == true)
                    {
                        reports.rptLibroDiarioExcel _rptLibroDiario = new reports.rptLibroDiarioExcel();
                        _rptLibroDiario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                        _rptLibroDiario.SetParameterValue("@MonedaID", monedaId);
                        _rptLibroDiario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("@Detallado", 0);
                        _rptLibroDiario.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroDiario.SetParameterValue("@Ejercicio", periodoId);
                        _rptLibroDiario.SetParameterValue("name_report", "Libro Diario");
                        _rptLibroDiario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("currency", "Expresado en " + monedaNom);
                        _rptLibroDiario.SetParameterValue("empresa", empresa);
                        _rptLibroDiario.SetParameterValue("periodo", periodoId);
                        _rptLibroDiario.SetParameterValue("ruc", rucParam);
                        _rptLibroDiario.SetParameterValue("address", direccParam);
                        _rptLibroDiario.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape; 
                        crvLibros.ReportSource = _rptLibroDiario;
                    }
                    else
                    {
                        String Mes = "";
                        Mes = MonthName(fechaInicio.Month).ToUpper();
                        reports.rptLibroDiario _rptLibroDiario = new reports.rptLibroDiario();
                        _rptLibroDiario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                        _rptLibroDiario.SetParameterValue("@MonedaID", monedaId);

                        _rptLibroDiario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("@Detallado", 0);

                       

                        _rptLibroDiario.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroDiario.SetParameterValue("@Ejercicio", periodoId);
                        _rptLibroDiario.SetParameterValue("name_report", "FORMATO 5.1: LIBRO DIARIO");
                        _rptLibroDiario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("currency", "EXPRESADO EN " + monedaNom.ToUpper());
                        _rptLibroDiario.SetParameterValue("empresa", empresa.ToUpper());
                        _rptLibroDiario.SetParameterValue("periodo", "EJERCICIO: " + periodoId + " - " + Mes);
                        _rptLibroDiario.SetParameterValue("ruc", "RUC: " + rucParam);
                        _rptLibroDiario.SetParameterValue("address", direccParam.ToUpper());
                        _rptLibroDiario.SetParameterValue("Fecha", "FECHA:  " + DateTime.Now.ToShortDateString());
                        _rptLibroDiario.SetParameterValue("Hora",  "HORA :  " + DateTime.Now.ToShortTimeString());
                        _rptLibroDiario.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape; 
                        crvLibros.ReportSource = _rptLibroDiario;
                    }
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
        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
    }
}
