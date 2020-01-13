using MyWallet.Data.Domain;

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

        public void Update(Context context)
        {
            using (var dbContext = new MyWalletDBContext())
            {
                dbContext.Entry(context).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
