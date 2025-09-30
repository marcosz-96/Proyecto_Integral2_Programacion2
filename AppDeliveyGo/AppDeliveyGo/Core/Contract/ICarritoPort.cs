namespace AppDeliveyGo
{
    public interface ICarritoPort
    {
        decimal Subtotal();
        void Run(ICommand cmd);
        void Undo();
        void Redo();
    }
}
