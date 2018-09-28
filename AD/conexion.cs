using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AD
{
    public class conexion
    {
        public static String connectionString()
        {
            //  Para publicar   ---> lawn
            //  Para programar  ---> home
            String nombre_conexion = "";
            nombre_conexion = ConfigurationManager.AppSettings["conexionBD_Datos"];
            return ConfigurationManager.ConnectionStrings[nombre_conexion].ConnectionString;
            String cadena = ConfigurationManager.AppSettings["cadenaconexion"].ToString();
            return ConfigurationManager.ConnectionStrings[cadena].ConnectionString;
        }

        public static String connectionStringSeguridad()
        {
            //  base de datos de seguridad
            String nombre_conexion = "";
            nombre_conexion = ConfigurationManager.AppSettings["conexionBD_Seguridad"];
            return ConfigurationManager.ConnectionStrings[nombre_conexion].ConnectionString;
        }
    }
}
