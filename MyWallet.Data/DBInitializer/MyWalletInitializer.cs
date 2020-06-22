using MyWallet.Data.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MyWallet.Data.DBInitializer
{
    public class MyWalletInitializer : CreateDatabaseIfNotExists<MyWalletDBContext>
    {
        protected override void Seed(MyWalletDBContext context)
        {
            var euro = new CurrencyType { Id = 1, Name = "Euro", Symbol = "€" };
            var real = new CurrencyType { Id = 3, Name = "Real", Symbol = "R$" };
            var dollar = new CurrencyType { Id = 2, Name = "Dollar", Symbol = "$" };

            context.CurrencyType.AddOrUpdate(x => x.Id, euro, real, dollar);

            var portugal = new Country { Id = 1, Name = "Portugal" };
            var brazil = new Country { Id = 2, Name = "Brazil" };
            var usa = new Country { Id = 3, Name = "USA" };

            context.Country.AddOrUpdate(x => x.Id, portugal, brazil, usa);

            var user = new User();
            user.Name = "Jéssica";
            user.LastName = "Leite";
            user.Email = "jessica@email.com";
            user.Password = "123456";
            user.CreationDate = DateTime.Now;

            var mainContext = new Context()
            {
                UserId = user.Id,
                IsMainContext = true,
                Name = "My Finances",
                CountryId = portugal.Id,
                CurrencyTypeId = euro.Id
            };

            context.Context.AddOrUpdate(x => x.Id, mainContext);

            context.User.AddOrUpdate(x => x.Id, user);

            var bankAccount = new BankAccount()
            {
                Id = 1,
                Name = "Default",
                ContextId = mainContext.Id,
                CreationDate = DateTime.Now,
                OpeningBalance = 10000
            };
            context.BankAccount.AddOrUpdate(x => x.Id, bankAccount);

            var category = new Category()
            {
                Id = 1,
                Name = "Default",
                ContextId = mainContext.Id
            };
            context.Category.AddOrUpdate(x => x.Id, category);

            context.SaveChanges();
        }

    }
}
