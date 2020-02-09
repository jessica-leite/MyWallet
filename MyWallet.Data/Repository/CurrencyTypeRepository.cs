using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class CurrencyTypeRepository
    {
        private MyWalletDBContext _context;

        public CurrencyTypeRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public IEnumerable<CurrencyType> GetAll()
        {
            return _context.CurrencyType.ToList();
        }
    }
}
