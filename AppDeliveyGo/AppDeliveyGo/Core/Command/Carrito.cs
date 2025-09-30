namespace AppDeliveyGo
{
    public class Carrito
    {
        private readonly Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public void Agregar(Item i)
        {
            if (_items.ContainsKey(i.Sku))
            {
                _items[i.Sku].Amount += i.Amount;
            }
            else
            {
                _items.Add(i.Sku, i);
            }
        }

        public Item? Quitar(string sku)
        {
            if (_items.Remove(sku, out Item? removedItem))
            {
                return removedItem;
            }
            return null;
        }

        public bool SetCantidad(string sku, int newAmount)
        {
            if (_items.ContainsKey(sku))
            {
                _items[sku].Amount = newAmount;
                return true;
            }
            return false;
        }

        public decimal Subtotal()
        {
            return _items.Values.Sum(i => i.Price * i.Amount);
        }

        public IEnumerable<Item> GetItems()
        {
            return _items.Values;
        }
    }
}
