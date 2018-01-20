using LibraryApp.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LibraryApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddBookPage : Page
    {
        List<Author> Authors = new List<Author>();
        Author BookAuthor;
        List<Genre> ListOfGenres = new List<Genre>();
        List<Genre> BookGenres = new List<Genre>();

        public AddBookPage()
        {
            this.InitializeComponent();
            Init();
        }

        private async void Init()
        {
            try
            {
                AuthorList.Visibility = Visibility.Collapsed;
                var authors = await DataTransfer.GetAuthors();
                Authors = JsonConvert.DeserializeObject<List<Author>>(authors);
                ListOfGenres = await DataTransfer.GetGenres();
                //Debug.WriteLine(authors.ToString());
            }
            catch (JsonReaderException ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                AuthorList.Visibility = Visibility.Visible;
                AuthorList.ItemsSource = Authors;
                GenreList.ItemsSource = ListOfGenres;
                LoadingIndicator.IsActive = false;
                LoadingIndicator.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void AuthorList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem;
            BookAuthor = (Author)item;
        }

        private void GenreList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Genre g = (Genre)sender;
            BookGenres.Add(g);
            Debug.WriteLine(BookGenres.ToString());
        }

        private void AuthorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookAuthor = (Author)e.AddedItems.Last();
         }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool Ok = false;

            string Title = string.Empty;
            string Summary = string.Empty;
            string Genre = string.Empty;
            int authorId = -1;
            string Isbn = string.Empty;

            if (TitleTextBox.Text.Equals(""))
            {
                TitleTextBox.PlaceholderText = "You must provide a title value.";
                TitleTextBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                Ok = false;
            }
            else
            {
                Ok = true;
                Title = TitleTextBox.Text;

                if (BookAuthor == null)
                {
                    AuthorList.BorderBrush = new SolidColorBrush(Colors.Red);
                    Ok = false;
                }
                else
                {
                    Ok = true;
                    authorId = BookAuthor.Id;

                    if (SummaryTextBox.Text.Equals(""))
                    {
                        SummaryTextBox.PlaceholderText = "You must provide a summary value.";
                        SummaryTextBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                        Ok = false;
                    }
                    else
                    {
                        Ok = true;
                        Summary = SummaryTextBox.Text;

                        if (IsbnTextBox.Text.Equals(""))
                        {
                            IsbnTextBox.PlaceholderText = "You must provide a ISBN number.";
                            IsbnTextBox.PlaceholderForeground = new SolidColorBrush(Colors.Red);
                            Ok = false;
                        }
                        else
                        {
                            /// needs genre functionality
                            Ok = true;
                        }
                    }
                }
            }
            
            if (Ok)
            {
                Book book = new Book(Title, authorId, Genre, Summary, Isbn);
                Debug.WriteLine(JsonConvert.SerializeObject(book));
                Debug.WriteLine(JsonConvert.SerializeObject(BookAuthor));

                HttpResponseMessage responseMessage = await DataTransfer.PostBook(book);
                Debug.WriteLine("Post Statuscode: " + responseMessage.StatusCode);
                
            }
        }

        private void NewGenreButton_Click(object sender, RoutedEventArgs e)
        {
            // query adding new genre
        }

        private void OpenNewGenre_Click(object sender, RoutedEventArgs e)
        {
            if (NewGenreMenu.Visibility == Visibility.Collapsed)
            {
                NewGenreMenu.Visibility = Visibility.Visible;
            }
            else
            {
                NewGenreMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenNewAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (NewAuthorMenu.Visibility == Visibility.Collapsed)
            {
                NewAuthorMenu.Visibility = Visibility.Visible;
            }
            else
            {
                NewAuthorMenu.Visibility = Visibility.Collapsed;
            }
        }
    }
}
