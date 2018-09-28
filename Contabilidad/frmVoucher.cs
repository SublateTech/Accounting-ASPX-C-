using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using BL;
using Excel = Microsoft.Office.Interop.Excel;


namespace Contabilidad
{
  public partial class frmVoucher : Form
  {

    //==========================================
    //DETALLE
    //SubDiario	-- NombreSubDiario
    //Glosa	  	-- Glosa
    //Comprobante	-- Comprobante
    //Dia		-- Dia
    //HaberSoles
    //DebeSoles
    //SaldoSoles
    //DebeDolares
    //HaberDolares
    //SaldoDolares
    //==========================================
    //RESUMEN
    //Codigo		-- CodigoPlanCuenta
    //Descripcion	-- NombrePlanCuenta
    //DebeSoles	
    //HaberSoles
    //SaldoSoles
    //DebeDolares
    //HaberDolares
    //SaldoDolares
    //==========================================


    private Int32 empresaId;
    private String empresa;
    private Int32 sucursalId;
    private String sucursal;
    private Int32 periodoId;

    private BLAsientos objBLAsientos;
    private BLMoneda objBLMoneda;
    private BLHotel objBLHotel;
    private BLUser objBLUser;

    private BLPlanCuenta objBLPlanCuenta;

    private DataTable datosGrid;

    private DataTable tablaResumen;

    public frmVoucher()
    {
      InitializeComponent();
    }

    public frmVoucher(Int32 _empresaId, String _empresa, Int32 _sucursalId, String _sucursal, Int32 _periodoId)
    {
      InitializeComponent();
      empresaId = _empresaId;
      empresa = _empresa;
      sucursalId = _sucursalId;
      sucursal = _sucursal;
      periodoId = _periodoId;

      objBLAsientos = new BLAsientos();
      objBLMoneda = new BLMoneda();
      objBLHotel = new BLHotel();
      objBLPlanCuenta = new BLPlanCuenta();
      objBLUser = new BLUser();
    }

    public void loadPlanCuenta()
    {

        try
        {
            //DataTable _dataTable = objBLPlanCuenta.getPlanCuentas(empresaId);
            
            DataTable _dataTable = objBLPlanCuenta.getPlanCuentas();
            this.cbxCuentaInicial_1.DataSource = _dataTable;
            this.cbxCuentaInicial_1.DisplayMember = "Nombre_PlanCuenta";
            this.cbxCuentaInicial_1.ValueMember = "PlanCuentaID";
            this.cbxCuentaFinal_1.DataSource = _dataTable;
            this.cbxCuentaFinal_1.DisplayMember = "Nombre_PlanCuenta";
            this.cbxCuentaFinal_1.ValueMember = "PlanCuentaID";
        }

        catch (Exception e)
        {
            MessageBox.Show("No se cargaron las cuentas. Mensaje de error: " + e.Message + ". Origen: " + e.Source);
        }

        try

        {
            DataTable _datos = objBLPlanCuenta.getFormatoPlanCuentas();
            this.cboFormato.DataSource = _datos;
            this.cboFormato.DisplayMember = "Formato";
            this.cboFormato.ValueMember = "Codigo";        
        }

        catch (Exception e) 
        {
            MessageBox.Show("No se cargaron los formatos. Mensaje de error: " + e.Message + ". Origen: " + e.Source);
        }

        //DataColumn _dataColumn = _dataTable.Columns.Add("Concatenado", System.Type.GetType("System.String"));
        //_dataColumn.Expression = "CodigoPlanCuenta+' --> '+NombrePlanCuenta";

    }

    private void frmVoucher_Load(object sender, EventArgs e)
    {
      DataView vistaSubDiarios = objBLAsientos.subdiarios(true).AsDataView();
      vistaSubDiarios.Sort = "NombreSubDiario";
      DataTable tablaSubDiarios = vistaSubDiarios.ToTable();
      this.cbxSubdiario.DataSource = tablaSubDiarios;
      this.cbxSubdiario.DisplayMember = "NombreSubDiario";
      this.cbxSubdiario.ValueMember = "SubDiarioID";

      this.cbxMoneda.DataSource = objBLMoneda.getMoneda();
      this.cbxMoneda.DisplayMember = "Nombre";
      this.cbxMoneda.ValueMember = "monedaid";
      //this.dtpDesde1.Value = DateTime.Now;
      //this.dtpHasta1.Value = DateTime.Now;

     // MessageBox.Show(cDatos.EstablecimientoID.ToString());

      DataTable datos = new DataTable();

      datos = objBLHotel.getUnidadesNegocio(cDatos.EstablecimientoID, "", "");

      DataRow fila = datos.NewRow();

      fila["UnidadNegocioID"] = 0;

      datos.Rows.Add(fila);

      DataView vistaDatos = new DataView(datos, "", "NombreUnidadNegocio ASC", DataViewRowState.CurrentRows);

      this.cboUnidadNegocio.DataSource = vistaDatos;

      this.cboUnidadNegocio.DisplayMember = "NombreUnidadNegocio";

      this.cboUnidadNegocio.ValueMember = "UnidadNegocioID";

      datos = new DataTable();

      datos = objBLHotel.getAreas("", "");

      fila = datos.NewRow();

      fila["AreaID"] = 0;

      datos.Rows.Add(fila);

      vistaDatos = new DataView(datos,"","NombreArea ASC",DataViewRowState.CurrentRows); 
      
      this.cboAreas.DataSource = vistaDatos;            

      this.cboAreas.DisplayMember = "NombreArea";

      this.cboAreas.ValueMember = "AreaID";

      DataTable _datos = objBLPlanCuenta.getFormatoPlanCuentas();
      this.cboFormato.DataSource = _datos;
      this.cboFormato.DisplayMember = "Formato";
      this.cboFormato.ValueMember = "Codigo";

      configurarCamposFecha();
      
     // loadPlanCuenta();

    }

