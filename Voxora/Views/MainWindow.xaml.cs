using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Voxora.Models;
using Voxora.ViewModels;

namespace Voxora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets up the WindowService, DataContext, and loads UI components.
        /// </summary>
        public MainWindow()
        {
            // Initialize the window service to manage window state actions from the ViewModel
            var windowService = new WindowService(this);

            // Bind the ViewModel to the DataContext of this window
            DataContext = new MainWindowViewModel(windowService);

            // Initialize XAML components
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseDown event on the header grid to enable window dragging.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Instance of MouseButtonEventArgs containing event data.</param>
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the left mouse button is pressed to initiate drag move
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}