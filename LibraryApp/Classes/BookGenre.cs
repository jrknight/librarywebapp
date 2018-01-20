﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Classes
{
    class BookGenre
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
