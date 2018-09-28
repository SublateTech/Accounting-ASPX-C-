using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Contabilidad
{
    static class funcionesReporte
    {
        public const int ReporteVentasSunat = 1;
        public const int ReporteComprasSunat = 2;
        //public const int ReporteVentasLAP= 3;
        //public const int ReporteVentasContaSis = 4;
        public const int ReporteLibroDiarioSunat = 5;
        public const int ReporteLibroMayorSunat = 6;
        //public const int ReporteLibroInventariosPermanentes = 7;


        public const string TR_VentasSunat="Ventas Sunat";
        public const string TR_CompasSunat = "Compras Sunat";
        //public const string TR_VentasLAP = "Ventas LAP";
        //public const string TR_VentasContaSis = "Ventas ContaSis";
        public const string TR_LibroDiarioSunat = "Libro Diario Sunat";
        public const string TR_LibroMayorSunat = "Libro Mayor Sunat";
        //public const string TR_LibroInventariosPermanentes = "Libro Inventarios Permanentes";
        
    }
}