    private void configurarCamposFecha()
    {
        txtDesde.Mask = "00/00/0000";
        //COMENTADO EL 17 03 2014
        //txtDesde.ValidatingType = typeof(System.DateTime);
        //txtDesde.TypeValidationCompleted += new TypeValidationEventHandler(mtxtFecha_TypeValidationCompleted);
        //txtDesde.KeyPress += new KeyPressEventHandler(mtxtFecha_KeyPress);
        //txtDesde.KeyDown += new KeyEventHandler(mtxtFecha_KeyDown);

        txtHasta.Mask = "00/00/0000";
        //COMENTADO EL 17 03 2014
        //txtHasta.ValidatingType = typeof(System.DateTime);
        //txtHasta.TypeValidationCompleted += new TypeValidationEventHandler(mtxtFecha_TypeValidationCompleted);
        //txtHasta.KeyPress += new KeyPressEventHandler(mtxtFecha_KeyPress);
        //txtHasta.KeyDown += new KeyEventHandler(mtxtFecha_KeyDown);
        txtDesde.Focus();
    }

    private void mtxtFecha_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
    {
        if (!e.IsValidInput)
        {
            //ttMensajes.ToolTipTitle = "Fecha Inválida";
            //ttMensajes.Show("Los datos que debe ingresar deben ser una fecha válida en el formato dd/mm/yyyy.", mtxtFecha, 0, -20, 5000);
            
            MaskedTextBox cajaMascara = (MaskedTextBox)sender;
            cajaMascara.SelectAll();
            e.Cancel = true;

        }

    }

    private void mtxtFecha_KeyDown(object sender, KeyEventArgs e)
    {
        //ttMensajes.Hide(mtxtFecha);
    }

    private void MostrarCuadradosNoCuadrados(Boolean valor)
    {
        if (valor == true)
        {

            chkCuadrados.Visible = true;
            chkNoCuadrados.Visible = true;

            Int32 subDiarioId = Convert.ToInt32(cbxSubdiario.SelectedValue);

            if (subDiarioId > 0)
            {
                btnEliminar.Visible = true;
                btnEliminarTodos.Visible = true;
                btnNuevo.Visible = true;
            }
            else
            {
                btnEliminar.Visible = false;
                btnEliminarTodos.Visible = false;
                btnNuevo.Visible = false;
            }

            
        }

        if (valor == false)
        {
            chkCuadrados.Visible = false;
            chkNoCuadrados.Visible = false;
            Int32 subDiarioId = Convert.ToInt32(cbxSubdiario.SelectedValue);

            if (subDiarioId > 0)
            {
                btnEliminar.Visible = false;
                btnEliminarTodos.Visible = false;
            }
            else
            {
                btnEliminar.Visible = true;
                btnEliminarTodos.Visible = true;
            }

        }

    }

    private void btnAsientos_Click(object sender, EventArgs e)
    {
        buscarAsientos();
    }

