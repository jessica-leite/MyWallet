using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");

            HasKey(u => u.Id);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.CreationDate)
                .IsRequired();
        }
    }
}
