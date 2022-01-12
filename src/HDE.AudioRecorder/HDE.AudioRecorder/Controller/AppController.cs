using HDE.AudioRecorder.Model;
using HDE.AudioRecorder.Services;

namespace HDE.AudioRecorder.Controller
{
    internal class AppController
    {
        public readonly AppModel Model = new AppModel();

        private readonly AudioDevicesListService _audioDevicesListService = new AudioDevicesListService();

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
    }
}
