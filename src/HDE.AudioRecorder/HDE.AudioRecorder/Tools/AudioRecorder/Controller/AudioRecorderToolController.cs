using HDE.AudioRecorder.Model;
using HDE.AudioRecorder.Services;
using HDE.Platform.Logging;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Controller
{
    class AudioRecorderToolController: IDisposable
    {
        public readonly AppModel Model = new AppModel();
        public readonly ILog Log;

        private readonly AudioDevicesListService _audioDevicesListService = new AudioDevicesListService();
        private readonly AudioRecorderService _audioRecorderService = new AudioRecorderService();
        
        public AudioRecorderToolController(ILog log)
        {
            Log = log;
        }

        public void Initialize()
        {
            Model.InputDevices = _audioDevicesListService.GetInputDevices();
            Model.OutputDevices = _audioDevicesListService.GetOutputDevices();
            Model.DefaultOutputDevice = _audioDevicesListService.GetDefaultOutputDevice();
            Model.DefaultInputDevice = _audioDevicesListService.GetDefaultInputDevice();
            
            Model.OutputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Audio Conference Recordings");
            if (!Directory.Exists(Model.OutputFolder))
                Directory.CreateDirectory(Model.OutputFolder);
        }

        public string Start(string inputDeviceFrinedlyName, string outputDeviceFriendlyName, string folder)
        {
            return _audioRecorderService.StartRecording(inputDeviceFrinedlyName, outputDeviceFriendlyName, folder);
        }

        public bool IsAudioRecording
        {
            get
            {
                return _audioRecorderService.IsAudioRecording;
            }
        }

        public void Stop()
        {
            _audioRecorderService.StopRecording();
        }

        public void Dispose()
        {

        }
    }
}
