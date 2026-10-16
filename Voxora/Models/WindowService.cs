using System.Windows;

namespace Voxora.Models
{
    public class WindowService : IWindowService
    {
        private Window _window;

        public WindowService(Window window)
        {
            _window = window;
        }

        public void WindowClose()
        {
            _window.Close();
        }

        public void WindowMinimize()
        {
            _window.WindowState = System.Windows.WindowState.Minimized;
        }

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
