using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Classes
{
    class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
