using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class CountryRepository
    {
        public IEnumerable<Country> GetAll()
        {
            using (var context = new MyWalletDBContext())
            {
                return context.Country.ToList();
            }
        }
    }
}
