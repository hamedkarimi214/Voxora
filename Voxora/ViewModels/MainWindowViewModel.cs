using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Voxora.Models;

namespace Voxora.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        string fileAddress = "";

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

        private bool _isTranscribing;
        public bool IsTranscribing
        {
            get => _isTranscribing;
            set
            {
                if (_isTranscribing == value)
                    return;

                _isTranscribing = value;
                OnPropertyChanged(nameof(IsTranscribing));
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
                fileAddress = CreateSoundName();
                Record = new RecordManager(fileAddress);
                Record.StartRecording();
            }
            else
            {
                IsTranscribing = true;
                Record.StopRecording();
                IWhisperService whisperService = new WhisperService();
                whisperService.TranscribeVoice(Path.GetFileName(fileAddress));
                IsTranscribing = false;
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

        private string CreateSoundName()
        {
            string fileAddress = "";

            string folderAddress = Path.Combine(Environment.CurrentDirectory, "Sounds");

            if (!Directory.Exists(folderAddress))
            {
                Directory.CreateDirectory(folderAddress);
                fileAddress = $"{folderAddress}\\Voxora1.wav";
            }
            else
            {
                var file = Directory.EnumerateFiles(folderAddress, "*.wav")
                    .Where(f => Path.GetFileName(f).StartsWith("Voxora"));

                HashSet<int> foundedNum = new HashSet<int>();
                string str = "";

                foreach (var f in file)
                {
                    str = Path.GetFileNameWithoutExtension(f);
                    str = str.Substring(6);

                    if (int.TryParse(str, out int outNum))
                        foundedNum.Add(outNum);
                }

                int checkedNumber = 1;

                while (true)
                {
                    if (foundedNum.Contains(checkedNumber))
                        checkedNumber++;
                    else
                    {
                        fileAddress = $"{folderAddress}\\Voxora{checkedNumber}.wav";
                        break;
                    }
                }
            }

            return fileAddress;
        }
    }
}