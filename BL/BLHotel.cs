using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AD;
using BE;
using System.Data;
namespace BL
{
  public class BLHotel
  {
    private ADHotel objADHotel;
    public BLHotel()
    {
      objADHotel = new ADHotel();
    }
    public List<BEHotel> getHoteles(Int32 _EstablecimientoID)
    {
        return objADHotel.getHoteles(_EstablecimientoID);
    }

    public DataTable getUnidadesNegocio(Int32 _EstablecimientoID, String Where, String OrderBy)
    {
        return objADHotel.getUnidadesNegocio(_EstablecimientoID, Where, OrderBy);
    }

    public DataTable getAreas(String Where, String OrderBy)
    {
        return objADHotel.getAreas(Where, OrderBy);
    }

    public DataTable getAreas(Int32 EstablecimientoID, Int32 HotelID)
    {
        return objADHotel.getAreas(EstablecimientoID, HotelID);
    }

    public DataTable getUnidadesNegocioArea(Int32 EstablecimientoId, Int32 HotelID, Int32 AreaID)
    {
        return objADHotel.getUnidadesNegocioArea(EstablecimientoId, HotelID, AreaID);
    }

    public DataTable getProyectos()
    {
        return objADHotel.getProyectos();
    }

    public Boolean estaHabilitado()
    {
        return objADHotel.estaHabilitado();
    }

    public String codigoConcesionario()
    {
        return objADHotel.codigoConcesionario();
    }

  }
}
