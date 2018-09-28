using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using BL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Xml.Serialization;
using AD;
using Microsoft.ApplicationBlocks.Data;
//using Microsoft.Office.Interop.Excel;

namespace Contabilidad
{
  public partial class frmAsientosList : Form
  {
    private Int32 empresaId;
    private String empresa;
    private Int32 sucursalId;
    private String sucursal;
    private Int32 periodoId;

    private BLAsientos objBLAsientos;
    private BLPlanCuenta objBLPlanCuenta;
    private BLPlanCuenta objBLPlanCuentaFin;
    private BLMoneda objBLMoneda;
    private DataTable dataTableAsientos= new DataTable();
    private int codigo_reporte = 0;

    private String planCtaIDLista = "";

    public frmAsientosList(Int32 _empresaId,String _empresa, Int32 _sucursalId,String _sucursal, Int32 _periodoId)
    {
      InitializeComponent();
      empresaId = _empresaId;
      empresa = _empresa;
      sucursalId = _sucursalId;
      sucursal = _sucursal;
      periodoId = _periodoId;

      objBLAsientos = new BLAsientos();
      objBLPlanCuenta = new BLPlanCuenta();
      objBLPlanCuentaFin = new BLPlanCuenta();
      objBLMoneda = new BLMoneda();
    }

    private void frmAsientosList_Load(object sender, EventArgs e)
    {
      //  PlanCtaChkList
                this.dtpDesde.Value = Convert.ToDateTime("01/01/" + cDatos.Periodo.ToString());
        this.dtpHasta.Value = Convert.ToDateTime("01/01/" + cDatos.Periodo.ToString());

            this.cboHotel.DataSource = getHotel(0, 0, empresaId);
            this.cboHotel.DisplayMember = "NombreHotel";
            this.cboHotel.ValueMember = "HotelID";

            this.loadPlanCuenta();
    }
    private void frmAsientosList_Resize(object sender, EventArgs e)
    {
      Point pMedio = new Point(this.Width / 2, this.Height / 2);
      gbxBusqueda.Location = new Point(pMedio.X - (gbxBusqueda.Width / 2), gbxBusqueda.Location.Y);
      //gbxComprobantes1.Location = new Point(pMedio.X - (gbxComprobantes1.Width / 2), gbxComprobantes1.Location.Y);
      pnlButton.Location = new Point(pMedio.X - (pnlButton.Width / 2), pnlButton.Location.Y);
    }
    public void loadPlanCuenta()
    {
            


     DataTable _dataTable = objBLPlanCuenta.getPlanCuentas(empresaId);
      DataTable _dataTfin = objBLPlanCuentaFin.getPlanCuentas(empresaId);
      DataTable _dataTableMoneda = objBLMoneda.getMoneda();
        
      DataColumn _dataColumn = _dataTable.Columns.Add("Concatenado", System.Type.GetType("System.String"));
      _dataColumn.Expression = "CodigoPlanCuenta+' > '+NombrePlanCuenta";

      DataColumn _dataColumnfin = _dataTfin.Columns.Add("Concatenado", System.Type.GetType("System.String"));
      _dataColumnfin.Expression = "CodigoPlanCuenta+' > '+NombrePlanCuenta";

      //DataRow fila = _dataTable.NewRow();
      //fila["CodigoPlanCuenta"] = 0;
      //_dataTable.Rows.Add(fila);
      DataView vistaDatosIni = new DataView(_dataTable, "", "CodigoPlanCuenta ASC", DataViewRowState.CurrentRows);
      //this.cbxCuentaInicial.DataSource = vistaDatosIni;
      //this.cbxCuentaInicial.DisplayMember = "Concatenado";
      //this.cbxCuentaInicial.ValueMember = "CodigoPlanCuenta";
      

      this.PlanCtaChkList.DataSource = vistaDatosIni;
      this.PlanCtaChkList.DisplayMember = "Concatenado";
      this.PlanCtaChkList.ValueMember = "CodigoPlanCuenta";

      DataRow filaMoneda = _dataTableMoneda.NewRow();
      filaMoneda["monedaid"] = 0;
      _dataTableMoneda.Rows.Add(filaMoneda);
      DataView selectMoneda = new DataView(_dataTableMoneda, "", "monedaid ASC", DataViewRowState.CurrentRows);
      this.cbxMoneda.DataSource = selectMoneda;
      this.cbxMoneda.DisplayMember = "Nombre";
      this.cbxMoneda.ValueMember = "monedaid";

      DataRow filaF = _dataTfin.NewRow();
      filaF["CodigoPlanCuenta"] = 0;
      _dataTfin.Rows.Add(filaF);
      DataView vistaDatosFin = new DataView(_dataTfin, "", "CodigoPlanCuenta ASC", DataViewRowState.CurrentRows);
      //this.cbxCuentaFinal.DataSource = vistaDatosFin;
      //this.cbxCuentaFinal.DisplayMember = "Concatenado";
      //this.cbxCuentaFinal.ValueMember = "CodigoPlanCuenta";
      this.btnSearch1.Visible = false;
    }

