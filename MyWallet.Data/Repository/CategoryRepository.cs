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

        public void Update(Category category)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Category GetById(int id)
        {
            using (var context = new MyWalletDBContext())
            {
                return context.Category.Find(id);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (var context = new MyWalletDBContext())
            {
                return context.Category.ToList();
            }
        }

        public IEnumerable<Category> GetByContextId(int contextId)
        {
            using(var context = new MyWalletDBContext())
            {
                var list = context.Category.Where(c => c.ContextId == contextId).ToList();
                return list;
            }
        }
    }
}
