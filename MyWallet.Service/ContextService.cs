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

        public void Add(Context context)
        {
            _contextRepository.Add(context);
        }
    }
}
