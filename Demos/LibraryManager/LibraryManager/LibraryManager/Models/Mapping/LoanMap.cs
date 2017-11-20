using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryManager.Models.Mapping
{
    public class LoanMap : EntityTypeConfiguration<Loan>
    {
        public LoanMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Loans");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MemberId).HasColumnName("MemberId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.FineIncurred).HasColumnName("FineIncurred");
            this.Property(t => t.BookInstanceId).HasColumnName("BookInstanceId");
            this.Property(t => t.Returned).HasColumnName("Returned");
            this.Property(t => t.FinePaid).HasColumnName("FinePaid");

            // Relationships
            this.HasRequired(t => t.BookInstance)
                .WithMany(t => t.Loans)
                .HasForeignKey(d => d.BookInstanceId);
            this.HasRequired(t => t.Member)
                .WithMany(t => t.Loans)
                .HasForeignKey(d => d.MemberId);

        }
    }
}
