using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Voxora.Models
{
    public class WhisperService : IWhisperService, INotifyPropertyChanged
    {
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

        public void TranscribeVoice(string soundName)
        {
            IsTranscribing = true;
            Thread thread = new Thread(() =>
            {
                TranscribeThread(soundName);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void TranscribeThread(string soundName)
        {
            string fileAddress = $"{Environment.CurrentDirectory}\\Sounds\\{soundName}";

            string command = $"whisper \"{fileAddress}\" --model turbo --language fa";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.Arguments = $"/c {command}";
            psi.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
            process.WaitForExit();
            IsTranscribing = false;
        }

        // Notifies the UI when a property changes
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
