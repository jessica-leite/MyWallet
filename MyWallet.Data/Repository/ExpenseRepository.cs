using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Data.Repository
{
    public class ExpenseRepository
    {
        public void Add(Expense expense)
        {
            using(var context = new MyWalletDBContext())
            {
                context.Expense.Add(expense);
                context.SaveChanges();
            }
        }
    }
}
