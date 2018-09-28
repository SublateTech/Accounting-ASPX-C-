using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic.Compatibility.VB6;
using Eventos;
using Excel = Microsoft.Office.Interop.Excel;


namespace exportaContaSis
{

    public class RowProcessedEventArgs : EventArgs
    {
        public int numero { get; set; }
        public int total { get; set; }
    }

    public class exportaVentasContaSis
    {
        private DataTable datos = new DataTable();

        private string _conces = "";

        private cEventos evento;

        public event EventHandler filaprocesada;

        private Boolean cancelaProceso = false;

        /**
         * 39 Campos para ContaSis
         * 
         * ***/
        FixedLengthString campo01 = new FixedLengthString(10);
        FixedLengthString campo02 = new FixedLengthString(10);
        FixedLengthString campo03 = new FixedLengthString(2);
        FixedLengthString campo04 = new FixedLengthString(6);
        FixedLengthString campo05 = new FixedLengthString(13);
        FixedLengthString campo06 = new FixedLengthString(2);
        FixedLengthString campo07 = new FixedLengthString(11);
        FixedLengthString campo08 = new FixedLengthString(60);
        FixedLengthString campo09 = new FixedLengthString(18);
        FixedLengthString campo10 = new FixedLengthString(18);

        FixedLengthString campo11 = new FixedLengthString(18);
        FixedLengthString campo12 = new FixedLengthString(18);
        FixedLengthString campo13 = new FixedLengthString(18);
        FixedLengthString campo14 = new FixedLengthString(18);
        FixedLengthString campo15 = new FixedLengthString(18);
        FixedLengthString campo16 = new FixedLengthString(18);
        FixedLengthString campo17 = new FixedLengthString(15);
        FixedLengthString campo18 = new FixedLengthString(10);
        FixedLengthString campo19 = new FixedLengthString(2);
        FixedLengthString campo20 = new FixedLengthString(6);

        FixedLengthString campo21 = new FixedLengthString(13);
        FixedLengthString campo22 = new FixedLengthString(1);
        FixedLengthString campo23 = new FixedLengthString(18);
        FixedLengthString campo24 = new FixedLengthString(10);
        FixedLengthString campo25 = new FixedLengthString(3);
        FixedLengthString campo26 = new FixedLengthString(9);
        FixedLengthString campo27 = new FixedLengthString(9);
        FixedLengthString campo28 = new FixedLengthString(10);
        FixedLengthString campo29 = new FixedLengthString(10);
        FixedLengthString campo30 = new FixedLengthString(10);

        FixedLengthString campo31 = new FixedLengthString(1);
        FixedLengthString campo32 = new FixedLengthString(8);
        FixedLengthString campo33 = new FixedLengthString(18);
        FixedLengthString campo34 = new FixedLengthString(6);
        FixedLengthString campo35 = new FixedLengthString(10);
        FixedLengthString campo36 = new FixedLengthString(10);
        FixedLengthString campo37 = new FixedLengthString(10);
        FixedLengthString campo38 = new FixedLengthString(8);
        FixedLengthString campo39 = new FixedLengthString(60);


        public bool exportar(string connectionString, string ruc, DateTime desde, DateTime hasta, string rutaDestino)
        {
            //generar los datos
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);

                String query = "UCO_RegistroVentas_iContaSis";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parametros = {
                                            new SqlParameter("@desde", desde),
                                                new SqlParameter("@hasta", hasta)
                                            //parametros del procedimiento
                                        };

                comando.Parameters.AddRange(parametros);

                conexion.Open();

                SqlDataReader lector = comando.ExecuteReader();
                datos.Rows.Clear();
                datos.Load(lector);

