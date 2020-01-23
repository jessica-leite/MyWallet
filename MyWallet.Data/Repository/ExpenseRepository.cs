using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public IEnumerable<Expense> GetByContextId(int contextId)
        {
            using(var context = new MyWalletDBContext())
            {
              var expenses =  context.Expense.Where(e => e.ContextId == contextId)
                    .Include(e => e.BankAccount)
                    .Include(e => e.Category)
                    .ToList();

                return expenses;

            }
        }
    }
}
