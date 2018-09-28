using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace Contabilidad
{
    public partial class frmBuscarCuenta : Form
    {

        public string pCodigoCuenta;
        public string _planCuentaID;
        public bool cancelo_formulario=false;

        private BLPlanCuenta objCuentas;

        public frmBuscarCuenta()
        {
            InitializeComponent();

            objCuentas = new BLPlanCuenta();

        }

        private void frmBuscarCuenta_Load(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Text = pCodigoCuenta.Trim();
                cancelo_formulario = false;
                dgvCuentas.Focus();
                dgvCuentas.CurrentCell = dgvCuentas[0, 0];
                this.ActiveControl = dgvCuentas;
                dgvCuentas.Select();
                dgvCuentas.CurrentCell = dgvCuentas[1, 1];
            }
            catch
            {
 
            }
            
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
            if (dgvCuentas.SelectedRows.Count == 1)
            {
                pCodigoCuenta = dgvCuentas.SelectedRows[0].Cells["CodigoPlanCuenta"].Value.ToString();

                _planCuentaID = dgvCuentas.SelectedRows[0].Cells["PlanCuentaId"].Value.ToString();

                iForm miInterfaz = this.Owner as iForm;

                if (miInterfaz != null)
                {
                    miInterfaz.cambiarTexto(pCodigoCuenta);
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
            dgvCuentas.DataSource=objCuentas.getPlanCuentas(txtBuscar.Text,cDatos.EstablecimientoID);

            dgvCuentas.Columns["PlanCuentaId"].Visible = false;
            dgvCuentas.Columns["CodigoPlanCuenta"].Visible = false;
            dgvCuentas.Columns["Cuenta"].ReadOnly = true;
            dgvCuentas.RowHeadersWidth = 10;
            dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCuentas.ReadOnly = true;
            //this.ActiveControl = dgvCuentas;
            //dgvCuentas.Select();
            //dgvCuentas_CellClick(sender, null);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 1)
            {
                pCodigoCuenta = dgvCuentas.SelectedRows[0].Cells["CodigoPlanCuenta"].Value.ToString();
                _planCuentaID = dgvCuentas.SelectedRows[0].Cells["PlanCuentaId"].Value.ToString();
            }
        }

        private void dgvCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 1)
            {
                pCodigoCuenta = dgvCuentas.SelectedRows[0].Cells["CodigoPlanCuenta"].Value.ToString();
                _planCuentaID = dgvCuentas.SelectedRows[0].Cells["PlanCuentaId"].Value.ToString();

                iForm miInterfaz = this.Owner as iForm;
                if (miInterfaz != null)
                {
                    miInterfaz.cambiarTexto(pCodigoCuenta);
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
