using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
  public class BEHotel
  {
    private Int32 _HotelID;
    private String _NombreHotel;
    private Int32 _PuntoVentaIDAlojamiento;
    private Int32 _PuntoVentaIDEventos;
    private Int32 _EstablecimientoID;

    public Int32 HotelID
    {
      get { return _HotelID; }
      set { _HotelID = value; }
    }
    public String NombreHotel
    {
      get { return _NombreHotel; }
      set { _NombreHotel = value; }
    }
    public Int32 PuntoVentaIDAlojamiento
    {
      get { return _PuntoVentaIDAlojamiento; }
      set { _PuntoVentaIDAlojamiento = value; }
    }
    public Int32 PuntoVentaIDEventos
    {
      get { return _PuntoVentaIDEventos; }
      set { _PuntoVentaIDEventos = value; }
    }
    public Int32 EstablecimientoID
    {
      get { return _EstablecimientoID; }
      set { _EstablecimientoID = value; }
    }
  }
}
