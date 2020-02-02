using MyWallet.Web.ViewModels.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels.BankAccount
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Opening Balance")]
        [Required(ErrorMessage ="Opening Balance is required")]
        public decimal? OpeningBalance { get; set; }
        public int ContextId { get; set; }
        public ContextViewModel Context { get; set; }
        public DateTime CreationDate { get; set; }
    }
}