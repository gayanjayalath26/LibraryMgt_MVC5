using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.Libarary
{
    public class Book
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string BookISBN { get; set; }

        public List<Book_Copy> Book_Copy { get; set; }

        
    }
}