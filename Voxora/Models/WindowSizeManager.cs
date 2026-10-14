using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Voxora.Models
{
    public class WindowSizeManager
    {
        // Constructor
        public WindowSizeManager()
        {
            // Set window width
            WindowWidth = SystemParameters.PrimaryScreenWidth * 0.7;

            // Set window height
            WindowHeight = SystemParameters.PrimaryScreenHeight * 0.7;
        }

        // Window width property
        public double WindowWidth { get; set; }

        // Window height property
        public double WindowHeight { get; set; }
    }
}
