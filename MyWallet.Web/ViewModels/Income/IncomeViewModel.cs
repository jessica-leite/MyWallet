using System;

namespace MyWallet.Web.ViewModels.Income
{
    public class IncomeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public bool Received { get; set; }
        public DateTime CreationDate { get; set; }
        public string Observation { get; set; }
        public int ContextId { get; set; }
        public string Context { get; set; }
        public int BankAccountId { get; set; }
        public string BankAccount { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}