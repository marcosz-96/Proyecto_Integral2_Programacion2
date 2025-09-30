namespace AppDeliveyGo
{
    public class CarritoPort : ICarritoPort
    {
        private Carrito _carrito = new Carrito();
        private EditorCarrito _editor = new EditorCarrito();

        public decimal Subtotal()
        {
            return _carrito.Subtotal();
        }

        public void Run(ICommand cmd)
        {
            _editor.Run(cmd);
        }

        public void Undo()
        {
            _editor.Undo();
        }

        public void Redo()
        {
            _editor.Redo();
        }

        public IEnumerable<Item> GetCurrentItems()
        {
            return _carrito.GetItems();
        }

        public Carrito GetCurrentCarritoInstance()
        {
            return _carrito;
        }
    }
}
