using System.Data.Entity;
using Dominio.MetaData;
using Dominio.Repositorio;
using Dominio.UnidadDeTrabajo;
using Infraestructura.Repositorio;
using Infraestructura.UnidadDeTrabajo;
using IServicio.Articulo;
using IServicio.Configuracion;
using IServicio.Departamento;
using IServicio.Deposito;
using IServicio.Iva;
using IServicio.ListaPrecio;
using IServicio.Localidad;
using IServicio.Marca;
using IServicio.Persona;
using IServicio.Provincia;
using IServicio.Rubro;
using IServicio.Seguridad;
using IServicio.UnidadMedida;
using IServicio.Usuario;
using IServicios.ActualizarPrecio;
using IServicios.BajaArticulo;
using IServicios.Banco;
using IServicios.Caja;
using IServicios.Compras;
using IServicios.Comprobante;
using IServicios.Contador;
using IServicios.CuentaCorriente;
using IServicios.MotivoBaja;
using IServicios.Proveedores;
using IServicios.PuestoTrabajo;
using IServicios.Tarjeta;
using Servicios.ActualizarPrecios;
using Servicios.Articulo;
using Servicios.BajaArticulo;
using Servicios.Banco;
using Servicios.Caja;
using Servicios.Compra;
using Servicios.Comprobante;
using Servicios.CondicionIva;
using Servicios.Configuracion;
using Servicios.Contador;
using Servicios.CuentaCorriente;
using Servicios.Departamento;
using Servicios.Deposito;
using Servicios.Iva;
using Servicios.ListaPrecio;
using Servicios.Localidad;
using Servicios.Marca;
using Servicios.MotivoBaja;
using Servicios.Persona;
using Servicios.Proveedores;
using Servicios.Provincia;
using Servicios.PuestoTrabajo;
using Servicios.Rubro;
using Servicios.Seguridad;
using Servicios.Tarjeta;
using Servicios.UnidadMedida;
using Servicios.Usuario;
using StructureMap;

namespace Aplicacion.IoC
{
    public class StructureMapContainer
    {
        public void Configure()
        {
            ObjectFactory.Configure(x =>
            {
                x.For(typeof(IRepositorio<>)).Use(typeof(Repositorio<>));

                x.ForSingletonOf<DbContext>();

                x.For<IUnidadDeTrabajo>().Use<UnidadDeTrabajo>();

                //---------------------------Administracion---------------------------------//

                x.For<IProvinciaServicio>().Use<ProvinciaServicio>();

                x.For<IDepartamentoServicio>().Use<DepartamentoServicio>();

                x.For<ILocalidadServicio>().Use<LocalidadServicio>();

                x.For<ICondicionIvaServicio>().Use<CondicionIvaServicio>();

                x.For<IConfiguracionServicio>().Use<ConfiguracionServicio>();

                x.For<IDepositoSevicio>().Use<DepositoServicio>();

                //-----------------------------Personas-----------------------------------//

                x.For<IPersonaServicio>().Use<PersonaServicio>();

                x.For<IClienteServicio>().Use<ClienteServicio>();

                x.For<IEmpleadoServicio>().Use<EmpleadoServicio>();

                x.For<IUsuarioServicio>().Use<UsuarioServicio>();

                //-----------------------------Articulo-----------------------------------//

                x.For<IArticuloServicio>().Use<ArticuloServicio>();

                x.For<IListaPrecioServicio>().Use<ListaPrecioServicio>();

                x.For<IMarcaServicio>().Use<MarcaServicio>();

                x.For<IRubroServicio>().Use<RubroServicio>();

                x.For<IIvaServicio>().Use<IvaServicio>();

                x.For<IUnidadMedidaServicio>().Use<UnidadMedidaServicio>();

                x.For<IMotivoBajaServicio>().Use <MotivoBajaServicio>();

                x.For<IBajaArticuloServicio>().Use<BajaArticuloServicio>();

                x.For<IActualizarPrecioServicio>().Use<ActualizarPreciosServicio>();

                //------------------------------------------------------------------------//

                x.For<ISeguridadServicio>().Use<SeguridadServicio>();

                x.For<IPuestoTrabajoServicio>().Use<PuestoTrabajoServicio>();

                x.For<IContadorServicio>().Use<ContadorServicio>();

                x.For<IFacturaServicio>().Use<FacturaServicio>();

                x.For<IBancoServicio>().Use<BancoServicio>();

                x.For<ITarjetaServicio>().Use<TarjetaServicio>();

                x.For<ICajaServicio>().Use<CajaServicio>();

                x.For<ICuentaCorrienteServicio>().Use<CuentaCorrienteServicio>();

                x.For<ICtaCteComprobanteServicio>().Use<CtaCteComprobanteServicio>();

                x.For<IProveedoresServicio>().Use<ProveedoresServicio>();

                x.For<ICompraServicio>().Use<CompraServicio>();
            });
        }
    }
}
