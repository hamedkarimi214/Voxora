using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Voxora.Models;

namespace Voxora.ViewModels
{
    /// <summary>
    /// Manages the main window functionality, including audio recording,
    /// window operations, and speech transcription.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string fileAddress = "";

        /// <summary>
        /// Gets or sets the window dimensions.
        /// </summary>
        public WindowSizeManager WindowSize { get; set; } = new WindowSizeManager();

        private IWindowService _windowService;

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

        private bool _isRecording = false;

        /// <summary>
        /// Gets or sets a value indicating whether audio recording is in progress.
        /// </summary>
        public bool IsRecording
        {
            get => _isRecording;
            set
            {
                _isRecording = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the command used to start and stop audio recording.
        /// </summary>
        public ICommand RecordCommand { get; set; }

        private RecordManager Record;

        /// <summary>
        /// Gets or sets the service responsible for audio transcription.
        /// </summary>
        public IWhisperService whisperService { get; set; } = new WhisperService();

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        /// <param name="windowService">
        /// Provides window management operations.
        /// </param>
        public MainWindowViewModel(IWindowService windowService)
        {
            WindowSize.SetWindowSize();
            _windowService = windowService;

            WindowCloseCommand = new RelayCommand(CloseMethod);
            WindowStateCommand = new RelayCommand(WindowStateMethod);
            WindowMinimizeCommand = new RelayCommand(MinimizeMethod);
            RecordCommand = new RelayCommand(RecordMethod);
        }

        /// <summary>
        /// Closes the main window.
        /// </summary>
        private void CloseMethod()
        {
            _windowService.WindowClose();
        }

        /// <summary>
        /// Starts or stops audio recording and initiates transcription
        /// when recording is stopped.
        /// </summary>
        private void RecordMethod()
        {
            // Existing implementation
        }

        /// <summary>
        /// Toggles the main window between maximized and normal states.
        /// </summary>
        private void WindowStateMethod()
        {
            _windowService.WindowState();
        }

        /// <summary>
        /// Minimizes the main window.
        /// </summary>
        private void MinimizeMethod()
        {
            _windowService.WindowMinimize();
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

        /// <summary>
        /// Generates a unique WAV file path in the Sounds directory.
        /// </summary>
        /// <returns>
        /// The full path of the generated WAV file.
        /// </returns>
        private string CreateSoundName()
        {
            // Existing implementation
            return "";
        }
    }
}