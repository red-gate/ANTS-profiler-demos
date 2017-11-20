using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace BookSearch.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public bool Large { get; set; }
        public DateTime PublishDate { get; set; }

        public BookViewModel ToBookViewModel()
        {
            return new BookViewModel
            {
                Title = Title,
                Author = Author,
                Copies = Copies,
                Large = Large,
                PublishDate = PublishDate
            };
        }
    }
}
