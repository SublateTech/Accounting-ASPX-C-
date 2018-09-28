using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad
{
    class Class1
    {
        private static string rptRegistroVentasSunat = "asd";
        public static string nombreReportePLE
        {
            get
            {
                return rptRegistroVentasSunat;
            }
            set
            {
                rptRegistroVentasSunat = value;
            }
           
        }
        private static string fechadesdeV = "";
        public static string fechaDesde
        {
            get
            {
                return fechadesdeV;
            }
            set
            {
                fechadesdeV = value;
            }
           
        }
        private static string fechaHastaV = "";
        public static string fechaHasta
        {
            get
            {
                return fechaHastaV;
            }
            set
            {
                fechaHastaV = value;
            }
            //get;
            //set;
        }
            private static string rptRegistroComprasSunat = "asd";
        public static string nombreReportePLE1
        {
            get
            {
                return rptRegistroComprasSunat;
            }
            set
            {
                rptRegistroVentasSunat = value;
            }
            //get;
            //set;
        }
        private static string fechadesdeV1 = "";
        public static string fechaDesde1
        {
            get
            {
                return fechadesdeV1;
            }
            set
            {
                fechadesdeV1 = value;
            }
            //get;
            //set;
        }
        private static string fechaHastaV1 = "";
        public static string fechaHasta1
        {
            get
            {
                return fechaHastaV1;
            }
            set
            {
                fechaHastaV1 = value;
            }
        }
    }
}
