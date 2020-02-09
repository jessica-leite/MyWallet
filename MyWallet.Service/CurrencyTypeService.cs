using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CurrencyTypeService
    {
        private UnitOfWork _unitOfWork;

        public CurrencyTypeService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<CurrencyType> GetAll()
        {
            return _unitOfWork.CurrencyTypeRepository.GetAll();
        }
    }
}
