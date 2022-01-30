using AudioRecorderV4;
using Microsoft.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HDE.AudioRecorder.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ApplicationView : INotifyPropertyChanged
    {
        public ApplicationView()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void OnOpenLogsFolder(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenLogsFolder();
        }

        private void OnOpenSupportLink(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenSupportLink();
        }

        private void OnOpenLicenseLink(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenLicenseLink();
        }

        private void OnOpenPrivatePolicyLink(object sender, RoutedEventArgs e)
        {
            App.Controller.OpenPrivatePolicyLink();
        }
    }
}
