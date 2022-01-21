using System.Collections.Generic;

namespace HDE.AudioRecorder.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsView
    {
        public List<string> InputDevices { get; set; }
        public string AudioInputDevice { get; set; }

        public List<string> OutputDevices { get; set; }
        public string AudioOutputDevice { get; set; }

        public string SaveRecordingToFolder { get; set; }

        public SettingsView()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            InputDevices = App.Controller.Model.InputDevices;
            AudioInputDevice = App.Controller.Model.Settings.AudioInputDevice;

            OutputDevices = App.Controller.Model.OutputDevices;
            AudioOutputDevice = App.Controller.Model.Settings.AudioOutputDevice;

            SaveRecordingToFolder = App.Controller.Model.Settings.SaveRecordingToFolder;
        }


        //private void OnAudioInputDeviceChanged(object sender, EventArgs e)
        //{
        //    App.Controller.UpdateSettings(new AudioRecorderSettings
        //    {
        //        AudioInputDevice = _audioInputDeviceComboBox.Text,
        //    });
        //}

        //private void OnAudioOutputDeviceChanged(object sender, EventArgs e)
        //{
        //    App.Controller.UpdateSettings(new AudioRecorderSettings
        //    {
        //        AudioOutputDevice = _audioOutputDeviceComboBox.Text,
        //    });
        //}

        //private void OnUpdateRecordingToFolder(object sender, EventArgs e)
        //{
        //    using (var folderBrowserDialog = new FolderBrowserDialog())
        //    {
        //        folderBrowserDialog.SelectedPath = _outputFolderTextBox.Text;
        //        if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
        //        {
        //            App.Controller.UpdateSettings(new AudioRecorderSettings
        //            {
        //                SaveRecordingToFolder = folderBrowserDialog.SelectedPath,
        //            });
        //            _outputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
        //        }
        //    }
        //}
    }
}
