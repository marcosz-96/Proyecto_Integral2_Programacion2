namespace AppDeliveyGo
{
    public class Item
    {
        public string Sku { get; init; } = ""; 
        public string Name { get; init; } = "";
        public decimal Price { get; init; }
        public int Amount { get; set; } // CANTIDAD
    }
}