    public static void ExportarExcelDataTable(DataTable dt, string RutaExcel)
    {
        const string FIELDSEPARATOR = "\t";
        const string ROWSEPARATOR = "\n";
        StringBuilder output = new StringBuilder();
        // Escribir encabezados    
        foreach (DataColumn dc in dt.Columns)
        {
            output.Append(dc.ColumnName);
            output.Append(FIELDSEPARATOR);
        }
        output.Append(ROWSEPARATOR);
        foreach (DataRow item in dt.Rows)
        {
            foreach (object value in item.ItemArray)
            {
                output.Append(value.ToString().Replace('\n', ' ').Replace('\r', ' ').Replace('.', ','));
                output.Append(FIELDSEPARATOR);
            }
            // Escribir una línea de registro        
            output.Append(ROWSEPARATOR);
        }
        // Valor de retorno    
        // output.ToString();
        StreamWriter sw = new StreamWriter(RutaExcel);
        sw.Write(output.ToString());
        sw.Close();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      frmEmpresa _frmEmpresa = new frmEmpresa();
      DialogResult result= _frmEmpresa.ShowDialog();
      if (result == DialogResult.OK) {
        this.txtruc.Text=_frmEmpresa.ruc;
      }
    }

    private void radButton1_Click(object sender, EventArgs e)
    {
      MessageBox.Show(dgvAsientos.Rows.Count.ToString());
    }

    private void btnReporte_Click(object sender, EventArgs e)
    {
        ReportDocument Reporte = new ReportDocument();

        DateTime fechaInicio = this.dtpDesde.Value;
        DateTime fechaFin = this.dtpHasta.Value;

        StringBuilder texto = new StringBuilder();
        
        switch (codigo_reporte)
        {
            case 1:
                if (reportesConGrupoCHB.Checked == true)
                {
                    Reporte = new rptSaldos();
                }
                else
                {
                    Reporte = new rptSaldosSinGrupo();
                }
                
                texto.Append("'");
                texto.Append(fechaInicio.ToShortDateString());
                texto.Append(" - ");
                texto.Append(fechaFin.ToShortDateString());
                texto.Append("'");

                Reporte.DataDefinition.FormulaFields["fechas"].Text = texto.ToString();
                //limpiar stringbuilder
                texto.Length = 0;
                texto.Append("'");
                texto.Append(empresa);
                texto.Append("'");
                Reporte.DataDefinition.FormulaFields["empresa"].Text = texto.ToString();
                //limpiar stringbuilder
                texto.Length = 0;
                texto.Append("'");
                texto.Append(sucursal);
                texto.Append("'");
                Reporte.DataDefinition.FormulaFields["sucursal"].Text = texto.ToString();
                break;

        }
        //ReportDocument Reporte = new rptSaldos();
        Reporte.SetDataSource(dataTableAsientos);
                
        frmReporte pantalla = new frmReporte(Reporte);
        pantalla.ShowDialog();

    }

    private void btnHistorico_Click(object sender, EventArgs e)
    {
        //saldos historicos
        //exec UCO_EstadosCuentaSaldosProveedores @EmpresaID=2,@Ejercicio='2012',@WhereCondition=' (ACD.Dia BETWEEN ''01/01/2011''         AND ''31/01/2012'') AND (CodigoPlanCuenta BETWEEN ''42121'' AND ''42121'')  and empresas.empresaid=22759',  @OrderByExpression=' ORDER BY PlanDeCuentas.CodigoPlanCuenta, ACD.EmpresaID, ACD.TipoDocumentoID, ACD.NumeroDocumento'
        String ruc = txtruc.Text;
        DateTime fechaInicio = this.dtpDesde.Value;
        DateTime fechaFin = this.dtpHasta.Value;
        //String cuentaInicial = Convert.ToString(cbxCuentaInicial.SelectedValue);
        //String cuentaFinal = Convert.ToString(cbxCuentaFinal.SelectedValue);
        Int32 monedaC = Convert.ToInt32(this.cbxMoneda.SelectedValue);
        if (fechaFin >= fechaInicio)
        {
            dataTableAsientos.Reset();
            string s = "";
            foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
            {
                s += drv[0].ToString() + ",";
            }
            s = s.Trim().TrimEnd(',');
            dataTableAsientos = objBLAsientos.estadosCuentaSaldosHistoricos(empresaId, Convert.ToString(periodoId), fechaInicio, fechaFin, ruc, monedaC, s);
            dgvAsientos.DataSource = dataTableAsientos;
            button1.Text = dataTableAsientos.Rows.Count.ToString();
            // ExportarExcelDataTable(dataTableAsientos,"C:\\Users\\usuario\\Downloads\\reporte.xls");
            this.dgvAsientos.ReadOnly = true;
            //this.dgvAsientos.ShowGroupPanel = false;
            //this.dgvAsientos.EnableGrouping = false;
            //this.dgvAsientos.AutoSizeRows = true;
            foreach (DataGridViewColumn column in dgvAsientos.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //column.TextAlignment = ContentAlignment.MiddleCenter;
                //column.BestFit();

            }
            dgvAsientos.Refresh();
        }
        else
        {
            RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }

    }

