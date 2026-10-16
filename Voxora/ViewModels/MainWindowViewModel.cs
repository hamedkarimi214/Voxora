using System.Windows.Input;
using Voxora.Models;

namespace Voxora.ViewModels
{
    public class MainWindowViewModel
    {
        // Property for set window size
        public WindowSizeManager WindowSize { get; set; } = new WindowSizeManager();

        // Interface for window setting
        private IWindowService _windowService;

        // Close command
        public ICommand WindowClose { get; set; }
        // Change window state command
        public ICommand WindowState { get; set; }
        // Minimize window command
        public ICommand WindowMinimize { get; set; }

        // Constructor
        public MainWindowViewModel(IWindowService windowService)
        {
            // Set window size
            WindowSize.SetWindowSize();

            // Assign window service
            _windowService = windowService;

            // Assign commands
            WindowClose = new RelayCommand(CloseMethod);
            WindowState = new RelayCommand(WindowStateMethod);
            WindowMinimize = new RelayCommand(MinimizeMethod);
        }

        // Method for close window
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        // Method for change window state
        private void WindowStateMethod()
        {
            _windowService.WindowState();
        }

        // Method for minimize window
        private void MinimizeMethod()
        {
            _windowService.WindowMinimize();
        }
    }
}
