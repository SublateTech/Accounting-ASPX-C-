using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AD;

namespace BL
{
    public class BLreporte
    {
        private ADReporte objADReporte = new ADReporte();
        public DataTable datosConfigRep001(String codigoReporte)
        {
            return objADReporte.datosConfigRep001(codigoReporte);
        }

        public bool AsignaProductoIdColumna(String codigoReporte, Int32 Columna, Int32 ProductoId, String Etiqueta)
        {
            return objADReporte.AsignaProductoIdColumna(codigoReporte, Columna, ProductoId, Etiqueta);
        }

        public DataSet reporteFlujoIngresos(DateTime desde, DateTime hasta, Int32 usarFechaFacturacion, Int32 usarTipoCambioCuentaCorriente)
        {
            return objADReporte.reporteFlujoIngresos(desde, hasta, usarFechaFacturacion, usarTipoCambioCuentaCorriente);
        }
    }
}
