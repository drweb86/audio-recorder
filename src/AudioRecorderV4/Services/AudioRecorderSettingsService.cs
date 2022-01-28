using HDE.AudioRecorder.Tools.AudioRecorder.Model;
using HDE.Platform.Logging;
using HDE.Platform.Services;
using System;
using System.IO;
using Windows.Storage;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Services
{
    internal class AudioRecorderSettingsService : SettingsService<AudioRecorderSettings>
    {
        public AudioRecorderSettingsService(
            ILog log) : base(log, 
                Path.Combine(
                    System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path,
                    "1.0",
                    "Settings"), 
                "Settings-v1.xml"))
        {
        }
    }
}
