using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System;

namespace MyWallet.Service
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();

        public void Add(User user)
        {
            user.CreationDate = DateTime.Now;

            userRepository.Add(user);
        }

    }
}
