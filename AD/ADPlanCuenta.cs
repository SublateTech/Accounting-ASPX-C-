using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
  public class ADPlanCuenta
  {
    public ADPlanCuenta()
    { 
    }
    public DataTable getPlanCuentas(String whereCondition, String orderByExpression) 
    {
      DataTable _dataTable = new DataTable();
      try
      {
        SqlParameter[] par = new SqlParameter[4];

        par[0] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 1000);
        par[0].Value = whereCondition;
        par[1] = new SqlParameter("@OrderByExpression", System.Data.SqlDbType.NVarChar,250);
        par[1].Value = orderByExpression;

        _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[UCO_PlanDeCuentas_Select_PopUp]", par).Tables[0];
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

    public DataTable getPlanCuentas()
    {
        DataTable _dataTable = new DataTable();
        try
        {
            
            //_dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[UCO_PlanDeCuentas_Select_PopUp]", par).Tables[0];

            _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "[UCO_PlanDeCuentas_Select_v2]").Tables[0];

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

    public DataTable getPlanCuentas(string criterio,Int32 EstablecimientoId)
    {
        string query = "select ltrim(rtrim(PlanCuentaID)) as PlanCuentaId, CodigoPlanCuenta, CAST(CodigoPlanCuenta as char(8)) + ' => ' + NombrePlanCuenta as Cuenta from plandecuentas where ((ltrim(rtrim(CodigoPlanCuenta)) like '" + criterio + "%') or (ltrim(rtrim(NombrePlanCuenta)) like '" + criterio + "%'))";

        query = query + " AND EstablecimientoId = " + EstablecimientoId.ToString();

        query = query + " AND NivelSaldoID <> (Select LTrim(RTrim(Valor)) From ParametrosGenerales Where ParametroGeneralID = 5001) Order by CodigoPlanCuenta, NombrePlanCuenta";

        return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];

    }

    public DataTable getFormatoPlanCuentas()
    {
        try

        {
            string query = "SELECT 0 As Codigo, 'DETALLADO' AS Formato UNION SELECT 1 as Codigo, 'CONSOLIDADO' AS Formato";
            return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            return new DataTable();
        }
        
    }

    public String NombreCuenta(string Codigo,Int32 EstablecimientoId)

    {
        string query = "SELECT ISNULL(NombrePlanCuenta,'') as NombrePlanCuenta FROM PlandeCuentas WHERE CodigoPlanCuenta = '" + Codigo.Trim() + "'";

        StringBuilder consulta = new StringBuilder();

        consulta.Append("select NombrePlanCuenta from plandecuentas where NivelSaldoID <> (select ltrim ");

        consulta.Append("(Valor) From ParametrosGenerales Where ParametroGeneralID = 5001) ");

        consulta.Append(" And CodigoPlanCuenta = '" + Codigo.Trim() + "'");

        consulta.Append(" And EstablecimientoId = " + EstablecimientoId.ToString());

        consulta.Append(" order by CodigoPlanCuenta, NombrePlanCuenta");

        query = consulta.ToString();

        

        try
        {
            DataRow fila = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0].Rows[0];
            return Convert.ToString(fila["NombrePlanCuenta"]);
        }
        catch
        {
            return "";
        }
        

    }

    public DataTable DatosCuenta(string Codigo, Int32 EstablecimientoId)
    {
        string query = "";

        StringBuilder consulta = new StringBuilder();

        consulta.Append("select PlanCuentaID, CodigoPlanCuenta, NombrePlanCuenta, ISNULL(RequiereDocumento,0) AS RequiereDocumento, ISNULL(RequiereFechaVencimiento,0) AS RequiereFechaVencimiento, ISNULL(RequiereArea,0) AS RequiereArea, ISNULL(RequiereProyecto,0) AS RequiereProyecto, ISNULL(RequiereCanal,0) AS RequiereCanal, CASE WHEN SubString(CodigoPlanCuenta,1,2)='10' THEN 1 ELSE 0 END as RequiereFlujoCaja  from plandecuentas where NivelSaldoID <> (select ltrim ");

        consulta.Append("(Valor) From ParametrosGenerales Where ParametroGeneralID = 5001) ");

        consulta.Append(" And CodigoPlanCuenta = '" + Codigo.Trim() + "'");

        consulta.Append(" And EstablecimientoId = " + EstablecimientoId.ToString());

        consulta.Append(" order by CodigoPlanCuenta, NombrePlanCuenta");

        query = consulta.ToString();



        try
        {
            DataTable dt = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
            return dt;
        }
        catch
        {
            return new DataTable();
        }


    }

    public DataTable getCanalesContables()
    {
        string query = "select canalcontableid,UPPER(codigocanalcontable) + ' ==> ' + nombrecanalcontable as canalcontable from canalescontables where estado = 0";

        return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];


    }

    public DataTable getFlujoCaja() 
    { 
        string query = "select FlujoCajaID, NombreFlujoCaja from flujocaja order by nombreflujocaja";

        return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];

    }

    public Int32 getMonedaCuenta(String PlanCuentaId)
    {
        
        string query = "UCO_GetMonedaCuenta";

        SqlParameter[] parametros = {
                                        new SqlParameter("@PlanCuentaId",PlanCuentaId)
                                    };

        Int32 valor = 0;
        try
        {
            valor = Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.connectionString(), query, parametros));
        }
        catch
        {
            valor = 0;
        }
        return valor;
    }

  }
}
