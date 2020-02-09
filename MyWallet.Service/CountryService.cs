using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CountryService
    {
        private UnitOfWork _unitOfWork;

        public CountryService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Country> GetAll()
        {
            return _unitOfWork.CountryRepository.GetAll();
        }
    }
}
