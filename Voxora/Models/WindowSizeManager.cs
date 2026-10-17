using System.Windows;

namespace Voxora.Models
{
    public class WindowSizeManager
    {
        // Gets or sets the window width
        public double WindowWidth { get; set; } = 600;

        // Gets or sets the window height
        public double WindowHeight { get; set; } = 600;

        // Sets window dimensions based on screen resolution
        public void SetWindowSize()
        {
            // Use 70% of the screen width
            WindowWidth = SystemParameters.PrimaryScreenWidth * 0.7;

            // Use 70% of the screen height
            WindowHeight = SystemParameters.PrimaryScreenHeight * 0.7;
        }
    }
}