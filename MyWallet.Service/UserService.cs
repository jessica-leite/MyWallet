using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System;

namespace MyWallet.Service
{
    public class UserService
    {
        private UnitOfWork _unitOfWork;

        public UserService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Add(User user)
        {
            user.CreationDate = DateTime.Now;

            _unitOfWork.UserRepository.Add(user);
        }

        public void Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
        }

        public User GetById(int id)
        {
            return _unitOfWork.UserRepository.GetById(id);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _unitOfWork.UserRepository.GetByEmailAndPassword(email, password);
        }

    }
}
