using System.Windows;
using Voxora.ViewModels;

namespace Voxora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set data context
            DataContext = new MainWindowViewModel();
        }
    }
}