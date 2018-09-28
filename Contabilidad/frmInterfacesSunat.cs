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
using exportaPLE;
using System.Configuration;
using ExportLAP;
using exportaContaSis;
using AD;
using System.Data.SqlClient;
namespace Contabilidad
{
    public partial class frmInterfacesSunat : Form
    {
        //public string nombreReporte;
        BLMoneda objMonedas;
        BLEstablecimiento objEstablecimento;
        Int32 reporteID = 0;
        private String RucEmpresa;
        DataTable DTPLE= new DataTable();
        int IndicadorPLE;
        Boolean moduloHabilitado = false;

        exportaContaSis.exportaVentasContaSis objExpContaSis;
        //tabInterfacesSunat

        public frmInterfacesSunat()
        {

            InitializeComponent();

        }

        private void frmInterfacesSunat_Load(object sender, EventArgs e)
        {
            lvwReportes.Items.Clear();
            lvwReportes.Items.Add("Registro de Ventas Sunat");
            lvwReportes.Items.Add("Registro de Compras Sunat");
            lvwReportes.Items.Add("Registro Libros Diarios Sunat");
            lvwReportes.Items.Add("Registro Libro Mayor Sunat");

            radioButton1.Checked = true;

            SqlConnection sqlconn = new SqlConnection(Connection.connectionString());
            sqlconn.Open();
            SqlCommand command_resultado_busqueda = new SqlCommand(" EXEC SWP_ParametroReporte ", sqlconn);
            SqlDataReader dataReader_resultado_busqueda = command_resultado_busqueda.ExecuteReader();
            while ((dataReader_resultado_busqueda.Read()))
            {
                RucEmpresa = dataReader_resultado_busqueda.GetValue(1).ToString().Trim();
                //direccParam = dataReader_resultado_busqueda.GetValue(2).ToString();
            }


            objExpContaSis = new exportaVentasContaSis();

            BL.BLHotel moduloContabilidad = new BL.BLHotel();

            if (moduloContabilidad.estaHabilitado() == true)
            {
                moduloHabilitado = true;
                lblYearComprasSunat.Visible = false;
                txtYearComprasSunat.Visible = false;
                lblYearVentasSunat.Visible = false;
                txtYearVentasSunat.Visible = false;
            }
            else
            {
                moduloHabilitado = false;
                lblYearComprasSunat.Visible = true;
                txtYearComprasSunat.Visible = true;
                lblYearVentasSunat.Visible = true;
                txtYearVentasSunat.Visible = true;
            }


            objMonedas = new BLMoneda();
            objEstablecimento = new BLEstablecimiento();
            cargaMeses();
            cargaMesesCompras();
            cargaMesesLibroDiario();
            cargaMesesLibroMayor();
            cargaMesesLibroInventarioPermanente();
            cargaMonedas();
            cargaEstablecimientos();
            cargaMonedasCompras();

            cargaMonedasEmision();

            /*cargar valores predeterminados o ya utilizados en la
             ruta de las carpetas donde se generan los archivos*/
            lblRuta.Text = ConfigurationManager.AppSettings["Ruta_Interfaz_SunatVentas"];
            lblRutaCompras.Text = ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"];
            lblRutaLAPVentas.Text = ConfigurationManager.AppSettings["Ruta_Interfaz_LapVentas"];
            lblContaSisVentaRuta.Text = ConfigurationManager.AppSettings["Ruta_Interfaz_ContaSisVentas"];
            rutaLB_libroDiario.Text = ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"];
            //rutaMayorLB.Text = ConfigurationManager.AppSettings["Ruta_Interfaz_SunatLibroMayor"];
        }

        private string[] GetMonths(string culture)
        {
            DateTimeFormatInfo ci = new CultureInfo(culture).DateTimeFormat;
            return ci.MonthNames;
        }

