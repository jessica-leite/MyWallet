using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class IncomeMapping : EntityTypeConfiguration<Income>
    {
        public IncomeMapping()
        {
            ToTable("Income");

            HasKey(i => i.Id);

            Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(255);

            Property(i => i.Value)
                .IsRequired();

            Property(i => i.Date)
                .IsRequired();

            Property(i => i.Received)
                .IsRequired();

            Property(i => i.Observation)
                .IsOptional()
                .HasMaxLength(255);

            HasRequired(i => i.BankAccount)
                .WithMany()
                .HasForeignKey(i => i.BankAccountId)
                .WillCascadeOnDelete(false);

            HasRequired(i => i.Category)
                .WithMany()
                .HasForeignKey(i => i.CategoryId)
                .WillCascadeOnDelete(false);

            Property(i => i.CreationDate)
                .IsRequired();

            HasRequired(i => i.Context)
                .WithMany()
                .HasForeignKey(i => i.ContextId)
                .WillCascadeOnDelete(false);
        }
    }
}
