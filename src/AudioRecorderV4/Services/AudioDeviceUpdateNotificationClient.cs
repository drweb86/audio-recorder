using NAudio.CoreAudioApi;
using System;

namespace AudioRecorderV4.Services
{
    public class AudioDeviceUpdateNotificationClient : NAudio.CoreAudioApi.Interfaces.IMMNotificationClient, IDisposable
    {
        private readonly MMDeviceEnumerator mMDeviceEnumerator;

        public AudioDeviceUpdateNotificationClient(MMDeviceEnumerator mMDeviceEnumerator)
        {
            mMDeviceEnumerator.RegisterEndpointNotificationCallback(this);
            this.mMDeviceEnumerator = mMDeviceEnumerator;
        }

        public EventHandler AudioDeviceChanges { get; set; }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            AudioDeviceChanges?.Invoke(this, null);
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
            AudioDeviceChanges?.Invoke(this, null);
        }

        public void OnDeviceRemoved(string deviceId)
        {
            AudioDeviceChanges?.Invoke(this, null);
        }

        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
        }

        public void Dispose()
        {
            mMDeviceEnumerator.UnregisterEndpointNotificationCallback(this);
        }
    }
}
