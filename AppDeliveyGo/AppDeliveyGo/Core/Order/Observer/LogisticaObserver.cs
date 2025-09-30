namespace AppDeliveyGo
{
    public class LogisticaObserver
    {
        public void Suscribir(PedidoService pedidoService)
        {
            pedidoService.EstadoCambiado += OnEstadoCambiado;
            Console.WriteLine("LogisticaObserver suscrito.");
        }
        public void Desuscribir(PedidoService pedidoService)
        {
            pedidoService.EstadoCambiado -= OnEstadoCambiado;
            Console.WriteLine("LogisticaObserver desuscrito.");
        }
        private void OnEstadoCambiado(object? sender, PedidoChangedEventArgs e)
        {
            Console.WriteLine($"[Logística] Actualizando tablero para Pedido {e.PedidoId}: {e.NuevoEstado} ({e.Cuando:HH:mm:ss})");
        }
    }
}
