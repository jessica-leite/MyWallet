using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class ContextRepository
    {
        public void Add(Context context)
        {
            using (var dbContext = new MyWalletDBContext())
            {
                dbContext.Context.Add(context);
                dbContext.SaveChanges();
            }
        }
    }
}
