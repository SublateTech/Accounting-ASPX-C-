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
using System.Data.SqlClient;
using System.Configuration;
using AD;

namespace Contabilidad
{
    public partial class frmProcesos : Form
    {

        private Int32 tipoTransferencia;

        private bool Bandera;

        int Mes;
        int Anio;

        DataSet datos;

        delegate void pgVisibleDelegate(bool value);

        public void pgVisible(bool value)
        {

            pgBar.Visible = value;

            if (value == true)
            {
                btnTransferir.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                btnTransferir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        public frmProcesos()
        {
            InitializeComponent();
            Bandera = false;
        }

        private void frmProcesos_Load(object sender, EventArgs e)
        {
            //transferencia 

            this.ControlBox = false;

            //cargar la lista de las transferencias
            this.lvwTransferencias.FullRowSelect = true;
            this.lvwTransferencias.GridLines = true;
            ColumnHeader columna = this.lvwTransferencias.Columns.Add("Procesos");
            columna.Width = 230;
            this.lvwTransferencias.Items.Add("1", "Cálculo de Diferencia de Cambio", 0);
            this.lvwTransferencias.Items.Add("2", "Inconsistencias", 0);
            this.lvwTransferencias.Items.Add("3", "Cierre de Periodo", 0);
            //seleccionar el primer item de la lista
            this.lvwTransferencias.Focus();
            this.lvwTransferencias.Items[0].Selected = true;
            this.grpDiferenciaCambio.Visible = true;
            this.grpTransferencias.Visible = false;
            this.grpPlanillas.Visible = false;
            fechaFinLB.Visible = false;
            tipoCompraLB.Visible = false;
            tipoVentaLB.Visible = false;
            tituloCompraLB.Visible = false;
            tituloVentaLB.Visible = false;
            //cargar los meses
            cboMonth.Items.Clear();
            for (int iMes = 1; iMes <= 12; iMes++)
            {
                cboMonth.Items.Add(NombreMes(iMes));
            }
            cboYear.Items.Clear();
            for (int iYear = 2000; iYear <= 2050; iYear++)
            {
                cboYear.Items.Add(iYear.ToString());
            }
            //obtener mes actual y año actual
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;
            cboYear.SelectedIndex = DateTime.Now.Year - 2000;

        }

        private String NombreMes(Int32 _mes)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(_mes).ToUpper();
        }

        private Boolean transfiere(Int32 tipo, DateTime desde, DateTime hasta)
        {
            BLAsientos asientos = new BLAsientos();

            //aca se ejecuta
            DateTime inicio = desde;
            DateTime fecha = desde;


            Int32 i = 0;

            Int32 sizeRange = 5;

            //Boolean valor = false;

            //calibramos el rango
            if (sizeRange > (hasta - desde).Days)
            {
                sizeRange = (hasta - desde).Days;
            }

            inicio = inicio.AddDays(sizeRange);

            while (i == 0)
            {

                switch (tipo)
                {
                    case 1:
                        //cálculo de diferencia de cambio

                        //Bandera = asientos.transferenciaVentas(desde, inicio, 0, "", "", "", "");
                        DateTime fechaDC = dtpFechaDC.Value;
                        Bandera = asientos.procesosCalculoDiferenciaCambio(fechaDC, cDatos.EstablecimientoID.ToString(), cDatos.Periodo.ToString(), cDatos.HotelID.ToString());
                        break;
                    case 2:
                        //inconsistencias
                        Bandera = true;
                        datos = asientos.inconsistencias(cDatos.EstablecimientoID, cDatos.Periodo);
                        datos.DataSetName = "Incon";
                        datos.Tables[0].TableName = "inconsistencia";
                        break;
                    case 3:
                        //PROCESAR
                        Bandera = asientos.procesosUCO_CierrePeriodoProcede(cDatos.Periodo.ToString(), cDatos.EstablecimientoID.ToString());
                        break;
                    case 4:
                        //transferencia de salidas de almacen
                        Bandera = asientos.transferenciaSalidas(desde, inicio, 0, "", "", "", "");
                        break;
                    case 5:
                        //transferencia de planillas de remuneraciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VC", 0, "", "", "", "");
                        break;
                    case 6:
                        //transferencia de planilla de practicante
                        Bandera = asientos.transferenciaPlanillas(fecha, "VP", 0, "", "", "", "");
                        break;
                    case 7:
                        //transferencia de provision de gratificaciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VPG", 0, "", "", "", "");
                        break;
                    case 8:
                        //transferencia de provision de vacaciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VPP", 0, "", "", "", "");
                        break;
                    case 9:
                        //transferencia de provision de cts
                        Bandera = asientos.transferenciaPlanillas(fecha, "VCP", 0, "", "", "", "");
                        break;
                    case 10:
                        //transferencia de planilla de gratificaciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VCG", 0, "", "", "", "");
                        break;
                    case 11:
                        //transferencia de tesoreria
                        Bandera = asientos.transferenciaTesoreria(desde, inicio,cDatos.UsuarioID);
                        break;
                }


                //Bandera = asientos.transferenciaVentas(desde, inicio, 0, "", "", "", "");

                if (Bandera == false)
                {
                    break;
                }

                if (sizeRange == 0)
                {
                    break;
                }

                desde = inicio.AddDays(1);

                TimeSpan ts = hasta - inicio;

                if (ts.Days >= sizeRange)
                {
                    inicio = inicio.AddDays(sizeRange);
                }
                else
                    if (ts.Days != 0)
                    {
                        inicio = inicio.AddDays(ts.Days);
                    }
                    else
                    {
                        break;
                    }

            }

            return Bandera;

        }

        private void iniciar()
        {

            //btnTransferir.Enabled = true;

            pgBar.Visible = true;

            BLAsientos asientos = new BLAsientos();

            DateTime desde = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());

            DateTime hasta = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());

