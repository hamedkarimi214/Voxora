using System;
using System.Collections.Generic;
using System.Text;
using Voxora.Models;

namespace Voxora.ViewModels
{
    public class MainWindowViewModel
    {
        // Property for set window size
        public WindowSizeManager WindowSize { get; set; }

        // Constructor
        public MainWindowViewModel()
        {
            // Assign WindowSize property
            WindowSize = new WindowSizeManager();
        }
    }
}
