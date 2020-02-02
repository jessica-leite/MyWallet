using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

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

        public void Add(IEnumerable<Expense> expenses)
        {
            _expenseRepository.Add(expenses);
        }

        public IEnumerable<Expense> GetByContextId(int contextId)
        {
            return _expenseRepository.GetByContextId(contextId);
        }
    }
}
