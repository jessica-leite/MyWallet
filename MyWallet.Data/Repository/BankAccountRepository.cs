using MyWallet.Data.Domain;
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

        public IEnumerable<BankAccount> GetByName(IEnumerable<string> fileBankAccounts, int contextId)
        {
            var query = _context.BankAccount.Where(b => b.ContextId == contextId && fileBankAccounts.Contains(b.Name));
            return query.ToList();
        }
    }
}
