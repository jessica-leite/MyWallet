using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System.Collections.Generic;

namespace MyWallet.Service
{
    public class CategoryService
    {
        private UnitOfWork _unitOfWork;

        public CategoryService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Add(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
        }


        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        public void Update(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
        }

        public void Delete(Category category)
        {
            _unitOfWork.CategoryRepository.Delete(category);
        }

        public IEnumerable<Category> GetByContextId(int contextId)
        {
            return _unitOfWork.CategoryRepository.GetByContextId(contextId);
        }
    }
}
