using AppDeliveyGo;

namespace AppDeliveryGo
{
    public class PedidoBuilder : IPedidoBuilder
    {
        private List<Item> _items = new List<Item>();
        private string _direccion = string.Empty;
        private string _tipoPago = string.Empty;
        private decimal _monto;
        private static int _nextId = 1; // Para generar IDs únicos

        public IPedidoBuilder ConItems(IEnumerable<(string sku, string name, decimal price, int amount)> items)
        {
            _items.AddRange(items.Select(i => new Item { Sku = i.sku, Name = i.name, Price = i.price, Amount = i.amount }));
            return this;
        }

        public IPedidoBuilder ConDireccion(string direccion)
        {
            _direccion = direccion;
            return this;
        }

        public IPedidoBuilder ConMetodoPago(string tipoPago)
        {
            _tipoPago = tipoPago;
            return this;
        }

        public void ConMonto(decimal v)
        {
            _monto = v;
        }

        public Pedido Build()
        {
            if (!_items.Any())
            {
                throw new InvalidOperationException("El pedido debe tener ítems.");
            }
            if (string.IsNullOrWhiteSpace(_direccion))
            {
                throw new InvalidOperationException("La dirección es obligatoria para el pedido.");
            }

            return new Pedido(_nextId++, _items, _direccion, _tipoPago, _monto);
        }
    }
}
