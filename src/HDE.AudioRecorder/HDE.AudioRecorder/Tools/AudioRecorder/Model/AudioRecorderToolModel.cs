namespace HDE.AudioRecorder.Tools.AudioRecorder.Model
{
    class AudioRecorderToolModel
    {
        public List<string> InputDevices { get; internal set; }
        public List<string> OutputDevices { get; internal set; }
        public AudioRecorderSettings Settings { get; set; }
    }
}
