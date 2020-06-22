using MyWallet.Data.DBInitializer;
using MyWallet.Data.Domain;
using MyWallet.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyWallet.Data
{
    public class MyWalletDBContext : DbContext
    {
        public MyWalletDBContext()
        {
            Database.SetInitializer(new MyWalletInitializer());
        }

        public DbSet<User> User { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Context> Context { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Income> Income { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new CurrencyTypeMapping());
            modelBuilder.Configurations.Add(new CountryMapping());
            modelBuilder.Configurations.Add(new ContextMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new BankAccountMapping());
            modelBuilder.Configurations.Add(new ExpenseMapping());
            modelBuilder.Configurations.Add(new IncomeMapping());
        }
    }
}
