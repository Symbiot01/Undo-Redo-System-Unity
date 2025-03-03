using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private static Stack<ICommand> _undoStack = new Stack<ICommand>();
    private static Stack<ICommand> _redoStack = new Stack<ICommand>();

    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear(); // Clear redo stack on new command execution.
    }

    public static void UndoCommand()
    {
        if (_undoStack.Count > 0)
        {
            ICommand command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }
    }

    public static void RedoCommand()
    {
        if (_redoStack.Count > 0)
        {
            ICommand command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
        }
    }
}
