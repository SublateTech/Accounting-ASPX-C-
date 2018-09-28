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
  public partial class frmEmpresa : Form
  {
    private BLEmpresa objBLEmpresa;
    public frmEmpresa()
    {
      InitializeComponent();
      objBLEmpresa = new BLEmpresa();
    }
    public string ruc { get; set; }
    private void frmEmpresa_Load(object sender, EventArgs e)
    {
      this.dgvEmpresas.DataSource = objBLEmpresa.getEmpresa(0,"","");
      this.formatDatagrid();
    }
    public void formatDatagrid()
    {
      this.dgvEmpresas.Columns["razonsocial"].Width = 200;
      this.dgvEmpresas.Columns["direccion"].Visible = false;
      this.dgvEmpresas.Columns["direccion"].Visible = false;
      this.dgvEmpresas.Columns["email"].Visible = false;
      this.dgvEmpresas.Columns["telefono2"].Visible = false;
      this.dgvEmpresas.Columns["telefono1"].Visible = false;
      this.dgvEmpresas.Columns["NivelId"].Visible = false;
      this.dgvEmpresas.Columns["UltimaVisita"].Visible = false;
      this.dgvEmpresas.Columns["TipoId"].Visible = false;
      this.dgvEmpresas.Columns["ResponsableId"].Visible = false;
      this.dgvEmpresas.Columns["CategoriaId"].Visible = false;
      this.dgvEmpresas.Columns["ActividadId"].Visible = false;
      this.dgvEmpresas.Columns["Aniversario"].Visible = false;
      this.dgvEmpresas.Columns["distritoid"].Visible = false;
      this.dgvEmpresas.Columns["empresaid"].Visible = false;
      this.dgvEmpresas.Columns["NombreNivel"].Visible = false;
      this.dgvEmpresas.Columns["nombreactividad"].Visible = false;
      this.dgvEmpresas.Columns["nombreresponsable"].Visible = false;
      this.dgvEmpresas.Refresh();
    }

    private void dgvEmpresas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewCell viewcell = dgvEmpresas.CurrentCell;
      ruc=Convert.ToString(dgvEmpresas["ruc", viewcell.RowIndex].Value);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
    public void dgvEmpresas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCell viewcell = dgvEmpresas.CurrentCell;
      ruc=Convert.ToString(dgvEmpresas["ruc", viewcell.RowIndex].Value);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
    private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13) {
        this.loadDatagrid();
      }
    }
    private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        this.loadDatagrid();
      }
    }
    private void txtCategoriaId_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        this.loadDatagrid();
      }
    }
    public void loadDatagrid()
    
    {
      Int32 categoriaId = 0;
      if (!string.IsNullOrEmpty(txtCategoriaId.Text)) { 
        categoriaId=Convert.ToInt32(txtCategoriaId.Text.Trim());
      }
      this.dgvEmpresas.DataSource = objBLEmpresa.getEmpresa(categoriaId, txtRazonSocial.Text, txtRuc.Text);
      this.formatDatagrid();
    }
    public void dgvEmpresas_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 13)
      {
        DataGridViewCell viewcell = dgvEmpresas.CurrentCell;
        ruc = Convert.ToString(dgvEmpresas["ruc", viewcell.RowIndex-1].Value);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}
