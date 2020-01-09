using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWallet.Data.Domain;

namespace MyWallet.Data.Mapping
{
    class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Category");

            HasKey(c => c.Id);

            Property(c => c.Name).IsRequired().HasMaxLength(255);
            Property(c => c.UserId).IsRequired();
        }
    }
}
