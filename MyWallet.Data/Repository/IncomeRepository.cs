using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Income GetById(int id)
        {
            return _context.Income.Find(id);
        }

        public void Add(Income income)
        {
            _context.Income.Add(income);
        }

        public void Delete(Income income)
        {
            _context.Entry(income).State = EntityState.Deleted;
        }

        public decimal GetTotalByContextAndDate(int contextId, DateTime startDate, DateTime endDate)
        {
            var incomes = _context.Income
                .Where(i => i.ContextId == contextId && i.Date >= startDate && i.Date <= endDate)
                .Select(i => i.Value)
                .ToList();

            decimal total = 0;
            foreach (var income in incomes)
            {
                total += income;
            }

            return total;
        }

        public void Update(Income income)
        {
            _context.Entry(income).State = EntityState.Modified;
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
