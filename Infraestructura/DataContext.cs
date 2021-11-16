using Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Infraestructura.Migrations;
using static Aplicacion.CadenaConexion.CadenaConecion;

namespace Infraestructura
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ObtenerCadenaSql)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }

        // Mapeo
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<BajaArticulo> BajaArticulos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<ConceptoGasto> ConceptoGastos { get; set; }
        public DbSet<CondicionIva> CondicionIvas { get; set; }
        public DbSet<Configuracion> Configurationes { get; set; }
        public DbSet<Contador> Contadores { get; set; }
        public DbSet<CuentaBancaria> CuentaBancarias { get; set; }
        public DbSet<CuentaCorrienteCliente> CuentaCorrientes { get; set; }
        public DbSet<CuentaCorrienteProveedor> CuentaCorrienteProveedores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<DepositoCheque> DepositoCheques { get; set; }
        public DbSet<DetalleCaja> DetalleCajas { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }
        public DbSet<FormaPagoCtaCte> FormaPagoCtaCtes { get; set; }
        public DbSet<FormaPagoCheque> FormaPagoCheques { get; set; }
        public DbSet<FormaPagoTarjeta> FormaPagoTarjetas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Iva> Ivas { get; set; }
        public DbSet<ListaPrecio> ListaPrecios { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MotivoBaja> MotivoBajas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<MovimientoCuentaCorriente> MovimientoCuentaCorrientes { get; set; }
        public DbSet<MovimientoCuentaCorrienteProveedor> MovimientoCuentaCorrienteProveedores { get; set; }
        public DbSet<NotaCredito> NotaCreditos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Precio> Precios { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<PuestoTrabajo> PuestoTrabajos { get; set; }
        public DbSet<Remito> Remitos { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
