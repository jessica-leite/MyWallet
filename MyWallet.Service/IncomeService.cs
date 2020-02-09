using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class IncomeService
    {
        private UnitOfWork _unitOfWork;

        public IncomeService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Add(Income income)
        {
            _unitOfWork.IncomeRepository.Add(income);
        }

        public void Delete(Income income)
        {
            _unitOfWork.IncomeRepository.Delete(income);
        }

        public IEnumerable<Income> GetByContextId(int contextId)
        {
            return _unitOfWork.IncomeRepository.GetByContextId(contextId);
        }
    }
}
