using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class ContextService
    {
        private UnitOfWork _unitOfWork;

        public ContextService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void AddOrUpdate(Context context)
        {
            if (context.IsNew())
                _unitOfWork.ContextRepository.Add(context);
            else
                _unitOfWork.ContextRepository.Update(context);
        }

        public void Delete(Context context)
        {
            _unitOfWork.ContextRepository.Delete(context);
        }

        public Context GetById(int id)
        {
            return _unitOfWork.ContextRepository.GetById(id);
        }

        public IEnumerable<Context> GetByUserId(int userId)
        {
            return _unitOfWork.ContextRepository.GetByUserId(userId);
        }

    }

}
