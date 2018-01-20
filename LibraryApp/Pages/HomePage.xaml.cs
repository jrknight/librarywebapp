using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(ContentHomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }

        private void _btnHome_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ContentHomePage));
            _txtPageLabel.Text = "Home";
        }

        private void _btnLibrary_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(LibraryPage));
            _txtPageLabel.Text = "Library";
        }

        private void _btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SettingsPage));
            _txtPageLabel.Text = "Settings";
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AddBookPage));
        }

        /**
        * Should check permissions and display what is necessary based on this.
        * Needs to display what the student has checked out now
        * Question what a teacher would want to see - possibly what they have checked out as well.
        */
    }
}