    private void buscarAsientos()
    {

        //DateTime fechaInicio = this.dtpDesde1.Value;
        //DateTime fechaFin = this.dtpHasta1.Value;

        DateTime fechaInicio=DateTime.Now;
        DateTime fechaFin=DateTime.Now;

        string fechaDesde = txtDesde.Text;
        string fechaHasta = txtHasta.Text;

        if (DateTime.TryParse(fechaDesde, out fechaInicio)==false)
        {
            MessageBox.Show("La fecha Desde no es válida.");
            return;
        }

        if (DateTime.TryParse(fechaHasta, out fechaFin) == false)
        {
            MessageBox.Show("La fecha Hasta no es válida.");
            return;
        }
 


        //comprobar si las cuentas con válidas
        if (rbCuentas.Checked == true)
        {
            if ((lblCuentaInicial_ID.Text.Trim().Length == 0) || (lblCuentaFinal_ID.Text.Trim().Length == 0))
            {
                MessageBox.Show("Elija una cuenta ...");
                return;
            }
        }

        //DataTable datos = new DataTable();
        //se marcan los cehckec de cuadrados y no cuadrados para evitar confusiones
        chkCuadrados.Checked = true;
        chkNoCuadrados.Checked = true;

        bool Nuevo = true;
        if (Nuevo == true)
        {
            if (fechaFin >= fechaInicio)
            {
                if (rbSubDiario.Checked == true)
                {
                    //prioridad subdiario
                    //detallado
                    if (Convert.ToString(cboFormato.SelectedValue) == "0")
                    {

                        datosGrid = objBLAsientos.asientosContables(Convert.ToString(empresaId), Convert.ToString(periodoId), fechaInicio, fechaFin, Convert.ToString(cbxCuentaInicial_1.SelectedValue).Trim(), Convert.ToString(cbxCuentaFinal_1.SelectedValue).Trim(), Convert.ToString(cbxSubdiario.SelectedValue), sucursalId);

                        DataView vista = datosGrid.AsDataView();

                        this.dgvAsientos.DataSource = vista;

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
                    //consolidado
                    if (Convert.ToString(cboFormato.SelectedValue) == "1")
                    {

                        String cuentaInicial;
                        String cuentaFinal;

                        try
                        {
                            cuentaInicial = Convert.ToString(cbxCuentaInicial_1.SelectedValue);
                        }
                        catch
                        {
                            cuentaInicial = "";
                        }

                        try
                        {
                            cuentaFinal = Convert.ToString(cbxCuentaFinal_1.SelectedValue);
                        }
                        catch
                        {
                            cuentaFinal = "";
                        }

                        this.dgvAsientos.DataSource = objBLAsientos.consolidadoAsientosContables(Convert.ToString(empresaId), Convert.ToString(periodoId), Convert.ToString(cbxSubdiario.SelectedValue), Convert.ToInt32(cboUnidadNegocio.SelectedValue), cDatos.HotelID, Convert.ToInt32(cboAreas.SelectedValue), fechaInicio, fechaFin, cuentaInicial, cuentaFinal);
                    }



                }
                if (rbCuentas.Checked == true)
                {
                    //prioridad cuentas

                }
            }
        }

        if (fechaFin >= fechaInicio)
        {


            //this.dgvAsientos.DataSource = objBLAsientos.asientosContables(Convert.ToString(empresaId), Convert.ToString(periodoId), fechaInicio, fechaFin, Convert.ToString(cbxSubdiario.SelectedValue), sucursalId);

            this.dgvAsientos.ReadOnly = true;

            //this.dgvAsientos.ShowGroupPanel = false;
            //this.dgvAsientos.EnableGrouping = false;
            //this.dgvAsientos.AutoSizeRows = true;

            foreach (var column in dgvAsientos.Columns)
            {

                //column.TextAlignment = ContentAlignment.MiddleCenter;
                //column.BestFit();

            }

            if (this.dgvAsientos.Columns.Contains("AsientoContableID") == true)
            {
                this.dgvAsientos.Columns["AsientoContableID"].Visible = false;
            }

            if (this.dgvAsientos.Columns.Contains("SubDiarioID") == true)
            {
                this.dgvAsientos.Columns["SubDiarioID"].Visible = false;
            }

            if (this.dgvAsientos.Columns.Contains("HotelID") == true)
            {
                this.dgvAsientos.Columns["HotelID"].Visible = false;
            }

            if (this.dgvAsientos.Columns.Contains("NunArchivos") == true)
            {
                this.dgvAsientos.Columns["NunArchivos"].Visible = false;
            }

            if (this.dgvAsientos.Columns.Contains("Bloqueado") == true)
            {
                this.dgvAsientos.Columns["Bloqueado"].Visible = false;
            }

            formatearGrid();

            dgvAsientos.Refresh();

        }
        else
        {
            MessageBox.Show("El rango de fechas es incorrecto", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnImprimir_Click(object sender, EventArgs e)
    {
      String subdiarioId = "";
      String asientoContableId = "";
      Int32 monedaId = Convert.ToInt32(cbxMoneda.SelectedValue);
      String moneda=cbxMoneda.SelectedText;

      //DateTime fechaInicio = this.dtpDesde1.Value;
      //DateTime fechaFin = this.dtpHasta1.Value;

      DateTime fechaInicio = DateTime.Now;
      DateTime fechaFin = DateTime.Now;

      string fechaDesde = txtDesde.Text;
      string fechaHasta = txtHasta.Text;

      if (DateTime.TryParse(fechaDesde, out fechaInicio) == false)
      {
          MessageBox.Show("La fecha Desde no es válida.");
          return;
      }

      if (DateTime.TryParse(fechaHasta, out fechaFin) == false)
      {
          MessageBox.Show("La fecha Hasta no es válida.");
          return;
      }

        

      if (checkSubdiario.Checked)
      {


        subdiarioId = Convert.ToString(cbxSubdiario.SelectedValue);
        frmVoucherRpt _frmVoucherRpt = new frmVoucherRpt(subdiarioId, asientoContableId, monedaId, moneda, fechaInicio, fechaFin, cDatos.HotelID.ToString(), cDatos.Periodo,cDatos.Establecimiento);
        _frmVoucherRpt.Height = this.Height;
        _frmVoucherRpt.Width = this.Width;
        _frmVoucherRpt.ShowDialog();
      }
      else 
      {
        if (dgvAsientos.RowCount > 0)
        {
          DataGridViewCell viewcell = dgvAsientos.CurrentCell;
          try
          {
              asientoContableId = Convert.ToString(dgvAsientos.Rows[viewcell.RowIndex].Cells["AsientoContableID"].Value);
              frmVoucherRpt _frmVoucherRpt = new frmVoucherRpt(subdiarioId, asientoContableId, monedaId, moneda, fechaInicio, fechaFin, cDatos.EstablecimientoID.ToString(), cDatos.Periodo,cDatos.Establecimiento);
              _frmVoucherRpt.Height = this.Height;
              _frmVoucherRpt.Width = this.Width;
              _frmVoucherRpt.ShowDialog();
          }
          catch
          {
              MessageBox.Show("Seleccione un registro.");
          }
          
        }
        else
        {
          RadMessageBox.Show("No hay asientos contables", "Error:", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
      }
      /*if (checkSubdiario.Checked)
      {
        MessageBox.Show("checked");
        frmVoucherRpt _frmVoucherRpt = new frmVoucherRpt(_subdiarioId,_asientoContableId,_monedaId,_desde,_hasta);
        _frmVoucherRpt.Height = this.Height;
        _frmVoucherRpt.Width = this.Width;
        _frmVoucherRpt.ShowDialog();
      }
      else
      {
        MessageBox.Show("unchecked");
      }*/
      //Telerik.WinControls.UI.GridDataCellElement viewcell = dgvAsientos.CurrentCell;
      //MessageBox.Show(Convert.ToString(dgvAsientos.RowCount));
      //MessageBox.Show(Convert.ToString(dgvAsientos.Rows[viewcell.RowIndex].Cells["AsientoContableID"].Value));
      //ruc = Convert.ToString(dgvAsientos["ruc", viewcell.RowIndex].Value);
    }

    private void gbxBusqueda_Enter(object sender, EventArgs e)
    {

    }

    private void cboFormato_SelectedIndexChanged(object sender, EventArgs e)
    {
 
    }

   
    private void rbSubDiario_CheckedChanged(object sender, EventArgs e)
    {
        if ((rbSubDiario.Checked == true) && (Convert.ToInt32(cboFormato.SelectedValue) == 0))
        {
            MostrarCuadradosNoCuadrados(true);
        }
        else 
        {
            MostrarCuadradosNoCuadrados(false);
        }
    }

    private void cboFormato_SelectedValueChanged(object sender, EventArgs e)
    {

        try 
        {
            if ((rbSubDiario.Checked == true) && (Convert.ToInt32(cboFormato.SelectedValue) == 0))
            {
                MostrarCuadradosNoCuadrados(true);
            }
            else
            {
                MostrarCuadradosNoCuadrados(false);
            }
        }
        catch { 
        }
    }

    private void filtrarGrid() {

        DataView vistaDatos = new DataView();
        
       
       vistaDatos = (DataView)dgvAsientos.DataSource;
           

        

        if (chkCuadrados.Checked == true && chkNoCuadrados.Checked == true)
        {
            //TODOS
            vistaDatos = new DataView(datosGrid, "", "", DataViewRowState.CurrentRows);
        }


        if (chkCuadrados.Checked == true && chkNoCuadrados.Checked == false)
        {
            //SOLO LOS CUADRADOS
            vistaDatos = new DataView(datosGrid, "SaldoSoles = 0", "", DataViewRowState.CurrentRows);
        }

        if (chkCuadrados.Checked == false && chkNoCuadrados.Checked == true)
        {
            //SOLO LOS NO CUADRADOS
            vistaDatos = new DataView(datosGrid, "SaldoSoles <> 0", "", DataViewRowState.CurrentRows);
        }

        if (chkCuadrados.Checked == false && chkNoCuadrados.Checked == false)
        {
            //NINGUNO
            vistaDatos = new DataView();
        }

        dgvAsientos.DataSource = vistaDatos;
    }

    private void chkCuadrados_CheckedChanged(object sender, EventArgs e)
    {

        filtrarGrid();

        
    }

    private void chkNoCuadrados_CheckedChanged(object sender, EventArgs e)
    {
        filtrarGrid();
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }


    private void tabVouchers_Selecting(Object sender, TabControlCancelEventArgs e)
    {
        if (e.TabPage.Name == "tpResumen")
        {

            //MessageBox.Show("Estamos seleccionando la pestaña de resumen, se deben cargar los datos.");
            int iSubDiario = 0;
            try
            {
                iSubDiario = Convert.ToInt32(cbxSubdiario.SelectedValue);
            }
            catch
            {
                iSubDiario = 0;
            }

            if (iSubDiario == 0)
            {
                MessageBox.Show("Seleccione un subdiario.");
                return;
            }

            //DateTime dFechaInicio = dtpDesde1.Value;
            //DateTime dFechaFin = dtpHasta1.Value;

            DateTime dFechaInicio = DateTime.Now;
            DateTime dFechaFin = DateTime.Now;

            string fechaDesde = txtDesde.Text;
            string fechaHasta = txtHasta.Text;

            if (DateTime.TryParse(fechaDesde, out dFechaInicio) == false)
            {
                MessageBox.Show("La fecha Desde no es válida.");
                return;
            }

            if (DateTime.TryParse(fechaHasta, out dFechaFin) == false)
            {
                MessageBox.Show("La fecha Hasta no es válida.");
                return;
            }


            tablaResumen = objBLAsientos.consolidadoDiarioAuxiliar(cDatos.EstablecimientoID.ToString(), cDatos.Periodo, iSubDiario, 0, cDatos.HotelID, 0, dFechaInicio, dFechaFin, "", null, null);

            dgvConsolidado.DataSource = tablaResumen;
            formatearGridConsolidado();
        }
    }

    private void formatearGridConsolidado()
  {
      dgvConsolidado.Columns["SubDiarioID"].Visible = false;
      dgvConsolidado.Columns["NombreSubDiario"].Visible = false;
      dgvConsolidado.Columns["PlanCuentaID"].Visible = false;
      dgvConsolidado.Columns["CodigoPlanCuenta"].HeaderText = "Codigo";
      dgvConsolidado.Columns["NombrePlanCuenta"].HeaderText = "Descripcion";
      dgvConsolidado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
  }


    private void dgvAsientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

        try
        {
            //If e.ColumnIndex = Me.DataGridView1.Columns.Item("check").Index Then

            if (e.ColumnIndex == dgvAsientos.Columns["chkbox"].Index)
            {
                Boolean valor = Convert.ToBoolean(this.dgvAsientos.Rows[e.RowIndex].Cells["chkbox"].Value);

                this.dgvAsientos.Rows[e.RowIndex].Cells["chkbox"].Value = !valor;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }

       //Dim chkCell As DataGridViewCheckBoxCell = Me.DataGridView1.Rows(e.RowIndex).Cells("check")
       //chkCell.Value = Not chkCell.Value
   //End If

    }

    private void dgvAsientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            //DataRow filaDBC  = dgvAsientos.Rows[e.RowIndex].DataBoundItem as DataRow;
            //int codigoAsiento = Convert.ToInt32(filaDBC["AsientoContableId"]);
            DataGridViewRow filaGrid = dgvAsientos.Rows[e.RowIndex];

            int codigoAsiento = Convert.ToInt32(filaGrid.Cells["AsientoContableId"].Value);

            String subDiarioId = Convert.ToString(filaGrid.Cells["SubDiarioId"].Value);

            frmRegistroAsientos _frmModificaAsiento = new frmRegistroAsientos(codigoAsiento,subDiarioId,false);

            _frmModificaAsiento.Text = "Modificar Asiento | SubDiario: " + objBLAsientos.nombreSubDiario(subDiarioId);

            //_frmModificaAsiento.Parent = this;

            _frmModificaAsiento.StartPosition = FormStartPosition.CenterParent;

            _frmModificaAsiento.ShowDialog(this);

            //buscarAsientos();

        }
    }

    private void cbxSubdiario_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if ((rbSubDiario.Checked == true) && (Convert.ToInt32(cboFormato.SelectedValue) == 0))
            {
                MostrarCuadradosNoCuadrados(true);
            }
            else
            {
                MostrarCuadradosNoCuadrados(false);
            }
        }
        catch
        {
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        //eliminar los asientos seleccionados
        //primero verifica que hay asientos
        //luego un bucle para ver cuales estan marcado
        if (dgvAsientos.Rows.Count != 0)
        {
            
            foreach (DataGridViewRow fila in dgvAsientos.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["chkbox"].Value) == true)
                {
                    string AsientoContableID = "";
                    
                    DateTime Fecha;

                    AsientoContableID = Convert.ToString(fila.Cells["AsientoContableID"].Value);

                    Fecha = Convert.ToDateTime(fila.Cells["Dia"].Value);

                    if (objBLAsientos.eliminarVoucher(cDatos.EstablecimientoID.ToString(), Fecha.Year.ToString(), AsientoContableID, cDatos.UsuarioID, 0, "", "", "", "", cDatos.HotelID) == false)
                    {
                        MessageBox.Show("No se eliminó ningún voucher.");
                        return;
                    }
                    else
                    {
                        //MessageBox.Show("Los asientos seleccionados fueron eliminados.");
                        //buscarAsientos();
                    }

                }

            }
            MessageBox.Show("Los asientos seleccionados fueron eliminados.");
            buscarAsientos();
        }
        else
        {
            MessageBox.Show("No hay asientos en la lista.");
        }
    }

    private void btnEliminarTodos_Click(object sender, EventArgs e)
    {

        DialogResult respuesta = MessageBox.Show("Desea eliminar todos los asientos del subdiario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (respuesta == DialogResult.No)
        {
            return;
        }

        String subDiarioId = Convert.ToString(cbxSubdiario.SelectedValue);

        if ((objBLAsientos.subdiarioEsAutomatico(subDiarioId) == true) && (objBLUser.permisoEliminarVoucherTodos(cDatos.UsuarioID)==true))
        {

            //string periodo = Convert.ToDateTime(dtpDesde1.Value).Year.ToString();
            string periodo = Convert.ToDateTime(txtDesde.Text).Year.ToString();
            
            //DateTime desde=Convert.ToDateTime(dtpDesde1.Value.ToShortDateString());
            //DateTime hasta = Convert.ToDateTime(dtpHasta1.Value.ToShortDateString());

            ///**************************
            DateTime desde = DateTime.Now;
            DateTime hasta = DateTime.Now;

            string fechaDesde = txtDesde.Text;
            string fechaHasta = txtHasta.Text;

            if (DateTime.TryParse(fechaDesde, out desde) == false)
            {
                MessageBox.Show("La fecha Desde no es válida.");
                return;
            }

            if (DateTime.TryParse(fechaHasta, out hasta) == false)
            {
                MessageBox.Show("La fecha Hasta no es válida.");
                return;
            }
            /////************************


            if (objBLAsientos.eliminarVoucherTodos(cDatos.EstablecimientoID.ToString(), periodo, desde, hasta, subDiarioId, cDatos.UsuarioID, 0, "", "", "", "", cDatos.HotelID) == false)
            {
                MessageBox.Show("No se eliminaron los vouchers.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                //limpia el grid
                btnAsientos_Click(sender, e);
                MessageBox.Show("Se eliminaron todos los vouchers.");
            }
            ;
        }
        else
        {
            MessageBox.Show("El subdiario no es automatico.");
        }

    }


    private void formatearGrid()
    {
        dgvAsientos.RowHeadersWidth = 10;
        //formato del grid de asientos
        dgvAsientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        dgvAsientos.Columns["NombreSubDiario"].HeaderText = "SubDiario";
        dgvAsientos.Columns["Comprobante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvAsientos.Columns["Dia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvAsientos.Columns["Dia"].DefaultCellStyle.Format = "d";
        dgvAsientos.Columns["HaberSoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvAsientos.Columns["DebeSoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvAsientos.Columns["SaldoSoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvAsientos.Columns["DebeDolares"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvAsientos.Columns["HaberDolares"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvAsientos.Columns["SaldoDolares"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    
        //FORMATEAR NUMEROS
        // antes el formatxo era C
        dgvAsientos.Columns["HaberSoles"].DefaultCellStyle.Format = "0.00";
        dgvAsientos.Columns["DebeSoles"].DefaultCellStyle.Format = "0.00";
        dgvAsientos.Columns["SaldoSoles"].DefaultCellStyle.Format = "0.00";
        //FORMATEAR NUMEROS DOLARES
        CultureInfo culture = new CultureInfo("en-US");
        culture.NumberFormat.CurrencyDecimalDigits = 2;
        //dgvAsientos.Columns["DebeDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
        //dgvAsientos.Columns["HaberDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
        //dgvAsientos.Columns["SaldoDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
        dgvAsientos.Columns["HaberDolares"].DefaultCellStyle.Format = "0.00";
        dgvAsientos.Columns["DebeDolares"].DefaultCellStyle.Format = "0.00";
        dgvAsientos.Columns["SaldoDolares"].DefaultCellStyle.Format = "0.00";

    }

    private void pnlButton_Paint(object sender, PaintEventArgs e)
    {

    }

    private void txtCuentaInicial_TextChanged(object sender, EventArgs e)
    {
        if (txtCuentaInicial.Text.Length > 0)
        {            //consulta de cuenta
            try
            {
                DataRow filaCta = objBLPlanCuenta.DatosCuenta(txtCuentaInicial.Text, cDatos.EstablecimientoID).Rows[0];

                lblCuentaInicial_ID.Text = Convert.ToString(filaCta["PlanCuentaID"]);
                lblCuentaInicial.Text = Convert.ToString(filaCta["NombrePlanCuenta"]);
            }
            catch
            {
                lblCuentaInicial_ID.Text = "";
                lblCuentaInicial.Text = "";
            }
        }
        else
        {
            lblCuentaInicial_ID.Text = "";
            lblCuentaInicial.Text = "";
        }
    }

    private void txtCuentaFinal_TextChanged(object sender, EventArgs e)
    {
        if (txtCuentaFinal.Text.Length > 0)
        {            //consulta de cuenta
            try
            {
                DataRow filaCta = objBLPlanCuenta.DatosCuenta(txtCuentaFinal.Text, cDatos.EstablecimientoID).Rows[0];

                lblCuentaFinal_ID.Text = Convert.ToString(filaCta["PlanCuentaID"]);
                lblCuentaFinal.Text = Convert.ToString(filaCta["NombrePlanCuenta"]);
            }
            catch
            {
                lblCuentaFinal_ID.Text = "";

                lblCuentaFinal.Text = "";
            }
        }
        else
        {
            lblCuentaFinal_ID.Text = "";
            lblCuentaFinal.Text = "";
        }
    }

    private void btnBuscarCtaInicial_Click(object sender, EventArgs e)
    {
        frmBuscarCuenta frmBuscador = new frmBuscarCuenta();

        frmBuscador.ShowDialog(this);

        txtCuentaInicial.Text = frmBuscador.pCodigoCuenta;
        
    }

    private void btnBuscarCtaFinal_Click(object sender, EventArgs e)
    {
        frmBuscarCuenta frmBuscador = new frmBuscarCuenta();

        frmBuscador.ShowDialog(this);

        txtCuentaFinal.Text = frmBuscador.pCodigoCuenta;
    }

    private void btnNuevo_Click(object sender, EventArgs e)
    {
        String subDiarioId = Convert.ToString(cbxSubdiario.SelectedValue);

        if (subDiarioId != "0")
        {
            
            frmRegistroAsientos _frmModificaAsiento = new frmRegistroAsientos(0, subDiarioId,true);

            //_frmModificaAsiento.Parent = this;

            _frmModificaAsiento.Text = "Crear Asiento | SubDiario: " + objBLAsientos.nombreSubDiario(subDiarioId);
            _frmModificaAsiento.StartPosition = FormStartPosition.CenterParent;
            _frmModificaAsiento.ShowDialog(this);
        }
        else
        {
            MessageBox.Show("Debe seleccionar un subdiario.");
        }

        btnAsientos_Click(sender, e);

    }

    private void groupBox2_Enter(object sender, EventArgs e)
    {

    }

    private void btnDesde_Click(object sender, EventArgs e)
    {
        //mover calfecha bajo txtdesde
        calFecha.Top = txtDesde.Bottom;
        calFecha.Left = txtDesde.Left;
        calFecha.Visible = !calFecha.Visible;
        calFecha.Tag = "Desde";
        calFecha.BringToFront();
    }

    private void btnHasta_Click(object sender, EventArgs e)
    {

        //mover calfecha bajo txthasta
        calFecha.Top = txtHasta.Bottom;
        calFecha.Left = txtHasta.Left;
        calFecha.Visible = !calFecha.Visible;
        calFecha.Tag = "Hasta";
        //Controls.SetChildIndex(calFecha, 1);
        calFecha.BringToFront();
        try
        {
            this.Controls.SetChildIndex(dgvAsientos, 2);
        }
        catch { }
    }

    private void calFecha_DateChanged(object sender, DateRangeEventArgs e)
    {
        if (calFecha.Tag.ToString() == "Desde")
        {
            txtDesde.Text = "";
            txtDesde.Text = calFecha.SelectionRange.Start.ToShortDateString();
            calFecha.Visible = false;
            txtDesde.Focus();
            txtDesde.SelectAll();
        }

        if (calFecha.Tag.ToString() == "Hasta")
        {
            txtHasta.Text = "";
            txtHasta.Text = calFecha.SelectionRange.Start.ToShortDateString();
            calFecha.Visible = false;
            txtHasta.Focus();
            txtHasta.SelectAll();
        }

    }

    private void btnExportarExcel_Click(object sender, EventArgs e)
    {
        //verificar en que pestaña se encuentra, según eso decide que exportar
        switch (tabVouchers.SelectedTab.Name)
        {
            case "tpDetalle":
                //exportar detalle
                try
                {
                    if (datosGrid.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay datos para exportar.");
                    }
                    else
                    {
                        exportarDetalleExcel();
                    }
                }
                catch
                {
                    MessageBox.Show("No hay datos para exportar.");
                }
                break;
            case "tpResumen":
                //exportar resumen
                try
                {
                    if (datosGrid.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay datos para exportar.");
                    }
                    else
                    {
                        exportarResumenExcel();
                    }
                }
                catch
                {
                    MessageBox.Show("No hay datos para exportar.");
                }
                    break;
        }
    }

    private void exportarDetalleExcel()
    {
        btnExportarExcel.Enabled = false;
        //datosGrid
        Excel.Application myApp;

        Excel.Workbook myWorkBk;

        object missingValue = System.Reflection.Missing.Value;

        myApp = new Microsoft.Office.Interop.Excel.Application();

        myApp.Visible = false;

        //myApp.Application.Calculation = Excel.XlCalculation.xlCalculationManual;

        myWorkBk = myApp.Workbooks.Add(missingValue);

        Excel.Worksheet myWorkSht;

        myWorkSht = (Excel.Worksheet)myWorkBk.Worksheets.get_Item(1);

        myWorkSht.Name = "Detalle";

        string fechaCortaDesde = Convert.ToDateTime(txtDesde.Text).ToShortDateString();
        string fechaCortaHasta = Convert.ToDateTime(txtHasta.Text).ToShortDateString();

        //myWorkSht.Cells[1, 1] = "Asientos del SubDiario " + cbxSubdiario.Text + " del " + fechaCortaDesde + " al " + dtpHasta1.Value.ToShortDateString();
        myWorkSht.Cells[1, 1] = "Asientos del SubDiario " + cbxSubdiario.Text + " del " + fechaCortaDesde + " al " + fechaCortaHasta;

        int filaIndex = 3;
        int columnaIndex = 1;
        int filaEncabezadosColumnas = 3;
        int filaInicioDatos = 4;

        string[] encabezados = { "Dia", "Comprobante", "Glosa", "HaberSoles", "DebeSoles", "SaldoSoles", "DebeDolares", "HaberDolares", "SaldoDolares" };


        foreach (string encabezado in encabezados)
                    {

                        myWorkSht.Cells[filaEncabezadosColumnas, columnaIndex] = encabezado;

                        columnaIndex = columnaIndex + 1;

                    }


        Excel.Range rango;

        //combinar las celdas del titulo del reporte
        rango = myWorkSht.Range[myWorkSht.Cells[1, 1], myWorkSht.Cells[1, columnaIndex-1]];
        rango.Merge();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.Font.Bold = true;
        //fin de combinar las celdas del titulo del reporte

        //combinar las celdas de los encabezados de columnas
        rango = myWorkSht.Range[myWorkSht.Cells[filaEncabezadosColumnas, 1], myWorkSht.Cells[filaEncabezadosColumnas, columnaIndex - 1]];
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.Font.Bold = true;
        //fin de combinar las celdas de los encabezados de columnas

        int columnaFinal = columnaIndex;

        filaIndex = filaIndex + 1;

        columnaIndex = 1;

       //seleccionar las columnas

        DataView vGrid = new DataView(datosGrid);
        
        string[] columnasSeleccionadas = {
                                           "Dia",
                                           "Comprobante",
                                           "Glosa",
                                           "HaberSoles",
                                           "DebeSoles",
                                           "SaldoSoles",
                                           "DebeDolares",
                                           "HaberDolares",
                                           "SaldoDolares"
                                         };

        DataTable tablaGrid = vGrid.ToTable(true, columnasSeleccionadas);

        //crear un array para obtener los datos de la Tabla
        object[,] arr = new object[tablaGrid.Rows.Count, tablaGrid.Columns.Count];

        //pasamos los datos de la tabla al array
        for (int r = 0; r < tablaGrid.Rows.Count; r++)
        {
            DataRow dr = tablaGrid.Rows[r];
            for (int c = 0; c < tablaGrid.Columns.Count; c++)
            {
                arr[r, c] = dr[c];
            }
        }

        //pasar datos a excel forma 2
        Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)myWorkSht.Cells[filaIndex, 1];

        Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)myWorkSht.Cells[filaIndex + tablaGrid.Rows.Count - 1, tablaGrid.Columns.Count];

        Microsoft.Office.Interop.Excel.Range range = myWorkSht.get_Range(c1, c2);

        //copiar el Array en Excel
        range.Value2 = arr;

        //formato de las celdas
        rango = myWorkSht.Range[myWorkSht.Cells[filaInicioDatos, 4], myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count - 1, tablaGrid.Columns.Count]];

        rango.NumberFormat = "0.00";

        //etiquetas de los totales
        rango = myWorkSht.Range[myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, 1], myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, 3]];

        rango.Merge();

        rango.Value = "Totales";
        
        rango.HorizontalAlignment = Excel.Constants.xlRight;

        rango.Font.Bold = true;
        //calcular totales de las columnas
        for (int i = 4; i <= (tablaGrid.Columns.Count); i++)
        {

            rango = myWorkSht.Range[myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, i], myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, i]];

            string letraCelda = getLetterFromNumberColumnExcel(i);

            rango.Value = "= SUMA(" + letraCelda + filaInicioDatos.ToString() + ":" + letraCelda + (filaInicioDatos + tablaGrid.Rows.Count - 1).ToString() + ")";

            rango.Font.Bold = true;

        }


