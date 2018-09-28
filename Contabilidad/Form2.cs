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

namespace Contabilidad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(Class1.nombreReportePLE.ToString()=="registroventassunat"){
                ReportDocument rpt = new ReportDocument();
                rpt.Load("/reports/RegistroVentasPLE.rpt");
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.RefreshReport();
            }
                
            this.crystalReportViewer1.RefreshReport();
           
        }
    }
}
