using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Voxora.Models
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Func<bool>? _canExecute;
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
