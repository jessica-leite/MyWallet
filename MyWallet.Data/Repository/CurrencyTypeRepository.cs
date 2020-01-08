using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class CurrencyTypeRepository
    {
        public IEnumerable<CurrencyType> GetAll()
        {
            using (var context = new MyWalletDBContext())
            {
                return context.CurrencyType.ToList();
            }
        }
    }
}
