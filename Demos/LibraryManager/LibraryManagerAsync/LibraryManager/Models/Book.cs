using System;
using System.Collections.Generic;

namespace LibraryManager.Models
{
    public partial class Book
    {
        public Book()
        {
            this.BookInstances = new List<BookInstance>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public virtual ICollection<BookInstance> BookInstances { get; set; }
    }
}
