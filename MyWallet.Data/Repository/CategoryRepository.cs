using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MyWallet.Data.Repository
{
    public class CategoryRepository
    {
        private MyWalletDBContext _context;

        public CategoryRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Category.Add(category);
        }

        public void Add(IEnumerable<Category> categories)
        {
            _context.Category.AddRange(categories);
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void Delete(Category category)
        {
            _context.Entry(category).State = EntityState.Deleted;
        }

        public Category GetById(int id)
        {
            return _context.Category.Find(id);
        }

        public IEnumerable<Category> GetByName(IEnumerable<string> categories, int contextId)
        {
            var query = _context.Category.Where(c => c.ContextId == contextId && categories.Contains(c.Name));
            return query.ToList();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public IEnumerable<Category> GetByContextId(int contextId)
        {
            return _context.Category.Where(c => c.ContextId == contextId).ToList();
        }

        public IEnumerable<Category> GetStandardCategories()
        {
            return new List<Category>
            {
                new Category{ Name = "Food" },
                new Category{ Name = "Groceries" },
                new Category{ Name = "Shopping" },
                new Category{ Name = "Transportation" },
                new Category{ Name = "Entertainment" },
                new Category{ Name = "Education" },
                new Category{ Name = "Health" },
                new Category{ Name = "Home" },
                new Category{ Name = "Debts" },
                new Category{ Name = "Salary" },
                new Category{ Name = "Other" }
            };
        }
    }
}
