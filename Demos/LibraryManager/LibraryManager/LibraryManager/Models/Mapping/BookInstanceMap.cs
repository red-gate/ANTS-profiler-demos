using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryManager.Models.Mapping
{
    public class BookInstanceMap : EntityTypeConfiguration<BookInstance>
    {
        public BookInstanceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Location)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("BookInstances");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BookId).HasColumnName("BookId");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.PricePaid).HasColumnName("PricePaid");

            // Relationships
            this.HasRequired(t => t.Book)
                .WithMany(t => t.BookInstances)
                .HasForeignKey(d => d.BookId);

        }
    }
}
