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
    public partial class TransferInforme : Form
    {
        DataTable dt1 = new DataTable();
        public TransferInforme()
        {
            InitializeComponent();
        }

        public TransferInforme(DataTable dt)
        {
            InitializeComponent();
            dt1 = dt;      
        }

        private void TransferInforme_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt1;
            //dataGridView1.Columns["Referencia"].Width=400;//
        // dataGridView1.Columns["Referencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    // dataGridView1.Columns["ddd"].Width
            dataGridView1.Columns["ID"].Visible = false;//
            dataGridView1.Columns["ProcesoID"].Visible = false;//
        }

       
    }
}
