using System.Windows;

namespace Voxora.Models
{
    /// <summary>
    /// Provides window management operations such as closing,
    /// minimizing, and changing the window state.
    /// </summary>
    public class WindowService : IWindowService
    {
        private Window _window;

        /// <summary>
        /// Initializes a new instance of the WindowService class.
        /// </summary>
        /// <param name="window">
        /// The window managed by this service.
        /// </param>
        public WindowService(Window window)
        {
            _window = window;
        }

        /// <summary>
        /// Closes the managed window.
        /// </summary>
        public void WindowClose()
        {
            _window.Close();
        }

        /// <summary>
        /// Minimizes the managed window.
        /// </summary>
        public void WindowMinimize()
        {
            _window.WindowState = System.Windows.WindowState.Minimized;
        }

        /// <summary>
        /// Toggles the managed window between maximized and normal states.
        /// </summary>
        public void WindowState()
        {
            if (_window.WindowState == System.Windows.WindowState.Maximized)
            {
                _window.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                _window.WindowState = System.Windows.WindowState.Maximized;
            }
        }
    }
}