using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.Reflection;

namespace AudioRecorderV4
{
    public sealed partial class MainWindow : Window
    {
        private readonly ResourceLoader _resourceLoader;
        public MainWindow()
        {
            this.InitializeComponent();
            _resourceLoader = new ResourceLoader();
            Title = _resourceLoader.GetString("ConferenceAudioRecorder");
            NavigateToView("RecordingView");
        }

        private NavigationViewItem _lastItem;
        private void NavigationView_OnItemInvoked(
            object sender,
            NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null || item == _lastItem)
                return;
            var clickedView = item.Tag?.ToString() ?? "SettingsView";
            if (!NavigateToView(clickedView)) return;
            _lastItem = item;
        }

        private bool NavigateToView(string clickedView)
        {
            var view = Assembly.GetExecutingAssembly()
                .GetType($"HDE.AudioRecorder.Views.{clickedView}");

            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }

            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        private void ContentFrame_OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NavigationException(
                $"Navigation failed {e.Exception.Message} for {e.SourcePageType.FullName}");
        }

        private void NavView_OnBackRequested(
            object sender,
            NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }
    }

    internal class NavigationException : Exception
    {
        public NavigationException(string msg) : base(msg)
        {

        }
    }
}
