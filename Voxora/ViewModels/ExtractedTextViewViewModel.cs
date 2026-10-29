using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Voxora.Models;

namespace Voxora.ViewModels
{
    public class ExtractedTextViewViewModel
    {
        public readonly IWindowService _windowService;

        // Window control commands
        public ICommand WindowCloseCommand { get; set; }
        public ICommand WindowStateCommand { get; set; }
        public ICommand WindowMinimizeCommand { get; set; }

        public ExtractedTextViewViewModel(WindowService windowService)
        {
            _windowService = windowService;

            // Connect commands to their methods
            WindowCloseCommand = new RelayCommand(CloseMethod);
            WindowStateCommand = new RelayCommand(WindowStateMethod);
            WindowMinimizeCommand = new RelayCommand(MinimizeMethod);
        }

        // Closes the window
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        // Changes the window state
        private void WindowStateMethod()
        {
            _windowService.WindowState();
        }

        // Minimizes the window
        private void MinimizeMethod()
        {
            _windowService.WindowMinimize();
        }
    }
}
