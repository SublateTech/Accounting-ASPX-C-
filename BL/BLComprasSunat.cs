using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using AD;
using System.Data;

namespace BL
{
    public  class BLComprasSunat
    {
        private ADCompasSunat objADVentasSunat;
        public BLComprasSunat() 
        {
            objADVentasSunat = new ADCompasSunat();
        }

        public DataTable getValidacompras(Int32 Desde, Int32 Empresa, Int32 Hasta, Int32 MonedaId)
        {
            return objADVentasSunat.getValidacompras(Desde, Empresa, Hasta, MonedaId);
        }
    }
}
