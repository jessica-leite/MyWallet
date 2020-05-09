using MyWallet.Data.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

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

        public IEnumerable<Category> CreateIfNotExistsAndReturnAll(IEnumerable<string> newCategoriesName, int contextId)
        {
            var existentCategories = GetByName(newCategoriesName, contextId);

            var allCategories = new List<Category>();
            foreach (var categoryName in newCategoriesName)
            {
                var category = existentCategories.FirstOrDefault(c => c.Name == categoryName);
                if (category == null)
                {
                    var newCategory = new Category { Name = categoryName, ContextId = contextId };
                    Add(newCategory);
                    allCategories.Add(newCategory);
                }
            }

            allCategories.AddRange(existentCategories);

            return allCategories;
        }

        public bool HasDependentExpensesOrIncomes(int categoryId)
        {
            var dependentExpenses = _context.Expense.Any(e => e.CategoryId == categoryId);
            var dependentIncomes = _context.Income.Any(i => i.CategoryId == categoryId);

            return dependentExpenses || dependentIncomes;
        }
    }
}
