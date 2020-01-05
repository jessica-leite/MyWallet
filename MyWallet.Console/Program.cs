using MyWallet.Data;
using MyWallet.Data.Domain;
using System;

namespace MyWallet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyWalletDBContext())
            {
                string connectionString = context.Database.Connection.ConnectionString;

                var user = new User();
                user.Name = "Jéssica";
                user.LastName = "Leite";
                user.Email = "jessica@email.com";
                user.Password = "123456";
                user.CreationDate = DateTime.Now;

                context.User.Add(user);
                context.SaveChanges();
            }
        }
    }
}
