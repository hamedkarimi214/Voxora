using System.Windows.Input;

namespace Voxora.Models
{
    /// <summary>
    /// Implements the ICommand interface to support command binding in MVVM.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Func<bool>? _canExecute;
        private readonly Action _execute;

        /// <summary>
        /// Occurs when the command's execution availability changes.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Initializes a command that can always execute.
        /// </summary>
        /// <param name="execute">
        /// The action to execute when the command is invoked.
        /// </param>
        public RelayCommand(Action execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        /// <summary>
        /// Initializes a command with a condition that determines
        /// whether the command can execute.
        /// </summary>
        /// <param name="execute">
        /// The action to execute when the command is invoked.
        /// </param>
        /// <param name="canExecute">
        /// A function that determines whether the command can execute.
        /// </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute.
        /// </summary>
        /// <param name="parameter">
        /// Data passed to the command. This implementation does not use it.
        /// </param>
        /// <returns>
        /// True if the command can execute; otherwise, false.
        /// </returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        /// <summary>
        /// Executes the command's associated action.
        /// </summary>
        /// <param name="parameter">
        /// Data passed to the command. This implementation does not use it.
        /// </param>
        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}