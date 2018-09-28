using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Contabilidad
{
    public partial class MDIPadre : Form
    {
        //private int childFormNumber = 0;
        /*
         * Ruta para distribuir en BTH      \\Foyer\ActualizaConta\
         * Ruta para distribuir en Antigua  \\ServerHotelera\ActualizaConta\
         \*/

        public MDIPadre()
        {
            InitializeComponent();
        }

       

     

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private bool verificarProcedimientos_V2()
        {
            BL.BLComprobador comprobador = new BL.BLComprobador();

            if (comprobador.validarConexion() == false)
            {
                frmConfigurarConexion configurador = new frmConfigurarConexion();
                if (configurador.ShowDialog() == DialogResult.OK)
                {
                    //
                }
                else
                {
                    return false;
                }

            }

            //lista de procedimientos
            //string[] procedimientos = new string[]
            String[] procedimientos;

            procedimientos = new String[500];

            const string PROC_SSOC_AMNISTIARCARGOS = "ssoc_AministarCargos";
            procedimientos[0] = PROC_SSOC_AMNISTIARCARGOS;
            const string PROC_SSOC_LISTARAMNISTIADETALLE = "ssoc_ListarAmnistiaDetalle";
            procedimientos[1] = PROC_SSOC_LISTARAMNISTIADETALLE;
            const string PROC_SSOC_LISTARAMNISTIAS = "ssoc_ListarAmnistias";
            procedimientos[2] = PROC_SSOC_LISTARAMNISTIAS;
            const string PROC_USO_CREAACTUALIZAAMNISTIA = "USO_CreaActualizaAmnistia";
            procedimientos[3] = PROC_USO_CREAACTUALIZAAMNISTIA;
            const string PROC_SSOC_REPORTE_AMNISTIA = "ssoc_ReporteAmnistia";
            procedimientos[4] = PROC_SSOC_REPORTE_AMNISTIA;
            const string PROC_LISTAR_CUENTACORRIENTE = "ssoc_ListarCuentaCorriente";
            procedimientos[5] = PROC_LISTAR_CUENTACORRIENTE;
            const string PROC_VERIFICARCARGOPRODUCTO = "ssoc_VerificarCargoProducto";
            procedimientos[6] = PROC_VERIFICARCARGOPRODUCTO;
            const string PROC_PROCESAR_CARGOSSOCIO2 = "ssoc_ProcesarCargosSocio2";
            procedimientos[7] = PROC_PROCESAR_CARGOSSOCIO2;
            const string PROC_PROCESAR_CARGOSSOCIO3 = "ssoc_ProcesarCargosSocio3";
            procedimientos[8] = PROC_PROCESAR_CARGOSSOCIO3;
            const string PROC_AGREGACARGO_CUENTACORRIENTE = "ssoc_Agrega_Cargo_CtaCte";
            procedimientos[9] = PROC_AGREGACARGO_CUENTACORRIENTE;
            const string PROC_BUSCAR_SOCIOSDEUDA = "ssoc_BuscarSociosDeuda";
            procedimientos[10] = PROC_BUSCAR_SOCIOSDEUDA;
            const string PROC_SOCIO_DEUDADETALLADA = "ssoc_SocioDeudaDetallada";
            procedimientos[11] = PROC_SOCIO_DEUDADETALLADA;
            const string PROC_REPORTE_CARGOSPENDIENTES = "ssoc_ReporteCargosPendientes";
            procedimientos[12] = PROC_REPORTE_CARGOSPENDIENTES;
            const string PROC_REPORTE_CARGOSPENDIENTES_MESES = "ssoc_ReporteCargosPendientes_v2";
            procedimientos[13] = PROC_REPORTE_CARGOSPENDIENTES_MESES;
            const string PROC_REPORTE_LISTADO_SOCIOSDEUDAS = "ssoc_ReporteSociosDeudasListado";
            procedimientos[14] = PROC_REPORTE_LISTADO_SOCIOSDEUDAS;
            const string PROC_PROCESAR_MORA = "ssoc_CalculaMoraSocio";
            procedimientos[15] = PROC_PROCESAR_MORA;
            const string PROC_REPORTE_LISTADO_SOCIOSDEUDAS_PENDIENTES = "ssoc_Reporte_CargosPendientes";
            procedimientos[16] = PROC_REPORTE_LISTADO_SOCIOSDEUDAS_PENDIENTES;
            const string PROC_LISTAR_MONEDA = "ssoc_ListarMoneda";
            procedimientos[17] = PROC_LISTAR_MONEDA;

            const string PROC_LISTAR_PRODUCTOS_SOCIOTIPO = "ssoc_ListarProductosSocioTipo";
            procedimientos[18] = PROC_LISTAR_PRODUCTOS_SOCIOTIPO;
            const string PROC_LISTAR_PRODUCTOS_SOCIO = "ssoc_ListarProductosSocio";
            procedimientos[19] = PROC_LISTAR_PRODUCTOS_SOCIO;
            const string PROC_CREAACTUALIZA_PRODUCTOS_SOCIOTIPO = "USO_CreaActualizaProductoSocioTipo";
            procedimientos[20] = PROC_CREAACTUALIZA_PRODUCTOS_SOCIOTIPO;
            const string PROC_CREAACTUALIZA_PRODUCTOS_SOCIO = "USO_CreaActualizaProductoSocio";
            procedimientos[21] = PROC_CREAACTUALIZA_PRODUCTOS_SOCIO;
            const string PROC_CREAACTUALIZA_PRODUCTOS_SOCIOGROUP = "USO_CreaActualizaProductoSocioGroup";
            procedimientos[22] = PROC_CREAACTUALIZA_PRODUCTOS_SOCIOGROUP;
            const string PROC_CREAACTUALIZA_AUTO = "USO_CreaActualizaAuto";
            procedimientos[23] = PROC_CREAACTUALIZA_AUTO;
            const string PROC_LISTAR_AUTOS_SOCIO = "ssoc_ListarAutosSocio";
            procedimientos[24] = PROC_LISTAR_AUTOS_SOCIO;
            const string PROC_BUSCAR_AUTOS_PLACA = "ssoc_BuscarAutosPlaca";
            procedimientos[25] = PROC_BUSCAR_AUTOS_PLACA;
            const string PROC_CREAACTUALIZA_CASILLERO = "USO_CreaActualizaCasillero";
            procedimientos[26] = PROC_CREAACTUALIZA_CASILLERO;
            const string PROC_LISTAR_CASILLEROS_SOCIO = "ssoc_ListarCasillerosSocio";
            procedimientos[27] = PROC_LISTAR_CASILLEROS_SOCIO;
            const string PROC_LISTAR_AREAS = "ssoc_ListarAreas";
            procedimientos[28] = PROC_LISTAR_AREAS;
            const string PROC_LISTAR_PRODUCTOS = "ssoc_ListarProductos";
            procedimientos[29] = PROC_LISTAR_PRODUCTOS;
            const string PROC_CREAACTUALIZA_SOCIO = "USO_CreaActualizaSocio";
            procedimientos[30] = PROC_CREAACTUALIZA_SOCIO;
            const string PROC_LISTAR_PROFESIONES = "ssoc_ListarProfesiones";
            procedimientos[31] = PROC_LISTAR_PROFESIONES;
            const string PROC_LISTAR_PAISES = "ssoc_ListarPaises";
            procedimientos[32] = PROC_LISTAR_PAISES;
            const string PROC_LISTAR_CIUDADES = "ssoc_ListarCiudades";
            procedimientos[33] = PROC_LISTAR_CIUDADES;
            const string PROC_LISTAR_DISTRITOS = "ssoc_ListarDistritos";
            procedimientos[34] = PROC_LISTAR_DISTRITOS;
            const string PROC_LISTAR_TIPOIDENTIDAD = "ssoc_ListarTipoIdentidad";
            procedimientos[35] = PROC_LISTAR_TIPOIDENTIDAD;
            const string PROC_LISTAR_SEXO = "ssoc_ListarSexo";
            procedimientos[36] = PROC_LISTAR_SEXO;
            const string PROC_LISTAR_PARENTESCO = "ssoc_ListarTipoParentesco";
            procedimientos[37] = PROC_LISTAR_PARENTESCO;
            const string PROC_LISTAR_TIPOPLAN = "ssoc_ListarTipoPlan";
            procedimientos[38] = PROC_LISTAR_TIPOPLAN;
            const string PROC_LISTAR_SOCIOS = "ssoc_ListarSocios";
            procedimientos[39] = PROC_LISTAR_SOCIOS;
            const string PROC_LISTAR_SOCIO = "ssoc_ListarSocio";
            procedimientos[40] = PROC_LISTAR_SOCIO;
            const string PROC_CREAACTUALIZA_SOCIODEPENDIENTE = "USO_CreaActualizaSocioDependiente";
            procedimientos[41] = PROC_CREAACTUALIZA_SOCIODEPENDIENTE;
            const string PROC_LISTAR_DEPENDIENTESSOCIO = "ssoc_ListarDependientesSocio";
            procedimientos[42] = PROC_LISTAR_DEPENDIENTESSOCIO;
            const string PROC_CAMBIAR_TIPOSOCIO = "ssoc_CambiarTipoSocio";
            procedimientos[43] = PROC_CAMBIAR_TIPOSOCIO;
            const string PROC_REPORTE_PADRONSOCIOS = "ssoc_Reporte_SociosPadron";
            procedimientos[44] = PROC_REPORTE_PADRONSOCIOS;
            const string PROC_LISTAR_CARGOS = "ssoc_ListarCargos";
            procedimientos[45] = PROC_LISTAR_CARGOS;
            const string PROC_CREA_ACTUALIZA_CARGOS = "ssoc_CreaActualizaCargo";
            procedimientos[46] = PROC_CREA_ACTUALIZA_CARGOS;

            const string PROC_LISTAR_SOCIOTIPO = "ssoc_ListarSocioTipo";
            procedimientos[47] = PROC_LISTAR_SOCIOTIPO;
            const string PROC_CREAACTUALIZA_SOCIOTIPO = "USO_CreaActualizaSocioTipo";
            procedimientos[48] = PROC_CREAACTUALIZA_SOCIOTIPO;

            const string PROC_LISTAR_TIPOCAMBIO = "ssoc_ListarTipoCambio";
            procedimientos[49] = PROC_LISTAR_TIPOCAMBIO;

            const string PROC_LOGIN = "ssoc_Login";
            procedimientos[50] = PROC_LOGIN;

            const string PROC_REPORTE_RELACIONGRAL = "ssoc_ReporteRelacionGeneral";
            procedimientos[51] = PROC_REPORTE_RELACIONGRAL;

            const string PROC_LISTAR_SOCIOTIPO_2 = "ssoc_ListarSocioTipo_Productos";
            procedimientos[52] = PROC_LISTAR_SOCIOTIPO_2;

            const string PROC_CREA_PRODUCTOS_SOCIOTIPO = "ssoc_CreaProductoSocioTipo";
            procedimientos[53] = PROC_CREA_PRODUCTOS_SOCIOTIPO;

            const string PROC_ELIMINA_PRODUCTOS_SOCIOTIPO = "ssoc_EliminaProductoSocioTipo";
            procedimientos[54] = PROC_ELIMINA_PRODUCTOS_SOCIOTIPO;

            const string PROC_ELIMINA_PRODUCTOS_SOCIO = "ssoc_EliminaProductoSocio";
            procedimientos[55] = PROC_ELIMINA_PRODUCTOS_SOCIO;

            const string PROC_TIPOCAMBIO_FECHA = "ssoc_ListarTipoCambio_Fecha";
            procedimientos[56] = PROC_TIPOCAMBIO_FECHA;

            const string PROC_CARGAR_CUOTA_INSCRIPCION = "ssoc_CargarCuotaInscripcion";
            procedimientos[57] = PROC_CARGAR_CUOTA_INSCRIPCION;

            const string PROC_CAMBIAR_ESTADOCANCELADO_CUENTACORRIENTE = "ssoc_CambiarEstadoCargo";
            procedimientos[58] = PROC_CAMBIAR_ESTADOCANCELADO_CUENTACORRIENTE;

            const string PROC_REPORTE_SOCIOS_HABILES = "ssoc_Reporte_Socios_Habiles";
            procedimientos[59] = PROC_REPORTE_SOCIOS_HABILES;

            const string PROC_PROCESAR_MORA_2 = "ssoc_CalcularMora_Socios_v3";
            procedimientos[59] = PROC_PROCESAR_MORA_2;
            //RECORRER EL ARREGLO

            StringBuilder Texto = new StringBuilder();

            int numero = 0;

            string nombre_procedimiento;

            for (numero = 0; numero < 500; numero++)
            {
                if (procedimientos[numero] == null)
                {
                    nombre_procedimiento = "";
                }
                else
                {
                    nombre_procedimiento = procedimientos[numero];
                }

                if (nombre_procedimiento.Trim().Length != 0)
                {
                    if (comprobador.ExisteProcedimiento(nombre_procedimiento) == false)
                    {
                        Texto.AppendLine(nombre_procedimiento);
                    }

                }

            }

            if (Texto.ToString().Trim().Length > 0)
            {
                MessageBox.Show("No se encontraron los siguientes procedimientos: " + Texto.ToString());
                return false;
            }


            //------------------------------------------------------------------------------------

            //-------------------------------------------------------------------------------------

            return true;
        }

        private void MDIPadre_Load(object sender, EventArgs e)
        {
            /*inicio de cambiar color de fondo en el formulario*/
            MdiClient ctlMDI;
            //ConfigurationManager.AppSettings["cadenaconexion"] = "demo2";
            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }

                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                   Console.WriteLine(exc.Message);
                }
            }
            /*fin de cambiar color de fondo en el formulario*/
            //if (verificarProcedimientos_V2() == false)
            //{
            //    return;
            //}
            //28112014
            frmLoginNew Login = new frmLoginNew();
            //frmLogin Login = new frmLogin();
            DialogResult resultado;

            lblEmpresa.Text = "";
            lblSucursal.Text = "";
            lblPeriodo.Text = "";
            
            do
            {
                resultado = Login.ShowDialog(this);

            } while (resultado != DialogResult.OK && resultado != DialogResult.Abort);

            if (resultado == DialogResult.OK)
            {
                this.menuStrip.Visible = true;
                lblEmpresa.Text = cDatos.Establecimiento;
                lblSucursal.Text = cDatos.Hotel;
                lblPeriodo.Text = Convert.ToString(cDatos.Periodo);

                //version de la aplicacion
                this.Text = this.Text + " " + Application.ProductVersion;
                //verificar si se habilita totalmente el módulo;
                BL.BLHotel moduloContabilidad = new BL.BLHotel();
                if (moduloContabilidad.estaHabilitado() == true)
                {
                    //el modulo está habilitado
                    btnAsientos.Visible = true;
                    btnCuentas.Visible = true;
                    btnLibros.Visible = true;
                    btnTransferencias.Visible = true;
                    btnProcesos.Visible = true;
                }
                else
                {
                    //el modulo está deshabilitado
                    btnAsientos.Visible = false;
                    btnCuentas.Visible = false;
                    btnLibros.Visible = false;
                    btnTransferencias.Visible = false;
                    btnProcesos.Visible = false;
                }

            }
            else
            {
                this.Close();
            }
        }

        private void asientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucher _frmVoucher = new frmVoucher(cDatos.EstablecimientoID, cDatos.Establecimiento, cDatos.HotelID, cDatos.Hotel, cDatos.Periodo);
            _frmVoucher.MdiParent = this;
            _frmVoucher.Show();

        }

        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferencias fTransferencias = new frmTransferencias(cDatos.Periodo);

            fTransferencias.ShowDialog();
        }

        private void registrarAsientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroAsientos fRAsientos = new frmRegistroAsientos(0,"0",true);

            fRAsientos.ShowDialog();
        }

        private void asientosAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsientos frmAsientos = new frmAsientos(true);

            frmAsientos.ShowDialog();
        }

        private void btnAsientos_Click(object sender, EventArgs e)
        {
            frmVoucher _frmVoucher = new frmVoucher(cDatos.EstablecimientoID, cDatos.Establecimiento, cDatos.HotelID, cDatos.Hotel, cDatos.Periodo);
            _frmVoucher.MdiParent = this.MdiParent;
            _frmVoucher.Show();
        }

        private void btnTransferencias_Click(object sender, EventArgs e)
        {
            frmTransferencias fTransferencias = new frmTransferencias(cDatos.Periodo);

            fTransferencias.StartPosition = FormStartPosition.CenterParent;

            fTransferencias.ShowDialog();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {

            frmAsientosList _frmAsientosList = new frmAsientosList(cDatos.EstablecimientoID, cDatos.Establecimiento, cDatos.HotelID, cDatos.Hotel, cDatos.Periodo);
            _frmAsientosList.MdiParent = this.MdiParent;
            //_frmAsientosList.Height = this.Height;
            //_frmAsientosList.Width = (Int32)(this.Width * 0.90);
            _frmAsientosList.ShowDialog(this);
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            //frmLibros _frmLibroDiario = new frmLibros(cDatos.EstablecimientoID, cDatos.Establecimiento, cDatos.HotelID, cDatos.Hotel, cDatos.Periodo);
            frmLibros _frmLibroDiario = new frmLibros(cDatos.EstablecimientoID, cDatos.Establecimiento, cDatos.EstablecimientoID, cDatos.Hotel, cDatos.Periodo);
            _frmLibroDiario.MdiParent = this.MdiParent;
            //_frmLibroDiario.Height = this.Height;
            //_frmLibroDiario.Width = (Int32)(this.Width * 0.90);
            _frmLibroDiario.Show();
        }

        private void btnVouchers_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcesos_Click(object sender, EventArgs e)
        {
            frmProcesos _frmProcesos = new frmProcesos();
            _frmProcesos.MdiParent = this.MdiParent;
            
            _frmProcesos.ShowDialog();
        }

        private void btnImportarExportar_Click(object sender, EventArgs e)
        {
            frmImportarExportar _frmProcesos = new frmImportarExportar();
            _frmProcesos.MdiParent = this.MdiParent;

            _frmProcesos.ShowDialog();
        }

        private void btnInterfaces_Click(object sender, EventArgs e)
        {
            frmInterfacesSunat _frmProcesos = new frmInterfacesSunat();

            _frmProcesos.MdiParent = this.MdiParent;

            _frmProcesos.ShowDialog();
        }
    }
} 
