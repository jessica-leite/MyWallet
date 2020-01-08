using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWallet.Data.Domain;
using MyWallet.Data.Repository;

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
