using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo
    {
        // Metodos
        void Commit();

        void Disposed();

        // Propiedades

        IRepositorio<Provincia> ProvinciaRepositorio { get; }
        IRepositorio<Departamento> DepartamentoRepositorio { get; }
        IRepositorio<Localidad> LocalidadRepositorio { get; }
        IRepositorio<CondicionIva> CondicionIvaRepositorio { get; }
        IRepositorio<Proveedor> ProveedorRepositorio { get; }
        IClienteRepositorio ClienteRepositorio { get; }
        IEmpleadoRepositorio EmpleadoRepositorio { get; }
        IFacturaRepositorio FacturaRepositorio { get; }
        ICtaCteClienteComprobanteRepositorio CtaCteClienteComprobanteRepositorio { get; }
        ICuentaCorrienteRepositorio CuentaCorrienteRepositorio { get; }
        IRepositorio<Usuario> UsuarioRepositorio { get; }
        IRepositorio<Configuracion> ConfiguracionRepositorio { get; }
        IRepositorio<ListaPrecio> ListaPrecioRepositorio { get; }
        IRepositorio<UnidadMedida> UnidadMedidaRepositorio { get; }
        IRepositorio<Marca> MarcaRepositorio { get; }
        IRepositorio<Rubro> RubroRepositorio { get; }
        IRepositorio<Iva> IvaRepositorio { get; }
        IRepositorio<Articulo> ArticuloRepositorio { get; }
        IRepositorio<Deposito> DepositoRepositorio { get; }
        IRepositorio<Stock> StockRepositorio { get; }
        IRepositorio<Precio> PrecioRepositorio { get; }
        IRepositorio<PuestoTrabajo> PuestoTrabajoRepositorio { get; }
        IRepositorio<MotivoBaja> MotivoBajaRepositorio { get; }
        IRepositorio<BajaArticulo> BajaArticuloRepositorio { get; }
        IRepositorio<Contador> ContadorRepositorio { get; }
        IRepositorio<DetalleCaja> DetalleCajaRepositorio { get; }
        IRepositorio<Caja> CajaRepositorio { get;}
        IRepositorio<Banco> BancoRepositorio { get; }
        IRepositorio<Tarjeta> TarjetaRepositorio { get; }
        IRepositorio<CuentaCorrienteCliente> CuentaCorrienteClienteRepositorio { get; }
        IRepositorio<Movimiento> MovimientoRepositorio { get; }
        IRepositorio<MovimientoCuentaCorriente> MovimientoCtaCteRepositorio { get; }


    }
}