        private void cargaMeses()
        {
            string[] meses = GetMonths("es-PE");
            String[] meses2 = new String[12];
            for (int x = 0; x <= meses.Length - 1; x++)
            {
                if (meses[x] != "")
                {
                    //poner en mayusculas
                    meses2[x] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(meses[x]);
                }
            }
            this.cboMesVentas.DataSource = meses2;
            this.mes_reporte.DataSource = meses2;
        }

        private void cargaMesesCompras()
        {
            string[] meses = GetMonths("es-PE");
            String[] meses2 = new String[12];
            for (int x = 0; x <= meses.Length - 1; x++)
            {
                if (meses[x] != "")
                {
                    //poner en mayusculas
                    meses2[x] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(meses[x]);
                }
            }
            this.cboMesCompras.DataSource = meses2;
        }

        private void cargaMesesLibroDiario()
        {
            string[] meses = GetMonths("es-PE");
            String[] meses2 = new String[12];
            for (int x = 0; x <= meses.Length - 1; x++)
            {
                if (meses[x] != "")
                {
                    meses2[x] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(meses[x]);
                }
            }
            this.mesCB_LD.DataSource = meses2;
        }

        private void cargaMesesLibroMayor()
        {
            string[] meses = GetMonths("es-PE");
            String[] meses2 = new String[12];
            for (int x = 0; x <= meses.Length - 1; x++)
            {
                if (meses[x] != "")
                {
                    meses2[x] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(meses[x]);
                }
            }
            this.mesMayorCB.DataSource = meses2;
        }

        private void cargaMesesLibroInventarioPermanente()
        {
            string[] meses = GetMonths("es-PE");
            String[] meses2 = new String[12];
            for (int x = 0; x <= meses.Length - 1; x++)
            {
                if (meses[x] != "")
                {
                    meses2[x] = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(meses[x]);
                }
            }
            this.mesLIP_CB.DataSource = meses2;
        }

        private void cargaMonedas()
        {
            DataTable tabla = new DataTable();
            //moneda
            tabla = objMonedas.getMoneda();
            //DataRow fila = tabla.NewRow();
            //fila["monedaid"] = 0;
            //tabla.Rows.Add(fila);
            DataView datos = new DataView(tabla, "", "monedaid ASC", DataViewRowState.CurrentRows);
            this.cboMonedaVentas.DataSource = datos;
            this.cboMonedaVentas.DisplayMember = "Nombre";
            this.cboMonedaVentas.ValueMember = "monedaid";
            this.cboMonedaVentas.SelectedValue = 1;
        }

        private void cargaEstablecimientos()
        {
            DataTable tabla1 = new DataTable();
            tabla1 = objEstablecimento.getEstablecimientosAll();
            //DataRow fila = tabla1.NewRow();
            //fila["EstablecimientoId"] = 0;
           // tabla1.Rows.Add(fila);
            DataView datos = new DataView(tabla1, "", "NombreEstablecimiento ASC", DataViewRowState.CurrentRows);
            this.establecimientoCB.DataSource = datos;
            this.establecimientoCB.DisplayMember = "NombreEstablecimiento";
            this.establecimientoCB.ValueMember = "EstablecimientoId";
            this.establecimientoCB.SelectedValue = 1;
        }

        private void cargaMonedasCompras()
        {
            DataTable tabla = new DataTable();
            //moneda
            tabla = objMonedas.getMoneda();
           // DataRow fila = tabla.NewRow();
           // fila["monedaid"] = 0;
           // tabla.Rows.Add(fila);
            DataView datos = new DataView(tabla, "", "monedaid ASC", DataViewRowState.CurrentRows);
            this.cboMonedaCompras.DataSource = datos;
            this.cboMonedaCompras.DisplayMember = "Nombre";
            this.cboMonedaCompras.ValueMember = "monedaid";

            this.cboMonedaCompras.SelectedValue = 1;
        }

