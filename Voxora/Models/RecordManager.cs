using NAudio.Wave;
using System.Windows;

namespace Voxora.Models
{
    /// <summary>
    /// Manages audio recording from the system's microphone
    /// and saves the captured audio to a WAV file.
    /// </summary>
    public class RecordManager
    {
        private WaveFormat _format;
        private WaveIn _input;
        private WaveFileWriter _file;

        /// <summary>
        /// Initializes a new instance of the RecordManager class.
        /// </summary>
        public RecordManager(string fileAddress)
        {
            if (WaveIn.DeviceCount < 1)
                throw new InvalidOperationException("Microphone not found.");

            _format = new WaveFormat(16000, 1);

            _file = new WaveFileWriter(fileAddress, _format);

            _input = new WaveIn();
            _input.DeviceNumber = 0;
            _input.WaveFormat = _format;

            _input.DataAvailable += _input_DataAvailable;
        }

        private void _input_DataAvailable(object? sender, WaveInEventArgs e)
        {
            _file.Write(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// Starts capturing audio from the microphone.
        /// </summary>
        public async void StartRecording()
        {
            _input.StartRecording();
        }

        /// <summary>
        /// Stops the audio recording and releases the associated resources.
        /// </summary>
        public async void StopRecording()
        {
            _input.StopRecording();
            _input.Dispose();
            _file.Close();
            _file.Dispose();
        }
    }
}