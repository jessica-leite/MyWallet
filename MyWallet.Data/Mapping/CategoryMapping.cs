using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Category");

            HasKey(c => c.Id);

            Property(c => c.Name).IsRequired().HasMaxLength(255);
            Property(c => c.ContextId).IsRequired();
        }
    }
}
