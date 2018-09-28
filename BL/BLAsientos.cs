using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AD;

namespace BL
{
    public class BLAsientos
    {

        private ADAsientos objADAsientos;
        public BLAsientos()
        {
            objADAsientos = new ADAsientos();
        }
        public DataTable estadosCuenta(Int32 empresaId, String ejercicio, DateTime fechaInicio, DateTime fechaFin, String ruc, Int32 moneda, String planCuentaListBox)
        {
            String add = (string.IsNullOrEmpty(ruc)) ? "" : " AND ACD.EmpresaID = [dbo].[FN_EMPRESAID_PORRUC](" + ruc + ")";
            String whereCondition = "";
            //if (planCuentaInicio.Trim() == "0" && planCuentaFin.Trim() == "0")
            if (planCuentaListBox.Trim() == "0")
            {
                if (moneda == 0)
                {
                    whereCondition = " (Convert(varchar(8),'" + fechaFin + "', 112)) " + add;
                }
                else
                {
                    whereCondition = "(ACD.MonedaID = '" + moneda + "')" + add;
                }
            }
            else
            {
                if (moneda == 0)
                {
                    whereCondition = "  (ACD.plancuentaid IN (" + planCuentaListBox + "))" + add;
                }
                else
                {
                    whereCondition = "   (ACD.plancuentaid IN (" + planCuentaListBox + ")) AND (ACD.MonedaID = '" + moneda + "')" + add;
                }

            }

            String orderByExpression = "ORDER BY PlanDeCuentas.CodigoPlanCuenta, ACD.EmpresaID, ACD.TipoDocumentoID, ACD.NumeroDocumento";

            return objADAsientos.estadosCuenta(empresaId, ejercicio, whereCondition, orderByExpression, fechaFin);
        }

        public DataTable estadosCuentaSaldos(Int32 empresaId, String ejercicio, DateTime fechaInicio, DateTime fechaFin,
            String ruc, Decimal SaldoMinimo, Int32 moneda, String planCuentaListBox)
        {
            String add = (string.IsNullOrEmpty(ruc)) ? "" : " and ACD.EmpresaID = [dbo].[FN_EMPRESAID_PORRUC](" + ruc + ") ";
            String where_saldo = "";
            if (SaldoMinimo == 0)
            {
                where_saldo = "";
            }
            else
            {
                where_saldo = " and (Sum(Case When ACD.MontoDebe > 0 Then ACD.ImporteSoles Else 0 End))>0 AND ";
                where_saldo = where_saldo + " (Sum(Case When ACD.MontoDebe > 0 Then 0 Else ACD.ImporteSoles  End)) > 0 and";
                where_saldo = where_saldo + " (Sum((Case When ACD.MontoDebe > 0 Then ACD.ImporteSoles Else 0 End)) - Sum((Case When ACD.MontoDebe > 0 Then 0 Else ACD.ImporteSoles  End))) <= " + SaldoMinimo.ToString();
                where_saldo = where_saldo + " and (Sum((Case When ACD.MontoDebe > 0 Then ACD.ImporteSoles Else 0 End)) - Sum((Case When ACD.MontoDebe > 0 Then 0 Else ACD.ImporteSoles  End))) >= " + (-1 * SaldoMinimo).ToString();
            }
            String whereCondition = "";
            //if (planCuentaInicio.Trim() == "0" && planCuentaFin.Trim() == "0")
            if (planCuentaListBox.Trim() == "0")
            {
                if (moneda == 0)
                {
                    if ((fechaInicio.Month == 1) && (fechaInicio.Day == 1))
                    {
                        whereCondition = "  " + add;
                        //convert(varchar(8), getdate(),112)
                    }
                    else
                    {
                        whereCondition = " " + add;
                    }

                }
                else
                {
                    if ((fechaInicio.Month == 1) && (fechaInicio.Day == 1))
                    {
                        whereCondition = "  (ACD.MonedaID = '" + moneda + "')" + add;
                    }
                    else
                    {
                        whereCondition = " (ACD.MonedaID = '" + moneda + "')" + add;
                    }
                }
            }
            else
            {
                if (moneda == 0)
                {
                    if ((fechaInicio.Month == 1) && (fechaInicio.Day == 1))
                    {
                        whereCondition = "  (ACD.plancuentaid IN (" + planCuentaListBox + "))" + add;

                        string D = fechaFin.ToString("yyyyMMdd");

                    }
                    else
                    {
                        whereCondition = "  (ACD.plancuentaid IN (" + planCuentaListBox + "))" + add;
                    }
                }
                else
                {
                    if ((fechaInicio.Month == 1) && (fechaInicio.Day == 1))
                    {
                        whereCondition = "  (ACD.plancuentaid IN (" + planCuentaListBox + ")) AND (ACD.MonedaID = '" + moneda + "')" + add;
                    }
                    else
                    {
                        whereCondition = " (ACD.plancuentaid IN (" + planCuentaListBox + ")) AND (ACD.MonedaID = '" + moneda + "')" + add;
                    }

                }
            }
            String orderByExpression = "ORDER BY PlanDeCuentas.CodigoPlanCuenta, ACD.EmpresaID, ACD.TipoDocumentoID, ACD.NumeroDocumento";
            //se reemplazo la clausula order para modificar la having porque no se aplica en el procedimiento, tal vez proximamente se podría agregar otro parametro para el having
            orderByExpression = where_saldo;
            return objADAsientos.estadosCuentaSaldos(empresaId, ejercicio, whereCondition, orderByExpression, fechaFin);
        }

