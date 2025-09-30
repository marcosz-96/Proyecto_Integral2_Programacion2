namespace AppDeliveyGo
{
    public class QuitarItemCommand : ICommand
    {
        private Carrito _carrito;
        private string _sku;
        private Item? _backup; // Esto guarda el item que se quitó para poder deshacer lo deshecho (por así decirlo)

        public QuitarItemCommand(Carrito carrito, string sku)
        {
            _carrito = carrito;
            _sku = sku;
        }

        public void Execute()
        {
            _backup = _carrito.Quitar(_sku);
        }

        public void Undo()
        {
            if (_backup != null)
            {
                _carrito.Agregar(_backup);
            }
        }
    }
}
