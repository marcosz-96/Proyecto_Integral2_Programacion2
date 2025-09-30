namespace AppDeliveyGo
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
