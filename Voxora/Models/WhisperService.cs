using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Voxora.Views;

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

        private bool _canRecord = true;
        public bool CanRecord
        {
            get => _canRecord;
            set
            {
                if (_canRecord == value)
                    return;

                _canRecord = value;
                OnPropertyChanged(nameof(CanRecord));
            }
        }

        public void TranscribeVoice(string soundName)
        {
            IsTranscribing = true;
            CanRecord = false;
            Thread thread = new Thread(() =>
            {
                TranscribeThread(soundName);

                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        private void TranscribeThread(string soundName)
        {
            string fileAddress = $"{Environment.CurrentDirectory}\\Sounds\\{soundName}";

            string command = $"whisper \"{fileAddress}\" --model turbo --language en";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.Arguments = $"/c {command}";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
            process.WaitForExit();
            ShowTranscribedVoid(Path.GetFileNameWithoutExtension(soundName));
            IsTranscribing = false;
            CanRecord = true;
        }

        private void ShowTranscribedVoid(string soundName)
        {
            string fullAddress = $"{AppDomain.CurrentDomain.BaseDirectory}\\{soundName}.txt";

            string text = GetTextOfFile(fullAddress);

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("No text extract.");
                return;
            }

            ExtractedTextView textView = new ExtractedTextView(text);
            textView.Show();
        }

        private string GetTextOfFile(string fileAddress)
        {
            string txt = File.ReadAllText(fileAddress);

            return txt;
        }

        // Notifies the UI when a property changes
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
