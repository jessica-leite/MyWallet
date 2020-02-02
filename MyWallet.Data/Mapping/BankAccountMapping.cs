using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class BankAccountMapping : EntityTypeConfiguration<BankAccount>
    {
        public BankAccountMapping()
        {
            ToTable("BankAccount");

            HasKey(b => b.Id);

            Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(b => b.OpeningBalance)
                .IsRequired();

            HasRequired(b => b.Context)
                .WithMany()
                .HasForeignKey(b => b.ContextId);

            Property(b => b.CreationDate)
                .IsRequired();
        }
    }
}
