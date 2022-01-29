using AudioRecorderV4;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources;

namespace HDE.AudioRecorder.Views
{
    public sealed partial class RecordingView : INotifyPropertyChanged
    {
        private ResourceLoader _resourceLoader;

        #region Input Devices Property

        private List<string> inputDevices;
        public List<string> InputDevices
        {
            get => inputDevices;
            set
            {
                inputDevices = value;
                OnPropertyChanged("InputDevices");
                AudioInputDeviceToggleSplitButton.IsEnabled = value != null && value.Count > 0;
            }
        }

        #endregion

        #region Audio Input Device

        private string audioInputDevice;

        public string AudioInputDevice
        {
            get => audioInputDevice;
            set
            {
                audioInputDevice = value;
                OnPropertyChanged("AudioInputDevice");
                App.Controller.UpdateAudioInputDevice(value);
                AudioInputDeviceToggleSplitButton.IsChecked = value != null;
            }
        }

        #endregion

        #region Output Devices

        private List<string> outputDevices;
        public List<string> OutputDevices
        {
            get => outputDevices;
            set
            {
                outputDevices = value;
                OnPropertyChanged("OutputDevices");
                AudioOutputDeviceToggleSplitButton.IsEnabled = value != null && value.Count > 0;
            }
        }

        #endregion

        #region Audio Output Device

        private string audioOutputDevice;
        public string AudioOutputDevice
        {
            get => audioOutputDevice;
            set
            {
                audioOutputDevice = value;
                OnPropertyChanged("AudioOutputDevice");
                App.Controller.UpdateAudioOutputDevice(value);
                AudioOutputDeviceToggleSplitButton.IsChecked = value != null;
            }
        }

        #endregion

        public string buttonTitle;
        public string ButtonTitle
        {
            get => buttonTitle;
            set
            {
                buttonTitle = value;
                OnPropertyChanged("ButtonTitle");
            }
        }

        public string buttonGlyph;
        public string ButtonGlyph
        {
            get => buttonGlyph;
            set
            {
                buttonGlyph = value;
                OnPropertyChanged("ButtonGlyph");
            }
        }

        public RecordingView()
        {
            this.InitializeComponent();
            this.DataContext = this;

            App.Controller.Initialize(); // Refreshing the sound devices list.
            InputDevices = App.Controller.Model.InputDevices;
            AudioInputDevice = App.Controller.Model.Settings.AudioInputDevice;

            OutputDevices = App.Controller.Model.OutputDevices;
            AudioOutputDevice = App.Controller.Model.Settings.AudioOutputDevice;
        }

        private void OnOpenRecordingsFolder(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenOutputFolder();
        }

        private void OnAudioInputDeviceToggleSplitButtonClick(object sender, SplitButtonClickEventArgs e)
        {
            AudioInputDevice = App.Controller.ToggleAudioInputDevice();
        }

        private void OnAudioOutputDeviceToggleSplitButtonClick(object sender, SplitButtonClickEventArgs e)
        {
            AudioOutputDevice = App.Controller.ToggleAudioOutputDevice();
        }

        private void OnRecordClick(object sender, RoutedEventArgs e)
        {
            if (App.Controller.IsAudioRecording)
            {
                App.Controller.Stop();
            }
            else
            {
                App.Controller.Start();
            }
            RefreshTitle();
        }

        private void RefreshTitle()
        {
            ButtonTitle = App.Controller.IsAudioRecording ? 
                _resourceLoader.GetString("Stop") :
                _resourceLoader.GetString("StartRecording");

            ButtonGlyph = App.Controller.IsAudioRecording ?
                "\uE71A" :
                "\uE7C8";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            RefreshTitle();
        }
    }
}
