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
    public partial class frmValidaCompraSunat : Form
    {
        private BLComprasSunat objBLComprasSunat;

        public frmValidaCompraSunat()
        {
            InitializeComponent();
            objBLComprasSunat = new BLComprasSunat();
        }

        private void frmValidaCompraSunat_Load(object sender, EventArgs e)
        {
            this.radGridValidaCompraSunat.DataSource = objBLComprasSunat.getValidacompras(1092014, 0, 30092014, 1);
            this.formatDatagrid();
        }

        public void formatDatagrid()
        {
            this.radGridValidaCompraSunat.Columns["Periodo"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Correlativo"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["correlativoAsientoContable"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["correlativoAsientoContable"].HeaderText = "CUO";
            this.radGridValidaCompraSunat.Columns["correlativoAsientoContable"].Width = 100;
            this.radGridValidaCompraSunat.Columns["GASTO"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Fecha"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Fecha"].Width = 80;
            this.radGridValidaCompraSunat.Columns["FechaVencimiento"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["FechaVencimiento"].HeaderText = "F. Vencimien.";
            this.radGridValidaCompraSunat.Columns["FechaVencimiento"].Width = 80;
            this.radGridValidaCompraSunat.Columns["Tipo"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Serie"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo07"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo07"].HeaderText = "Campo 08";
            this.radGridValidaCompraSunat.Columns["Numero"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo09"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo09"].HeaderText = "Campo 10";
            this.radGridValidaCompraSunat.Columns["TipoDocumentoIdProveedor"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["TipoDocumentoIdProveedor"].HeaderText = "Tipo Doc.";
            this.radGridValidaCompraSunat.Columns["Ruc"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Ruc"].Width = 100;
            this.radGridValidaCompraSunat.Columns["NombreEmpresa"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["NombreEmpresa"].HeaderText = "Empresa";
            this.radGridValidaCompraSunat.Columns["NombreEmpresa"].Width = 200;
            this.radGridValidaCompraSunat.Columns["BaseImponibleB"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["BaseImponibleB"].HeaderText = "Base Imponible";
            this.radGridValidaCompraSunat.Columns["BaseImponibleB"].Width = 100;
            this.radGridValidaCompraSunat.Columns["IGVB"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["IGVB"].HeaderText = "IGV";
            this.radGridValidaCompraSunat.Columns["Campo15"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo15"].HeaderText = "Campo 16";
            this.radGridValidaCompraSunat.Columns["Campo16"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo16"].HeaderText = "Campo 17";
            this.radGridValidaCompraSunat.Columns["Campo17"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo17"].HeaderText = "Campo 18";
            this.radGridValidaCompraSunat.Columns["Campo18"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo18"].HeaderText = "Campo 19";
            this.radGridValidaCompraSunat.Columns["Campo19"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo19"].HeaderText = "Campo 20";
            this.radGridValidaCompraSunat.Columns["ISC"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Otros"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Total"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["TipoCambio"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["TipoCambio"].HeaderText = "T.C.";
            this.radGridValidaCompraSunat.Columns["Campo24"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo24"].HeaderText = "Campo 25";
            this.radGridValidaCompraSunat.Columns["Campo24"].Width = 80;
            this.radGridValidaCompraSunat.Columns["Campo25"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo25"].HeaderText = "Campo 26";
            this.radGridValidaCompraSunat.Columns["Campo25"].Width = 70;
            this.radGridValidaCompraSunat.Columns["Campo26"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Campo26"].HeaderText = "Campo 27";
            this.radGridValidaCompraSunat.Columns["codigoDependenciaAduanera"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Campo27"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo27"].HeaderText = "Campo 29";
            this.radGridValidaCompraSunat.Columns["Campo27"].Width = 70;
            this.radGridValidaCompraSunat.Columns["Campo28"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo28"].HeaderText = "Campo 30";
            this.radGridValidaCompraSunat.Columns["Campo28"].Width = 70;
            this.radGridValidaCompraSunat.Columns["Campo29"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo29"].HeaderText = "Campo 31";
            this.radGridValidaCompraSunat.Columns["Campo29"].Width = 80;
            this.radGridValidaCompraSunat.Columns["Campo30"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo30"].HeaderText = "Campo 32";
            this.radGridValidaCompraSunat.Columns["Campo31"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo31"].HeaderText = "Campo 33";
            this.radGridValidaCompraSunat.Columns["Campo32"].IsVisible = true;
            this.radGridValidaCompraSunat.Columns["Campo32"].HeaderText = "Estado";
            this.radGridValidaCompraSunat.Columns["BoletaVenta"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Referencia"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Entrada"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["NombreDocumento"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Detraccion"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["FechaDetraccion"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["estado"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["numeroComprobanteModificado"].IsVisible = false;
            this.radGridValidaCompraSunat.Columns["Mcorrelativo"].IsVisible = false;
            this.radGridValidaCompraSunat.Refresh();
        }

    }
}
