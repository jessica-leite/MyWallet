using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class CurrencyTypeMapping : EntityTypeConfiguration<CurrencyType>
    {
        public CurrencyTypeMapping()
        {
            ToTable("CurrencyType");

            HasKey(u => u.Id);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(u => u.Symbol)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
