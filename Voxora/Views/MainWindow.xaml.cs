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

            DataContext = new MainWindowViewModel(windowService);

            InitializeComponent();
        }

        // Allows the window to be dragged by its header
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private bool _isRecording = false;

        private System.Windows.Media.Animation.Storyboard _pulseStoryboard =
            new System.Windows.Media.Animation.Storyboard();

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}