                //ya tenemos los datos,  hay que convertirlo en txt
                //_conces = codigoConces;
                //return generaArchivo(rutaDestino);
                return generaExcel2(rutaDestino);
                //return generaExcel3(rutaDestino);
                //return generaExcel2(rutaDestino);

            }
            catch (Exception ex) {
                Eventos.cEventos registrar = new Eventos.cEventos();
                registrar.registrar("ExportarContaSis", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);
                return false; 
            }
        }

        public void cancelarProceso(Boolean valor)
        {
            cancelaProceso = valor;
        }

     

        private bool generaExcel3(string ruta)
        {
            ConvertidorExcel objExportador = new ConvertidorExcel();

            try
            {
                //objExportador.ExcelHeaderBold = false;
                objExportador.ShowExcelTableBorder = false;
                objExportador.Convert(datos, ruta, "regventas.xls");

                return true;

            }
            catch
            {
                return false;
            }

        }

        private bool generaExcel2(string ruta)
        {

            try
            {
                if (File.Exists(ruta + "regventas.xls") == true)
                {
                    File.Delete(ruta + "regventas.xls");
                }

                Excel.Application myApp;

                Excel.Workbook myWorkBk;

                object missingValue = System.Reflection.Missing.Value;

                myApp = new Microsoft.Office.Interop.Excel.Application();

                myApp.Visible = false;

                myWorkBk = myApp.Workbooks.Add(missingValue);

                Excel.Worksheet myWorkSht;

                myWorkSht = (Excel.Worksheet)myWorkBk.Worksheets.get_Item(1);

                myWorkSht.Name = "RegVentas";

                int nroFilas = 0;
                int nroColumnas = 0;

                nroFilas = datos.Rows.Count;
                nroColumnas = datos.Columns.Count;

                Excel.Range rango;

                

                for (int i = 1; i <= nroFilas; i++)
                {
                    RowProcessedEventArgs argumentos=new RowProcessedEventArgs();
                    argumentos.numero=i;
                    argumentos.total = nroFilas;
                    filaprocesada(this,argumentos);
                    for (int j = 1; j < nroColumnas; j++)
                    {
                        //poner el valor en la celda
                        //formato de texto
                        switch (j)
                        {
                            case 1:
                            case 2:
                            case 18:
                            case 24:
                            case 36:
                                rango=myWorkSht.Range[myWorkSht.Cells[i, j], myWorkSht.Cells[i, j]];
                                rango.NumberFormat = "dd/mm/yyyy";
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                            case 34:
                            case 35:
                            case 37:
                            case 39:
                                rango=myWorkSht.Range[myWorkSht.Cells[i, j], myWorkSht.Cells[i, j]];
                                rango.NumberFormat = "@";
                                break;
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 23:
                            case 32:
                            case 33:
                            case 38:
                                rango=myWorkSht.Range[myWorkSht.Cells[i, j], myWorkSht.Cells[i, j]];
                                rango.NumberFormat = "0.00";
                                break;
                            case 17:
                                rango = myWorkSht.Range[myWorkSht.Cells[i, j], myWorkSht.Cells[i, j]];
                                rango.NumberFormat = "0.0000";
                                break;
                        }

                        if (cancelaProceso == true)
                        {
                            return false;
                        }
                        
                        myWorkSht.Cells[i,j]=datos.Rows[i-1][j-1];
                    }
                }

                myWorkSht.SaveAs(ruta + "regventas.xls");
                
                myApp.Visible = true;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private bool generaExcel(string ruta)
        {

            try
            {
                // create the DataGrid and perform the databinding
                System.Web.UI.WebControls.DataGrid grid =
                            new System.Web.UI.WebControls.DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = datos;
                //grid.DataMember = data.Stats.TableName;

                grid.DataBind();

                // render the DataGrid control to a file
                if (File.Exists(ruta + "test.xls") == true)
                {
                    File.Delete(ruta + "test.xls");
                }


                using (StreamWriter sw = new StreamWriter("d:\\backup\\test.xls"))
                {
                    using (System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw))
                    {
                        grid.RenderControl(hw);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool generaArchivo(string ruta)
        {
            //generar el nombre segun  el siguiente formato
            // LERRRRRRRRRRRAAAAMM0014010000OIM1.TXT
            // LE-RRRRRRRRRRR-AAAA-MM-00-140100-00-O-I-M-1.TXT

            StringBuilder nombreArchivo = new StringBuilder("formato_ventas_contasis_");
            //falta indicar como se genera el nombre del archivo
            nombreArchivo.Append("generado");
            nombreArchivo.Append(".txt");
            String campo = "";

            if (File.Exists(ruta + nombreArchivo) == true)
            {
                File.Delete(ruta + nombreArchivo);
            }

            StreamWriter archivo = new StreamWriter(ruta + nombreArchivo);

            try
            {

                int correlativo = 0;

                foreach (DataRow fila in datos.Rows)
                {
                    correlativo = correlativo + 1;
                    StringBuilder linea = new StringBuilder();

                    //fecha de emision del comprobante de pago
                    campo01.Value = Convert.ToString(fila["FechaEmision"]);
                    linea.Append(campo01.ToString());

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

        private string ToCSV(DataTable table, string delimiter, bool includeHeader)
        {
            var result = new StringBuilder();

            if (includeHeader)
            {
                foreach (DataColumn column in table.Columns)
                {
                    result.Append(column.ColumnName);
                    result.Append(delimiter);
                }

                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }

            foreach (DataRow row in table.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    if (item is DBNull)
                        result.Append(delimiter);
                    else
                    {
                        string itemAsString = item.ToString();
                        // Double up all embedded double quotes
                        itemAsString = itemAsString.Replace("\"", "\"\"");

                        // To keep things simple, always delimit with double-quotes
                        // so we don't have to determine in which cases they're necessary
                        // and which cases they're not.
                        itemAsString = "\"" + itemAsString + "\"";

                        result.Append(itemAsString + delimiter);
                    }
                }

                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }


    }
}
