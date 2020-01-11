using MyWallet.Data.Domain;
using System.Linq;

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

        public User GetByEmailAndPassword(string email, string password)
        {
            using (var context = new MyWalletDBContext())
            {
               return context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }
    }
}
