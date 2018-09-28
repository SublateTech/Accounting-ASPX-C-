using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Eventos;

namespace exportaPLE
{
    public class exportaLibroDiario2
    {
        private DataTable datos = new DataTable();
        private string _ruc = "";
        private DateTime _fecha;
        private string _moneda = "";
        private cEventos evento = new cEventos();

        public Boolean exporta(string connectionString, string ruc, DateTime fecha, int monedaID, int desde, int hasta, int establecimientoID, string rutaDestino)
        {
            try
            {
                //obtenemos los datos
                _ruc = ruc;
                _fecha = fecha;
                _moneda = monedaID.ToString();

                SqlConnection conexion = new SqlConnection(connectionString);
                String query = "UCO_RegistroLibroDiario2SunatElectronico";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = {
                                            new SqlParameter("@Desde",desde),
                                            new SqlParameter("@Hasta",hasta),
                                            new SqlParameter("@EstablecimientoId",establecimientoID)
                                        };
                comando.Parameters.AddRange(parametros);
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();
                datos.Load(lector);
                return generaArchivo(rutaDestino);
            }
            catch (Exception ex)
            {
                evento.registrar("Contabilidad - SGH - Módulo EScritorio", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

        }

        private bool generaArchivo(string ruta)
        {
            //generar el nombre segun  el siguiente formato
            // LERRRRRRRRRRRAAAAMM0014010000OIM1.TXT
            // LE-RUC-AAAA-MM-00-140100-00-O-I-M-1.TXT
            StringBuilder nombreArchivo = new StringBuilder("LE");
            //ruc de la empresa
            nombreArchivo.Append(_ruc);
            //año
            nombreArchivo.Append(_fecha.Year.ToString());
            //mes
            string mes = "00" + _fecha.Month.ToString();

            mes = mes.Substring(mes.Length - 2, 2);

            nombreArchivo.Append(mes);
            //campo dia solo se aplica a inventarios y balances
            nombreArchivo.Append("00");
            //identificador del libro 14 es registro de ventas
            nombreArchivo.Append("050300");
            //codigo de oportunidad
            nombreArchivo.Append("00");
            //indicador de operaciones
            nombreArchivo.Append("1");
            //indicador del contenido
            nombreArchivo.Append("1");
            //indicador de la moneda utilizada
            nombreArchivo.Append(_moneda);
            //indicador fijo 1
            nombreArchivo.Append("1");
            //extension del archivo
            nombreArchivo.Append(".txt");
            String campo = "";
            try
            {
                if (File.Exists(ruta + nombreArchivo) == true)
                {
                    File.Delete(ruta + nombreArchivo);
                }
                StreamWriter archivo = new StreamWriter(ruta + nombreArchivo);

                int correlativo = 0;
                foreach (DataRow fila in datos.Rows)
                {
                    correlativo = correlativo + 1;
                    StringBuilder linea = new StringBuilder();
                    //01 periodo
                    campo = "00000000" + Convert.ToString(fila["Periodo"]);
                    campo = campo.Substring(campo.Length - 8, 8);
                    linea.Append(campo);
                    linea.Append("|");
                    //02 Codigo de la cuenta contable 
                    campo = Convert.ToString(fila["CodigoPlanCuenta"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //03 NombrePlanCuenta
                    campo = Convert.ToString(fila["NombrePlanCuenta"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //04 codigo de plan de cuentas 
                    campo = Convert.ToString(fila["CodigoCuenta"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //05 descripcion de pland de cuentas 
                    campo = Convert.ToString(fila["DescrCuenta"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //06 codigo de la cuenta contable corporativa   NO OBLIGATORIO
                    campo = Convert.ToString(fila["CodigoCuentaCorporativa"]);
                    linea.Append("");
                    linea.Append("|");

                    //07 descripcipn de la cuenta contable corporativa  NO OBLIGATORIO
                    campo = Convert.ToString(fila["DescrCuentaCorporativa"]);
                    linea.Append("");
                    linea.Append("|");
                    //08 estado
                    campo = Convert.ToString(fila["Estado"]);
                    linea.Append(campo);
                    linea.Append("|");

                   
                    
                    //agregar al archivo
                    archivo.WriteLine(linea);
                }
                archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                evento.registrar("Contabilidad - SGH - Módulo EScritorio", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }
    }
}
