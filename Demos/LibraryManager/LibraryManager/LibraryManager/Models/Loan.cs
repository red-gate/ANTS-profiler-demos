using System;
using System.Collections.Generic;

namespace LibraryManager.Models
{
    public partial class Loan
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public Nullable<decimal> FineIncurred { get; set; }
        public int BookInstanceId { get; set; }
        public byte Returned { get; set; }
        public byte FinePaid { get; set; }
        public virtual BookInstance BookInstance { get; set; }
        public virtual Member Member { get; set; }
    }
}
