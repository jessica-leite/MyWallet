using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class BankAccountRepository
    {
        public void Add(BankAccount bankAccount)
        {
            using (var context = new MyWalletDBContext())
            {
                context.BankAccount.Add(bankAccount);
                context.SaveChanges();

            }
        }

        public IEnumerable<BankAccount> GetAll()
        {
            using (var context = new MyWalletDBContext())
            {
                return context.BankAccount.ToList();
            }
        }
    }
}
