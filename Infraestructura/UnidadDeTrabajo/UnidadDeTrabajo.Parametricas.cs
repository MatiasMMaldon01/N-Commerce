using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio;

namespace Infraestructura.UnidadDeTrabajo
{
    public partial class UnidadDeTrabajo
    {
        // ============================================================================================================ //

        private IRepositorio<Provincia> provinciaRepositorio;
        public IRepositorio<Provincia> ProvinciaRepositorio => provinciaRepositorio
                                                               ?? (provinciaRepositorio =
                                                                   new Repositorio<Provincia>(_context));

        // ============================================================================================================ //

        private IRepositorio<Departamento> departamentoRepositorio;

        public IRepositorio<Departamento> DepartamentoRepositorio => departamentoRepositorio
                                                                  ?? (departamentoRepositorio =
                                                                      new Repositorio<Departamento>(_context));

        // ============================================================================================================ //

        private IRepositorio<Localidad> localidadRepositorio;

        public IRepositorio<Localidad> LocalidadRepositorio => localidadRepositorio
                                                               ?? (localidadRepositorio =
                                                                   new Repositorio<Localidad>(_context));

        // ============================================================================================================ //

        private IRepositorio<CondicionIva> condicionIvaRepositorio;

        public IRepositorio<CondicionIva> CondicionIvaRepositorio => condicionIvaRepositorio
                                                                     ?? (condicionIvaRepositorio =
                                                                         new Repositorio<CondicionIva>(_context));

        // ============================================================================================================ //

        private IRepositorio<Marca> marcaRepositorio;

        public IRepositorio<Marca> MarcaRepositorio => marcaRepositorio
                                                       ?? (marcaRepositorio =
                                                           new Repositorio<Marca>(_context));

        // ============================================================================================================ //

        private IRepositorio<Rubro> rubroRepositorio;

        public IRepositorio<Rubro> RubroRepositorio => rubroRepositorio
                                                       ?? (rubroRepositorio =
                                                           new Repositorio<Rubro>(_context));

        // ============================================================================================================ //

        private IRepositorio<UnidadMedida> unidadMedidaRepositorio;

        public IRepositorio<UnidadMedida> UnidadMedidaRepositorio => unidadMedidaRepositorio
                                                                     ?? (unidadMedidaRepositorio =
                                                                         new Repositorio<UnidadMedida>(_context));

        // ============================================================================================================ //

        private IRepositorio<Iva> ivaRepositorio;

        public IRepositorio<Iva> IvaRepositorio => ivaRepositorio
                                                   ?? (ivaRepositorio =
                                                       new Repositorio<Iva>(_context));

        // ============================================================================================================ //

        private IRepositorio<Deposito> depositoRepositorio;

        public IRepositorio<Deposito> DepositoRepositorio => depositoRepositorio
                                                             ?? (depositoRepositorio =
                                                                 new Repositorio<Deposito>(_context));

        // ============================================================================================================ //
        private IRepositorio<Precio> precioRepositorio;

        public IRepositorio<Precio> PrecioRepositorio => precioRepositorio
                                                             ?? (precioRepositorio =
                                                                 new Repositorio<Precio>(_context));

        // ============================================================================================================ //
        private IRepositorio<Stock> stockRepositorio;

        public IRepositorio<Stock> StockRepositorio => stockRepositorio
                                                             ?? (stockRepositorio =
                                                                 new Repositorio<Stock>(_context));

        // ============================================================================================================ //
        private IRepositorio<PuestoTrabajo> puestoTrabajoRepositorio;

        public IRepositorio<PuestoTrabajo> PuestoTrabajoRepositorio => puestoTrabajoRepositorio
                                                             ?? (puestoTrabajoRepositorio =
                                                                 new Repositorio<PuestoTrabajo>(_context));

        // ============================================================================================================ //
        private IRepositorio<MotivoBaja> motivoBajaRepositorio;

        public IRepositorio<MotivoBaja> MotivoBajaRepositorio => motivoBajaRepositorio
                                                             ?? (motivoBajaRepositorio =
                                                                 new Repositorio<MotivoBaja>(_context));

        // ============================================================================================================ //
        private IRepositorio<BajaArticulo> bajaArticuloRepositorio;

        public IRepositorio<BajaArticulo> BajaArticuloRepositorio => bajaArticuloRepositorio
                                                             ?? (bajaArticuloRepositorio =
                                                                 new Repositorio<BajaArticulo>(_context));

        // ============================================================================================================ //
        private IRepositorio<Contador> contadorRepositorio;

        public IRepositorio<Contador> ContadorRepositorio => contadorRepositorio
                                                             ?? (contadorRepositorio =
                                                                 new Repositorio<Contador>(_context));

        // ============================================================================================================ //
        private IRepositorio<Caja> cajaRepositorio;

        public IRepositorio<Caja> CajaRepositorio => cajaRepositorio
                                                             ?? (cajaRepositorio =
                                                                 new Repositorio<Caja>(_context));

        // ============================================================================================================ //
        private IRepositorio<Banco> bancoRepositorio;

        public IRepositorio<Banco> BancoRepositorio => bancoRepositorio
                                                             ?? (bancoRepositorio =
                                                                 new Repositorio<Banco>(_context));

        // ============================================================================================================ //
        private IRepositorio<Tarjeta> tarjetaRepositorio;

        public IRepositorio<Tarjeta> TarjetaRepositorio => tarjetaRepositorio
                                                             ?? (tarjetaRepositorio =
                                                                 new Repositorio<Tarjeta>(_context));

        // ============================================================================================================ //
    }
}
