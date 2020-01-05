using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Service
{
    public class UserService
    {
        public void Add(User user)
        {
            user.CreationDate = DateTime.Now;

            var userRepository = new UserRepository();
            userRepository.Add(user);
        }

        public void Add()
        {

        }
    }
}
