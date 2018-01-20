using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LibraryApp.Classes
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
         
        public Book(string Title, int AuthorId, string Genre, string Summary, string ISBN)
        {
            this.Title = Title;
            this.AuthorId = AuthorId;
            this.Summary = Summary;
            this.ISBN = ISBN;
        }

        public async Task GetAuthor(int Id)
        {
            string author = await DataTransfer.GetAuthor(AuthorId);
            Author a = JsonConvert.DeserializeObject<Author>(author);
            AuthorName = a.Name;
        }
    }
}
