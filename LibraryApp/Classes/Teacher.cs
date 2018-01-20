using System.Collections.Generic;

namespace LibraryApp.Classes
{
    class Teacher
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string TeacherId { get; set; }
        private List<Book> CheckedOut { get; set; }
        private List<Book> PreviouslyCheckedOut { get; set; }

        public Teacher(string FirstName, string LastName, string TeacherId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.TeacherId = TeacherId;
        }

        public void CheckOutBook(Book book)
        {
            CheckedOut.Add(book);

        }

        public void CheckedInBook(Book book)
        {
            PreviouslyCheckedOut.Add(book);
            CheckedOut.Remove(book);
        }
    }
}
