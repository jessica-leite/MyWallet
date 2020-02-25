using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class BankAccountRepository
    {
        private MyWalletDBContext _context;

        public BankAccountRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public void Add(BankAccount bankAccount)
        {
            _context.BankAccount.Add(bankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            _context.Entry(bankAccount).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(BankAccount bankAccount)
        {
            _context.Entry(bankAccount).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<BankAccount> GetByContextId(int contextId)
        {
            return _context.BankAccount.Where(b => b.ContextId == contextId).ToList();
        }

        public BankAccount GetById(int id)
        {
            return _context.BankAccount.Find(id);
        }

        public IEnumerable<BankAccount> GetByName(IEnumerable<string> bankAccountNames, int contextId)
        {
            var query = _context.BankAccount.Where(b => b.ContextId == contextId && bankAccountNames.Contains(b.Name));
            return query.ToList();
        }

        public IEnumerable<BankAccount> CreateIfNotExistsAndReturnAll(IEnumerable<string> newBankAccountsName, int contextId)
        {
            var existentBankAccounts = GetByName(newBankAccountsName, contextId);
            
            var allBankAccounts = new List<BankAccount>();
            foreach (var bankAccountName in newBankAccountsName)
            {
                var bankAccount = existentBankAccounts.FirstOrDefault(b => b.Name == bankAccountName);
                if (bankAccount == null)
                {
                    var newBankAccount = new BankAccount
                    {
                        Name = bankAccountName,
                        ContextId = contextId,
                        CreationDate = DateTime.Now,
                        OpeningBalance = 0
                    };

                    Add(newBankAccount);

                    allBankAccounts.Add(newBankAccount);
                }
            }

            allBankAccounts.AddRange(existentBankAccounts);
            return allBankAccounts;
        }
    }
}
