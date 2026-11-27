using System;
using System.Collections.Generic;
using System.Text;

namespace Voxora.Models
{
    public interface IWhisperService
    {
        void TranscribeVoice(string soundName);
    }
}
