using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BL;

namespace Contabilidad
{
    public partial class frmImportarExportar : Form
    {

        int establecimientoID = 0;

        int ejercicio = 0;

        int mes = 0;

        int subDiarioID = 0;

        BLAsientos objBLAsientos;

        DataTable datosInconsistentes;

        

        public frmImportarExportar()
        {
            InitializeComponent();

            objBLAsientos = new BLAsientos();

        }

        private string[] GetMonths(string culture)
        {
            DateTimeFormatInfo ci = new CultureInfo(culture).DateTimeFormat;
            return ci.MonthNames;
        }

        private void frmImportarExportar_Load(object sender, EventArgs e)
        {
            establecimientoID = cDatos.EstablecimientoID;

            ejercicio = cDatos.Periodo;

            /*cargar periodos (meses)*/
            string[] meses = GetMonths("es-PE");
            String[] meses2 = new String[12];
            for (int x = 0; x <= meses.Length-1; x++ )
            {
                if (meses[x] != "")
                {
                    //poner en mayusculas
                    meses2[x] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(meses[x]);

                }
            }

            cboPeriodo.DataSource = meses2;

         cbxSubDiario.DropDown +=cboMoneda_DropDown;
            
            /*cargar subdiarios*/
            DataView vistaSubDiarios = objBLAsientos.subdiarios(true).AsDataView();
            vistaSubDiarios.Sort = "NombreSubDiario";
            DataTable tablaSubDiarios = vistaSubDiarios.ToTable();
            this.cbxSubDiario.DataSource = tablaSubDiarios;
            this.cbxSubDiario.DisplayMember = "NombreSubDiario";
            this.cbxSubDiario.ValueMember = "SubDiarioID";

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            lblEspera.Visible = true;
            btnImportar.Enabled = false;
            btnExportar.Enabled = false;
            dgvInconsistencias.DataSource = null;
            try
            {
                subDiarioID = Convert.ToInt32(cbxSubDiario.SelectedValue);
            }
            catch
            {
                subDiarioID = 0;
            }

            if (subDiarioID == 0)
            {
                MessageBox.Show("Selecciona el subdiario que desea importar.");
                
                lblEspera.Visible = false;
                
                btnImportar.Enabled = true;

                btnExportar.Enabled = true;

                return;
            }

            if (cboPeriodo.Text == "")
            {

                MessageBox.Show("Selecciona el mes que desea importar.");

                lblEspera.Visible = false;

                btnImportar.Enabled = true;

                btnExportar.Enabled = true;
                
                return;
            }
            else
            {

                //se verifica las inconsistencias
                datosInconsistentes = objBLAsientos.inconsistenciasImportar(cDatos.EstablecimientoID, cDatos.Periodo, mes,subDiarioID.ToString());

                if (datosInconsistentes.Rows.Count > 0)
                {

                    MessageBox.Show("Los datos no son correctos, por favor valide las inconsistencias.");

                    dgvInconsistencias.DataSource = datosInconsistentes;

                    formatearGrid();

                    lblEspera.Visible = false;
                    btnImportar.Enabled = true;

                }

                else
                {

                    lblEspera.Visible = true;

                    mes = cboPeriodo.SelectedIndex;

                    mes = mes + 1;

                    

                    if (bgWorkerImportar.IsBusy != true)
                    {
                        bgWorkerImportar.RunWorkerAsync();
                    }
                
                }

            }

        }

        private void formatearGrid()
        {
            //formatear grid de las inconsistencias
            dgvInconsistencias.RowHeadersWidth = 10;
            dgvInconsistencias.Columns["SubDiarioID"].Visible = false;
            dgvInconsistencias.Columns["HotelID"].Visible = false;
            dgvInconsistencias.Columns["Ejercicio"].Visible = false;
            dgvInconsistencias.Columns["SubDiarioID"].Visible = false;
            dgvInconsistencias.Columns["SubDiarioID"].Visible = false;
            dgvInconsistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private string importar(int mes, int subDiarioID)
        {
            
          
                if (objBLAsientos.importarAsientos(cDatos.EstablecimientoID, cDatos.Periodo, subDiarioID.ToString(), mes, cDatos.HotelID, cDatos.UsuarioID, "", "", "") == true)
                {
                    return "La importación de asientos se realizó con éxito.";
                }
                else
                {
                    return "La importación falló.";
                }

        

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblEspera.Visible = false;
            btnImportar.Enabled = true;
            MessageBox.Show(e.Result.ToString());
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //llamar al procedimiento
            if (cboPeriodo.Text == "")
            {
                MessageBox.Show("Selecciona el mes que desea exportar.");
                return;
            }

            mes = cboPeriodo.SelectedIndex;

            mes = mes + 1;
            try
            {
                subDiarioID = Convert.ToInt32(cbxSubDiario.SelectedValue);
            }
            catch
            {
                subDiarioID = 0;
            }

            if (subDiarioID == 0)
            {
                MessageBox.Show("Selecciona el subdiario que desea exportar.");
                return;
            }

            if (objBLAsientos.exportarAsientos(cDatos.EstablecimientoID, cDatos.Periodo, mes, subDiarioID.ToString(), true) == true)
            {
                MessageBox.Show("La exportación de asientos se realizó con éxito.");
            }
            else
            {
                MessageBox.Show("La exportación de asientos falló.");
            }

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            // trabajo en segundo plano
                e.Result = importar(mes, subDiarioID);

        }

        private void cbxSubDiario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMoneda_DropDown(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;

            foreach (object item in ((ComboBox)sender).Items)
            {
                string s = senderComboBox.GetItemText(item);

                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

    }
}

