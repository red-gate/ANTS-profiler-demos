using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Configuration;

namespace LibraryManager
{
    public partial class AdminConsole : Form
    {
        public AdminConsole()
        {
            InitializeComponent();
        }
        private enum ObjectType
        {
            Member,
            Book
        }

        #region Event Handlers

        private void button_RefreshStatus_Click(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void AdminConsole_Shown(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void button_SearchMembers_Click(object sender, EventArgs e)
        {
            SearchForMembers();
        }

        private void button_SearchBooks_Click(object sender, EventArgs e)
        {
            SearchForBooks();
        }

        private void UpdateDetails(object sender, EventArgs e, int id, ObjectType objectType)
        {
            if (objectType == ObjectType.Member)
            {
                UpdateMemberDetails(id);
            }
            if (objectType == ObjectType.Book)
            {
                UpdateBookDetails(id);
            }
        }

        #endregion

        #region Update Status

        private void UpdateStatus()
        {
            UpdateStatusWithNothing();
            UpdateStatusWithData();
        }

        private void UpdateStatusWithData()
        {
            using (var db = new LibraryManagerDatabase())
            {
                Status status = db.GetStatus();
                label_BooksInInventory.Text = status.BooksInInventory.ToString();
                label_UniqueBooks.Text = status.UniqueBooks.ToString();
                label_BooksInStock.Text = status.BooksInStock.ToString();
                label_BooksOnLoan.Text = status.BooksOnLoan.ToString();
                label_OverdueBooks.Text = status.OverdueBooks.ToString();
                label_OutstandingFees.Text = "£" + Math.Round(status.OutstandingFines, 2).ToString();
                label_EnrolledMembers.Text = status.EnrolledMembers.ToString();
                label_JoinedThisWeek.Text = status.JoinedThisWeek.ToString();
                label_DueBackToday.Text = status.DueBackToday.ToString();
                label_MostRecentLoan.Text = status.MostRecentLoan.ToString("t");
            }
        }

        private void UpdateStatusWithNothing()
        {
            label_BooksInInventory.Text = "...";
            label_UniqueBooks.Text = "...";
            label_BooksInStock.Text = "...";
            label_BooksOnLoan.Text = "...";
            label_OverdueBooks.Text = "...";
            label_OutstandingFees.Text = "...";
            label_EnrolledMembers.Text = "...";
            label_JoinedThisWeek.Text = "...";
            label_DueBackToday.Text = "...";
            label_MostRecentLoan.Text = "...";
            Refresh();
        }

        #endregion

        #region Search

        private void SearchForMembers()
        {
            var firstName = textBox_SearchFirstName.Text;
            var lastName = textBox_SearchLastName.Text;
            var postCode = textBox_SearchPostCode.Text;
            var city = textBox_SearchCity.Text;
            var filterByLoan = checkBox_SearchWithLoans.Checked;

            tableLayoutPanel_SearchResults.RowStyles.Clear();
            tableLayoutPanel_SearchResults.Controls.Clear();
            tableLayoutPanel_SearchResults.RowCount = 1;
            label_Searching.Visible = true;
            Refresh();

            IEnumerable<Member> members = GetMembersFromDatabase(firstName, lastName, postCode, city, filterByLoan);

            UpdateMemberSearchResults(members);
            ResetScrollBars();
            label_Searching.Visible = false;
        }

        private IEnumerable<Member> GetMembersFromDatabase(string firstName, string lastName, string postCode, string city, bool filterByLoan)
        {
            using (var db = new LibraryManagerDatabase())
            {
                List<Member> members = db.FindMembers(firstName, lastName, postCode, city, filterByLoan);
                return members;
            }
        }

        private IEnumerable<Member> FilterMembersByLoanStatus(IEnumerable<Member> members)
        {
            return members.Where(m => m.Loans.Any(l => l.Returned == 0)).ToList();
        }

        private void UpdateMemberSearchResults(IEnumerable<Member> members)
        {
            tableLayoutPanel_SearchResults.SuspendLayout();
            foreach (var member in members)
            {
                tableLayoutPanel_SearchResults.RowCount++;
                int latestRow = tableLayoutPanel_SearchResults.RowCount - 1;
                
                Label nameLabel = GetClickableMemberLabel(member);
                var postCodeLabel = new Label { Text = member.PostCode };
                var joinDateLabel = new Label { Text = member.JoinDate.ToString("d") };

                tableLayoutPanel_SearchResults.Controls.Add(nameLabel, 0, latestRow);
                tableLayoutPanel_SearchResults.Controls.Add(postCodeLabel, 1, latestRow);
                tableLayoutPanel_SearchResults.Controls.Add(joinDateLabel, 2, latestRow);
            }
            tableLayoutPanel_SearchResults.ResumeLayout();
        }

        private Label GetClickableMemberLabel(Member member)
        {
            var label = new Label {Text = member.FirstName + " " + member.LastName, ForeColor = Color.Blue};
            label.Click += (s, e) =>UpdateDetails(s, e, member.Id, ObjectType.Member);
            return label;
        }

        private void SearchForBooks()
        {
            var title = textBox_SearchTitle.Text;
            var author = textBox_SearchAuthor.Text;
            var archiveSearch = checkBox_SearchArchive.Checked;
            var searchInArchive = checkBox_SearchArchive.Checked;

            tableLayoutPanel_SearchResults.RowStyles.Clear();
            tableLayoutPanel_SearchResults.Controls.Clear();
            tableLayoutPanel_SearchResults.RowCount = 1;
            label_Searching.Visible = true;
            Refresh();

            if (archiveSearch)
            {
                PopulateListIncludingArchiveSearch(title, author);
            }
            else
            {
                PopulateListWithoutArchiveSearch(title, author);
            }

            ResetScrollBars();
            label_Searching.Visible = false;
        }

        private void PopulateListIncludingArchiveSearch(string title, string author)
        {
            IEnumerable<Book> books = GetArchivedBooksFromDatabase(title, author);
            UpdateBookSearchResults(books);
        }

        private IEnumerable<Book> GetArchivedBooksFromDatabase(string title, string author)
        {
            const string queryString = "[dbo].[AdvancedSearch]";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagerDb"].ConnectionString))
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand(queryString, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Author", author);
                    sqlCommand.Parameters.AddWithValue("@Title", title);
                    return InstantiateBooksFromQueryResults(sqlCommand);
                }
            }
        }

        private static IEnumerable<Book> InstantiateBooksFromQueryResults(SqlCommand cmd)
        {
            using (var reader = cmd.ExecuteReader())
            {
                var matchingBooks = new List<Book>();

                while (reader.Read() && matchingBooks.Count() <= 100)
                {
                    var record = (IDataRecord) reader;
                    var book = new Book
                    {
                        Id = (int) record[0],
                        Title = (string) record[1],
                        Author = (string) record[2],
                        ISBN = (string) record[3]
                    };
                    matchingBooks.Add(book);
                }
                return matchingBooks;
            }
        }

        private void PopulateListWithoutArchiveSearch(string title, string author)
        {
            IEnumerable<Book> books = GetUnarchivedBooksFromDatabase(title, author);
            UpdateBookSearchResults(books);
        }

        private IEnumerable<Book> GetUnarchivedBooksFromDatabase(string title, string author)
        {
            using (var db = new LibraryManagerDatabase())
            {
                List<Book> books = db.FindBooks(title, author);
                return books;
            }
        }

        private void UpdateBookSearchResults(IEnumerable<Book> books)
        {
            tableLayoutPanel_SearchResults.SuspendLayout();
            foreach (var book in books)
            {
                tableLayoutPanel_SearchResults.RowCount++;
                int latestRow = tableLayoutPanel_SearchResults.RowCount - 1;

                Label titleLabel = GetClickableBookLabel(book);
                var authorLabel = new Label { Text = book.Author };
                var isbnLabel = new Label { Text = book.ISBN };

                tableLayoutPanel_SearchResults.Controls.Add(titleLabel, 0, latestRow);
                tableLayoutPanel_SearchResults.Controls.Add(authorLabel, 1, latestRow);
                tableLayoutPanel_SearchResults.Controls.Add(isbnLabel, 2, latestRow);
            }
            tableLayoutPanel_SearchResults.ResumeLayout();
        }

        private Label GetClickableBookLabel(Book book)
        {
            var label = new Label {Width = 150, Text = book.Title, ForeColor = Color.Blue};
            label.Click += (s, e) => UpdateDetails(s, e, book.Id, ObjectType.Book);
            return label;
        }

        private void ResetScrollBars()
        {
            //This really shouldn't work or be necessary...
            tableLayoutPanel_SearchResults.AutoScroll = false;
            tableLayoutPanel_SearchResults.AutoScroll = true;
        }

        #endregion

        #region Update Details

        private void UpdateMemberDetails(int memberId)
        {
            label_Loading.Visible = true;
            panel_BookDetails.Visible = false;
            panel_MemberDetails.Visible = false;
            Refresh();
            using (var db = new LibraryManagerDatabase())
            {
                Member member = db.FindMemberById(memberId);
                label_MemberDetailsName.Text = member.FirstName + " " + member.LastName;
                label_MemberDetailsPhone.Text = member.Phone1;
                label_MemberDetailsAddress.Text = PrintAddress(member);
                label_MemberDetailsEmail.Text = member.Email1;
                pictureBox_MemberDetailsImage.Image = LookupUserImage(memberId);
            }
            panel_MemberDetails.Visible = true;
            label_Loading.Visible = false;
        }

        private string PrintAddress(Member member)
        {
            string address = "";
            if (!String.IsNullOrEmpty(member.Address1))
            {
                address += member.Address1 + "\n";
            }
            if (!String.IsNullOrEmpty(member.Address2))
            {
                address += member.Address2 + "\n";
            }
            if (!String.IsNullOrEmpty(member.City))
            {
                address += member.City + "\n";
            }
            if (!String.IsNullOrEmpty(member.PostCode))
            {
                address += member.PostCode + "\n";
            }
            if (!String.IsNullOrEmpty(member.Country))
            {
                address += member.Country + "\n";
            }
            return address;
        }

        private Bitmap LookupUserImage(int memberId)
        {
            using (var wc = new WebClient())
            {
                var imgData = wc.DownloadData(ConfigurationSettings.AppSettings["ApiBaseUrl"] + "/Members/Images/" + memberId);
                var ms = new System.IO.MemoryStream(imgData);
                var bitmap = new Bitmap(ms);
                return bitmap;
            }
        }

        private void UpdateBookDetails(int bookId)
        {
            label_Loading.Visible = true;
            panel_BookDetails.Visible = false;
            panel_MemberDetails.Visible = false;
            Refresh();
            using (var db = new LibraryManagerDatabase())
            {
                Book book = db.FindBookById(bookId);
                label_BookDetailsTitle.Text = book.Title;
                label_BookDetailsAuthor.Text = book.Author;
                label_BookDetailsIsbn.Text = book.ISBN;
                label_BookDetailsCopies.Text = book.BookInstances.Count.ToString();
            }
            panel_BookDetails.Visible = true;
            label_Loading.Visible = false;
        }

        #endregion
    }

    public class LibraryManagerDatabase : IDisposable
    {
        private LibraryManagerEntities db = new LibraryManagerEntities();

        public void Dispose() //Not a proper IDisposable implementation but it'll do for now :-)
        {
            db.Dispose();
        }

        #region Search

        public List<Member> FindMembers(string firstName, string lastName, string postCode, string city, bool onlyMembersWithOutstandingLoans)
        {

            var members = from m in db.Members
                where
                    (m.FirstName == firstName || firstName == "") &&
                    (m.LastName == lastName | lastName == "") &&
                    (m.PostCode == postCode || postCode == "") &&
                    (m.City == city || city == "") &&
                    (m.Loans.Count > 0 || !onlyMembersWithOutstandingLoans)
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

    public class Status
    {
        public int BooksInInventory;
        public int UniqueBooks;
        public int BooksInStock;
        public int BooksOnLoan;
        public int OverdueBooks;
        public Decimal OutstandingFines;
        public int EnrolledMembers;
        public int JoinedThisWeek;
        public int DueBackToday;
        public DateTime MostRecentLoan;
    }
}