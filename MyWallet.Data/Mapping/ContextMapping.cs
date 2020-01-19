using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class ContextMapping : EntityTypeConfiguration<Context>
    {
        public ContextMapping()
        {
            ToTable("Context");

            HasKey(u => u.Id);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(u => u.User)
                .WithMany(e => e.Contexts)
                .HasForeignKey(u => u.UserId);

            HasRequired(u => u.CurrencyType)
                .WithMany()
                .HasForeignKey(u => u.CurrencyTypeId);

            HasRequired(u => u.Country)
                .WithMany()
                .HasForeignKey(u => u.CountryId);

            Property(u => u.IsMainContext)
                .IsRequired();
        }
    }
}
