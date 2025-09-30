namespace AppDeliveyGo
{
    public class SetCantidadCommand : ICommand 
    {
        private Carrito _carrito;
        private string _sku;
        private int _newAmount;
        private int _previousAmount;
        private bool _applied; // Esto indica la operación aplicó realmente

        public SetCantidadCommand(Carrito carrito, string sku, int newAmount)
        {
            _carrito = carrito;
            _sku = sku;
            _newAmount = newAmount;
        }

        public void Execute()
        {
            // Se guarda la cantidad anterior antes de modificarla
            if (_carrito.GetItems().Any(a => a.Sku == _sku))
            {
                _previousAmount = _carrito.GetItems().First(a => a.Sku == _sku).Amount;
                _applied = _carrito.SetCantidad(_sku, _newAmount);
            }
            else
            {
                _applied = false;
            }
        }

        public void Undo()
        {
            if (_applied)
            {
                _carrito.SetCantidad(_sku, _previousAmount);
            }
        }
    }
}
