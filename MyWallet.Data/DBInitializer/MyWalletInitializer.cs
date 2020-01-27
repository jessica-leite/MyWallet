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
            var dollar = new CurrencyType { Id = 2, Name = "Dollar", Symbol = "$" };
            var real = new CurrencyType { Id = 3, Name = "Real", Symbol = "R$" };

            context.CurrencyType.AddOrUpdate(x => x.Id, euro, dollar, real);

            var portugal = new Country { Id = 1, Name = "Portugal" };
            var brazil = new Country { Id = 2, Name = "Brazil" };
            var france = new Country { Id = 3, Name = "France" };

            context.Country.AddOrUpdate(x => x.Id, portugal, brazil, france);

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
            user.AddNewContext(mainContext);

            context.User.AddOrUpdate(x => x.Id, user);

            var rowsAffected = context.SaveChanges();
        }

    }
}
