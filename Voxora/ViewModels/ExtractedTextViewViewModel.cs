using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Voxora.Models;
using static System.Net.Mime.MediaTypeNames;

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

        public ExtractedTextViewViewModel(WindowService windowService, string textExtract)
        {
            _windowService = windowService;

            // Connect commands to their methods
            WindowCloseCommand = new RelayCommand(CloseMethod);
            WindowStateCommand = new RelayCommand(WindowStateMethod);
            WindowMinimizeCommand = new RelayCommand(MinimizeMethod);
            CopyTextCommand = new RelayCommand(CopyTextMethod);

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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? ""));
        }
    }
}
