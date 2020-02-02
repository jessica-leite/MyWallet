using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWallet.Data.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Context> Contexts { get; set; }

        public User()
        {
            Contexts = new List<Context>();
        }

        public Context GetTheMainContext()
        {
            return Contexts.FirstOrDefault(c => c.IsMainContext);
        }

        public int GetTheMainContextId()
        {
            return GetTheMainContext().Id;
        }

        public void AddNewContext(Context context)
        {
            Contexts.Add(context);
        }
    }
}
