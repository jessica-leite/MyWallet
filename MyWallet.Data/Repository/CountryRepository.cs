using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class CountryRepository
    {
        private MyWalletDBContext _context;

        public CountryRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Country.ToList();
        }
    }
}
