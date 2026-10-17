using NAudio.Wave;
using System.IO;
using System.Windows;

namespace Voxora.Models
{
    public class RecordManager
    {
        private WaveFormat _format;
        private WaveIn _input;
        private WaveFileWriter _file;
        private int count = 1;
        string fileAddress = "";

        public RecordManager()
        {
            
        }

        private void CreateSoundName()
        {
            string folderAddress = Path.Combine(Environment.CurrentDirectory, "Sounds");

            if (!Directory.Exists(folderAddress))
            {
                Directory.CreateDirectory(folderAddress);
                fileAddress = Path.Combine(folderAddress, "\\Voxora1.wav");
            }
            else
            {
                var file = Directory.EnumerateFiles(folderAddress, "*.wav")
                    .Where(s => Path.GetFileName(s).StartsWith("Voxora"));

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
        }

        private void _input_DataAvailable(object? sender, WaveInEventArgs e)
        {
            _file.Write(e.Buffer, 0, e.BytesRecorded);
        }

        public async void StartRecording()
        {
             CreateSoundName();

            _format = new WaveFormat(16000, 1);

            _file = new WaveFileWriter(fileAddress, _format);

            _input = new WaveIn();
            _input.WaveFormat = _format;

            _input.DataAvailable += _input_DataAvailable;

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
