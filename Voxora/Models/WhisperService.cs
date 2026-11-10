using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Voxora.Views;

namespace Voxora.Models
{
    /// <summary>
    /// Manages audio transcription using the Whisper speech recognition engine.
    /// </summary>
    public class WhisperService : IWhisperService, INotifyPropertyChanged
    {
        private bool _isTranscribing;
        /// <summary>
        /// Gets or sets a value indicating whether audio transcription is in progress.
        /// </summary>
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
        /// <summary>
        /// Gets or sets a value indicating whether audio recording is allowed.
        /// </summary>
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

        /// <summary>
        /// Starts the transcription process for the specified audio file
        /// on a separate thread.
        /// </summary>
        /// <param name="soundName">
        /// The name of the audio file to transcribe.
        /// </param>
        public void TranscribeVoice(string soundName)
        {
            IsTranscribing = true;
            CanRecord = false;

            Thread thread = new Thread(() =>
            {
                TranscribeThread(soundName);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        private void TranscribeThread(string soundName)
        {
            try
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
                ShowTranscribedText(Path.GetFileNameWithoutExtension(soundName));
            }
            finally
            {
                IsTranscribing = false;
                CanRecord = true;
            }
        }

        private void ShowTranscribedText(string soundName)
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
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
