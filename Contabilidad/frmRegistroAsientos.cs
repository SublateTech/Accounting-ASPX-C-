using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using System.Globalization;
using System.Configuration;


namespace Contabilidad
{
    public partial class frmRegistroAsientos : Form, iForm
    {
        BLPlanCuenta objCuentas;
        BLMoneda objMonedas;
        BLDocumentos objDocumentos;
        BLHotel objHotel;
        BLEmpresa objEmpresa;
        BLAsientos objAsiento;

        //variable de paso de cuentas
        public static string pCodigoCuenta;
        //tabla interna detalle
        private DataTable tablaDetalle;
        //tabla interna detalleTransferencia
        private DataTable tablaDetalleTransferencia;

        private int asientoContableId;
        string subDiarioId;

        bool nuevo;

        DataGridView grid=new DataGridView();

        //variable para hacer seguimientos a cambios en el asiento
        bool seModifico = false;

        //parametro que indica si la carga del asiento ya está completa
        bool asientoCargado = false;
        
        
        public frmRegistroAsientos(int _asientoContableId, string _subDiarioId,bool _nuevo)
        {

            InitializeComponent();
            
            objCuentas = new BLPlanCuenta();
            objMonedas = new BLMoneda();
            objDocumentos = new BLDocumentos();
            objHotel = new BLHotel();
            objEmpresa = new BLEmpresa();
            objAsiento = new BLAsientos();

            CrearDetalle();
            CargarDetalle();

            asientoContableId = _asientoContableId;
            subDiarioId = _subDiarioId;
            nuevo = _nuevo;

            

        }

        public void cambiarTexto(string texto)
        {
            txtCuenta.Text = texto;
        }

        public void cambiarTextoRUC(string texto)
        {
            txtEmpresa.Text = texto;
        }

        private void frmRegistroAsientos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (btnCancelar.Enabled == true)
                {
                    btnCancelar_Click(sender, e);
                }

                if (btnCancelarActualizarDetalle.Enabled == true)
                {
                    btnCancelarActualizarDetalle_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F5)
            {
                btnActualizarDetalle_Click(sender, e);
            }

            if (e.KeyCode == Keys.F6)
            {
                btnAgregar_Click_1(sender, e);
            }

            if (e.KeyCode == Keys.F7)
            {
                btnFinalizar_Click(sender, e);
            }

        }
        
        private void frmRegistroAsientos_Load(object sender, EventArgs e)
        {
            //inicio de codigo para el campo de fechas
            mtxtFecha.Mask = "00/00/0000";
            mtxtFecha.ValidatingType = typeof(System.DateTime);
            mtxtFecha.TypeValidationCompleted += new TypeValidationEventHandler(mtxtFecha_TypeValidationCompleted);
            mtxtFecha.KeyPress += new KeyPressEventHandler(mtxtFecha_KeyPress);
            mtxtFecha.KeyDown += new KeyEventHandler(mtxtFecha_KeyDown);

            mtxtFechaEmision.Mask = "00/00/0000";
            mtxtFechaEmision.ValidatingType = typeof(System.DateTime);
            mtxtFechaEmision.TypeValidationCompleted += new TypeValidationEventHandler(mtxtFechaEmision_TypeValidationCompleted);
            mtxtFechaEmision.KeyPress += new KeyPressEventHandler(mtxtFechaEmision_KeyPress);
            mtxtFechaEmision.KeyDown += new KeyEventHandler(mtxtFechaEmision_KeyDown);

            mtxtFechaVencimiento.Mask = "00/00/0000";
            mtxtFechaVencimiento.ValidatingType = typeof(System.DateTime);
            mtxtFechaVencimiento.TypeValidationCompleted += new TypeValidationEventHandler(mtxtFechaVencimiento_TypeValidationCompleted);
            mtxtFechaVencimiento.KeyPress += new KeyPressEventHandler(mtxtFechaVencimiento_KeyPress);
            mtxtFechaVencimiento.KeyDown += new KeyEventHandler(mtxtFechaVencimiento_KeyDown);

            //ttMensajes.IsBalloon = true;
            //fin de codigo para el campo de fechas
          
            //mtxtFecha.ValidatingType = typeof(DateTime);
            txtDebe.Text = "0.00";
            txtHaber.Text = "0.00";
            txtTipoCambio.Text = "0.00";
            //cargar combos
            loadCombos();

            if (asientoContableId == 0)
            {//nuevo asiento
                lblComprobante.Visible = false;
                txtComprobante.Visible = false;
                //mtxtFecha.ValidatingType = typeof(DateTime);
                txtDebe.Text = "0.00";
                txtHaber.Text = "0.00";
                txtTipoCambio.Text = "0.00";
                //cargar combos
                loadCombos();
            }
            else
            {//modificar asiento
                lblComprobante.Visible = true;
                txtComprobante.Visible = true;
                //cargar datos del asiento
                //CARGAR LA CABECERA, EL DETALLE y el AUN
                cargarAsientoParaEditar();
                //bgWorker.RunWorkerAsync();
                //do
                //{
                //    Application.DoEvents();
                //}while(asientoCargado==false);
            }


            //cargar moneda y tipo de conversion
            cboMoneda.SelectedValue=ConfigurationManager.AppSettings["PRA_MonedaId"];

            cboTipoConversion.SelectedValue = ConfigurationManager.AppSettings["PRA_TipoConversionId"];

            cboArea.DropDown += cboMoneda_DropDown;
            
        }

