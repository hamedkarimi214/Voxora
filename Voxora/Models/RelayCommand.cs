using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Voxora.Models
{
    /// <summary>
    /// A basic command that relays its functionality by delegating invokes to delegates.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Optional predicate function to determine if the command can execute.
        /// </summary>
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// The action to be executed when the command is invoked.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class with execution and condition logic.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns>True if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}