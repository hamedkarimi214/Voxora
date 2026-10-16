using System.Windows;

namespace Voxora.Models
{
    /// <summary>
    /// Implementation of <see cref="IWindowService"/> to manipulate WPF Window states.
    /// </summary>
    public class WindowService : IWindowService
    {
        /// <summary>
        /// Reference to the target WPF Window instance.
        /// </summary>
        private Window _window;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowService"/> class.
        /// </summary>
        /// <param name="window">The window to be managed.</param>
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
        /// Toggles the window state between Maximized and Normal.
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