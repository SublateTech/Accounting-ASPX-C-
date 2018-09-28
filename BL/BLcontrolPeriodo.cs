using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AD;
namespace BL
{
    public class BLcontrolPeriodo
    {
        private ADcontrolPeriodo objADcontrolPeriodo;
        public BLcontrolPeriodo()
        {
            objADcontrolPeriodo = new ADcontrolPeriodo();
        }

        public DataTable UCO_selectControlPeriodo(Int32 PeriodoIDV)
        {
            return objADcontrolPeriodo.UCO_selectControlPeriodo(PeriodoIDV);
        }
        public DataTable ValidacionTransferencia(Int32 id, DateTime desde, DateTime hasta)
        {
            return objADcontrolPeriodo.ValidacionTransferencia(id, desde, hasta);
        }


    }
}