    private void btnProcConciliacion_Click(object sender, EventArgs e)
    {
        bool existeColCheck = false;
        foreach (DataGridViewColumn columna in dgvAsientos.Columns)
        {
            if (columna.Name == "chkbox")
            {
                existeColCheck = true;
                break;
            }
        }

        if (existeColCheck == false)
        {
            return;
        }
        //INICIAR EL PROCESO DE CONCILIACION
        //LLENAR TABLA PARA LOS REGISTROS SELECCIONADOS
        DataTable dtSel = new DataTable("seleccionados");
        dtSel.Columns.Add("CodigoSunat", System.Type.GetType("System.String"));
        dtSel.Columns.Add("NumeroDocumento", System.Type.GetType("System.String"));
        dtSel.Columns.Add("SaldoSoles", System.Type.GetType("System.Decimal"));
        dtSel.Columns.Add("SaldoDolares", System.Type.GetType("System.Decimal"));
        dtSel.Columns.Add("PlanCuentaId", System.Type.GetType("System.String"));
        dtSel.Columns.Add("Dia", System.Type.GetType("System.DateTime"));
        dtSel.Columns.Add("CodigoSubDiario", System.Type.GetType("System.String"));
        dtSel.Columns.Add("EmpresaId", System.Type.GetType("System.Int32"));
        dtSel.Columns.Add("MonedaId", System.Type.GetType("System.Int32"));
        foreach (DataGridViewRow filaDG in dgvAsientos.Rows)
        {
            if (Convert.ToBoolean(filaDG.Cells["chkbox"].Value) == true)
            {
                DataRow filaNueva = dtSel.NewRow();
                filaNueva["CodigoSunat"] = filaDG.Cells["CodigoSunat"].Value;
                filaNueva["NumeroDocumento"]=filaDG.Cells["NumeroDocumento"].Value;
                filaNueva["SaldoSoles"] = filaDG.Cells["SaldoSoles"].Value;
                filaNueva["SaldoDolares"] = filaDG.Cells["SaldoDolares"].Value;
                filaNueva["PlanCuentaId"] = filaDG.Cells["PlanCuentaId"].Value;
                filaNueva["Dia"] = filaDG.Cells["Dia"].Value;
                filaNueva["CodigoSubDiario"] = filaDG.Cells["CodigoSubDiario"].Value;
                filaNueva["EmpresaId"] = filaDG.Cells["EmpresaId"].Value;
                filaNueva["MonedaId"] = filaDG.Cells["MonedaId"].Value;
                dtSel.Rows.Add(filaNueva);
            }
        }
        //PROCESAR NEGATIVOS Y POSITIVOS POR UN LADO
        //EXTRAER CUENTAS DE PARAMETROSGENERALES
        //CALCULAR EL TOTAL DE LOS POSITIVOS y NEGATIVOS POR MONEDA
        Decimal totalPositivosSoles = 0;
        Decimal totalPositivosDolares = 0;
        Decimal totalNegativosSoles = 0;
        Decimal totalNegativosDolares = 0;
        try
        {
            totalPositivosSoles = Convert.ToDecimal(dtSel.Compute("SUM(SaldoSoles)", "SaldoSoles>0 and MonedaId=1"));
        }
        catch
        {
            totalPositivosSoles = 0;
        }

        try
        {
            totalPositivosDolares = Convert.ToDecimal(dtSel.Compute("SUM(SaldoSoles)", "SaldoSoles>0 and MonedaId=2"));
        }
        catch
        {
            totalPositivosDolares = 0;
        }
        try
        {
            totalNegativosSoles = Convert.ToDecimal(dtSel.Compute("SUM(SaldoSoles)", "SaldoSoles<0 and MonedaId=1"));
        }
        catch
        {
            totalNegativosSoles = 0;
        }

        try
        {
            totalNegativosDolares = Convert.ToDecimal(dtSel.Compute("SUM(SaldoSoles)", "SaldoSoles<0 and MonedaId=2"));
        }
        catch
        {
            totalNegativosDolares = 0;
        }

        //CREAR CABECERA
        BLAsientos asientos = new BLAsientos();
        //int AsientoContableID=0;
        
        //SERIALIZAR LOS DATOS
        // 
        StringWriter swStringWriter = new StringWriter();
        dtSel.WriteXml(swStringWriter);
        String tabla = swStringWriter.ToString();
        String Por = "";
        if (rbDiferenciaCambio.Checked == true)
        {
            Por = "DIFERENCIA DE CAMBIO";
        }
        if (rbRedondeo.Checked == true)
        {
            Por = "REDONDEO";
        }
        DateTime fechaCL = Convert.ToDateTime(dtpFechaConciliacion.Value.ToShortDateString());
        if (objBLAsientos.Conciliacion(cDatos.EstablecimientoID.ToString(), cDatos.Periodo.ToString(), tabla, Por, cDatos.HotelID, fechaCL) == true)
        {
            MessageBox.Show("El proceso se realizó correctamente.");
        }
        else
        {
            MessageBox.Show("El proceso falló.");
        }
        //asientos.setCreaAsientoCabecera("ACC",cDatos.EstablecimientoID,cDatos.Periodo,AsientoContableID,SubDiarioID,cDatos.HotelID,"ASIENTO DE CONCILIACIÓN MANUAL: ",Comprobante,fechadelnuevoasiento,cDatos.UsuarioID,0,"","","","",0)
        //CREAR DETALLE
        //foreach (DataRow filaASN in dtSel.Rows)
        //{
 
        //}

    }

