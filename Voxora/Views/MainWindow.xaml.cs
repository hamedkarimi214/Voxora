using System.Windows;
using System.Windows.Input;
using Voxora.Models;
using Voxora.ViewModels;

namespace Voxora
{
    public partial class MainWindow : Window
    {
        // Initializes the window and its ViewModel
        public MainWindow()
        {
            var windowService = new WindowService(this);

            InitializeComponent();

            DataContext = new MainWindowViewModel(windowService);
        }

        // Allows the window to be dragged by its header
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}