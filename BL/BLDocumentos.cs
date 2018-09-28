using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AD;

namespace BL
{
    public class BLDocumentos
    {

    private AdDocumentos objADDocumentos;

    public BLDocumentos()
    {
      objADDocumentos = new AdDocumentos();
    }

    public DataTable tipos()
    {
        return objADDocumentos.tipos();
    }


    }
}
