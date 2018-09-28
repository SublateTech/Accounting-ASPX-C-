using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using AD;
using System.Data;

namespace BL
{
    public class BLVentasSunat
    {
         private ADVentasSunar objADVentasSunat;
        public BLVentasSunat() 
        {
            objADVentasSunat = new ADVentasSunar();
        }

      //  public Boolean dsVentasSunat(int monedaIDEmision, int monedaId,string moneda,DateTime desde,DateTime hasta,int empresa,int establecimientoID,int produccion,int prepagos)
        //{
            //return objADVentasSunat.VentasSunat(monedaIDEmision, monedaId, moneda, desde, hasta, empresa, establecimientoID, produccion, prepagos);
        //}
    }
}
