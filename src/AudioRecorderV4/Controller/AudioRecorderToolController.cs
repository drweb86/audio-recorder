using HDE.AudioRecorder.Tools.AudioRecorder.Commands;
using HDE.AudioRecorder.Tools.AudioRecorder.Model;
using HDE.Platform.Logging;
using System;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Controller
{

    class AudioRecorderToolController: IDisposable
    {
        public readonly ServiceContainer Services;
        public readonly AudioRecorderToolModel Model;
        public AudioRecorderToolController(ILog log)
        {
            Model = new AudioRecorderToolModel();
            Services = new ServiceContainer(log);
        }

        public void Initialize()
        {
            new InitializeCommand().Execute(this);
        }

        public void Start()
        {
            Services.AudioRecorderService.StartRecording(Model.Settings.AudioInputDevice, Model.Settings.AudioOutputDevice, Model.Settings.SaveRecordingToFolder);
        }

        public bool IsAudioRecording
        {
            get
            {
                return Services.AudioRecorderService.IsAudioRecording;
            }
        }

        public void Stop()
        {
            Services.AudioRecorderService.StopRecording();
        }

        public void Dispose()
        {
            if (IsAudioRecording)
            {
                Stop();
            }
        }

        internal void OpenOutputFolder()
        {
            new OpenOutputFolderCommand().Execute(this);
        }

        internal void OpenLogsFolder()
        {
            new OpenLogsFolderCommand().Execute(this);
        }

        public void UpdateAudioInputDevice(string audioInputDevice)
        {
            new UpdateSettingsCommand().UpdateAudioInputDevice(this, audioInputDevice);
        }

        public void UpdateAudioOutputDevice(string audioOutputDevice)
        {
            new UpdateSettingsCommand().UpdateAudioOutputDevice(this, audioOutputDevice);
        }

        public void UpdateSaveRecordingToFolder(string saveRecordingToFolder)
        {
            new UpdateSettingsCommand().UpdateSaveRecordingToFolder(this, saveRecordingToFolder);
        }

        internal string ToggleAudioInputDevice()
        {
            return new ToggleAudioInputDeviceCommand().Execute(this);
        }

        internal string ToggleAudioOutputDevice()
        {
            return new ToggleAudioOutputDeviceCommand().Execute(this);
        }
    }
}
