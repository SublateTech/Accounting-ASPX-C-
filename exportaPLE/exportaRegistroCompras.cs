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
    public class exportaRegistroCompras
    {

        private DataTable datos = new DataTable();
        private string _ruc = "";
        private DateTime _fecha;
        private string _moneda = "";
        private cEventos evento = new cEventos();

        public Boolean exporta(string connectionString, string ruc, DateTime fecha, int monedaID, int desde, int hasta, int establecimientoID, string rutaDestino,int format)
        {

            try
            {
                //obtenemos los datos

                _ruc = ruc;

                _fecha = fecha;

                _moneda = monedaID.ToString();

                SqlConnection conexion = new SqlConnection(connectionString);

                String query = "UCO_RegistroDeComprasSunatElectronico";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = {
                                            new SqlParameter("@monedaID",monedaID),
                                            new SqlParameter("@Desde",desde),
                                            new SqlParameter("@Hasta",hasta),
                                            new SqlParameter("@EstablecimientoID",establecimientoID),
                                            new SqlParameter("@Formato82", format)
                                        };

                comando.Parameters.AddRange(parametros);
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                datos.Load(lector);

                //ya tenemos los datos,  hay que convertirlo en txt
               //if (format == 81) { return generaArchivo81(rutaDestino); } else if (format == 82) { return generaArchivo82(rutaDestino); }
                return generaArchivo(rutaDestino,format);
            }
            catch (Exception ex)
            {
                evento.registrar("Contabilidad - SGH - Módulo EScritorio", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                return false;
            }

        }

        private bool generaArchivo(string ruta,int format)
        {
            if (format == 0)
            {
                // Registro de Compras 8.1

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
                //identificador del libro 14 es registro de compras
                nombreArchivo.Append("080100");
                //codigo de oportunidad
                nombreArchivo.Append("00");
                //indicador de operaciones O
                nombreArchivo.Append("1");
                //indicador del contenido  I
                if (datos.Rows.Count == 0) { 
                    nombreArchivo.Append("0"); 
                } else { 
                    nombreArchivo.Append("1"); 
                }
                
                //indicador de la moneda utilizada  M
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
                        //02 codigo unico operacion (CUO)
                        //campo = "0000000000000000000000000000000000000000" + correlativo.ToString();
                        //07/06/2013    "0000000000000000000000000000000000000000" +
                        campo =  Convert.ToString(fila["Correlativo"]);
                        //campo = campo.Substring(campo.Length - 40, 40);
                        linea.Append(campo);
                        linea.Append("|");
                        //03 correlativoAsientoContable (CUO)
                        //campo = "000000000000000000000000000000000000000" + Convert.ToString(fila["Correlativo"]);
                        //campo = "000000000000000000000000000000000000000" + correlativo.ToString();
                        //campo = campo.Substring(campo.Length - 9, 9);
                        //campo = "M" + campo;
                        campo = Convert.ToString(fila["correlativoAsientoContable"]);
                        linea.Append(campo);
                        linea.Append("|");
                        //04 fecha de emision
                        campo = Convert.ToString(fila["Fecha"]).Trim() ;
                        campo = campo.Substring(campo.Length - 10, 10);
                        linea.Append(campo);
                        linea.Append("|");
                        //05 fecha de vencimiento
                        campo = Convert.ToString(fila["FechaVencimiento"]).Trim();
                        if (campo.Length >= 10)
                        {
                            campo = campo.Substring(campo.Length - 10, 10);
                        }
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
                        //08 AÑO DE EMISION fecha de DUA
                        campo = Convert.ToString(fila["Campo07"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //09 campo 9 NUMERO INICIAL 
                        campo = Convert.ToString(fila["Numero"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //10 NUMERO FINAL
                        campo = Convert.ToString(fila["Campo09"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //11 TIPO DOCUMENTO O IDENTIDAD
                        campo = Convert.ToString(fila["TipoDocumentoIdProveedor"]).Trim();
                        linea.Append(campo.Trim());
                        linea.Append("|");
                        //12 NUMERO 
                        campo = Convert.ToString(fila["Ruc"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //13 RAZON SOCIAL 
                        campo = Convert.ToString(fila["NombreEmpresa"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //14 base imponible
                        campo = Convert.ToString(fila["BaseImponibleB"]).Trim();
                        //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                        linea.Append(campo);
                        linea.Append("|");
                        //15 IGV
                        campo = Convert.ToString(fila["IGVB"]).Trim();

                        //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                        linea.Append(campo);
                        linea.Append("|");
                        //16  BASE IMPONIBLE 
                        campo = Convert.ToString(fila["Campo15"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //17  IGV
                        campo = Convert.ToString(fila["Campo16"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //18 BASE IMPONIBLE 
                        campo = Convert.ToString(fila["Campo17"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //19  IGV
                        campo = Convert.ToString(fila["Campo18"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //20  BI  ADQUISICIONES GRAVADAS INTERNAS 
                        campo = Convert.ToString(fila["Campo19"]).Trim();
                        decimal monto = 0;
                        monto = Convert.ToDecimal(campo);
                        string[] arreglo = { "07", "87", "97", "14" };
                        if (monto >= 0)
                        {
                            //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                            campo = Convert.ToString(campo);
                        }
                        else
                        {
                            if (arreglo.Contains(Convert.ToString(fila["Tipo"]).Trim()))
                            {
                                //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                                campo = Convert.ToString(campo);
                            }
                            else
                            {
                                campo = "0.00";
                            }
                        }
                        linea.Append(campo);
                        linea.Append("|");
                        //21  ISC 
                        campo = Convert.ToString(fila["ISC"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //22  OTROS 
                        campo = Convert.ToString(fila["Otros"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //23 IMPORTE TOTAL 
                        campo = Convert.ToString(fila["Total"]).Trim();
                        //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                        linea.Append(campo);
                        linea.Append("|");
                        //24  CODIGO MONEDA        ----10/02/2016

                        campo = fila["CodigoMoneda"].ToString().Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        // 25 tipo cambio

                        campo = Convert.ToString(fila["TipoCambio"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //26  fecha emision 
                        campo = Convert.ToString(fila["Campo24"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //27 tipo 
                        campo = Convert.ToString(fila["Campo25"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //28 serie 
                        campo = Convert.ToString(fila["Campo26"]).Trim(); //numero de serie
                        linea.Append(campo);
                        linea.Append("|");
                        //29 codigo dua 
                        campo = ""; // Obligatorio si campo 26 = '50' , '52'. 
                        linea.Append(campo);
                        linea.Append("|");
                        //30 numero 
                        campo = Convert.ToString(fila["Campo27"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //31 fecha emisiond e la detraccion 
                        campo = Convert.ToString(fila["Campo29"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //32 numero de constancia de d etarccion 
                        campo = Convert.ToString(fila["Campo30"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //33 marca de comprobante 
                        campo = Convert.ToString(fila["Campo31"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //34 codigo clasificacion
                        campo = Convert.ToString(fila["CodigoClasificacion"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //35 contrato
                        campo = Convert.ToString(fila["Contrato"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //36 error tipo 1
                        campo = Convert.ToString(fila["ErrorTipo1"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //37 error tipo 2
                        campo = Convert.ToString(fila["ErrorTipo2"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //38 error tipo 3
                        campo = Convert.ToString(fila["ErrorTipo3"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //39 error tipo 4
                        campo = Convert.ToString(fila["ErrorTipo4"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //40 indicador pago                  
                        campo = Convert.ToString(fila["IndicadorPago"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        // 41 Estado 
                        campo = Convert.ToString(fila["Estado"]).Trim();
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
            else
            {

                ////////            Registro de Compras  8.2////////////////////////////////////////////////////


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
                nombreArchivo.Append("080200");
                //codigo de oportunidad
                nombreArchivo.Append("00");
                //indicador de operaciones
                nombreArchivo.Append("1");
                //indicador del contenido
                if (datos.Rows.Count == 0) { nombreArchivo.Append("0"); } else { nombreArchivo.Append("1"); }
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
                        campo = "00000000" + Convert.ToString(fila["Periodo"]).Trim();
                        campo = campo.Substring(campo.Length - 8, 8);
                        linea.Append(campo);
                        linea.Append("|");
                        //02 codigo unico operacion (CUO)
                        //campo = "0000000000000000000000000000000000000000" + correlativo.ToString();
                        //07/06/2013
                        campo = "0000000000000000000000000000000000000000" + Convert.ToString(fila["Correlativo"]).Trim();
                        campo = campo.Substring(campo.Length - 40, 40);
                        linea.Append(campo);
                        linea.Append("|");
                        //03 correlativoAsientoContable (CUO)
                        //campo = "000000000000000000000000000000000000000" + Convert.ToString(fila["Correlativo"]);
                        //campo = "000000000000000000000000000000000000000" + correlativo.ToString();
                        //campo = campo.Substring(campo.Length - 9, 9);
                        //campo = "M" + campo;
                        campo = Convert.ToString(fila["correlativoAsientoContable"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //04 fecha de emision
                        campo = Convert.ToString(fila["Fecha"]).Trim();
                        campo = campo.Substring(campo.Length - 10, 10);
                        linea.Append(campo);
                        linea.Append("|");
 
                        //05 tipo de comprobante
                        campo = Convert.ToString(fila["Tipo"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //06 serie de comprobante
                        campo = Convert.ToString(fila["Serie"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //07 campo  NUMERO 
                        campo = Convert.ToString(fila["Numero"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //08 base imbonible
                        campo = Convert.ToString(fila["BaseImponibleB"]).Trim();

                        //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                        linea.Append(campo);
                        linea.Append("|");

                        //09  otros
                        campo = Convert.ToString(fila["Otros"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //10 importe total 
                        campo = Convert.ToString(fila["Total"]).Trim();
                        //campo = String.Format("{0:0.00}", Convert.ToDecimal(campo));
                        linea.Append(campo);
                        linea.Append("|");
                        //11  tipo sustento 
                        campo = Convert.ToString(fila["TipoSustento"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //12  serie no domicialiado
                        campo = Convert.ToString(fila["SerieNoDomiciliado"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //13  periodo DUA
                        campo = Convert.ToString(fila["PeriodoDua"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //14  InvoiceNoDomiciliado 
                        campo = Convert.ToString(fila["InvoiceNoDomiciliado"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //15  Retencion IGV
                        campo = (Convert.ToString(fila["RetencionIGV"])).Trim();
                        if (campo == "0") {campo=""; }
                        linea.Append(campo);
                        linea.Append("|");
                        //16  Codigo Moneda  
                        campo = Convert.ToString(fila["CodigoMoneda"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //17  Tipo Cambio
                        campo = Convert.ToString(fila["TipoCambio"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //18 Pais Recidencia
                        campo = Convert.ToString(fila["Pais"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //19 Nombre Empresa
                        campo = Convert.ToString(fila["NombreEmpresa"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //20 Direccion
                        campo = Convert.ToString(fila["Direccion"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //21 Identificacion
                        campo = Convert.ToString(fila["Identificacion"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //22 num identificacion fiscal del beneficiario efectivo de los pagos 
                        campo = Convert.ToString(fila["NumBeneficiario"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //23 razon social  del beneficiario
                        campo = Convert.ToString(fila["RSBeneficiario"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //24 pais del beneficiario
                        campo = Convert.ToString(fila["Pais"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //25 vinculo entre el contribuyente y el residente 
                        campo = Convert.ToString(fila["Vinculo"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //26 Renta Bruta
                        campo = Convert.ToString(fila["RentaBruta"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //27 Deduccion /costo de enajenacion de bienes de capital 
                        campo = Convert.ToString(fila["DeduccionCosto"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //28 Renta Neta
                        campo = Convert.ToString(fila["RentaNeta"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //29 Tasa de Retencion 
                        campo = Convert.ToString(fila["TasaRetencion"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //30 Impuesto Retenido 
                        campo = Convert.ToString(fila["ImpRetenido"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //31 convenio para evitar la doble imposicion aplicable
                        campo = Convert.ToString(fila["CodigoDobleTributacion"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        
                        //32 Exoneracion Aplicada 
                        campo = Convert.ToString(fila["ExoneracionAplicada"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //33 Tipo de Renta

                        campo = Convert.ToString(fila["CodigoTipoRenta"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");

                        //34 Modalidad del servicio prestado por el nro domiciliado
                        campo = Convert.ToString(fila["Modalidad"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //35 aplicacion de penultimo parrafo
                        campo = Convert.ToString(fila["Aplicacion"]).Trim();
                        linea.Append(campo);
                        linea.Append("|");
                        //36 Estado
                        campo = Convert.ToString(fila["Estado"]).Trim();
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
}
