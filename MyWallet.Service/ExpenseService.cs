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

        public void Update(Expense expense)
        {
            _expenseRepository.Update(expense);
        }

        public void Delete(Expense expense)
        {
            _expenseRepository.Delete(expense);
        }

        public Expense GetById(int id)
        {
            return _expenseRepository.GetById(id);
        }

        public IEnumerable<Expense> GetByContextId(int contextId)
        {
            return _expenseRepository.GetByContextId(contextId);
        }
    }
}
