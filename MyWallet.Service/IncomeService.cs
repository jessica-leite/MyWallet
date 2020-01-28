using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class IncomeService
    {
        private IncomeRepository _incomeRepository;

        public IncomeService()
        {
            _incomeRepository = new IncomeRepository();
        }

        public void Add(Income income)
        {
            _incomeRepository.Add(income);
        }

        public IEnumerable<Income> GetByContextId(int contextId)
        {
            return _incomeRepository.GetByContextId(contextId);
        }
    }
}
