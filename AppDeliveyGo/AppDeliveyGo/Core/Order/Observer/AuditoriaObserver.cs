namespace AppDeliveyGo
{
    public class AuditoriaObserver
    {
        public void Suscribir(PedidoService pedidoService)
        {
            pedidoService.EstadoCambiado += OnEstadoCambiado;
            Console.WriteLine("AuditoriaObserver suscrito.");
        }
        public void Desuscribir(PedidoService pedidoService)
        {
            pedidoService.EstadoCambiado -= OnEstadoCambiado;
            Console.WriteLine("AuditoriaObserver desuscrito.");
        }
        private void OnEstadoCambiado(object? sender, PedidoChangedEventArgs e)
        {
            Console.WriteLine($"[Auditoría] Registro: PedidoId={e.PedidoId}, NuevoEstado={e.NuevoEstado}, Timestamp={e.Cuando:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
