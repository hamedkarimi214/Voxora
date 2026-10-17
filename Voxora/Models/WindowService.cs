using System.Windows;

namespace Voxora.Models
{
    public class WindowService : IWindowService
    {
        // Stores the window managed by this service
        private Window _window;

        // Initializes the service with a target window
        public WindowService(Window window)
        {
            _window = window;
        }

        // Closes the window
        public void WindowClose()
        {
            _window.Close();
        }

        // Minimizes the window
        public void WindowMinimize()
        {
            _window.WindowState = System.Windows.WindowState.Minimized;
        }

        // Toggles between maximized and normal states
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