using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
  public class ADAlmacen
  {
    public ADAlmacen()
    { }

    public DataTable almacenesAll()
    {
      DataTable _dataTable = new DataTable();
      try
      {
        String query="select AlmacenId,NombreAlmacen from almacenes";
        _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text,query).Tables[0];
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


    
  }
}
