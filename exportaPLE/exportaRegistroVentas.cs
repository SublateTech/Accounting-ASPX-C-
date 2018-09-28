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
    public class exportaRegistroVentas
    {

        private DataTable datos = new DataTable();
        private string _ruc = "";
        private DateTime _fecha;
        private string _moneda = "";
        private cEventos evento=new cEventos();

        public Boolean exporta(string connectionString, string ruc, DateTime fecha, int monedaID, int desde, int hasta, int establecimientoID, int monedaIDEmision, int produccion, int prepagos, string rutaDestino)
        {

            try
            {
                //obtenemos los datos

                _ruc = ruc;

                _fecha = fecha;

                _moneda = monedaID.ToString();

                SqlConnection conexion = new SqlConnection(connectionString);

                String query = "UCO_RegistroDeVentasSunatElectronico";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = {
                                            new SqlParameter("@monedaID",monedaID),
                                            new SqlParameter("@Desde",desde),
                                            new SqlParameter("@Hasta",hasta),
                                            new SqlParameter("@EstablecimientoID",establecimientoID),
                                            new SqlParameter("@MonedaIDEmision",monedaIDEmision),
                                            new SqlParameter("@Produccion",produccion),
                                            new SqlParameter("@Prepagos",prepagos),
                                        };

                comando.Parameters.AddRange(parametros);
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                datos.Load(lector);

                //ya tenemos los datos,  hay que convertirlo en txt
                return generaArchivo(rutaDestino);
            }
            catch(Exception ex)
            {
                

                evento.registrar("Contabilidad - SGH - Módulo EScritorio", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            
        }

        private bool generaArchivo(string ruta)
        {
            //generar el nombre segun  el siguiente formato
            // LERRRRRRRRRRRAAAAMM0014010000OIM1.TXT
            // LE-RRRRRRRRRRR-AAAA-MM-00-140100-00-O-I-M-1.TXT

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
            nombreArchivo.Append("140100");
            //codigo de oportunidad
            nombreArchivo.Append("00");
            //indicador de operaciones
            nombreArchivo.Append("1");
            //indicador del contenido
            if (datos.Rows.Count == 0)
            {
                nombreArchivo.Append("0");
            }
            else
            {
                nombreArchivo.Append("1");
            }
           // nombreArchivo.Append("1");
            //indicador de la moneda utilizada
            nombreArchivo.Append(_moneda);
            //indicador fijo 1
            nombreArchivo.Append("1");
            //extension del archivo
            nombreArchivo.Append(".txt");
            String campo = "";
            try
            {
                if (File.Exists(ruta + nombreArchivo)==true)
                {
                    File.Delete(ruta + nombreArchivo);
                }
                StreamWriter archivo = new StreamWriter(ruta + nombreArchivo);
                
                int correlativo = 0;
                foreach(DataRow fila in datos.Rows)
                {
                    correlativo = correlativo + 1;
                    StringBuilder linea = new StringBuilder();
                    //01 periodo
                    campo = "00000000" + Convert.ToString(fila["Periodo"]).Trim();
                    campo=campo.Substring(campo.Length-8,8);
                    linea.Append(campo);
                    linea.Append("|");
                    //02 codigo unico de operacion(CUO)
                    //campo = "0000000000000000000000000000000000000000" + correlativo.ToString();
                    //campo = campo.Substring(campo.Length - 40, 40);
                    //linea.Append(campo);
                    //linea.Append("|");
                    campo = Convert.ToString(fila["COUcampo"]).Trim();
                    //campo = campo.Substring(campo.Length - 40, 40);
                    linea.Append(campo);
                    linea.Append("|");
                    //03 Correlativo
                    campo = "0000000000" + correlativo.ToString();
                    campo = campo.Substring(campo.Length - 9, 9);
                    campo = "M" + campo;
                    linea.Append(campo);
                    linea.Append("|");
                    //04 Fecha de Emision
                    campo = Convert.ToString(fila["FechaEmision"]).Trim();
                    campo = campo.Substring(campo.Length - 10, 10);
                    linea.Append(campo);
                    linea.Append("|");
                    //05 fecha de vencimiento
                    campo = Convert.ToString(fila["FechaVencimiento"]).Trim();
                    
                    //campo = campo.Substring(campo.Length - 10, 10);
                    linea.Append(campo);
                    linea.Append("|");
                    //06 tipo de comprobante
                    campo = Convert.ToString(fila["Tipo"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //07 serie de comprobante
                    campo = Convert.ToString(fila["Serie"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //08 numero de comprobante
                    campo = Convert.ToString(fila["Numero"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //09 campo 8 numero final
                    campo = Convert.ToString(fila["Campo8"]).Trim();
                    linea.Append("");
                    linea.Append("|");
                    //10 tipo documento identidad
                    campo = Convert.ToString(fila["TipoDocumento"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //11 numero de documento identidad
                    campo = Convert.ToString(fila["NumeroDocumentoIdentidad"]).Trim();
                    linea.Append(campo.Trim());
                    linea.Append("|");
                    //12 razon social 
                    campo = Convert.ToString(fila["NombreEmpresa"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //13 valor facturado de la exportCION 
                    campo = Convert.ToString(fila["Exportaciones"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //14 base imponible
                    campo = Convert.ToString(fila["BaseImponible"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //15 descuento de la base imponible   --10/02/2016
                    //linea.Append("0");
                    campo = Convert.ToString(fila["Descuento"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");


                    //16 IGV
                    campo = Convert.ToString(fila["IGV"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //17 DESCUENTO DEL IGV          --10/02/2016
                    //linea.Append("0");
                    campo = Convert.ToString(fila["DescuentoIGV"]).Trim();   
                    linea.Append(campo);
                    linea.Append("|");

                    //18  IMPORTE TOTAL DE LA EXPORTACION EXONERADA
                    campo = Convert.ToString(fila["BaseExonerada"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //19 IMPORTE  TOTAL DE LA OPERACION INAFECTA
                    //campo = "0";
                    campo = Convert.ToString(fila["ImporteTotal_OperacionInafecta"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //20   ISC
                    campo = Convert.ToString(fila["ISC"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //21 BI DE LA OPERACION GRAVADA CON IMPUESTO A LA VENTAS DEL ARROZ PILADO
                    campo = Convert.ToString(fila["BaseImponible_IVAP"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //22 IMPUESTO A LAS VENTAS DEL ARROZ PILADO
                    campo = Convert.ToString(fila["IVAP"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //23  OTROS CONCEPTOS , TRIBUTOS Y CARGOS 
                    campo = Convert.ToString(fila["Otros"]).Trim();
                    //campo = Convert.ToString(1);
                    linea.Append(campo);
                    linea.Append("|");
                    //24  IMPORTE TOTAL COMPROBANTE PAGO
                    campo = Convert.ToString(fila["Total"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //25  MONEDA                            --10/02/2016
                    campo = fila["CodigoMoneda"].ToString().Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //26 TIPO DE CAMBIO 
                    campo = Convert.ToString(fila["TipoCambio"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //27  FECHA DE EMISION 
                    campo = Convert.ToString(fila["FechaEmisionDocumentoNota"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //28 TIPO
                    campo = Convert.ToString(fila["TipoNC"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //29  SERIE
                    campo = Convert.ToString(fila["SerieNC"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //30 NUMERO 
                    campo = Convert.ToString(fila["NumeroNC"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //31 CONTRATO                            --10/02/2016
                    campo = fila["Contrato"].ToString().Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //32 ERROR TIPO                             --10/02/2016
                    campo = fila["ErrorTipoCambio"].ToString().Trim();
                    linea.Append(campo);
                    linea.Append("|");

                    //FOB 33 INDICADOR DE MEDIO DE PAGO                           --10/02/2016
                    //campo = Convert.ToString(fila["FOB"]);
                    //linea.Append(campo);
                    //linea.Append("|");
                    campo = fila["IndicadorPago"].ToString().Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //34 ESTADO
                    campo = Convert.ToString(fila["Estado"]).Trim();
                    linea.Append(campo);
                    linea.Append("|");
                    //agregar al archivo
                    archivo.WriteLine(linea);
                }
                archivo.Close();
                return true;
            }
            catch(Exception ex)
            {
                evento.registrar("Contabilidad - SGH - Módulo EScritorio",ex.Message,System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
        }

    }
}
