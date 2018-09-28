using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
  public class ADLibroDiario
  {
    public ADLibroDiario()
    {    
    }
    public DataTable getLibroDiario(Int32 monedaId, DateTime date_start, DateTime date_end)
    {
      DataTable _dataTable = new DataTable();
      try
      {
        SqlParameter[] par = new SqlParameter[4];

        par[0] = new SqlParameter("@MonedaID", System.Data.SqlDbType.Int);
        par[0].Value = monedaId;
        par[1] = new SqlParameter("@Desde", System.Data.SqlDbType.DateTime);
        par[1].Value = date_start;
        par[2] = new SqlParameter("@Hasta", System.Data.SqlDbType.DateTime);
        par[2].Value = date_end;

        _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[Sp_Empresas]", par).Tables[0];
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
  }
}
