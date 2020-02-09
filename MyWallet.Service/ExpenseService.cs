using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{

    public class ExpenseService
    {
        private UnitOfWork _unitOfWork;

        public ExpenseService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Add(Expense expense)
        {
            _unitOfWork.ExpenseRepository.Add(expense);
        }

        public void Add(IEnumerable<Expense> expenses)
        {
            _unitOfWork.ExpenseRepository.Add(expenses);
        }

        public void Update(Expense expense)
        {
            _unitOfWork.ExpenseRepository.Update(expense);
        }

        public void Delete(int id)
        {
            _unitOfWork.ExpenseRepository.Delete(id);
        }

        public Expense GetById(int id)
        {
            return _unitOfWork.ExpenseRepository.GetById(id);
        }

        public IEnumerable<Expense> GetByContextId(int contextId)
        {
            return _unitOfWork.ExpenseRepository.GetAllByContextId(contextId);
        }
    }
}
