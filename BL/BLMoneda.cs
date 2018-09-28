using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AD;
 
namespace BL
{
  public class BLMoneda
  {
    private ADMoneda objADMoneda;
    public BLMoneda() 
    {
      objADMoneda = new ADMoneda();
    }
    public DataTable getMoneda()
    {
      return objADMoneda.getMoneda();
    }

    public DataTable getTipoConversion()
    {
        return objADMoneda.getTipoConversion();
    }

    public Decimal getTipoCambio(string tipoConversionID, DateTime fecha)
    {
        return objADMoneda.getTipoCambio(tipoConversionID, fecha);
    }

    

  }
}
