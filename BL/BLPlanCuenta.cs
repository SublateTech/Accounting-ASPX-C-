using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AD;
namespace BL
{
  public class BLPlanCuenta
  {
    ADPlanCuenta objADPlanCuenta;
    public BLPlanCuenta()
    {
      objADPlanCuenta = new ADPlanCuenta();
    }
    public DataTable getPlanCuentas(Int32 establecimientoId)
    {
        String whereCondition = "EstablecimientoID='" + establecimientoId + "' and nivelsaldoId ='17'";
        String orderByExpression = "NombrePlanCuenta";
        return objADPlanCuenta.getPlanCuentas(whereCondition, orderByExpression);
    }

    public DataTable getPlanCuentas()
    {
        return objADPlanCuenta.getPlanCuentas();
    }

    public DataTable getFormatoPlanCuentas()
    {
        return objADPlanCuenta.getFormatoPlanCuentas();
    }

    public String NombreCuenta(string Codigo, Int32 EstablecimientoId)
    {
        return objADPlanCuenta.NombreCuenta(Codigo, EstablecimientoId);
    }

    public DataTable DatosCuenta(string Codigo, Int32 EstablecimientoId)
    {
        return objADPlanCuenta.DatosCuenta(Codigo, EstablecimientoId);
    }

    public DataTable getCanalesContables()
    {
        return objADPlanCuenta.getCanalesContables();
    }

    public DataTable getFlujoCaja()
    {
        return objADPlanCuenta.getFlujoCaja();
    }

    public DataTable getPlanCuentas(string criterio, Int32 EstablecimientoId)
    {
        return objADPlanCuenta.getPlanCuentas(criterio, EstablecimientoId);
    }
    public Int32 getMonedaCuenta(String PlanCuentaId)
    {
        return objADPlanCuenta.getMonedaCuenta(PlanCuentaId);
    }
  }
}
