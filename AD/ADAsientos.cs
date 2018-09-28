using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace AD
{
    public class ADAsientos
    {

      //  private cEventos regEvent;

        public ADAsientos()
        {
        //    regEvent = new cEventos();
        }

        public DataTable estadosCuenta(Int32 empresaId, String ejercicio, String whereCondition, String orderByExpression, DateTime Hasta)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@EmpresaID", System.Data.SqlDbType.Int);
                par[0].Value = empresaId;
                par[1] = new SqlParameter("@Ejercicio", System.Data.SqlDbType.VarChar, 4);
                par[1].Value = ejercicio;
                par[2] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 350);
                par[2].Value = whereCondition;
                par[3] = new SqlParameter("@OrderByExpression", System.Data.SqlDbType.NVarChar, 350);
                par[3].Value = orderByExpression;
                par[4] = new SqlParameter("@DetalladoSaldo", System.Data.SqlDbType.Int);
                par[4].Value = 1;
                par[5] = new SqlParameter("@Hasta", System.Data.SqlDbType.DateTime);
                par[5].Value = Hasta;
                //_dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_EstadosCuenta", par).Tables[0];
                using (var conn = new SqlConnection(Connection.connectionString()))
                using (var command = new SqlCommand("UCO_EstadosCuenta", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.AddRange(par);
                    command.CommandTimeout = 0;
                    var dataReader = command.ExecuteReader();
                    _dataTable.Load(dataReader);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{

            //}
            return _dataTable;
        }
        public DataTable estadosCuentaSaldos(Int32 empresaId, String ejercicio, String whereCondition, String orderByExpression, DateTime Hasta)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[5];

                par[0] = new SqlParameter("@EmpresaID", System.Data.SqlDbType.Int);
                par[0].Value = empresaId;
                par[1] = new SqlParameter("@Ejercicio", System.Data.SqlDbType.VarChar, 4);
                par[1].Value = ejercicio;
                par[2] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 3000);
                par[2].Value = whereCondition;
                par[3] = new SqlParameter("@OrderByExpression", System.Data.SqlDbType.NVarChar, 3000);
                par[3].Value = orderByExpression;
                par[4] = new SqlParameter("@Hasta", System.Data.SqlDbType.DateTime);
                par[4].Value = Hasta;
                //_dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_EstadosCuentaSaldos", par).Tables[0];
                using (var conn = new SqlConnection(Connection.connectionString()))
                using (var command = new SqlCommand("UCO_EstadosCuentaSaldos", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.AddRange(par);
                    command.CommandTimeout = 0;
                    var dataReader = command.ExecuteReader();
                    _dataTable.Load(dataReader);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{
            //}
            return _dataTable;
        }

        public DataTable estadosCuentaSaldosHistoricos(Int32 empresaId, String ejercicio, String whereCondition, String orderByExpression,DateTime FechaFin)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@EmpresaID", System.Data.SqlDbType.Int);
                par[0].Value = empresaId;
                par[1] = new SqlParameter("@Ejercicio", System.Data.SqlDbType.VarChar, 4);
                par[1].Value = ejercicio;
                par[2] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 350);
                par[2].Value = whereCondition;
                par[3] = new SqlParameter("@OrderByExpression", System.Data.SqlDbType.NVarChar, 350);
                par[3].Value = orderByExpression;
                par[4] = new SqlParameter("@DetalladoSaldo", System.Data.SqlDbType.Int);
                par[4].Value = 0;
                par[5] = new SqlParameter("@Hasta", System.Data.SqlDbType.DateTime);
                par[5].Value = FechaFin;

                //_dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_EstadosCuenta", par).Tables[0];
                using (var conn = new SqlConnection(Connection.connectionString()))
                using (var command = new SqlCommand("UCO_EstadosCuenta", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.AddRange(par);
                    command.CommandTimeout = 0;
                    var dataReader = command.ExecuteReader();
                    _dataTable.Load(dataReader);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{

            //}
            return _dataTable;
        }
        //public DataTable estadosCuentaSaldosHistoricos(Int32 empresaId, String ejercicio, String whereCondition, String orderByExpression)
        //{
        //    DataTable _dataTable = new DataTable();
        //    try
        //    {
        //        SqlParameter[] par = new SqlParameter[4];

        //        par[0] = new SqlParameter("@EmpresaID", System.Data.SqlDbType.Int);
        //        par[0].Value = empresaId;
        //        par[1] = new SqlParameter("@Ejercicio", System.Data.SqlDbType.VarChar, 4);
        //        par[1].Value = ejercicio;
        //        par[2] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 3000);
        //        par[2].Value = whereCondition;
        //        par[3] = new SqlParameter("@OrderByExpression", System.Data.SqlDbType.NVarChar, 3000);
        //        par[3].Value = orderByExpression;

        //        _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_EstadosCuentaSaldosProveedores", par).Tables[0];
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    //finally
        //    //{
        //    //}
        //    return _dataTable;
        //}


        public DataTable subdiarios(Boolean opcionTodos)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                string query = "";
                if (opcionTodos == true)
                {
                    query = "select SubDiarioID,CodigoSubDiario,NombreSubDiario from subdiarios UNION select '0', '0', '<<< TODOS >>>' from SubDiarios";
                }
                else
                {
                    query = "select SubDiarioID,CodigoSubDiario,NombreSubDiario from subdiarios";
                }


                _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.Text, query).Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{
            //}
            return _dataTable;
        }
        public DataTable asientosContables(String empresaId, String ejercicio, DateTime desde, DateTime hasta, String subdiarioId, Int32 hotelId)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[13];

                par[0] = new SqlParameter("@NomCabecera", System.Data.SqlDbType.VarChar, 100);
                par[0].Value = "ACC";
                par[1] = new SqlParameter("@NomCabeceraDetalle", System.Data.SqlDbType.VarChar, 100);
                par[1].Value = "ACD";
                par[2] = new SqlParameter("@Empresa", System.Data.SqlDbType.VarChar, 50);
                par[2].Value = empresaId;
                par[3] = new SqlParameter("@anio", System.Data.SqlDbType.VarChar, 4);
                par[3].Value = ejercicio;
                par[4] = new SqlParameter("@FechaDesde", System.Data.SqlDbType.DateTime);
                par[4].Value = desde.ToShortDateString();
                par[5] = new SqlParameter("@FechaHasta", System.Data.SqlDbType.DateTime);
                par[5].Value = hasta.ToShortDateString();
                par[6] = new SqlParameter("@PlanCuentaID", System.Data.SqlDbType.VarChar, 20);
                par[6].Value = "";
                par[7] = new SqlParameter("@PlanCuentaID2", System.Data.SqlDbType.VarChar, 20);
                par[7].Value = "";
                par[8] = new SqlParameter("@SubDiarioID", System.Data.SqlDbType.VarChar, 20);
                par[8].Value = subdiarioId;
                par[9] = new SqlParameter("@HotelID", System.Data.SqlDbType.Int);
                par[9].Value = hotelId;
                par[10] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 500);
                par[10].Value = "";
                par[11] = new SqlParameter("@HavingCondition", System.Data.SqlDbType.NVarChar, 500);
                par[11].Value = null;
                par[12] = new SqlParameter("@TiposCuadre", System.Data.SqlDbType.Int);
                par[12].Value = 0;

                _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_AsientosContables_Select", par).Tables[0];
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{
            //}
            return _dataTable;
        }

        public DataTable asientosContables(String empresaId, String ejercicio, DateTime desde, DateTime hasta, String planCuentaId1, String planCuentaId2, String subdiarioId, Int32 hotelId)
        {
            DataTable _dataTable = new DataTable();

            try
            {

                String query = "UCO_AsientosContables_Select";
                SqlCommand comando = new SqlCommand(query);
                SqlParameter[] par = new SqlParameter[13];

                par[0] = new SqlParameter("@NomCabecera", System.Data.SqlDbType.VarChar, 100);
                par[0].Value = "ACC";
                par[1] = new SqlParameter("@NomCabeceraDetalle", System.Data.SqlDbType.VarChar, 100);
                par[1].Value = "ACD";
                par[2] = new SqlParameter("@Empresa", System.Data.SqlDbType.VarChar, 50);
                par[2].Value = empresaId;
                par[3] = new SqlParameter("@anio", System.Data.SqlDbType.VarChar, 4);
                par[3].Value = ejercicio;
                par[4] = new SqlParameter("@FechaDesde", System.Data.SqlDbType.DateTime);
                par[4].Value = desde.ToShortDateString();
                par[5] = new SqlParameter("@FechaHasta", System.Data.SqlDbType.DateTime);
                par[5].Value = hasta.ToShortDateString();
                par[6] = new SqlParameter("@PlanCuentaID", System.Data.SqlDbType.VarChar, 20);
                par[6].Value = planCuentaId1;
                par[7] = new SqlParameter("@PlanCuentaID2", System.Data.SqlDbType.VarChar, 20);
                par[7].Value = planCuentaId2;
                par[8] = new SqlParameter("@SubDiarioID", System.Data.SqlDbType.VarChar, 20);
                par[8].Value = subdiarioId;
                par[9] = new SqlParameter("@HotelID", System.Data.SqlDbType.Int);
                par[9].Value = hotelId;
                par[10] = new SqlParameter("@WhereCondition", System.Data.SqlDbType.NVarChar, 500);
                par[10].Value = "";
                par[11] = new SqlParameter("@HavingCondition", System.Data.SqlDbType.NVarChar, 500);
                par[11].Value = null;
                par[12] = new SqlParameter("@TiposCuadre", System.Data.SqlDbType.Int);
                par[12].Value = 0;

                comando.Parameters.AddRange(par);

                SqlConnection conexion = new SqlConnection(Connection.connectionString());

                comando.CommandType = CommandType.StoredProcedure;

                comando.CommandTimeout = 3600;

                comando.Connection = conexion;

                //conexion.Open();

                //comando.ExecuteReader();

                //SqlDataReader lector = comando.ExecuteReader();

                DataSet ds = new DataSet();

                //DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(ds, "Tabla");

                _dataTable = ds.Tables[0];

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{
            //}
            return _dataTable;
        }

        public DataTable consolidadoAsientosContables(String empresaId, String ejercicio, String subdiarioId, Int32 unidadNegocioID, Int32 hotelId, Int32 areaID, DateTime desde, DateTime hasta, string @AsientocontableDetalleIDTransferencia, String PlanCuentaId1, String PlanCuentaId2)
        {
            DataTable _dataTable = new DataTable();
            try
            {
                SqlParameter[] par = new SqlParameter[11];

                par[0] = new SqlParameter("@Empresa", System.Data.SqlDbType.VarChar, 50);
                par[0].Value = empresaId;
                par[1] = new SqlParameter("@Ejercicio", System.Data.SqlDbType.Int);
                par[1].Value = ejercicio;
                par[2] = new SqlParameter("@SubDiarioID", System.Data.SqlDbType.Int);
                par[2].Value = subdiarioId;
                par[3] = new SqlParameter("@UnidadNegocioID", System.Data.SqlDbType.Int);
                par[3].Value = unidadNegocioID;
                par[4] = new SqlParameter("@HotelID", System.Data.SqlDbType.Int);
                par[4].Value = hotelId;
                par[5] = new SqlParameter("@AreaID", System.Data.SqlDbType.Int);
                par[5].Value = areaID;
                par[6] = new SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime);
                par[6].Value = desde.ToShortDateString();
                par[7] = new SqlParameter("@FechaFin", System.Data.SqlDbType.DateTime);
                par[7].Value = hasta.ToShortDateString();
                par[8] = new SqlParameter("@AsientocontableDetalleIDTransferencia", System.Data.SqlDbType.VarChar, 500);
                par[8].Value = AsientocontableDetalleIDTransferencia;
                par[9] = new SqlParameter("@PlanCuentaId1", System.Data.SqlDbType.VarChar, 20);
                par[9].Value = PlanCuentaId1;
                par[10] = new SqlParameter("@PlanCuentaId2", System.Data.SqlDbType.VarChar, 20);
                par[10].Value = PlanCuentaId2;

                _dataTable = SqlHelper.ExecuteDataset(Connection.connectionString(), CommandType.StoredProcedure, "UCO_ConsolidadoAsientosContables_Select_v2", par).Tables[0];
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            //finally
            //{
            //}
            return _dataTable;
        }

        public bool transferenciaVentas(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            //regEvent.registrar("Contabilidad-AD.DLL","Inicia proceso de transferencia de ventas",System.Diagnostics.EventLogEntryType.Information);
            string query = "UCOTRA_VENTAS";
            SqlParameter[] parametros;
            try
            {
                parametros = new SqlParameter[] {
                                      new SqlParameter("@desde",desde),
                                      new SqlParameter("@hasta",hasta),
                                      new SqlParameter("@usuarioID",usuarioID),
                                      new SqlParameter("@movimiento",movimiento),
                                      new SqlParameter("@ipEquipo",ipEquipo),
                                      new SqlParameter("@usuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@nombreEquipo",nombreEquipo)
                                    };
                //regEvent.registrar("Contabilidad-AD.DLL","Se crearon parametros.",System.Diagnostics.EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                //regEvent.registrar("Contabilidad-AD.DLL", "Transferencia de Ventas iniciada.", System.Diagnostics.EventLogEntryType.Information);
                try
                {

                    SqlConnection conexion = new SqlConnection(Connection.connectionString());

                    SqlCommand comandoSQL = new SqlCommand(query);

                    comandoSQL.CommandTimeout = 36000;
                    comandoSQL.Connection = conexion;
                    comandoSQL.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    comandoSQL.Parameters.Add(new SqlParameter("@desde", desde));
                    comandoSQL.Parameters.Add(new SqlParameter("@hasta", hasta));
                    comandoSQL.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                    comandoSQL.Parameters.Add(new SqlParameter("@movimiento", movimiento));
                    comandoSQL.Parameters.Add(new SqlParameter("@ipEquipo", ipEquipo));
                    comandoSQL.Parameters.Add(new SqlParameter("@usuarioActualEquipo", usuarioActualEquipo));
                    comandoSQL.Parameters.Add(new SqlParameter("@nombreEquipo", nombreEquipo));

                    comandoSQL.ExecuteNonQuery();


                    //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros); 

                }
                catch (Exception exM)
                {
                    string mensajeEX = exM.Message.Substring(0, 32000);
                    //regEvent.registrar("Contabilidad-AD.DLL", mensajeEX, System.Diagnostics.EventLogEntryType.Error); 
                }

                //regEvent.registrar("Contabilidad-AD.DLL","Transferencia de Ventas finalizada.", System.Diagnostics.EventLogEntryType.Information);
                return true;
            }

            catch (SqlException e)
            {
                string mensaje = e.Message.Substring(0, 32700);
                //regEvent.registrar("Contabilidad-AD.DLL", mensaje, System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                string mensaje = e.Message.Substring(0, 32700);
                //regEvent.registrar("Contabilidad-AD.DLL", mensaje, System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(e.Message);
                return false;
            }


        }

        public bool transferenciaCobranzas(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {

            try
            {
                string query = "UCOTRA_COBRANZAS";

                SqlParameter[] parametros = {

                                      new SqlParameter("@desde",desde),
                                      new SqlParameter("@hasta",hasta),
                                      new SqlParameter("@usuarioID",usuarioID),
                                      new SqlParameter("@movimiento",movimiento),
                                      new SqlParameter("@ipEquipo",ipEquipo),
                                      new SqlParameter("@usuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@nombreEquipo",nombreEquipo)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());


                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@desde", desde));
                comandoSQL.Parameters.Add(new SqlParameter("@hasta", hasta));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                comandoSQL.Parameters.Add(new SqlParameter("@movimiento", movimiento));
                comandoSQL.Parameters.Add(new SqlParameter("@ipEquipo", ipEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioActualEquipo", usuarioActualEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@nombreEquipo", nombreEquipo));

                comandoSQL.ExecuteNonQuery();

                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool transferenciaCompras(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {

            try
            {
                string query = "UCOTRA_COMPRAS";

                SqlParameter[] parametros = {

                                      new SqlParameter("@desde",desde.ToShortDateString()),
                                      new SqlParameter("@hasta",hasta.ToShortDateString()),
                                      new SqlParameter("@usuarioID",usuarioID),
                                      new SqlParameter("@movimiento",movimiento),
                                      new SqlParameter("@ipEquipo",ipEquipo),
                                      new SqlParameter("@usuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@nombreEquipo",nombreEquipo)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());

                string h = desde.ToShortDateString();

                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@desde", desde.ToShortDateString()));
                comandoSQL.Parameters.Add(new SqlParameter("@hasta", hasta.ToShortDateString()));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                comandoSQL.Parameters.Add(new SqlParameter("@movimiento", movimiento));
                comandoSQL.Parameters.Add(new SqlParameter("@ipEquipo", ipEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioActualEquipo", usuarioActualEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@nombreEquipo", nombreEquipo));

                comandoSQL.ExecuteNonQuery();

                conexion.Close();



                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool transferenciaSalidas(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {

            try
            {
                string query = "UCOTRA_SALIDAS";

                SqlParameter[] parametros = {

                                      new SqlParameter("@desde",desde),
                                      new SqlParameter("@hasta",hasta),
                                      new SqlParameter("@usuarioID",usuarioID),
                                      new SqlParameter("@movimiento",movimiento),
                                      new SqlParameter("@ipEquipo",ipEquipo),
                                      new SqlParameter("@usuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@nombreEquipo",nombreEquipo)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());


                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@desde", desde));
                comandoSQL.Parameters.Add(new SqlParameter("@hasta", hasta));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                comandoSQL.Parameters.Add(new SqlParameter("@movimiento", movimiento));
                comandoSQL.Parameters.Add(new SqlParameter("@ipEquipo", ipEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioActualEquipo", usuarioActualEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@nombreEquipo", nombreEquipo));

                comandoSQL.ExecuteNonQuery();

                conexion.Close();



                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool transferenciaDevegueVentas(DateTime Desde, DateTime Hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            try
            {
                string query = "UCOTRA_VENTAS_DEVENGUES";

                SqlParameter[] parametros = {

                                      new SqlParameter("@Desde",Desde),
                                      new SqlParameter("@Hasta",Hasta),
                                      new SqlParameter("@usuarioID",usuarioID),
                                      new SqlParameter("@movimiento",movimiento),
                                      new SqlParameter("@ipEquipo",ipEquipo),
                                      new SqlParameter("@usuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@nombreEquipo",nombreEquipo)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());


                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@Desde", Desde));
                comandoSQL.Parameters.Add(new SqlParameter("@Hasta", Hasta));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                comandoSQL.Parameters.Add(new SqlParameter("@movimiento", movimiento));
                comandoSQL.Parameters.Add(new SqlParameter("@ipEquipo", ipEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioActualEquipo", usuarioActualEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@nombreEquipo", nombreEquipo));

                comandoSQL.ExecuteNonQuery();

                conexion.Close();



                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        public bool transferenciaDevegueGastos(String PeriodoFiltro, String MesFiltro, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            try
            {
                string query = "UCOTRA_COMPRAS_GASTOS_DIFERIDOS";

                SqlParameter[] parametros = {

                                      new SqlParameter("@PeriodoFiltro",PeriodoFiltro),
                                      new SqlParameter("@MesFiltro",MesFiltro),
                                      new SqlParameter("@UsuarioID",usuarioID),
                                      new SqlParameter("@Movimiento",movimiento),
                                      new SqlParameter("@IPEquipo",ipEquipo),
                                      new SqlParameter("@UsuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@NombreEquipo",nombreEquipo)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());


                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@PeriodoFiltro", PeriodoFiltro));
                comandoSQL.Parameters.Add(new SqlParameter("@MesFiltro", MesFiltro));
                comandoSQL.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));
                comandoSQL.Parameters.Add(new SqlParameter("@Movimiento", movimiento));
                comandoSQL.Parameters.Add(new SqlParameter("@IPEquipo", ipEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@UsuarioActualEquipo", usuarioActualEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@NombreEquipo", nombreEquipo));

                comandoSQL.ExecuteNonQuery();

                conexion.Close();



                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        public bool transferenciaPlanillas(DateTime fecha, string tipoProvision, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {

            try
            {
                string query = "UCOTRA_PLANILLAS";

                SqlParameter[] parametros = {

                                      new SqlParameter("@fecha",fecha),
                                      new SqlParameter("@tipoProvision",tipoProvision),
                                      new SqlParameter("@usuarioID",usuarioID),
                                      new SqlParameter("@movimiento",movimiento),
                                      new SqlParameter("@ipEquipo",ipEquipo),
                                      new SqlParameter("@usuarioActualEquipo",usuarioActualEquipo),
                                      new SqlParameter("@nombreEquipo",nombreEquipo)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());


                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@fecha", fecha));
                comandoSQL.Parameters.Add(new SqlParameter("@tipoProvision", tipoProvision));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                comandoSQL.Parameters.Add(new SqlParameter("@movimiento", movimiento));
                comandoSQL.Parameters.Add(new SqlParameter("@ipEquipo", ipEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@usuarioActualEquipo", usuarioActualEquipo));
                comandoSQL.Parameters.Add(new SqlParameter("@nombreEquipo", nombreEquipo));

                comandoSQL.ExecuteNonQuery();

                conexion.Close();



                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool transferenciaTesoreria(DateTime desde, DateTime hasta, int usuarioID)
        {

            try
            {
                string query = "UCOTRA_TESORERIA";

                SqlParameter[] parametros = {

                                      new SqlParameter("@desde",desde),
                                      new SqlParameter("@hasta",hasta),
                                      new SqlParameter("@UsuarioID",usuarioID)

                                    };

                SqlConnection conexion = new SqlConnection(Connection.connectionString());

                SqlCommand comandoSQL = new SqlCommand(query);

                comandoSQL.CommandTimeout = 36000;
                comandoSQL.Connection = conexion;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                comandoSQL.Parameters.Add(new SqlParameter("@desde", desde));
                comandoSQL.Parameters.Add(new SqlParameter("@hasta", hasta));
                comandoSQL.Parameters.Add(new SqlParameter("@UsuarioID",usuarioID ));

                comandoSQL.ExecuteNonQuery();

                conexion.Close();

                //SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

     

        public bool eliminarVoucher(string EstablecimientoID, string Periodo, string AsientoContableID, Int32 UsuarioID, Int32 UsuarioIdAutorizado, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo, string TablaMovimientoID, int HotelID)
        {
            //@EstablecimientoID varchar(20),                     
            //@Periodo varchar(4) ,        
            //@AsientoContableID varchar(20),                         
            //@UsuarioID Int=null,          
            //@UsuarioIdAutorizado Int =null,            
            //@IPEquipo    nVarChar(50)=null,             
            //@UsuarioActualEquipo nVarChar(50)=null,             
            //@NombreEquipo   nVarChar(50)=null,            
            //@TablaMovimientoID  nVarChar(20)=null,  
            //@HotelID Int =null            
            try
            {
                string query = "UCO_AsientoContable_Elimina";

                SqlParameter[] parametros = 
            
                                    {

                                      new SqlParameter("@EstablecimientoID",EstablecimientoID),
                                      new SqlParameter("@Periodo",Periodo),
                                      new SqlParameter("@AsientoContableID",AsientoContableID),
                                      new SqlParameter("@UsuarioID",UsuarioID),
                                      new SqlParameter("@UsuarioIdAutorizado",UsuarioIdAutorizado),
                                      new SqlParameter("@IPEquipo",IPEquipo),
                                      new SqlParameter("@UsuarioActualEquipo",UsuarioActualEquipo),
                                      new SqlParameter("@NombreEquipo",NombreEquipo),
                                      new SqlParameter("@TablaMovimientoID",TablaMovimientoID),
                                      new SqlParameter("@HotelID",HotelID)

                                    };

                SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool eliminarDetalle(string EstablecimientoID, string Periodo, string AsientoContableID, string AsientoContableDetalleID, Int32 UsuarioID, Int32 UsuarioIdAutorizado, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo, string TablaMovimientoID, int HotelID)
        {

            try
            {
                string query = "UCO_AsientoContableDetalle_Elimina";

                SqlParameter[] parametros = 
            
                                    {

                                      new SqlParameter("@EstablecimientoID",EstablecimientoID),
                                      new SqlParameter("@Periodo",Periodo),
                                      new SqlParameter("@AsientoContableID",AsientoContableID),
                                      new SqlParameter("@AsientoContableDetalleID",AsientoContableDetalleID),
                                      new SqlParameter("@UsuarioID",UsuarioID),
                                      new SqlParameter("@UsuarioIdAutorizado",UsuarioIdAutorizado),
                                      new SqlParameter("@IPEquipo",IPEquipo),
                                      new SqlParameter("@UsuarioActualEquipo",UsuarioActualEquipo),
                                      new SqlParameter("@NombreEquipo",NombreEquipo),
                                      new SqlParameter("@TablaMovimientoID",TablaMovimientoID),
                                      new SqlParameter("@HotelID",HotelID)

                                    };

                SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool eliminarVoucherTodos(string EstablecimientoID, string Periodo, DateTime Desde, DateTime Hasta, string SubDiarioId, Int32 UsuarioID, Int32 UsuarioIdAutorizado, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo, string TablaMovimientoID, int HotelID)
        {
            //@EstablecimientoID varchar(20),                     
            //@Periodo varchar(4),
            //@Desde datetime,
            //@Hasta datetime,
            //@SubDiarioId char(20),
            //@UsuarioID Int = null,          
            //@UsuarioIdAutorizado Int = null,            
            //@IPEquipo    nVarChar(50)= null,             
            //@UsuarioActualEquipo nVarChar(50)= null,             
            //@NombreEquipo   nVarChar(50)= null,            
            //@TablaMovimientoID nVarChar(20)= null,  
            //@HotelID Int = null          
            try
            {
                string query = "UCO_AsientoContable_EliminaTodos";

                SqlParameter[] parametros = 
            
                                    {

                                      new SqlParameter("@EstablecimientoID",EstablecimientoID),
                                      new SqlParameter("@Periodo",Periodo),                                      
                                      new SqlParameter("@SubDiarioID",SubDiarioId),
                                      new SqlParameter("@UsuarioID",UsuarioID),
                                      new SqlParameter("@UsuarioIdAutorizado",UsuarioIdAutorizado),
                                      new SqlParameter("@IPEquipo",IPEquipo),
                                      new SqlParameter("@UsuarioActualEquipo",UsuarioActualEquipo),
                                      new SqlParameter("@NombreEquipo",NombreEquipo),
                                      new SqlParameter("@TablaMovimientoID",TablaMovimientoID),
                                      new SqlParameter("@HotelID",HotelID),
                                      new SqlParameter("@Desde",Desde),
                                      new SqlParameter("@Hasta",Hasta)

                                    };

                SqlHelper.ExecuteNonQuery(Connection.connectionString(), query, parametros);

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public Boolean SubDiarioEsAutomatico(String SubDiarioId)
        {
            string query = "UCO_SubDiarioAutomatico";

            SqlParameter[] parametros = {
                                        new SqlParameter("@SubDiarioId",SubDiarioId.Trim())
                                    };

            DataRow fila;

            fila = SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros).Tables[0].Rows[0];

            Boolean valor;

            valor = Convert.ToBoolean(fila["Automatico"]);

            return valor;

        }

        public bool procesosCalculoDiferenciaCambio(DateTime fecha, string EstablecimientoId, string Periodo, string HotelId)
        {
            String query = "UCO_CALCULADIFERENCIACAMBIO";
            fecha = Convert.ToDateTime(fecha.ToShortDateString());
            SqlParameter[] parametros = {
                                        new SqlParameter("@fecha",fecha),
                                        new SqlParameter("@EstablecimientoId",EstablecimientoId),
                                        new SqlParameter("@Periodo",Periodo),
                                        new SqlParameter("@HotelId",HotelId),
                                        new SqlParameter("@MonedaId",1)
                                    };

            SqlConnection conexion = new SqlConnection(Connection.connectionString());


            SqlCommand comandoSQL = new SqlCommand(query);

            comandoSQL.CommandTimeout = 36000;
            comandoSQL.Connection = conexion;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            comandoSQL.Parameters.Add(new SqlParameter("@fecha", fecha));
            comandoSQL.Parameters.Add(new SqlParameter("@EstablecimientoId", EstablecimientoId));
            comandoSQL.Parameters.Add(new SqlParameter("@Periodo", Periodo));
            comandoSQL.Parameters.Add(new SqlParameter("@HotelId", HotelId));
            comandoSQL.Parameters.Add(new SqlParameter("@MonedaId", 1));

            try
            {
                comandoSQL.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            //=========================
        }

        public bool procesosUCO_CierrePeriodoProcede(string Ejercicio, string Establecimiento)
        {
            String query = "UCO_CierrePeriodoProcede";
            SqlParameter[] parametros = {
                                        new SqlParameter("@MonedaID",1),
                                        new SqlParameter("@PeriodoID",13),
                                        new SqlParameter("@Ejercicio",Ejercicio),
                                        new SqlParameter("@HotelID",0),
                                        new SqlParameter("@EstablecimientoID",Establecimiento),
                                        new SqlParameter("@NivelID",7),
                                        new SqlParameter("@Acumulado",1)
                                    };
            SqlConnection conexion = new SqlConnection(Connection.connectionString());
            SqlCommand comandoSQL = new SqlCommand(query);
            comandoSQL.CommandTimeout = 36000;
            comandoSQL.Connection = conexion;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            comandoSQL.Parameters.Add(new SqlParameter("@MonedaID", 1));
            comandoSQL.Parameters.Add(new SqlParameter("@PeriodoID", 13));
            comandoSQL.Parameters.Add(new SqlParameter("@Ejercicio", Ejercicio));
            comandoSQL.Parameters.Add(new SqlParameter("@HotelID", 0));
            comandoSQL.Parameters.Add(new SqlParameter("@EstablecimientoID", Establecimiento));
            comandoSQL.Parameters.Add(new SqlParameter("@NivelID", 7));
            comandoSQL.Parameters.Add(new SqlParameter("@Acumulado", 1));
            try
            {
                comandoSQL.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataSet inconsistencias(Int32 establecimientoID, Int32 periodo)
        {
            String query = "UCO_Inconsistencias";

            SqlParameter[] parametros = {
                                          new SqlParameter("@EstablecimientoID",establecimientoID),
                                          new SqlParameter("@periodo",periodo)
                                      };
            try
            {
                return SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros);
            }
            catch
            {
                return new DataSet();
            }

        }

        public String setCreaAsientoCabecera(String NomCabecera, String Empresa, String Anio, String AsientoContableID, String SubDiarioID, Int32 HotelID, String Glosa, String Comprobante, DateTime FechaEmision, Int32 UsuarioID, Int32 UsuarioIdAutorizado, String IPEquipo, String UsuarioActualEquipo, String NombreEquipo, String TablaMovimientoID, Int32 Bloqueado)
        {
            string query = "UCO_AsientosContables_CreaoModifica";

            SqlCommand comando = new SqlCommand(query);

            comando.Connection = new SqlConnection(Connection.connectionString());

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NomCabecera", NomCabecera);
            comando.Parameters.AddWithValue("@Empresa", Empresa);
            comando.Parameters.AddWithValue("@Anio", Anio);
            comando.Parameters.AddWithValue("@AsientoContableID", AsientoContableID);
            comando.Parameters.AddWithValue("@SubDiarioID", SubDiarioID);
            comando.Parameters.AddWithValue("@HotelID", HotelID);
            comando.Parameters.AddWithValue("@Glosa", Glosa);
            comando.Parameters.AddWithValue("@Comprobante", Comprobante);
            comando.Parameters.AddWithValue("@FechaEmision", FechaEmision);
            comando.Parameters.AddWithValue("@UsuarioID", UsuarioID);
            comando.Parameters.AddWithValue("@UsuarioIdAutorizado", UsuarioIdAutorizado);
            comando.Parameters.AddWithValue("@IPEquipo", IPEquipo);
            comando.Parameters.AddWithValue("@UsuarioActualEquipo", UsuarioActualEquipo);
            comando.Parameters.AddWithValue("@NombreEquipo", NombreEquipo);
            comando.Parameters.AddWithValue("@TablaMovimientoID", TablaMovimientoID);
            comando.Parameters.AddWithValue("@Bloqueado", Bloqueado);

            comando.Parameters["@AsientoContableID"].Size = 20;
            comando.Parameters["@AsientoContableID"].Direction = ParameterDirection.InputOutput;

            int numeroparametros = comando.Parameters.Count;

            comando.Connection.Open();

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine(sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            String Codigo;

            try
            {
                Codigo = comando.Parameters["@AsientoContableID"].Value.ToString();
            }
            catch
            {
                Codigo = "";
            }


            comando.Connection = null;

            comando = null;

            return Codigo;
            // @NomCabecera varchar(100),                              
            //@Empresa VarChar(50),                           
            //@Anio VarChar(4),                          

            //@AsientoContableID varchar(20) output,      
            //@SubDiarioID varchar(20),                        
            //@HotelID int,                        
            //--@TipoConversionMonedaID varchar(20),                        
            //@Glosa  varchar(100),                        
            //@Comprobante  varchar(20),                        
            //@FechaEmision datetime,                        
            //--@MonedaID int,                        
            //--@TipoCambio varchar(10),                        
            //@UsuarioID Int = null,              
            //@UsuarioIdAutorizado Int  = null,               
            //@IPEquipo    nVarChar(50) = null,              
            //@UsuarioActualEquipo nVarChar(50) = null,              
            //@NombreEquipo   nVarChar(50) = null,              
            //@TablaMovimientoID  nVarChar(20) = null,              
            //@Bloqueado int = null    
        }

        public bool setCreaAsientoDetalle(String EstablecimientoID, String Periodo, String AsientoContableDetalleID, string AsientoContableID, Decimal MontoDebe, Decimal MontoHaber, String CanalContableID, Int32 EmpresaID, Int32 TipoDocumentoID, Int32 ProyectoID, DateTime Dia, String Referencia, DateTime FechaEmision, DateTime FechaVencimiento, Int32 AreaID, String NumeroDocumento, String TransaccionDocumentoID, Int32 FlujoCajaID, String PlanCuentaID, Decimal ImporteSoles, Decimal ImporteDolares, String AsientoContableDetalleIDTransferencia, String PeriodoID, String TablaMovimientoIDAsientos, Int32 UnidadNegocioId_1, Decimal ImporteSoles_1, Decimal ImporteDolares_1, Int32 UnidadNegocioId_2, Decimal ImporteSoles_2, Decimal ImporteDolares_2, Int32 UnidadNegocioId_3, Decimal ImporteSoles_3, Decimal ImporteDolares_3, Int32 UnidadNegocioId_4, Decimal ImporteSoles_4, Decimal ImporteDolares_4, Int32 UnidadNegocioId_5, Decimal ImporteSoles_5, Decimal ImporteDolares_5, Int32 UnidadNegocioId_6, Decimal ImporteSoles_6, Decimal ImporteDolares_6, Int32 UnidadNegocioId_7, Decimal ImporteSoles_7, Decimal ImporteDolares_7, Int32 UnidadNegocioId_8, Decimal ImporteSoles_8, Decimal ImporteDolares_8, Int32 UnidadNegocioId_9, Decimal ImporteSoles_9, Decimal ImporteDolares_9, Int32 UnidadNegocioId_10, Decimal ImporteSoles_10, Decimal ImporteDolares_10, String TipoConversionMonedaID, Int32 MonedaID, String TipoCambio)
        {

            string query = "UCO_AsientosContablesDetalle_CreaoModifica";

            SqlCommand comando = new SqlCommand(query);

            comando.Parameters.Add(new SqlParameter("@EstablecimientoID", EstablecimientoID));
            comando.Parameters.Add(new SqlParameter("@Periodo", Periodo));
            comando.Parameters.Add(new SqlParameter("@AsientoContableDetalleID", AsientoContableDetalleID));
            comando.Parameters.Add(new SqlParameter("@AsientoContableID", AsientoContableID));
            comando.Parameters.Add(new SqlParameter("@MontoDebe", MontoDebe));
            comando.Parameters.Add(new SqlParameter("@MontoHaber", MontoHaber));
            comando.Parameters.Add(new SqlParameter("@CanalContableID", CanalContableID));
            comando.Parameters.Add(new SqlParameter("@EmpresaID", EmpresaID));
            comando.Parameters.Add(new SqlParameter("@TipoDocumentoID", TipoDocumentoID));
            comando.Parameters.Add(new SqlParameter("@ProyectoID", ProyectoID));
            comando.Parameters.Add(new SqlParameter("@Dia", Dia));
            comando.Parameters.Add(new SqlParameter("@Referencia", Referencia));
            comando.Parameters.Add(new SqlParameter("@FechaEmision", FechaEmision));
            comando.Parameters.Add(new SqlParameter("@FechaVencimiento", FechaVencimiento));
            comando.Parameters.Add(new SqlParameter("@AreaID", AreaID));
            comando.Parameters.Add(new SqlParameter("@NumeroDocumento", NumeroDocumento));
            comando.Parameters.Add(new SqlParameter("@TransaccionDocumentoID", TransaccionDocumentoID));
            comando.Parameters.Add(new SqlParameter("@FlujoCajaID", FlujoCajaID));
            comando.Parameters.Add(new SqlParameter("@PlanCuentaID", PlanCuentaID));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles", ImporteSoles));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares", ImporteDolares));
            comando.Parameters.Add(new SqlParameter("@AsientoContableDetalleIDTransferencia", AsientoContableDetalleIDTransferencia));
            comando.Parameters.Add(new SqlParameter("@PeriodoID", PeriodoID));
            comando.Parameters.Add(new SqlParameter("@TablaMovimientoIDAsientos", TablaMovimientoIDAsientos));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_1", UnidadNegocioId_1));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_1", ImporteSoles_1));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_1", ImporteDolares_1));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_2", UnidadNegocioId_2));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_2", ImporteSoles_2));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_2", ImporteDolares_2));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_3", UnidadNegocioId_3));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_3", ImporteSoles_3));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_3", ImporteDolares_3));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_4", UnidadNegocioId_4));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_4", ImporteSoles_4));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_4", ImporteDolares_4));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_5", UnidadNegocioId_5));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_5", ImporteSoles_5));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_5", ImporteDolares_5));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_6", UnidadNegocioId_6));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_6", ImporteSoles_6));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_6", ImporteDolares_6));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_7", UnidadNegocioId_7));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_7", ImporteSoles_7));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_7", ImporteDolares_7));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_8", UnidadNegocioId_8));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_8", ImporteSoles_8));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_8", ImporteDolares_8));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_9", UnidadNegocioId_9));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_9", ImporteSoles_9));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_9", ImporteDolares_9));
            comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_10", UnidadNegocioId_10));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles_10", ImporteSoles_10));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares_10", ImporteDolares_10));
            comando.Parameters.Add(new SqlParameter("@TipoConversionMonedaID", TipoConversionMonedaID));
            comando.Parameters.Add(new SqlParameter("@MonedaID", MonedaID));
            comando.Parameters.Add(new SqlParameter("@TipoCambio", TipoCambio));

            comando.Connection = new SqlConnection(Connection.connectionString());

            comando.CommandType = CommandType.StoredProcedure;

            comando.Connection.Open();



            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }





            //@EstablecimientoID varchar(20),      
            //@Periodo varchar(4),      
            //@AsientoContableDetalleID char(20),      
            //@AsientoContableID char(20),      
            //@MontoDebe decimal(18, 2),      
            //@MontoHaber decimal(18, 2),      
            //@CanalContableID char(20),      
            //@EmpresaID int,      
            //@TipoDocumentoID int,      
            //@ProyectoID int,      
            //@Dia datetime,      
            //@Referencia varchar(80),      
            //@FechaEmision datetime,      
            //@FechaVencimiento datetime,      
            //@AreaID int,      
            //@NumeroDocumento varchar(20),      
            //@TransaccionDocumentoID char(20),      
            //@FlujoCajaID int,      
            //@PlanCuentaID char(20),      
            //@ImporteSoles decimal(18, 2),      
            //@ImporteDolares decimal(18, 2),      
            //@AsientoContableDetalleIDTransferencia char(20),      
            //@PeriodoID varchar(2),      
            //@TablaMovimientoIDAsientos nvarchar(20) = null,      

            //--///A.-PARAMETROS DISTRIBUCION DE UNIDAD DE NEGOCIO//////////////////////////////////////////////////////////////          
            //@UnidadNegocioID_1 int=null,      
            //@ImporteSoles_1 decimal(18,2)=null,      
            //@ImporteDolares_1 decimal(18,2)=null,      

            //@UnidadNegocioID_2 int=null,      
            //@ImporteSoles_2 decimal(18,2)=null,      
            //@ImporteDolares_2 decimal(18,2)=null,      

            //@UnidadNegocioID_3 int=null,      
            //@ImporteSoles_3 decimal(18,2)=null,      
            //@ImporteDolares_3 decimal(18,2)=null,      

            //@UnidadNegocioID_4 int=null,      
            //@ImporteSoles_4 decimal(18,2)=null,      
            //@ImporteDolares_4 decimal(18,2)=null,      

            //@UnidadNegocioID_5 int=null,      
            //@ImporteSoles_5 decimal(18,2)=null,      
            //@ImporteDolares_5 decimal(18,2)=null,      

            //@UnidadNegocioID_6 int=null,      
            //@ImporteSoles_6 decimal(18,2)=null,      
            //@ImporteDolares_6 decimal(18,2)=null,      

            //@UnidadNegocioID_7 int=null,      
            //@ImporteSoles_7 decimal(18,2)=null,      
            //@ImporteDolares_7 decimal(18,2)=null,      

            //@UnidadNegocioID_8 int=null,      
            //@ImporteSoles_8 decimal(18,2)=null,      
            //@ImporteDolares_8 decimal(18,2)=null,      

            //@UnidadNegocioID_9 int=null,      
            //@ImporteSoles_9 decimal(18,2)=null,      
            //@ImporteDolares_9 decimal(18,2)=null,      

            //@UnidadNegocioID_10 int=null,      
            //@ImporteSoles_10 decimal(18,2)=null,      
            //@ImporteDolares_10 decimal(18,2)=null,      


            ///*FRANCO */
            //@TipoConversionMonedaID varchar(20), 
            //@MonedaID int,                        
            //@TipoCambio varchar(10)
        }

        public bool setCreaAsientoDetalle(String EstablecimientoID, String Periodo, String AsientoContableDetalleID, string AsientoContableID, Decimal MontoDebe, Decimal MontoHaber, String CanalContableID, Int32 EmpresaID, Int32 TipoDocumentoID, Int32 ProyectoID, DateTime Dia, String Referencia, DateTime FechaEmision, DateTime FechaVencimiento, Int32 AreaID, String NumeroDocumento, String TransaccionDocumentoID, Int32 FlujoCajaID, String PlanCuentaID, Decimal ImporteSoles, Decimal ImporteDolares, String AsientoContableDetalleIDTransferencia, String PeriodoID, String TablaMovimientoIDAsientos, Int32[] UnidadNegocioId, Decimal[] UNImporteSoles, Decimal[] UNImporteDolares, String TipoConversionMonedaID, Int32 MonedaID, String TipoCambio)
        {

            string query = "UCO_AsientosContablesDetalle_CreaoModifica";

            SqlCommand comando = new SqlCommand(query);

            comando.Parameters.Add(new SqlParameter("@EstablecimientoID", EstablecimientoID));
            comando.Parameters.Add(new SqlParameter("@Periodo", Periodo));
            comando.Parameters.Add(new SqlParameter("@AsientoContableDetalleID", AsientoContableDetalleID));
            comando.Parameters.Add(new SqlParameter("@AsientoContableID", AsientoContableID));
            comando.Parameters.Add(new SqlParameter("@MontoDebe", MontoDebe));
            comando.Parameters.Add(new SqlParameter("@MontoHaber", MontoHaber));
            comando.Parameters.Add(new SqlParameter("@CanalContableID", CanalContableID));
            comando.Parameters.Add(new SqlParameter("@EmpresaID", EmpresaID));
            comando.Parameters.Add(new SqlParameter("@TipoDocumentoID", TipoDocumentoID));
            comando.Parameters.Add(new SqlParameter("@ProyectoID", ProyectoID));
            comando.Parameters.Add(new SqlParameter("@Dia", Dia));
            //campo de referencia se cambia para pruebas a plancuentaid
            comando.Parameters.Add(new SqlParameter("@Referencia", Referencia));
            //campo de referencia se cambia para pruebas a plancuentaid
            comando.Parameters.Add(new SqlParameter("@FechaEmision", FechaEmision));
            comando.Parameters.Add(new SqlParameter("@FechaVencimiento", FechaVencimiento));
            comando.Parameters.Add(new SqlParameter("@AreaID", AreaID));
            comando.Parameters.Add(new SqlParameter("@NumeroDocumento", NumeroDocumento));
            comando.Parameters.Add(new SqlParameter("@TransaccionDocumentoID", TransaccionDocumentoID));
            comando.Parameters.Add(new SqlParameter("@FlujoCajaID", FlujoCajaID));

            if ((PlanCuentaID.Trim().Length == 0) || (PlanCuentaID.Trim() == "0") || (PlanCuentaID == null))
            {
                return false;
            }

            comando.Parameters.Add(new SqlParameter("@PlanCuentaID", PlanCuentaID));
            comando.Parameters.Add(new SqlParameter("@ImporteSoles", ImporteSoles));
            comando.Parameters.Add(new SqlParameter("@ImporteDolares", ImporteDolares));
            comando.Parameters.Add(new SqlParameter("@AsientoContableDetalleIDTransferencia", AsientoContableDetalleIDTransferencia));
            comando.Parameters.Add(new SqlParameter("@PeriodoID", PeriodoID));
            comando.Parameters.Add(new SqlParameter("@TablaMovimientoIDAsientos", TablaMovimientoIDAsientos));

            for (Int32 _num = 1; _num <= 10; _num++)
            {

                comando.Parameters.Add(new SqlParameter("@UnidadNegocioID_" + _num.ToString(), UnidadNegocioId[_num - 1]));
                if (Convert.ToInt32(UnidadNegocioId[_num - 1]) != 0)
                {
                    comando.Parameters.Add(new SqlParameter("@ImporteSoles_" + _num.ToString(), UNImporteSoles[_num - 1]));
                    comando.Parameters.Add(new SqlParameter("@ImporteDolares_" + _num.ToString(), UNImporteDolares[_num - 1]));
                }
                else
                {
                    comando.Parameters.Add(new SqlParameter("@ImporteSoles_" + _num.ToString(), 0));
                    comando.Parameters.Add(new SqlParameter("@ImporteDolares_" + _num.ToString(), 0));
                }

            }

            comando.Parameters.Add(new SqlParameter("@TipoConversionMonedaID", TipoConversionMonedaID));
            comando.Parameters.Add(new SqlParameter("@MonedaID", MonedaID));
            comando.Parameters.Add(new SqlParameter("@TipoCambio", TipoCambio));

            comando.Connection = new SqlConnection(Connection.connectionString());

            comando.CommandType = CommandType.StoredProcedure;

            comando.Connection.Open();


            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public DataSet AsientoContable_Listar(String AsientoContableID, String EstablecimientoID, String Periodo)
        {
            String query = "UCO_AsientoContable_Listar";

            SqlParameter[] parametros = {
                                        new SqlParameter("@EstablecimientoID",EstablecimientoID),
                                        new SqlParameter("@Periodo",Periodo),
                                        new SqlParameter("@AsientoContableID",AsientoContableID)
                                    };
            return SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros);
        }

        public Boolean Conciliacion(String EstablecimientoID, String Periodo, String Datos, String Por, Int32 HotelID, DateTime fechaConciliacion)
        {
            string query = "UCO_AsientoContable_Conciliacion";

            SqlParameter[] parametros = {
                                        new SqlParameter("@EstablecimientoId",EstablecimientoID),
                                        new SqlParameter("@Periodo",Periodo),
                                        new SqlParameter("@Datos",Datos),
                                        new SqlParameter("@Por",Por),
                                        new SqlParameter("@HotelId",HotelID),
                                        new SqlParameter("@FechaConciliacion",fechaConciliacion)
                                    };
            SqlHelper.ExecuteDataset(Connection.connectionString(), query, parametros);
            return true;
        }

        public String nombreSubDiario(String subDiarioId)
        {
            string query = "UCO_NombreSubDiario";

            SqlParameter[] parametros = {
                                        new SqlParameter("@subDiarioId",subDiarioId)
                                    };

            return Convert.ToString(SqlHelper.ExecuteScalar(Connection.connectionString(), query, parametros));
        }

        public DataTable inconsistenciasImportar(int EstablecimientoID, int Periodo, int Mes, string SubDiarioID)
        {

            string query = "UCO_InconsistenciasImportar";

            SqlConnection conexion = new SqlConnection(Connection.connectionString());

            SqlCommand comandoSQL = new SqlCommand(query);

            comandoSQL.CommandTimeout = 36000;
            comandoSQL.Connection = conexion;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            comandoSQL.Parameters.Add(new SqlParameter("@EstablecimientoID", EstablecimientoID));

            comandoSQL.Parameters.Add(new SqlParameter("@Periodo", Periodo));

            comandoSQL.Parameters.Add(new SqlParameter("@Mes", Mes));

            comandoSQL.Parameters.Add(new SqlParameter("@SubDiarioID", SubDiarioID));

            try
            {
                SqlDataReader lector = comandoSQL.ExecuteReader();

                DataTable tabla = new DataTable();

                tabla.Load(lector);

                conexion.Close();

                return tabla;



            }
            catch
            {
                return new DataTable();

            }

        }

        public bool exportarAsientos(int EstablecimientoID, int Ejercicio, int Periodo, string SubDiarioID, bool BorrarTablas)
        {

            string query = "UCO_Exportar";

            SqlConnection conexion = new SqlConnection(Connection.connectionString());

            SqlCommand comandoSQL = new SqlCommand(query);

            comandoSQL.CommandTimeout = 36000;
            comandoSQL.Connection = conexion;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            comandoSQL.Parameters.Add(new SqlParameter("@EstablecimientoID", EstablecimientoID));

            comandoSQL.Parameters.Add(new SqlParameter("@Ejercicio", Ejercicio));

            comandoSQL.Parameters.Add(new SqlParameter("@Periodo", Periodo));

            comandoSQL.Parameters.Add(new SqlParameter("@SubDiarioID", SubDiarioID));

            comandoSQL.Parameters.Add(new SqlParameter("@BorrarTablas", BorrarTablas));


            try
            {
                comandoSQL.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool importarAsientos(int EstablecimientoID, int Periodo, string SubDiarioID, int Mes, int HotelID, int UsuarioID, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo)
        {

            string query = "UCO_Importar_2";

            SqlConnection conexion = new SqlConnection(Connection.connectionString());

            SqlCommand comandoSQL = new SqlCommand(query);

            comandoSQL.CommandTimeout = 36000;
            comandoSQL.Connection = conexion;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            comandoSQL.Parameters.Add(new SqlParameter("@EstablecimientoID", EstablecimientoID));

            comandoSQL.Parameters.Add(new SqlParameter("@Periodo", Periodo));

            comandoSQL.Parameters.Add(new SqlParameter("@SubDiarioID", SubDiarioID));

            comandoSQL.Parameters.Add(new SqlParameter("@Mes", Mes));

            comandoSQL.Parameters.Add(new SqlParameter("@HotelID", HotelID));

            comandoSQL.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));

            comandoSQL.Parameters.Add(new SqlParameter("@IPEquipo", IPEquipo));

            comandoSQL.Parameters.Add(new SqlParameter("@UsuarioActualEquipo", UsuarioActualEquipo));

            comandoSQL.Parameters.Add(new SqlParameter("@NombreEquipo", NombreEquipo));

            try
            {
                comandoSQL.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        public DataTable consolidadoDiarioAuxiliar(string empresa, int ejercicio, int subDiarioID, int unidadNegocioID, int hotelID, int areaID, DateTime fechaInicio, DateTime fechaFin, string asientoContableDetalleIDTransferencia, string codigoPlanCuenta1, string codigoPlanCuenta2)
        {
            string query = "UCO_ConsolidadoAsientosContables_Select";

            SqlConnection conexion = new SqlConnection(Connection.connectionString());

            SqlCommand comandoSQL = new SqlCommand(query);

            comandoSQL.CommandTimeout = 36000;
            comandoSQL.Connection = conexion;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            comandoSQL.Parameters.Add(new SqlParameter("@Empresa", empresa));

            comandoSQL.Parameters.Add(new SqlParameter("@Ejercicio", ejercicio));

            comandoSQL.Parameters.Add(new SqlParameter("@SubDiarioID", subDiarioID));

            comandoSQL.Parameters.Add(new SqlParameter("@UnidadNegocioID", unidadNegocioID));

            comandoSQL.Parameters.Add(new SqlParameter("@HotelID", hotelID));

            comandoSQL.Parameters.Add(new SqlParameter("@AreaID", areaID));

            comandoSQL.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));

            comandoSQL.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));

            comandoSQL.Parameters.Add(new SqlParameter("@AsientocontableDetalleIDTransferencia", asientoContableDetalleIDTransferencia));

            comandoSQL.Parameters.Add(new SqlParameter("@codigoPlanCuenta1", codigoPlanCuenta1));

            comandoSQL.Parameters.Add(new SqlParameter("@codigoPlanCuenta2", codigoPlanCuenta2));

            try
            {
                SqlDataReader lector = comandoSQL.ExecuteReader();

                DataTable tabla = new DataTable();

                tabla.Load(lector);

                return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable();
            }
        }
    }
}
