﻿using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class IncomeRepository
    {
        public void Add(Income income)
        {
            using(var context = new MyWalletDBContext())
            {
                context.Income.Add(income);
                context.SaveChanges();
            }
        }

        public IEnumerable<Income> GetByContextId(int contextId)
        {
            using(var context = new MyWalletDBContext())
            {
                 var incomeList = context.Income.Where(i => i.ContextId == contextId)
                    .Include(i => i.BankAccount)
                    .Include(i => i.Category)
                    .ToList();

                return incomeList;
            }
        }
    }
}