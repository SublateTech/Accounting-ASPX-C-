using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AD;
namespace BL
{
  public class BLEmpresa
  {
    private ADEmpresa objADEmpresa;
    public BLEmpresa()
    {
      objADEmpresa = new ADEmpresa();
    }

    public DataTable getEmpresa(Int32 categoriaId, String razonSocial, String ruc)
    {
      return objADEmpresa.getEmpresa(categoriaId, razonSocial, ruc);
    }

    public DataTable getEmpresa(String Ruc)
    {
        return objADEmpresa.getEmpresa(Ruc);
    }

    public DataTable getEmpresa(String buscar,int maxRecords)
    {
        return objADEmpresa.getEmpresa(buscar,maxRecords);
    }
  }
}
