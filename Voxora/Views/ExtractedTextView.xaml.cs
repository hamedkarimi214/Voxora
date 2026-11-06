using System.Windows;
using System.Windows.Input;
using Voxora.Models;
using Voxora.ViewModels;

namespace Voxora.Views
{
    /// <summary>
    /// Interaction logic for ExtractedTextView.xaml
    /// </summary>
    public partial class ExtractedTextView : Window
    {
        public ExtractedTextView(string text)
        {
            InitializeComponent();

            var windowService = new WindowService(this);

            DataContext = new ExtractedTextViewViewModel(windowService, text);
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
