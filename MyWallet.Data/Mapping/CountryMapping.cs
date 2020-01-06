using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class CountryMapping : EntityTypeConfiguration<Country>
    {
        public CountryMapping()
        {
            ToTable("Country");

            HasKey(u => u.Id);

            Property(u => u.Name).IsRequired().HasMaxLength(255);
        }
    }
}
