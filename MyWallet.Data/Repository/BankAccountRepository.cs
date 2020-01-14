using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
