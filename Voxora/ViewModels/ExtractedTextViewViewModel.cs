using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Voxora.Models;
using System.Windows.Forms;
using System.IO;

namespace Voxora.ViewModels
{
    public class ExtractedTextViewViewModel : INotifyPropertyChanged
    {
        public readonly IWindowService _windowService;

        // Window control commands
        public ICommand WindowCloseCommand { get; set; }
        public ICommand WindowStateCommand { get; set; }
        public ICommand WindowMinimizeCommand { get; set; }
        public ICommand CopyTextCommand { get; set; }
        public ICommand ExportTextCommand { get; set; }

        public ExtractedTextViewViewModel(WindowService windowService, string textExtract)
        {
            _windowService = windowService;

            // Connect commands to their methods
            WindowCloseCommand = new RelayCommand(CloseMethod);
            WindowStateCommand = new RelayCommand(WindowStateMethod);
            WindowMinimizeCommand = new RelayCommand(MinimizeMethod);
            CopyTextCommand = new RelayCommand(CopyTextMethod);
            ExportTextCommand = new RelayCommand(ExportTextMethod);

            ExtractedText = textExtract;
        }

        // Closes the window
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        // Changes the window state
        private void WindowStateMethod()
        {
            _windowService.WindowState();
        }

        // Minimizes the window
        private void MinimizeMethod()
        {
            _windowService.WindowMinimize();
        }

        private string _extractedText;
        public string ExtractedText
        {
            get => _extractedText;
            set
            {
                _extractedText = value;
                OnPropertyChanged();
            }
        }

        // Copy text
        private void CopyTextMethod()
        {
            System.Windows.Forms.Clipboard.SetText(ExtractedText);
        }

        // Export text to file
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? ""));
        }
    }
}
