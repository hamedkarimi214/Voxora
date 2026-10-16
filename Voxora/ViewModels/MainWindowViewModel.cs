using System.Windows.Input;
using Voxora.Models;

namespace Voxora.ViewModels
{
    /// <summary>
    /// ViewModel for the MainWindow, handling commands, state, and window interactions.
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// Gets or sets the window size manager responsible for calculating dynamic window dimensions.
        /// </summary>
        public WindowSizeManager WindowSize { get; set; } = new WindowSizeManager();

        /// <summary>
        /// Service interface used to execute window operations (Close, Minimize, Maximize/Restore).
        /// </summary>
        private IWindowService _windowService;

        /// <summary>
        /// Gets or sets the command executed when closing the window.
        /// </summary>
        public ICommand WindowClose { get; set; }

        /// <summary>
        /// Gets or sets the command executed when toggling the window state (Maximized/Normal).
        /// </summary>
        public ICommand WindowState { get; set; }

        /// <summary>
        /// Gets or sets the command executed when minimizing the window.
        /// </summary>
        public ICommand WindowMinimize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="windowService">The window service instance for window control.</param>
        public MainWindowViewModel(IWindowService windowService)
        {
            // Set initial dynamic window dimensions
            WindowSize.SetWindowSize();

            // Assign the passed window service instance
            _windowService = windowService;

            // Initialize commands with their respective execution methods
            WindowClose = new RelayCommand(CloseMethod);
            WindowState = new RelayCommand(WindowStateMethod);
            WindowMinimize = new RelayCommand(MinimizeMethod);
        }

        /// <summary>
        /// Invokes the window service method to close the application window.
        /// </summary>
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        /// <summary>
        /// Invokes the window service method to toggle between maximized and normal window states.
        /// </summary>
        private void WindowStateMethod()
        {
            _windowService.WindowState();
        }

        /// <summary>
        /// Invokes the window service method to minimize the application window.
        /// </summary>
        private void MinimizeMethod()
        {
            _windowService.WindowMinimize();
        }
    }
}