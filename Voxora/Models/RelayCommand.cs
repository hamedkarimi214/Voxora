using System.Windows.Input;

namespace Voxora.Models
{
    public class RelayCommand : ICommand
    {
        // Determines whether the command can execute
        private readonly Func<bool>? _canExecute;

        // Defines the command execution logic
        private readonly Action _execute;

        // Notifies the UI when execution availability changes
        public event EventHandler? CanExecuteChanged;

        // Creates a command that can always execute
        public RelayCommand(Action execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        // Creates a command with an execution condition
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Checks whether the command can execute
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        // Executes the command
        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}