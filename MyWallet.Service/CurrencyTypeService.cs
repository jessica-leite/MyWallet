using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CurrencyTypeService
    {
        CurrencyTypeRepository currencyTypeRepository = new CurrencyTypeRepository();

        public IEnumerable<CurrencyType> GetAll()
        {
            return currencyTypeRepository.GetAll();
        }
    }
}
