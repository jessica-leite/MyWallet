using MyWallet.Data.Domain;
using System.Data.Entity;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class UserRepository
    {
        private MyWalletDBContext _context;

        public UserRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public User GetById(int id)
        {
            return _context.User.Find(id);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            var userWithContexts = _context.User
                           .Include(u => u.Contexts)
                           .FirstOrDefault(u => u.Email == email && u.Password == password);

            return userWithContexts;
        }
    }
}
