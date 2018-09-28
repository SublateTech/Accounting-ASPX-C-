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
    public partial class Form_InventarioReport : Form
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
        public Int32 AlmacenId;

        public Form_InventarioReport()
        {
            InitializeComponent();
        }

        private void Form_InventarioReport_Load(object sender, EventArgs e)
        {
            if (fechaFin >= fechaInicio)
            {
                try
                {
                    reports.rptInventarioPermanente _rptInventario = new reports.rptInventarioPermanente();
                    //pase 12
                    _rptInventario.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());

                    _rptInventario.SetParameterValue("@InicioMes", fechaInicio.ToShortDateString());
                    _rptInventario.SetParameterValue("@Desde", fechaInicio.ToShortDateString());
                    _rptInventario.SetParameterValue("@Hasta", fechaFin.ToShortDateString());
                    _rptInventario.SetParameterValue("@AlmacenID", Convert.ToInt32(AlmacenId));

                    _rptInventario.SetParameterValue("name_report", "Registro de Inventario Permanente Valorizado");
                    _rptInventario.SetParameterValue("date_range", fechaInicio.ToShortDateString() + " - " + fechaFin.ToShortDateString());
                    _rptInventario.SetParameterValue("empresa", empresa);
                    _rptInventario.SetParameterValue("periodo", periodoId);
                    _rptInventario.SetParameterValue("ruc", rucParam);
                    _rptInventario.SetParameterValue("address", direccParam);
                    crvLibros.ReportSource = _rptInventario;
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
