using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Classes
{
    class Student
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string StudentId { get; set; }
        private List<Book> CheckedOut { get; set; }
        private List<Book> PreviouslyCheckedOut { get; set; }

        public Student(string FirstName, string LastName, int StudentId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.StudentId = StudentId.ToString();

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
