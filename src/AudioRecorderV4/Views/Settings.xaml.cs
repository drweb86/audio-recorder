using AudioRecorderV4;
using Microsoft.UI.Xaml;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WinRT.Interop;

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

        private async void OnSaveRecordingToFolder(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            InitializeWithWindow.Initialize(folderPicker, System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // TODO: set token in folder. var token = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                SaveRecordingToFolder = folder.Path;
            }
        }
    }
}
