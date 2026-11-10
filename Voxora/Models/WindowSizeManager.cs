using System.Windows;

namespace Voxora.Models
{
    /// <summary>
    /// Manages the window dimensions based on the screen resolution.
    /// </summary>
    public class WindowSizeManager
    {
        /// <summary>
        /// Gets or sets the window width.
        /// </summary>
        public double WindowWidth { get; set; } = 600;

        /// <summary>
        /// Gets or sets the window height.
        /// </summary>
        public double WindowHeight { get; set; } = 600;

        /// <summary>
        /// Sets the window dimensions to 70% of the primary screen resolution.
        /// </summary>
        public void SetWindowSize()
        {
            // Use 70% of the screen width
            WindowWidth = SystemParameters.PrimaryScreenWidth * 0.7;

            // Use 70% of the screen height
            WindowHeight = SystemParameters.PrimaryScreenHeight * 0.7;
        }
    }
}