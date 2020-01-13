using MyWallet.Data.Domain;
using MyWallet.Data.Repository;

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
    }

}
