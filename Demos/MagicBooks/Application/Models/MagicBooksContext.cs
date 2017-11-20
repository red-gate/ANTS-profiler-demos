using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BookSearch.Models.Mapping;

namespace BookSearch.Models
{
    public partial class MagicBooksContext : DbContext
    {
        static MagicBooksContext()
        {
            Database.SetInitializer<MagicBooksContext>(null);
        }

        public MagicBooksContext()
            : base("Name=MagicBooksContext")
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
        }
    }
}
