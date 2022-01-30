using AudioRecorderV4;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HDE.AudioRecorder.Views
{
    public sealed partial class RecordingView : INotifyPropertyChanged
    {
        #region Input Devices Property

        public bool IsAudioRecording
        {
            get => App.Controller.IsAudioRecording;
            set
            {
                OnPropertyChanged("IsAudioRecording");
                OnPropertyChanged("IsAudioInputDeviceEnabled");
                OnPropertyChanged("IsAudioOutputDeviceEnabled");
            }
        }

        #endregion

        #region IsAudioInputDeviceEnabled

        public bool IsAudioInputDeviceEnabled
        {
            get => !IsAudioRecording && InputDevices != null && InputDevices.Any();
            set
            {
                OnPropertyChanged("IsAudioInputDeviceEnabled");
            }
        }

        #endregion

        #region IsAudioInputDeviceEnabled

        public bool IsAudioOutputDeviceEnabled
        {
            get => !IsAudioRecording && OutputDevices != null && OutputDevices.Any();
            set
            {
                OnPropertyChanged("IsAudioOutputDeviceEnabled");
            }
        }

        #endregion

        #region Input Devices Property

        private List<string> inputDevices;
        public List<string> InputDevices
        {
            get => inputDevices;
            set
            {
                inputDevices = value;
                OnPropertyChanged("InputDevices");
                OnPropertyChanged("IsAudioInputDeviceEnabled");
            }
        }

        #endregion

        #region Is Audio Recording Enabled

        public bool IsAudioRecordingEnabled
        {
            get => audioInputDevice != null || audioOutputDevice != null;
            set
            {
                OnPropertyChanged("IsAudioRecordingEnabled");
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
                OnPropertyChanged("IsAudioRecordingEnabled");
                App.Controller.UpdateAudioInputDevice(value);
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
                OnPropertyChanged("IsAudioOutputDeviceEnabled");
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
                OnPropertyChanged("IsAudioRecordingEnabled");
                App.Controller.UpdateAudioOutputDevice(value);
            }
        }

        #endregion

        public RecordingView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshProperties();
            base.OnNavigatedTo(e);
        }

        private void RefreshProperties()
        {
            InputDevices = App.Controller.Model.InputDevices;
            AudioInputDevice = App.Controller.Model.Settings.AudioInputDevice;

            OutputDevices = App.Controller.Model.OutputDevices;
            AudioOutputDevice = App.Controller.Model.Settings.AudioOutputDevice;

        }

        private void OnSeeRecordingsClick(object sender, object e)
        {
            App.Controller.OpenOutputFolder();
        }

        private void OnShowDisableRecordingHint(object sender, object e)
        {
            ShowDisableRecordingTeachingTip.IsOpen = true;
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
            OnPropertyChanged("IsAudioRecording");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
