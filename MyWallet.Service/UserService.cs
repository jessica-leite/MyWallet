using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System;

namespace MyWallet.Service
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService() 
        { 
           _userRepository = new UserRepository();
        } 

        public void Add(User user)
        {
            user.CreationDate = DateTime.Now;

            _userRepository.Add(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetByEmailAndPassword(email, password);
        }

    }
}
