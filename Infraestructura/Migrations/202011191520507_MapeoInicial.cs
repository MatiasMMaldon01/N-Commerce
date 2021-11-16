namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapeoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarcaId = c.Long(nullable: false),
                        RubroId = c.Long(nullable: false),
                        UnidadMedidaId = c.Long(nullable: false),
                        IvaId = c.Long(nullable: false),
                        Codigo = c.Int(nullable: false),
                        CodigoBarra = c.String(nullable: false, maxLength: 100, unicode: false),
                        Abreviatura = c.String(maxLength: 10, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        Detalle = c.String(maxLength: 500, unicode: false),
                        Ubicacion = c.String(maxLength: 500, unicode: false),
                        Foto = c.Binary(nullable: false),
                        ActivarLimiteVenta = c.Boolean(nullable: false),
                        LimiteVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivarHoraVenta = c.Boolean(nullable: false),
                        HoraLimiteVentaDesde = c.DateTime(nullable: false),
                        HoraLimiteVentaHasta = c.DateTime(nullable: false),
                        PermiteStockNegativo = c.Boolean(nullable: false),
                        DescuentaStock = c.Boolean(nullable: false),
                        StockMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Iva", t => t.IvaId)
                .ForeignKey("dbo.Marca", t => t.MarcaId)
                .ForeignKey("dbo.Rubro", t => t.RubroId)
                .ForeignKey("dbo.UnidadMedida", t => t.UnidadMedidaId)
                .Index(t => t.MarcaId)
                .Index(t => t.RubroId)
                .Index(t => t.UnidadMedidaId)
                .Index(t => t.IvaId);
            
            CreateTable(
                "dbo.BajaArticulo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloId = c.Long(nullable: false),
                        MotivoBajaId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Observacion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Foto = c.Binary(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId)
                .ForeignKey("dbo.MotivoBajas", t => t.MotivoBajaId)
                .Index(t => t.ArticuloId)
                .Index(t => t.MotivoBajaId);
            
            CreateTable(
                "dbo.MotivoBajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleComprobante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        ArticuloId = c.Long(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId)
                .ForeignKey("dbo.Comprobante", t => t.ComprobanteId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.Comprobante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Numero = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva105 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoComprobante = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Apellido = c.String(nullable: false, maxLength: 150, unicode: false),
                        Nombre = c.String(nullable: false, maxLength: 200, unicode: false),
                        Dni = c.String(maxLength: 8, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Telefono = c.String(maxLength: 25, unicode: false),
                        Mail = c.String(nullable: false, maxLength: 250, unicode: false),
                        LocalidadId = c.Long(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DepartamentoId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .Index(t => new { t.DepartamentoId, t.Descripcion }, unique: true, name: "Index_DepartamentoId_Descripcion_Localidad");
            
            CreateTable(
                "dbo.Configuracion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 250, unicode: false),
                        NombreFantasia = c.String(maxLength: 250, unicode: false),
                        Cuit = c.String(nullable: false, maxLength: 13, unicode: false),
                        Telefono = c.String(maxLength: 25, unicode: false),
                        Celular = c.String(maxLength: 25, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        LocalidadId = c.Long(nullable: false),
                        FacturaDescuentaStock = c.Boolean(nullable: false),
                        PresupuestoDescuentaStock = c.Boolean(nullable: false),
                        RemitoDescuentaStock = c.Boolean(nullable: false),
                        ActualizaCostoDesdeCompra = c.Boolean(nullable: false),
                        ModificaPrecioVentaDesdeCompra = c.Boolean(nullable: false),
                        DepositoIdStock = c.Long(nullable: false),
                        DepositoIdVenta = c.Long(nullable: false),
                        TipoFormaPagoPorDefectoVenta = c.Int(nullable: false),
                        TipoFormaPagoPorDefectoCompra = c.Int(nullable: false),
                        ObservacionEnPieFactura = c.String(maxLength: 400, unicode: false),
                        UnificarRenglonesIngresarMismoProducto = c.Boolean(nullable: false),
                        ListaPrecioPorDefectoId = c.Long(nullable: false),
                        IngresoManualCajaInicial = c.Boolean(nullable: false),
                        PuestoCajaSeparado = c.Boolean(nullable: false),
                        ActivarRetiroDeCaja = c.Boolean(nullable: false),
                        MontoMaximoRetiroCaja = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivarBascula = c.Boolean(nullable: false),
                        ComienzoCodigo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PesoEnElCodigoBarras = c.Boolean(nullable: false),
                        PrecioEnElCodigoBarras = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListaPrecio", t => t.ListaPrecioPorDefectoId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId)
                .Index(t => t.ListaPrecioPorDefectoId);
            
            CreateTable(
                "dbo.Deposito",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        Ubicacion = c.String(maxLength: 400, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        Configuracion_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Configuracion", t => t.Configuracion_Id)
                .Index(t => t.Descripcion, unique: true, name: "Index_Descripcion_Deposito")
                .Index(t => t.Configuracion_Id);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloId = c.Long(nullable: false),
                        DepositoId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId)
                .ForeignKey("dbo.Deposito", t => t.DepositoId)
                .Index(t => t.ArticuloId)
                .Index(t => t.DepositoId);
            
            CreateTable(
                "dbo.ListaPrecio",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        PorcentajeGanancia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NecesitaAutorizacion = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Precio",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloId = c.Long(nullable: false),
                        ListaPrecioId = c.Long(nullable: false),
                        PrecioCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioPublico = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaActualizacion = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId)
                .ForeignKey("dbo.ListaPrecio", t => t.ListaPrecioId)
                .Index(t => t.ArticuloId)
                .Index(t => t.ListaPrecioId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinciaId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId)
                .Index(t => new { t.ProvinciaId, t.Descripcion }, unique: true, name: "Index_ProvinciaId_Descripcion_Departamento");
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Descripcion, unique: true, name: "Index_Descripcion_Provincia");
            
            CreateTable(
                "dbo.Cheque",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                        BancoId = c.Long(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        EstaRechazado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banco", t => t.BancoId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuentaBancarias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BancoId = c.Long(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Titular = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banco", t => t.BancoId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.DepositoCheques",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChequeId = c.Long(nullable: false),
                        CuentaBancariaId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cheque", t => t.ChequeId)
                .ForeignKey("dbo.CuentaBancarias", t => t.CuentaBancariaId)
                .Index(t => t.ChequeId)
                .Index(t => t.CuentaBancariaId);
            
            CreateTable(
                "dbo.FormaPago",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.ComprobanteId)
                .Index(t => t.ComprobanteId);
            
            CreateTable(
                "dbo.CondicionIva",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 150, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Descripcion, unique: true, name: "Index_Descripcion_CondicionIva");
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 250, unicode: false),
                        CUIT = c.String(nullable: false, maxLength: 15, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Telefono = c.String(maxLength: 25, unicode: false),
                        Mail = c.String(nullable: false, maxLength: 250, unicode: false),
                        LocalidadId = c.Long(nullable: false),
                        CondicionIvaId = c.Long(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CondicionIva", t => t.CondicionIvaId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId)
                .Index(t => t.CondicionIvaId);
            
            CreateTable(
                "dbo.Tarjeta",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movimiento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CajaId = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 4000, unicode: false),
                        TipoMovimiento = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Caja", t => t.CajaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .ForeignKey("dbo.Comprobante", t => t.ComprobanteId)
                .Index(t => t.CajaId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Caja",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsuarioAperturaId = c.Long(nullable: false),
                        MontoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaApertura = c.DateTime(nullable: false),
                        UsuarioCierreId = c.Long(),
                        FechaCierre = c.DateTime(),
                        MontoCierre = c.Decimal(precision: 18, scale: 2),
                        TotalEntradaEfectivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSalidaEfectivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalEntradaTarjeta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSalidaTarjeta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalEntradaCheque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSalidaCheque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalEntradaCtaCte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSalidaCtaCte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioAperturaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCierreId)
                .Index(t => t.UsuarioAperturaId)
                .Index(t => t.UsuarioCierreId);
            
            CreateTable(
                "dbo.DetalleCaja",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CajaId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Caja", t => t.CajaId)
                .Index(t => t.CajaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaBloqueado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.PuestoTrabajo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Descripcion, unique: true, name: "Index_Descripcion_PuestoTrabajo");
            
            CreateTable(
                "dbo.Iva",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        Porcentaje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rubro",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        HoraLimiteVentaDesde = c.DateTime(nullable: false),
                        HoraLimiteVentaHasta = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadMedida",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConceptoGastos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gasto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConceptoGastoId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConceptoGastos", t => t.ConceptoGastoId)
                .Index(t => t.ConceptoGastoId);
            
            CreateTable(
                "dbo.Contador",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TipoComprobante = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persona_Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CondicionIvaId = c.Long(nullable: false),
                        ActivarCtaCte = c.Boolean(nullable: false),
                        TieneLimiteCompra = c.Boolean(nullable: false),
                        MontoMaximoCtaCte = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .ForeignKey("dbo.CondicionIva", t => t.CondicionIvaId)
                .Index(t => t.Id)
                .Index(t => t.CondicionIvaId);
            
            CreateTable(
                "dbo.Comprobante_Compra",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProveedorId = c.Long(nullable: false),
                        FechaEntrega = c.DateTime(nullable: false),
                        Iva27 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionTemp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionPyP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionIva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionIB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoFactura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorId)
                .Index(t => t.Id)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Comprobante_CtaCteProveedor",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProveedorId = c.Long(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorId)
                .Index(t => t.Id)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Comprobante_CtaCte",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Persona_Empleado",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Legajo = c.Int(nullable: false),
                        Foto = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Comprobante_Factura",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        PuestoTrabajoId = c.Long(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.PuestoTrabajo", t => t.PuestoTrabajoId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId)
                .Index(t => t.PuestoTrabajoId);
            
            CreateTable(
                "dbo.FormaPago_Cheque",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ChequeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaPago", t => t.Id)
                .ForeignKey("dbo.Cheque", t => t.ChequeId)
                .Index(t => t.Id)
                .Index(t => t.ChequeId);
            
            CreateTable(
                "dbo.FormaPago_CtaCte",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaPago", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.FormaPago_Tarjeta",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        TarjetaId = c.Long(nullable: false),
                        NumeroTarjeta = c.String(nullable: false, maxLength: 100, unicode: false),
                        CuponPago = c.String(nullable: false, maxLength: 100, unicode: false),
                        CantidadCuotas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaPago", t => t.Id)
                .ForeignKey("dbo.Tarjeta", t => t.TarjetaId)
                .Index(t => t.Id)
                .Index(t => t.TarjetaId);
            
            CreateTable(
                "dbo.Movimiento_CuentaCorrienteProveedor",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProveedorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movimiento", t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorId)
                .Index(t => t.Id)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Movimiento_CuentaCorriente",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movimiento", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Comprobante_NotaCredito",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.ComprobanteId)
                .Index(t => t.Id)
                .Index(t => t.ComprobanteId);
            
            CreateTable(
                "dbo.Comprobante_Presupuesto",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Comprobante_Remito",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobante", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprobante_Remito", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobante_Remito", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Comprobante_Presupuesto", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobante_Presupuesto", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Comprobante_NotaCredito", "ComprobanteId", "dbo.Comprobante");
            DropForeignKey("dbo.Comprobante_NotaCredito", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Movimiento_CuentaCorriente", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Movimiento_CuentaCorriente", "Id", "dbo.Movimiento");
            DropForeignKey("dbo.Movimiento_CuentaCorrienteProveedor", "ProveedorId", "dbo.Proveedor");
            DropForeignKey("dbo.Movimiento_CuentaCorrienteProveedor", "Id", "dbo.Movimiento");
            DropForeignKey("dbo.FormaPago_Tarjeta", "TarjetaId", "dbo.Tarjeta");
            DropForeignKey("dbo.FormaPago_Tarjeta", "Id", "dbo.FormaPago");
            DropForeignKey("dbo.FormaPago_CtaCte", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.FormaPago_CtaCte", "Id", "dbo.FormaPago");
            DropForeignKey("dbo.FormaPago_Cheque", "ChequeId", "dbo.Cheque");
            DropForeignKey("dbo.FormaPago_Cheque", "Id", "dbo.FormaPago");
            DropForeignKey("dbo.Comprobante_Factura", "PuestoTrabajoId", "dbo.PuestoTrabajo");
            DropForeignKey("dbo.Comprobante_Factura", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobante_Factura", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Persona_Empleado", "Id", "dbo.Persona");
            DropForeignKey("dbo.Comprobante_CtaCte", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobante_CtaCte", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Comprobante_CtaCteProveedor", "ProveedorId", "dbo.Proveedor");
            DropForeignKey("dbo.Comprobante_CtaCteProveedor", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Comprobante_Compra", "ProveedorId", "dbo.Proveedor");
            DropForeignKey("dbo.Comprobante_Compra", "Id", "dbo.Comprobante");
            DropForeignKey("dbo.Persona_Cliente", "CondicionIvaId", "dbo.CondicionIva");
            DropForeignKey("dbo.Persona_Cliente", "Id", "dbo.Persona");
            DropForeignKey("dbo.Gasto", "ConceptoGastoId", "dbo.ConceptoGastos");
            DropForeignKey("dbo.Articulo", "UnidadMedidaId", "dbo.UnidadMedida");
            DropForeignKey("dbo.Articulo", "RubroId", "dbo.Rubro");
            DropForeignKey("dbo.Articulo", "MarcaId", "dbo.Marca");
            DropForeignKey("dbo.Articulo", "IvaId", "dbo.Iva");
            DropForeignKey("dbo.Proveedor", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Proveedor", "CondicionIvaId", "dbo.CondicionIva");
            DropForeignKey("dbo.Movimiento", "ComprobanteId", "dbo.Comprobante");
            DropForeignKey("dbo.Movimiento", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.Comprobante", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Caja", "UsuarioCierreId", "dbo.Usuario");
            DropForeignKey("dbo.Caja", "UsuarioAperturaId", "dbo.Usuario");
            DropForeignKey("dbo.Movimiento", "CajaId", "dbo.Caja");
            DropForeignKey("dbo.DetalleCaja", "CajaId", "dbo.Caja");
            DropForeignKey("dbo.FormaPago", "ComprobanteId", "dbo.Comprobante");
            DropForeignKey("dbo.Cheque", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.DepositoCheques", "CuentaBancariaId", "dbo.CuentaBancarias");
            DropForeignKey("dbo.DepositoCheques", "ChequeId", "dbo.Cheque");
            DropForeignKey("dbo.CuentaBancarias", "BancoId", "dbo.Banco");
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropForeignKey("dbo.Persona", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Departamento", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Localidad", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Configuracion", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Precio", "ListaPrecioId", "dbo.ListaPrecio");
            DropForeignKey("dbo.Precio", "ArticuloId", "dbo.Articulo");
            DropForeignKey("dbo.Configuracion", "ListaPrecioPorDefectoId", "dbo.ListaPrecio");
            DropForeignKey("dbo.Stock", "DepositoId", "dbo.Deposito");
            DropForeignKey("dbo.Stock", "ArticuloId", "dbo.Articulo");
            DropForeignKey("dbo.Deposito", "Configuracion_Id", "dbo.Configuracion");
            DropForeignKey("dbo.Comprobante", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.DetalleComprobante", "ComprobanteId", "dbo.Comprobante");
            DropForeignKey("dbo.DetalleComprobante", "ArticuloId", "dbo.Articulo");
            DropForeignKey("dbo.BajaArticulo", "MotivoBajaId", "dbo.MotivoBajas");
            DropForeignKey("dbo.BajaArticulo", "ArticuloId", "dbo.Articulo");
            DropIndex("dbo.Comprobante_Remito", new[] { "ClienteId" });
            DropIndex("dbo.Comprobante_Remito", new[] { "Id" });
            DropIndex("dbo.Comprobante_Presupuesto", new[] { "ClienteId" });
            DropIndex("dbo.Comprobante_Presupuesto", new[] { "Id" });
            DropIndex("dbo.Comprobante_NotaCredito", new[] { "ComprobanteId" });
            DropIndex("dbo.Comprobante_NotaCredito", new[] { "Id" });
            DropIndex("dbo.Movimiento_CuentaCorriente", new[] { "ClienteId" });
            DropIndex("dbo.Movimiento_CuentaCorriente", new[] { "Id" });
            DropIndex("dbo.Movimiento_CuentaCorrienteProveedor", new[] { "ProveedorId" });
            DropIndex("dbo.Movimiento_CuentaCorrienteProveedor", new[] { "Id" });
            DropIndex("dbo.FormaPago_Tarjeta", new[] { "TarjetaId" });
            DropIndex("dbo.FormaPago_Tarjeta", new[] { "Id" });
            DropIndex("dbo.FormaPago_CtaCte", new[] { "ClienteId" });
            DropIndex("dbo.FormaPago_CtaCte", new[] { "Id" });
            DropIndex("dbo.FormaPago_Cheque", new[] { "ChequeId" });
            DropIndex("dbo.FormaPago_Cheque", new[] { "Id" });
            DropIndex("dbo.Comprobante_Factura", new[] { "PuestoTrabajoId" });
            DropIndex("dbo.Comprobante_Factura", new[] { "ClienteId" });
            DropIndex("dbo.Comprobante_Factura", new[] { "Id" });
            DropIndex("dbo.Persona_Empleado", new[] { "Id" });
            DropIndex("dbo.Comprobante_CtaCte", new[] { "ClienteId" });
            DropIndex("dbo.Comprobante_CtaCte", new[] { "Id" });
            DropIndex("dbo.Comprobante_CtaCteProveedor", new[] { "ProveedorId" });
            DropIndex("dbo.Comprobante_CtaCteProveedor", new[] { "Id" });
            DropIndex("dbo.Comprobante_Compra", new[] { "ProveedorId" });
            DropIndex("dbo.Comprobante_Compra", new[] { "Id" });
            DropIndex("dbo.Persona_Cliente", new[] { "CondicionIvaId" });
            DropIndex("dbo.Persona_Cliente", new[] { "Id" });
            DropIndex("dbo.Gasto", new[] { "ConceptoGastoId" });
            DropIndex("dbo.PuestoTrabajo", "Index_Descripcion_PuestoTrabajo");
            DropIndex("dbo.Usuario", new[] { "EmpleadoId" });
            DropIndex("dbo.DetalleCaja", new[] { "CajaId" });
            DropIndex("dbo.Caja", new[] { "UsuarioCierreId" });
            DropIndex("dbo.Caja", new[] { "UsuarioAperturaId" });
            DropIndex("dbo.Movimiento", new[] { "UsuarioId" });
            DropIndex("dbo.Movimiento", new[] { "ComprobanteId" });
            DropIndex("dbo.Movimiento", new[] { "CajaId" });
            DropIndex("dbo.Proveedor", new[] { "CondicionIvaId" });
            DropIndex("dbo.Proveedor", new[] { "LocalidadId" });
            DropIndex("dbo.CondicionIva", "Index_Descripcion_CondicionIva");
            DropIndex("dbo.FormaPago", new[] { "ComprobanteId" });
            DropIndex("dbo.DepositoCheques", new[] { "CuentaBancariaId" });
            DropIndex("dbo.DepositoCheques", new[] { "ChequeId" });
            DropIndex("dbo.CuentaBancarias", new[] { "BancoId" });
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropIndex("dbo.Cheque", new[] { "ClienteId" });
            DropIndex("dbo.Provincia", "Index_Descripcion_Provincia");
            DropIndex("dbo.Departamento", "Index_ProvinciaId_Descripcion_Departamento");
            DropIndex("dbo.Precio", new[] { "ListaPrecioId" });
            DropIndex("dbo.Precio", new[] { "ArticuloId" });
            DropIndex("dbo.Stock", new[] { "DepositoId" });
            DropIndex("dbo.Stock", new[] { "ArticuloId" });
            DropIndex("dbo.Deposito", new[] { "Configuracion_Id" });
            DropIndex("dbo.Deposito", "Index_Descripcion_Deposito");
            DropIndex("dbo.Configuracion", new[] { "ListaPrecioPorDefectoId" });
            DropIndex("dbo.Configuracion", new[] { "LocalidadId" });
            DropIndex("dbo.Localidad", "Index_DepartamentoId_Descripcion_Localidad");
            DropIndex("dbo.Persona", new[] { "LocalidadId" });
            DropIndex("dbo.Comprobante", new[] { "UsuarioId" });
            DropIndex("dbo.Comprobante", new[] { "EmpleadoId" });
            DropIndex("dbo.DetalleComprobante", new[] { "ArticuloId" });
            DropIndex("dbo.DetalleComprobante", new[] { "ComprobanteId" });
            DropIndex("dbo.BajaArticulo", new[] { "MotivoBajaId" });
            DropIndex("dbo.BajaArticulo", new[] { "ArticuloId" });
            DropIndex("dbo.Articulo", new[] { "IvaId" });
            DropIndex("dbo.Articulo", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Articulo", new[] { "RubroId" });
            DropIndex("dbo.Articulo", new[] { "MarcaId" });
            DropTable("dbo.Comprobante_Remito");
            DropTable("dbo.Comprobante_Presupuesto");
            DropTable("dbo.Comprobante_NotaCredito");
            DropTable("dbo.Movimiento_CuentaCorriente");
            DropTable("dbo.Movimiento_CuentaCorrienteProveedor");
            DropTable("dbo.FormaPago_Tarjeta");
            DropTable("dbo.FormaPago_CtaCte");
            DropTable("dbo.FormaPago_Cheque");
            DropTable("dbo.Comprobante_Factura");
            DropTable("dbo.Persona_Empleado");
            DropTable("dbo.Comprobante_CtaCte");
            DropTable("dbo.Comprobante_CtaCteProveedor");
            DropTable("dbo.Comprobante_Compra");
            DropTable("dbo.Persona_Cliente");
            DropTable("dbo.Contador");
            DropTable("dbo.Gasto");
            DropTable("dbo.ConceptoGastos");
            DropTable("dbo.UnidadMedida");
            DropTable("dbo.Rubro");
            DropTable("dbo.Marca");
            DropTable("dbo.Iva");
            DropTable("dbo.PuestoTrabajo");
            DropTable("dbo.Usuario");
            DropTable("dbo.DetalleCaja");
            DropTable("dbo.Caja");
            DropTable("dbo.Movimiento");
            DropTable("dbo.Tarjeta");
            DropTable("dbo.Proveedor");
            DropTable("dbo.CondicionIva");
            DropTable("dbo.FormaPago");
            DropTable("dbo.DepositoCheques");
            DropTable("dbo.CuentaBancarias");
            DropTable("dbo.Banco");
            DropTable("dbo.Cheque");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Precio");
            DropTable("dbo.ListaPrecio");
            DropTable("dbo.Stock");
            DropTable("dbo.Deposito");
            DropTable("dbo.Configuracion");
            DropTable("dbo.Localidad");
            DropTable("dbo.Persona");
            DropTable("dbo.Comprobante");
            DropTable("dbo.DetalleComprobante");
            DropTable("dbo.MotivoBajas");
            DropTable("dbo.BajaArticulo");
            DropTable("dbo.Articulo");
        }
    }
}
