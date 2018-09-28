using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AD;
namespace BL
{
  public class BLEstablecimiento
  {
    private ADEstablecimiento objADEstablecimiento;
    public BLEstablecimiento()
    {
      objADEstablecimiento = new ADEstablecimiento();    
    }
    public DataTable getEstablecimientosAll()
    {
      return objADEstablecimiento.getEstablecimientosAll();
    }

    public DataTable getEstablecimientoHotel()
    {
        return objADEstablecimiento.getEstablecimientoHotel();
    }

  }
}
