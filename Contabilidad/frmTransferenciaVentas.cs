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
  public partial class frmTransferenciaVentas : Form
  {

      private bool Bandera;

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

    public frmTransferenciaVentas()
    {
      InitializeComponent();
      Bandera = false;
    }

    private Boolean transfiereVentas(DateTime desde, DateTime hasta)
    {

        BLAsientos asientos = new BLAsientos();
        
        //aca se ejecuta
        DateTime inicio = desde;

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


            Bandera = asientos.transferenciaVentas(desde, inicio, 0, "", "", "", "");

            if (Bandera == false)
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

    private void frmTransferenciaVentas_Load(object sender, EventArgs e)
    {
        this.ControlBox = false;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {

    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnTransferir_Click(object sender, EventArgs e)
    {

        btnTransferir.Enabled = true;
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

        transfiereVentas(desde, hasta);

    }

    private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {

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


  }
}
