using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
  [Serializable]
  public partial class BEEstablecimiento
  {
    private Int32 _establecimientoId;
    private String _nombreEstablecimiento;
    private String _direccion;
    private String _ruc;
    private String _nombreHotel;

    public Int32 EstablecimientoId
    {
      get { return _establecimientoId; }
      set { _establecimientoId = value; }
    }
    public String NombreEstablecimiento
    {
      get { return _nombreEstablecimiento; }
      set { _nombreEstablecimiento = value; }
    }
    public String Direccion
    {
      get { return _direccion; }
      set { _direccion = value; }
    }
    public String Ruc
    {
      get { return _ruc; }
      set { _ruc = value; }
    }
    public String NombreHotel
    {
      get { return _nombreHotel; }
      set { _nombreHotel = value; }
    }

  }

}
