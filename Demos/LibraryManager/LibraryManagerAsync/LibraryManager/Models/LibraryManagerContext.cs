using System.Data.Entity;
using LibraryManager.Models.Mapping;

namespace LibraryManager.Models
{
    public partial class LibraryManagerContext : DbContext
    {
        static LibraryManagerContext()
        {
            Database.SetInitializer<LibraryManagerContext>(null);
        }

        public LibraryManagerContext()
            : base("Name=LibraryManagerContext")
        {
        }

        public DbSet<BookInstance> BookInstances { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookInstanceMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new LoanMap());
            modelBuilder.Configurations.Add(new MagazineMap());
            modelBuilder.Configurations.Add(new MemberMap());
        }
    }
}