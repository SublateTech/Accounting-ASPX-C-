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

namespace Contabilidad
{
    public partial class Form_HuespedesReport : Form
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
        public Form_HuespedesReport()
        {
            InitializeComponent();
        }

        private void Form_HuespedesReport_Load(object sender, EventArgs e)
        {
            if (fechaFin >= fechaInicio)
            {
                try
                {
                    reports.rptHuespedes _rptHuespedes = new reports.rptHuespedes();
                    _rptHuespedes.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                    _rptHuespedes.SetParameterValue("@MonedaID", monedaId);
                    _rptHuespedes.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                    _rptHuespedes.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                    _rptHuespedes.SetParameterValue("name_report", "Registro de Huespedes");
                    _rptHuespedes.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                    _rptHuespedes.SetParameterValue("currency", "Expresado en " + monedaNom);
                    _rptHuespedes.SetParameterValue("empresa", empresa);
                    _rptHuespedes.SetParameterValue("periodo", periodoId);
                    _rptHuespedes.SetParameterValue("ruc", rucParam);
                    _rptHuespedes.SetParameterValue("address", direccParam);
                    crvLibros.ReportSource = _rptHuespedes;
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
