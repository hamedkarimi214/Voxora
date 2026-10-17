namespace Voxora.Models
{
    public interface IWindowService
    {
        // Closes the window
        void WindowClose();

        // Toggles between maximized and normal states
        void WindowState();

        // Minimizes the window
        void WindowMinimize();
    }
}