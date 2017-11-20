using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BookSearch.Models.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BookId, t.Isbn, t.Title, t.Author, t.Copies, t.Large, t.PublishDate });

            // Properties
            this.Property(t => t.BookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Isbn)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Copies)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Books");
            this.Property(t => t.BookId).HasColumnName("BookId");
            this.Property(t => t.Isbn).HasColumnName("ISBN");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Copies).HasColumnName("Copies");
            this.Property(t => t.Large).HasColumnName("Large");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
        }
    }
}
