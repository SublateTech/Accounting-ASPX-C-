using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using System.Configuration;


namespace AD
{
    public class ADComprobador
    {
        public bool ExisteProcedimiento(string StoredProcedureName)
        {
            string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND ROUTINE_NAME = '" + StoredProcedureName + "'";

            string cadenaConexion = Connection.connectionString();

            int valor = (int)SqlHelper.ExecuteScalar(cadenaConexion, CommandType.Text, query);

            return (valor > 0);
        }

        public bool validarConexion()
        {
            string query = "select top 1 pasajeroid from pasajeros";
            Int32 codigo;
            try
            {
                codigo = (Int32)SqlHelper.ExecuteScalar(Connection.connectionString(), CommandType.Text, query);
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }

        public string server()
        {
            SqlConnectionStringBuilder cnx_prueba = new SqlConnectionStringBuilder(Connection.connectionString());

            return cnx_prueba.DataSource;

        }

        public string database()
        {
            SqlConnectionStringBuilder cnx_prueba = new SqlConnectionStringBuilder(Connection.connectionString());

            return cnx_prueba.InitialCatalog;

        }

        public string user()
        {
            SqlConnectionStringBuilder cnx_prueba = new SqlConnectionStringBuilder(Connection.connectionString());

            return cnx_prueba.UserID;

        }

        public string password()
        {
            //09/12/2013
            SqlConnectionStringBuilder cnx_prueba = new SqlConnectionStringBuilder(Connection.connectionString());

            return cnx_prueba.Password;

        }

    }
}