        private void mtxtFecha_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                //ttMensajes.ToolTipTitle = "Fecha Inválida";
                //ttMensajes.Show("Los datos que debe ingresar deben ser una fecha válida en el formato dd/mm/yyyy.", mtxtFecha, 0, -20, 5000);
                mtxtFecha.SelectAll();
                e.Cancel = true;
            }
           
        }

        private void mtxtFechaEmision_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                //ttMensajes.ToolTipTitle = "Fecha Inválida";
                //ttMensajes.Show("Los datos que debe ingresar deben ser una fecha válida en el formato dd/mm/yyyy.", mtxtFechaEmision, 0, -20, 5000);
                mtxtFechaEmision.SelectAll();
                e.Cancel = true;
            }
           
        }

        private void mtxtFechaVencimiento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                //ttMensajes.ToolTipTitle = "Fecha Inválida";
                //ttMensajes.Show("Los datos que debe ingresar deben ser una fecha válida en el formato dd/mm/yyyy.", mtxtFechaEmision, 0, -20, 5000);
                mtxtFechaVencimiento.SelectAll();
                e.Cancel = true;
            }
         
        }

        // Oculta el tooltipo si el usuario empieza a escribir otra vez antes que el límite de tiempo expire. 
        private void mtxtFecha_KeyDown(object sender, KeyEventArgs e)
        {
            //ttMensajes.Hide(mtxtFecha);
        }

        private void mtxtFechaEmision_KeyDown(object sender, KeyEventArgs e)
        {
            //ttMensajes.Hide(mtxtFechaEmision);
        }

        private void mtxtFechaVencimiento_KeyDown(object sender, KeyEventArgs e)
        {
            //ttMensajes.Hide(mtxtFechaVencimiento);
        }

        private void cargarAsientoParaEditar()
        {
            //limpiar los datos

            //DATOS DEL ASIENTO
            
            DataSet datosAsientoEditar = objAsiento.AsientoContable_Listar(asientoContableId.ToString(),cDatos.EstablecimientoID.ToString(),cDatos.Periodo.ToString());
            
            datosAsientoEditar.Tables[0].TableName = "cabecera";
            DataTable dt_cabecera = datosAsientoEditar.Tables[0];
            datosAsientoEditar.Tables[1].TableName = "detalle";
            DataTable dt_detalle = datosAsientoEditar.Tables[1];
            datosAsientoEditar.Tables[2].TableName = "transferencia";
            DataTable dt_transferencia = datosAsientoEditar.Tables[2];
            datosAsientoEditar.Tables[3].TableName = "unidades";
            DataTable dt_unidades = datosAsientoEditar.Tables[3];
            //CABECERA
            DataRow filaCB = dt_cabecera.Rows[0];
            //aqui hay que cambiar
            txtGlosa.Text = (String)filaCB["Glosa"];
            txtComprobante.Text = (String)filaCB["Comprobante"];
            mtxtFecha.Text = ((DateTime)filaCB["Dia"]).ToShortDateString();
            int valorBloqueado = 0;
            try {
                valorBloqueado = Convert.ToInt32(filaCB["Bloqueado"]);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                valorBloqueado = 0;
            }
            
            switch (valorBloqueado)
            {
                case 0:
                    chkBloqueado.Checked=false;
                    break;
                case 2:
                    chkBloqueado.Checked=true;
                    break;
            }
            subDiarioId = Convert.ToString(filaCB["SubDiarioId"]);
            //DETALLE
            //limpiar la tabla detalle
            tablaDetalle.Rows.Clear();
            //cargar las filas
            
            foreach (DataRow filaDT in dt_detalle.Rows)
            {
                //if (Convert.ToString(filaDT["AsientoContableDetalleIDTransferencia"]) == "0")
                //{
                //crea nueva fila en la tabla Detalle
                DataRow nuevafilaDT = tablaDetalle.NewRow();
                nuevafilaDT["DetalleId"] = filaDT["DetalleId"];
                nuevafilaDT["MontoDebe"] = filaDT["MontoDebe"];
                nuevafilaDT["MontoHaber"] = filaDT["MontoHaber"];
                nuevafilaDT["DebeSoles"] = filaDT["DebeSoles"];
                nuevafilaDT["HaberSoles"] = filaDT["HaberSoles"];
                nuevafilaDT["DebeDolares"] = filaDT["DebeDolares"];
                nuevafilaDT["HaberDolares"] = filaDT["HaberDolares"];
                nuevafilaDT["CanalContableID"] = filaDT["CanalContableID"];
                nuevafilaDT["CanalContable"] = filaDT["CanalContable"];
                nuevafilaDT["EmpresaID"] = filaDT["EmpresaID"];
                nuevafilaDT["Empresa"] = filaDT["Empresa"];
                nuevafilaDT["RUC"] = filaDT["RUC"];
                nuevafilaDT["TipoDocumentoID"] = filaDT["TipoDocumentoID"];
                nuevafilaDT["TipoDocumento"] = filaDT["TipoDocumento"];
                nuevafilaDT["ProyectoID"] = filaDT["ProyectoID"];
                nuevafilaDT["Proyecto"] = filaDT["Proyecto"];
                nuevafilaDT["Dia"] = filaDT["Dia"];
                nuevafilaDT["Referencia"] = filaDT["Referencia"];
                nuevafilaDT["FechaEmision"] = filaDT["FechaEmision"];
                nuevafilaDT["FechaVencimiento"] = filaDT["FechaVencimiento"];
                nuevafilaDT["AreaID"] = filaDT["AreaID"];
                nuevafilaDT["Area"] = filaDT["Area"];
                nuevafilaDT["NumeroDocumento"] = filaDT["NumeroDocumento"];
                nuevafilaDT["FlujoCajaID"] = filaDT["FlujoCajaID"];
                nuevafilaDT["FlujoCaja"] = filaDT["FlujoCaja"];
                nuevafilaDT["PlanCuentaID"] = filaDT["PlanCuentaID"];
                nuevafilaDT["PlanCuenta"] = filaDT["PlanCuenta"];
                nuevafilaDT["PlanCuentaCodigo"] = filaDT["PlanCuentaCodigo"];
                nuevafilaDT["MonedaID"] = filaDT["MonedaID"];
                nuevafilaDT["Moneda"] = filaDT["Moneda"];
                nuevafilaDT["TipoCambio"] = filaDT["TipoCambio"];
                nuevafilaDT["ImporteSoles"] = filaDT["ImporteSoles"];
                nuevafilaDT["ImporteDolares"] = filaDT["ImporteDolares"];
                nuevafilaDT["PeriodoID"] = filaDT["PeriodoID"];
                nuevafilaDT["TipoConversionMonedaID"] = filaDT["TipoConversionMonedaID"];
                nuevafilaDT["TipoConversionMoneda"] = filaDT["TipoConversionMoneda"];
                nuevafilaDT["AsientoContableDetalleIDTransferencia"] = filaDT["AsientoContableDetalleIDTransferencia"];
                try
                {
                    nuevafilaDT["DetalleNuevo"] = 0;
                    nuevafilaDT["DetalleEliminado"] = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    //CARGAR DATOS DE LAS UNIDADES DE NEGOCIOS
                DataView dvUnidades = dt_unidades.AsDataView();
                String filtro;
                filtro = "AsientoContableDetalleId = '" + filaDT["DetalleId"].ToString() + "'";
                try
                {
                    dvUnidades.RowFilter = filtro;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar las unidades de negocios: " + ex.Message);
                }
                
                int cont_unidad = 0;

                //cont_unidad = cont_unidad + 1;
                
                foreach (DataRowView filaUN in dvUnidades)
                {
                    string numero = cDatos.Right("00" + (cont_unidad + 1).ToString().Trim(), 2);
                    Int32 unNegId = 0;
                    Decimal importe_Soles = 0;
                    Decimal importe_Dolares = 0;
                    unNegId = Convert.ToInt32(filaUN["UnidadNegocioID"]);
                    importe_Soles = Convert.ToDecimal(filaUN["ImporteSoles"]);
                    importe_Dolares = Convert.ToDecimal(filaUN["ImporteDolares"]);
                    String nombre_campo = "";
                    nombre_campo = "UnidadNegocio_" + numero + "_ID";
                    nuevafilaDT[nombre_campo] = unNegId;
                    nombre_campo="UnidadNegocio_" + numero + "_ImporteSoles";
                    nuevafilaDT[nombre_campo] = importe_Soles;
                    nombre_campo = "UnidadNegocio_" + numero + "_ImporteDolares";
                    nuevafilaDT[nombre_campo] = importe_Dolares;
                    
                    cont_unidad = cont_unidad + 1;
                }
                
                tablaDetalle.Rows.Add(nuevafilaDT);
                //finaliza crear nueva fila en tabla Detalle
                //}
            }
            //----------------------------------------
            //TRANSFERENCIA
            //limpiar datos de transferencia
            tablaDetalleTransferencia.Rows.Clear();
            //cargar las filas
            foreach (DataRow filaDT in dt_transferencia.Rows)
            {
                //if (Convert.ToString(filaDT["AsientoContableDetalleIDTransferencia"]) == "0")
                //{
                //crea nueva fila en la tabla Transferencia
                DataRow nuevafilaDT = tablaDetalleTransferencia.NewRow();
                nuevafilaDT["DetalleId"] = filaDT["DetalleId"];
                nuevafilaDT["MontoDebe"] = filaDT["MontoDebe"];
                nuevafilaDT["MontoHaber"] = filaDT["MontoHaber"];
                nuevafilaDT["DebeSoles"] = filaDT["DebeSoles"];
                nuevafilaDT["HaberSoles"] = filaDT["HaberSoles"];
                nuevafilaDT["DebeDolares"] = filaDT["DebeDolares"];
                nuevafilaDT["HaberDolares"] = filaDT["HaberDolares"];
                nuevafilaDT["CanalContableID"] = filaDT["CanalContableID"];
                nuevafilaDT["CanalContable"] = filaDT["CanalContable"];
                nuevafilaDT["EmpresaID"] = filaDT["EmpresaID"];
                nuevafilaDT["Empresa"] = filaDT["Empresa"];
                nuevafilaDT["RUC"] = filaDT["RUC"];
                nuevafilaDT["TipoDocumentoID"] = filaDT["TipoDocumentoID"];
                nuevafilaDT["TipoDocumento"] = filaDT["TipoDocumento"];
                nuevafilaDT["ProyectoID"] = filaDT["ProyectoID"];
                nuevafilaDT["Proyecto"] = filaDT["Proyecto"];
                nuevafilaDT["Dia"] = filaDT["Dia"];
                nuevafilaDT["Referencia"] = filaDT["Referencia"];
                nuevafilaDT["FechaEmision"] = filaDT["FechaEmision"];
                nuevafilaDT["FechaVencimiento"] = filaDT["FechaVencimiento"];
                nuevafilaDT["AreaID"] = filaDT["AreaID"];
                nuevafilaDT["Area"] = filaDT["Area"];
                nuevafilaDT["NumeroDocumento"] = filaDT["NumeroDocumento"];
                nuevafilaDT["FlujoCajaID"] = filaDT["FlujoCajaID"];
                nuevafilaDT["FlujoCaja"] = filaDT["FlujoCaja"];
                nuevafilaDT["PlanCuentaID"] = filaDT["PlanCuentaID"];
                nuevafilaDT["PlanCuenta"] = filaDT["PlanCuenta"];
                nuevafilaDT["PlanCuentaCodigo"] = filaDT["PlanCuentaCodigo"];
                nuevafilaDT["MonedaID"] = filaDT["MonedaID"];
                nuevafilaDT["Moneda"] = filaDT["Moneda"];
                nuevafilaDT["TipoCambio"] = filaDT["TipoCambio"];
                nuevafilaDT["ImporteSoles"] = filaDT["ImporteSoles"];
                nuevafilaDT["ImporteDolares"] = filaDT["ImporteDolares"];
                nuevafilaDT["PeriodoID"] = filaDT["PeriodoID"];
                nuevafilaDT["TipoConversionMonedaID"] = filaDT["TipoConversionMonedaID"];
                nuevafilaDT["TipoConversionMoneda"] = filaDT["TipoConversionMoneda"];
                nuevafilaDT["AsientoContableDetalleIDTransferencia"] = filaDT["AsientoContableDetalleIDTransferencia"];
                //CARGAR DATOS DE LAS UNIDADES DE NEGOCIOS
                DataView dvUnidades = dt_unidades.AsDataView();
                String filtro;
                filtro = "AsientoContableDetalleId = '" + filaDT["DetalleId"].ToString() + "'";
                try
                {
                    dvUnidades.RowFilter = filtro;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las unidades de negocios: " + ex.Message);
                }

                int cont_unidad = 0;
                //cont_unidad = cont_unidad + 1;
                foreach (DataRow filaUN in dvUnidades)
                {
                    string numero = cDatos.Right("00" + (cont_unidad + 1).ToString().Trim(), 2);
                    nuevafilaDT["UnidadNegocio_" + numero + "_ID"] = filaUN["UnidadNegocioID"];
                    nuevafilaDT["UnidadNegocio_" + numero + "_ImporteSoles"] = filaDT["ImporteSoles"];
                    nuevafilaDT["UnidadNegocio_" + numero + "_ImporteDolares"] = filaDT["ImporteDolares"];
                    cont_unidad = cont_unidad + 1;
                }

                tablaDetalleTransferencia.Rows.Add(nuevafilaDT);
                //finaliza crear nueva fila en tabla Transferencia
                //}
            }

            
            //calcular totales
            calcularTotales();
            //formatoGridDetalle();
            //DateTime Inicio = DateTime.Now;
            //DETALLE
            formatoGrid(1);
            //formatoGridTransferencias();
            //TRANSFERENCIAS
            formatoGrid(2);

            //DateTime Fin = DateTime.Now;
            //TimeSpan ts = new TimeSpan(Fin.Ticks - Inicio.Ticks);
            //MessageBox.Show("Demoró: " + ts.Seconds.ToString() + " segundos.");

        }

        public static void SetComboScrollWidth(object sender)
        {
            try
            {
                ComboBox senderComboBox = (ComboBox)sender;
                int width = senderComboBox.Width;
                Graphics g = senderComboBox.CreateGraphics();
                Font font = senderComboBox.Font;

                //checks if a scrollbar will be displayed.
                //If yes, then get its width to adjust the size of the drop down list.
                int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

                //Loop through list items and check size of each items.
                //set the width of the drop down list to the width of the largest item.

                int newWidth;
                foreach (string s in ((ComboBox)sender).Items)
                {
                    if (s != null)
                    {
                        newWidth = (int)g.MeasureString(s.Trim(), font).Width
                        + vertScrollBarWidth;
                        if (width < newWidth)
                        {
                            width = newWidth;
                        }
                    }
                }
                senderComboBox.DropDownWidth = width;
            }
            catch (Exception objException)
            {

                //Catch objException
                MessageBox.Show(objException.Message);
                
            }
        }     

        private void txtFechaEmision_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaEmision_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFechaEmision_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            try
            {
                DateTime lafecha;
                TextBox caja = (TextBox)sender;
                if (DateTime.TryParse(caja.Text, out lafecha) == true)
                {
                    return;    
                }
                

                if (tb.Text.Length != 8)
                {
                    DateTime fsal;
                    if (DateTime.TryParse(tb.Text, out fsal) == false)
                    {
                        MessageBox.Show("La fecha ingresada no es válida.");
                        tb.Focus();
                        return;
                    }

                }

                tb.Text = formatoFecha(tb.Text);

              

                if ((cboTipoConversion.SelectedValue != null) && (cboMoneda.SelectedValue != null))
                {
                    //si se ha seleccionado algo en la moneda y el tipo de conversión 

                }
                
                //DateTime fecha1 = Convert.ToDateTime(tb.Text);
 
            }

            catch
            {
                MessageBox.Show("La fecha ingresada no es válida.");
                tb.Focus();
            }
            
        }

        private void txtFechaEmision_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //buscar la cuenta
                if (buscarCuentaCodigo(txtCuenta.Text) == true) 
                {
                    //pasa al campo siguiente...
                    Control parent = ((TextBox)sender).Parent;
                    parent.SelectNextControl(ActiveControl, true, true, true, true);

                }
            }
        }

        private bool buscarCuentaCodigo(string codigoCuenta) 
        {
            objCuentas = new BLPlanCuenta();            
            lblNombreCuenta.Text=objCuentas.NombreCuenta(codigoCuenta,cDatos.EstablecimientoID);
            
            if (lblNombreCuenta.Text.Trim().Length == 0 )
            {
                txtCuenta.SelectAll();
                lblPlanCuentaID.Text = "";
               frmBuscarCuenta buscador = new frmBuscarCuenta();
                buscador.pCodigoCuenta = txtCuenta.Text;
                buscador.ShowDialog();
                txtCuenta.Text = buscador.pCodigoCuenta;
                
                //txtCuenta.Text = "";
 
                txtCuenta.SelectAll();
                txtCuenta.Focus();
                if (buscador.cancelo_formulario == false)
                { SendKeys.Send("{ENTER}"); }
                  

                    return false;
            }
            else
            { 
                //mostrar los campos obligatorios
                txtReferencia.Visible = true;
                txtReferencia.Text = lblNombreCuenta.Text;
                txtDebe.Visible = true;
                txtHaber.Visible = true;
                cboMoneda.Visible = true;
                cboTipoConversion.Visible=true;
                txtTipoCambio.Visible = true;
                //montos debe y haber a cero
                //txtDebe.Text = "0.00";
                //txtHaber.Text = "0.00";
            //recuperar datos de la cuenta
                DataTable datos = objCuentas.DatosCuenta(codigoCuenta,cDatos.EstablecimientoID);
                DataRow fila = datos.Rows[0];


                if (fila["PlanCuentaID"] == null)
                {
                    MessageBox.Show("Error en el código de cuenta.");
                    return false;
                }

                lblPlanCuentaID.Text = Convert.ToString(fila["PlanCuentaID"]);
                
                bool RequiereArea=Convert.ToBoolean(fila["RequiereArea"]);
                bool RequiereCanal = Convert.ToBoolean(fila["RequiereCanal"]);
                bool RequiereProyecto = Convert.ToBoolean(fila["RequiereProyecto"]);
                bool RequiereFechaVcto = Convert.ToBoolean(fila["RequiereFechaVencimiento"]);
                bool RequiereDocumento = Convert.ToBoolean(fila["RequiereDocumento"]);
                bool RequiereFlujoCaja = Convert.ToBoolean(fila["RequiereFlujoCaja"]);
                //limpio el grid de unidades de negocios
                //dgvAreas.Rows.Clear();
                cboArea.SelectedValue = "0";
                //opciones de requiere
                if (RequiereArea == true)
                {
                    cboArea.Visible = true;
                    dgvAreas.Visible = true;
                    lblDifUnd.Visible = true;
                    lblDiferencia.Visible = true;
                    btnAjustar.Visible = true;
                }
                else
                {
                    cboArea.Visible = false;
                    dgvAreas.Visible = false;
                    //cboArea.DataSource = null;
                    dgvAreas.DataSource = null;
                    lblDifUnd.Visible = false;
                    lblDiferencia.Visible = false;
                    btnAjustar.Visible = false;
                }

                cboCanalContable.SelectedValue = "0";
                if (RequiereCanal == true)
                {
                    cboCanalContable.Visible = true;
                }
                else
                {
                    cboCanalContable.Visible = false;
                }

                cboProyecto.SelectedValue = "0";
                
                if (RequiereProyecto == true)
                {
                    cboProyecto.Visible = true;
                }
                else
                {
                    cboProyecto.Visible = false;
                }
                //limpio fecha de vencimiento
                mtxtFechaVencimiento.Text = "";
                if (RequiereFechaVcto == true)
                {
                    mtxtFechaVencimiento.Visible = true;
                }
                else
                {
                    mtxtFechaVencimiento.Visible = false;
                }
                //limpio fecha de emision, tipo documento, documento y empresa
                cboTipoDocumento.SelectedValue = 0;
                mtxtFechaEmision.Text = "";
                txtDocumento.Text = "";
                txtEmpresa.Text = "";
                lblEmpresaID.Text = "";
                lblRazonSocialEmpresa.Text = "";
                
                if (RequiereDocumento == true)
                {
                    cboTipoDocumento.Visible = true;
                    mtxtFechaEmision.Visible = true;
                    txtDocumento.Visible = true;
                    txtEmpresa.Visible = true;
                    btnBuscarEmpresa.Visible = true;
                    lblRazonSocialEmpresa.Visible = true;
                }
                else
                {
                    cboTipoDocumento.Visible = false;
                    mtxtFechaEmision.Visible = false;
                    txtDocumento.Visible = false;
                    txtEmpresa.Visible = false;
                    btnBuscarEmpresa.Visible = false;
                    lblRazonSocialEmpresa.Visible = false;
                }

                cboFlujoCaja.SelectedValue = "0";

                if (RequiereFlujoCaja == true)
                {
                    cboFlujoCaja.Visible = true;
                }
                else
                {
                    cboFlujoCaja.Visible = false;
                }

                return true;
                
            }
           
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtReferencia.Text.Trim().Length > 0)
                {
                    //pasa al campo siguiente...
                    Control parent = ((TextBox)sender).Parent;
                    parent.SelectNextControl(ActiveControl, true, true, true, true);
                }
                else 
                {
                    MessageBox.Show("El campo Referencia es obligatorio.");
                    txtReferencia.Focus();
                }
                
               
            }
        }

        private void txtDebe_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            decimal valor;
            if (Decimal.TryParse(txtDebe.Text, out valor) == true)
            {
                if (valor > 0)
                {
                    txtHaber.Text = "0.00";
                    txtHaber.Enabled = false;
                }
                else
                {
                    txtHaber.Enabled = true;
                }
            }
            

            if (e.KeyChar == (char)Keys.Enter)
            {

                //pasa al campo siguiente...
                Control parent = ((TextBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        private void txtHaber_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            decimal valor;
            if (Decimal.TryParse(txtHaber.Text, out valor) == true)
            {
                if (valor > 0)
                {
                    txtDebe.Text = "0.00";
                    txtDebe.Enabled = false;
                }
                else
                {
                    txtDebe.Enabled = true;
                }
            }


            if (e.KeyChar == (char)Keys.Enter)
            {

                //pasa al campo siguiente...
                Control parent = ((TextBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        private void loadCombos() 
        {
            DataTable tabla = new DataTable();
            //moneda
            tabla = objMonedas.getMoneda();
            DataRow fila = tabla.NewRow();
            fila["monedaid"] = 0;
            tabla.Rows.Add(fila);
            DataView datos = new DataView(tabla, "", "monedaid ASC", DataViewRowState.CurrentRows);
            this.cboMoneda.DataSource = datos;
            this.cboMoneda.DisplayMember = "Nombre";
            this.cboMoneda.ValueMember = "monedaid";
            //tipo conversion
            tabla = objMonedas.getTipoConversion();
            fila = tabla.NewRow();
            fila["TipoConversionMonedaID"] = 0;
            tabla.Rows.Add(fila);
            datos = new DataView(tabla, "", "TipoConversionMonedaID ASC", DataViewRowState.CurrentRows);
            this.cboTipoConversion.DataSource = datos;
            this.cboTipoConversion.DisplayMember = "TipoConversion";
            this.cboTipoConversion.ValueMember = "TipoConversionMonedaID";
            //proyecto
            tabla = objHotel.getProyectos();
            fila = tabla.NewRow();
            fila["ProyectoID"] = 0;
            tabla.Rows.Add(fila);
            datos = new DataView(tabla, "", "ProyectoID ASC", DataViewRowState.CurrentRows);
            this.cboProyecto.DataSource = datos;
            this.cboProyecto.DisplayMember = "NombreProyecto";
            this.cboProyecto.ValueMember = "ProyectoID";
            //canal contable
            tabla = objCuentas.getCanalesContables();
            fila = tabla.NewRow();
            fila["CanalContableID"] = "";
            tabla.Rows.Add(fila);
            datos = new DataView(tabla, "", "CanalContableID ASC", DataViewRowState.CurrentRows);
            this.cboCanalContable.DataSource = datos;
            this.cboCanalContable.DisplayMember = "CanalContable";
            this.cboCanalContable.ValueMember = "CanalContableID";
            //flujo caja
            tabla = objCuentas.getFlujoCaja();
            fila = tabla.NewRow();
            fila["FlujoCajaID"] = 0;
            tabla.Rows.Add(fila);
            datos = new DataView(tabla, "", "FlujoCajaID ASC", DataViewRowState.CurrentRows);
            this.cboFlujoCaja.DataSource = datos;
            this.cboFlujoCaja.DisplayMember = "NombreFlujoCaja";
            this.cboFlujoCaja.ValueMember = "FlujoCajaID";
            //tipodocumento
            tabla = objDocumentos.tipos();
            fila = tabla.NewRow();
            fila["TipoDocumentoID"] = 0;
            tabla.Rows.Add(fila);
            datos = new DataView(tabla, "", "TipoDocumentoID ASC", DataViewRowState.CurrentRows);
            this.cboTipoDocumento.DataSource = datos;
            this.cboTipoDocumento.DisplayMember = "TipoDocumento";
            this.cboTipoDocumento.ValueMember = "TipoDocumentoID";
            //areas
            tabla = objHotel.getAreas(cDatos.EstablecimientoID, cDatos.HotelID);
            fila = tabla.NewRow();
            fila["AreaID"] = 0;
            tabla.Rows.Add(fila);
            datos = new DataView(tabla, "", "nombreArea ASC", DataViewRowState.CurrentRows);
            this.cboArea.DataSource = datos;
            this.cboArea.DisplayMember = "nombreArea";
            this.cboArea.ValueMember = "AreaID";
        }

        private void cboTipoConversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboTipoConversion.SelectedValue.ToString());
        }

        private void cboTipoConversion_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string tipoConversionID;

            DateTime fecha;

            try
            {
                //obtener la fecha
                fecha = Convert.ToDateTime(mtxtFecha.Text);
                //obtener el tipoconversionid
                tipoConversionID = cboTipoConversion.SelectedValue.ToString();

                if (tipoConversionID.Trim().Length == 0)
                {
                    MessageBox.Show("Debe elegir un tipo de conversión.");
                    cboTipoConversion.Focus();
                    return;
                }

                //obtener el tipo de cambio
                try
                {
                    txtTipoCambio.Text = objMonedas.getTipoCambio(tipoConversionID, fecha).ToString();
                }
                catch
                {
                    txtTipoCambio.Text = "0.00";
                }

            }
            catch
            {
                MessageBox.Show("Tiene que ingresar una fecha válida para el asiento.");
                mtxtFecha.Focus();
            }
        }

        private void cboTipoConversion_Leave(object sender, EventArgs e)
        {
            string tipoConversionID;

            DateTime fecha;

            try 
            { 
                //obtener la fecha
                DateTime fechaResultado;

                String cadena=mtxtFecha.Text;

                if (DateTime.TryParse(mtxtFecha.Text, out fechaResultado) == true)
                {
                    fecha = fechaResultado;
                }
                else
                {
                    MessageBox.Show("La fecha no es válida.");
                    return;
                }
                
                //obtener el tipoconversionid
                tipoConversionID = cboTipoConversion.SelectedValue.ToString();

                if (tipoConversionID.Trim().Length == 0)
                {
                    MessageBox.Show("Debe elegir un tipo de conversión.");
                    cboTipoConversion.Focus();
                    return;
                }
                //obtener el tipo de cambio
                if (tipoConversionID.Trim() == "113")
                {
                    txtTipoCambio.BackColor = Color.FromArgb(128, 255, 128);
                    txtTipoCambio.Enabled = true;
                }
                else 
                {
                    
                    txtTipoCambio.BackColor = Color.FromArgb(255, 255, 128);
                    txtTipoCambio.Enabled = false;
                }

                try
                {
                    txtTipoCambio.Text = objMonedas.getTipoCambio(tipoConversionID, fecha).ToString();
                }
                catch 
                {
                    txtTipoCambio.Text = "0.00";
                }
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Tiene que ingresar una fecha válida para el asiento.");
                mtxtFecha.Focus();
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cboTipoConversion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }

        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                    //pasa al campo siguiente...
                    Control parent = ((ComboBox)sender).Parent;
                    parent.SelectNextControl(ActiveControl, true, true, true, true);
             
            }
        }

        private void cboMoneda_KeyDown(object sender, KeyEventArgs e)
        {
            //continuaaaa....
            if (e.KeyCode == Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        private void txtGlosa_TextChanged(object sender, EventArgs e)
        {

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

        private void txtGlosa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                if (txtGlosa.Text.Trim().Length > 0)
                {
                    Control parent = ((TextBox)sender).Parent;
                    parent.SelectNextControl(ActiveControl, true, true, true, true);
                }
                

            }
        }

        private void txtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {

            //escribiendo solo numeros y ""/"
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }

            //presionando enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente... 
                    Control parent = ((TextBox)sender).Parent;
                    parent.SelectNextControl(ActiveControl, true, true, true, true);
             
            }

        }

        private void chkBloqueado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...

                Control parent = ((CheckBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);



            }
        }

        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...

                Control parent = ((TextBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);



            }
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkBloqueado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHaber_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            Decimal valor = 0;

            if (Decimal.TryParse(tb.Text, out valor) == false)
            {
                valor = 0;
            }

            if (valor == 0)
            {
                if (tb.Name == "txtHaber")
                {
                    txtDebe.Enabled = true;
                    //txtHaber.Enabled = false;
                }
                if (tb.Name == "txtDebe")
                {
                    txtHaber.Enabled = true;
                    //txtDebe.Enabled = false;
                }
            }
            else
            {
                if (tb.Name == "txtHaber")
                {
                    txtDebe.Enabled = false;
                    //txtHaber.Enabled = false;
                }
                if (tb.Name == "txtDebe")
                {
                    txtHaber.Enabled = false;
                    //txtDebe.Enabled = false;
                }
            }
            Mostrar_Calcular_UnidadesNegocio();
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mostrar_Calcular_UnidadesNegocio();
        }

        private void cboArea_TextChanged(object sender, EventArgs e)
        {
            if (cboArea.Text.Trim() == "")
            {
                cboArea.SelectedValue = 0;
                Mostrar_Calcular_UnidadesNegocio();
            }
            
        }

        private void Mostrar_Calcular_UnidadesNegocio()
        {
            int AreaID = 0;
            try
            {
                AreaID = Convert.ToInt32(cboArea.SelectedValue);
            }
            catch
            {
                AreaID = 0;
            }
            
            if (AreaID != 0)
            {
                DataTable tabla = objHotel.getUnidadesNegocioArea(cDatos.EstablecimientoID, cDatos.HotelID, AreaID);

                dgvAreas.DataSource = tabla;
                //tamaño de columna 
                //dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAreas.RowHeadersWidth = 10;
                //60% para unidadnegocio y 40% participacion
                //dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                //dgvAreas.Columns["NombreUnidadNegocio"].Width = (dgvAreas.Width * 60) / 100;
                //dgvAreas.Columns["Participacion"].Width = (dgvAreas.Width * 40) / 100;
                //ocultar y ubicar columnas
                dgvAreas.Columns["ID"].Visible = false;
                dgvAreas.Columns["ID"].DisplayIndex = 0;
                dgvAreas.Columns["UnidadNegocioID"].Visible = false;
                dgvAreas.Columns["UnidadNegocioID"].DisplayIndex = 1;
                dgvAreas.Columns["AreaID"].Visible = false;
                dgvAreas.Columns["AreaID"].DisplayIndex = 2;
                dgvAreas.Columns["Participacion"].DisplayIndex = 4;
                dgvAreas.Columns["Participacion"].HeaderText = "%";
                dgvAreas.Columns["Participacion"].ReadOnly = true;
                
                dgvAreas.Columns["NombreUnidadNegocio"].HeaderText = "Unidad de Negocio";
                dgvAreas.Columns["NombreUnidadNegocio"].DisplayIndex = 3;
                dgvAreas.Columns["NombreUnidadNegocio"].ReadOnly = true;
                dgvAreas.Columns["NombreArea"].Visible = false;
                
                dgvAreas.Columns["NombreArea"].DisplayIndex = 5;

                dgvAreas.Columns["Participacion"].Width = 30;
                dgvAreas.Columns["NombreArea"].Width = 50;
                //dgvAreas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                
                //agregar columna para montos
                //comprueba si existe
                int campo = 0;
                try
                {
                    campo = dgvAreas.Columns["Valor"].Width;
                }
                catch
                {
                    campo = 0;
                }

                if (campo == 0)
                {
                    //si hay columnas agregar
                    if (dgvAreas.Columns.Count > 0)
                    {
                        DataGridViewColumn columna = new DataGridViewTextBoxColumn();
                        columna.Name = "Valor";
                        columna.HeaderText = "Valor";
                        columna.ReadOnly = false;
                        columna.Visible = true;
                        columna.DisplayIndex = 6;
                        columna.Width = 30;
                        columna.DefaultCellStyle.Format = "0.00";
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvAreas.Columns.Add(columna);
                        dgvAreas.Refresh();
                    }
                    
                }

                //ahora calcular los montos por unidades de acuerdo al porcentaje
                decimal valor = 0;
                try
                {
                    valor = Convert.ToDecimal(txtDebe.Text);
                    if (valor == 0)
                    {
                        valor = Convert.ToDecimal(txtHaber.Text);
                    }
                }
                catch
                {
                    valor = Convert.ToDecimal(txtHaber.Text);
                }
                //recorrer el grid y ver los porcentajes
                foreach (DataGridViewRow fila in dgvAreas.Rows)
                {
                    try
                    {
                        Decimal porcentaje = Convert.ToDecimal(fila.Cells["Participacion"].Value);
                        fila.Cells["Valor"].Value = valor * (porcentaje / 100);
                    }
                    catch
                    {
                        fila.Cells["Valor"].Value = 0;
                    }

                }
               //calcular diferencia entre el total y los valores



            }
            else
            {
                dgvAreas.Columns.Clear();
                dgvAreas.DataSource = null;
            }
        }

        private void cboArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //consultar las unidades de negocios
            try
            {

                Mostrar_Calcular_UnidadesNegocio();

            }
            catch
            {
                MessageBox.Show("Error al mostrar o calcular la distribución de las áreas de negocio.");
            }
            
        }

        private void cboProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboProyecto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cboCanalContable_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cboFlujoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cboTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((TextBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (buscaEmpresa() == true)
                {
                    //pasa al campo siguiente...
                    Control parent = ((TextBox)sender).Parent;
                    parent.SelectNextControl(ActiveControl, true, true, true, true);
                }
                else
                {
                    e.Handled = false;
                }
                
            }
        }

        private bool buscaEmpresa() 
        {
            DataTable datos = objEmpresa.getEmpresa(txtEmpresa.Text);
            try
            {
                DataRow fila = datos.Rows[0];
                lblRazonSocialEmpresa.Text = Convert.ToString(fila["RazonSocial"]);
                lblEmpresaID.Text = Convert.ToString(fila["EmpresaID"]);
                return true;
            }
            catch 
            {
                lblRazonSocialEmpresa.Text = "";
                lblEmpresaID.Text = "";

                txtEmpresa.SelectAll();
                lblEmpresaID.Text = "";
                frmBuscarEmpresa buscador = new frmBuscarEmpresa();
                buscador.pRUCEmpresa = txtEmpresa.Text;
                buscador.ShowDialog();
                txtEmpresa.Text = buscador.pRUCEmpresa;

                //txtCuenta.Text = "";


                txtEmpresa.SelectAll();
                txtEmpresa.Focus();
                if (buscador.cancelo_formulario == false)
                { SendKeys.Send("{ENTER}"); }
                    

                return false;
            }
        }

        private void cboArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            //continuaaaa....
            if (e.KeyChar == (char)Keys.Enter)
            {
                //pasa al campo siguiente...
                Control parent = ((ComboBox)sender).Parent;
                parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBuscarCuenta frmBuscador = new frmBuscarCuenta();

            frmBuscador.pCodigoCuenta=txtCuenta.Text.Trim();

            frmBuscador.ShowDialog(this);

            if (frmBuscador.cancelo_formulario == true)
            {
                return;
            }

            txtCuenta.Text = frmBuscador.pCodigoCuenta.Trim();
            //RaiseKeyEvent(
            //lblNombreCuenta.Text = "";
            //mostrar los campos obligatorios
            txtCuenta.Text = frmBuscador.pCodigoCuenta.Trim();
            try
            {
                lblPlanCuentaID.Text = frmBuscador._planCuentaID.Trim();
            }
            catch
            {
                MessageBox.Show("Error al seleccionar la cuenta.");
                return;
            }

            if (lblPlanCuentaID.Text == null)
            {
                MessageBox.Show("Error al seleccionar la cuenta.");
                return;
            }

                //RaiseKeyEvent
            txtCuenta.SelectAll();

            txtCuenta.Focus();

            SendKeys.Send("{ENTER}");
            
        }

        private void CrearDetalle()
        {
            //CODIGO DONDE SE CREA LA TABLA DETALLE
            tablaDetalle = new DataTable("Detalle");

            
            //para crear la clave principal
            DataColumn[] keys = new DataColumn[1];
            DataColumn columna1 = tablaDetalle.Columns.Add("DetalleID", typeof(Int32));
            columna1.AutoIncrement = true;
            columna1.AutoIncrementSeed=1;
            columna1.AutoIncrementStep = 1;

            keys[0] = columna1;
            tablaDetalle.PrimaryKey=keys;
            
            tablaDetalle.Columns.Add("MontoDebe", typeof(Decimal));
            tablaDetalle.Columns.Add("MontoHaber", typeof(Decimal));
            tablaDetalle.Columns.Add("DebeSoles", typeof(Decimal));
            tablaDetalle.Columns.Add("HaberSoles", typeof(Decimal));
            tablaDetalle.Columns.Add("DebeDolares", typeof(Decimal));
            tablaDetalle.Columns.Add("HaberDolares", typeof(Decimal));
            tablaDetalle.Columns.Add("CanalContableID", typeof(String));
            tablaDetalle.Columns.Add("CanalContable", typeof(String));
            tablaDetalle.Columns.Add("EmpresaID", typeof(Int32));
            tablaDetalle.Columns.Add("Empresa", typeof(String));
            tablaDetalle.Columns.Add("RUC", typeof(String));
            tablaDetalle.Columns.Add("TipoDocumentoID", typeof(Int32));
            tablaDetalle.Columns.Add("TipoDocumento", typeof(string));
            tablaDetalle.Columns.Add("ProyectoID", typeof(Int32));
            tablaDetalle.Columns.Add("Proyecto", typeof(String));
            tablaDetalle.Columns.Add("Dia", typeof(DateTime));
            tablaDetalle.Columns.Add("Referencia", typeof(String));
            tablaDetalle.Columns.Add("FechaEmision", typeof(DateTime));
            tablaDetalle.Columns.Add("FechaVencimiento", typeof(DateTime));
            tablaDetalle.Columns.Add("AreaID", typeof(Int32));
            tablaDetalle.Columns.Add("Area", typeof(String));
            tablaDetalle.Columns.Add("NumeroDocumento", typeof(String));
            
            tablaDetalle.Columns.Add("FlujoCajaID", typeof(Int32));
            tablaDetalle.Columns.Add("FlujoCaja", typeof(String));
            tablaDetalle.Columns.Add("PlanCuentaID", typeof(String));
            tablaDetalle.Columns.Add("PlanCuenta", typeof(String));
            tablaDetalle.Columns.Add("PlanCuentaCodigo", typeof(String));
            
            tablaDetalle.Columns.Add("MonedaID", typeof(Int32));
            tablaDetalle.Columns.Add("Moneda", typeof(String));
            tablaDetalle.Columns.Add("TipoCambio", typeof(Decimal));

            tablaDetalle.Columns.Add("ImporteSoles", typeof(Decimal));
            tablaDetalle.Columns.Add("ImporteDolares", typeof(Decimal));
            
            tablaDetalle.Columns.Add("PeriodoID", typeof(String));
            
            tablaDetalle.Columns.Add("TipoConversionMonedaID", typeof(String));
            tablaDetalle.Columns.Add("TipoConversionMoneda", typeof(String));


            //unidades de negocios (10)

            for (Int32 _num = 1; _num <= 10; _num++)
            {

                string _etiqueta_1 = "UnidadNegocio_" + cDatos.Right("0" + _num.ToString(), 2) + "_ID";
                string _etiqueta_2 = "UnidadNegocio_" + cDatos.Right("0" + _num.ToString(), 2) + "_ImporteSoles";
                string _etiqueta_3 = "UnidadNegocio_" + cDatos.Right("0" + _num.ToString(), 2) + "_ImporteDolares";

                tablaDetalle.Columns.Add(_etiqueta_1, typeof(Int32));
                tablaDetalle.Columns.Add(_etiqueta_2, typeof(Decimal));
                tablaDetalle.Columns.Add(_etiqueta_3, typeof(Decimal));

            }
            

            //asientocontabledetalleidtransferencia
            tablaDetalle.Columns.Add("AsientoContableDetalleIDTransferencia", typeof(String));
            //columna para controlar si es un nuevo detalle
            tablaDetalle.Columns.Add("DetalleNuevo", typeof(Int32));
            //columna para controlar si es un detalle a eliminar
            tablaDetalle.Columns.Add("DetalleEliminado",typeof(Int32));
            //se crea la tabla para los detalles de transferenbcia
            tablaDetalleTransferencia = tablaDetalle.Clone();

            dgvDetalle.ReadOnly = true;
            dgvTransferencias.ReadOnly = true;

        }

        private void calcularTotales()
        {
            //inicio del codigo para la suma del debe y el haber
            object _sumaDebeSoles;
            object _sumaDebeDolares;
            object _sumaHaberSoles;
            object _sumaHaberDolares;

            _sumaDebeSoles = tablaDetalle.Compute("Sum(DebeSoles)", "DetalleEliminado<>1");
            _sumaDebeDolares = tablaDetalle.Compute("Sum(DebeDolares)", "DetalleEliminado<>1");
            _sumaHaberSoles = tablaDetalle.Compute("Sum(HaberSoles)", "DetalleEliminado<>1");
            _sumaHaberDolares = tablaDetalle.Compute("Sum(HaberDolares)", "DetalleEliminado<>1");

            try
            {

                decimal sumaDebeSoles = Convert.ToDecimal(_sumaDebeSoles);
                decimal sumaDebeDolares = Convert.ToDecimal(_sumaDebeDolares);
                decimal sumaHaberSoles = Convert.ToDecimal(_sumaHaberSoles);
                decimal sumaHaberDolares = Convert.ToDecimal(_sumaHaberDolares);

                //String.Format("{0:0.00}", sumaDebe);
                txtSubTotalDebeSoles.Text = String.Format("{0:0.00}", sumaDebeSoles);
                txtSubTotalDebeDolares.Text = String.Format("{0:0.00}", sumaDebeDolares);
                txtSubTotalHaberSoles.Text = String.Format("{0:0.00}", sumaHaberSoles);
                txtSubTotalHaberDolares.Text = String.Format("{0:0.00}", sumaHaberDolares);
            }
            catch
            {
                txtSubTotalDebeSoles.Text = "0.00";
                txtSubTotalDebeDolares.Text = "0.00";
                txtSubTotalHaberSoles.Text = "0.00";
                txtSubTotalHaberDolares.Text = "0.00";
            }
            //la diferencia
            try
            {
                Decimal decSDS = Convert.ToDecimal(_sumaDebeSoles);
                Decimal decSHS = Convert.ToDecimal(_sumaHaberSoles);
                Decimal decSDD = Convert.ToDecimal(_sumaDebeDolares);
                Decimal decSHD = Convert.ToDecimal(_sumaHaberDolares);
                txtDiferenciaSoles.Text = String.Format("{0:0.00}", decSDS - decSHS);
                txtDiferenciaDolares.Text = String.Format("{0:0.00}", decSDD - decSHD);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                
                txtDiferenciaSoles.Text = "0.00";
                txtDiferenciaDolares.Text = "0.00";
                Console.WriteLine(ex.Message);

            }
            //fin del codigo para la suma del debe y el haber
        }

        private void CargarDetalle() 
        {
            //VISTA DE LOS DATOS DEL DETALLE
            //DataView dvDetalle = tablaDetalle.AsDataView();
            //dvDetalle.RowFilter = "AsientoContableDetalleIDTransferencia=0";
            //dgvDetalle.DataSource = dvDetalle.ToTable();
            //dvDetalle.RowFilter = "";
            //dvDetalle.RowFilter = "AsientoContableDetalleIDTransferencia<>0";
            //dgvTransferencias.DataSource = dvDetalle.ToTable();
            dgvDetalle.DataSource = tablaDetalle;

            cargarTransferencias();

            calcularTotales();

            //formatoGridDetalle();
            //DETALLE
            formatoGrid(1);
            //TRANSFERENCIA
            formatoGrid(2);
            //formatoGridTransferencias();
            
        }

        private void formatoGrid(int gridID)
        {
            try
            { 
            DataGridView objGrid = new DataGridView();

            switch (gridID)
            {
                case 1:
                    objGrid = dgvDetalle;
                    break;
                case 2:
                    objGrid = dgvTransferencias;
                    break;
                default:
                    break;
            }

            objGrid.Visible = false;

            objGrid.RowHeadersWidth = 10;
            //DataGridView grid = (DataGridView)gridX;
            //ocultar columnas
            objGrid.Columns["DetalleID"].Visible = false;

            objGrid.Columns["CanalContableID"].Visible = false;

            objGrid.Columns["EmpresaID"].Visible = false;

            objGrid.Columns["TipoDocumentoID"].Visible = false;

            objGrid.Columns["ProyectoID"].Visible = false;

            objGrid.Columns["AreaID"].Visible = false;

            objGrid.Columns["FlujoCajaID"].Visible = false;

            objGrid.Columns["PlanCuentaID"].Visible = false;

            objGrid.Columns["MonedaID"].Visible = false;

            objGrid.Columns["TipoConversionMonedaID"].Visible = false;

            for (Int32 iUnd = 1; iUnd <= 10; iUnd++)
            {
                string etiqueta = "";
                //id de las unidades de negocios
                etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ID";
                objGrid.Columns[etiqueta].Visible = false;
                //importes en soles de las unidades de negocios
                etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteSoles";
                objGrid.Columns[etiqueta].Visible = false;
                //importes en dolares de las unidades de negocios
                etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteDolares";
                objGrid.Columns[etiqueta].Visible = false;
            }

            objGrid.Columns["PeriodoID"].Visible = false;
            objGrid.Columns["MontoDebe"].Visible = false;
            objGrid.Columns["MontoHaber"].Visible = false;
            objGrid.Columns["AsientoContableDetalleIDTransferencia"].Visible = false;
            objGrid.Columns["DetalleNuevo"].Visible = false;
            objGrid.Columns["DetalleEliminado"].Visible = false;

            //TITULO DE LAS COLUMNAS
            objGrid.Columns["PlanCuentaCodigo"].HeaderText = "Cuenta";
            objGrid.Columns["PlanCuenta"].HeaderText = "Nombre";
            objGrid.Columns["CanalContable"].HeaderText = "Canal";
            objGrid.Columns["TipoDocumento"].HeaderText = "T.Doc.";
            objGrid.Columns["FechaEmision"].HeaderText = "F.Emisión";
            objGrid.Columns["FechaVencimiento"].HeaderText = "F.Vencim.";
            objGrid.Columns["NumeroDocumento"].HeaderText = "Nro.Doc.";
            objGrid.Columns["FlujoCaja"].HeaderText = "Flujo";
            objGrid.Columns["TipoCambio"].HeaderText = "T.C.";
            objGrid.Columns["ImporteSoles"].HeaderText = "Imp.Soles";
            objGrid.Columns["ImporteDolares"].HeaderText = "Imp.Dolares";
            objGrid.Columns["TipoConversionMoneda"].HeaderText = "Tipo Conversión";
            objGrid.Columns["DebeSoles"].HeaderText = "Debe S/.";
            objGrid.Columns["HaberSoles"].HeaderText = "Haber S/.";
            objGrid.Columns["DebeDolares"].HeaderText = "Debe $";
            objGrid.Columns["HaberDolares"].HeaderText = "Haber $";
            objGrid.Columns["Moneda"].HeaderText = "Mon.";
            //ANCHO DE LAS COLUMNAS
            //dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //CREA UN ESTILO PARA ESAS COLUMNAS
            DataGridViewCellStyle numeroEstilo = new DataGridViewCellStyle();
            numeroEstilo.Alignment = DataGridViewContentAlignment.MiddleRight;
            numeroEstilo.Format = "";
            //ALINEAR NUMEROS
            objGrid.Columns["DebeSoles"].DefaultCellStyle = numeroEstilo;
            objGrid.Columns["HaberSoles"].DefaultCellStyle = numeroEstilo;
            objGrid.Columns["DebeDolares"].DefaultCellStyle = numeroEstilo;
            objGrid.Columns["HaberDolares"].DefaultCellStyle = numeroEstilo;
            objGrid.Columns["TipoCambio"].DefaultCellStyle = numeroEstilo;
            objGrid.Columns["ImporteSoles"].DefaultCellStyle = numeroEstilo;
            objGrid.Columns["ImporteDolares"].DefaultCellStyle = numeroEstilo;
            //FORMATEAR NUMEROS
            objGrid.Columns["DebeSoles"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["HaberSoles"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["DebeDolares"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["HaberDolares"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["TipoCambio"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["ImporteSoles"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["ImporteDolares"].DefaultCellStyle.Format = "0.00";
            objGrid.Columns["ImporteSoles"].Visible = false;
            objGrid.Columns["ImporteDolares"].Visible = false;
            objGrid.Columns["Dia"].Visible = false;
            //FORMATEAR NUMEROS DOLARES
            //CultureInfo culture = new CultureInfo("en-US");
            //culture.NumberFormat.CurrencyDecimalDigits = 2;
            //dgvDetalle.Columns["DebeDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
            //dgvDetalle.Columns["HaberDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
            //dgvDetalle.Columns["ImporteDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
            //ORDEN DE LAS COLUMNAS
            objGrid.Columns["PlanCuentaCodigo"].DisplayIndex = 0;
            objGrid.Columns["PlanCuenta"].DisplayIndex = 1;
            objGrid.Columns["DebeSoles"].DisplayIndex = 2;
            objGrid.Columns["HaberSoles"].DisplayIndex = 3;
            objGrid.Columns["DebeDolares"].DisplayIndex = 4;
            objGrid.Columns["HaberDolares"].DisplayIndex = 5;
            objGrid.Columns["TipoCambio"].DisplayIndex = 6;
            objGrid.Columns["Referencia"].DisplayIndex = 7;
            objGrid.Columns["Area"].DisplayIndex = 8;
            objGrid.Columns["Moneda"].DisplayIndex = 9;
            objGrid.Columns["RUC"].DisplayIndex = 10;
            objGrid.Columns["Empresa"].DisplayIndex = 11;
            objGrid.Columns["TipoDocumento"].DisplayIndex = 12;
            objGrid.Columns["NumeroDocumento"].DisplayIndex = 13;
            objGrid.Columns["FechaEmision"].DisplayIndex = 14;
            objGrid.Columns["FechaVencimiento"].DisplayIndex = 15;
            objGrid.Columns["FlujoCaja"].DisplayIndex = 16;
            objGrid.Columns["CanalContable"].DisplayIndex = 17;
            objGrid.Columns["TipoConversionMoneda"].DisplayIndex = 18;
            objGrid.Columns["Proyecto"].DisplayIndex = 19;

            foreach (DataGridViewColumn columnaD in objGrid.Columns)
            {
                if (columnaD.Visible == true)
                {
                    switch (columnaD.Name)
                    {
                        case "PlanCuentaCodigo":
                            columnaD.Width = 65;
                            break;
                        case "TipoCambio":
                            columnaD.Width = 35;
                            break;
                        case "Moneda":
                            columnaD.Width = 35;
                            break;
                        case "RUC":
                            columnaD.Width = 80;
                            break;
                        case "Empresa":
                            columnaD.Width = 110;
                            break;
                        case "TipoDocumento":
                            columnaD.Width = 70;
                            break;
                        case "NumeroDocumento":
                            columnaD.Width = 75;
                            break;
                        case "FechaEmision":
                            columnaD.Width = 70;
                            break;
                        case "FechaVencimiento":
                            columnaD.Width = 70;
                            break;
                        case "TipoConversionMoneda":
                            columnaD.Width = 70;
                            break;

                        
                    }

                }

                

            }

            foreach (DataGridViewRow filaD in objGrid.Rows)
            {
                if (Convert.ToString(filaD.Cells["MonedaId"].Value) == "1")
                {

                    filaD.Cells["DebeSoles"].Style.Font = new Font(objGrid.Font, FontStyle.Bold);
                    filaD.Cells["HaberSoles"].Style.Font = new Font(objGrid.Font, FontStyle.Bold); ;
                }

                if (Convert.ToString(filaD.Cells["MonedaId"].Value) == "2")
                {
                    filaD.Cells["DebeDolares"].Style.Font = new Font(objGrid.Font, FontStyle.Bold);
                    filaD.Cells["HaberDolares"].Style.Font = new Font(objGrid.Font, FontStyle.Bold); ;
                }


            }

            objGrid.Visible = true;

            objGrid = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatoGridDetalle()
        {

            //SendMessage(dgvDetalle.Handle, WM_SETREDRAW, false, 0); // before
            //foreach (DataGridViewColumn c in dgvDetalle.Columns)
            //{
            //    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //}

            

            dgvDetalle.RowHeadersWidth = 10;
            //DataGridView grid = (DataGridView)gridX;
            //ocultar columnas
            dgvDetalle.Columns["DetalleID"].Visible = false;
            
            dgvDetalle.Columns["CanalContableID"].Visible = false;
            
            dgvDetalle.Columns["EmpresaID"].Visible = false;
            
            dgvDetalle.Columns["TipoDocumentoID"].Visible = false;
            
            dgvDetalle.Columns["ProyectoID"].Visible = false;
            
            dgvDetalle.Columns["AreaID"].Visible = false;
            
            dgvDetalle.Columns["FlujoCajaID"].Visible = false;
            
            dgvDetalle.Columns["PlanCuentaID"].Visible = false;
            
            dgvDetalle.Columns["MonedaID"].Visible = false;
            
            dgvDetalle.Columns["TipoConversionMonedaID"].Visible = false;

            for (Int32 iUnd = 1; iUnd <= 10; iUnd++)
            {
                string etiqueta = "";
                //id de las unidades de negocios
                etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ID";
                dgvDetalle.Columns[etiqueta].Visible = false;
                //importes en soles de las unidades de negocios
                etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteSoles";
                dgvDetalle.Columns[etiqueta].Visible = false;
                //importes en dolares de las unidades de negocios
                etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteDolares";
                dgvDetalle.Columns[etiqueta].Visible = false;
            }

            dgvDetalle.Columns["PeriodoID"].Visible = false;
            dgvDetalle.Columns["MontoDebe"].Visible = false;
            dgvDetalle.Columns["MontoHaber"].Visible = false;
            dgvDetalle.Columns["AsientoContableDetalleIDTransferencia"].Visible = false;
            dgvDetalle.Columns["DetalleNuevo"].Visible = false;
            dgvDetalle.Columns["DetalleEliminado"].Visible = false;

            //TITULO DE LAS COLUMNAS
            dgvDetalle.Columns["PlanCuentaCodigo"].HeaderText = "Cuenta";
            dgvDetalle.Columns["PlanCuenta"].HeaderText = "Nombre";
            dgvDetalle.Columns["CanalContable"].HeaderText = "Canal";
            dgvDetalle.Columns["TipoDocumento"].HeaderText = "T.Doc.";
            dgvDetalle.Columns["FechaEmision"].HeaderText = "F.Emisión";
            dgvDetalle.Columns["FechaVencimiento"].HeaderText = "F.Vencimiento";
            dgvDetalle.Columns["NumeroDocumento"].HeaderText = "Nro.Doc.";
            dgvDetalle.Columns["FlujoCaja"].HeaderText = "Flujo";
            dgvDetalle.Columns["TipoCambio"].HeaderText = "T.C.";
            dgvDetalle.Columns["ImporteSoles"].HeaderText = "Imp.Soles";
            dgvDetalle.Columns["ImporteDolares"].HeaderText = "Imp.Dolares";
            dgvDetalle.Columns["TipoConversionMoneda"].HeaderText = "Tipo Conversión";
            dgvDetalle.Columns["DebeSoles"].HeaderText = "Debe S/.";
            dgvDetalle.Columns["HaberSoles"].HeaderText = "Haber S/.";
            dgvDetalle.Columns["DebeDolares"].HeaderText = "Debe $";
            dgvDetalle.Columns["HaberDolares"].HeaderText = "Haber $";
            //ANCHO DE LAS COLUMNAS
            //dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //ALINEAR NUMEROS
            //FORMATEAR NUMEROS
            DataGridViewCellStyle numeroCellStyle = new DataGridViewCellStyle();
            numeroCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            numeroCellStyle.Format = "0.00";

            dgvDetalle.Columns["DebeSoles"].DefaultCellStyle=numeroCellStyle;
            dgvDetalle.Columns["HaberSoles"].DefaultCellStyle=numeroCellStyle;
            dgvDetalle.Columns["DebeDolares"].DefaultCellStyle=numeroCellStyle;
            dgvDetalle.Columns["HaberDolares"].DefaultCellStyle=numeroCellStyle;
            dgvDetalle.Columns["TipoCambio"].DefaultCellStyle = numeroCellStyle;
            dgvDetalle.Columns["ImporteSoles"].DefaultCellStyle = numeroCellStyle;
            dgvDetalle.Columns["ImporteDolares"].DefaultCellStyle = numeroCellStyle;
            //FORMATEAR NUMEROS
            //dgvDetalle.Columns["DebeSoles"].DefaultCellStyle.Format = "0.00";
            //dgvDetalle.Columns["HaberSoles"].DefaultCellStyle.Format = "0.00";
            //dgvDetalle.Columns["DebeDolares"].DefaultCellStyle.Format = "0.00";
            //dgvDetalle.Columns["HaberDolares"].DefaultCellStyle.Format = "0.00";
            //dgvDetalle.Columns["TipoCambio"].DefaultCellStyle.Format = "0.00";
            //dgvDetalle.Columns["ImporteSoles"].DefaultCellStyle.Format = "0.00";
            //dgvDetalle.Columns["ImporteDolares"].DefaultCellStyle.Format = "0.00";
            dgvDetalle.Columns["ImporteSoles"].Visible = false;
            dgvDetalle.Columns["ImporteDolares"].Visible = false;
            dgvDetalle.Columns["Dia"].Visible=false;
            //FORMATEAR NUMEROS DOLARES
            //CultureInfo culture = new CultureInfo("en-US");
            //culture.NumberFormat.CurrencyDecimalDigits = 2;
            //dgvDetalle.Columns["DebeDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
            //dgvDetalle.Columns["HaberDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
            //dgvDetalle.Columns["ImporteDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
            //ORDEN DE LAS COLUMNAS
            dgvDetalle.Columns["PlanCuentaCodigo"].DisplayIndex = 0;
            dgvDetalle.Columns["PlanCuenta"].DisplayIndex = 1;
            dgvDetalle.Columns["DebeSoles"].DisplayIndex = 2;
            dgvDetalle.Columns["HaberSoles"].DisplayIndex = 3;
            dgvDetalle.Columns["DebeDolares"].DisplayIndex = 4;
            dgvDetalle.Columns["HaberDolares"].DisplayIndex = 5;
            dgvDetalle.Columns["TipoCambio"].DisplayIndex = 6;
            dgvDetalle.Columns["Referencia"].DisplayIndex = 7;
            dgvDetalle.Columns["Area"].DisplayIndex = 8;
            dgvDetalle.Columns["Moneda"].DisplayIndex = 9;
            dgvDetalle.Columns["RUC"].DisplayIndex = 10;
            dgvDetalle.Columns["Empresa"].DisplayIndex = 11;
            dgvDetalle.Columns["TipoDocumento"].DisplayIndex = 12;
            dgvDetalle.Columns["NumeroDocumento"].DisplayIndex = 13;
            dgvDetalle.Columns["FechaEmision"].DisplayIndex = 14;
            dgvDetalle.Columns["FechaVencimiento"].DisplayIndex = 15;
            dgvDetalle.Columns["FlujoCaja"].DisplayIndex = 16;
            dgvDetalle.Columns["CanalContable"].DisplayIndex = 17;
            dgvDetalle.Columns["TipoConversionMoneda"].DisplayIndex = 18;
            dgvDetalle.Columns["Proyecto"].DisplayIndex = 19;

            foreach (DataGridViewColumn columnaD in dgvDetalle.Columns)
            {
                if (columnaD.Visible == true)
                {
                    columnaD.Width = 90;
                }
            }

            foreach (DataGridViewRow filaD in dgvDetalle.Rows)
            {
                if (Convert.ToString(filaD.Cells["MonedaId"].Value) == "1")
                {

                    filaD.Cells["DebeSoles"].Style.Font = new Font(dgvDetalle.Font, FontStyle.Bold);
                    filaD.Cells["HaberSoles"].Style.Font = new Font(dgvDetalle.Font, FontStyle.Bold); ;
                }

                if (Convert.ToString(filaD.Cells["MonedaId"].Value) == "2")
                {
                    filaD.Cells["DebeDolares"].Style.Font = new Font(dgvDetalle.Font, FontStyle.Bold);
                    filaD.Cells["HaberDolares"].Style.Font = new Font(dgvDetalle.Font, FontStyle.Bold); ;
                }


            }
            
        }

        private void formatoGridTransferencias()
        {
            try
            {
                dgvTransferencias.RowHeadersWidth = 10;
                //DataGridView grid = (DataGridView)gridX;
                //ocultar columnas
                dgvTransferencias.Columns["DetalleID"].Visible = false;
                //tablaDetalle.Columns.Add("MontoDebe", typeof(Decimal));
                //tablaDetalle.Columns.Add("MontoHaber", typeof(Decimal));
                dgvTransferencias.Columns["CanalContableID"].Visible = false;
                //tablaDetalle.Columns.Add("CanalContable", typeof(String));
                dgvTransferencias.Columns["EmpresaID"].Visible = false;
                //tablaDetalle.Columns.Add("EmpresaID", typeof(Int32));
                //tablaDetalle.Columns.Add("Empresa", typeof(String));
                //tablaDetalle.Columns.Add("RUC", typeof(String));
                dgvTransferencias.Columns["TipoDocumentoID"].Visible = false;
                //tablaDetalle.Columns.Add("TipoDocumento", typeof(string));
                dgvTransferencias.Columns["ProyectoID"].Visible = false;
                //tablaDetalle.Columns.Add("ProyectoID", typeof(Int32));
                //tablaDetalle.Columns.Add("Proyecto", typeof(String));
                //tablaDetalle.Columns.Add("Dia", typeof(DateTime));
                //tablaDetalle.Columns.Add("Referencia", typeof(String));
                //tablaDetalle.Columns.Add("FechaEmision", typeof(DateTime));
                //tablaDetalle.Columns.Add("FechaVencimiento", typeof(DateTime));
                dgvTransferencias.Columns["AreaID"].Visible = false;
                //tablaDetalle.Columns.Add("AreaID", typeof(Int32));
                //tablaDetalle.Columns.Add("Area", typeof(String));
                //tablaDetalle.Columns.Add("NumeroDocumento", typeof(String));
                //dgvDetalle.Columns["TransaccionDocumentoID"].Visible = false;
                //tablaDetalle.Columns.Add("TransaccionDocumentoID", typeof(String));
                dgvTransferencias.Columns["FlujoCajaID"].Visible = false;
                //tablaDetalle.Columns.Add("FlujoCajaID", typeof(Int32));
                //tablaDetalle.Columns.Add("FlujoCaja", typeof(String));
                dgvTransferencias.Columns["PlanCuentaID"].Visible = false;
                dgvTransferencias.Columns["MonedaID"].Visible = false;
                dgvTransferencias.Columns["TipoConversionMonedaID"].Visible = false;
                
                
                for (Int32 iUnd = 1; iUnd <= 10; iUnd++)    
                {
                    string etiqueta = "";
                    //id de las unidades de negocios
                    etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(),2) + "_ID";
                    dgvTransferencias.Columns[etiqueta].Visible = false;
                    //importes en soles de las unidades de negocios
                    etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteSoles";
                    dgvTransferencias.Columns[etiqueta].Visible = false;
                    //importes en dolares de las unidades de negocios
                    etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteDolares";
                    dgvTransferencias.Columns[etiqueta].Visible = false;
                }

                //tablaDetalle.Columns.Add("PlanCuentaID", typeof(String));
                //tablaDetalle.Columns.Add("PlanCuenta", typeof(String));
                //tablaDetalle.Columns.Add("ImporteSoles", typeof(Decimal));
                //tablaDetalle.Columns.Add("ImporteDolares", typeof(Decimal));
                //dgvDetalle.Columns["AsientoContableDetalleIDTransferencia"].Visible = false;
                dgvTransferencias.Columns["PeriodoID"].Visible = false;
                dgvTransferencias.Columns["MontoDebe"].Visible = false;
                dgvTransferencias.Columns["MontoHaber"].Visible = false;
                dgvTransferencias.Columns["AsientoContableDetalleIDTransferencia"].Visible = false;
                dgvTransferencias.Columns["DetalleNuevo"].Visible = false;
                dgvTransferencias.Columns["DetalleEliminado"].Visible = false;

                //TITULO DE LAS COLUMNAS
                dgvTransferencias.Columns["PlanCuentaCodigo"].HeaderText = "Cod/Cuenta";
                dgvTransferencias.Columns["PlanCuenta"].HeaderText = "Nombre/Cuenta";
                dgvTransferencias.Columns["CanalContable"].HeaderText = "Canal";
                dgvTransferencias.Columns["TipoDocumento"].HeaderText = "T.Doc.";
                dgvTransferencias.Columns["FechaEmision"].HeaderText = "F.Emisión";
                dgvTransferencias.Columns["FechaVencimiento"].HeaderText = "F.Vencimiento";
                dgvTransferencias.Columns["NumeroDocumento"].HeaderText = "Nro.Doc.";
                dgvTransferencias.Columns["FlujoCaja"].HeaderText = "Flujo";
                dgvTransferencias.Columns["TipoCambio"].HeaderText = "T.C.";
                dgvTransferencias.Columns["ImporteSoles"].HeaderText = "Imp.Soles";
                dgvTransferencias.Columns["ImporteDolares"].HeaderText = "Imp.Dolares";
                dgvTransferencias.Columns["TipoConversionMoneda"].HeaderText = "Tipo Conversión";

                dgvTransferencias.Columns["DebeSoles"].HeaderText = "Debe S/.";
                dgvTransferencias.Columns["HaberSoles"].HeaderText = "Haber S/.";
                dgvTransferencias.Columns["DebeDolares"].HeaderText = "Debe $";
                dgvTransferencias.Columns["HaberDolares"].HeaderText = "Haber $";


                //ALINEAR NUMEROS
                //ALINEAR NUMEROS
                //FORMATEAR NUMEROS
                DataGridViewCellStyle numeroCellStyle = new DataGridViewCellStyle();
                numeroCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                numeroCellStyle.Format = "0.00";

                dgvTransferencias.Columns["DebeSoles"].DefaultCellStyle=numeroCellStyle;
                dgvTransferencias.Columns["HaberSoles"].DefaultCellStyle = numeroCellStyle;
                dgvTransferencias.Columns["DebeDolares"].DefaultCellStyle = numeroCellStyle;
                dgvTransferencias.Columns["HaberDolares"].DefaultCellStyle = numeroCellStyle;
                dgvTransferencias.Columns["TipoCambio"].DefaultCellStyle = numeroCellStyle;
                dgvTransferencias.Columns["ImporteSoles"].DefaultCellStyle = numeroCellStyle;
                dgvTransferencias.Columns["ImporteDolares"].DefaultCellStyle = numeroCellStyle;
                //FORMATEAR NUMEROS
                //el formato era C
                //dgvTransferencias.Columns["DebeSoles"].DefaultCellStyle.Format = "0.00";
                //dgvTransferencias.Columns["HaberSoles"].DefaultCellStyle.Format = "0.00";
                //dgvTransferencias.Columns["DebeDolares"].DefaultCellStyle.Format = "0.00";
                //dgvTransferencias.Columns["HaberDolares"].DefaultCellStyle.Format = "0.00";
                //dgvTransferencias.Columns["TipoCambio"].DefaultCellStyle.Format = "0.00";
                //dgvTransferencias.Columns["ImporteSoles"].DefaultCellStyle.Format = "0.00";
                //dgvTransferencias.Columns["ImporteDolares"].DefaultCellStyle.Format = "0.00";

                dgvTransferencias.Columns["ImporteSoles"].Visible = false;
                dgvTransferencias.Columns["ImporteDolares"].Visible = false;
                dgvTransferencias.Columns["Dia"].Visible = false;
                //FORMATEAR NUMEROS DOLARES
                //CultureInfo culture = new CultureInfo("en-US");
                //culture.NumberFormat.CurrencyDecimalDigits = 2;
                //dgvTransferencias.Columns["DebeDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
                //dgvTransferencias.Columns["HaberDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
                //dgvTransferencias.Columns["ImporteDolares"].DefaultCellStyle.FormatProvider = culture.NumberFormat;
                //ORDEN DE LAS COLUMNAS
                
                dgvTransferencias.Columns["PlanCuentaCodigo"].DisplayIndex = 0;
                dgvTransferencias.Columns["PlanCuenta"].DisplayIndex = 1;
                dgvTransferencias.Columns["DebeSoles"].DisplayIndex = 2;
                dgvTransferencias.Columns["HaberSoles"].DisplayIndex = 3;
                dgvTransferencias.Columns["DebeDolares"].DisplayIndex = 4;
                dgvTransferencias.Columns["HaberDolares"].DisplayIndex = 5;
                dgvTransferencias.Columns["TipoCambio"].DisplayIndex = 6;
                dgvTransferencias.Columns["Referencia"].DisplayIndex = 7;
                dgvTransferencias.Columns["Area"].DisplayIndex = 8;
                dgvTransferencias.Columns["Moneda"].DisplayIndex = 9;
                dgvTransferencias.Columns["RUC"].DisplayIndex = 10;
                dgvTransferencias.Columns["Empresa"].DisplayIndex = 11;
                dgvTransferencias.Columns["TipoDocumento"].DisplayIndex = 12;
                dgvTransferencias.Columns["NumeroDocumento"].DisplayIndex = 13;
                dgvTransferencias.Columns["FechaEmision"].DisplayIndex = 14;
                dgvTransferencias.Columns["FechaVencimiento"].DisplayIndex = 15;
                dgvTransferencias.Columns["FlujoCaja"].DisplayIndex = 16;
                dgvTransferencias.Columns["CanalContable"].DisplayIndex = 17;
                dgvTransferencias.Columns["TipoConversionMoneda"].DisplayIndex = 18;
                dgvTransferencias.Columns["Proyecto"].DisplayIndex = 19;

                foreach (DataGridViewColumn columnaD in dgvTransferencias.Columns)
                {
                    if (columnaD.Visible == true)
                    {
                        switch (columnaD.Name)
                        {
                            case "PlanCuentaCodigo":
                                columnaD.Width = 80;
                                break;
                            case "TipoCambio":
                                columnaD.Width = 50;
                                break;
                            case "Moneda":
                                columnaD.Width = 50;
                                break;
                            case "RUC":
                                columnaD.Width = 70;
                                break;
                            case "Empresa":
                                columnaD.Width = 110;
                                break;
                            case "TipoDocumento":
                                columnaD.Width = 70;
                                break;
                            case "NumeroDocumento":
                                columnaD.Width = 70;
                                break;
                            case "FechaEmision":
                                columnaD.Width = 70;
                                break;
                            case "FechaVencimiento":
                                columnaD.Width = 70;
                                break;
                            case "TipoConversionMoneda":
                                columnaD.Width = 70;
                                break;
                            
                            default:
                                columnaD.Width = 90;
                                break;
                        }
                        
                    }
                }
                //ANCHO DE LAS COLUMNAS
                //dgvTransferencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool validarDatosDetalle()
        { 
            bool valor_retorno;
            //campos obligatorios
            //valido la cuenta

            if (txtGlosa.Text.Trim().Length == 0)
            {
                MessageBox.Show("La glosa está en blanco.");
                return false;
            }

            string _fecha = mtxtFecha.Text;
            
            DateTime fechaV;

            if (DateTime.TryParse(_fecha,out fechaV)==false)
            {
                MessageBox.Show("Indique una fecha válida para el asiento.");
                return false;
            }

            if ((txtCuenta.Text.Trim().Length == 0) || (lblNombreCuenta.Text.Trim().Length == 0))
            {
                if ((lblPlanCuentaID.Text == "0") || (lblPlanCuentaID.Text == null))
                {
                    MessageBox.Show("Debe ingresar una cuenta válida.");
                    return false;
                }
            }

            //campo referencia
            if (txtReferencia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el campo Referencia.");
                return false;
            }

            //campo debe o haber
            if (txtDebe.Text.Trim() == "")
            {
                txtDebe.Text = "0.00";
                txtHaber.Focus();
                MessageBox.Show("El campo Debe está en blanco.");
                return false;
            }

            if (txtHaber.Text.Trim() == "")
            {
                txtHaber.Text = "0.00";
                txtDebe.Focus();
                MessageBox.Show("El campo Haber está en blanco.");
                return false;
            }

            decimal valorX;
            if (txtDebe.Text.Trim().Length == 0)
            {
                valorX = 0;
            }
            else
            {
                valorX = Convert.ToDecimal(txtDebe.Text);
            }

            if (valorX == 0)
            {
                if (txtHaber.Text.Trim().Length == 0)
                {
                    valorX = 0;
                }
                else
                {
                    valorX = Convert.ToDecimal(txtHaber.Text);
                }
            }
            if (valorX == 0)
            {
                MessageBox.Show("Debe ingresar un importe Debe o un importe Haber.");
                return false;
            }
            Decimal valorImporte = valorX;
            //campo moneda
            Int32 monedaID = Convert.ToInt32(cboMoneda.SelectedValue);
            if (monedaID == 0)
            {
                MessageBox.Show("Elija una moneda.");
                return false;
            }
            //campo tipoconversion
            String tipoconversionID = Convert.ToString(cboTipoConversion.SelectedValue);
            if (tipoconversionID.Trim().Length == 0)
            {
                MessageBox.Show("Elija un tipo de conversión.");
                return false;
            }
            //valido el tipo de cambio
            valor_retorno = decimal.TryParse(txtTipoCambio.Text, out valorX);

            if ((valor_retorno == false) || (valorX == 0))
            {
                MessageBox.Show("El tipo de cambio no debe ser 0.");
                return false;
            }
            //ahora valido los campos que son requeridos segun el tipo de cuenta
            DataTable datosRCuenta = objCuentas.DatosCuenta(txtCuenta.Text, cDatos.EstablecimientoID);

            DataRow fila = datosRCuenta.Rows[0];

            bool RequiereArea = Convert.ToBoolean(fila["RequiereArea"]);
            bool RequiereCanal = Convert.ToBoolean(fila["RequiereCanal"]);
            bool RequiereProyecto = Convert.ToBoolean(fila["RequiereProyecto"]);
            bool RequiereFechaVcto = Convert.ToBoolean(fila["RequiereFechaVencimiento"]);
            bool RequiereDocumento = Convert.ToBoolean(fila["RequiereDocumento"]);
            bool RequiereFlujoCaja = Convert.ToBoolean(fila["RequiereFlujoCaja"]);
            
            if (RequiereArea == true)
            {
                //valido el area
                int areaID = Convert.ToInt32(cboArea.SelectedValue);
                if (areaID == 0)
                {
                    MessageBox.Show("La cuenta requiere indicar un área.");
                    return false;
                }
                //valido la suma de las unidades de negocios es igual al debe o al haber
                //valorX contiene el importe del debe o del haber
                Decimal sumaImporteUnidades = 0;
                foreach (DataGridViewRow filaUN in dgvAreas.Rows)
                {
                    try
                    {
                        sumaImporteUnidades = sumaImporteUnidades + Convert.ToDecimal(filaUN.Cells["valor"].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Un valor de las áreas no es válido.");
                        return false;
                    }
                }
                if (sumaImporteUnidades != valorImporte)
                {
                    MessageBox.Show("La suma de importes por Unidades de Negocios no es igual al importe del detalle.");
                    return false;
                }

            }
            if (RequiereCanal == true)
            {
                //valido el canal contable
                string canalID = Convert.ToString(cboCanalContable.SelectedValue);
                if (canalID.Trim().Length == 0)
                {
                    MessageBox.Show("La cuenta requiere indicar un canal contable.");
                    return false;
                }
            }
            if (RequiereProyecto == true)
            {
                //valido el proyecto
                int proyectoID = Convert.ToInt32(cboProyecto.SelectedValue);
                if (proyectoID == 0)
                {
                    MessageBox.Show("La cuenta requiere indicar un proyecto.");
                    return false;
                }
            }
            if (RequiereFechaVcto == true)
            {
                //valido la fecha de vencimiento
                DateTime fechavalida;                
                if (DateTime.TryParse(mtxtFechaVencimiento.Text, out fechavalida) == false)
                {
                    MessageBox.Show("Indique una fecha de vencimiento válida.");
                    return false;
                }

            }
            if (RequiereDocumento == true)
            {
                //valido datos del documento
                //valido tipo de documento
                Int32 tipodocumentoID = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                if (tipodocumentoID == 0)
                {
                    MessageBox.Show("La cuenta requiere indicar un tipo de documento.");
                    return false;
                }
                //valido fecha de emision
                DateTime fechavalida;
                if (DateTime.TryParse(mtxtFechaEmision.Text, out fechavalida) == false)
                {
                    MessageBox.Show("Indique una fecha de emisión válida.");
                    return false;
                }
                //valido numero de documento
                String numeroDocumento = txtDocumento.Text;
                if (numeroDocumento.Trim().Length == 0)
                {
                    MessageBox.Show("No ha indicado un número de documento.");
                    return false;
                }
                //valido empresa
                String rucEmpresa = txtEmpresa.Text.Trim();
                
                if (isNumeric(rucEmpresa) == false)
                {
                    return false;
                }

                String nombreEmpresa = lblRazonSocialEmpresa.Text;
                Int32 idEmpresa = Convert.ToInt32(lblEmpresaID.Text);
                
                if ((rucEmpresa.Trim().Length==0) || (nombreEmpresa.Trim().Length==0) || (idEmpresa == 0))
                {
                    MessageBox.Show("No ha indicado la empresa del documento.");
                    return false;
                }
            }
            if (RequiereFlujoCaja == true)
            {
                //valido el flujo de caja
                int flujocajaID = Convert.ToInt32(cboFlujoCaja.SelectedValue);
                if (flujocajaID == 0)
                {
                    MessageBox.Show("La cuenta requiere indicar el flujo de caja.");
                    return false;
                }
            }
            

            return true;
        }

        private bool isNumeric(string cadena)
        {
            for (int i=0; i< cadena.Length; i++)

            {

                if (char.IsDigit(cadena[i]) == false)
                {
                    return false;
                }

            }
            return true;
        }

        private void Agregar_Detalle(bool modifica) 
        {
            //agrega o actualiza detalle
            DataRow nuevaFila=null;

            Int32 detalleID = 0; 

            if (modifica == false)
            {
                nuevaFila = tablaDetalle.NewRow();
                nuevaFila["DetalleNuevo"] = 1;
                nuevaFila["DetalleEliminado"] = 0;
            }
            else
            {
                if (modifica == true)
                {
                    //OBTENGO EL ID
                    detalleID = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["DetalleID"].Value);
                    //LO BUSCO EN LA TABLA DETALLE
                    nuevaFila = tablaDetalle.Rows.Find(detalleID);
                    //si el detalle fue modificado se pone el valor
                    //de DetalleNuevo a 2 de ese modo solo se graban esos datos
                    //y no todo el asiento nuevamente
                    nuevaFila["DetalleNuevo"] = 2;
                }
                
            }

            //ahora tengo que recuperar los requerimientos de la cuenta
            //e ir enviando los datos en blanco o 0 cuando no son necesarios
            DataTable datosRCuenta = objCuentas.DatosCuenta(txtCuenta.Text, cDatos.EstablecimientoID);

            DataRow fila = datosRCuenta.Rows[0];

            bool RequiereArea = Convert.ToBoolean(fila["RequiereArea"]);//ya esta
            bool RequiereCanal = Convert.ToBoolean(fila["RequiereCanal"]);//ya esta
            bool RequiereProyecto = Convert.ToBoolean(fila["RequiereProyecto"]);//ya esta
            bool RequiereFechaVcto = Convert.ToBoolean(fila["RequiereFechaVencimiento"]);//ya esta
            bool RequiereDocumento = Convert.ToBoolean(fila["RequiereDocumento"]);//ya esta
            bool RequiereFlujoCaja = Convert.ToBoolean(fila["RequiereFlujoCaja"]);//ya esta
            //datos obligatorios
            nuevaFila["MontoDebe"]=Convert.ToDecimal(txtDebe.Text);
            nuevaFila["MontoHaber"] = Convert.ToDecimal(txtHaber.Text);
            nuevaFila["Dia"] = Convert.ToDateTime(mtxtFecha.Text);
            nuevaFila["Referencia"] = Convert.ToString(txtReferencia.Text);
            nuevaFila["MonedaId"] = Convert.ToInt32(cboMoneda.SelectedValue);
            int monedaId = Convert.ToInt32(cboMoneda.SelectedValue);
            nuevaFila["Moneda"] = Convert.ToString(cboMoneda.Text);
            decimal tipoCambio = Convert.ToDecimal(txtTipoCambio.Text);
            nuevaFila["TipoCambio"] = tipoCambio.ToString();
            nuevaFila["PeriodoID"] = Convert.ToDateTime(mtxtFecha.Text).Month.ToString();
            nuevaFila["TipoConversionMonedaID"] = Convert.ToString(cboTipoConversion.SelectedValue);
            nuevaFila["TipoConversionMoneda"] = Convert.ToString(cboTipoConversion.Text);

            //haber debe soles dolares
            if (monedaId==1)
            {
                nuevaFila["DebeSoles"]=nuevaFila["MontoDebe"];
                nuevaFila["HaberSoles"] = nuevaFila["MontoHaber"];
                nuevaFila["DebeDolares"] = Convert.ToDecimal(nuevaFila["MontoDebe"]) / tipoCambio;
                nuevaFila["HaberDolares"] = Convert.ToDecimal(nuevaFila["MontoHaber"]) / tipoCambio;
            }

            if (monedaId == 2)
            {
                nuevaFila["DebeDolares"] = nuevaFila["MontoDebe"];
                nuevaFila["HaberDolares"] = nuevaFila["MontoHaber"];
                nuevaFila["DebeSoles"] = Convert.ToDecimal(nuevaFila["MontoDebe"]) * tipoCambio;
                nuevaFila["HaberSoles"] = Convert.ToDecimal(nuevaFila["MontoHaber"]) * tipoCambio;
            }
            
            if (RequiereCanal == true)
            {
                nuevaFila["CanalContableID"] = Convert.ToString(cboCanalContable.SelectedValue);
                nuevaFila["CanalContable"] = cboCanalContable.Text;
            }
            else
            {
                nuevaFila["CanalContableID"] = "";
                nuevaFila["CanalContable"] = "";
            }
            
            DateTime fecha_valida;

            if (RequiereDocumento == true)
            {
                Int32 empresaID = 0;
                if (Int32.TryParse(lblEmpresaID.Text, out empresaID) == true)
                {
                    nuevaFila["EmpresaID"] = Convert.ToInt32(lblEmpresaID.Text);
                }
                else
                {
                    nuevaFila["EmpresaID"] = 0;
                }
                nuevaFila["Empresa"] = lblRazonSocialEmpresa.Text;
                nuevaFila["RUC"] = txtEmpresa.Text;
                nuevaFila["TipoDocumentoID"] = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                nuevaFila["TipoDocumento"] = Convert.ToString(cboTipoDocumento.Text);
                
                if (DateTime.TryParse(mtxtFechaEmision.Text, out fecha_valida) == true)
                {
                    nuevaFila["FechaEmision"] = Convert.ToDateTime(mtxtFechaEmision.Text);
                }
                else
                {
                    nuevaFila["FechaEmision"] = DBNull.Value;
                }
                nuevaFila["NumeroDocumento"] = Convert.ToString(txtDocumento.Text);
            }
            else
            {
                nuevaFila["EmpresaID"] = 0;
                nuevaFila["Empresa"] ="";
                nuevaFila["RUC"] = "";
                nuevaFila["TipoDocumentoID"] = 0;
                nuevaFila["TipoDocumento"] = "";
                nuevaFila["FechaEmision"] = DBNull.Value;
                nuevaFila["NumeroDocumento"] = "";
            }

            if (RequiereProyecto == true)
            {
                nuevaFila["ProyectoID"] = Convert.ToInt32(cboProyecto.SelectedValue);
                nuevaFila["Proyecto"] = Convert.ToString(cboProyecto.Text);
            }
            else
            {
                nuevaFila["ProyectoID"] = 0;
                nuevaFila["Proyecto"] = "";
            }


            if (RequiereFechaVcto == true)
            {
                if (DateTime.TryParse(mtxtFechaVencimiento.Text, out fecha_valida) == true)
                {
                    nuevaFila["FechaVencimiento"] = Convert.ToDateTime(mtxtFechaVencimiento.Text);
                }
                else
                {
                    nuevaFila["FechaVencimiento"] = DBNull.Value;
                }
            }
            else
            {
                nuevaFila["FechaVencimiento"] = DBNull.Value;
            }

            if (RequiereArea == true)
            {
                nuevaFila["AreaID"] = Convert.ToInt32(cboArea.SelectedValue);
                nuevaFila["Area"] = Convert.ToString(cboArea.Text);
                //los valores para las unidades de negocio
                //numero de filas del grid de unidades
                int numFilas = dgvAreas.Rows.Count;
                if (numFilas != 0)
                {
                    for (int i = 0; i < numFilas; i++)
                    {
                        string numero = cDatos.Right("00" + (i + 1).ToString().Trim(), 2);

                        nuevaFila["UnidadNegocio_" + numero + "_ID"] = Convert.ToInt32(dgvAreas.Rows[i].Cells["UnidadNegocioID"].Value);
                        decimal importe = Convert.ToDecimal(dgvAreas.Rows[i].Cells["Valor"].Value);
                        if (monedaId == 1)
                        {
                            nuevaFila["UnidadNegocio_" + numero + "_ImporteSoles"] = importe;
                            nuevaFila["UnidadNegocio_" + numero + "_ImporteDolares"] = importe / tipoCambio;
                        }

                        if (monedaId == 2)
                        {
                            nuevaFila["UnidadNegocio_" + numero + "_ImporteSoles"] = importe * tipoCambio;
                            nuevaFila["UnidadNegocio_" + numero + "_ImporteDolares"] = importe;
                        }
                    }
                }
            }
            else
            {
                nuevaFila["AreaID"] = 0;
                nuevaFila["Area"] = "";
                for (int i = 0; i <= 9; i++)
                {
                    string numero = cDatos.Right("00" + (i + 1).ToString().Trim(), 2);

                    nuevaFila["UnidadNegocio_" + numero + "_ID"] = 0;
                    nuevaFila["UnidadNegocio_" + numero + "_ImporteSoles"] = 0;
                    nuevaFila["UnidadNegocio_" + numero + "_ImporteDolares"] = 0;
                }
            }

            if (RequiereFlujoCaja == true)
            {
                nuevaFila["FlujoCajaID"] = Convert.ToInt32(cboFlujoCaja.SelectedValue);
                nuevaFila["FlujoCaja"] = Convert.ToString(cboFlujoCaja.Text);
            }
            else
            {
                nuevaFila["FlujoCajaID"] = 0;
                nuevaFila["FlujoCaja"] = "";
            }
            
            //el codigo interno de la cuenta
            if ((lblPlanCuentaID.Text.Trim().Length == 0) || (lblPlanCuentaID.Text == "0") || (lblPlanCuentaID.Text == null))
            {
                MessageBox.Show("Error al grabar el código de cuenta.");
                return;
            }

            nuevaFila["PlanCuentaID"] = Convert.ToString(lblPlanCuentaID.Text.Trim());
            //el nombre de la cuenta
            nuevaFila["PlanCuenta"] = Convert.ToString(lblNombreCuenta.Text);
            //el numero de la cuenta
            nuevaFila["PlanCuentaCodigo"] = Convert.ToString(txtCuenta.Text);
            //calcular importe soles y dolares
            decimal importeSoles = 0;
            decimal importeDolares = 0;
            
            decimal valor = 0;
            valor = Convert.ToDecimal(txtDebe.Text);
            if (valor == 0)
            {
                valor = Convert.ToDecimal(txtHaber.Text);
            }

            if (monedaId == 1)
            {
            //soles
                importeSoles = valor;
                importeDolares = valor / tipoCambio;
            }
            if (monedaId == 2)
            {
            //dolares
                importeDolares = valor;
                importeSoles = valor * tipoCambio;
            }

            nuevaFila["ImporteSoles"] = importeSoles;
            nuevaFila["ImporteDolares"] = importeDolares;

            if (modifica == false)
            {
                tablaDetalle.Rows.Add(nuevaFila);
            }
            if (modifica == true)
            {
                dgvDetalle.Update();
                dgvDetalle.Invalidate();
            }
            
            

        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            cargarTransferencias();

            colorearTransferencias();

            

        }

        private void colorearTransferencias()
        {

            Int32 fila_indice = 0;

            if (dgvDetalle.CurrentRow != null)
            {
                fila_indice = dgvDetalle.CurrentRow.Index;
            }
            else
            {
                return;
            }


            Int32 codigoDetalleIdSeleccionar = 0;

            codigoDetalleIdSeleccionar = Convert.ToInt32(dgvDetalle.Rows[fila_indice].Cells["DetalleId"].Value);

            //cargarTransferencias();

            //colorea las filas del grid de transferencias
            foreach (DataGridViewRow fila in dgvTransferencias.Rows)
            {
                Int32 idFilaTransferencia = 0;

                idFilaTransferencia = Convert.ToInt32(fila.Cells["AsientoContableDetalleIDTransferencia"].Value);

                if (idFilaTransferencia == codigoDetalleIdSeleccionar)
                {

                    dgvTransferencias.Rows[fila.Index].DefaultCellStyle.BackColor = Color.Tan;

                }
                else
                {
                    dgvTransferencias.Rows[fila.Index].DefaultCellStyle.BackColor = Color.Empty;
                }

            }
            //por ultimo tacha la fila del grid de detalle
            if (dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor == Color.Tan)
            {
                dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor = Color.Empty;
            }
            else
            {
                dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor = Color.Tan;
            }

        }

        private void dgvDetalle_RowEnter(object sender, DataGridViewCellEventArgs e)
        {


            Int32 fila_indice = 0;

            if (dgvDetalle.CurrentRow != null)
            {
                fila_indice = e.RowIndex;
                this.Text = fila_indice.ToString();
                
            }
            else
            {
                return;
            }

            //cargar los asientos de transferencias
            if (rbTodos.Checked == false)
            {

                DataView vistaF = tablaDetalleTransferencia.AsDataView();

                vistaF.RowFilter = "";


                if (rbFiltro.Checked == true)
                {
                    int filaID = fila_indice;

                    Int32 codigoDetalleId = Convert.ToInt32(dgvDetalle.Rows[filaID].Cells["DetalleId"].Value);

                    vistaF.RowFilter = "AsientoContableDetalleIdTransferencia = " + codigoDetalleId.ToString();

                    dgvTransferencias.DataSource = vistaF;

                    dgvTransferencias.Refresh();

                    formatoGrid(2);

                }
            }
            //fin de cargar los asientos de transferencias

            Int32 codigoDetalleIdSeleccionar = 0;

            codigoDetalleIdSeleccionar = Convert.ToInt32(dgvDetalle.Rows[fila_indice].Cells["DetalleId"].Value);

            //colorea las filas del grid de transferencias

            foreach (DataGridViewRow fila in dgvTransferencias.Rows)
            {
                Int32 idFilaTransferencia = 0;

                idFilaTransferencia = Convert.ToInt32(fila.Cells["AsientoContableDetalleIDTransferencia"].Value);

                if (idFilaTransferencia == codigoDetalleIdSeleccionar)
                {

                    dgvTransferencias.Rows[fila.Index].DefaultCellStyle.BackColor = Color.Tan;

                }
                else
                {
                    dgvTransferencias.Rows[fila.Index].DefaultCellStyle.BackColor = Color.Empty;
                }

            }

            //por ultimo colorea la fila del grid de detalle
            if (dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor == Color.Tan)
            {
                dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor = Color.Empty;
            }
            else
            {
                dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor = Color.Tan;
            }

            
        }

        private void dgvDetalle_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //deshace eliminar
            
            Int32 fila_indice = 0;
            fila_indice = e.RowIndex;
            dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor = Color.Empty;
            //Int32 codigoDetalleIdSeleccionar = 0;
            //codigoDetalleIdSeleccionar = Convert.ToInt32(dgvDetalle.Rows[fila_indice].Cells["DetalleId"].Value);
            
            
            ////destacha las filas del grid de transferencias
            //foreach (DataGridViewRow fila in dgvTransferencias.Rows)
            //{
            //    Int32 idFilaTransferencia = 0;

            //    idFilaTransferencia = Convert.ToInt32(fila.Cells["AsientoContableDetalleIDTransferencia"].Value);

            //    if (idFilaTransferencia == codigoDetalleIdSeleccionar)
            //    {
            //        //dgvTransferencias.Rows.RemoveAt(fila.Index);
            //        dgvTransferencias.Rows[fila.Index].DefaultCellStyle.BackColor=Color.Empty;
            //    }

            //}
            ////por ultimo destacha la fila del grid de detalle
            //dgvDetalle.Rows[fila_indice].DefaultCellStyle.BackColor = Color.Empty;
            ////dgvDetalle.Rows.RemoveAt(fila_indice);
            ////cargarTransferencias();
        }

        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                string accion = "";
                Int32 fila_indice = 0;
                fila_indice = dgvDetalle.CurrentRow.Index;

                Int32 codigoDetalleIdEliminar = 0;

                codigoDetalleIdEliminar = Convert.ToInt32(dgvDetalle.Rows[fila_indice].Cells["DetalleId"].Value);
                DataRow filaeliminar = tablaDetalle.Rows.Find(codigoDetalleIdEliminar);

                if (Convert.ToInt32(filaeliminar["DetalleEliminado"]) == 1)
                {
                    //si es eliminado, se deshace la eliminación
                    accion = "deshacer";
                }
                else
                {
                    accion = "eliminar";
                }

                if (accion == "eliminar")
                {
                    filaeliminar["DetalleEliminado"] = 1;
                    calcularTotales();
                    //tacha las filas del grid de transferencias
                    foreach (DataGridViewRow fila in dgvTransferencias.Rows)
                    {
                        Int32 idFilaTransferencia = 0;
                        idFilaTransferencia = Convert.ToInt32(fila.Cells["AsientoContableDetalleIDTransferencia"].Value);
                        if (idFilaTransferencia == codigoDetalleIdEliminar)
                        {
                            //dgvTransferencias.Rows.RemoveAt(fila.Index);
                            dgvTransferencias.Rows[fila.Index].DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Strikeout);
                        }

                    }

                    //por ultimo tacha la fila del grid de detalle
                    dgvDetalle.Rows[fila_indice].DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Strikeout);
                    //dgvDetalle.Rows.RemoveAt(fila_indice);

                }
                if (accion == "deshacer")
                {
                    
                        //deshace eliminar
                        //e.Handled = true;
                        //Int32 fila_indice = 0;
                        //fila_indice = dgvDetalle.CurrentRow.Index;

                        //Int32 codigoDetalleIdEliminar = 0;
                        //codigoDetalleIdEliminar = Convert.ToInt32(dgvDetalle.Rows[fila_indice].Cells["DetalleId"].Value);
                        //DataRow filaeliminar = tablaDetalle.Rows.Find(codigoDetalleIdEliminar);
                        filaeliminar["DetalleEliminado"] = 0;
                        calcularTotales();
                        //destacha las filas del grid de transferencias
                        foreach (DataGridViewRow fila in dgvTransferencias.Rows)
                        {
                            Int32 idFilaTransferencia = 0;

                            idFilaTransferencia = Convert.ToInt32(fila.Cells["AsientoContableDetalleIDTransferencia"].Value);

                            if (idFilaTransferencia == codigoDetalleIdEliminar)
                            {
                                //dgvTransferencias.Rows.RemoveAt(fila.Index);
                                dgvTransferencias.Rows[fila.Index].DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Regular);
                            }

                        }
                        //por ultimo destacha la fila del grid de detalle
                        dgvDetalle.Rows[fila_indice].DefaultCellStyle.Font = new Font(Font.Name, Font.Size, FontStyle.Regular);
                        //dgvDetalle.Rows.RemoveAt(fila_indice);
                    
                }
                
            }
                    
                        
            if (e.KeyData == (Keys.Alt | Keys.S))
            {
                //save data
            }
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow filaseleccionada = dgvDetalle.CurrentRow;

            if (Convert.ToInt32(filaseleccionada.Cells["DetalleEliminado"].Value) == 1)
            {
                MessageBox.Show("El detalle ha sido marcado para eliminar, no se puede modificar.");
                return;
            }

            btnAgregar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnCancelar.Enabled = false;
            
            dgvDetalle.Enabled = false;
            dgvTransferencias.Enabled = false;

            rbTodos.Enabled = false;
            rbFiltro.Enabled = false;

            btnActualizarDetalle.Visible = true;
            btnCancelarActualizarDetalle.Visible = true;
            lblAvisoModificaDetalle.Visible = true;
            
            cargarDetalleAModificar();
            
        }

        //private void modificarDetalle() 
        //{
        //    //modificar el detalle
        //    //al hacer doble clikc se cargan los datos para modificar el detalle
        //    //OBTENGO EL ID
        //    Int32 detalleID = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["DetalleID"].Value);
        //    //LO BUSCO EN LA TABLA DETALLE
        //    DataRow filamodifica = tablaDetalle.Rows.Find(detalleID);
        //    //modificar los datos obligatorios
        //    //***************************************************************************************************
        //    filamodifica["MontoDebe"]=Convert.ToDecimal(txtDebe.Text);
        //    filamodifica["MontoHaber"] = Convert.ToDecimal(txtHaber.Text);
            
        //    tablaDetalle.Columns.Add("DebeSoles", typeof(Decimal));
        //    tablaDetalle.Columns.Add("HaberSoles", typeof(Decimal));
        //    tablaDetalle.Columns.Add("DebeDolares", typeof(Decimal));
        //    tablaDetalle.Columns.Add("HaberDolares", typeof(Decimal));
        //    tablaDetalle.Columns.Add("CanalContableID", typeof(String));
        //    tablaDetalle.Columns.Add("CanalContable", typeof(String));
        //    tablaDetalle.Columns.Add("EmpresaID", typeof(Int32));
        //    tablaDetalle.Columns.Add("Empresa", typeof(String));
        //    tablaDetalle.Columns.Add("RUC", typeof(String));
        //    tablaDetalle.Columns.Add("TipoDocumentoID", typeof(Int32));
        //    tablaDetalle.Columns.Add("TipoDocumento", typeof(string));
        //    tablaDetalle.Columns.Add("ProyectoID", typeof(Int32));
        //    tablaDetalle.Columns.Add("Proyecto", typeof(String));
        //    tablaDetalle.Columns.Add("Dia", typeof(DateTime));
        //    tablaDetalle.Columns.Add("Referencia", typeof(String));
        //    tablaDetalle.Columns.Add("FechaEmision", typeof(DateTime));
        //    tablaDetalle.Columns.Add("FechaVencimiento", typeof(DateTime));
        //    tablaDetalle.Columns.Add("AreaID", typeof(Int32));
        //    tablaDetalle.Columns.Add("Area", typeof(String));
        //    tablaDetalle.Columns.Add("NumeroDocumento", typeof(String));

        //    tablaDetalle.Columns.Add("FlujoCajaID", typeof(Int32));
        //    tablaDetalle.Columns.Add("FlujoCaja", typeof(String));
        //    tablaDetalle.Columns.Add("PlanCuentaID", typeof(String));
        //    tablaDetalle.Columns.Add("PlanCuenta", typeof(String));
        //    tablaDetalle.Columns.Add("PlanCuentaCodigo", typeof(String));

        //    tablaDetalle.Columns.Add("MonedaID", typeof(Int32));
        //    tablaDetalle.Columns.Add("Moneda", typeof(String));
        //    tablaDetalle.Columns.Add("TipoCambio", typeof(Decimal));

        //    tablaDetalle.Columns.Add("ImporteSoles", typeof(Decimal));
        //    tablaDetalle.Columns.Add("ImporteDolares", typeof(Decimal));

        //    tablaDetalle.Columns.Add("PeriodoID", typeof(String));


        //    tablaDetalle.Columns.Add("TipoConversionMonedaID", typeof(String));
        //    tablaDetalle.Columns.Add("TipoConversionMoneda", typeof(String));

        //    //unidades de negocios (10)
        //    for (Int32 iUnd = 0; iUnd >= 10; iUnd++)
        //    {
        //        string etiqueta = "";
        //        //id de las unidades de negocios
        //        etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ID";
        //        tablaDetalle.Columns.Add(etiqueta, typeof(Int32));
        //        //importes en soles de las unidades de negocios
        //        etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteSoles";
        //        tablaDetalle.Columns.Add(etiqueta, typeof(Decimal));
        //        //importes en dolares de las unidades de negocios
        //        etiqueta = "UnidadNegocio_" + cDatos.Right("00" + iUnd.ToString(), 2) + "_ImporteDolares";
        //        tablaDetalle.Columns.Add(etiqueta, typeof(Decimal));
        //    }

        //    tablaDetalle.Columns.Add("AsientoContableDetalleIDTransferencia", typeof(String));

        //    tablaDetalle.Columns.Add("DetalleNuevo", typeof(Int32));

        //    //***************************************************************************************************
        //    //habilitar controles
        //    dgvDetalle.Enabled = true;
        //    //ocultar botones
        //    btnActualizarDetalle.Visible = false;
        //    btnCancelarActualizarDetalle.Visible = false;
        //}

        private void cargarDetalleAModificar()
        {
            //al hacer doble clikc se cargan los datos para modificar el detalle
            //OBTENGO EL ID
            Int32 detalleID = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["DetalleID"].Value);
            //LO BUSCO EN LA TABLA DETALLE

            DataRow filamodifica = tablaDetalle.Rows.Find(detalleID);

            //teniendo la fila a modificar cargo los datos en los campos que corresponda
            txtCuenta.Text = Convert.ToString(filamodifica["PlanCuentaCodigo"]);
            if (buscarCuentaCodigo(txtCuenta.Text) == true)
            {
                //buscar datos que requiere la cuenta
                //DATOS OBLIGATORIOS
                txtReferencia.Text = Convert.ToString(filamodifica["Referencia"]);
                txtDebe.Text = Convert.ToString(filamodifica["MontoDebe"]);
                txtHaber.Text = Convert.ToString(filamodifica["MontoHaber"]);
                cboMoneda.SelectedValue = filamodifica["monedaID"];
                Int32 monedaID = Convert.ToInt32(filamodifica["monedaID"]);
                cboTipoConversion.SelectedValue = filamodifica["TipoConversionMonedaID"];
                txtTipoCambio.Text = Convert.ToString(filamodifica["TipoCambio"]);

                //DATOS SEGUN LA CUENTA
                DataTable datosRCuenta = objCuentas.DatosCuenta(txtCuenta.Text, cDatos.EstablecimientoID);
                DataRow filaCuenta = datosRCuenta.Rows[0];

                bool RequiereArea = Convert.ToBoolean(filaCuenta["RequiereArea"]);//ya esta
                bool RequiereCanal = Convert.ToBoolean(filaCuenta["RequiereCanal"]);//ya esta
                bool RequiereProyecto = Convert.ToBoolean(filaCuenta["RequiereProyecto"]);//ya esta
                bool RequiereFechaVcto = Convert.ToBoolean(filaCuenta["RequiereFechaVencimiento"]);//ya esta
                bool RequiereDocumento = Convert.ToBoolean(filaCuenta["RequiereDocumento"]);//ya esta
                bool RequiereFlujoCaja = Convert.ToBoolean(filaCuenta["RequiereFlujoCaja"]);

                if (RequiereArea == true)
                {
                    //AREA
                    cboArea.SelectedValue = filamodifica["AreaID"];
                    //UNIDADES DE NEGOCIO
                    for (int i = 1; i <= 10; i++)
                    {
                        string numeroUnidad = cDatos.Right("00" + i.ToString(), 2);
                        string nombreCampo1 = "UnidadNegocio_" + numeroUnidad + "_ID";
                        Int32 unidadnegocioID = 0;
                        try
                        {
                            unidadnegocioID = Convert.ToInt32(filamodifica[nombreCampo1]);
                        }
                        catch
                        {
                            unidadnegocioID = 0;
                        }

                        if (dgvAreas.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow filaGrid in dgvAreas.Rows)
                            {

                                if (Convert.ToInt32(filaGrid.Cells["UnidadNegocioID"].Value) == unidadnegocioID)
                                {
                                    string nombreCampo2 = "UnidadNegocio_" + numeroUnidad + "_ImporteSoles";
                                    string nombreCampo3 = "UnidadNegocio_" + numeroUnidad + "_ImporteDolares";

                                    switch (monedaID)
                                    {
                                        case 1:
                                            filaGrid.Cells["Valor"].Value = filamodifica[nombreCampo2];
                                            break;
                                        case 2:
                                            filaGrid.Cells["Valor"].Value = filamodifica[nombreCampo3];
                                            break;
                                    }

                                }

                            }

                        }

                    }
                }
                else
                {
                    //MessageBox.Show(dgvAreas.Rows.Count.ToString());
                    dgvAreas.DataSource = null;
                }

                if (RequiereCanal == true)
                {
                    cboCanalContable.SelectedValue = filamodifica["CanalContableID"];
                }
                if (RequiereProyecto == true)
                {
                    cboProyecto.SelectedValue = filamodifica["ProyectoID"];
                }
                if (RequiereFechaVcto == true)
                {
                    mtxtFechaVencimiento.Text = Convert.ToString(filamodifica["FechaVencimiento"]);
                }
                if (RequiereDocumento == true)
                {
                    cboTipoDocumento.SelectedValue = filamodifica["TipoDocumentoID"];
                    mtxtFechaEmision.Text = Convert.ToString(filamodifica["FechaEmision"]);
                    txtDocumento.Text = Convert.ToString(filamodifica["NumeroDocumento"]);
                    txtEmpresa.Text = Convert.ToString(filamodifica["RUC"]);
                    lblEmpresaID.Text = Convert.ToString(filamodifica["EmpresaID"]);
                    lblRazonSocialEmpresa.Text = Convert.ToString(filamodifica["Empresa"]);
                }
                if (RequiereFlujoCaja == true)
                {
                    cboFlujoCaja.SelectedValue = filamodifica["FlujoCajaID"];
                }

                //MessageBox.Show(Convert.ToString(filamodifica["Referencia"]));
            }
            //SendKeys.Send("{ENTER}");
            //jalar los Datos de la
            //formatoGridDetalle();
            //DETALLE
            formatoGrid(1);
            //formatoGridTransferencias();
            //TRANSFERENCIA
            formatoGrid(2);

        }

        private void btnCancelarActualizarDetalle_Click(object sender, EventArgs e)
        {

            if (btnCancelarActualizarDetalle.Visible == false)
            {
                return;
            }

            btnActualizarDetalle.Visible = false;
            btnCancelarActualizarDetalle.Visible = false;
            btnCancelar.Enabled = true;

            dgvDetalle.Enabled = true;
            dgvTransferencias.Enabled = true;

            rbTodos.Enabled = true;
            rbFiltro.Enabled = true;

            lblAvisoModificaDetalle.Visible = false;

            btnAgregar.Enabled = true;
            btnFinalizar.Enabled = true;

        }

        private void btnActualizarDetalle_Click(object sender, EventArgs e)
        {

            if (btnActualizarDetalle.Visible == false)
            {
                return;
            }

            if (validarDatosDetalle() == true)
            {
                Agregar_Detalle(true);

                btnActualizarDetalle.Visible = false;

                btnCancelarActualizarDetalle.Visible = false;

                dgvDetalle.Enabled = true;
                dgvTransferencias.Enabled = true;

                rbTodos.Enabled = true;
                rbFiltro.Enabled = true;

                lblAvisoModificaDetalle.Visible = false;

                btnAgregar.Enabled = true;

                btnFinalizar.Enabled = true;

                seModifico = true;

                calcularTotales();
            }
            
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            calFecha.Visible = !calFecha.Visible;
        }

        private void calFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            mtxtFecha.Text = "";
            mtxtFecha.Text = calFecha.SelectionRange.Start.ToShortDateString();
            calFecha.Visible = false;
            mtxtFecha.Focus();
            mtxtFecha.SelectAll();
            //txtFecha.SelectedText = txtFecha.Text;
        }

        private void mtxtFecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

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

        private void mtxtFechaEmision_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mtxtFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
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

        private string formatoFecha(string Texto)
        {
            //no debe tener /

            string dia = Texto.Substring(0, 2);
            string mes = Texto.Substring(2, 2);
            string anio = Texto.Substring(4, 4);

            string salida = dia + "/" + mes + "/" + anio;

            return salida;

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            ConfigurationManager.AppSettings["PRA_MonedaId"] = cboMoneda.SelectedValue.ToString();

            ConfigurationManager.AppSettings["PRA_TipoConversionId"] = cboTipoConversion.SelectedValue.ToString();
            
            //boton finalizar
            //validar si no hay diferencia entre debe y haber
            calcularTotales();

            if (txtDiferenciaSoles.Text != "0.00")
            {

                MessageBox.Show("El asiento no está cuadrado.");

                return;

            }

            //finalizar el asiento
            String codigoAsiento;

            BLAsientos objAsientos = new BLAsientos();

            if (nuevo == true)
            {
                codigoAsiento = "0";
            }
            else
            {
                codigoAsiento = asientoContableId.ToString();
            }
            /*
             * PARTE DONDE SE GRABA LA CABECERA DEL VOUCHER
             */
            //guardar el encabezado
            codigoAsiento = objAsientos.setCreaAsientoCabecera("ACC", cDatos.EstablecimientoID.ToString(), cDatos.Periodo.ToString(), codigoAsiento, subDiarioId, cDatos.HotelID, txtGlosa.Text, txtComprobante.Text, Convert.ToDateTime(mtxtFecha.Text), cDatos.UsuarioID, cDatos.UsuarioID, PartnerManager.funcionesSistema.ipEquipo(), PartnerManager.funcionesSistema.nombreUsuarioWindows(), PartnerManager.funcionesSistema.nombreEquipo(), "", 0);

            asientoContableId = Convert.ToInt32(codigoAsiento);

            //txtComprobante.Text = codigoAsiento;
            //objAsientos.setCreaAsientoDetalle(
            //guardar el detalle
            //filtrar los detalles que tenga el campo DetalleNuevo con valor 1 o con valor 2
            //son los únicos que se van a modificar o grabar
            DataView vistaDetalles;
            vistaDetalles = tablaDetalle.DefaultView;

            vistaDetalles.RowFilter = "DetalleNuevo in (1,2)";

            //PARTE DONDE SE GRABAN LOS DETALLES DEL VOUCHER
            //foreach (DataRow fila in tablaDetalle.Rows)
            foreach (DataRow fila in vistaDetalles.ToTable().Rows)
            {
                //inicio del bucle FOR
                String vDetalleId = "";

                String vPlanCuentaID = Convert.ToString(fila["PlanCuentaID"]);
                
                if (Convert.ToInt32(fila["DetalleNuevo"]) == 1)
                {

                    vDetalleId = "0";

                }
                else
                {
                    if (Convert.ToInt32(fila["DetalleNuevo"]) == 2)
                    {
                        vDetalleId = Convert.ToString(fila["DetalleId"]); 
                    }
                    else
                    {
                        nuevo = false;
                        continue;
                    }
                }

                //obtener que datos son requeridos por la cuenta
                String codigoCuenta = Convert.ToString(fila["PlanCuentaCodigo"]);
                DataTable reqCuenta = objCuentas.DatosCuenta(codigoCuenta, cDatos.EstablecimientoID);
                DataRow filaReqCuenta = reqCuenta.Rows[0];
                bool cRequiereArea = Convert.ToBoolean(filaReqCuenta["RequiereArea"]);
                bool cRequiereCanal = Convert.ToBoolean(filaReqCuenta["RequiereCanal"]);
                bool cRequiereProyecto = Convert.ToBoolean(filaReqCuenta["RequiereProyecto"]);
                bool cRequiereFechaVcto = Convert.ToBoolean(filaReqCuenta["RequiereFechaVencimiento"]);
                bool cRequiereDocumento = Convert.ToBoolean(filaReqCuenta["RequiereDocumento"]);
                bool cRequiereFlujoCaja = Convert.ToBoolean(filaReqCuenta["RequiereFlujoCaja"]);
                //fin de obtener que datos son requeridos por la cuenta

                Decimal vMontoDebe = 0;
                Decimal vMontoHaber = 0;
                String vCanalContableId = "";

                try
                {
                    vMontoDebe = Convert.ToDecimal(fila["MontoDebe"]);
                }
                catch
                {
                    vMontoDebe = 0;
                }

                try
                {
                    vMontoHaber = Convert.ToDecimal(fila["MontoHaber"]);
                }
                catch 
                {
                    vMontoHaber = 0;
                }

                if (cRequiereCanal == true)
                {
                    try
                    {
                        vCanalContableId = Convert.ToString(fila["CanalContableID"]);
                    }
                    catch
                    {
                        vCanalContableId = "";
                    }
                }
                else
                {
                    vCanalContableId = "";
                }

                Int32 vEmpresaId = 0;
                Int32 vTipoDocumentoId = 0;
                DateTime vFechaEmision;
                DateTime vFechaVencimiento;
                String vNumeroDocumento = "";
                String vTransaccionDocumentoID = "";
                if (cRequiereDocumento == true)
                {
                    vEmpresaId = Convert.ToInt32(fila["EmpresaID"]);
                    vTipoDocumentoId = Convert.ToInt32(fila["TipoDocumentoID"]);
                    try
                    {
                        vFechaEmision = Convert.ToDateTime(fila["FechaEmision"]);
                    }
                    catch
                    {
                        vFechaEmision = DateTime.Now;
                    }
                    try
                    {
                        vFechaVencimiento = Convert.ToDateTime(fila["FechaVencimiento"]);
                    }
                    catch
                    {
                        vFechaVencimiento = DateTime.Now;
                    }
                    
                    vNumeroDocumento = Convert.ToString(fila["NumeroDocumento"]);

                    vTransaccionDocumentoID = Convert.ToString(fila["NumeroDocumento"]);
                }
                else
                {
                    vEmpresaId = 0;
                    vTipoDocumentoId = 0;
                    vFechaEmision = DateTime.Now;
                    vFechaVencimiento = DateTime.Now;
                    vNumeroDocumento = "";
                    vTransaccionDocumentoID = "";
                }

                Int32 vProyectoID = 0;
                if (cRequiereProyecto == true)
                {
                    vProyectoID = Convert.ToInt32(fila["ProyectoID"]);
                }
                else
                {
                    vProyectoID = 0;
                }

                DateTime vDia = Convert.ToDateTime(fila["Dia"]);

                String vReferencia = Convert.ToString(fila["Referencia"]);

                Int32 vAreaID = 0;
                Int32[] vUnidadNegocioId = new Int32[10];
                Decimal[] vUNImporteSoles = new Decimal[10];
                Decimal[] vUNImporteDolares = new Decimal[10];
                 if (cRequiereArea == true)
                {
                    vAreaID = Convert.ToInt32(fila["AreaID"]);
                    
                    //unidades de negocios

                    for (Int32 _num = 1; _num <= 10; _num++)
                    {
                        try
                        {
                            vUnidadNegocioId[_num - 1] = Convert.ToInt32(fila["UnidadNegocio_" + cDatos.Right("0" + _num.ToString(), 2) + "_ID"]);

                            vUNImporteSoles[_num - 1] = Convert.ToDecimal(fila["UnidadNegocio_" + cDatos.Right("0" + _num.ToString(), 2) + "_ImporteSoles"]);
                            vUNImporteDolares[_num - 1] = Convert.ToDecimal(fila["UnidadNegocio_" + cDatos.Right("0" + _num.ToString(), 2) + "_ImporteDolares"]);
                        }
                        catch
                        {

                            vUnidadNegocioId[_num - 1] = 0;

                            vUNImporteSoles[_num - 1] = 0;

                            vUNImporteDolares[_num - 1] = 0;

                        }

                    }
                }
                else
                {
                    
                    vAreaID = 0;

                    for (Int32 _num = 1; _num <= 10; _num++)
                    {
                        vUnidadNegocioId[_num - 1] = 0;

                        vUNImporteSoles[_num - 1] = 0;

                        vUNImporteDolares[_num - 1] = 0;
                    }

                }

                Int32 vFlujoCajaID = 0;

                if (cRequiereFlujoCaja == true)
                {
                    vFlujoCajaID = Convert.ToInt32(fila["FlujoCajaID"]);
                }
                else
                {
                    vFlujoCajaID = 0;
                }

                Decimal vImporteSoles = Convert.ToDecimal(fila["ImporteSoles"]);

                Decimal vImporteDolares = Convert.ToDecimal(fila["ImporteDolares"]);

                String vAsientoContableDetalleIDTransferencia = Convert.ToString(fila["AsientoContableDetalleIDTransferencia"]);

                String vPeriodoID = Convert.ToString(fila["PeriodoID"]);

                String vTablaMovimientoIDAsientos = ""; //=Convert.ToString(fila["TablaMovimientoIDAsientos"]);

                String vTipoConversionMonedaID = Convert.ToString(fila["TipoConversionMonedaID"]);

                Int32 vMonedaID = Convert.ToInt32(fila["MonedaID"]);

                String vTipoCambio = Convert.ToString(fila["TipoCambio"]);

                if (Convert.ToInt32(fila["DetalleEliminado"]) != 1)
                {
                    //se debe crear el detalle, solo si la cuenta tiene un ID válido
                    if (vPlanCuentaID.Trim().Length != 0)
                    {

                        if (vPlanCuentaID.Trim() == "0")
                        {
                            MessageBox.Show("Error al guardar el detalle.");
                            return;
                        }

                        vAsientoContableDetalleIDTransferencia = vAsientoContableDetalleIDTransferencia.Trim();

                        if (vAsientoContableDetalleIDTransferencia == "")
                        {
                            vAsientoContableDetalleIDTransferencia = "0";
                        }

                        if (vCanalContableId == "")
                        {
                            vCanalContableId = "0";
                        }

                        objAsiento.setCreaAsientoDetalle(cDatos.EstablecimientoID.ToString(), cDatos.Periodo.ToString(), vDetalleId, asientoContableId.ToString(), vMontoDebe, vMontoHaber, vCanalContableId, vEmpresaId, vTipoDocumentoId, vProyectoID, vDia, vReferencia, vFechaEmision, vFechaVencimiento, vAreaID, vNumeroDocumento, vTransaccionDocumentoID, vFlujoCajaID, vPlanCuentaID.Trim(), vImporteSoles, vImporteDolares, vAsientoContableDetalleIDTransferencia, vPeriodoID, vTablaMovimientoIDAsientos, vUnidadNegocioId, vUNImporteSoles, vUNImporteDolares, vTipoConversionMonedaID, vMonedaID, vTipoCambio);

                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el detalle.");
                        return;
                    }


                }
                else
                {
                    if ((Convert.ToInt32(fila["DetalleEliminado"]) == 1) && (Convert.ToInt32(fila["DetalleNuevo"]) != 1))
                    {
                        //si el asiento está marcado para eliminar y no es un nuevo registro, es decir
                        //si está grabado en la base de datos se procede a eliminar
                        objAsiento.eliminarDetalle(cDatos.EstablecimientoID.ToString(), cDatos.Periodo.ToString(), asientoContableId.ToString(), vDetalleId, cDatos.UsuarioID, 0, PartnerManager.funcionesSistema.ipEquipo(), PartnerManager.funcionesSistema.nombreUsuarioWindows(), PartnerManager.funcionesSistema.nombreEquipo(), "", cDatos.HotelID);

                    }
                }

                nuevo = false;

            //fin del bucle FOR
            }
            //mostrar las cuentas derivadas
            cargarAsientoParaEditar();
            //cerrar ventana
            this.Close();
        
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //recoger los datos
            if (validarDatosDetalle() == true)
            {
                Agregar_Detalle(false);
                CargarDetalle();
                seModifico = true;
                txtCuenta.Focus();

            }
            else
            {
                MessageBox.Show("Faltan datos o son incorrectos.");
            }

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (seModifico == true)
            {
                if (MessageBox.Show("Se realizaron cambios en el asiento. ¿Desea cerrar la ventana de todas formas?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            
            CargarDetalle();
            
        }

        private void rbFiltro_CheckedChanged(object sender, EventArgs e)
        {

            CargarDetalle();
            
        }

        private void cargarTransferencias()
        {
            if (rbTodos.Checked == true)
            {
                dgvTransferencias.DataSource = tablaDetalleTransferencia;
            }

            else
            {

                DataView vistaF = tablaDetalleTransferencia.AsDataView();

                vistaF.RowFilter = "";


                if (rbFiltro.Checked == true)
                {
                    int filaID = dgvDetalle.CurrentRow.Index;

                    Int32 codigoDetalleId = Convert.ToInt32(dgvDetalle.Rows[filaID].Cells["DetalleId"].Value);

                    vistaF.RowFilter = "AsientoContableDetalleIdTransferencia = " + codigoDetalleId.ToString();

                    dgvTransferencias.Visible = false;

                    dgvTransferencias.DataSource = vistaF;

                    dgvTransferencias.Refresh();

                    formatoGrid(2);

                    dgvTransferencias.Visible = true;

                }
            }
        }

        private void btnBuscarEmpresa_Click(object sender, EventArgs e)
        {
            frmBuscarEmpresa frmBuscador = new frmBuscarEmpresa();

            frmBuscador.pRUCEmpresa = txtEmpresa.Text.Trim();

            frmBuscador.ShowDialog(this);

            if (frmBuscador.cancelo_formulario == true)
            {
                return;
            }

            txtEmpresa.Text = frmBuscador.pRUCEmpresa.Trim();
            //RaiseKeyEvent(
            //lblNombreCuenta.Text = "";
            //mostrar los campos obligatorios
            txtEmpresa.Text = frmBuscador.pRUCEmpresa.Trim();
            try
            {
                lblEmpresaID.Text = frmBuscador._EmpresaID.Trim();
            }
            catch
            {
                MessageBox.Show("Error al seleccionar la empresa.");
                return;
            }

            if (lblEmpresaID.Text == null)
            {
                MessageBox.Show("Error al seleccionar la empresa.");
                return;
            }

            //RaiseKeyEvent
            txtEmpresa.SelectAll();

            txtEmpresa.Focus();

            SendKeys.Send("{ENTER}");
        }

        private void dgvAreas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAreas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           //YA TERMINO DE ESCRIBIR EN LA CELDA, SE calcula la diferencia
            //calcular diferencia entre el total y los valores
            Decimal totalUND = calcularTotalUnidades();

            Decimal _dif = calcularDiferenciaUnidades(totalUND);
            
                lblDiferencia.Text = (_dif > 0 ? _dif : (-1 * _dif)).ToString();
           

           


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private Decimal calcularTotalUnidades()
        {
            Decimal _totalUND = 0;
            foreach (DataGridViewRow fila in dgvAreas.Rows)
            {
                try
                {
                    Decimal montoUnidad = Convert.ToDecimal(fila.Cells["Valor"].Value);
                    _totalUND = _totalUND + montoUnidad;
                }
                catch
                {
                    _totalUND = _totalUND + 0;
                }

            }

            return _totalUND;

        }

        private Decimal calcularDiferenciaUnidades(Decimal _totalUND)
        {
            decimal _importeAsiento = 0;
            decimal _diferencia = 0;
            if (Decimal.TryParse(txtDebe.Text, out _importeAsiento) == true)
            {
                if (_importeAsiento != 0)
                {
                _diferencia = (_totalUND - _importeAsiento);
                }
                else
                {
                    if (Decimal.TryParse(txtHaber.Text, out _importeAsiento) == true)
                    {
                        _diferencia = (_totalUND - _importeAsiento);
                    }
                }
            }

           
                return _diferencia;
           
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            
            try
             {

                //ajusta la fila de la unidad seleccionada
                Int32 fila_indice = 0;

                fila_indice = dgvAreas.CurrentRow.Index;

                Decimal totalUND = calcularTotalUnidades();
                Decimal dif1 = calcularDiferenciaUnidades(totalUND);


                dgvAreas.CurrentRow.Cells["Valor"].Value = Convert.ToDecimal(dgvAreas.CurrentRow.Cells["Valor"].Value) - dif1;

                totalUND = calcularTotalUnidades();

                lblDiferencia.Text = calcularDiferenciaUnidades(totalUND).ToString();

            }
            catch
            {
                
            }
        }

        private void dgvTransferencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalle_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblNombreCuenta_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            cargarAsientoParaEditar();
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                //operacion cancelada


            }
            else if (e.Error != null)
            {
                MessageBox.Show("Un error ocurrió:" + e.Error.Message);
            }
            else
            {
                asientoCargado = true;
            }

 
        }

    }
}
