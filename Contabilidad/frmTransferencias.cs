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
using Eventos;

namespace Contabilidad
{
    public partial class frmTransferencias : Form
    {

        private Int32 tipoTransferencia;
        private Int32 PeriodoiID;

        private bool Bandera;

        int Mes;
        int Anio;

        //cEventos regEventos;

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

        public frmTransferencias(int _PeriodoID)
        {
            InitializeComponent();
            PeriodoiID = _PeriodoID;
            Bandera = false;
            //regEventos = new cEventos();
        }

        private void ColorearListView()
        {
            for (int index = 0; index <= lvwTransferencias.Items.Count - 1; index++)
            {


                if (index % 2 == 0)
                {
                    // lvwTransferencias.Items[index].BackColor = Color.LightBlue;
                }
                else
                {
                    // lvwTransferencias.Items[index].BackColor = Color.Beige;
                }
            }


        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            //transferencia 

            this.ControlBox = false;

            //cargar la lista de las transferencias
            this.lvwTransferencias.FullRowSelect = true;
            this.lvwTransferencias.GridLines = true;
            ColumnHeader columna = this.lvwTransferencias.Columns.Add("Transferencias");
            columna.Width = 230;
            this.lvwTransferencias.Items.Add("1", "Transferencia de Ventas", 0);
            this.lvwTransferencias.Items.Add("2", "Transferencia de Cobranzas", 0);
            this.lvwTransferencias.Items.Add("3", "Transferencia de Compras", 0);
            this.lvwTransferencias.Items.Add("4", "Transferencia de Salidas de Almacén", 0);
            //this.lvwTransferencias.Items.Add("5", "Transferencia de Planilla de Remuneraciones", 0);
            //this.lvwTransferencias.Items.Add("6", "Transferencia de Planilla de Practicantes", 0);
            //this.lvwTransferencias.Items.Add("7", "Transferencia de Provisión de Gratificaciones", 0);
            //this.lvwTransferencias.Items.Add("8", "Transferencia de Provisión de Vacaciones", 0);
            //this.lvwTransferencias.Items.Add("9", "Transferencia de Provisión de CTS", 0);
            //this.lvwTransferencias.Items.Add("10", "Transferencia de Planilla de Gratificaciones", 0);
            this.lvwTransferencias.Items.Add("11", "Tesorería", 0);
            this.lvwTransferencias.Items.Add("12", "Devengue de gastos", 0);
            this.lvwTransferencias.Items.Add("13", "Devengue de ventas", 0);
            //seleccionar el primer item de la lista
            this.lvwTransferencias.Focus();
            this.lvwTransferencias.Items[0].Selected = true;
            this.grpTransferencias.Visible = true;
            this.grpPlanillas.Visible = false;
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

            ColorearListView();

        }

        private String NombreMes(Int32 _mes)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(_mes).ToUpper();
        }

