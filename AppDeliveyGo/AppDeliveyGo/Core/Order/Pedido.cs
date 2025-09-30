namespace AppDeliveyGo
{
    public class Pedido
    {
        public int Id { get; init; }
        public IEnumerable<Item> Items { get; init; }
        public string Direccion { get; init; }
        public string TipoPago { get; init; }
        public EstadoPedido Estado { get; set; }
        public decimal Monto { get; init; }
        // Constructor para el Builder
        public Pedido(int id, IEnumerable<Item> items, string direccion, string tipoPago, decimal monto)
        {
            Id = id;
            Items = items;
            Direccion = direccion;
            TipoPago = tipoPago;
            Monto = monto;
            Estado = EstadoPedido.Recibido; // Estado inicial
        }
    }
}
