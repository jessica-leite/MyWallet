using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class ContextService
    {
        private readonly ContextRepository _contextRepository;

        public ContextService()
        {
            _contextRepository = new ContextRepository();
        }

        public void AddOrUpdate(Context context)
        {
            if (context.IsNew())
                _contextRepository.Add(context);
            else
                _contextRepository.Update(context);
        }

        public void Delete(Context context)
        {
            _contextRepository.Delete(context);
        }

        public Context GetById(int id)
        {
            return _contextRepository.GetById(id);
        }

        public IEnumerable<Context> GetAll()
        {
            return _contextRepository.GetAll();
        }

    }

}
