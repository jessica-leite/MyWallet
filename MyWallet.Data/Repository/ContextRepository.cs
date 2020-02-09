using MyWallet.Data.Domain;
using System.Collections.Generic;
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
            return _context.Context.ToList()
                    .Where(m => m.UserId == userId);
        }
    }
}
