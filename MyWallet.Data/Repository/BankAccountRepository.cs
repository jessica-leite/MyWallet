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

        public BankAccount GetById(int id)
        {
            using (var context = new MyWalletDBContext())
            {
                return context.BankAccount.Find(id);
            }
        }

        public void Update(BankAccount bankAccount)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Entry(bankAccount).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
