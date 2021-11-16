using Aplicacion.Constantes;
using IServicio.BaseDto;

namespace IServicio.Configuracion.DTOs
{
    public class ConfiguracionDto : DtoBase
    {
        // ====================================== //
        // ====    Datos de la Empresa     ====== //
        // ====================================== //
        public string RazonSocial { get; set; }

        public string NombreFantasia { get; set; }

        public string Cuit { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public long LocalidadId { get; set; }

        public long DepartamentoId { get; set; }

        public long ProvinciaId { get; set; }

        // ====================================== //
        // ==   Datos del Stock y Articulo     == //
        // ====================================== //

        public bool FacturaDescuentaStock { get; set; }

        public bool PresupuestoDescuentaStock { get; set; }

        public bool RemitoDescuentaStock { get; set; }

        public bool ActualizaCostoDesdeCompra { get; set; }

        public bool ModificaPrecioVentaDesdeCompra { get; set; }

        public long DepositoIdStock { get; set; }

        // ====================================== //
        // ==    Forma de Pago por defecto     == //
        // ====================================== //

        public TipoPago TipoFormaPagoPorDefectoVenta { get; set; }

        public TipoPago TipoFormaPagoPorDefectoCompra { get; set; }

        // ====================================== //
        // =========    Comprobante     ========= //
        // ====================================== //

        public string ObservacionEnPieFactura { get; set; }

        public bool UnificarRenglonesIngresarMismoProducto { get; set; }

        public long ListaPrecioPorDefectoId { get; set; }

        // ====================================== //
        // =========         Caja       ========= //
        // ====================================== //

        public bool IngresoManualCajaInicial { get; set; }

        public bool PuestoCajaSeparado { get; set; }

        public bool ActivarRetiroDeCaja { get; set; }

        // Propiedad para no permitir que tenga mas de un cierto
        // monto de dinero en la caja

        public decimal MontoMaximoRetiroCaja { get; set; }

        // ====================================== //
        // =========       Bascula      ========= //
        // ====================================== //

        public bool ActivarBascula { get; set; }

        public decimal ComienzoCodigo { get; set; }

        public bool PesoEnElCodigoBarras { get; set; }

        public bool PrecioEnElCodigoBarras { get; set; }

        // ====================================== //

        public long DepositoIdVenta { get; set; }

        public bool EsPrimeraVez { get; set; } = false;
    }
}