    private void formatearGrid()
    {
        if (dgvAsientos.Columns.Contains("Codigo") == true)
        {
            dgvAsientos.Columns["Codigo"].Visible = false;
            dgvAsientos.Columns.Remove("Codigo");
        }

        if (dgvAsientos.Columns.Contains("PlanCuentaId") == true)
        {
            dgvAsientos.Columns["PlanCuentaId"].Visible = false;
            dgvAsientos.Columns.Remove("PlanCuentaId");
        }

        if (dgvAsientos.Columns.Contains("PeriodoId") == true)
        {
            dgvAsientos.Columns["PeriodoId"].Visible = false;
            dgvAsientos.Columns.Remove("PeriodoId");
        }

        if (dgvAsientos.Columns.Contains("CodigoSubDiario") == true)
        {
            dgvAsientos.Columns["CodigoSubDiario"].Visible = false;
            dgvAsientos.Columns.Remove("CodigoSubDiario");
        }

        if (dgvAsientos.Columns.Contains("EmpresaId") == true)
        {
            dgvAsientos.Columns["EmpresaId"].Visible = false;
            dgvAsientos.Columns.Remove("EmpresaId");
        }

        if (dgvAsientos.Columns.Contains("MonedaId") == true)
        {
            dgvAsientos.Columns["MonedaId"].Visible = false;
            dgvAsientos.Columns.Remove("MonedaId");
        }

        if (dgvAsientos.Columns.Contains("CodigoPlanCuenta") == true)
        {
            dgvAsientos.Columns["CodigoPlanCuenta"].HeaderText = "Plan de Cuenta";
        }

        if (dgvAsientos.Columns.Contains("NombrePlanCuenta") == true)
        {
            dgvAsientos.Columns["NombrePlanCuenta"].HeaderText = "Nombre Cuenta";
        }

        if (dgvAsientos.Columns.Contains("RazonSocial") == true)
        {
            dgvAsientos.Columns["RazonSocial"].HeaderText = "Empresa";
        }

        if (dgvAsientos.Columns.Contains("CodigoSunat") == true)
        {
            dgvAsientos.Columns["CodigoSunat"].HeaderText = "Tipo Documento";
        }

        if (dgvAsientos.Columns.Contains("NumeroDocumento") == true)
        {
            dgvAsientos.Columns["NumeroDocumento"].HeaderText = "Documento";
            //dgvAsientos.Columns["NumeroDocumento"].CellTemplate.FormattedValue = Text
        }

        if (dgvAsientos.Columns.Contains("DebeSoles") == true)
        {
            dgvAsientos.Columns["DebeSoles"].HeaderText = "Debe Soles";
        }

        if (dgvAsientos.Columns.Contains("HaberSoles") == true)
        {
            dgvAsientos.Columns["HaberSoles"].HeaderText = "Haber Soles";
        }

        if (dgvAsientos.Columns.Contains("SaldoSoles") == true)
        {
            dgvAsientos.Columns["SaldoSoles"].HeaderText = "Saldo Soles";
        }

        if (dgvAsientos.Columns.Contains("DebeDolares") == true)
        {
            dgvAsientos.Columns["DebeDolares"].HeaderText = "Debe Dolares";
        }

        if (dgvAsientos.Columns.Contains("HaberDolares") == true)
        {
            dgvAsientos.Columns["HaberDolares"].HeaderText = "Haber Dolares";
        }

        if (dgvAsientos.Columns.Contains("SaldoDolares") == true)
        {
            dgvAsientos.Columns["SaldoDolares"].HeaderText = "Saldo Dolares";
        }

        if (dgvAsientos.Columns.Contains("NombreSubDiario") == true)
        {
            dgvAsientos.Columns["NombreSubDiario"].HeaderText = "Nombre SubDiario";
        }

        if (dgvAsientos.Columns.Contains("NuevoSaldoS") == true)
        {
            dgvAsientos.Columns["NuevoSaldoS"].HeaderText = "Nuevo Saldo Soles";
        }

        if (dgvAsientos.Columns.Contains("NuevoSaldoD") == true)
        {
            dgvAsientos.Columns["NuevoSaldoD"].HeaderText = "Nuevo Saldo Dolares";
        }

        if (dgvAsientos.Columns.Contains("TipoCambio") == true)
        {
            dgvAsientos.Columns["TipoCambio"].HeaderText = "Tipo Cambio";
        }
        dgvAsientos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
    }


    private void dgvAsientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

        //If e.ColumnIndex = Me.DataGridView1.Columns.Item("check").Index Then

