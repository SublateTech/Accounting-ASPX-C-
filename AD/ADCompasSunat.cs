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
    public class ADCompasSunat
    {
        private const string PROC_Compra_Sunat = "UCO_RegistroDeComprasSunatElectronico";
        private const string PROC_Compra_SunatValida = "UCO_RegistroDeComprasSunatElectronicoValida";
        public DataTable getValidacompras(Int32 Desde, Int32 Empresa, Int32 Hasta, Int32 MonedaId)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[9];

                par[0] = new SqlParameter("@Monedaid", System.Data.SqlDbType.Int);
                par[0].Value = MonedaId;
                par[1] = new SqlParameter("@Desde", System.Data.SqlDbType.Int);
                par[1].Value = Desde;
                par[2] = new SqlParameter("@Hasta", System.Data.SqlDbType.Int);
                par[2].Value = Hasta;
                par[3] = new SqlParameter("@EstablecimientoID", System.Data.SqlDbType.Int);
                par[3].Value = Empresa;

                _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[UCO_RegistroDeComprasSunatElectronicoValida]", par).Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
            return _dataTable;
        }
        
        public Boolean CompasSunat(List<BECompasSunat> listBECompasSunat)
        {
            Boolean estado = false;

            SqlConnection connection = new SqlConnection(conexion.connectionString());
            connection.Open();

            SqlTransaction sqlTran = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            try
            {
                foreach (BECompasSunat objComprasSunat in listBECompasSunat)
                {
                    SqlParameter[] par = new SqlParameter[9];
                    par[0] = new SqlParameter("@Desde", System.Data.SqlDbType.Int);
                    par[0].Value = objComprasSunat.desde;
                    par[1] = new SqlParameter("@Empresa", System.Data.SqlDbType.Int);
                    par[1].Value = objComprasSunat.empresa;
                    par[2] = new SqlParameter("@Hasta", System.Data.SqlDbType.Int);
                    par[2].Value = objComprasSunat.hasta;
                    par[3] = new SqlParameter("@MonedaId", System.Data.SqlDbType.Int);
                    par[3].Value = objComprasSunat.monedaId;
                   

                    SqlHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure, PROC_Compra_Sunat, par);
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
