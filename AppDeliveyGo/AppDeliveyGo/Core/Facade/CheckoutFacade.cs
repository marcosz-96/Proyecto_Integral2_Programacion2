using AppDeliveyGo;

namespace AppDeliveryGo
{
    public class CheckoutFacade
    {
        private readonly ICarritoPort _carrito;
        private IEnvioStrategy _envioActual;
        private readonly PedidoService _pedidosService;

        public CheckoutFacade(ICarritoPort carrito, IEnvioStrategy envioInicial, PedidoService pedidosService)
        {
            _carrito = carrito;
            _envioActual = envioInicial;
            _pedidosService = pedidosService;
        }

        // Métodos para el Carrito (Command)
        public void AgregarItem(string sku, string nombre, decimal precio, int cantidad)
        {
            var item = new Item { Sku = sku, Name = nombre, Price = precio, Amount = cantidad };
            _carrito.Run(new AgregarItemCommand((_carrito as CarritoPort).GetCurrentCarritoInstance(), item));
            Console.WriteLine($"Item '{nombre}' agregado al carrito.");
        }

        public void CambiarCantidad(string sku, int cantidad)
        {
            _carrito.Run(new SetCantidadCommand((_carrito as CarritoPort).GetCurrentCarritoInstance(), sku, cantidad));
            Console.WriteLine($"Cantidad de '{sku}' cambiada a {cantidad}.");
        }

        public void QuitarItem(string sku)
        {
            _carrito.Run(new QuitarItemCommand((_carrito as CarritoPort).GetCurrentCarritoInstance(), sku));
            Console.WriteLine($"Item '{sku}' quitado del carrito.");
        }

        public void UndoCarrito() => _carrito.Undo();
        public void RedoCarrito() => _carrito.Redo();
        public decimal GetSubtotalCarrito() => _carrito.Subtotal();
        public IEnumerable<Item> GetItemsCarrito() => (_carrito as CarritoPort).GetCurrentItems();


        // Métodos para Envío (Strategy)
        public void ElegirEnvio(IEnvioStrategy nuevaEstrategia)
        {
            _envioActual = nuevaEstrategia;
            Console.WriteLine($"Estrategia de envío cambiada a: {_envioActual.Nombre}");
        }

        public decimal CalcularTotal()
        {
            decimal subtotal = _carrito.Subtotal();
            decimal costoEnvio = _envioActual.Calcular(subtotal);
            return subtotal + costoEnvio;
        }

        public string GetNombreEnvioActual() => _envioActual.Nombre;


        // Métodos para Pago (Factory/Adapter/Decorator)
        public bool Pagar(string tipoPago, bool aplicarIVA, decimal? cupon = null)
        {
            decimal montoAPagar = CalcularTotal();
            IPago pagoBase;

            if (tipoPago.ToLower() == "mp-adapter")
            {
                pagoBase = new PagoAdapterMp(new MpSdkFalsa());
            }
            else
            {
                pagoBase = PagoFactory.Create(tipoPago);
            }

            if (aplicarIVA)
            {
                pagoBase = new PagoConImpuestos(pagoBase);
            }

            if (cupon.HasValue && cupon.Value > 0 && cupon.Value < 1) // Cupón como porcentaje (ej. 0.10)
            {
                pagoBase = new PagoConCupon(pagoBase, cupon.Value);
            }
            else if (cupon.HasValue && cupon.Value >= 1) // Si el cupón es un valor absoluto, se necesitaría otro decorador o lógica
            {
                Console.WriteLine("Advertencia: El cupón debe ser un porcentaje (ej. 0.10). No se aplicó.");
            }

            Console.WriteLine($"Iniciando proceso de pago con: {pagoBase.Nombre}");
            return pagoBase.Procesar(montoAPagar);
        }

        // Métodos para Pedido (Builder/Observer)
        public Pedido ConfirmarPedido(string direccion, string tipoPagoRegistrado)
        {
            if (!GetItemsCarrito().Any())
            {
                throw new InvalidOperationException("No se puede confirmar un pedido sin ítems en el carrito.");
            }

            var builder = new PedidoBuilder();
            builder.ConItems(GetItemsCarrito().Select(i => (i.Sku, i.Name, i.Price, i.Amount)))
                   .ConDireccion(direccion)
                   .ConMetodoPago(tipoPagoRegistrado)
                   .ConMonto(CalcularTotal());

            Pedido nuevoPedido = builder.Build();

            // Simular workflow de estados
            _pedidosService.CambiarEstado(nuevoPedido.Id, EstadoPedido.Recibido);
            _pedidosService.CambiarEstado(nuevoPedido.Id, EstadoPedido.Preparando);
            _pedidosService.CambiarEstado(nuevoPedido.Id, EstadoPedido.Enviado);
            _pedidosService.CambiarEstado(nuevoPedido.Id, EstadoPedido.Entregado);

            Console.WriteLine($"Pedido {nuevoPedido.Id} confirmado y entregado.");
            return nuevoPedido;
        }
    }
}