        public DataTable estadosCuentaSaldosHistoricos(Int32 empresaId, String ejercicio, DateTime fechaInicio, DateTime fechaFin, String ruc, Int32 moneda, String planCuentaListBox)
        {
            //ACD.MonedaID
            String add = (string.IsNullOrEmpty(ruc)) ? "" : " and ACD.EmpresaID = [dbo].[FN_EMPRESAID_PORRUC](" + ruc + ")";
            //String whereCondition = "(ACD.Dia BETWEEN '" + fechaInicio.ToString("dd/MM/yy") + "' AND '" + fechaFin.ToString("dd/MM/yy") + "') AND (CodigoPlanCuenta BETWEEN '" + planCuentaInicio + "' AND '" + planCuentaFin + "')" + add;
            String whereCondition = "";
            if (moneda == 0)
            {
                whereCondition = "  (ACD.plancuentaid IN (" + planCuentaListBox + "))" + add;
            }
            else
            {
                whereCondition = "  (ACD.plancuentaid IN (" + planCuentaListBox + ")) AND (ACD.MonedaID = '" + moneda + "')" + add;
            }


            String orderByExpression = "ORDER BY PlanDeCuentas.CodigoPlanCuenta, ACD.EmpresaID, ACD.TipoDocumentoID, ACD.NumeroDocumento";
            //se reemplazo la clausula order para modificar la having porque no se aplica en el procedimiento, tal vez proximamente se podría agregar otro parametro para el having
            //        orderByExpression = where_saldo;
            return objADAsientos.estadosCuentaSaldosHistoricos(empresaId, ejercicio, whereCondition, orderByExpression,fechaFin);
        }

        public DataTable subdiarios(bool opcionTodos)
        {
            return objADAsientos.subdiarios(opcionTodos);
        }
        public DataTable asientosContables(String empresaId, String ejercicio, DateTime desde, DateTime hasta, String subdiarioId, Int32 hotelId)
        {
            return objADAsientos.asientosContables(empresaId, ejercicio, desde, hasta, subdiarioId, hotelId);
        }

        public DataTable asientosContables(String empresaId, String ejercicio, DateTime desde, DateTime hasta, string planCuentaID1, string planCuentaID2, String subdiarioId, Int32 hotelId)
        {
            return objADAsientos.asientosContables(empresaId, ejercicio, desde, hasta, planCuentaID1, planCuentaID2, subdiarioId, hotelId);
        }

        public DataTable consolidadoAsientosContables(String empresaId, String ejercicio, String subDiarioID, Int32 unidadNegocioID, Int32 hotelId, Int32 areaID, DateTime desde, DateTime hasta, string planCuentaID1, string planCuentaID2)
        {
            return objADAsientos.consolidadoAsientosContables(empresaId, ejercicio, subDiarioID, unidadNegocioID, hotelId, areaID, desde, hasta, "", planCuentaID1, planCuentaID2);
        }

