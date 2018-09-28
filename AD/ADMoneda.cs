using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
namespace AD
{
  public class ADMoneda
  {
    public ADMoneda() 
    { 
    }
    public DataTable getMoneda()
    {
      DataTable _dataTable = new DataTable();
      try
      {
        _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, "select monedaid,Nombre,Nomenclatura from monedas").Tables[0];
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

    public DataTable getTipoConversion()
    {
        DataTable _dataTable = new DataTable();
        try
        {
            string query = "select TipoConversionMonedaID, CodigoTipoConversionMoneda + ' ==> ' + NombreTipoConversionMoneda as TipoConversion from tipodeconversionesmoneda where Estado=0";
            _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
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

    public Decimal getTipoCambio(string tipoConversionID, DateTime fecha)
    {
        //StringBuilder consulta = new StringBuilder();
        
        //consulta.Append("select case when " + tipoConversionID.Trim() + "= 111" + " then (select top 1 compra from tiposcambio where fechacambioid='" + fecha.ToShortDateString() + "') ");
        //consulta.Append("when " + tipoConversionID.Trim() + "=112 then (select top 1 venta from tiposcambio where fechacambioid='"+fecha.ToShortDateString()+"') end TipoCambio");

        //string query = consulta.ToString();

        string query = "";

        query = "UCO_TipoCambio_TipoConversionFecha";

        SqlParameter[] parametros = {
                                        new SqlParameter("@TipoConversionMonedaId",tipoConversionID),
                                        new SqlParameter("@Fecha",fecha)
                                    };
        Decimal valor = 0;
        try { 
            valor = Convert.ToDecimal(SqlHelper.ExecuteScalar(Connection.connectionString(), query, parametros));
            return valor;
        }
        catch { return valor; }
        

    }
  }
}
