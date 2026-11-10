namespace Voxora.Models
{
    public interface IWhisperService
    {
        /// <summary>
        /// Convert an audio file into text using Whisper model
        /// </summary>
        void TranscribeVoice(string soundName);
    }
}