        private Boolean transfiere(Int32 tipo, DateTime desde, DateTime hasta)
        {

            try
            {
                //TRANSFERENCIAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                BLAsientos asientos = new BLAsientos();

                //aca se ejecuta
                DateTime inicio = desde;
                DateTime fecha = desde;

                Int32 i = 0;

                Int32 sizeRange = 5;




                switch (tipo)
                {
                    case 1:
                        //transferencia de ventas
                        //SE COMENTO EL 17/03/2014
                        //regEventos.registrar("Contabilidad", "Inicia transferencia de ventas desde " + desde.ToShortDateString() + " hasta " + hasta.ToShortDateString() + ". La Bandera está en " + Bandera.ToString() + ".", System.Diagnostics.EventLogEntryType.Information);
                        Bandera = asientos.transferenciaVentas(desde, hasta, cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 2:
                        //transferencia de cobranzas
                        Bandera = asientos.transferenciaCobranzas(desde, hasta, cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 3:
                        //transferencia de compras
                        Bandera = asientos.transferenciaCompras(desde, hasta, cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 4:
                        //transferencia de salidas de almacen
                        Bandera = asientos.transferenciaSalidas(desde, hasta, cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 5:
                        //transferencia de planillas de remuneraciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VC", cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 6:
                        //transferencia de planilla de practicante
                        Bandera = asientos.transferenciaPlanillas(fecha, "VP", cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 7:
                        //transferencia de provision de gratificaciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VPG", cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 8:
                        //transferencia de provision de vacaciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VPP", cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 9:
                        //transferencia de provision de cts
                        Bandera = asientos.transferenciaPlanillas(fecha, "VCP", cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 10:
                        //transferencia de planilla de gratificaciones
                        Bandera = asientos.transferenciaPlanillas(fecha, "VCG", cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 11:
                        //transferencia de tesoreria
                        Bandera = asientos.transferenciaTesoreria(desde, hasta,cDatos.UsuarioID);
                        break;
                    case 12:
                        //Devengue de gastos
                        Bandera = asientos.transferenciaDevegueGastos(Mes.ToString(), cDatos.Periodo.ToString(), cDatos.UsuarioID, "", "", "", "");
                        break;
                    case 13:
                        //Devengues Ventas
                        Bandera = asientos.transferenciaDevegueVentas(desde, hasta, cDatos.UsuarioID, "", "", "", "");
                        break;
                }


                //Bandera = asientos.transferenciaVentas(desde, inicio, 0, "", "", "", "");
                // ** saul 15122014
                //if (Bandera == false)
                //{
                //    break;
                //}

                //if (sizeRange == 0)
                //{
                //    break;
                //}

                //desde = inicio.AddDays(1);

                //TimeSpan ts = hasta - inicio;

                //if (ts.Days >= sizeRange)
                //{
                //    inicio = inicio.AddDays(sizeRange);
                //}
                //else
                //    if (ts.Days != 0)
                //    {
                //        inicio = inicio.AddDays(ts.Days);
                //    }
                //    else
                //    {
                //        break;
                //    }

                //}
                // ** saul 15122014
                return Bandera;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Substring(0, 32700);
                //regEventos.registrar("Contabilidad", mensaje, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

        private void iniciar(int ide)
        {
            DateTime desde;
            DateTime hasta;
            //btnTransferir.Enabled = true;
            //string valormes = (cboMeses.SelectedIndex + 1).ToString();
            string valormes = (cboMonth.SelectedIndex + 1).ToString();
            string f = "01/" + valormes + "/" + PeriodoiID;
            DateTime f1 = Convert.ToDateTime(f);
            DateTime f2;
            if (f1.Month + 1 < 13)
            { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
            else
            { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }


            pgBar.Visible = true;
            lblMensajeTransfiriendo.Visible = true;

            BLAsientos asientos = new BLAsientos();
            if (ide == 1)
            {
                desde = f1;

                hasta = f2;
            }
            else
            {
                desde = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());

                hasta = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());
            }


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
                lblMensajeTransfiriendo.Visible = false;
                return;
            }

            pgBar.Visible = false;

            lblMensajeTransfiriendo.Visible = false;

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //pgBar.Visible = true;
            //pgBar.Invoke(new pgVisible(pgBar.Visible));
            this.Invoke(new pgVisibleDelegate(pgVisible), true);


            DateTime desde = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());

            DateTime hasta = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());

            DateTime fecha = new DateTime(Anio, Mes, DateTime.DaysInMonth(Anio, Mes));
            if (tipoTransferencia == 12 || tipoTransferencia == 13)
            {
                //  sstring valor = (cboMonth.SelectedIndex).ToString();
                string f = "01/" + Mes + "/" + PeriodoiID;
                DateTime f1 = Convert.ToDateTime(f);
                DateTime f2;
                if (f1.Month + 1 < 13)
                { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
                else
                { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }

                desde = f1; hasta = f2;
            }


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
                MessageBox.Show("La transferencia se realizó con éxito.");
            }
            else
            {
                MessageBox.Show("La transferencia no se realizó.");
            }
            this.Invoke(new pgVisibleDelegate(pgVisible), false);
        }


        private void btnTransferenciaVentas_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 1;
            iniciar(0);
        }

        private void btnTransferenciaCobranzas_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 2;
            iniciar(0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnTransferenciaCompras_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 3;
            iniciar(0);
        }

        private void btnTransferenciasSalidas_Click(object sender, EventArgs e)
        {
            tipoTransferencia = 4;
            iniciar(0);
        }

        private void btnTransferir_Click_1(object sender, EventArgs e)
        {
            BLcontrolPeriodo BL_ComtrolPeriodo = new BLcontrolPeriodo();
            int id;
            DataTable dt = new DataTable();

            //ver el indice
            if (this.lvwTransferencias.SelectedItems.Count != 1)
            {
                MessageBox.Show("Debe seleccionar la transferencia a realizar.");
                return;
            }

            ListViewItem ItmX = this.lvwTransferencias.SelectedItems[0];
            tipoTransferencia = Convert.ToInt32(ItmX.Name);
            switch (tipoTransferencia)
            {
                case 3: id = 1; break;
                case 1: id = 2; break;
                case 11: id = 3; break;
                case 2: id = 4; break;
                case 13: id = 5; break;
                case 12: id = 6; break;
                case 4: id = 7; break;
                default: id = 0; break;
            }
            //MessageBox.Show(tipoTransferencia.ToString());
            Mes = cboMonth.SelectedIndex + 1;
            Anio = cboYear.SelectedIndex + 2000;
            string a1 = (dtpDesde.Value.Year.ToString());

            string a2 = (dtpHasta.Value.Year.ToString());
            if (tipoTransferencia == 12 | tipoTransferencia == 13)
            {
                string valormes = (cboMonth.SelectedIndex + 1).ToString();
                string f = "01/" + valormes + "/" + PeriodoiID;
                DateTime f1 = Convert.ToDateTime(f);
                DateTime f2;
                if (f1.Month + 1 < 13)
                { f2 = new DateTime(f1.Year, f1.Month + 1, 1).AddDays(-1); }
                else
                { f2 = new DateTime(f1.Year + 1, 1, 1).AddDays(-1); }
                dt = BL_ComtrolPeriodo.ValidacionTransferencia(id, f1, f2);
                if (dt.Rows.Count == 0)
                { iniciar(1); }
                else
                {
                    TransferInforme _trans = new TransferInforme(dt);
                    _trans.MdiParent = this.MdiParent;
                    _trans.Show();
                }

                //}
                //else
                //{
                //    MessageBox.Show("Periodo Ingresado es Incorrecto!");
                //}
            }
            else
            {
                if (cDatos.Periodo.ToString() == a1 && cDatos.Periodo.ToString() == a2)
                {
                    DateTime desd = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());

                    DateTime hast = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());

                    dt = BL_ComtrolPeriodo.ValidacionTransferencia(id, desd, hast);
                    if (dt.Rows.Count == 0)
                    { iniciar(0); }
                    else
                    {
                        TransferInforme _trans = new TransferInforme(dt);
                        _trans.MdiParent = this.MdiParent;
                        _trans.Show();
                    }
                }
                else
                {
                    MessageBox.Show("El rango de fechas no se encuentra en el periodo correcto!");
                }
            }
        }

        private void lvwTransferencias_Click(object sender, EventArgs e)
        {
            ListViewItem ItmX = this.lvwTransferencias.SelectedItems[0];
            tipoTransferencia = Convert.ToInt32(ItmX.Name);
            switch (tipoTransferencia)
            {
                case 1:
                case 2:
                case 3:
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
                case 12:
                case 13:
                    grpTransferencias.Visible = false;
                    grpPlanillas.Visible = true;
                    break;
            }
        }



    }
}
