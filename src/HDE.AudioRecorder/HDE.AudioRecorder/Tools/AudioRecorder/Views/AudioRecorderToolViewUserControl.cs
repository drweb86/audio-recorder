using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Views
{
    public partial class AudioRecorderToolViewUserControl : UserControl
    {
        private AudioRecorderToolController _controller;
        public AudioRecorderToolViewUserControl()
        {
            InitializeComponent();
        }

        internal void Init(AudioRecorderToolController controller)
        {
            _controller = controller;

            _audioInputDeviceComboBox.BeginUpdate();
            _audioInputDeviceComboBox.Items.Clear();
            _audioInputDeviceComboBox.Items.AddRange(_controller.Model.InputDevices.ToArray());
            _audioInputDeviceComboBox.SelectedItem = _controller.Model.DefaultInputDevice;
            _audioInputDeviceComboBox.EndUpdate();

            _audioOutputDeviceComboBox.BeginUpdate();
            _audioOutputDeviceComboBox.Items.Clear();
            _audioOutputDeviceComboBox.Items.AddRange(_controller.Model.OutputDevices.ToArray());
            _audioOutputDeviceComboBox.SelectedItem = _controller.Model.DefaultOutputDevice;
            _audioOutputDeviceComboBox.EndUpdate();

            _outputFolderTextBox.Text = _controller.Model.OutputFolder;
        }

        internal void TearDown()
        {
            // !
        }

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
