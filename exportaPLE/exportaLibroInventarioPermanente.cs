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
    public class exportaLibroInventarioPermanente
    {
        private DataTable datos = new DataTable();
        private string _ruc = "";
        private DateTime _fecha;
        private string _moneda = "";
        private cEventos evento = new cEventos();

        public Boolean exporta(string connectionString, string ruc, DateTime fecha, int monedaID,
                                string desde, string hasta, int establecimientoID, string rutaDestino,
                                string iniciomes, int almacenid, int articuloid, int opcionsaleccionada,
                                int familiaarticuloid, int subfamiliaid)
        {
            try
            {
                //obtenemos los datos
                _ruc = ruc;
                _fecha = fecha;
                _moneda = monedaID.ToString();

                SqlConnection conexion = new SqlConnection(connectionString);
                String query = "UCO_LibroInventariosPermanentes";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parametros = {
                                            new SqlParameter("@InicioMes",iniciomes),
                                            new SqlParameter("@Desde",desde),
                                            new SqlParameter("@Hasta",hasta),
                                            new SqlParameter("@AlmacenID",almacenid),
                                            new SqlParameter("@ArticuloId",articuloid),
                                            new SqlParameter("@OpcionSeleccionada",opcionsaleccionada),
                                            new SqlParameter("@FamiliaArticuloId",familiaarticuloid),
                                            new SqlParameter("@SubFamiliaId",subfamiliaid)
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
            //LERRRRRRRRRRRAAAAMM00-130100-00OIM1
            //identificador del libro 14 es registro de ventas
            nombreArchivo.Append("130100");
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
                    ////02 Codigo del establecimiento
                    campo = "0000000" + Convert.ToString(fila["codEstablecimiento"]);
                    campo = campo.Substring(campo.Length - 7, 7);
                    linea.Append(campo);
                    linea.Append("|");
                    ////03 Codigo de Catalogo
                    campo = "0" + Convert.ToString(fila["codCatalogo"]);
                    campo = campo.Substring(campo.Length - 1, 1);
                    linea.Append(campo);
                    linea.Append("|");
                    ////04 Tipo de Existencia
                    campo = "00" + Convert.ToString(fila["TipoExistencia"]);
                    campo = campo.Substring(campo.Length - 2, 2);
                    linea.Append(campo);
                    linea.Append("|");
                    ////05 Codigo de Existencia
                    campo = Convert.ToString(fila["CodigoExistencia"]);
                    campo = campo.Trim();
                    if (campo.Length >= 24)
                    {
                        campo = campo.Substring(0, 23);
                    }
                    linea.Append(campo);
                    linea.Append("|");
                    //06 fecha de emision
                    campo = Convert.ToString(fila["fechaEmision"]);
                    campo = campo.Substring(campo.Length - 10, 10);
                    linea.Append(campo);
                    linea.Append("|");
                    ////07 Tipo del documento
                    campo = "00" + Convert.ToString(fila["TipoDocumento"]);
                    campo = campo.Trim();
                    campo = campo.Substring(campo.Length - 2, 2);
                    linea.Append(campo);
                    linea.Append("|");
                    ////08 Serie del documento
                    campo = "00000000000000000000" + Convert.ToString(fila["Serie"]);
                    campo = campo.Trim();
                    campo = campo.Substring(campo.Length - 20, 20);
                    linea.Append(campo);
                    linea.Append("|");
                    ////09 Numero del documento
                    campo = "00000000000000000000" + Convert.ToString(fila["Numero"]);
                    campo = campo.Trim();
                    campo = campo.Substring(campo.Length - 10, 10);
                    linea.Append(campo);
                    linea.Append("|");
                    ////10 Tipo de Operacion
                    campo = Convert.ToString(fila["TipoOperacion"]);
                    linea.Append(campo);
                    linea.Append("|");
                    ////11 Descripcion
                    campo = Convert.ToString(fila["descripcion"]);
                    campo = campo.Trim();
                    if (campo.Length >= 80)
                    {
                        campo = campo.Substring(0, 78);
                    }
                    linea.Append(campo);
                    linea.Append("|");
                    ////12 Codigo de Unidad de Medida
                    campo = Convert.ToString(fila["codUnidadMedida"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //13 Medoto de Evaluacion
                    campo = Convert.ToString(fila["codMetodo"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //14 Cantidad de Unidades Fisicas
                    campo = Convert.ToString(fila["CantidadUnidadesFisicas"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //15 Costo unitario de bien ingresado
                    campo = Convert.ToString(fila["costoUnitario"]);
                    decimal monto = 0;
                    monto = Convert.ToDecimal(campo);
                    if (monto >= 0)
                    {
                        campo = Convert.ToString(campo);
                    }
                    else
                    {
                        campo = "0.00";
                    }
                    linea.Append(campo);
                    linea.Append("|");
                    //16 Costo total del bien ingresado
                    campo = Convert.ToString(fila["costoUnitarioTotal"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //17 Cantidad de Unidades Retiradas
                    campo = Convert.ToString(fila["CantidadUnidadesRetirado"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //18 costo de Unidades Retiradas
                    campo = Convert.ToString(fila["costoUnitarioRetiro"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //19 costo Total de Unidades Retiradas
                    campo = Convert.ToString(fila["costoTotalRetirado"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //20 Cantidad de Saldo Final
                    campo = Convert.ToString(fila["cantidadUnidadFinal"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //21 Costo Unitario de Saldo final
                    campo = Convert.ToString(fila["costoUnidadFinal"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //22 costo Total deSaldo Final
                    campo = Convert.ToString(fila["costoTotalFinal"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //23 Estado
                    campo = Convert.ToString(fila["Estado"]);
                    linea.Append(campo);
                    linea.Append("|");
                    //24 Correlativo
                    //campo = Convert.ToString(fila["CorrelativoS"]);
                    //linea.Append(campo);
                    //linea.Append("|");

                    ////agregar al archivo
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
