namespace AppDeliveyGo
{
    public class EditorCarrito 
    {
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void Run(ICommand cmd)
        {
            cmd.Execute();
            _undoStack.Push(cmd);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand cmd = _undoStack.Pop();
                cmd.Undo();
                _redoStack.Push(cmd);
            }
            else
            {
                Console.WriteLine("[ATENCION] No hay acciones para deshacer");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                ICommand cmd = _redoStack.Pop();
                cmd.Execute();
                _undoStack.Push(cmd);
            }
            else
            {
                Console.WriteLine("[ATENCION] No hay acciones para rehacer");
            }
        }
    }
}
