using LibraryApp.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 


    public sealed partial class ContentHomePage : Page
    {

        private List<Book> Books = new List<Book>();
        private List<Author> Authors = new List<Author>();

        public object Console { get; private set; }

        public ContentHomePage()
        {
            this.InitializeComponent();
            Init();
        }
        
        public async void Init()
        {
            try
            {
                LoadingIndicator.IsActive = true;
                await PopulateListOfBooks();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                LoadingIndicator.IsActive = false;
                LoadingIndicator.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private async Task PopulateListOfBooks()
        {
            /// will fetch and return a list of books based on something similar to http://bit.ly/2iTrk2h
            /// should also bind list to the list in the page
            /// query for books that are currently checked out by the user 

            try
            {
                await UpdateBooks();
                foreach(var book in Books)
                {
                    PopulateBookDetails(book);
                }
            }
            catch (JsonReaderException ex)
            {
                Debug.WriteLine(ex);
                //TODO Notify user of failure
            }
            
        }

        private async Task UpdateBooks()
        {
            Books = await DataTransfer.GetBooks();
            AvailableBooksList.ItemsSource = Books;
        }

        private void AvailableBooksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var item = e.ClickedItem;

                Book book = (Book)item;

                PopulateBookDetails(book);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        private void PopulateBookDetails(Book book) //Populate the details page on the home page
        {
            txtTitle.Text = book.Title;
            //Author author = Authors.Where(a => a.Id == book.AuthorId).FirstOrDefault();
            txtAuthor.Text = "by " + book.Author.Name;
            txtDescription.Text = book.Summary;
            string s = "";
            foreach (var g in book.BookGenres)
            {
                s += (g.Genre.Name + ", ");
            }
            txtGenre.Text = s;
        }
    }
}