        public bool transferenciaVentas(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {

            return objADAsientos.transferenciaVentas(desde, hasta, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }

        public bool transferenciaCobranzas(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            return objADAsientos.transferenciaCobranzas(desde, hasta, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }

        public bool transferenciaCompras(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            return objADAsientos.transferenciaCompras(desde, hasta, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }

        public bool transferenciaSalidas(DateTime desde, DateTime hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            return objADAsientos.transferenciaSalidas(desde, hasta, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }

        public bool transferenciaDevegueGastos(String PeriodoFiltro, String MesFiltro, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            return objADAsientos.transferenciaDevegueGastos(PeriodoFiltro, MesFiltro, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }
        public bool transferenciaDevegueVentas(DateTime Desde, DateTime Hasta, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            return objADAsientos.transferenciaDevegueVentas(Desde, Hasta, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }
        public bool transferenciaPlanillas(DateTime fecha, string tipoProvision, int usuarioID, string movimiento, string ipEquipo, string usuarioActualEquipo, string nombreEquipo)
        {
            return objADAsientos.transferenciaPlanillas(fecha, tipoProvision, usuarioID, movimiento, ipEquipo, usuarioActualEquipo, nombreEquipo);
        }

        public bool transferenciaTesoreria(DateTime desde, DateTime hasta, int usuarioID)
        {
            return objADAsientos.transferenciaTesoreria(desde, hasta,usuarioID);
        }

        public bool procesosCalculoDiferenciaCambio(DateTime fecha, string EstablecimientoId, string Periodo, string HotelId)
        {
            return objADAsientos.procesosCalculoDiferenciaCambio(fecha, EstablecimientoId, Periodo, HotelId);
        }

        public bool procesosUCO_CierrePeriodoProcede(string Ejercicio, string Establecimiento)
        {
            return objADAsientos.procesosUCO_CierrePeriodoProcede(Ejercicio, Establecimiento);
        }

        public bool eliminarVoucher(string EstablecimientoID, string Periodo, string AsientoContableID, Int32 UsuarioID, Int32 UsuarioIdAutorizado, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo, string TablaMovimientoID, int HotelID)
        {
            return objADAsientos.eliminarVoucher(EstablecimientoID, Periodo, AsientoContableID, UsuarioID, UsuarioIdAutorizado, IPEquipo, UsuarioActualEquipo, NombreEquipo, TablaMovimientoID, HotelID);
        }

        public bool eliminarVoucherTodos(string EstablecimientoID, string Periodo, DateTime Desde, DateTime Hasta, string SubDiarioId, Int32 UsuarioID, Int32 UsuarioIdAutorizado, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo, string TablaMovimientoID, int HotelID)
        {
            return objADAsientos.eliminarVoucherTodos(EstablecimientoID, Periodo, Desde, Hasta, SubDiarioId, UsuarioID, UsuarioIdAutorizado, IPEquipo, UsuarioActualEquipo, NombreEquipo, TablaMovimientoID, HotelID);
        }


        public Boolean subdiarioEsAutomatico(String SubDiarioID)
        {
            return objADAsientos.SubDiarioEsAutomatico(SubDiarioID);
        }

        public DataSet inconsistencias(Int32 establecimientoID, Int32 periodo)
        {

            return objADAsientos.inconsistencias(establecimientoID, periodo);
        }

        public String setCreaAsientoCabecera(String NomCabecera, String Empresa, String Anio, String AsientoContableID, String SubDiarioID, Int32 HotelID, String Glosa, String Comprobante, DateTime FechaEmision, Int32 UsuarioID, Int32 UsuarioIdAutorizado, String IPEquipo, String UsuarioActualEquipo, String NombreEquipo, String TablaMovimientoID, Int32 Bloqueado)
        {
            return objADAsientos.setCreaAsientoCabecera(NomCabecera, Empresa, Anio, AsientoContableID, SubDiarioID, HotelID, Glosa, Comprobante, FechaEmision, UsuarioID, UsuarioIdAutorizado, IPEquipo, UsuarioActualEquipo, NombreEquipo, TablaMovimientoID, Bloqueado);
        }

        public bool setCreaAsientoDetalle(String EstablecimientoID, String Periodo, String AsientoContableDetalleID, string AsientoContableID, Decimal MontoDebe, Decimal MontoHaber, String CanalContableID, Int32 EmpresaID, Int32 TipoDocumentoID, Int32 ProyectoID, DateTime Dia, String Referencia, DateTime FechaEmision, DateTime FechaVencimiento, Int32 AreaID, String NumeroDocumento, String TransaccionDocumentoID, Int32 FlujoCajaID, String PlanCuentaID, Decimal ImporteSoles, Decimal ImporteDolares, String AsientoContableDetalleIDTransferencia, String PeriodoID, String TablaMovimientoIDAsientos, Int32 UnidadNegocioId_1, Decimal ImporteSoles_1, Decimal ImporteDolares_1, Int32 UnidadNegocioId_2, Decimal ImporteSoles_2, Decimal ImporteDolares_2, Int32 UnidadNegocioId_3, Decimal ImporteSoles_3, Decimal ImporteDolares_3, Int32 UnidadNegocioId_4, Decimal ImporteSoles_4, Decimal ImporteDolares_4, Int32 UnidadNegocioId_5, Decimal ImporteSoles_5, Decimal ImporteDolares_5, Int32 UnidadNegocioId_6, Decimal ImporteSoles_6, Decimal ImporteDolares_6, Int32 UnidadNegocioId_7, Decimal ImporteSoles_7, Decimal ImporteDolares_7, Int32 UnidadNegocioId_8, Decimal ImporteSoles_8, Decimal ImporteDolares_8, Int32 UnidadNegocioId_9, Decimal ImporteSoles_9, Decimal ImporteDolares_9, Int32 UnidadNegocioId_10, Decimal ImporteSoles_10, Decimal ImporteDolares_10, String TipoConversionMonedaID, Int32 MonedaID, String TipoCambio)
        {
            return objADAsientos.setCreaAsientoDetalle(EstablecimientoID, Periodo, AsientoContableDetalleID, AsientoContableID, MontoDebe, MontoHaber, CanalContableID, EmpresaID, TipoDocumentoID, ProyectoID, Dia, Referencia, FechaEmision, FechaVencimiento, AreaID, NumeroDocumento, TransaccionDocumentoID, FlujoCajaID, PlanCuentaID, ImporteSoles, ImporteDolares, AsientoContableDetalleIDTransferencia, PeriodoID, TablaMovimientoIDAsientos, UnidadNegocioId_1, ImporteSoles_1, ImporteDolares_1, UnidadNegocioId_2, ImporteSoles_2, ImporteDolares_2, UnidadNegocioId_3, ImporteSoles_3, ImporteDolares_3, UnidadNegocioId_4, ImporteSoles_4, ImporteDolares_4, UnidadNegocioId_5, ImporteSoles_5, ImporteDolares_5, UnidadNegocioId_6, ImporteSoles_6, ImporteDolares_6, UnidadNegocioId_7, ImporteSoles_7, ImporteDolares_7, UnidadNegocioId_8, ImporteSoles_8, ImporteDolares_8, UnidadNegocioId_9, ImporteSoles_9, ImporteDolares_9, UnidadNegocioId_10, ImporteSoles_10, ImporteDolares_10, TipoConversionMonedaID, MonedaID, TipoCambio);
        }

        public bool setCreaAsientoDetalle(String EstablecimientoID, String Periodo, String AsientoContableDetalleID, string AsientoContableID, Decimal MontoDebe, Decimal MontoHaber, String CanalContableID, Int32 EmpresaID, Int32 TipoDocumentoID, Int32 ProyectoID, DateTime Dia, String Referencia, DateTime FechaEmision, DateTime FechaVencimiento, Int32 AreaID, String NumeroDocumento, String TransaccionDocumentoID, Int32 FlujoCajaID, String PlanCuentaID, Decimal ImporteSoles, Decimal ImporteDolares, String AsientoContableDetalleIDTransferencia, String PeriodoID, String TablaMovimientoIDAsientos, Int32[] UnidadNegocioId, Decimal[] UNImporteSoles, Decimal[] UNImporteDolares, String TipoConversionMonedaID, Int32 MonedaID, String TipoCambio)
        {
            if ((PlanCuentaID != null) || (PlanCuentaID.Trim() != "") || (PlanCuentaID.Trim() != "0"))
            {
                return objADAsientos.setCreaAsientoDetalle(EstablecimientoID, Periodo, AsientoContableDetalleID, AsientoContableID, MontoDebe, MontoHaber, CanalContableID, EmpresaID, TipoDocumentoID, ProyectoID, Dia, Referencia, FechaEmision, FechaVencimiento, AreaID, NumeroDocumento, TransaccionDocumentoID, FlujoCajaID, PlanCuentaID, ImporteSoles, ImporteDolares, AsientoContableDetalleIDTransferencia, PeriodoID, TablaMovimientoIDAsientos, UnidadNegocioId, UNImporteSoles, UNImporteDolares, TipoConversionMonedaID, MonedaID, TipoCambio);
            }
            else
            {
                return false;
            }
        }

        public DataSet AsientoContable_Listar(String AsientoContableID, String EstablecimientoID, String Periodo)
        {
            return objADAsientos.AsientoContable_Listar(AsientoContableID, EstablecimientoID, Periodo);
        }

        public Boolean Conciliacion(String EstablecimientoID, String Periodo, String Datos, String Por, Int32 HotelID, DateTime fechaConciliacion)
        {
            return objADAsientos.Conciliacion(EstablecimientoID, Periodo, Datos, Por, HotelID, fechaConciliacion);
        }

        public String nombreSubDiario(String subDiarioId)
        {
            return objADAsientos.nombreSubDiario(subDiarioId);
        }

        public bool eliminarDetalle(string EstablecimientoID, string Periodo, string AsientoContableID, string AsientoContableDetalleID, Int32 UsuarioID, Int32 UsuarioIdAutorizado, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo, string TablaMovimientoID, int HotelID)
        {
            return objADAsientos.eliminarDetalle(EstablecimientoID, Periodo, AsientoContableID, AsientoContableDetalleID, UsuarioID, UsuarioIdAutorizado, IPEquipo, UsuarioActualEquipo, NombreEquipo, TablaMovimientoID, HotelID);
        }


        public DataTable inconsistenciasImportar(int EstablecimientoID, int Periodo, int Mes, string SubDiarioID)
        {
            return objADAsientos.inconsistenciasImportar(EstablecimientoID, Periodo, Mes, SubDiarioID);
        }

        public bool exportarAsientos(int EstablecimientoID, int Ejercicio, int Periodo, string SubDiarioID, bool BorrarTablas)
        {
            return objADAsientos.exportarAsientos(EstablecimientoID, Ejercicio, Periodo, SubDiarioID, BorrarTablas);
        }

        public bool importarAsientos(int EstablecimientoID, int Periodo, string SubDiarioID, int Mes, int HotelID, int UsuarioID, string IPEquipo, string UsuarioActualEquipo, string NombreEquipo)
        {
            return objADAsientos.importarAsientos(EstablecimientoID, Periodo, SubDiarioID, Mes, HotelID, UsuarioID, IPEquipo, UsuarioActualEquipo, NombreEquipo);
        }

        public DataTable consolidadoDiarioAuxiliar(string empresa, int ejercicio, int subDiarioID, int unidadNegocioID, int hotelID, int areaID, DateTime fechaInicio, DateTime fechaFin, string asientoContableDetalleIDTransferencia, string codigoPlanCuenta1, string codigoPlanCuenta2)
        {
            return objADAsientos.consolidadoDiarioAuxiliar(empresa, ejercicio, subDiarioID, unidadNegocioID, hotelID, areaID, fechaInicio, fechaFin, asientoContableDetalleIDTransferencia, codigoPlanCuenta1, codigoPlanCuenta2);
        }

    }
}
