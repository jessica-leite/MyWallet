using MyWallet.Data.Domain;
using MyWallet.Data.Repository;

namespace MyWallet.Service
{
    public class ContextService
    {
        ContextRepository contextRepository = new ContextRepository();

        public void Add(Context context)
        {
            contextRepository.Add(context);
        }
    }
}
