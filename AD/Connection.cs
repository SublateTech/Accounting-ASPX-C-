using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AD
{
  public class Connection
  {
      public static string cadenaconec;
    public static String connectionString()
        {
      
      //return ConfigurationManager.AppSettings.Get("connectionString");
      //return ConfigurationManager.ConnectionStrings["demo"].ConnectionString;

            string cadena = "Coneccion" + cadenaconec;  // ConfigurationManager.AppSettings["cadenaconexion"].ToString(); //demo
      return ConfigurationManager.ConnectionStrings[cadena].ConnectionString;

    }
  }
}
