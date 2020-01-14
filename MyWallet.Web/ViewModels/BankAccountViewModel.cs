using MyWallet.Web.ViewModels.Context;
using System;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OpeningBalance { get; set; }
        public int ContextId { get; set; }
        public ContextViewModel Context { get; set; }
        public DateTime CreationDate { get; set; }
    }
}