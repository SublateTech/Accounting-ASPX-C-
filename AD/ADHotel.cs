using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BE;
using System.Configuration;
namespace AD
{
  public class ADHotel
  {
    private BEHotel objBEHotel;

    public ADHotel()
    {
      objBEHotel = new BEHotel();
    }

    public List<BEHotel> getHoteles(Int32 _EstablecimientoID, Boolean moduloHabilitado=false)
    {

      List<BEHotel> listObjBEHoteles = new List<BEHotel>();
      try
      {
        String query = "select * from hoteles WHERE EstablecimientoID='" + _EstablecimientoID + "'";
        SqlDataReader _dataReader = SqlHelper.ExecuteReader(Connection.connectionString(), CommandType.Text, query);
        while (_dataReader.Read())
        {
          BEHotel objBEHotelTemp = new BEHotel();
          objBEHotelTemp.HotelID = (Int32)_dataReader.GetValue(_dataReader.GetOrdinal("HotelID"));
          objBEHotelTemp.NombreHotel = (String)_dataReader.GetValue(_dataReader.GetOrdinal("NombreHotel"));
          objBEHotelTemp.PuntoVentaIDAlojamiento = (Int32)_dataReader.GetValue(_dataReader.GetOrdinal("PuntoVentaIDAlojamiento"));
          objBEHotelTemp.PuntoVentaIDEventos = (Int32)_dataReader.GetValue(_dataReader.GetOrdinal("PuntoVentaIDEventos"));
          objBEHotelTemp.EstablecimientoID = (Int32)_dataReader.GetValue(_dataReader.GetOrdinal("EstablecimientoID"));
          listObjBEHoteles.Add(objBEHotelTemp);
        }
        _dataReader.Close();
      }
      catch (Exception e)
      {
        throw e;
      }
      return listObjBEHoteles;
    }

    public DataTable getUnidadesNegocio(Int32 _EstablecimientoID,String Where, String OrderBy)
    {
        String query = "UCO_UnidadesDeNegocios_Select";

        SqlParameter[] parametros = {
                                        new SqlParameter("@EstablecimientoId",_EstablecimientoID),
                                        new SqlParameter("@WhereCondition",Where),
                                        new SqlParameter("@OrderByExpression",OrderBy)
                                    };
        try
        {
            return SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros).Tables[0];
        }
        catch (SqlException e)
        {

            Console.WriteLine(e.Message);
            return new DataTable();

        }
        catch (Exception e)
        {
            
            Console.WriteLine(e.Message);
            return new DataTable();

        }

        
    }

    public DataTable getUnidadesNegocioArea(Int32 EstablecimientoId, Int32 HotelID, Int32 AreaID)
    {
        
        string query = "UCO_UnidadesDeNegocio_Areas_Select";

        SqlParameter[] parametros = {
                                        new SqlParameter("@EstablecimientoID",EstablecimientoId),
                                        new SqlParameter("@HotelID",HotelID),
                                        new SqlParameter("@AreaID",AreaID)
                                    };

        return SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros).Tables[0];

    }

    public DataTable getAreas(int EstablecimientoID, int HotelID) 
    {
        string query = "select AreaID, Nomenclatura, nombreArea from areas where EstablecimientoID = " + EstablecimientoID.ToString() + " and HotelID = " + HotelID.ToString() + " order by nombreArea";

        return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];

 
    }


    public DataTable getAreas(String Where, String OrderBy)
    {
        String query = "UCO_Areas_Select";

        SqlParameter[] parametros = {
                                        
                                        new SqlParameter("@WhereCondition",Where),
                                        new SqlParameter("@OrderByExpression",OrderBy)
                                    };
        try
        {
            return SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros).Tables[0];
        }
        catch (SqlException e)
        {

            Console.WriteLine(e.Message);
            return new DataTable();

        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return new DataTable();

        }


    }

    public DataTable getProyectos()
    {
        string query = "select ProyectoId, NombreProyecto from proyectos where estado=0";

        return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];

    }

    public Boolean estaHabilitado()
    {
        string query = "select Estado from ParametrosGenerales where ParametroGeneralID=" + ConfigurationManager.AppSettings["PG_ModuloHabilitado"].ToString();       

        int estado = 0;

        estado = Convert.ToInt32(SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0].Rows[0]["Estado"]);

        if (estado == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public String codigoConcesionario()
    {
        string query = "select Valor from ParametrosGenerales where ParametroGeneralID=" + ConfigurationManager.AppSettings["PG_CodigoConcesionario"].ToString();
        try
        {
            return Convert.ToString(SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0].Rows[0]["Valor"]);
        }
        catch
        {
            return "";
        }
    }




  }
}
