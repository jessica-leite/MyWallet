using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWallet.Data.Domain;
using MyWallet.Data.Repository;

namespace MyWallet.Service
{
    public class ContextService
    {
        public void Add(Context context)
        {
            var contextRepository = new ContextRepository();
            contextRepository.Add(context);
        }
    }
}
