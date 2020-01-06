using MyWallet.Data.Domain;
using MyWallet.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyWallet.Data
{
    public class MyWalletDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new CurrencyTypeMapping());
        }
    }
}
