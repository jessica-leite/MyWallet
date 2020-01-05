using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Data.Repository
{
    public class UserRepository
    {
        public void Add(User user) 
        {
            using (var context = new MyWalletDBContext()) 
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }
    }
}
