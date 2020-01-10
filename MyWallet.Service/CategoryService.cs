using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository = new CategoryRepository();

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }


        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Edit(Category category)
        {
            _categoryRepository.Edit(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }
    }
}
