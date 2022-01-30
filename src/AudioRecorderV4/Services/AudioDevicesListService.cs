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
        private readonly MMDeviceEnumerator mMDeviceEnumerator;

        public AudioDevicesListService(ILog log, MMDeviceEnumerator mMDeviceEnumerator)
        {
            _log = log;
            this.mMDeviceEnumerator = mMDeviceEnumerator;
        }

        public MMDevice GetInputDevice(string friendlyName)
        {
            foreach (MMDevice device in mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                if (device.FriendlyName == friendlyName)
                    return device;
            }
            throw new Exception("Device was not found!");
        }

        public MMDevice GetOutputDevice(string friendlyName)
        {
            foreach (MMDevice device in mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                if (device.FriendlyName == friendlyName)
                    return device;
            }
            throw new Exception("Device was not found!");
        }

        public List<string> GetInputDevices()
        {
            _log.Debug("Get list of input devices");
            var names = new List<string>();
            foreach (MMDevice device in mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                names.Add(device.FriendlyName);
                _log.Debug($"Input device {device.FriendlyName}");
            }
            return names;
        }

        public string GetDefaultInputDevice()
        {
            _log.Debug("Get default input device");
            try
            {
                var device = mMDeviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
                _log.Debug($"Default input device is {device.FriendlyName}");
                return device.FriendlyName;
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
                var device = mMDeviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                _log.Debug($"Default output device is {device.FriendlyName}");
                return device.FriendlyName;
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
            foreach (MMDevice device in mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                _log.Debug($"Output device {device.FriendlyName}");
                names.Add(device.FriendlyName);
            }
            return names;
        }
    }
}
