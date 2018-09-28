using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
    public class ADVentasSunar
    {

        
        private const string PROC_Venta_Sunat = "UCO_RegistroDeVentasSunatElectronico";

        public Boolean VentasSunat(List<BEVentasSunat> listBEVentasSunat)
        {
            Boolean estado = false;

            SqlConnection connection = new SqlConnection(conexion.connectionString());
            connection.Open();

            SqlTransaction sqlTran = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            try
            {
                foreach (BEVentasSunat objVentasSunat in listBEVentasSunat)
                {
                    SqlParameter[] par = new SqlParameter[9];
                    par[0] = new SqlParameter("@Desde", System.Data.SqlDbType.Int);
                    par[0].Value = objVentasSunat.desde;
                    par[1] = new SqlParameter("@Empresa", System.Data.SqlDbType.Int);
                    par[1].Value = objVentasSunat.empresa;
                    par[2] = new SqlParameter("@EstablecimientoID", System.Data.SqlDbType.Int);
                    par[2].Value = objVentasSunat.establecimientoID;
                    par[3] = new SqlParameter("@Hasta", System.Data.SqlDbType.Int);
                    par[3].Value = objVentasSunat.hasta;
                    par[4] = new SqlParameter("@Moneda", System.Data.SqlDbType.Decimal);
                    par[4].Value = objVentasSunat.moneda;
                    par[4].Precision = 18;
                    par[4].Scale = 2;
                    par[5] = new SqlParameter("@MonedaId", System.Data.SqlDbType.Int);
                    par[5].Value = objVentasSunat.monedaId;
                    par[6] = new SqlParameter("@MonedaIDEmision", System.Data.SqlDbType.Int);
                    par[6].Value = objVentasSunat.monedaIDEmision;
                    par[7] = new SqlParameter("@Prepagos", System.Data.SqlDbType.Int);
                    par[7].Value = objVentasSunat.prepagos;
                    par[8] = new SqlParameter("@Produccion", System.Data.SqlDbType.Int);
                    par[8].Value = objVentasSunat.produccion;

                    SqlHelper.ExecuteNonQuery(sqlTran, CommandType.StoredProcedure, PROC_Venta_Sunat, par);
                }
                sqlTran.Commit();
                estado = true;
            }
            catch (Exception e)
            {
                //throw e;
                sqlTran.Rollback();
                estado = false;
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return estado;
        }
    }
}
