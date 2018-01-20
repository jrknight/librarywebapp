using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryApp.Pages
{
    /// <summary>
    /// May need to be replaced with a system where teachers create accounts for students
    /// </summary>
    public sealed partial class CreateAccount : Page
    {
        public CreateAccount()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += CreateAccount_BackRequested;
        }

        private void CreateAccount_BackRequested(object sender, BackRequestedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
