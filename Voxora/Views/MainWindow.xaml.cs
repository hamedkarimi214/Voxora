using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Voxora.Models;
using Voxora.ViewModels;

namespace Voxora
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var windowService = new WindowService(this);

            DataContext = new MainWindowViewModel(windowService);

            InitializeComponent();
        }

        // Window Drag
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}