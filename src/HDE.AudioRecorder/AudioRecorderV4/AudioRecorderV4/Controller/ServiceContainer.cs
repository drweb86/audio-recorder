using HDE.AudioRecorder.Tools.AudioRecorder.Services;
using HDE.Platform.Logging;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Controller
{
    class ServiceContainer
    {
        public ServiceContainer(ILog log)
        {
            Log = log;

            AudioDevicesListService = new AudioDevicesListService();
            AudioRecorderService = new AudioRecorderService();
            AudioRecorderSettingsService = new AudioRecorderSettingsService(log);

        }

        public readonly ILog Log;
        public readonly AudioDevicesListService AudioDevicesListService;
        public readonly AudioRecorderService AudioRecorderService;
        public readonly AudioRecorderSettingsService AudioRecorderSettingsService;
    }
}
