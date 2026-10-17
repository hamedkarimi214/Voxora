using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Voxora.Models;

namespace Voxora.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // Manages the window dimensions
        public WindowSizeManager WindowSize { get; set; } = new WindowSizeManager();

        // Handles window operations
        private IWindowService _windowService;

        // Window control commands
        public ICommand WindowCloseCommand { get; set; }
        public ICommand WindowStateCommand { get; set; }
        public ICommand WindowMinimizeCommand { get; set; }

        // Tracks the recording state
        private bool _isRecording = false;

        public bool IsRecording
        {
            get => _isRecording;
            set
            {
                _isRecording = value;
                OnPropertyChanged();
            }
        }

        // Starts and stops recording
        public ICommand RecordCommand { get; set; }

        private RecordManager Record;

        // Initializes the ViewModel and its commands
        public MainWindowViewModel(IWindowService windowService)
        {
            WindowSize.SetWindowSize();
            _windowService = windowService;

            // Connect commands to their methods
            WindowCloseCommand = new RelayCommand(CloseMethod);
            WindowStateCommand = new RelayCommand(WindowStateMethod);
            WindowMinimizeCommand = new RelayCommand(MinimizeMethod);
            RecordCommand = new RelayCommand(RecordMethod);
        }

        // Closes the window
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        // Toggles the recording state
        private void RecordMethod()
        {
            IsRecording = !IsRecording;

            if (IsRecording)
            {
                Record = new RecordManager();
                Record.StartRecording();
            }
            else
            {
                Record.StopRecording();
            }
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

        // Notifies the UI when a property changes
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}