        private void cargaMonedasEmision()
        {
            DataTable tabla = new DataTable();
            //moneda
            tabla = objMonedas.getMoneda();
            //DataRow fila = tabla.NewRow();
            //fila["monedaid"] = 0;
            //tabla.Rows.Add(fila);
            DataView datos = new DataView(tabla, "", "monedaid ASC", DataViewRowState.CurrentRows);
            this.cboMonedaEmisionVentas.DataSource = datos;
            this.cboMonedaEmisionVentas.DisplayMember = "Nombre";
            this.cboMonedaEmisionVentas.ValueMember = "monedaid";
            this.cboMonedaEmisionVentas.SelectedValue = 1;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    lblRuta.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {   //generar ple ventas
            IndicadorPLE=1;
           // DataTable dtple = new DataTable();

            exportaRegistroVentas objExp = new exportaRegistroVentas();
            
            int mesNumero = cboMesVentas.SelectedIndex + 1;
            int numYear = 0;
            if (moduloHabilitado == true)
            { numYear = cDatos.Periodo; }
            else  { numYear = Convert.ToInt32(txtYearVentasSunat.Text);  }
            DateTime desde = new DateTime(numYear, mesNumero, 1);
            DateTime hasta = new DateTime(numYear, mesNumero, DateTime.DaysInMonth(numYear, mesNumero));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());
            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = lblRuta.Text + "\\";
            string cadenaConexion = Connection.connectionString();

            int establecimiendoIDv = cDatos.EstablecimientoID; //Convert.ToInt32(establecimientoCB.SelectedValue.ToString());
            //validar PLE [UCO_ValidaTransferenciasContables]

           DTPLE= ValidarPLE(IndicadorPLE, desde, hasta); //valida ple 
            
            if(DTPLE.Rows.Count > 0 )
            {
                TransferInforme _trans = new TransferInforme(DTPLE);
                _trans.MdiParent = this.MdiParent;
                _trans.Show();
            }else
            {
                if (objExp.exporta(cadenaConexion, RucEmpresa, fecha, 1, desde_numero, hasta_numero, establecimiendoIDv, 0, 0, 1, ruta) == true)
                {
                    MessageBox.Show("Se generó el libro de ventas sin errores.");
                    /*
                     * guardar el valor utilizado ruta de la carpeta 
                     * donde se generan los archivos
                     */
                    ConfigurationManager.AppSettings["Ruta_Interfaz_SunatVentas"] = lblRuta.Text;
                }
                else
                {
                    MessageBox.Show("Error al generar el libro de ventas.");
                }
            }
                
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarCompras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarCompras_Click(object sender, EventArgs e)
        {

            int format = 0;
            if (radioButton1.Checked) { format = 0; IndicadorPLE = 9; } else if (radioButton2.Checked) { format = 1; IndicadorPLE = 10; }
            exportaRegistroCompras objExp = new exportaRegistroCompras();
            //generar ple compras
            int mesNumero = cboMesCompras.SelectedIndex + 1;

            int numYear = 0;

            if (moduloHabilitado == true)
            {
                numYear = cDatos.Periodo;
            }
            else
            {
                numYear = Convert.ToInt32(txtYearComprasSunat.Text);
            }
            DateTime desde = new DateTime(numYear, mesNumero, 1);
            DateTime hasta = new DateTime(numYear, mesNumero, DateTime.DaysInMonth(numYear, mesNumero));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());

            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = lblRutaCompras.Text + "\\";
            string cadenaConexion = Connection.connectionString();      
            int EstablecimientoID = cDatos.EstablecimientoID;
            DTPLE = ValidarPLE(IndicadorPLE, desde, hasta); //valida ple 

            if (DTPLE.Rows.Count > 0)
            {
                TransferInforme _trans = new TransferInforme(DTPLE);
                _trans.MdiParent = this.MdiParent;
                _trans.Show();
            }
            else
            {
                if (objExp.exporta(cadenaConexion, RucEmpresa, fecha, 1, desde_numero, hasta_numero, EstablecimientoID, ruta, format) == true)
                {
                    MessageBox.Show("Se generó el libro de compras sin errores.");
                    /*
                  * guardar el valor utilizado ruta de la carpeta 
                  * donde se generan los archivos
                  */
                    ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"] = lblRutaCompras.Text;
                }
                else
                {
                    MessageBox.Show("Error al generar el libro de compras.");
                }
            }
        }

