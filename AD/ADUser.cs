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
  public class ADUser
  {
    public ADUser()
    { }
    public Boolean login(String user,String password)
    {
      Boolean stateLogin = false;

      SqlParameter[] par = new SqlParameter[2];
      par[0] = new SqlParameter("@NombreUsuario", System.Data.SqlDbType.NVarChar, 50);
      par[0].Value = user;
      par[1] = new SqlParameter("@Clave", System.Data.SqlDbType.NVarChar, 50);
      par[1].Value = password;

      try
      {
        SqlDataReader _dataReader = SqlHelper.ExecuteReader(Connection.connectionString(), CommandType.StoredProcedure, "[usp_PerSelUsuarios]", par);
        _dataReader.Read();
        if (_dataReader.HasRows)
        {
          stateLogin = true;
        }
        _dataReader.Close();
      }
      catch (Exception e)
      {
        throw e;
      }
      finally
      { 

      }
      return stateLogin;
    }


    public Int32 usuarioId(String user)
    {
        string query = "UCO_UsuarioId";
        
        SqlParameter[] parametros = {
                                        new SqlParameter("@NombreUsuario",user)
                                    };

        return Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.connectionString(), query, parametros));

        
        
    }

    public Boolean permisoEliminarVoucherTodos(Int32 usuarioId)
    {
        string query = "UCO_UsuarioPermisoEliminarVoucherTodos";
        
        SqlParameter[] parametros = {
                                        new SqlParameter("@UsuarioId",usuarioId)
                                    };

        //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

        DataRow fila;

        fila = SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros).Tables[0].Rows[0];

        Boolean valor;

        valor = Convert.ToBoolean(fila["EliminaVoucher"]);

        return valor;


    }

    public DataTable fnUsuariosAll()
    {
        DataTable oDataTable = new DataTable();

        try
        {
            oDataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "usp_SelUsuariosAll").Tables[0];
        }
         catch (Exception ex)
        {
            
            
            
            
            
            
            
            
            
            
            
            
            throw ex;
        }
        finally
        {
        }

        return oDataTable;
    }

  }
}
