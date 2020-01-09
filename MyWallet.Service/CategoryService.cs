using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CategoryService
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public void Add(Category category)
        {
            categoryRepository.Add(category);
        }


        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }
    }
}
