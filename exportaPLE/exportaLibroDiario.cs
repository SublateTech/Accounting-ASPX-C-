using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Eventos;
using System.Windows.Forms;

namespace exportaPLE
{
    public class exportaLibroDiario
    {
        private DataTable datos = new DataTable();
        private string _ruc = "";
        private DateTime _fecha;
        private string _moneda = "";
        private cEventos evento = new cEventos();

        public String exporta(string connectionString, string ruc, DateTime fecha, int monedaID, int desde, int hasta, int establecimientoID, string rutaDestino)
        {
            try
            {
                //obtenemos los datos
                _ruc = ruc;
                _fecha = fecha;
                _moneda = monedaID.ToString();
                
                SqlConnection conexion = new SqlConnection(connectionString);
                String query = "UCO_RegistroLibroDiarioSunatElectronico";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = {
                                            new SqlParameter("@Desde",desde),
                                            new SqlParameter("@Hasta",hasta),
                                            new SqlParameter("@EstablecimientoID",establecimientoID)
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
                return "";
            }

        }

        private String generaArchivo(string ruta)
        {
            String msjError="";
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
            nombreArchivo.Append("050100");
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
                if (Directory.Exists(ruta) == false)
                {
                    try
                    {
                        Directory.CreateDirectory(ruta);
                    }
                    catch (Exception ex)
                    {
                         msjError = ex.Message;
                        return msjError;
                    }


                }

                if (File.Exists(ruta + nombreArchivo) == true)
                {
                    File.Delete(ruta + nombreArchivo);
                }

                String RutaCompleta = ruta + nombreArchivo;
                StreamWriter archivo = new StreamWriter(RutaCompleta);

                int correlativo = 0;
                foreach (DataRow fila in datos.Rows)
                {

                    correlativo +=  1;
                    //if (correlativo == 10858)
                    //{

                    //}
                    StringBuilder linea = new StringBuilder();
                    //01 periodo
                    campo = "00000000" + Convert.ToString(fila["Periodo"]);
                    campo = campo.Substring(campo.Length - 8, 8);
                    linea.Append(campo);
                    linea.Append("|");
                    //02 CUO
                    campo = Convert.ToString(fila["NumeroCorrelativo"]);
                    //campo = campo.Substring(campo.Length - 40, 40);
                    linea.Append(campo);
                    linea.Append("|");
                    //03 correlativo del CUO
                    campo = Convert.ToString(fila["correlativoAMC"]);
                    linea.Append(campo);
                    linea.Append("|");
                  

                    //04 codigo de la cuenta contable
                    campo = Convert.ToString(fila["CodigoPlanCuenta"]);
                    //campo = campo.Substring(campo.Length - 24, 24);
                    linea.Append(campo);
                    linea.Append("|");

                    //05 Codigo de la unidad de operacion 
                    campo = Convert.ToString(fila["CodigoUnidad"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //06 Codigo del centro de costos centro de utilidades o centro de inversion 
                    campo = Convert.ToString(fila["CodigoCentroCosto"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //07 tipo moneda de origen ********************************
                    campo = Convert.ToString(fila["TipoMoneda"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //08 tipo documento identidad del emisor
                    campo = Convert.ToString(fila["TipoDocumento"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //09 numero documento identidad del emisor
                    campo = Convert.ToString(fila["NumeroDocumento"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //10 Tipo Comprobante de pago   ****************************************
                    campo = Convert.ToString(fila["TipoComprobante"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //11 Numero serie del comprobante
                    campo = Convert.ToString(fila["Serie"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //12 Numero del comprobante de pago *******************************************
                    campo = Convert.ToString(fila["Numero"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //13 Fecha Contable
                    campo = Convert.ToString(fila["FechaContable"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //14 Fecha Vencimiento
                    campo = Convert.ToString(fila["FechaVencimiento"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //15 Fecha de la operacion o emision
                    campo = Convert.ToString(fila["Dia"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //16 Glosa 
                    campo = Convert.ToString(fila["Glosa"]);
                    
                    linea.Append(campo);
                    linea.Append("|");

                    //17 Glosa referencial
                    campo = Convert.ToString(fila["Referencia"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //18 Movimiento del debe
                    campo = Convert.ToString(fila["MontoDebe"]);
                    linea.Append(campo);
                    linea.Append("|");
                    

                    //19 Movimiento del haber
                    campo = Convert.ToString(fila["MontoHaber"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //20 campo 1, 2 y 3 del registro ventas  e ingresos
                    campo = Convert.ToString(fila["CampoRegistro"]);
                    linea.Append(campo);
                    linea.Append("|");
                    
                    //21 Estado 
                    campo = Convert.ToString(fila["Estado"]);
                    linea.Append(campo);
                    linea.Append("|");


                    archivo.WriteLine(linea);
                    

                   
                }
                archivo.Close();
                return msjError;
            }
            catch (Exception ex)
            {
               // evento.registrar("Contabilidad - SGH - Módulo EScritorio", ex.Message, System.Diagnostics.EventLogEntryType.Error);
            //    msjError = ex.Message;
                return msjError;
            }
        }
    }
}
