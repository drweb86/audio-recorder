using HDE.AudioRecorder.Tools.AudioRecorder.Commands;
using HDE.AudioRecorder.Tools.AudioRecorder.Model;
using HDE.Platform.Logging;

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

        public string Start(string inputDeviceFrinedlyName, string outputDeviceFriendlyName, string folder)
        {
            return Services.AudioRecorderService.StartRecording(inputDeviceFrinedlyName, outputDeviceFriendlyName, folder);
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

        }
    }
}
