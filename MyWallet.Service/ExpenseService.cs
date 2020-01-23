using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Service
{

    public class ExpenseService
    {
        private ExpenseRepository _expenseRepository;

        public ExpenseService()
        {
            _expenseRepository = new ExpenseRepository();
        }

        public void Add(Expense expense)
        {
            _expenseRepository.Add(expense);
        }

        public IEnumerable<Expense> GetByContextId(int contextId)
        {
            return _expenseRepository.GetByContextId(contextId);
        }
    }
}
