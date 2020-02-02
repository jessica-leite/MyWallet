using MyWallet.Data.Domain;
using System.Linq;
using System.Data.Entity;

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

        public void Update(User user)
        {
            using(var context = new MyWalletDBContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            using(var context = new MyWalletDBContext())
            {
                return context.User.Find(id);
            }
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            using (var context = new MyWalletDBContext())
            {
                var userWithContexts = context.User
                            .Include(u => u.Contexts)
                            .FirstOrDefault(u => u.Email == email && u.Password == password);

                return userWithContexts;
            }
        }

    }
}
