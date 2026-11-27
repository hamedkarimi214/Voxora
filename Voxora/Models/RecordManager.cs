using NAudio.Wave;
using System.IO;

namespace Voxora.Models
{
    public class RecordManager
    {
        private WaveFormat _format;
        private WaveIn _input;
        private WaveFileWriter _file;

        public RecordManager(string fileAddress)
        {
            _format = new WaveFormat(16000, 1);

            _file = new WaveFileWriter(fileAddress, _format);

            _input = new WaveIn();
            _input.WaveFormat = _format;

            _input.DataAvailable += _input_DataAvailable;
        }

        private void _input_DataAvailable(object? sender, WaveInEventArgs e)
        {
            _file.Write(e.Buffer, 0, e.BytesRecorded);
        }

        public async void StartRecording()
        {
            _input.StartRecording();
        }

        public async void StopRecording()
        {
            _input.StopRecording();
            _input.Dispose();
            _file.Close();
            _file.Dispose();
        }
    }
}
