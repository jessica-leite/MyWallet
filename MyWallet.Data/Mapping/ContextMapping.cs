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

            Property(u => u.Name).IsRequired().HasMaxLength(255);
            Property(u => u.UserId).IsRequired();
            Property(u => u.CurrencyTypeId).IsRequired();
            Property(u => u.CountryId).IsRequired();
            Property(u => u.IsMainContext).IsRequired();
        }
    }
}
