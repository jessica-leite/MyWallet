using MyWallet.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MyWallet.Data.Mapping
{
    public class ExpenseMapping : EntityTypeConfiguration<Expense>
    {
        public ExpenseMapping()
        {
            ToTable("Expense");

            HasKey(e => e.Id);

            Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255);

            Property(e => e.Value)
                .IsRequired();

            Property(e => e.Date)
                .IsRequired();

            Property(e => e.IsPaid)
                .IsRequired();

            Property(e => e.Observation)
                .IsOptional()
                .HasMaxLength(255);

            HasRequired(e => e.BankAccount)
                .WithMany()
                .HasForeignKey(e => e.BankAccountId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            Property(e => e.CreationDate)
                .IsRequired();
        }
    }
}
