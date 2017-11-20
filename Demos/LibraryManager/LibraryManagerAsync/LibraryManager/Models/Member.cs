using System;
using System.Collections.Generic;

namespace LibraryManager.Models
{
    public partial class Member
    {
        public Member()
        {
            this.Loans = new List<Loan>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public System.DateTime JoinDate { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
