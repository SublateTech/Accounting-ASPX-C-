using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

namespace Contabilidad
{

    

    static class cDatos
    {


        private static int _EstablecimientoId = 0;
        private static int _HotelId = 0;
        private static int _UsuarioId = 0;
        private static int _Periodo = 0;

        private static string _Establecimiento = "";
        private static string _Hotel = "";
        

        static public int EstablecimientoID { 
            get {return _EstablecimientoId;}
            set { _EstablecimientoId = value;} 
            
        }

        static public string Establecimiento
        {
            get { return _Establecimiento; }
            set { _Establecimiento = value; }

        }

        static public int HotelID
        {
            get { return _HotelId; }
            set { _HotelId = value; }
        }

        static public string Hotel
        {
            get { return _Hotel; }
            set { _Hotel = value; }

        }

        static public int UsuarioID
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        static public int Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }

        public static string Left(string param, int length)
        {



            string result = param.Substring(0, length);

            return result;

        }

        public static string Right(string param, int length)
        {


            int value = param.Length - length;

            string result = param.Substring(value, length);

            return result;

        }

        public static string Mid(string param, int startIndex, int length)
        {

            string result = param.Substring(startIndex, length);

            return result;

        }



        public static string Mid(string param, int startIndex)
        {

            string result = param.Substring(startIndex);

            return result;

        }

     public static string cfgGetValue(string seccion, string clave, string predeterminado)
     {
         IDictionary valores = (IDictionary) ConfigurationManager.GetSection(seccion);
         if (valores.Contains(clave))
         {
             return valores[clave].ToString();
         }
         else
         {
             return predeterminado;
         }

     }


   

    }
}
