using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class ContextRepository
    {
        private MyWalletDBContext _context;

        public ContextRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public void Add(Context context)
        {
            _context.Context.Add(context);
        }

        public void Update(Context context)
        {
            _context.Entry(context).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Context context)
        {
            _context.Entry(context).State = System.Data.Entity.EntityState.Deleted;
        }

        public Context GetById(int id)
        {
            return _context.Context.Find(id);
        }

        public IEnumerable<Context> GetByUserId(int userId)
        {
            return _context.Context
                .Include(c => c.CurrencyType)
                .Include(c => c.Country)
                .Where(c => c.UserId == userId)
                .ToList();
        }

        public void SetTheMainContextAsNonMain(int userId)
        {
            var mainContext = _context.Context.FirstOrDefault(c => c.UserId == userId && c.IsMainContext);
            mainContext.IsMainContext = false;
        }
    }
}