        try
        {
            if (e.ColumnIndex == dgvAsientos.Columns["chkbox"].Index)
            {
                Boolean valor = Convert.ToBoolean(this.dgvAsientos.Rows[e.RowIndex].Cells["chkbox"].Value);

                this.dgvAsientos.Rows[e.RowIndex].Cells["chkbox"].Value = !valor;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //Dim chkCell As DataGridViewCheckBoxCell = Me.DataGridView1.Rows(e.RowIndex).Cells("check")
        //chkCell.Value = Not chkCell.Value
        //End If

    }

    private void btnDetallado1_Click(object sender, EventArgs e)
    {
        String ruc = txtruc.Text;
        DateTime fechaInicio = this.dtpDesde.Value;
        DateTime fechaFin = this.dtpHasta.Value;
        //String cuentaInicial = Convert.ToString(cbxCuentaInicial.SelectedValue);
        //String cuentaFinal = Convert.ToString(cbxCuentaFinal.SelectedValue);
        Int32 monedaC = Convert.ToInt32(this.cbxMoneda.SelectedValue);

        if (fechaFin >= fechaInicio)
        {
            string s = "";
            foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
            {
                s += drv[0].ToString() + ",";
            }
            s = s.Trim().TrimEnd(',');

            dataTableAsientos.Reset();
            dataTableAsientos = objBLAsientos.estadosCuenta(empresaId, Convert.ToString(periodoId), fechaInicio, fechaFin, ruc, monedaC, s);
            dgvAsientos.DataSource = dataTableAsientos;
            this.dgvAsientos.ReadOnly = true;
            //this.dgvAsientos.ShowGroupPanel = false;
            //this.dgvAsientos.EnableGrouping = false;
            //this.dgvAsientos.AutoSizeRows = true;
            foreach (DataGridViewColumn column in dgvAsientos.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //column.TextAlignment = ContentAlignment.MiddleCenter;
                //column.BestFit();

            }
            dgvAsientos.Refresh();
        }
        else
        {
            RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
    }

    private void btnSaldos1_Click(object sender, EventArgs e)
    {
        //-----------------------------------------
        String ruc = txtruc.Text;
        DateTime fechaInicio = this.dtpDesde.Value;
        DateTime fechaFin = this.dtpHasta.Value;
        //String cuentaInicial = Convert.ToString(cbxCuentaInicial.SelectedValue);
        //String cuentaFinal = Convert.ToString(cbxCuentaFinal.SelectedValue);
        Int32 monedaC = Convert.ToInt32(this.cbxMoneda.SelectedValue);

        if (fechaFin >= fechaInicio)
        {
            dataTableAsientos.Reset();
            decimal saldoMinimo = 0;
            try
            {
                saldoMinimo = Convert.ToDecimal(txtSaldoMinimo.Text);
            }
            catch
            {
                saldoMinimo = 0;
            }
            //PlanCtaChkList
            string s = "";
            foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
            {
                s += drv[0].ToString() + ",";
            }
            s = s.Trim().TrimEnd(',');

            dataTableAsientos = objBLAsientos.estadosCuentaSaldos(empresaId, Convert.ToString(periodoId), fechaInicio, fechaFin, ruc, saldoMinimo, monedaC, s);
            dgvAsientos.DataSource = dataTableAsientos;
            button1.Text = dataTableAsientos.Rows.Count.ToString();
            if (saldoMinimo != 0)
            {
                //agregar columna checkbox
                //AGREGAMOS UNA COLUMNA DE CHECKBOX
                bool existeColCheck = false;
                foreach (DataGridViewColumn columna in dgvAsientos.Columns)
                {
                    if (columna.Name == "chkbox")
                    {
                        existeColCheck = true;
                        break;
                    }
                }

                if (existeColCheck == false)
                {

                    DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();

                    doWork.Name = "chkbox";

                    doWork.HeaderText = "Registro";

                    doWork.ReadOnly = false;

                    doWork.FalseValue = "0";

                    doWork.TrueValue = "1";

                    this.dgvAsientos.Columns.Insert(0, doWork);

                }
                // termina AGREGAMOS UNA COLUMNA DE CHECKBOX

            }
            else
            {
                //terminamos por eliminar si es diferente de cero y existe la columna
                bool existeColCheck = false;
                foreach (DataGridViewColumn columna in dgvAsientos.Columns)
                {
                    if (columna.Name == "chkbox")
                    {
                        existeColCheck = true;
                        break;
                    }
                }

                if (existeColCheck == true)
                {
                    dgvAsientos.Columns.Remove("chkbox");
                }

            }
            // ExportarExcelDataTable(dataTableAsientos,"C:\\Users\\usuario\\Downloads\\reporte.xls");
            this.dgvAsientos.ReadOnly = true;
            //this.dgvAsientos.ShowGroupPanel = false;
            //this.dgvAsientos.EnableGrouping = false;
            //this.dgvAsientos.AutoSizeRows = true;
            foreach (DataGridViewColumn column in dgvAsientos.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //column.AutoSizeMode=DataGridViewAutoSize;
                //column.TextAlignment = ContentAlignment.MiddleCenter;
                //column.BestFit();

            }
            dgvAsientos.Refresh();
            if (dgvAsientos.Rows.Count >= 1)
            {
                codigo_reporte = 1;
                btnReporte.Enabled = true;
                btnGenerarExcel.Enabled = true;
            }
            else
            {
                codigo_reporte = 0;
                btnReporte.Enabled = false;
                btnGenerarExcel.Enabled = false;
            }
            formatearGrid();
        }
        else
        {
            RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
        //-----------------------------------------
    }

    private void btnExportExcel1_Click(object sender, EventArgs e)
    {
        if (dataTableAsientos.Rows.Count > 0)
        {
            DateTime fechaInicio = this.dtpDesde.Value;
            DateTime fechaFin = this.dtpHasta.Value;

            ExportExcel objExcel = new ExportExcel();
            objExcel.exportToExcel(dataTableAsientos, empresa, sucursal, fechaInicio, fechaFin);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (dataTableAsientos.Rows.Count > 0)
        {
            DateTime fechaInicio = this.dtpDesde.Value;
            DateTime fechaFin = this.dtpHasta.Value;

            ExportExcel objExcel = new ExportExcel();
            objExcel.exportToExcelDetallado(dataTableAsientos, empresa, sucursal, fechaInicio, fechaFin);
        }
    }

    private void PlanCtaChkList_SelectedIndexChanged(object sender, EventArgs e)
    {
        planCtaIDLista = planCtaIDLista + "," + this.PlanCtaChkList.SelectedValue.ToString();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("test");
        
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        Int32 CtasChecked = 0;
        foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
        {
            CtasChecked ++;
        }

        if (CtasChecked > 0)
        {
            if (this.rbSaldos.Checked == true)
            {
                //-----------------------------------------
                String ruc = txtruc.Text;
                DateTime fechaInicio = this.dtpDesde.Value;
                DateTime fechaFin = this.dtpHasta.Value;
                //String cuentaInicial = Convert.ToString(cbxCuentaInicial.SelectedValue);
                //String cuentaFinal = Convert.ToString(cbxCuentaFinal.SelectedValue);
                Int32 monedaC = Convert.ToInt32(this.cbxMoneda.SelectedValue);

                if (fechaFin >= fechaInicio)
                {
                    dataTableAsientos.Reset();
                    decimal saldoMinimo = 0;
                    try
                    {
                        saldoMinimo = Convert.ToDecimal(txtSaldoMinimo.Text);
                    }
                    catch
                    {
                        saldoMinimo = 0;
                    }
                    //PlanCtaChkList
                    string s = "";
                    foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
                    {
                        s += drv[0].ToString() + ",";
                    }
                    s = s.Trim().TrimEnd(',');

                    dataTableAsientos = objBLAsientos.estadosCuentaSaldos(empresaId, Convert.ToString(periodoId), fechaInicio, fechaFin, ruc, saldoMinimo, monedaC, s);
                    dgvAsientos.DataSource = dataTableAsientos;
                    button1.Text = dataTableAsientos.Rows.Count.ToString();
                    if (saldoMinimo != 0)
                    {
                        //agregar columna checkbox
                        //AGREGAMOS UNA COLUMNA DE CHECKBOX
                        bool existeColCheck = false;
                        foreach (DataGridViewColumn columna in dgvAsientos.Columns)
                        {
                            if (columna.Name == "chkbox")
                            {
                                existeColCheck = true;
                                break;
                            }
                        }

                        if (existeColCheck == false)
                        {

                            DataGridViewCheckBoxColumn doWork = new DataGridViewCheckBoxColumn();

                            doWork.Name = "chkbox";

                            doWork.HeaderText = "Registro";

                            doWork.ReadOnly = false;

                            doWork.FalseValue = "0";

                            doWork.TrueValue = "1";

                            this.dgvAsientos.Columns.Insert(0, doWork);

                        }
                        // termina AGREGAMOS UNA COLUMNA DE CHECKBOX

                    }
                    else
                    {
                        //terminamos por eliminar si es diferente de cero y existe la columna
                        bool existeColCheck = false;
                        foreach (DataGridViewColumn columna in dgvAsientos.Columns)
                        {
                            if (columna.Name == "chkbox")
                            {
                                existeColCheck = true;
                                break;
                            }
                        }

                        if (existeColCheck == true)
                        {
                            dgvAsientos.Columns.Remove("chkbox");
                        }

                    }
                    // ExportarExcelDataTable(dataTableAsientos,"C:\\Users\\usuario\\Downloads\\reporte.xls");
                    this.dgvAsientos.ReadOnly = true;
                    //this.dgvAsientos.ShowGroupPanel = false;
                    //this.dgvAsientos.EnableGrouping = false;
                    //this.dgvAsientos.AutoSizeRows = true;
                    foreach (DataGridViewColumn column in dgvAsientos.Columns)
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //column.AutoSizeMode=DataGridViewAutoSize;
                        //column.TextAlignment = ContentAlignment.MiddleCenter;
                        //column.BestFit();

                    }
                    dgvAsientos.Refresh();
                    if (dgvAsientos.Rows.Count >= 1)
                    {
                        codigo_reporte = 1;
                        btnReporte.Enabled = true;
                        btnGenerarExcel.Enabled = true;
                    }
                    else
                    {
                        codigo_reporte = 0;
                        btnReporte.Enabled = false;
                        btnGenerarExcel.Enabled = false;
                    }
                    formatearGrid();
                }
                else
                {
                    RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                //-----------------------------------------
            }
            else if (this.rbDetallado.Checked == true)
            {
                String ruc = txtruc.Text;
                DateTime fechaInicio = this.dtpDesde.Value;
                DateTime fechaFin = this.dtpHasta.Value;
                //String cuentaInicial = Convert.ToString(cbxCuentaInicial.SelectedValue);
                //String cuentaFinal = Convert.ToString(cbxCuentaFinal.SelectedValue);
                Int32 monedaC = Convert.ToInt32(this.cbxMoneda.SelectedValue);

                if (fechaFin >= fechaInicio)
                {
                    string s = "";
                    foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
                    {
                        s += drv[0].ToString() + ",";
                    }
                    s = s.Trim().TrimEnd(',');

                    dataTableAsientos.Reset();
                    dataTableAsientos = objBLAsientos.estadosCuenta(empresaId, Convert.ToString(periodoId), fechaInicio, fechaFin, ruc, monedaC, s);
                    dgvAsientos.DataSource = dataTableAsientos;
                    this.dgvAsientos.ReadOnly = true;
                    //this.dgvAsientos.ShowGroupPanel = false;
                    //this.dgvAsientos.EnableGrouping = false;
                    //this.dgvAsientos.AutoSizeRows = true;
                    foreach (DataGridViewColumn column in dgvAsientos.Columns)
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //column.TextAlignment = ContentAlignment.MiddleCenter;
                        //column.BestFit();

                    }
                    dgvAsientos.Refresh();
                    if (dgvAsientos.Rows.Count >= 1)
                    {
                        codigo_reporte = 1;
                        btnReporte.Enabled = true;
                        btnGenerarExcel.Enabled = true;
                    }
                    else
                    {
                        codigo_reporte = 0;
                        btnReporte.Enabled = false;
                        btnGenerarExcel.Enabled = false;
                    }
                    formatearGrid();
                }
                else
                {
                    RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
            else
            {
                //saldos historicos
                //exec UCO_EstadosCuentaSaldosProveedores @EmpresaID=2,@Ejercicio='2012',@WhereCondition=' (ACD.Dia BETWEEN ''01/01/2011''         AND ''31/01/2012'') AND (CodigoPlanCuenta BETWEEN ''42121'' AND ''42121'')  and empresas.empresaid=22759',  @OrderByExpression=' ORDER BY PlanDeCuentas.CodigoPlanCuenta, ACD.EmpresaID, ACD.TipoDocumentoID, ACD.NumeroDocumento'
                String ruc = txtruc.Text;
                DateTime fechaInicio = this.dtpDesde.Value;
                DateTime fechaFin = this.dtpHasta.Value;
                //String cuentaInicial = Convert.ToString(cbxCuentaInicial.SelectedValue);
                //String cuentaFinal = Convert.ToString(cbxCuentaFinal.SelectedValue);
                Int32 monedaC = Convert.ToInt32(this.cbxMoneda.SelectedValue);
                if (fechaFin >= fechaInicio)
                {
                    dataTableAsientos.Reset();
                    string s = "";
                    foreach (DataRowView drv in PlanCtaChkList.CheckedItems)
                    {
                        s += drv[0].ToString() + ",";
                    }
                    s = s.Trim().TrimEnd(',');
                    dataTableAsientos = objBLAsientos.estadosCuentaSaldosHistoricos(empresaId, Convert.ToString(periodoId), fechaInicio, fechaFin, ruc, monedaC, s);
                    dgvAsientos.DataSource = dataTableAsientos;
                    button1.Text = dataTableAsientos.Rows.Count.ToString();
                    // ExportarExcelDataTable(dataTableAsientos,"C:\\Users\\usuario\\Downloads\\reporte.xls");
                    this.dgvAsientos.ReadOnly = true;
                    //this.dgvAsientos.ShowGroupPanel = false;
                    //this.dgvAsientos.EnableGrouping = false;
                    //this.dgvAsientos.AutoSizeRows = true;
                    foreach (DataGridViewColumn column in dgvAsientos.Columns)
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //column.TextAlignment = ContentAlignment.MiddleCenter;
                        //column.BestFit();

                    }
                    dgvAsientos.Refresh();
                    if (dgvAsientos.Rows.Count >= 1)
                    {
                        codigo_reporte = 1;
                        btnReporte.Enabled = true;
                        btnGenerarExcel.Enabled = true;
                    }
                    else
                    {
                        codigo_reporte = 0;
                        btnReporte.Enabled = false;
                        btnGenerarExcel.Enabled = false;
                    }
                    formatearGrid();
                }
                else
                {
                    RadMessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Seleccione almenos una cuenta contable",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RightAlign,
            false);
        }
        
    }
      private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

      private void btnGenerarExcel_Click(object sender, EventArgs e)
      {
          if(reportesConGrupoCHB.Checked == true){
              if(this.rbSaldos.Checked == true){
                  if (dataTableAsientos.Rows.Count > 0)
                  {
                      DateTime fechaInicio = this.dtpDesde.Value;
                      DateTime fechaFin = this.dtpHasta.Value;

                      ExportExcel objExcel = new ExportExcel();
                      objExcel.exportToExcel(dataTableAsientos, empresa, sucursal, fechaInicio, fechaFin);
                  }
              }else if(this.rbDetallado.Checked == true  || this.rbHistorico.Checked == true  ){
                  if (dataTableAsientos.Rows.Count > 0)
                  {
                      DateTime fechaInicio = this.dtpDesde.Value;
                      DateTime fechaFin = this.dtpHasta.Value;

                      ExportExcel objExcel = new ExportExcel();
                      objExcel.exportToExcelDetallado(dataTableAsientos, empresa, sucursal, fechaInicio, fechaFin);
                  }
              }
          }
          else
          {
              Microsoft.Office.Interop.Excel.Worksheet wsheet;
              Microsoft.Office.Interop.Excel.Workbook wbook;
              Microsoft.Office.Interop.Excel.Application wapp;
              wapp = new Microsoft.Office.Interop.Excel.Application();

            //  wapp = new Microsoft.Office.Interop.Excel.Application();
              wapp.Visible = false;
              wbook = wapp.Workbooks.Add(true);
              wsheet = (Microsoft.Office.Interop.Excel.Worksheet)wbook.ActiveSheet;



              try
              {
                  List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
                  foreach (DataGridViewColumn col in dgvAsientos.Columns)
                  {
                      if (col.Visible)
                          listVisible.Add(col);
                  }

                  for (int i = 0; i < listVisible.Count; i++)
                  {

                      wsheet.Cells[i + 1] = listVisible[i].HeaderText;
                      wsheet.Cells[i + 1].EntireRow.Font.Bold = true;
                      wsheet.Cells[i + 1].Borders.Color = 000;
                      wsheet.Cells[i + 1].Interior.ColorIndex = 24;
                  }

                  for (int i = 0; i <= dgvAsientos.Rows.Count - 1; i++)
                  {
                      for (int j = 0; j < listVisible.Count; j++)
                      {
                          if (this.dgvAsientos.Columns[j].HeaderText == "Documento")
                          {
                              wsheet.Cells[i + 2, j + 1] = "'" + dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "@";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Dia")
                          {
                              //wsheet.Cells[i + 2, j + 1] = Convert.ToDateTime(dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString()).ToString("dd/MM/yyyy");
                              //wsheet.Cells[i + 2, j + 1].NumberFormat = "dd/MM/yyyy";
                              wsheet.Cells[i + 2, j + 1] = "'" + Convert.ToDateTime(dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString()).ToString("dd/MM/yyyy");
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "@";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Ruc")
                          {
                              wsheet.Cells[i + 2, j + 1] = "'" + dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "@";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Debe Soles")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Haber Soles")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Saldo Soles")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Nuevo SaldoS")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Debe Dolares")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Haber Dolares")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Nuevo SaldoD")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Saldo Dolares")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Nuevo Saldo Soles")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Nuevo Saldo Dolares")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,##0.00";
                          }
                          else if (this.dgvAsientos.Columns[j].HeaderText == "Tipo Cambio")
                          {
                              wsheet.Cells[i + 2, j + 1] = dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                              wsheet.Cells[i + 2, j + 1].NumberFormat = "#,#####0.00000";
                          }
                          else
                          {
                              wsheet.Cells[i + 2, j + 1] = "'" + dgvAsientos.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                          }

                      }
                  }
                  wsheet.Rows.AutoFit();
                  wsheet.Columns.AutoFit();
                  wapp.Visible = true;
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error Details" + ex.Message);
              }
          }


          
        }

      private void rbSaldos_CheckedChanged(object sender, EventArgs e)
      {
          btnGenerarExcel.Enabled = false;
          btnReporte.Enabled = false;
      }

      private void rbDetallado_CheckedChanged(object sender, EventArgs e)
      {
          btnGenerarExcel.Enabled = false;
          btnReporte.Enabled = false;
      }

      private void rbHistorico_CheckedChanged(object sender, EventArgs e)
      {
          btnGenerarExcel.Enabled = false;
          btnReporte.Enabled = false;
      }


        public DataTable getHotel(Int32 EstadoActivo, Int32 EstadoDesactivo, Int32 EstablecimientoID)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@EstadoActivo", System.Data.SqlDbType.Int);
                par[0].Value = EstadoActivo;
                par[1] = new SqlParameter("@EstadoDesactivo", System.Data.SqlDbType.Int);
                par[1].Value = EstadoDesactivo;
                par[2] = new SqlParameter("@EstablecimientoID", System.Data.SqlDbType.Int);
                par[2].Value = EstablecimientoID;

                _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "USP_Hoteles", par).Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
            return _dataTable;
        }


    }

}
