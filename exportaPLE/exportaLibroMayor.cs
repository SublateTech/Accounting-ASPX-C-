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
    public class exportaLibroMayor
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
                String query = "UCO_RegistroLibroMayorSunatElectronico";
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
                return false;
            }

        }
        //LIBRO MAYOR
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
            nombreArchivo.Append("060100");
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

                    //02 CUO
                    campo =Convert.ToString(fila["NumeroCorrelativo"]);
                    //campo = campo.Substring(campo.Length - 40, 40);
                    linea.Append(campo);
                    linea.Append("|");

                    //03 #Correlativo del asiento contable
                    campo = Convert.ToString(fila["correlativoAMC"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //04 Codigo de la cuenta contable 
                    campo = Convert.ToString(fila["CodigoPlanCuenta"]);
                    //campo = campo.Substring(campo.Length - 24, 24);
                    linea.Append(campo);
                    linea.Append("|");                    

                    //05 Codigo de la unidad de operacion 
                    campo = Convert.ToString(fila["CodigoUnidad"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //06 Codigo del centro de costos 
                    campo = Convert.ToString(fila["CodigoCentroCosto"]);
                    linea.Append(campo);
                    linea.Append("|");
                    
                    //07 Tipo Moneda origen
                    campo = Convert.ToString(fila["TipoMoneda"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //08  tipo de documento de identidad del emisor
                    campo = Convert.ToString(fila["TipoDocumento"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    
                    //09 numero de documento de identidad del emisor
                    campo = Convert.ToString(fila["NumeroDocumento"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    
                    //10 Tipo de Comprobante de Pago o Documento asociada a la operación
                    campo = Convert.ToString(fila["TipoComprobante"]);
                    linea.Append("00");
                    linea.Append("|");

                    //11 Número de serie del comprobante de pago o documento asociada a la operación
                    campo = Convert.ToString(fila["Serie"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //12 Número del comprobante de pago o documento asociada a la operación
                    campo = Convert.ToString(fila["Numero"]).Trim();
                    linea.Append("01");
                    linea.Append("|");

                    //13 Fecha Contable
                    campo = Convert.ToString(fila["FechaContable"]);
                    linea.Append(campo);
                    linea.Append("|");
                    
                    //14 Fecha de Vencimiento
                    campo = Convert.ToString(fila["FechaVencimiento"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //15 Fecha de la operacion o emision 
                    campo = Convert.ToString(fila["Dia"]);
                    campo = campo.Substring(campo.Length - 10, 10);
                    linea.Append(campo);
                    linea.Append("|");

                    //16 Glosa o descripción de la naturaleza de la operación registrada, de ser el caso. 
                    campo = Convert.ToString(fila["Glosa"]);
                    campo = campo.Trim();
                    if (campo.Length >= 100)
                    {
                        campo = campo.Substring(0, 98);
                    }
                    linea.Append(campo);
                    linea.Append("|");

                    //17 Glosa Referencial
                    campo = Convert.ToString(fila["Referencia"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //18 Movimiento del Debe
                    campo = Convert.ToString(fila["Debe"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //19 Movimiento del Haber
                    campo = Convert.ToString(fila["Haber"]);
                    linea.Append(campo);
                    linea.Append("|");

                    //20 Dato estructurado , codigo del libro campo 1, 2 y 3 del registro de ventas e ingresos
                    campo = Convert.ToString(fila["CampoRegistro"]);
                    linea.Append(campo);
                    linea.Append("|");
                   
                    //21 Estado 
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
