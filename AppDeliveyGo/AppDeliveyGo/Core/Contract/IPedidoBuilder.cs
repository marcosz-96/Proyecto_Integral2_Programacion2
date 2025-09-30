namespace AppDeliveyGo
{
    public interface IPedidoBuilder
    {
        IPedidoBuilder ConItems(IEnumerable<(string sku, string name, decimal price, int amount)> items);
        IPedidoBuilder ConDireccion(string direccion);
        IPedidoBuilder ConMetodoPago(string tipoPago); // "tarjeta", "mp", "transf", "adapter"
        Pedido Build();
        void ConMonto(decimal v);
    }
}
