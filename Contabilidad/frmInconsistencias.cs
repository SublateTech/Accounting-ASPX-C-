using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class frmInconsistencias : Form
    {

        DataSet datos;

        public frmInconsistencias(DataSet _datos)
        {
            InitializeComponent();
            datos = _datos;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInconsistencias_Load(object sender, EventArgs e)
        {
            dgvInconsistencias.DataSource = datos.Tables[0];
            //formatear datagrid
            dgvInconsistencias.Refresh();
            //
            dgvInconsistencias.Columns["AsientoContableID"].Visible = false;
            dgvInconsistencias.Columns["NombreSubDiario"].HeaderText = "SubDiario";
            dgvInconsistencias.Columns["CodigoPlanCuenta"].HeaderText = "Cuenta";
            dgvInconsistencias.Columns["NumeroDocumento"].HeaderText = "Documento";
            dgvInconsistencias.Columns["MontoDebe"].HeaderText = "Debe";
            dgvInconsistencias.Columns["MontoHaber"].HeaderText = "Haber";
            dgvInconsistencias.Columns["MontoDebe"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;
            dgvInconsistencias.Columns["MontoHaber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInconsistencias.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInconsistencias.Columns["NombreArea"].HeaderText = "Área";
            dgvInconsistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvInconsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reporte de inconsistencias
            rptInconsistencias reporte = new rptInconsistencias();
            reporte.SetDataSource(datos);
            frmReporte mostrador = new frmReporte(reporte);
            mostrador.ShowDialog();
        }
    }
}
