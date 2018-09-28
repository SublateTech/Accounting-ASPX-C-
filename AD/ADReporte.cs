using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace AD
{
    public class ADReporte
    {
        private const string PROC_LISTAR_CONFIG_REPORTE = "ssoc_ReporteConfig";
        private const string PROC_LISTAR_CONFIG_REPORTE_COLUMNA = "ssoc_ReporteConfigColumna";

        private const string PROC_REPORTE_FLUJO_INGRESOS = "ssoc_ReporteIngresosFlujo";

        public DataTable datosConfigRep001(String codigoReporte)
        {

            SqlParameter[] parametros = { new SqlParameter("@Reporte", codigoReporte) };

            return SqlHelper.ExecuteDataset(conexion.connectionString(), PROC_LISTAR_CONFIG_REPORTE, parametros).Tables[0];

        
        }

        public bool AsignaProductoIdColumna(String codigoReporte, Int32 Columna, Int32 ProductoId, String Etiqueta)
        {

            SqlParameter[] parametros = { 

                                            new SqlParameter("@Reporte", codigoReporte),
                                            new SqlParameter("@Columna", Columna),
                                            new SqlParameter("@ProductoId", ProductoId),
                                            new SqlParameter("@Etiqueta", Etiqueta),

                                        };


            try
            {
                SqlHelper.ExecuteNonQuery(conexion.connectionString(), PROC_LISTAR_CONFIG_REPORTE_COLUMNA, parametros);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public DataSet reporteFlujoIngresos(DateTime desde, DateTime hasta, Int32 usarFechaFacturacion, Int32 usarTipoCambioCuentaCorriente)
        {

            string query = PROC_REPORTE_FLUJO_INGRESOS;

            SqlCommand comando = new SqlCommand(query);

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandTimeout = 3600;

            comando.Parameters.AddWithValue("@desde", desde);

            comando.Parameters.AddWithValue("@hasta", hasta);

            comando.Parameters.AddWithValue("@UsarFechaFacturacion", usarFechaFacturacion);

            comando.Parameters.AddWithValue("@UsarTipoCambioCuentaCorriente", usarTipoCambioCuentaCorriente);

            SqlConnection conexion = new SqlConnection(Connection.connectionString());

            comando.Connection = conexion;

            DataSet ds = new DataSet();

            conexion.Open();

             //SqlDataReader lector = comando.ExecuteReader();

            //DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = comando;

            try
            {
                da.Fill(ds);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ds;
        }
    }
}
