namespace AppDeliveyGo
{
    public class PedidoService
    {
        public event EventHandler<PedidoChangedEventArgs>? EstadoCambiado;
        public void CambiarEstado(int pedidoId, EstadoPedido nuevoEstado)
        {
            System.Console.WriteLine($"--- Pedido {pedidoId}: Cambiando estado a {nuevoEstado} ---");
            EstadoCambiado?.Invoke(this, new PedidoChangedEventArgs(pedidoId, nuevoEstado, DateTime.Now));
        }
    }
}
