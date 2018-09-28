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
    public partial class Form_CuentaCorrienteReport3 : Form
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
        public Int32 a3;
        public Form_CuentaCorrienteReport3()
        {
            InitializeComponent();
        }

        private void Form_CuentaCorrienteReport3_Load(object sender, EventArgs e)
        {
            if (fechaFin >= fechaInicio)
            {
                try
                {
                    if (checkExcel == true)
                    {
                        reports.rptLibroCajaCuentaCorrienteExcel _rptLibroCtaCorriente = new reports.rptLibroCajaCuentaCorrienteExcel();
                        //pase 07
                        _rptLibroCtaCorriente.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

                        _rptLibroCtaCorriente.SetParameterValue("@MonedaID", monedaId);
                        _rptLibroCtaCorriente.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("@Detallado", 0);
                        _rptLibroCtaCorriente.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroCtaCorriente.SetParameterValue("@Ejercicio", periodoId);
                        //_rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", sucursalId);
                        _rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", empresaId);
                        _rptLibroCtaCorriente.SetParameterValue("name_report", "Libro Caja y Bancos(Mov Cta Corriente)");
                        _rptLibroCtaCorriente.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("currency", "Expresado en " + monedaNom);
                        _rptLibroCtaCorriente.SetParameterValue("empresa", empresa);
                        _rptLibroCtaCorriente.SetParameterValue("periodo", periodoId);
                        _rptLibroCtaCorriente.SetParameterValue("ruc", rucParam);
                        _rptLibroCtaCorriente.SetParameterValue("address", direccParam);
                        crvLibros.ReportSource = _rptLibroCtaCorriente;
                    }
                    else
                    {
                        String Mes = "";
                        Mes = MonthName(fechaInicio.Month).ToUpper();
                        reports.rptLibroCajaCuentaCorrientea3 _rptLibroCtaCorriente = new reports.rptLibroCajaCuentaCorrientea3();
                        //pase 08
                        _rptLibroCtaCorriente.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

                        _rptLibroCtaCorriente.SetParameterValue("@MonedaID", monedaId);
                        _rptLibroCtaCorriente.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("@Detallado", 0);
                        _rptLibroCtaCorriente.SetParameterValue("@EmpresaID", empresaId);
                        _rptLibroCtaCorriente.SetParameterValue("@Ejercicio", periodoId);
                        //_rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", sucursalId);
                        _rptLibroCtaCorriente.SetParameterValue("@EstablecimientoID", empresaId);
                        _rptLibroCtaCorriente.SetParameterValue("name_report", "FORMATO 01.02 LIBRO CAJA Y BANCOS DETALLE DE LOS MOVIMIENTOS DE LA CUENTA CORRIENTE");
                        _rptLibroCtaCorriente.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("currency", "EXPRESADO EN " + monedaNom.ToUpper());
                        _rptLibroCtaCorriente.SetParameterValue("empresa", empresa.ToUpper());
                        _rptLibroCtaCorriente.SetParameterValue("periodo", "EJERCICIO: " + periodoId + " - " + Mes);
                        _rptLibroCtaCorriente.SetParameterValue("ruc", "RUC: " + rucParam);
                        _rptLibroCtaCorriente.SetParameterValue("address", direccParam.ToUpper());
                        _rptLibroCtaCorriente.SetParameterValue("Fecha", "FECHA:  " + DateTime.Now.ToShortDateString());
                        _rptLibroCtaCorriente.SetParameterValue("Hora", "HORA :  " + DateTime.Now.ToShortTimeString());

                        
                        // _rptLibroCtaCorriente.PrintOptions.PaperSize("", 10, 10);
                        crvLibros.ReportSource = _rptLibroCtaCorriente;



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
