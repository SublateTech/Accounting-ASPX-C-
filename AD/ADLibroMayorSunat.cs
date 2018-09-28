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
    public class ADLibroMayorSunat
    {
        private const string PROC_Libro_Mayor_Sunat = "UCO_RegistroLibroMayorSunatElectronico";

        public Boolean LibroMayorSunat(List<BELibroMayorSunat> listBELibroMayorSunat)
        {
            Boolean estado = false;

            SqlConnection connection = new SqlConnection(conexion.connectionString());
            connection.Open();

            SqlTransaction sqlTran = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            try
            {
                foreach (BELibroMayorSunat objLibroMayorSunat in listBELibroMayorSunat)
                {
                    SqlParameter[] par = new SqlParameter[9];
                    par[0] = new SqlParameter("@Desde", System.Data.SqlDbType.Int);
                    par[0].Value = objLibroMayorSunat.desde;
                    par[1] = new SqlParameter("@Hasta", System.Data.SqlDbType.Int);
                    par[1].Value = objLibroMayorSunat.hasta;
                    par[2].Precision = 18;
                    par[2].Scale = 2;


                    SqlHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure, PROC_Libro_Mayor_Sunat, par);
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
