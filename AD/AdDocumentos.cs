
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
    public class AdDocumentos
    {
        public AdDocumentos()
    {
 
    }

        public DataTable tipos()
        {
            string query = "select TipoDocumentoID, '[' + CAST(ISNULL(rtrim(ltrim(Codigo)),'') as char(3)) + '][' + ISNULL(CAST(CanjeaDocumento as char(1)),' ') + '][' +CAST(ISNULL(CodigoSunat,'') as char(3)) + ']' + NombreDocumento as TipoDocumento from tipodocumentos";

            query = "select TipoDocumentoID, NombreDocumento as TipoDocumento from tipodocumentos order by NombreDocumento";


            return SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
        }

    }
}
