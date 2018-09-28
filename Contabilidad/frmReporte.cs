using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;
using Telerik.WinControls;



namespace Contabilidad

{
    public partial class frmReporte : Form
    {

        private Int32 monedaIDEmision;
        private Int32 monedaId;
        private String moneda;
        private DateTime desde;
        private DateTime hasta;
        private String empresa;
        private Int32 establecimientoID;
        private Int32 produccion;
        private Int32 prepagos;

        private Int32 reporteParaMostrar;
        ReportDocument documento;
        String tituloReporte;
        private DataSet datos;

        public frmReporte(ReportDocument _documento)
        {
            InitializeComponent();
            documento = _documento;

        }
        public frmReporte(Int32 _reporte)
        {
            InitializeComponent();
            reporteParaMostrar = _reporte;
        }
        public void datosReporte(DataSet _datos)
        {
            datos = _datos;
        }

        public frmReporte()
        {
            // TODO: Complete member initialization
        }

        private void crvVisor_Load(object sender, EventArgs e)
        {
            crvVisor.ReportSource = documento;
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            registroVentasSunat RventasSunat = new registroVentasSunat();
            RegistroComprasSunat RcomprasSunat = new RegistroComprasSunat();
            RegistroLibroDiarioSunat RlibroDiarioSunat = new RegistroLibroDiarioSunat();
            RegistroLibroMayorSunat RlibroMayorSunat = new RegistroLibroMayorSunat();
            

            BL.BLComprobador objCnx = new BL.BLComprobador();
           
            switch (reporteParaMostrar)
            {
                case funcionesReporte.ReporteVentasSunat:
      
                    RventasSunat = new registroVentasSunat();
                    RventasSunat.SetDataSource(datos);
                   
                    RventasSunat.SetParameterValue("@Monedaid", 1);
                    RventasSunat.SetParameterValue("@Desde", Class1.fechaDesde);
                    RventasSunat.SetParameterValue("@Hasta", Class1.fechaHasta);;
                    RventasSunat.SetParameterValue("@EstablecimientoID", 0); //establecimientoID);
                    RventasSunat.SetParameterValue("@MonedaIDEmision", 0); //monedaIDEmision);
                    RventasSunat.SetParameterValue("@Produccion", 0); //produccion);
                    RventasSunat.SetParameterValue("@Prepagos", 1); //prepagos);       
                    RventasSunat.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                    crvVisor.ReportSource = RventasSunat;
                    break;
                   

                case funcionesReporte.ReporteComprasSunat:

                    RcomprasSunat = new RegistroComprasSunat();
                    RcomprasSunat.SetDataSource(datos);

                    RcomprasSunat.SetParameterValue("@Monedaid", 1);
                    RcomprasSunat.SetParameterValue("@Desde",Class1.fechaDesde);
                    RcomprasSunat.SetParameterValue("@Hasta", Class1.fechaHasta); ;
                    RcomprasSunat.SetParameterValue("@EstablecimientoID", 0); //establecimientoID);
                    RcomprasSunat.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                    crvVisor.ReportSource = RcomprasSunat;
                    break;



                case funcionesReporte.ReporteLibroDiarioSunat:

                    RlibroDiarioSunat = new RegistroLibroDiarioSunat();
                    RlibroDiarioSunat.SetDataSource(datos);

                    
                    RlibroDiarioSunat.SetParameterValue("@Desde", Class1.fechaDesde);
                    RlibroDiarioSunat.SetParameterValue("@Hasta", Class1.fechaHasta); ;
                    
                    RlibroDiarioSunat.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                    crvVisor.ReportSource = RlibroDiarioSunat;
                    break;



                case funcionesReporte.ReporteLibroMayorSunat:

                    RlibroMayorSunat = new RegistroLibroMayorSunat();
                    RlibroMayorSunat.SetDataSource(datos);


                    RlibroMayorSunat.SetParameterValue("@Desde", Class1.fechaDesde);
                    RlibroMayorSunat.SetParameterValue("@Hasta", Class1.fechaHasta); ;

                    RlibroMayorSunat.DataSourceConnections[0].SetConnection(objCnx.server(), objCnx.database(), objCnx.user(), objCnx.password());
                    crvVisor.ReportSource = RlibroMayorSunat;
                    break;



            }
            
        }

    }
}
     
