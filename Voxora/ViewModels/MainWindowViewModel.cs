using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Voxora.Models;

namespace Voxora.ViewModels
{
    public class MainWindowViewModel
    {
        // Property for set window size
        public WindowSizeManager WindowSize { get; set; } = new WindowSizeManager();

        // Constructor
        public MainWindowViewModel()
        {
            // Set window size
            WindowSize.SetWindowSize();
        }
    }
}
