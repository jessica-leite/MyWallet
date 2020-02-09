using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class BankAccountService
    {
        private UnitOfWork _unitOfWork;

        public BankAccountService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Add(BankAccount bankAccount)
        {
            _unitOfWork.BankAccountRepository.Add(bankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            _unitOfWork.BankAccountRepository.Update(bankAccount);
        }

        public void Delete(BankAccount bankAccount)
        {
            _unitOfWork.BankAccountRepository.Delete(bankAccount);
        }

        public BankAccount GetById(int id)
        {
            return _unitOfWork.BankAccountRepository.GetById(id);
        }

        public IEnumerable<BankAccount> GetByContextId(int contextId)
        {
            return _unitOfWork.BankAccountRepository.GetByContextId(contextId);
        }
    }
}
