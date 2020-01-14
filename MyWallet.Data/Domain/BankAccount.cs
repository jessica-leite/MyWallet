using System;

namespace MyWallet.Data.Domain
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OpeningBalance { get; set; }
        public int ContextId { get; set; }
        public Context Context { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
