using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public List<Member> FindMembers(string firstName, string lastName, string postCode, string city)
        {
            var members = from m in db.Members
                          where
                              (m.FirstName == firstName || firstName == "") &&
                              (m.LastName == lastName | lastName == "") &&
                              (m.PostCode == postCode || postCode == "") &&
                              (m.City == city || city == "")
                          select m;
            return members.Take(250).ToList();
        }

        public Member FindMemberById(int id)
        {
            var members = from m in db.Members where m.Id == id select m;
            return members.First();
        }

        public List<Member> FindMembersByCity(string city)
        {
            var members = from m in db.Members where m.City == city select m;
            return members.ToList();
        }

        public List<Member> FindMembersByPostCode(string postCode)
        {
            var members = from m in db.Members where m.PostCode == postCode select m;
            return members.ToList();
        }

        public List<Member> FindMembersByFirstName(string firstName)
        {
            var members = from m in db.Members where m.FirstName == firstName select m;
            return members.ToList();
        }

        public List<Member> FindMembersByLastName(string lastName)
        {
            var members = from m in db.Members where m.LastName == lastName select m;
            return members.ToList();
        }

        public List<Magazine> FindMagazines(string title, string author)
        {
            var magazines = db.Magazines.Where(m => ((m.Title == title)) || ((m.Author == author)));
            return magazines.ToList();
        }

        public List<Book> FindBooks(string title, string author)
        {
            var books = from b in db.Books
                        where
                            (b.Title.Contains(title) || title == "") &&
                            (b.Author == author | author == "")
                        select b;
            return books.Take(100).ToList();
        }

        public Book FindBookById(int id)
        {
            var books = from b in db.Books where b.Id == id select b;
            return books.First();
        }

        public Magazine FindMagazineById(int id)
        {
            var magazines = from m in db.Magazines where m.Id == id select m;
            return magazines.First();
        }

        public List<Book> FindBookByTitle(string title)
        {
            var books = from b in db.Books where b.Title == title select b;
            return books.ToList();
        }

        public List<Book> FindBookByIsbn(string isbn)
        {
            var books = from b in db.Books where b.ISBN == isbn select b;
            return books.ToList();
        }

        #endregion

        #region Status

        public Status GetStatus()
        {
            var status = new Status();
            status.BooksInInventory = GetBooksInInventory();
            status.UniqueBooks = GetUniqueBooks();
            status.BooksInStock = GetBooksInStock();
            status.BooksOnLoan = GetBooksOnLoan();
            status.OverdueBooks = GetOverdueBooks();
            status.OutstandingFines = GetOutstandingFines();
            status.EnrolledMembers = GetEnrolledMembers();
            status.JoinedThisWeek = GetjoinedThisWeek();
            status.DueBackToday = GetDueBackToday();
            status.MostRecentLoan = GetMostRecentLoan();
            return status;
        }

        private int GetBooksInInventory()
        {
            return (from bi in db.BookInstances select bi).Count();
        }

        private int GetUniqueBooks()
        {
            return (from b in db.Books select b).Count();
        }

        private int GetBooksInStock()
        {
            return
                (from bi in db.BookInstances
                 join l in db.Loans on bi.Id equals l.BookInstanceId
                 where l.Returned == 1
                 select bi).Count();
        }

        private int GetBooksOnLoan()
        {
            return
                (from bi in db.BookInstances
                 join l in db.Loans on bi.Id equals l.BookInstanceId
                 where l.Returned == 0
                 select bi).Count();
        }

        private int GetOverdueBooks()
        {
            return
                (from bi in db.BookInstances
                 join l in db.Loans on bi.Id equals l.BookInstanceId
                 where l.Returned == 0 && l.DueDate < DateTime.Now
                 select bi).Count();
        }

        private Decimal GetOutstandingFines()
        {
            return
                (from l in db.Loans
                 where l.FinePaid == 0
                 select l.FineIncurred ?? 0).Sum();
        }

        private int GetEnrolledMembers()
        {
            return (from m in db.Members select m).Count();
        }

        private int GetjoinedThisWeek()
        {
            return
                (from m in db.Members
                 where m.JoinDate < DateTime.Now && m.JoinDate > DbFunctions.AddDays(DateTime.Now, -7)
                 select m)
                    .Count();
        }

        private int GetDueBackToday()
        {
            return
                (from l in db.Loans
                 where
                     l.Returned == 0 && l.DueDate > DateTime.Now && l.DueDate < DbFunctions.AddDays(DateTime.Now, 1)
                 select l)
                    .Count();
        }

        private DateTime GetMostRecentLoan()
        {
            return
                (from l in db.Loans where l.StartDate < DateTime.Now orderby l.StartDate descending select l).First()
                    .StartDate;
        }

        #endregion
    }
}
