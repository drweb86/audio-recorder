using HDE.AudioRecorder.SingleToolShell;
using HDE.Platform.AspectOrientedFramework.WinForms;
using System.Diagnostics;

namespace HDE.AudioRecorder
{
    public partial class ShellMainForm : Form, IMainFormView
    {
        private ShellController _shellController;
        public TabControl TabControl
        {
            get { return _shellTabControl; }
        }

        public MenuStrip MainMenu
        {
            get { return _shellMenuStrip; }
        }

        public void SetController(object controller)
        {
            _shellController = (ShellController)controller;
        }

        public ShellMainForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _audioInputDeviceComboBox.BeginUpdate();
            _audioInputDeviceComboBox.Items.Clear();
            _audioInputDeviceComboBox.Items.AddRange(Program.Controller.Model.InputDevices.ToArray());
            _audioInputDeviceComboBox.SelectedItem = Program.Controller.Model.DefaultInputDevice;
            _audioInputDeviceComboBox.EndUpdate();

            _audioOutputDeviceComboBox.BeginUpdate();
            _audioOutputDeviceComboBox.Items.Clear();
            _audioOutputDeviceComboBox.Items.AddRange(Program.Controller.Model.OutputDevices.ToArray());
            _audioOutputDeviceComboBox.SelectedItem = Program.Controller.Model.DefaultOutputDevice;
            _audioOutputDeviceComboBox.EndUpdate();

            _outputFolderTextBox.Text = Program.Controller.Model.OutputFolder;
        }

        private void _startRecordingButton_Click(object sender, EventArgs e)
        {
            if (Program.Controller.IsAudioRecording)
            {
                Program.Controller.Stop();
                _startRecordingButton.Text = "Start";
                _linkFileLinkLabel.Visible = true;
            }
            else
            {
                var fileName = Program.Controller.Start(_audioInputDeviceComboBox.Text, _audioOutputDeviceComboBox.Text, _outputFolderTextBox.Text);
                _startRecordingButton.Text = "Stop";
                _linkFileLinkLabel.Text = fileName;
                _linkFileLinkLabel.Visible = false;
            }
        }

        private void _linkFileLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = _outputFolderTextBox.Text,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}