using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BookSearch.Models;

namespace BookSearch
{
    public partial class SearchForm : Form
    {
        private Stopwatch m_timer = new Stopwatch();

        public SearchForm()
        {
            InitializeComponent();
            InitialiseEf();
        }

        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            try
            {
                DoSearch();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem querying the database.");
            }
        }

        private void DoSearch()
        {
            m_timer.Reset();
            m_timer.Start();
            ClearResults();
            labelStatus.Text = "Searching...";
            Refresh();
            BookViewModel book = SearchForIsbn();
            m_timer.Stop();
            long time = m_timer.ElapsedMilliseconds;
            labelStatus.Text = String.Format("Last search took {0}ms", time);
            UpdateResults(book);
        }

        private BookViewModel SearchForIsbn()
        {
            string isbn = textBoxIsbn.Text;
            return SearchForIsbn(isbn);
        }

        private BookViewModel SearchForIsbn(string isbn)
        {
            var db = new DbAccess();
            BookViewModel book = db.SearchByIsbn(isbn);
            return book;
        }

        private void UpdateResults(BookViewModel book)
        {
            if (!String.IsNullOrWhiteSpace(book.Title))
            {
                labelTitleResult.Text = book.Title;
                labelAuthorResult.Text = book.Author;
                labelCopiesResult.Text = book.Copies.ToString();
                labelPublishDateResult.Text = book.PublishDate.ToString("D");
                labelSizeResult.Text = book.Large ? "Large" : "Regular";
            }
            else
            {
                ClearResults();
            }
        }

        private void ClearResults()
        {
            labelTitleResult.Text = String.Empty;
            labelAuthorResult.Text = String.Empty;
            labelCopiesResult.Text = String.Empty;
            labelPublishDateResult.Text = String.Empty;
            labelSizeResult.Text = String.Empty;
        }

        private void InitialiseEf()
        {
            using (var db = new MagicBooksContext())
            {
                var a = db.Books.Where(b => b.Large);
                db.SaveChanges();
            }
        }
    }
}
