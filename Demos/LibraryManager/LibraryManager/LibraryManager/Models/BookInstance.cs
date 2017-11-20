using System;
using System.Collections.Generic;

namespace LibraryManager.Models
{
    public partial class BookInstance
    {
        public BookInstance()
        {
            this.Loans = new List<Loan>();
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public string Location { get; set; }
        public decimal PricePaid { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
