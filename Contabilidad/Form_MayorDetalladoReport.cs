using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using AD;
using Telerik.WinControls;
using System.Globalization;

namespace Contabilidad
{
    public partial class Form_MayorDetalladoReport : Form
    {
        BLComprobador objCnx = new BLComprobador();
        public DateTime fechaInicio;
        public DateTime fechaFin;
        public Int32 monedaId;
        public Boolean checkExcel;
        public Boolean checkVertical;
        public String monedaNom;
        public String rucParam;
        public String direccParam;
        public Int32 empresaId;
        public String empresa;
        public Int32 _sucursalId;
        public String _sucursal;
        public Int32 periodoId;
        public Form_MayorDetalladoReport()
        {
            InitializeComponent();
        }

        private void Form_MayorDetalladoReport_Load(object sender, EventArgs e)
        {
            if (fechaFin >= fechaInicio)
            {
                try
                {
                    if (checkExcel == true)
                    {
                        reports.rptLibroMayorExcel _rptLibroMayor = new reports.rptLibroMayorExcel();
                        //pase 05
                        _rptLibroMayor.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

                        _rptLibroMayor.SetParameterValue("@MonedaID", monedaId);
                        _rptLibroMayor.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("@Detallado", 1);
                        _rptLibroMayor.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroMayor.SetParameterValue("@Ejercicio", periodoId);
                        _rptLibroMayor.SetParameterValue("@EstablecimientoID", _sucursalId);
                        _rptLibroMayor.SetParameterValue("name_report", "FORMATO 06.01 : LIBRO MAYOR");
                        _rptLibroMayor.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("currency", "Expresado en " + monedaNom);
                        _rptLibroMayor.SetParameterValue("empresa", empresa);
                        _rptLibroMayor.SetParameterValue("periodo", periodoId);
                        _rptLibroMayor.SetParameterValue("ruc", rucParam);
                        _rptLibroMayor.SetParameterValue("address", direccParam);
                        _rptLibroMayor.SetParameterValue("Fecha", "FECHA:" + DateTime.Now.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("Hora", "HORA:" + DateTime.Now.ToShortTimeString());
                        crvLibros.ReportSource = _rptLibroMayor;
                    }
                    else
                    {
                        String Mes = "";
                        Mes = MonthName(fechaInicio.Month).ToUpper();
                        //reports.rptLibroMayor _rptLibroMayor = new reports.rptLibroMayor();

                        CrystalDecisions.CrystalReports.Engine.ReportClass _rptLibroMayor;
                        if (checkVertical)
                            _rptLibroMayor = new reports.rptLibroMayorVert();
                        else
                            _rptLibroMayor = new reports.rptLibroMayor();


                        //pase 06
                        _rptLibroMayor.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

                        _rptLibroMayor.SetParameterValue("@MonedaID", monedaId);
                        _rptLibroMayor.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("@Detallado", 1);
                        _rptLibroMayor.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroMayor.SetParameterValue("@Ejercicio", periodoId);
                        _rptLibroMayor.SetParameterValue("@EstablecimientoID", _sucursalId);
                        _rptLibroMayor.SetParameterValue("name_report", "FORMATO 06.01 : LIBRO MAYOR");
                        _rptLibroMayor.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("currency", "EXPRESADO EN " + monedaNom.ToUpper());
                        _rptLibroMayor.SetParameterValue("empresa", empresa.ToUpper());
                        _rptLibroMayor.SetParameterValue("periodo", "EJERCICIO: " + periodoId + " - " + Mes);
                        _rptLibroMayor.SetParameterValue("ruc", "RUC: " + rucParam);
                        _rptLibroMayor.SetParameterValue("address", direccParam.ToUpper());
                        _rptLibroMayor.SetParameterValue("Fecha", "FECHA:  " + DateTime.Now.ToShortDateString());
                        _rptLibroMayor.SetParameterValue("Hora", "HORA :  " + DateTime.Now.ToShortTimeString());
                        crvLibros.ReportSource = _rptLibroMayor;
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
