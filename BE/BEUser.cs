using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
  public partial class BEUser
  {
    private Int32 _usuarioID;
    private String _nombreUsuario;
    private String _clave;
    private Int32 _areaId;
    private Int32 _transaccionUsuarioId;
    private Int32 _actualizatipocambio;
    private Int32 _modificatipocambiocancelacion;
    private Int32 _acceso;
    private Int32 _apruebaSolicitudes;
    private Int32 _estado;
    private Int32 _cargoId;
    private String _codigoCentralTelefonica;
    private Int16 _autorizaPedidos;
    private Int16 _listoPedidos;
    private Int16 _modificaFechaLiquidacion;
    private Int16 _caja;
    private Single _topePorcentageTarifa;
    private Int16 _entregaEncargo;
    private Int16 _informeVentas;
    private Int16 _actualizaCanjes;
    private String _planillaVoucherID;
    private Int16 _cierreDiaAuditoria;
    private Int16 _verAlertas;
    private Int16 _reaperturaMesaBloqueada;
    private Int16 _autorizaCredito;
    private Int16 _autorizaCambiaEstadoFueraServicio;
    private Int16 _autorizaCambiaEstadoLimpieza;
    private Int16 _modificaFechaEmisionDocumento;
    private Int16 _autorizaEliminaFormaPago;
    private Int16 _cambioProducto;
    private Int16 _modificaNumeroDocumento;
    private Int16 _modificaPreciosTarifas;
    private Int16 _activaDocumentoAnulado;
    private String _nomenclatura;
    private Int16 _anulaDocumento;
    private Int16 _anulaComanda;
    private Int16 _anulaRecibo;
    private Int16 _anulaReservaEvento;
    private Int16 _anulaReservaAlojamiento;
    private Int16 _autorizaConciliar;
    private Int16 _autorizaPaidOutConImpuestos;
    private Int16 _productosVenta;
    private Int16 _checkIn;
    private Int16 _maestroArticulos;
    private Int16 _actualizaSGC;
    private Int16 _confirmaEventos;
    private Int16 _cerrarVoucher;
    private Int16 _tentativoEventos;
    private Int16 _cambiaMovimientoEmpresa;
    private Int16 _modificaUnidad;
    private Int16 _anulaPedidos;
    private Int16 _anulaSalidas;
    private Int16 _cambiaPuntoVentaSalida;
    private Int16 _transferenciaRecibos;
    private Int16 _entregaPedidosCualquierArea;
    private Int16 _cargoEgresosPaxSeRetiro;
    private Int16 _transfiereConsumos;
    private Int16 _cierreTemporalPedidosInventarios;
    private Int16 _modificaAgregaProductos;
    private Int16 _cambiaResponsableEmpresa;
    private Int16 _correoDocumentoAnulado;
    private Int16 _correoReciboAnulado;
    private Int16 _correoFormaPagoAnulado;
    private Int16 _asignaTarifas;
    private Int16 _anulaDocumentoDiaCerrado;
    private Int16 _anulaDocumentoConNotaCredito;
    private Int16 _liberarHabitacionAntesdelaSalida;
    private Int32 _diasVenceClave;
    private DateTime _diaVencimientoClave;
    private Int16 _verLlamadasEntrantes;
    private Int16 _verLlamadasSalientes;
    private Int16 _verLlamadasEntreAnexos;
    private Int16 _eliminaProductoComanda;
    private Int16 _permiteVerTodasLasLlamadas;
    private Int16 _cierreMensualTelefonia;
    private Int32 _responsableID;
    private Int16 _registroRetenciones;
    private Int32 _TrabajadorID;
    private Int32 _perfilID;
    private Int32 _ingresoManual;

    public Int32 UsuarioID
    {
      get{return _usuarioID;}
      set{_usuarioID = value;}
    }
    public String NombreUsuario
    {
      get{return _nombreUsuario;}
      set{_nombreUsuario = value;}
    }
    public String Clave
    {
      get{return _clave;}
      set{_clave = value;}
    }
    public Int32 AreaId
    {
      get{return _areaId;}
      set{_areaId = value;}
    }
    public Int32 TransaccionUsuarioId
    {
      get{return _transaccionUsuarioId;}
      set{_transaccionUsuarioId = value;}
    }
    public Int32 Actualizatipocambio
    {
      get{return _actualizatipocambio;}
      set{_actualizatipocambio = value;}
    }
    public Int32 Modificatipocambiocancelacion
    {
      get{return _modificatipocambiocancelacion;}
      set{_modificatipocambiocancelacion = value;}
    }
    public Int32 Acceso
    {
      get{return _acceso;}
      set{_acceso = value;}
    }
    public Int32 ApruebaSolicitudes
    {
      get{return _apruebaSolicitudes;}
      set{_apruebaSolicitudes = value;}
    }
    public Int32 Estado
    {
      get{return _estado;}
      set{_estado = value;}
    }
    public Int32 CargoId
    {
      get{return _cargoId;}
      set{_cargoId = value;}
    }
    public String CodigoCentralTelefonica
    {
      get
      {
        return _codigoCentralTelefonica;
      }
      set
      {
        _codigoCentralTelefonica = value;
      }
    }
    public Int16 AutorizaPedidos
    {
      get
      {
        return _autorizaPedidos;
      }
      set
      {
        _autorizaPedidos = value;
      }
    }
    public Int32 TrabajadorID
    {
      get { return _TrabajadorID; }
      set { _TrabajadorID = value; }
    }

    public Int16 ListoPedidos
    {
      get
      {
        return _listoPedidos;
      }
      set
      {
        _listoPedidos = value;
      }
    }
    public Int16 ModificaFechaLiquidacion
    {
      get
      {
        return _modificaFechaLiquidacion;
      }
      set
      {
        _modificaFechaLiquidacion = value;
      }
    }
    public Int16 Caja
    {
      get
      {
        return _caja;
      }
      set
      {
        _caja = value;
      }
    }
    public Single TopePorcentageTarifa
    {
      get
      {
        return _topePorcentageTarifa;
      }
      set
      {
        _topePorcentageTarifa = value;
      }
    }
    public Int16 EntregaEncargo
    {
      get
      {
        return _entregaEncargo;
      }
      set
      {
        _entregaEncargo = value;
      }
    }
    public Int16 InformeVentas
    {
      get
      {
        return _informeVentas;
      }
      set
      {
        _informeVentas = value;
      }
    }
    public Int16 ActualizaCanjes
    {
      get
      {
        return _actualizaCanjes;
      }
      set
      {
        _actualizaCanjes = value;
      }
    }
    public String PlanillaVoucherID
    {
      get
      {
        return _planillaVoucherID;
      }
      set
      {
        _planillaVoucherID = value;
      }
    }
    public Int16 CierreDiaAuditoria
    {
      get
      {
        return _cierreDiaAuditoria;
      }
      set
      {
        _cierreDiaAuditoria = value;
      }
    }
    public Int16 VerAlertas
    {
      get
      {
        return _verAlertas;
      }
      set
      {
        _verAlertas = value;
      }
    }
    public Int16 ReaperturaMesaBloqueada
    {
      get
      {
        return _reaperturaMesaBloqueada;
      }
      set
      {
        _reaperturaMesaBloqueada = value;
      }
    }
    public Int16 AutorizaCredito
    {
      get
      {
        return _autorizaCredito;
      }
      set
      {
        _autorizaCredito = value;
      }
    }
    public Int16 AutorizaCambiaEstadoFueraServicio
    {
      get
      {
        return _autorizaCambiaEstadoFueraServicio;
      }
      set
      {
        _autorizaCambiaEstadoFueraServicio = value;
      }
    }
    public Int16 AutorizaCambiaEstadoLimpieza
    {
      get
      {
        return _autorizaCambiaEstadoLimpieza;
      }
      set
      {
        _autorizaCambiaEstadoLimpieza = value;
      }
    }
    public Int16 ModificaFechaEmisionDocumento
    {
      get
      {
        return _modificaFechaEmisionDocumento;
      }
      set
      {
        _modificaFechaEmisionDocumento = value;
      }
    }
    public Int16 AutorizaEliminaFormaPago
    {
      get
      {
        return _autorizaEliminaFormaPago;
      }
      set
      {
        _autorizaEliminaFormaPago = value;
      }
    }
    public Int16 CambioProducto
    {
      get
      {
        return _cambioProducto;
      }
      set
      {
        _cambioProducto = value;
      }
    }
    public Int16 ModificaNumeroDocumento
    {
      get
      {
        return _modificaNumeroDocumento;
      }
      set
      {
        _modificaNumeroDocumento = value;
      }
    }
    public Int16 ModificaPreciosTarifas
    {
      get
      {
        return _modificaPreciosTarifas;
      }
      set
      {
        _modificaPreciosTarifas = value;
      }
    }
    public Int16 ActivaDocumentoAnulado
    {
      get
      {
        return _activaDocumentoAnulado;
      }
      set
      {
        _activaDocumentoAnulado = value;
      }
    }
    public String Nomenclatura
    {
      get
      {
        return _nomenclatura;
      }
      set
      {
        _nomenclatura = value;
      }
    }
    public Int16 AnulaDocumento
    {
      get
      {
        return _anulaDocumento;
      }
      set
      {
        _anulaDocumento = value;
      }
    }
    public Int16 AnulaComanda
    {
      get
      {
        return _anulaComanda;
      }
      set
      {
        _anulaComanda = value;
      }
    }
    public Int16 AnulaRecibo
    {
      get
      {
        return _anulaRecibo;
      }
      set
      {
        _anulaRecibo = value;
      }
    }
    public Int16 AnulaReservaEvento
    {
      get
      {
        return _anulaReservaEvento;
      }
      set
      {
        _anulaReservaEvento = value;
      }
    }
    public Int16 AnulaReservaAlojamiento
    {
      get
      {
        return _anulaReservaAlojamiento;
      }
      set
      {
        _anulaReservaAlojamiento = value;
      }
    }
    public Int16 AutorizaConciliar
    {
      get
      {
        return _autorizaConciliar;
      }
      set
      {
        _autorizaConciliar = value;
      }
    }
    public Int16 AutorizaPaidOutConImpuestos
    {
      get
      {
        return _autorizaPaidOutConImpuestos;
      }
      set
      {
        _autorizaPaidOutConImpuestos = value;
      }
    }
    public Int16 ProductosVenta
    {
      get
      {
        return _productosVenta;
      }
      set
      {
        _productosVenta = value;
      }
    }
    public Int16 CheckIn
    {
      get
      {
        return _checkIn;
      }
      set
      {
        _checkIn = value;
      }
    }
    public Int16 MaestroArticulos
    {
      get
      {
        return _maestroArticulos;
      }
      set
      {
        _maestroArticulos = value;
      }
    }
    public Int16 ActualizaSGC
    {
      get
      {
        return _actualizaSGC;
      }
      set
      {
        _actualizaSGC = value;
      }
    }
    public Int16 ConfirmaEventos
    {
      get
      {
        return _confirmaEventos;
      }
      set
      {
        _confirmaEventos = value;
      }
    }
    public Int16 CerrarVoucher
    {
      get
      {
        return _cerrarVoucher;
      }
      set
      {
        _cerrarVoucher = value;
      }
    }
    public Int16 TentativoEventos
    {
      get
      {
        return _tentativoEventos;
      }
      set
      {
        _tentativoEventos = value;
      }
    }
    public Int16 CambiaMovimientoEmpresa
    {
      get
      {
        return _cambiaMovimientoEmpresa;
      }
      set
      {
        _cambiaMovimientoEmpresa = value;
      }
    }
    public Int16 ModificaUnidad
    {
      get
      {
        return _modificaUnidad;
      }
      set
      {
        _modificaUnidad = value;
      }
    }
    public Int16 AnulaPedidos
    {
      get
      {
        return _anulaPedidos;
      }
      set
      {
        _anulaPedidos = value;
      }
    }
    public Int16 AnulaSalidas
    {
      get
      {
        return _anulaSalidas;
      }
      set
      {
        _anulaSalidas = value;
      }
    }
    public Int16 CambiaPuntoVentaSalida
    {
      get
      {
        return _cambiaPuntoVentaSalida;
      }
      set
      {
        _cambiaPuntoVentaSalida = value;
      }
    }
    public Int16 TransferenciaRecibos
    {
      get
      {
        return _transferenciaRecibos;
      }
      set
      {
        _transferenciaRecibos = value;
      }
    }
    public Int16 EntregaPedidosCualquierArea
    {
      get
      {
        return _entregaPedidosCualquierArea;
      }
      set
      {
        _entregaPedidosCualquierArea = value;
      }
    }
    public Int16 CargoEgresosPaxSeRetiro
    {
      get
      {
        return _cargoEgresosPaxSeRetiro;
      }
      set
      {
        _cargoEgresosPaxSeRetiro = value;
      }
    }
    public Int16 TransfiereConsumos
    {
      get
      {
        return _transfiereConsumos;
      }
      set
      {
        _transfiereConsumos = value;
      }
    }
    public Int16 CierreTemporalPedidosInventarios
    {
      get
      {
        return _cierreTemporalPedidosInventarios;
      }
      set
      {
        _cierreTemporalPedidosInventarios = value;
      }
    }
    public Int16 ModificaAgregaProductos
    {
      get
      {
        return _modificaAgregaProductos;
      }
      set
      {
        _modificaAgregaProductos = value;
      }
    }
    public Int16 CambiaResponsableEmpresa
    {
      get
      {
        return _cambiaResponsableEmpresa;
      }
      set
      {
        _cambiaResponsableEmpresa = value;
      }
    }
    public Int16 CorreoDocumentoAnulado
    {
      get
      {
        return _correoDocumentoAnulado;
      }
      set
      {
        _correoDocumentoAnulado = value;
      }
    }
    public Int16 CorreoReciboAnulado
    {
      get
      {
        return _correoReciboAnulado;
      }
      set
      {
        _correoReciboAnulado = value;
      }
    }
    public Int16 CorreoFormaPagoAnulado
    {
      get
      {
        return _correoFormaPagoAnulado;
      }
      set
      {
        _correoFormaPagoAnulado = value;
      }
    }
    public Int16 AsignaTarifas
    {
      get
      {
        return _asignaTarifas;
      }
      set
      {
        _asignaTarifas = value;
      }
    }
    public Int16 AnulaDocumentoDiaCerrado
    {
      get
      {
        return _anulaDocumentoDiaCerrado;
      }
      set
      {
        _anulaDocumentoDiaCerrado = value;
      }
    }
    public Int16 AnulaDocumentoConNotaCredito
    {
      get
      {
        return _anulaDocumentoConNotaCredito;
      }
      set
      {
        _anulaDocumentoConNotaCredito = value;
      }
    }
    public Int16 LiberarHabitacionAntesdelaSalida
    {
      get
      {
        return _liberarHabitacionAntesdelaSalida;
      }
      set
      {
        _liberarHabitacionAntesdelaSalida = value;
      }
    }
    public Int32 DiasVenceClave
    {
      get
      {
        return _diasVenceClave;
      }
      set
      {
        _diasVenceClave = value;
      }
    }
    public DateTime DiaVencimientoClave
    {
      get
      {
        return _diaVencimientoClave;
      }
      set
      {
        _diaVencimientoClave = value;
      }
    }
    public Int16 VerLlamadasEntrantes
    {
      get
      {
        return _verLlamadasEntrantes;
      }
      set
      {
        _verLlamadasEntrantes = value;
      }
    }
    public Int16 VerLlamadasSalientes
    {
      get
      {
        return _verLlamadasSalientes;
      }
      set
      {
        _verLlamadasSalientes = value;
      }
    }
    public Int16 VerLlamadasEntreAnexos
    {
      get
      {
        return _verLlamadasEntreAnexos;
      }
      set
      {
        _verLlamadasEntreAnexos = value;
      }
    }
    public Int16 EliminaProductoComanda
    {
      get
      {
        return _eliminaProductoComanda;
      }
      set
      {
        _eliminaProductoComanda = value;
      }
    }
    public Int16 PermiteVerTodasLasLlamadas
    {
      get
      {
        return _permiteVerTodasLasLlamadas;
      }
      set
      {
        _permiteVerTodasLasLlamadas = value;
      }
    }
    public Int16 CierreMensualTelefonia
    {
      get
      {
        return _cierreMensualTelefonia;
      }
      set
      {
        _cierreMensualTelefonia = value;
      }
    }
    public Int32 ResponsableID
    {
      get
      {
        return _responsableID;
      }
      set
      {
        _responsableID = value;
      }
    }
    public Int16 RegistroRetenciones
    {
      get
      {
        return _registroRetenciones;
      }
      set
      {
        _registroRetenciones = value;
      }
    }
    public Int32 PerfilID
    {
      get { return _perfilID; }
      set { _perfilID = value; }
    }
    public Int32 IngresoManual
    {
      get { return _ingresoManual; }
      set { _ingresoManual = value; }
    }
  }
}
