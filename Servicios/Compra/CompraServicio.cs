using Dominio.UnidadDeTrabajo;
using IServicio.Configuracion;
using IServicios.Compras;
using IServicios.Compras.DTOs;
using StructureMap;
using System;
using System.Linq;

namespace Servicios.Compra
{
    public class CompraServicio : ICompraServicio
    {
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public CompraServicio()
        {
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
            _unidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
        }
        public void IncrementarStock(CompraDto compra)
        {
            var config = _configuracionServicio.Obtener();


            foreach (var item in compra.Items)
            {
                var stockActual = _unidadDeTrabajo.StockRepositorio.Obtener(x => x.ArticuloId == item.ArticuloId && x.DepositoId == config.DepositoIdStock).FirstOrDefault();

                if (stockActual == null)
                    throw new Exception("Ocurrio un error al obtener el Stock del Articulo");

                stockActual.Cantidad += item.Cantidad;

                _unidadDeTrabajo.StockRepositorio.Modificar(stockActual);
                _unidadDeTrabajo.Commit();
            }
        }
    }
}