        private void btnRutaCompras_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    lblRutaCompras.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelarLAPVentas_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarLAPVentas_Click(object sender, EventArgs e)
        {
            exportaVentasLAP objExp = new exportaVentasLAP();
            //generar el txt

            DateTime fechaDesde = dtpFechaLAPVentasDesde.Value;
            DateTime fechaHasta = dtpFechaLAPVentasHasta.Value;

            string ruta = lblRutaLAPVentas.Text + "\\";



            string cadenaConexion = Connection.connectionString();

            //string ruc = ConfigurationManager.AppSettings["rucEmpresa"].ToString();

            //obtener el codigo de concesionario
            BLHotel objHotel = new BLHotel();
            string codigoConcesionario = objHotel.codigoConcesionario().Trim();
            //exportar a un archivo de texto
            //objExp.exportar llamar al archivo exportaVentasLAP.cs
            if (objExp.exportar(cadenaConexion, RucEmpresa, fechaDesde, ruta, codigoConcesionario, fechaHasta) == true)
            {
                MessageBox.Show("Se generó el archivo de ventas para LAP sin errores.");
                /*
              * guardar el valor utilizado ruta de la carpeta 
              * donde se generan los archivos
              */
                ConfigurationManager.AppSettings["Ruta_Interfaz_LapVentas"] = lblRutaLAPVentas.Text;
            }
            else
            {
                MessageBox.Show("Error al generar el archivo de ventas para LAP.");
            }
        }

        private void btnRutaVentasLAP_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    lblRutaLAPVentas.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objExpContaSis.cancelarProceso(true);
            this.Close();
        }

        private void btnContaSisVentaRuta_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    lblContaSisVentaRuta.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mostrarFila(object sender, EventArgs e)
        {
            exportaContaSis.RowProcessedEventArgs argumentos = (exportaContaSis.RowProcessedEventArgs)e;
            if (pgbProceso.Maximum == 0)
            {
                pgbProceso.Maximum = argumentos.total;
            }

            pgbProceso.Value = argumentos.numero; //.ToString();



            Application.DoEvents();
        }

        private void btnContaSisVentaGenerar_Click(object sender, EventArgs e)
        {

            objExpContaSis.filaprocesada += mostrarFila;
            //generar el txt

            DateTime desde = dtpContaSisVentaDesde.Value;

            DateTime hasta = dtpContaSisVentaHasta.Value;

            string ruta = lblContaSisVentaRuta.Text + "\\";


            string cadenaConexion = Connection.connectionString();

            // string ruc = ConfigurationManager.AppSettings["rucEmpresa"].ToString();
            pgbProceso.Maximum = 0;
            pgbProceso.Visible = true;
            if (objExpContaSis.exportar(cadenaConexion, RucEmpresa, desde, hasta, ruta) == true)
            {
                MessageBox.Show("Se generó el libro de ventas sin errores.");
                /*
                 * guardar el valor utilizado ruta de la carpeta 
                 * donde se generan los archivos
                 */
                ConfigurationManager.AppSettings["Ruta_Interfaz_ContaSisVentas"] = lblContaSisVentaRuta.Text;
                pgbProceso.Maximum = 0;
                pgbProceso.Visible = false;
            }
            else
            {
                MessageBox.Show("Error al generar el libro de ventas.");
            }
        }

