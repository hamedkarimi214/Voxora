using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Voxora.Models;
using System.Windows.Forms;
using System.IO;

namespace Voxora.ViewModels
{
    /// <summary>
    /// Manages the extracted text view, including window controls,
    /// text copying, and text exporting.
    /// </summary>
    public class ExtractedTextViewViewModel : INotifyPropertyChanged
    {
        private readonly IWindowService _windowService;

        /// <summary>
        /// Gets or sets the command used to close the window.
        /// </summary>
        public ICommand WindowCloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the command used to toggle the window state.
        /// </summary>
        public ICommand WindowStateCommand { get; set; }

        /// <summary>
        /// Gets or sets the command used to minimize the window.
        /// </summary>
        public ICommand WindowMinimizeCommand { get; set; }

        /// <summary>
        /// Gets or sets the command used to copy the extracted text.
        /// </summary>
        public ICommand CopyTextCommand { get; set; }

        /// <summary>
        /// Gets or sets the command used to export the extracted text.
        /// </summary>
        public ICommand ExportTextCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the ExtractedTextViewViewModel class.
        /// </summary>
        /// <param name="windowService">
        /// Provides window management operations.
        /// </param>
        /// <param name="textExtract">
        /// The text extracted from the audio file.
        /// </param>
        public ExtractedTextViewViewModel(
            WindowService windowService,
            string textExtract)
        {
            _windowService = windowService;

            WindowCloseCommand = new RelayCommand(CloseMethod);
            WindowStateCommand = new RelayCommand(WindowStateMethod);
            WindowMinimizeCommand = new RelayCommand(MinimizeMethod);
            CopyTextCommand = new RelayCommand(CopyTextMethod);
            ExportTextCommand = new RelayCommand(ExportTextMethod);

            ExtractedText = textExtract;
        }

        /// <summary>
        /// Closes the current window.
        /// </summary>
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        /// <summary>
        /// Toggles the current window between maximized and normal states.
        /// </summary>
        private void WindowStateMethod()
        {
            _windowService.WindowState();
        }

        /// <summary>
        /// Minimizes the current window.
        /// </summary>
        private void MinimizeMethod()
        {
            _windowService.WindowMinimize();
        }

        private string _extractedText;

        /// <summary>
        /// Gets or sets the text extracted from the audio file.
        /// </summary>
        public string ExtractedText
        {
            get => _extractedText;
            set
            {
                _extractedText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Copies the extracted text to the clipboard.
        /// </summary>
        private void CopyTextMethod()
        {
            System.Windows.Forms.Clipboard.SetText(ExtractedText);
        }

        /// <summary>
        /// Opens a save dialog and exports the extracted text to a file.
        /// </summary>
        private void ExportTextMethod()
        {
            if (string.IsNullOrWhiteSpace(ExtractedText))
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, ExtractedText);
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifies the UI that a property value has changed.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property that changed.
        /// </param>
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}