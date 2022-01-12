using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace HDE.AudioRecorder.Services
{
    internal class AudioDevicesListService
    {
        public List<string> GetInputDevices()
        {
            var names = new List<string>();
            using (var enumerator = new MMDeviceEnumerator())
            {
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
                {
                    names.Add(device.FriendlyName);
                }
            }
            return names;
        }

        public string GetDefaultInputDevice()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
            return device.FriendlyName;
        }

        public string GetDefaultOutputDevice()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            return device.FriendlyName;
        }

        public List<string> GetOutputDevices()
        {
            var names = new List<string>();
            using (var enumerator = new MMDeviceEnumerator())
            {
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
                    names.Add(device.FriendlyName);
                }
            }
            return names;
        }
    }
}