        //pasar datos a excel forma 1

        //foreach (DataRow fila in tablaGrid.Rows)
        //{

        //    for (int contador = 0; contador <= tablaGrid.Columns.Count - 1; contador++)
        //    {

        //        myWorkSht.Cells[filaIndex, contador + 1] = fila[contador];
                
        //        if (contador > 0)
        //        {

        //            rango = myWorkSht.Range[myWorkSht.Cells[filaIndex, contador + 1], myWorkSht.Cells[filaIndex, contador + 1]];

        //            rango.NumberFormat = "0.00";

        //        }

        //    }

        //    filaIndex = filaIndex + 1;

        //}
        //fin de pasar datos a excel

        //autosize de las columna
        myWorkSht.Columns.AutoFit();


        myApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;

        //excel visible
        myApp.Visible = true;

        btnExportarExcel.Enabled = true;

    }

    private void exportarResumenExcel()
    {
        btnExportarExcel.Enabled = false;
        //datosGrid
        Excel.Application myApp;

        Excel.Workbook myWorkBk;

        object missingValue = System.Reflection.Missing.Value;

        myApp = new Microsoft.Office.Interop.Excel.Application();

        myApp.Visible = false;

        //myApp.Application.Calculation = Excel.XlCalculation.xlCalculationManual;

        myWorkBk = myApp.Workbooks.Add(missingValue);

        Excel.Worksheet myWorkSht;

        myWorkSht = (Excel.Worksheet)myWorkBk.Worksheets.get_Item(1);

        myWorkSht.Name = "Resumen";

        //myWorkSht.Cells[1, 1] = "Consolidado del SubDiario " + cbxSubdiario.Text + " del " + dtpDesde1.Value.ToShortDateString() + " al " + dtpHasta1.Value.ToShortDateString();

        string fechaCortaDesde = Convert.ToDateTime(txtDesde.Text).ToShortDateString();
        string fechaCortaHasta = Convert.ToDateTime(txtHasta.Text).ToShortDateString();

        myWorkSht.Cells[1, 1] = "Consolidado del SubDiario " + cbxSubdiario.Text + " del " + fechaCortaDesde + " al " + fechaCortaHasta;

        int filaIndex = 3;
        int columnaIndex = 1;
        int filaEncabezadosColumnas = 3;
        int filaInicioDatos = 4;
        int columnaTotales = 3;

        string[] encabezados = { "Codigo", "Descripción", "DebeSoles", "HaberSoles", "SaldoSoles", "DebeDolares", "HaberDolares", "SaldoDolares" };


        foreach (string encabezado in encabezados)
        {

            myWorkSht.Cells[filaEncabezadosColumnas, columnaIndex] = encabezado;

            columnaIndex = columnaIndex + 1;

        }


        Excel.Range rango;

        //combinar las celdas del titulo del reporte
        rango = myWorkSht.Range[myWorkSht.Cells[1, 1], myWorkSht.Cells[1, columnaIndex - 1]];
        rango.Merge();
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.Font.Bold = true;
        //fin de combinar las celdas del titulo del reporte

        //combinar las celdas de los encabezados de columnas
        rango = myWorkSht.Range[myWorkSht.Cells[filaEncabezadosColumnas, 1], myWorkSht.Cells[filaEncabezadosColumnas, columnaIndex - 1]];
        rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        rango.Font.Bold = true;
        //fin de combinar las celdas de los encabezados de columnas

        int columnaFinal = columnaIndex;

        filaIndex = filaIndex + 1;

        columnaIndex = 1;

        //seleccionar las columnas

        DataView vGrid = new DataView(tablaResumen);

        string[] columnasSeleccionadas = {
                                           "CodigoPlanCuenta",
                                           "NombrePlanCuenta",
                                           "DebeSoles",
                                           "HaberSoles",                                           
                                           "SaldoSoles",
                                           "DebeDolares",
                                           "HaberDolares",
                                           "SaldoDolares"
                                         };

        DataTable tablaGrid = vGrid.ToTable(true, columnasSeleccionadas);

        //crear un array para obtener los datos de la Tabla
        object[,] arr = new object[tablaGrid.Rows.Count, tablaGrid.Columns.Count];

        //pasamos los datos de la tabla al array
        for (int r = 0; r < tablaGrid.Rows.Count; r++)
        {
            DataRow dr = tablaGrid.Rows[r];
            for (int c = 0; c < tablaGrid.Columns.Count; c++)
            {
                arr[r, c] = dr[c];
            }
        }

        //pasar datos a excel forma 2
        Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)myWorkSht.Cells[filaIndex, 1];

        Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)myWorkSht.Cells[filaIndex + tablaGrid.Rows.Count - 1, tablaGrid.Columns.Count];

        Microsoft.Office.Interop.Excel.Range range = myWorkSht.get_Range(c1, c2);

        //copiar el Array en Excel
        range.Value2 = arr;

        //formato de las celdas
        rango = myWorkSht.Range[myWorkSht.Cells[filaInicioDatos, columnaTotales], myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count - 1, tablaGrid.Columns.Count]];

        rango.NumberFormat = "0.00";

        //etiquetas de los totales
        rango = myWorkSht.Range[myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, 1], myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, columnaTotales - 1]];

        rango.Merge();

        rango.Value = "Totales";

        rango.HorizontalAlignment = Excel.Constants.xlRight;

        rango.Font.Bold = true;
        //calcular totales de las columnas
        for (int i = columnaTotales; i <= (tablaGrid.Columns.Count); i++)
        {

            rango = myWorkSht.Range[myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, i], myWorkSht.Cells[filaInicioDatos + tablaGrid.Rows.Count, i]];

            string letraCelda = getLetterFromNumberColumnExcel(i);

            rango.Value = "= SUMA(" + letraCelda + filaInicioDatos.ToString() + ":" + letraCelda + (filaInicioDatos + tablaGrid.Rows.Count - 1).ToString() + ")";

            rango.Font.Bold = true;

        }


        //pasar datos a excel forma 1

        //foreach (DataRow fila in tablaGrid.Rows)
        //{

        //    for (int contador = 0; contador <= tablaGrid.Columns.Count - 1; contador++)
        //    {

        //        myWorkSht.Cells[filaIndex, contador + 1] = fila[contador];

        //        if (contador > 0)
        //        {

        //            rango = myWorkSht.Range[myWorkSht.Cells[filaIndex, contador + 1], myWorkSht.Cells[filaIndex, contador + 1]];

        //            rango.NumberFormat = "0.00";

        //        }

        //    }

        //    filaIndex = filaIndex + 1;

        //}
        //fin de pasar datos a excel

        //autosize de las columna
        myWorkSht.Columns.AutoFit();


        myApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;

        //excel visible
        myApp.Visible = true;

        btnExportarExcel.Enabled = true;

    }

    private string getLetterFromNumberColumnExcel(int columnNumber)
    {

        int dividend = columnNumber;
        string columnName = String.Empty;
        int modulo;

        while (dividend > 0)
        {
            modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
            dividend = (int)((dividend - modulo) / 26);
        }

        return columnName;
    }

    private void Control_Recibe_Foco(object sender, EventArgs e)
    {

        Control objeto = (Control)sender;

        try
        {
            TextBox caja = (TextBox)objeto;
            caja.SelectAll();
        }
        catch
        {
            try
            {
                ComboBox combo = (ComboBox)objeto;
                combo.SelectAll();
            }
            catch
            {
                try
                {
                    MaskedTextBox maskedText = (MaskedTextBox)objeto;
                    //maskedText.SelectAll();
                    //no funciona el SelectAll, debe utilizarse un delegado
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        maskedText.SelectAll();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }

    private void mtxtFecha_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            try
            {
                Control parent = ((TextBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
            catch
            {
                Control parent = ((MaskedTextBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }


    private void mtxtFecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    //private void button1_Click(object sender, EventArgs e)
    //{
    //    String subDiarioId = Convert.ToString(cbxSubdiario.SelectedValue);

    //    if (subDiarioId != "0")
    //    {

    //        frmRegistroAsientosV2 _frmModificaAsiento = new frmRegistroAsientosV2(0, subDiarioId, true);

    //        _frmModificaAsiento.Text = "Crear Asiento | SubDiario: " + objBLAsientos.nombreSubDiario(subDiarioId);
    //        _frmModificaAsiento.ShowDialog();
    //    }
    //    else
    //    {
    //        MessageBox.Show("Debe seleccionar un subdiario.");
    //    }
    //}
  }
}
