using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public string GetCurrencySymbolByContextId(int contextId)
        {
            var currencySymbol = _context.Context
                .Include(c => c.CurrencyType)
                .Where(c => c.Id == contextId)
                .Select(c => c.CurrencyType.Symbol)
                .FirstOrDefault();

            return currencySymbol;
        }
    }
}
