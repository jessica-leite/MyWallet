using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class CategoryRepository
    {
        public void Add(Category category)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Category.Add(category);
                context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (var context = new MyWalletDBContext())
            {
                return context.Category.ToList();
            }
        }
    }
}