        private void B_rutaLibroDiario_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    rutaLB_libroDiario.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelaLibroDiario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generarLibroDiario_Click(object sender, EventArgs e)
        {
            exportaLibroDiario objExp1 = new exportaLibroDiario();
            IndicadorPLE = 11;
            //generar ple diaria
            int mesNumero = mesCB_LD.SelectedIndex + 1;
            int numYear = 0;
            if (moduloHabilitado == true)
            {
                numYear = cDatos.Periodo;
            }
            else
            {
                numYear = Convert.ToInt32(anioTB_LibroDiario.Text);
            }
            DateTime desde = new DateTime(numYear, mesNumero, 1);
            DateTime hasta = new DateTime(numYear, mesNumero, DateTime.DaysInMonth(numYear, mesNumero));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());
            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = rutaLB_libroDiario.Text + "\\";
            string cadenaConexion = Connection.connectionString();
            int EstablecimientoID = cDatos.EstablecimientoID;
             DTPLE = ValidarPLE(IndicadorPLE, desde, hasta); //valida ple 

             if (DTPLE.Rows.Count > 0)
             {
                 TransferInforme _trans = new TransferInforme(DTPLE);
                 _trans.MdiParent = this.MdiParent;
                 _trans.Show();
             }
             else
             {
                string resultado = objExp1.exporta(cadenaConexion, RucEmpresa, fecha,  1, desde_numero, hasta_numero, EstablecimientoID, ruta);
                 if (resultado == "")
                 {
                     MessageBox.Show("Se generó el Libro Diario sin errores.");
                     /*
                   * guardar el valor utilizado ruta de la carpeta 
                   * donde se generan los archivos
                   */
                     ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"] = rutaLB_libroDiario.Text;
                 }
                 else
                 {
                     MessageBox.Show("Error al generar el Libro Diario." + "\r" + "\r" + resultado );
                 }
             }
        }

        private void buscaRutaMayorB_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    rutaMayorLB.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelaMayorB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generaMayorB_Click(object sender, EventArgs e)
        {
            IndicadorPLE = 13;
            exportaLibroMayor objExp2 = new exportaLibroMayor();
            //generar ple mayor
            int mesNumero = mesMayorCB.SelectedIndex + 1;
            int numYear = 0;
            if (moduloHabilitado == true)
            {
                numYear = cDatos.Periodo;
            }
            else
            {
                numYear = Convert.ToInt32(anioMayorCB.Text);
            }
            DateTime desde = new DateTime(numYear, mesNumero, 1);
            DateTime hasta = new DateTime(numYear, mesNumero, DateTime.DaysInMonth(numYear, mesNumero));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());
            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = rutaMayorLB.Text + "\\";


            string cadenaConexion = Connection.connectionString();

            int EstablecimientoID = cDatos.EstablecimientoID;
             DTPLE = ValidarPLE(IndicadorPLE, desde, hasta); //valida ple 

             if (DTPLE.Rows.Count > 0)
             {
                 TransferInforme _trans = new TransferInforme(DTPLE);
                 _trans.MdiParent = this.MdiParent;
                 _trans.Show();
             }
             else
             {
                 if (objExp2.exporta(cadenaConexion, RucEmpresa, fecha, 1, desde_numero, hasta_numero, EstablecimientoID, ruta) == true)
                 {
                     MessageBox.Show("Se generó el Libro Diario sin errores.");
                     /*
                   * guardar el valor utilizado ruta de la carpeta 
                   * donde se generan los archivos
                   */
                     ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"] = rutaMayorLB.Text;
                 }
                 else
                 {
                     MessageBox.Show("Error al generar el Libro Diario.");
                 }
             }
        }
        /*Hasta aca*/
        /* - lIBRO DE INVENTARIO MAYOR PERMANENTE*/
        private void buscarutaLIP_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdCarpeta.ShowDialog() == DialogResult.OK)
                {
                    rutaLIP.Text = fbdCarpeta.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelaLIP_B_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*22/10/2013*/
        private void generarLIP_B_Click(object sender, EventArgs e)
        {
            //exportaRegistroCompras objExp = new exportaRegistroCompras();
            exportaLibroInventarioPermanente objExp2 = new exportaLibroInventarioPermanente();
            //generar el txt
            int mesNumero = mesLIP_CB.SelectedIndex + 1;
            int numYear = 0;
            if (moduloHabilitado == true)
            {
                numYear = cDatos.Periodo;
                //numYear = Convert.ToInt32(anioMayorCB.Text);
            }
            else
            {
                numYear = Convert.ToInt32(anioLIP_TB.Text);
            }
            DateTime desde = new DateTime(numYear, mesNumero, 1);
            DateTime hasta = new DateTime(numYear, mesNumero, DateTime.DaysInMonth(numYear, mesNumero));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());
            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = rutaLIP.Text + "\\";

            string cadenaConexion = Connection.connectionString();
            // string ruc = ConfigurationManager.AppSettings["rucEmpresa"].ToString();

            //exporta(string connectionString, string ruc, DateTime fecha, int monedaID, 
            //                    int desde, int hasta, int establecimientoID, string rutaDestino,
            //                    DateTime iniciomes, int almacenid, int articuloid, int opcionsaleccionada,
            //                    int familiaarticuloid, int subfamiliaid)
            //if (objExp2.exporta(cadenaConexion, ruc, fecha, 1, desde_numero, hasta_numero, 0, ruta, desde_numero, 1,1,1,1,1) == true)
            String desdeV = desde.ToString("yyyyMMdd");
            String hastaV = hasta.ToString("yyyyMMdd");

            if (objExp2.exporta(cadenaConexion, RucEmpresa, fecha, 1, desdeV, hastaV, 0, ruta, desdeV, 61, 0, 0, 0, 0) == true)
            {
                MessageBox.Show("Se generó el Libro Diario sin errores.");
                /*
              * guardar el valor utilizado ruta de la carpeta 
              * donde se generan los archivos
              */
                ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"] = rutaMayorLB.Text;
            }
            else
            {
                MessageBox.Show("Error al generar el Libro Diario.");
            }
        }




        //por ver

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            btnMostrar.Text = "Espere ...";
            btnMostrar.Enabled = false;
            //mostrar el reporte
            StringBuilder listaTipos = new StringBuilder();

            int mesNumeroR = mes_reporte.SelectedIndex + 1;
            int numYear = 0;
            if (moduloHabilitado == true)
            {
                numYear = cDatos.Periodo;
            }
            else
            {
                numYear = Convert.ToInt32(anio_reporte.Text);
            }
            DateTime desde = new DateTime(numYear, mesNumeroR, 1);
            DateTime hasta = new DateTime(numYear, mesNumeroR, DateTime.DaysInMonth(numYear, mesNumeroR));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());
            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = rutaLB_libroDiario.Text + "\\";

            string cadenaConexion = Connection.connectionString();

            frmReporte reporte;

            switch (reporteID)
            {
                case funcionesReporte.ReporteVentasSunat:

                    //construir la lista de tipo de socios                  
                    Class1.fechaDesde = Convert.ToString(desde_numero);
                    Class1.fechaHasta = Convert.ToString(hasta_numero);
                    reporte = new frmReporte(funcionesReporte.ReporteVentasSunat);
                    reporte.ShowDialog(this);
                    break;

                case funcionesReporte.ReporteComprasSunat:
                    Class1.fechaDesde = Convert.ToString(desde_numero);
                    Class1.fechaHasta = Convert.ToString(hasta_numero);
                    reporte = new frmReporte(funcionesReporte.ReporteComprasSunat);
                    reporte.ShowDialog(this);
                    break;

                case funcionesReporte.ReporteLibroDiarioSunat:
                    Class1.fechaDesde = Convert.ToString(desde_numero);
                    Class1.fechaHasta = Convert.ToString(hasta_numero);
                    reporte = new frmReporte(funcionesReporte.ReporteLibroDiarioSunat);
                    reporte.ShowDialog(this);
                    break;

                case funcionesReporte.ReporteLibroMayorSunat:
                    Class1.fechaDesde = Convert.ToString(desde_numero);
                    Class1.fechaHasta = Convert.ToString(hasta_numero);
                    reporte = new frmReporte(funcionesReporte.ReporteLibroMayorSunat);
                    reporte.ShowDialog(this);
                    break;

                //agregar siguiente reporte


            }
            btnMostrar.Enabled = true;
            btnMostrar.Text = "Mostrar";
        }

        private void lvwReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwReportes.SelectedItems.Count == 1)
            {
                switch (lvwReportes.SelectedItems[0].Text)
                {
                    case "Registro de Ventas Sunat":
                        reporteID = funcionesReporte.ReporteVentasSunat;
                        break;

                    case "Registro de Compras Sunat":
                        reporteID = funcionesReporte.ReporteComprasSunat;
                        break;

                    case "Registro Libros Diarios Sunat":
                        reporteID = funcionesReporte.ReporteLibroDiarioSunat; ;
                        break;

                    case "Registro Libro Mayor Sunat":
                        reporteID = funcionesReporte.ReporteLibroMayorSunat; ;
                        break;
                }
            }
        }

        private void generaLibroDiarioDetalle_Click(object sender, EventArgs e)
        {
            IndicadorPLE = 12;
            exportaLibroDiario2 objExp1 = new exportaLibroDiario2();
            //generar el txt
            int mesNumero = mesCB_LD.SelectedIndex + 1;
            int numYear = 0;
            if (moduloHabilitado == true)
            {
                numYear = cDatos.Periodo;
            }
            else
            {
                numYear = Convert.ToInt32(anioTB_LibroDiario.Text);
            }
            DateTime desde = new DateTime(numYear, mesNumero, 1);
            DateTime hasta = new DateTime(numYear, mesNumero, DateTime.DaysInMonth(numYear, mesNumero));
            DateTime fecha = desde;
            string mes = "00";
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            int desde_numero = 0;
            mes = "00" + desde.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            desde_numero = Convert.ToInt32(desde.Day.ToString() + mes + desde.Year.ToString());
            int hasta_numero = 0;
            mes = "00" + hasta.Month.ToString();
            mes = mes.Substring(mes.Length - 2, 2);
            hasta_numero = Convert.ToInt32(hasta.Day.ToString() + mes + hasta.Year.ToString());
            string ruta = rutaLB_libroDiario.Text + "\\";

            string cadenaConexion = Connection.connectionString();
            //string ruc = ConfigurationManager.AppSettings["rucEmpresa"].ToString();
            int EstablecimientoID = cDatos.EstablecimientoID;
             DTPLE = ValidarPLE(IndicadorPLE, desde, hasta); //valida ple 

             if (DTPLE.Rows.Count > 0)
             {
                 TransferInforme _trans = new TransferInforme(DTPLE);
                 _trans.MdiParent = this.MdiParent;
                 _trans.Show();
             }
             else
             {
                 if (objExp1.exporta(cadenaConexion, RucEmpresa, fecha, 1, desde_numero, hasta_numero, EstablecimientoID, ruta) == true)
                 {
                     MessageBox.Show("Se generó el Libro Diario Detalle sin errores.");
                     /*
                   * guardar el valor utilizado ruta de la carpeta 
                   * donde se generan los archivos
                   */
                     ConfigurationManager.AppSettings["Ruta_Interfaz_SunatCompras"] = rutaLB_libroDiario.Text;
                 }
                 else
                 {
                     MessageBox.Show("Error al generar el Libro Diario.");
                 }
             }
        }

        private void validarCompraB_Click(object sender, EventArgs e)
        {
            frmValidaCompraSunat _frmValidaCompraSuna = new frmValidaCompraSunat();
            _frmValidaCompraSuna.MdiParent = this.MdiParent;
            _frmValidaCompraSuna.ShowDialog();
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;

        }

       

        private DataTable  ValidarPLE(int Ind, DateTime Desde, DateTime Hasta )
        {
            DataTable dt = new DataTable();
            BLcontrolPeriodo BL_ControlPeriodo = new BLcontrolPeriodo();
           // Hasta= Convert.ToDateTime("30/05/2016");
            dt = BL_ControlPeriodo.ValidacionTransferencia(Ind, Desde, Hasta);     
            return dt;
        }




    }
}
