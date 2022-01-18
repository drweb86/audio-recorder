using HDE.AudioRecorder.Tools.AudioRecorder.Model;
using HDE.Platform.Logging;
using HDE.Platform.Services;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Services
{
    internal class AudioRecorderSettingsService : SettingsService<AudioRecorderSettings>
    {
        public AudioRecorderSettingsService(
            ILog log) : base(log, 
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "HDE",
                    "AudioRecorder",
                    "1.0"), 
                "AudioRecorder Settings v1.xml")
        {
        }
    }
}
