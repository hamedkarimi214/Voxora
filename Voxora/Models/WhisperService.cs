using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace Voxora.Models
{
    public class WhisperService : IWhisperService
    {
        public void TranscribeVoice(string soundName)
        {
            string fileAddress = $"{Environment.CurrentDirectory}\\Sounds\\{soundName}";

            string command = $"whisper \"{fileAddress}\" --model turbo --language fa";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.Arguments = $"/c {command}";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
            process.WaitForExit();
        }
    }
}
