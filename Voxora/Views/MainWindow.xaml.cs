using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using Voxora.ViewModels;

namespace Voxora
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();

            InitializeComponent();
        }
    }
}