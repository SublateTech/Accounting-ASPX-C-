using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AD;

namespace BL
{
  public class BLAlmacen
  {
    private ADAlmacen objADAlmacen;
    public BLAlmacen()
    {
      objADAlmacen = new ADAlmacen();
    }
    public DataTable almacenesAll()
    {
      return objADAlmacen.almacenesAll();
    }
  }
}
