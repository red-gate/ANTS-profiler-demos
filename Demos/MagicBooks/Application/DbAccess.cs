using System.Collections.Generic;
using System.Linq;
using BookSearch.Models;

namespace BookSearch
{
    class DbAccess
    {
        public BookViewModel SearchByIsbn(string isbn)
        {
            using (var db = new MagicBooksContext())
            {
                db.Database.CommandTimeout = 300;
                List<Book> books = db.Books
                    .Where(b => b.Isbn == isbn)
                    .Take(1)
                    .ToList();

                if (books.Any())
                {
                    return books.First().ToBookViewModel();
                }
            }
            return new BookViewModel();
        }
    }
}