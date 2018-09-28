using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BE;
namespace AD
{
  public class ADEstablecimiento
  {
    public ADEstablecimiento() 
    {
    
    }
    public List<BEEstablecimiento> getEstablecimientosAll2()
    {
      List<BEEstablecimiento> listBEEstablecimiento = new List<BEEstablecimiento>();

      return listBEEstablecimiento;
    }
    public DataTable getEstablecimientosAll()
    {
      DataTable _dataTable = new DataTable();
      try
      {
            _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "usp_RodSelEstablecimientosAll").Tables[0];
      }
      catch (Exception e)
      {
        //throw e;
        Console.WriteLine(e.Message);
      }
      finally
      {

      }
      return _dataTable;
    }

    public DataTable getEstablecimientoHotel()
    {
        DataTable _dataTable = new DataTable();
        try
        {
            //create procedure UCO_SELECT_EstablecimientoHotel

            _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_SELECT_EstablecimientoHotel").Tables[0];
        }
        catch (Exception e)
        {
            //throw e;
            Console.WriteLine(e.Message);
        }
        finally
        {

        }
        return _dataTable;
    }
  }
}
