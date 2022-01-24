using AudioRecorderV4;
using Microsoft.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources;
using Windows.Globalization;

namespace HDE.AudioRecorder.Views
{
    public sealed partial class RecordingView : INotifyPropertyChanged
    {
        private ResourceLoader _resourceLoader;

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

        public RecordingView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void OnOpenRecordingsFolder(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenOutputFolder();
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
