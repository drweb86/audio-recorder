using AudioRecorderV4;
using Microsoft.UI.Xaml;
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
        private string saveRecordingToFolder;

        public string SaveRecordingToFolder 
        { 
            get => saveRecordingToFolder;
            set
            {
                saveRecordingToFolder = value;
                OnPropertyChanged("SaveRecordingToFolder");
                App.Controller.UpdateSaveRecordingToFolder(value);
            }
        }

        public Settings()
        {
            this.InitializeComponent();

            SaveRecordingToFolder = App.Controller.Model.Settings.SaveRecordingToFolder;

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

        private void OnSaveRecordingToFolder(object sender, RoutedEventArgs e)
        {
            using (var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = saveRecordingToFolder;
                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    SaveRecordingToFolder = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
