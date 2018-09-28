using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace AD
{
    public class ADcontrolPeriodo
    {
        public DataTable UCO_selectControlPeriodo(Int32 PeriodoIDV)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@PeriodoID", System.Data.SqlDbType.Int);
                par[0].Value = PeriodoIDV;

                _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[UCO_selectControlPeriodo]", par).Tables[0];
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
            }
            return _dataTable;
        }


        //nbernuy 01/04/2016
        public DataTable ValidacionTransferencia(Int32 id, DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@ProcesoID", System.Data.SqlDbType.Int);
                par[0].Value = id;
                par[1] = new SqlParameter("@Desde", System.Data.SqlDbType.DateTime);
                par[1].Value = desde;
                par[2] = new SqlParameter("@Hasta", System.Data.SqlDbType.DateTime);
                par[2].Value = hasta;
                dt = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[UCO_ValidaTransferenciasContables]", par).Tables[0];

            }
            catch (Exception e)
            {

            }
            return dt;
        }
    }
}
