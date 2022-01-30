using HDE.Platform.Logging;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Services
{
    internal class AudioDevicesListService
    {
        private readonly ILog _log;

        public AudioDevicesListService(ILog log)
        {
            _log = log;
        }

        public MMDevice GetInputDevice(string friendlyName)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
                {
                    if (device.FriendlyName == friendlyName)
                        return device;
                }
            }
            throw new Exception("Device was not found!");
        }

        public MMDevice GetOutputDevice(string friendlyName)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
                    if (device.FriendlyName == friendlyName)
                        return device;
                }
            }
            throw new Exception("Device was not found!");
        }

        public List<string> GetInputDevices()
        {
            _log.Debug("Get list of input devices");
            var names = new List<string>();
            using (var enumerator = new MMDeviceEnumerator())
            {
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
                {
                    names.Add(device.FriendlyName);
                    _log.Debug($"Input device {device.FriendlyName}");
                }
            }
            return names;
        }

        public string GetDefaultInputDevice()
        {
            _log.Debug("Get default input device");
            try
            {
                using (var enumerator = new MMDeviceEnumerator())
                {
                    var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
                    _log.Debug($"Default input device is {device.FriendlyName}");
                    return device.FriendlyName;
                }
            } 
            catch (Exception e)
            {
                _log.Error(e);
                return null;
            }

        }

        public string GetDefaultOutputDevice()
        {
            _log.Debug("Get default output device");
            try
            {
                using (var enumerator = new MMDeviceEnumerator())
                {
                    var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                    _log.Debug($"Default output device is {device.FriendlyName}");
                    return device.FriendlyName;
                }
            } 
            catch (Exception e)
            {
                _log.Error(e);
                return null;
            }
        }

        public List<string> GetOutputDevices()
        {
            _log.Debug("Get list of output devices");
            var names = new List<string>();
            using (var enumerator = new MMDeviceEnumerator())
            {
                foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
                    _log.Debug($"Output device {device.FriendlyName}");
                    names.Add(device.FriendlyName);
                }
            }
            return names;
        }
    }
}