            TimeSpan diferencia = hasta - desde;

            if (diferencia.TotalDays >= 0)
            {
                //aca se ejecuta

                if (bgWorker.IsBusy != true)
                {
                    bgWorker.RunWorkerAsync();
                }

                //transfiereVentas(desde, hasta);

            }

            else
            {
                MessageBox.Show("El rango de fechas no es correcto.");
                pgBar.Visible = false;
                return;
            }
            pgBar.Visible = false;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //pgBar.Visible = true;
            //pgBar.Invoke(new pgVisible(pgBar.Visible));
            this.Invoke(new pgVisibleDelegate(pgVisible), true);
            DateTime desde = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());

            DateTime hasta = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());


            DateTime fecha = new DateTime(Anio, Mes, DateTime.DaysInMonth(Anio, Mes));

            //aca le paso las fechas
            //desde y hasta es la misma para las transferencias de planillas
            switch (tipoTransferencia)
            {
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    desde = fecha;
                    hasta = fecha;
                    break;
            }

            transfiere(tipoTransferencia, desde, hasta);

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Bandera == true)
            {
                if (tipoTransferencia == 2)
                {
                    //pantalla de inconsistencias
                    frmInconsistencias forma = new frmInconsistencias(datos);
                    forma.Show();

                }
                MessageBox.Show("El proceso se realizó con éxito.");
            }
            else
            {
                MessageBox.Show("El proceso no se realizó.");
            }
            this.Invoke(new pgVisibleDelegate(pgVisible), false);
        }


        private void btnTransferenciaVentas_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 1;
            iniciar();
        }

        private void btnTransferenciaCobranzas_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 2;
            iniciar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnTransferenciaCompras_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 3;
            iniciar();
        }

        private void btnTransferenciasSalidas_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 4;
            iniciar();
        }

        private void btnTransferir_Click_1(object sender, EventArgs e)
        {
            //ver el indice

            if (this.lvwTransferencias.SelectedItems.Count != 1)
            {
                MessageBox.Show("Debe seleccionar el proceso a realizar.");
                return;
            }

            //if (this.tipoCompraLB.Text == "0.00")
            //{
            //    MessageBox.Show("No existe Tipo de Cambio para la Fecha Seleccionada.");
            //    return;
            //}

            ListViewItem ItmX = this.lvwTransferencias.SelectedItems[0];
            tipoTransferencia = Convert.ToInt32(ItmX.Name);
            //MessageBox.Show(tipoTransferencia.ToString());
            Mes = cboMonth.SelectedIndex + 1;
            Anio = cboYear.SelectedIndex + 2000;
            string yea = dtpFechaDC.Value.Year.ToString();



            if (yea == cDatos.Periodo.ToString())
            {
                iniciar();
            }
            else
            {
                MessageBox.Show("La Fecha no se encuentra en el Periodo Ingresado");
            }

        }

        private void lvwTransferencias_Click(object sender, EventArgs e)
        {
            ListViewItem ItmX = this.lvwTransferencias.SelectedItems[0];
            tipoTransferencia = Convert.ToInt32(ItmX.Name);
            switch (tipoTransferencia)
            {
                case 1:
                    grpDiferenciaCambio.Visible = true;
                    grpDiferenciaCambio.Text = "Diferencia de Cambio";
                    dtpFechaDC.Value = DateTime.Today;
                    grpTransferencias.Visible = false;
                    dtpFechaDC.Visible = true;
                    grpPlanillas.Visible = false;
                    fechaFinLB.Visible = false;
                    tipoCompraLB.Visible = false;
                    tipoVentaLB.Visible = false;
                    tituloCompraLB.Visible = false;
                    tituloVentaLB.Visible = false;
                    break;
                case 2:
                    grpDiferenciaCambio.Visible = false;
                    grpTransferencias.Visible = false;
                    grpPlanillas.Visible = false;
                    break;
                case 3:
                    grpDiferenciaCambio.Visible = true;
                    dtpFechaDC.Visible = false;
                    grpDiferenciaCambio.Text = "Hasta la Fecha";
                    dtpFechaDC.Visible = false;
                    tituloCompraLB.Visible = true;
                    tituloVentaLB.Visible = true;
                    fechaFinLB.Text = "31/12/" + cDatos.Periodo.ToString();
                    fechaFinLB.Visible = true;
                    tipoCompraLB.Visible = true;
                    tipoVentaLB.Visible = true;
                    SqlConnection sqlconn = new SqlConnection(Connection.connectionString());
                    sqlconn.Open();
                    SqlCommand command_resultado_busqueda = new SqlCommand("SELECT CompraSunat, VentaSunat FROM tiposcambio WHERE (CONVERT(VARCHAR(10), FechacambioId, 103) ='" + "31/12/" + cDatos.Periodo.ToString() + "')", sqlconn);
                    //string varF = "SELECT CompraSunat, VentaSunat FROM tiposcambio WHERE (CONVERT(VARCHAR(10), FechacambioId, 103) ='" + "31/12/" + cDatos.Periodo.ToString() + "')";
                    //    MessageBox.Show(varF);
                    SqlDataReader dataReader_resultado_busqueda = command_resultado_busqueda.ExecuteReader();
                    while ((dataReader_resultado_busqueda.Read()))
                    {
                        tipoCompraLB.Text = dataReader_resultado_busqueda.GetValue(0).ToString();
                        tipoVentaLB.Text = dataReader_resultado_busqueda.GetValue(1).ToString();
                    }
                    grpTransferencias.Visible = false;
                    grpPlanillas.Visible = false;
                    break;
                case 4:
                case 11:
                    grpTransferencias.Visible = true;
                    grpPlanillas.Visible = false;
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    grpTransferencias.Visible = false;
                    grpPlanillas.Visible = true;
                    break;
            }
        }

    }
}
