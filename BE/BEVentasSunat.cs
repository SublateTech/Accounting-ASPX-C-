using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BEVentasSunat
    {
        public BEVentasSunat()
        {
        }
        public Int32 monedaIDEmision { get; set; }
        public Int32 monedaId { get; set; }
        public String moneda { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public String empresa { get; set; }
        public Int32 establecimientoID { get; set; }
        public Int32 produccion { get; set; }
        public Int32 prepagos { get; set; }

    }
}
