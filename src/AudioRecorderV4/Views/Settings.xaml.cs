using AudioRecorderV4;
using HDE.AudioRecorder.Tools.AudioRecorder.Model;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HDE.AudioRecorder.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : INotifyPropertyChanged
    {
        private List<string> inputDevices;
        private string audioInputDevice;
        private string logsFolder;
        private List<string> outputDevices;
        private string audioOutputDevice;
        private string saveRecordingToFolder;

        public List<string> InputDevices 
        {
            get => inputDevices; 
            set 
            {
                inputDevices = value;
                OnPropertyChanged("InputDevices");
            } 
        }
        public string AudioInputDevice 
        { 
            get => audioInputDevice;
            set
            {
                audioInputDevice = value;
                OnPropertyChanged("AudioInputDevice");
                if (App.Controller.Model.Settings.AudioInputDevice != value)
                {
                    App.Controller.UpdateSettings(new AudioRecorderSettings
                    {
                        AudioInputDevice = value,
                    });
                }
            }
        }

        public List<string> OutputDevices 
        { 
            get => outputDevices;
            set
            {
                outputDevices = value;
                OnPropertyChanged("OutputDevices");
            }
        }
        public string AudioOutputDevice 
        { 
            get => audioOutputDevice;
            set
            {
                audioOutputDevice = value;
                OnPropertyChanged("AudioOutputDevice");
                if (App.Controller.Model.Settings.AudioOutputDevice != value)
                {
                    App.Controller.UpdateSettings(new AudioRecorderSettings
                    {
                        AudioOutputDevice = value,
                    });
                }
            }
        }

        public string SaveRecordingToFolder 
        { 
            get => saveRecordingToFolder;
            set
            {
                saveRecordingToFolder = value;
                OnPropertyChanged("SaveRecordingToFolder");
                if (App.Controller.Model.Settings.SaveRecordingToFolder != value)
                {
                    App.Controller.UpdateSettings(new AudioRecorderSettings
                    {
                        SaveRecordingToFolder = value,
                    });
                }
            }
        }

        public string LogsFolder
        {
            get => logsFolder;
            set
            {
                logsFolder = value;
                OnPropertyChanged("LogsFolder");
            }
        }

        public Settings()
        {
            this.InitializeComponent();

            App.Controller.Initialize();
            InputDevices = App.Controller.Model.InputDevices;
            AudioInputDevice = App.Controller.Model.Settings.AudioInputDevice;

            OutputDevices = App.Controller.Model.OutputDevices;
            AudioOutputDevice = App.Controller.Model.Settings.AudioOutputDevice;

            SaveRecordingToFolder = App.Controller.Model.Settings.SaveRecordingToFolder;
            LogsFolder = App.Controller.Model.LogsFolder;

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void OnOpenRecordingsFolder(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenOutputFolder();
        }

        private void OnOpenLogsFolder(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenLogsFolder();
        }

        private void OnSaveRecordingToFolder(object sender, RoutedEventArgs e)
        {
            using (var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = saveRecordingToFolder;
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    App.Controller.UpdateSettings(new AudioRecorderSettings
                    {
                        SaveRecordingToFolder = folderBrowserDialog.SelectedPath,
                    });
                    SaveRecordingToFolder = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
