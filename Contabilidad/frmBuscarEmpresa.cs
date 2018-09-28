using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using System.Configuration;

namespace Contabilidad
{
    public partial class frmBuscarEmpresa : Form
    {

        public string pRUCEmpresa;

        public string _EmpresaID;

        public bool cancelo_formulario = false;

        private BLEmpresa objEmpresas;

        public frmBuscarEmpresa()
        {
            InitializeComponent();

            objEmpresas = new BLEmpresa();

        }

        private void frmBuscarEmpresa_Load(object sender, EventArgs e)
        {
            txtBuscar.Text = pRUCEmpresa.Trim();
            cancelo_formulario = false;
            dgvEmpresas.Focus();
        }

        private void frmBuscarCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            //DoSomething();
            if (e.KeyCode == Keys.F5)
            {
                txtBuscar.Focus();
            }
            if (e.KeyCode == Keys.F6)
            {
                btnSeleccionar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }


        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count == 1)
            {
                pRUCEmpresa = dgvEmpresas.SelectedRows[0].Cells["ruc"].Value.ToString();

                _EmpresaID = dgvEmpresas.SelectedRows[0].Cells["empresaid"].Value.ToString();

                iForm miInterfaz = this.Owner as iForm;

                if (miInterfaz != null)
                {
                    miInterfaz.cambiarTextoRUC(pRUCEmpresa);
                }
                //frmRegistroAsientos forma = (frmRegistroAsientos)this.Parent;
                //(frmRegistroAsientos)this.Parent.pCodigoCuenta = pCodigoCuenta;
            }
            cancelo_formulario = false;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //buscar cuenta

            Int32 maxRecords = 0;

            maxRecords = Convert.ToInt32(ConfigurationManager.AppSettings["maxRecordsEmpresa"]);

            dgvEmpresas.DataSource = objEmpresas.getEmpresa(txtBuscar.Text, maxRecords);

            dgvEmpresas.Columns["empresaid"].Visible = false;

            dgvEmpresas.Columns["ruc"].Visible = true;

            dgvEmpresas.Columns["ruc"].ReadOnly = true;
            
            dgvEmpresas.Columns["razonsocial"].ReadOnly = true;

            dgvEmpresas.RowHeadersWidth = 10;

            dgvEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvEmpresas.ReadOnly = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count == 1)
            {
                pRUCEmpresa = dgvEmpresas.SelectedRows[0].Cells["ruc"].Value.ToString();
                _EmpresaID = dgvEmpresas.SelectedRows[0].Cells["empresaid"].Value.ToString();
            }
        }

        private void dgvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count == 1)
            {
                pRUCEmpresa = dgvEmpresas.SelectedRows[0].Cells["ruc"].Value.ToString();
                _EmpresaID = dgvEmpresas.SelectedRows[0].Cells["empresaid"].Value.ToString();

                iForm miInterfaz = this.Owner as iForm;
                if (miInterfaz != null)
                {
                    miInterfaz.cambiarTextoRUC(pRUCEmpresa);
                }
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelo_formulario = true;
            this.Close();
        }


    }
}
