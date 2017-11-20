using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Models;

namespace LibraryManager
{
    public class LibraryManagerDatabase : IDisposable
    {
        private LibraryManagerContext db = new LibraryManagerContext();

        public void Dispose() //Not a proper IDisposable implementation but it'll do for now :-)
        {
            db.Dispose();
        }

        #region Search

        public Task<List<Member>> FindMembers(string firstName, string lastName, string postCode, string city)
        {
            var members = (from m in db.Members
                          where
                              (m.FirstName == firstName || firstName == "") &&
                              (m.LastName == lastName | lastName == "") &&
                              (m.PostCode == postCode || postCode == "") &&
                              (m.City == city || city == "")
                          select m)
                          .Take(250)
                          .ToListAsync();
            return members;
        }

        public Task<Member> FindMemberById(int id)
        {
            var member = (from m in db.Members where m.Id == id select m).FirstAsync();
            return member;
        }

        public Task<List<Member>> FindMembersByCity(string city)
        {
            var members = (from m in db.Members where m.City == city select m).ToListAsync();
            return members;
        }

        public Task<List<Member>> FindMembersByPostCode(string postCode)
        {
            var members = (from m in db.Members where m.PostCode == postCode select m).ToListAsync();
            return members;
        }

        public Task<List<Member>> FindMembersByFirstName(string firstName)
        {
            var members = (from m in db.Members where m.FirstName == firstName select m).ToListAsync();
            return members;
        }

        public Task<List<Member>> FindMembersByLastName(string lastName)
        {
            var members = (from m in db.Members where m.LastName == lastName select m).ToListAsync();
            return members;
        }

        public Task<List<Magazine>> FindMagazines(string title, string author)
        {
            var magazines = (db.Magazines.Where(m => ((m.Title == title)) || ((m.Author == author)))).ToListAsync();
            return magazines;
        }

        public Task<List<Book>> FindBooks(string title, string author)
        {
            var books = (from b in db.Books
                        where
                            (b.Title.Contains(title) || title == "") &&
                            (b.Author == author | author == "")
                        select b).Take(100).ToListAsync();
            return books;
        }

        public Task<Book> FindBookById(int id)
        {
            var book = (from b in db.Books where b.Id == id select b).FirstAsync();
            return book;
        }

        public Task<Magazine> FindMagazineById(int id)
        {
            var magazine = (from m in db.Magazines where m.Id == id select m).FirstAsync();
            return magazine;
        }

        public Task<List<Book>> FindBookByTitle(string title)
        {
            var books = (from b in db.Books where b.Title == title select b).ToListAsync();
            return books;
        }

        public Task<List<Book>> FindBookByIsbn(string isbn)
        {
            var books = (from b in db.Books where b.ISBN == isbn select b).ToListAsync();
            return books;
        }

        #endregion

        #region Status

        public async Task<Status> GetStatus()
        {
            var status = new Status();
            status.BooksInInventory = await GetBooksInInventory();
            status.UniqueBooks = await GetUniqueBooks();
            status.BooksInStock = await GetBooksInStock();
            status.BooksOnLoan = await GetBooksOnLoan();
            status.OverdueBooks = await GetOverdueBooks();
            status.OutstandingFines = await GetOutstandingFines();
            status.EnrolledMembers = await GetEnrolledMembers();
            status.JoinedThisWeek = await GetjoinedThisWeek();
            status.DueBackToday = await GetDueBackToday();
            status.MostRecentLoan = await GetMostRecentLoan();
            return status;
        }

        private Task<int> GetBooksInInventory()
        {
            return (from bi in db.BookInstances select bi).CountAsync();
        }

        private Task<int> GetUniqueBooks()
        {
            return (from b in db.Books select b).CountAsync();
        }

        private Task<int> GetBooksInStock()
        {
            return
                (from bi in db.BookInstances
                 join l in db.Loans on bi.Id equals l.BookInstanceId
                 where l.Returned == 1
                 select bi).CountAsync();
        }

        private Task<int> GetBooksOnLoan()
        {
            return
                (from bi in db.BookInstances
                 join l in db.Loans on bi.Id equals l.BookInstanceId
                 where l.Returned == 0
                 select bi).CountAsync();
        }

        private Task<int> GetOverdueBooks()
        {
            return
                (from bi in db.BookInstances
                 join l in db.Loans on bi.Id equals l.BookInstanceId
                 where l.Returned == 0 && l.DueDate < DateTime.Now
                 select bi).CountAsync();
        }

        private Task<Decimal> GetOutstandingFines()
        {
            return
                (from l in db.Loans
                 where l.FinePaid == 0
                 select l.FineIncurred ?? 0).SumAsync();
        }

        private Task<int> GetEnrolledMembers()
        {
            return (from m in db.Members select m).CountAsync();
        }

        private Task<int> GetjoinedThisWeek()
        {
            return
                (from m in db.Members
                 where m.JoinDate < DateTime.Now && m.JoinDate > DbFunctions.AddDays(DateTime.Now, -7)
                 select m)
                    .CountAsync();
        }

        private Task<int> GetDueBackToday()
        {
            return
                (from l in db.Loans
                 where
                     l.Returned == 0 && l.DueDate > DateTime.Now && l.DueDate < DbFunctions.AddDays(DateTime.Now, 1)
                 select l)
                    .CountAsync();
        }

        private Task<DateTime> GetMostRecentLoan()
        {
            return
                (from l in db.Loans where l.StartDate < DateTime.Now orderby l.StartDate descending select l.StartDate).FirstAsync();
        }

        #endregion
    }
}
