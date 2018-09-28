using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic.Compatibility.VB6;
using Eventos;

namespace ExportLAP
{
    public class exportaVentasLAP
    {
        private DataTable datos = new DataTable();
        private string _conces = "";

        private cEventos evento;

        //------------------------------------------------
        //24 campos para lap
        FixedLengthString conCes = new FixedLengthString(4);
        FixedLengthString tipDoc = new FixedLengthString(3);
        FixedLengthString nroDoc = new FixedLengthString(20);
        FixedLengthString fecDoc = new FixedLengthString(16);
        FixedLengthString famProd = new FixedLengthString(5);
        FixedLengthString subfamProd = new FixedLengthString(5);
        FixedLengthString codArt = new FixedLengthString(20);
        FixedLengthString dscArt = new FixedLengthString(40);
        FixedLengthString preUni = new FixedLengthString(10);
        FixedLengthString cant = new FixedLengthString(10);
        FixedLengthString dsctos = new FixedLengthString(10);
        FixedLengthString cargos = new FixedLengthString(10);
        FixedLengthString otros = new FixedLengthString(10);
        FixedLengthString igv = new FixedLengthString(10);
        FixedLengthString total = new FixedLengthString(10);
        FixedLengthString moneda = new FixedLengthString(1);
        FixedLengthString estado = new FixedLengthString(1);
        FixedLengthString tipDocRel = new FixedLengthString(3);
        FixedLengthString nroDocRel = new FixedLengthString(20);
        FixedLengthString adicionales = new FixedLengthString(20);
        FixedLengthString flgAplic = new FixedLengthString(1);
        FixedLengthString dscFamilia = new FixedLengthString(40);
        FixedLengthString dscSubFamilia = new FixedLengthString(40);
        FixedLengthString fechaFiscal = new FixedLengthString(16);
        //------------------------------------------------

        public bool exportar(string connectionString, string ruc, DateTime fechaDesde,  string rutaDestino, string codigoConces, DateTime fechaHasta)
        {
            //generar los datos
            try {
                SqlConnection conexion = new SqlConnection(connectionString);

                String query = "UCO_RegistroVentas_LAP";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = {
                                            new SqlParameter("@conces", codigoConces),
                                                new SqlParameter("@fecha", fechaDesde),
                                                new SqlParameter("@fechaHasta", fechaHasta)
                                            //parametros del procedimiento
                                        };

                comando.Parameters.AddRange(parametros);
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                datos.Load(lector);

                //ya tenemos los datos,  hay que convertirlo en txt
                _conces = codigoConces;
                return generaArchivo(rutaDestino, fechaDesde);
            
            }
            catch { return false; }
        }

