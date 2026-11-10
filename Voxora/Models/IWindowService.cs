namespace Voxora.Models
{
    /// <summary>
    /// Defines the contract for managing window operations.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Closes the current window.
        /// </summary>
        void WindowClose();

        /// <summary>
        /// Toggles the window between maximized and normal states.
        /// </summary>
        void WindowState();

        /// <summary>
        /// Minimizes the current window.
        /// </summary>
        void WindowMinimize();
    }
}