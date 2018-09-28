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
    public partial class Form_CuentaEfectivoReporta3 : Form
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

        public Form_CuentaEfectivoReporta3()
        {
            InitializeComponent();
        }

        private void Form_CuentaEfectivoReporta3_Load(object sender, EventArgs e)
        {
            Traza tr = new Traza();
            if (fechaFin >= fechaInicio)
            {
                try
                {
                    if (checkExcel == true)
                    {
                        reports.rptLibroBancosExcel _rptLibroBancos = new reports.rptLibroBancosExcel();
                        //pase 09
                        _rptLibroBancos.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

                        _rptLibroBancos.SetParameterValue("@MonedaID", monedaId);
                        _rptLibroBancos.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroBancos.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroBancos.SetParameterValue("@Detallado", 1);
                        _rptLibroBancos.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroBancos.SetParameterValue("@Ejercicio", periodoId);
                        //_rptLibroBancos.SetParameterValue("@EstablecimientoID", sucursalId);
                        _rptLibroBancos.SetParameterValue("@EstablecimientoID", empresaId);
                        _rptLibroBancos.SetParameterValue("name_report", "Libro Caja y Bancos(Mov Cta Efectivo)");
                        _rptLibroBancos.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroBancos.SetParameterValue("currency", "Expresado en " + monedaNom);
                        _rptLibroBancos.SetParameterValue("empresa", empresa);
                        _rptLibroBancos.SetParameterValue("periodo", periodoId);
                        _rptLibroBancos.SetParameterValue("ruc", rucParam);
                        _rptLibroBancos.SetParameterValue("address", direccParam);
                        crvLibros.ReportSource = _rptLibroBancos;
                    }
                    else
                    {
                        String Mes = "";
                        //tr.Trazas("a");
                        Mes = MonthName(fechaInicio.Month).ToUpper();
                        //tr.Trazas("b");
                        reports.rptLibroBancosa3 _rptLibroBancos = new reports.rptLibroBancosa3();
                        //tr.Trazas("c");
                        _rptLibroBancos.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                        //tr.Trazas("d");
                        _rptLibroBancos.SetParameterValue("@MonedaID", monedaId);
                        //tr.Trazas("e");
                        // _rptLibroBancos.SetParameterValue("@FormatoCuentaCorriente", 2);
                        _rptLibroBancos.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        //tr.Trazas("f");
                        _rptLibroBancos.SetParameterValue("@Hasta", fechaFin.ToShortDateString()); //tr.Trazas("g");
                        _rptLibroBancos.SetParameterValue("@Detallado", 1); //tr.Trazas("h");
                        _rptLibroBancos.SetParameterValue("@EmpresaID", empresaId); //tr.Trazas("i");
                        _rptLibroBancos.SetParameterValue("@Ejercicio", periodoId); //tr.Trazas("j");
                        //_rptLibroBancos.SetParameterValue("@EstablecimientoID", sucursalId);
                        _rptLibroBancos.SetParameterValue("@EstablecimientoID", empresaId); //tr.Trazas("k");
                        _rptLibroBancos.SetParameterValue("name_report", "FORMATO 01.01 LIBRO CAJA Y BANCOS DETALLE DE LOS MOVIMIENTOS DEL EFECTIVO");
                        _rptLibroBancos.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString()); //tr.Trazas("l");
                        _rptLibroBancos.SetParameterValue("currency", "EXPRESADO EN " + monedaNom.ToUpper()); //tr.Trazas("m");
                        _rptLibroBancos.SetParameterValue("empresa", empresa.ToUpper());// tr.Trazas("n");
                        _rptLibroBancos.SetParameterValue("periodo", "EJERCICIO:" + periodoId + " - " + Mes); //tr.Trazas("o");
                        _rptLibroBancos.SetParameterValue("ruc", "RUC:" + rucParam); //tr.Trazas("p");
                        _rptLibroBancos.SetParameterValue("address", direccParam.ToUpper()); //tr.Trazas("q");
                        _rptLibroBancos.SetParameterValue("Fecha", "FECHA:  " + DateTime.Now.ToShortDateString()); //tr.Trazas("r");
                        _rptLibroBancos.SetParameterValue("Hora", "HORA :  " + DateTime.Now.ToShortTimeString()); //tr.Trazas("s");
                        crvLibros.ReportSource = _rptLibroBancos; //tr.Trazas("t");
                    }
                }
                catch
                {
                    //tr.Trazas("error2");
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
