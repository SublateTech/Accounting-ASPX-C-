using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
    public class ADLibroDiarioSunat
    {
        private const string PROC_Libro_Diario_Sunat = "UCO_RegistroLibroDiarioSunatElectronico";

        public Boolean LibroDiarioSunat(List<BELibroDiarioSunat> listBELibroDiarioSunat)
        {
            Boolean estado = false;

            SqlConnection connection = new SqlConnection(conexion.connectionString());
            connection.Open();

            SqlTransaction sqlTran = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            try
            {
                foreach (BELibroDiarioSunat objLibroDiarioSunat in listBELibroDiarioSunat)
                {
                    SqlParameter[] par = new SqlParameter[9];
                    par[0] = new SqlParameter("@Desde", System.Data.SqlDbType.Int);
                    par[0].Value = objLibroDiarioSunat.desde;        
                    par[1] = new SqlParameter("@Hasta", System.Data.SqlDbType.Int);
                    par[1].Value = objLibroDiarioSunat.hasta;                  
                    par[2].Precision = 18;
                    par[2].Scale = 2;
          

                    SqlHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure, PROC_Libro_Diario_Sunat, par);
                }
                sqlTran.Commit();
                estado = true;
            }
            catch (Exception e)
            {
                //throw e;
                sqlTran.Rollback();
                estado = false;
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return estado;
        }
    }
}
