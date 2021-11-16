using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio;

namespace Infraestructura.UnidadDeTrabajo
{
    public partial class UnidadDeTrabajo
    {
        // ============================================================================================================ //

        private IRepositorio<Proveedor> proveedorRepositorio;

        public IRepositorio<Proveedor> ProveedorRepositorio => proveedorRepositorio
                                                               ?? (proveedorRepositorio =
                                                                   new Repositorio<Proveedor>(_context));

        // ============================================================================================================ //

        private IEmpleadoRepositorio empleadoRepositorio;

        public IEmpleadoRepositorio EmpleadoRepositorio => empleadoRepositorio
                                                           ?? (empleadoRepositorio = 
                                                               new EmpleadoRepositorio(_context));

        // ============================================================================================================ //

        private IClienteRepositorio clienteRepositorio;

        public IClienteRepositorio ClienteRepositorio => clienteRepositorio
                                                         ?? (clienteRepositorio =
                                                             new ClienteRepositorio(_context));

        // ============================================================================================================ //
        private IFacturaRepositorio facturaRepositorio;

        public IFacturaRepositorio FacturaRepositorio => facturaRepositorio
                                                         ?? (facturaRepositorio =
                                                             new FacturaRepositorio(_context));

        // ============================================================================================================ //
        private ICtaCteClienteComprobanteRepositorio ctaCteClienteComprobanteRepositorio;

        public ICtaCteClienteComprobanteRepositorio CtaCteClienteComprobanteRepositorio => ctaCteClienteComprobanteRepositorio
                                                         ?? (ctaCteClienteComprobanteRepositorio =
                                                             new CtaCteClienteComprobanteRepositorio(_context));

        // ============================================================================================================ //
        private ICuentaCorrienteRepositorio cuentaCorrienteRepositorio;

        public ICuentaCorrienteRepositorio CuentaCorrienteRepositorio => cuentaCorrienteRepositorio
                                                         ?? (cuentaCorrienteRepositorio =
                                                             new CuentaCorrienteRepositorio(_context));

        // ============================================================================================================ //

        private IRepositorio<Configuracion> configuracionRepositorio;

        public IRepositorio<Configuracion> ConfiguracionRepositorio => configuracionRepositorio
                                                                       ?? (configuracionRepositorio =
                                                                           new Repositorio<Configuracion>(_context));

        // ============================================================================================================ //

        private IRepositorio<ListaPrecio> listaPrecioRepositorio;

        public IRepositorio<ListaPrecio> ListaPrecioRepositorio => listaPrecioRepositorio
                                                                   ?? (listaPrecioRepositorio =
                                                                       new Repositorio<ListaPrecio>(_context));

        // ============================================================================================================ //

        private IRepositorio<Articulo> articuloRepositorio;

        public IRepositorio<Articulo> ArticuloRepositorio => articuloRepositorio
                                                             ?? (articuloRepositorio =
                                                                 new Repositorio<Articulo>(_context));

        // ============================================================================================================ //

        private IRepositorio<DetalleCaja> detalleCajaRepositorio;

        public IRepositorio<DetalleCaja> DetalleCajaRepositorio => detalleCajaRepositorio
                                                             ?? (detalleCajaRepositorio =
                                                                 new Repositorio<DetalleCaja>(_context));

        // ============================================================================================================ //

        private IRepositorio<CuentaCorrienteCliente> cuentaCorrienteClienteRepositorio;

        public IRepositorio<CuentaCorrienteCliente> CuentaCorrienteClienteRepositorio => cuentaCorrienteClienteRepositorio
                                                             ?? (cuentaCorrienteClienteRepositorio =
                                                                 new Repositorio<CuentaCorrienteCliente>(_context));

        // ============================================================================================================ // 
        private IRepositorio<MovimientoCuentaCorriente> movimientoCtaCteRepositorio;

        public IRepositorio<MovimientoCuentaCorriente> MovimientoCtaCteRepositorio => movimientoCtaCteRepositorio
                                                             ?? (movimientoCtaCteRepositorio =
                                                                 new Repositorio<MovimientoCuentaCorriente>(_context));

        // ============================================================================================================ //

        private IRepositorio<Movimiento> movimientoRepositorio;

        public IRepositorio<Movimiento> MovimientoRepositorio => movimientoRepositorio
                                                             ?? (movimientoRepositorio =
                                                                 new Repositorio<Movimiento>(_context));

        // ============================================================================================================ //
    }
}
