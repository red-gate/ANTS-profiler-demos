using System;

namespace BookSearch
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public bool Large { get; set; }
        public DateTime PublishDate { get; set; }
    }
}