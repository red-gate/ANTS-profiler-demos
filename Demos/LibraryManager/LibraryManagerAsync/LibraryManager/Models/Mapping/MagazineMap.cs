using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryManager.Models.Mapping
{
    public class MagazineMap : EntityTypeConfiguration<Magazine>
    {
        public MagazineMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.ISBN)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Magazines");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.ISBN).HasColumnName("ISBN");
        }
    }
}
