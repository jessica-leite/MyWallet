using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CountryService
    {
        CountryRepository countryRepository = new CountryRepository();

        public IEnumerable<Country> GetAll()
        {
            return countryRepository.GetAll();
        }
    }
}