        private bool generaArchivo(string ruta, DateTime fechaDesde)
        {
            //generar el nombre segun  el siguiente formato
            // LERRRRRRRRRRRAAAAMM0014010000OIM1.TXT
            // LE-RRRRRRRRRRR-AAAA-MM-00-140100-00-O-I-M-1.TXT


            //NOMBRE ORIGINAL 11032013 - formato> lap_pos_ventas_0088
            //empieza
            //StringBuilder nombreArchivo = new StringBuilder("lap_pos_ventas_"); 
            //termina


            //NOMBRE NUEVO 11032013 - formato> 0088130305VENTAS.txt
            //empieza
            DateTime hoy;
            int anio, mes, dia;
            string formatocadena;
            string mesCompleto = "", diaCompleto = "";
            //hoy = DateTime.Now;
            hoy = fechaDesde;
            anio = hoy.Year;
            mes = hoy.Month;
            dia = hoy.Day;
            if (Convert.ToString(mes).Length == 1)
            {
                mesCompleto = "0" + Convert.ToString(mes);
            }
            if (Convert.ToString(mes).Length == 2)
            {
                mesCompleto = Convert.ToString(mes);
            }

            if (Convert.ToString(dia).Length == 1)
            {
                diaCompleto = "0" + Convert.ToString(dia);
            }
            if (Convert.ToString(dia).Length == 2)
            {
                diaCompleto = Convert.ToString(dia);
            }

            string concesio = "";
            concesio = _conces;

            formatocadena = concesio + Convert.ToString(anio).Substring(2, 2) + mesCompleto + diaCompleto + "VENTAS";
            StringBuilder nombreArchivo = new StringBuilder(formatocadena);
            //termina
            //SE COMENTA LA LINEA DE ABAJO, ES ORIGINAL
            //nombreArchivo.Append(_conces);
            nombreArchivo.Append(".txt");
            //String campo = "";

            if (File.Exists(ruta + nombreArchivo) == true)
            {
                File.Delete(ruta + nombreArchivo);
            }
            //Encoding codifica = Encoding.Default;
            Encoding codifica = Encoding.GetEncoding(1252);
            StreamWriter archivo = new StreamWriter(ruta + nombreArchivo, false, codifica);

            try
            {
               
                int correlativo = 0;

                foreach (DataRow fila in datos.Rows)
                {
                    correlativo = correlativo + 1;
                    StringBuilder linea = new StringBuilder();
                   
                    //conces
                    conCes.Value = Convert.ToString(fila["Conces"]);
                    linea.Append(conCes.ToString());
                    //tipDoc
                    tipDoc.Value = Convert.ToString(fila["TipDoc"]);
                    linea.Append(tipDoc.ToString());
                    //NroDoc
                    nroDoc.Value = Convert.ToString(fila["NroDoc"]);
                    linea.Append(nroDoc.ToString());
                    //FecDoc
                    fecDoc.Value = Convert.ToString(fila["FecDoc"]);
                    linea.Append(fecDoc.ToString());
                    //FamProd
                    famProd.Value = Convert.ToString(fila["FamProd"]);
                    linea.Append(famProd.ToString());
                    //SubFamProd
                    subfamProd.Value = Convert.ToString(fila["SubFamProd"]);
                    linea.Append(subfamProd.ToString());
                    //CodArt
                    codArt.Value = Convert.ToString(fila["CodArt"]);
                    linea.Append(codArt.ToString());
                    //DscArt
                    dscArt.Value = Convert.ToString(fila["DscArt"]);
                    linea.Append(dscArt.ToString());
                    //PreUni
                    preUni.Value = Convert.ToString(fila["PreUni"]);
                    linea.Append(preUni.ToString());
                    //Cant
                    cant.Value = Convert.ToString(fila["Cant"]);
                    linea.Append(cant.ToString());
                    //Dsctos
                    dsctos.Value = Convert.ToString(fila["Dsctos"]);
                    linea.Append(dsctos.ToString());
                    //conces
                    cargos.Value = Convert.ToString(fila["Cargos"]);
                    linea.Append(cargos.ToString());
                    //Otros
                    otros.Value = Convert.ToString(fila["Otros"]);
                    linea.Append(otros.ToString());
                    //Igv
                    igv.Value = Convert.ToString(fila["Igv"]);
                    linea.Append(igv.ToString());
                    //Total
                    total.Value = Convert.ToString(fila["Total"]);
                    linea.Append(total.ToString());
                    //Moneda
                    moneda.Value = Convert.ToString(fila["Moneda"]);
                    linea.Append(moneda.ToString());
                    //Estado
                    estado.Value = Convert.ToString(fila["Estado"]);
                    linea.Append(estado.ToString());
                    //TipDocRel
                    tipDocRel.Value = Convert.ToString(fila["TipDocRel"]);
                    linea.Append(tipDocRel.ToString());
                    //NroDocRel
                    nroDocRel.Value = Convert.ToString(fila["NroDocRel"]);
                    linea.Append(nroDocRel.ToString());
                    //Adicionales
                    adicionales.Value = Convert.ToString(fila["Adicionales"]);
                    linea.Append(adicionales.ToString());
                    //FlgAplic
                    flgAplic.Value = Convert.ToString(fila["FlgAplic"]);
                    linea.Append(flgAplic.ToString());
                    //DscFamilia
                    dscFamilia.Value = Convert.ToString(fila["DscFam"]);
                    linea.Append(dscFamilia.ToString());
                    //DscSubFamilia
                    dscSubFamilia.Value = Convert.ToString(fila["DscSubFam"]);
                    linea.Append(dscSubFamilia.ToString());
                    //FechaFiscal
                    fechaFiscal.Value = Convert.ToString(fila["FechaFiscal"]);
                    linea.Append(fechaFiscal.ToString());

                    //linea.Append(".txt");
                    //agregar al archivo
                    archivo.WriteLine(linea);
                }
                archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                cEventos evento = new cEventos();
                evento.registrar("Exporta a LAP", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                archivo.Close();
                return false;
            }
        }

    }
}
