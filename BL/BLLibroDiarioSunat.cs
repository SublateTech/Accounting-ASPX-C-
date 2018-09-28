using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using AD;
using System.Data;

namespace BL
{
    public class BLLibroDiarioSunat
    {
        private ADLibroDiarioSunat objADLibroDiarioSunat;
        public BLLibroDiarioSunat() 
        {
            objADLibroDiarioSunat = new ADLibroDiarioSunat();
        }
    }
}
