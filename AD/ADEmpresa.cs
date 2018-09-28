using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace AD
{
  public class ADEmpresa
  {
    public DataTable getEmpresa(Int32 categoriaId, String razonSocial,String ruc)
    {
      DataTable _dataTable = new DataTable();
      try
      {
        SqlParameter[] par = new SqlParameter[3];

        par[0] = new SqlParameter("@CategoriaId", System.Data.SqlDbType.Int);
        par[0].Value = categoriaId;
        par[1] = new SqlParameter("@RazonSocial", System.Data.SqlDbType.NVarChar, 30);
        par[1].Value = razonSocial;
        par[2] = new SqlParameter("@Ruc", System.Data.SqlDbType.NVarChar, 15);
        par[2].Value = ruc;

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

    public DataTable getEmpresa(String Ruc)
    {
        string query = "select top 1 empresaid,razonsocial from empresas where ruc = '" + Ruc + "'";

        DataTable tabla;

        try
        {
            tabla = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
        }
        catch
        {
            tabla = new DataTable();
        }

        return tabla;

    }

    public DataTable getEmpresa(String buscar,int maxRecords)
    {


        string query;

        if (maxRecords > 0)
        {
            query = "select top " + maxRecords.ToString() + " empresaid, rtrim(razonsocial) razonsocial, ruc from empresas where (ruc like '%" + buscar + "%') OR (razonsocial like '%" + buscar + "%')";
        }
        else
        {
            query = "select empresaid,  rtrim(razonsocial) razonsocial, ruc from empresas where  (ruc like '%" + buscar + "%') OR (razonsocial like '%" + buscar + "%')";
        }

        DataTable tabla;

        try
        {
            tabla = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
        }
        catch
        {
            tabla = new DataTable();
        }

        return tabla;

    }

  }
}
