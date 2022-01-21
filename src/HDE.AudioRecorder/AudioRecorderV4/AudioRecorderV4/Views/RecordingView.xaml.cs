namespace HDE.AudioRecorder.Views
{
    public sealed partial class RecordingView
    {
        public RecordingView()
        {
            this.InitializeComponent();
        }
        /*
        private void _startRecordingButton_Click(object sender, EventArgs e)
        {
            if (_controller.IsAudioRecording)
            {
                _controller.Stop();
                _startRecordingButton.Text = "Start";
                _linkFileLinkLabel.Visible = true;
            }
            else
            {
                var fileName = _controller.Start(_audioInputDeviceComboBox.Text, _audioOutputDeviceComboBox.Text, _outputFolderTextBox.Text);
                _startRecordingButton.Text = "Stop";
                _linkFileLinkLabel.Text = fileName;
                _linkFileLinkLabel.Visible = false;
            }
        }

        private void OnOpenFileLocation(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _controller.OpenOutputFolder();
        }*/
    }
}
