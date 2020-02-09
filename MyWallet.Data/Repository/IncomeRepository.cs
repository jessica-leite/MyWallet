using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class IncomeRepository
    {
        private MyWalletDBContext _context;

        public IncomeRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public void Add(Income income)
        {
            _context.Income.Add(income);
        }

        public void Delete(Income income)
        {
            _context.Entry(income).State = EntityState.Deleted;
        }

        public IEnumerable<Income> GetByContextId(int contextId)
        {
            var incomeList = _context.Income.Where(i => i.ContextId == contextId)
                  .Include(i => i.BankAccount)
                  .Include(i => i.Category)
                  .Include(i => i.Context)
                  .ToList();

            return incomeList;
        }
    }
}
