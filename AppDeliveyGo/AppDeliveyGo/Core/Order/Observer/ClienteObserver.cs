namespace AppDeliveyGo
{
    public class ClienteObserver
    {
        public void Suscribir(PedidoService pedidoService)
        {
            pedidoService.EstadoCambiado += OnEstadoCambiado;
            Console.WriteLine("ClienteObserver suscrito.");
        }
        public void Desuscribir(PedidoService pedidoService)
        {
            pedidoService.EstadoCambiado -= OnEstadoCambiado;
            Console.WriteLine("ClienteObserver desuscrito.");
        }
        private void OnEstadoCambiado(object? sender, PedidoChangedEventArgs e)
        {
            Console.WriteLine($"[Cliente] Pedido {e.PedidoId} ahora está: {e.NuevoEstado} a las {e.Cuando:HH:mm:ss}");
        }
    }
}
