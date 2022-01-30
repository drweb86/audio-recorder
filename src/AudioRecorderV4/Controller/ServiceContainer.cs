using AudioRecorderV4.Services;
using HDE.AudioRecorder.Tools.AudioRecorder.Services;
using HDE.Platform.Logging;
using System;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Controller
{
    class ServiceContainer: IDisposable
    {
        public ServiceContainer(ILog log)
        {
            Log = log;

            MMDeviceEnumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            AudioDeviceUpdateNotificationClient = new AudioDeviceUpdateNotificationClient(MMDeviceEnumerator);
            AudioDevicesListService = new AudioDevicesListService(log, MMDeviceEnumerator);
            AudioRecorderService = new AudioRecorderService(AudioDevicesListService, log);
            AudioRecorderSettingsService = new AudioRecorderSettingsService(log);
        }

        public readonly NAudio.CoreAudioApi.MMDeviceEnumerator MMDeviceEnumerator;
        public readonly ILog Log;
        public readonly AudioDevicesListService AudioDevicesListService;
        public readonly AudioRecorderService AudioRecorderService;
        public readonly AudioRecorderSettingsService AudioRecorderSettingsService;
        public readonly AudioDeviceUpdateNotificationClient AudioDeviceUpdateNotificationClient;

        public void Dispose()
        {
            AudioDeviceUpdateNotificationClient.Dispose();
            Log.Close();
        }
    }
}
