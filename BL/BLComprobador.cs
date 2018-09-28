using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BLComprobador
    {

        private AD.ADComprobador objComprobador;

         public BLComprobador()
        {
            objComprobador = new AD.ADComprobador();
        }

         public bool validarConexion()
         {
             return objComprobador.validarConexion();
         }


         public bool ExisteProcedimiento(string StoredProcedureName)
         {
             return objComprobador.ExisteProcedimiento(StoredProcedureName);
         }

         public string server()
         {

             return objComprobador.server();

         }

         public string database()
         {
            
             return objComprobador.database();

         }

         public string user()
         {

             return objComprobador.user();

         }

         public string password()
         {

             return objComprobador.password();

         }

    }
}
