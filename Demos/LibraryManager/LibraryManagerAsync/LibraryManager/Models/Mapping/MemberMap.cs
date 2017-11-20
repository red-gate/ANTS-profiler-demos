using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LibraryManager.Models.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.Address3)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.County)
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.PostCode)
                .HasMaxLength(10);

            this.Property(t => t.Phone1)
                .HasMaxLength(50);

            this.Property(t => t.Phone2)
                .HasMaxLength(50);

            this.Property(t => t.Email1)
                .HasMaxLength(50);

            this.Property(t => t.Email2)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Members");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.Address3).HasColumnName("Address3");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
            this.Property(t => t.Phone1).HasColumnName("Phone1");
            this.Property(t => t.Phone2).HasColumnName("Phone2");
            this.Property(t => t.Email1).HasColumnName("Email1");
            this.Property(t => t.Email2).HasColumnName("Email2");
            this.Property(t => t.JoinDate).HasColumnName("JoinDate");
        }
    }
}
