using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Voxora.Models
{
    /// <summary>
    /// Manages the sizing logic and dimensions for the application window.
    /// </summary>
    public class WindowSizeManager
    {
        /// <summary>
        /// Calculates and sets the window width and height based on the primary screen resolution.
        /// </summary>
        public void SetWindowSize()
        {
            // Set window width to 70% of the primary screen width
            WindowWidth = SystemParameters.PrimaryScreenWidth * 0.7;

            // Set window height to 70% of the primary screen height
            WindowHeight = SystemParameters.PrimaryScreenHeight * 0.7;
        }

        /// <summary>
        /// Gets or sets the window width. Default value is 600.
        /// </summary>
        public double WindowWidth { get; set; } = 600;

        /// <summary>
        /// Gets or sets the window height. Default value is 600.
        /// </summary>
        public double WindowHeight { get; set; } = 600;
    }
}