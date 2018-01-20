using LibraryApp.Classes;
using System;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LibraryApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            ApplicationView.PreferredLaunchViewSize = new Size(1200, 700);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        private void _lnkToCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(Pages.CreateAccount));
        }

        private async void _btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.HomePage));
        }
    }
}
