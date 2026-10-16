using System;
using System.Collections.Generic;
using System.Text;

namespace Voxora.Models
{
    /// <summary>
    /// Defines methods for controlling window operations from ViewModels.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Closes the window.
        /// </summary>
        void WindowClose();

        /// <summary>
        /// Toggles the window state (Maximized/Normal).
        /// </summary>
        void WindowState();

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        void WindowMinimize();
    }
}