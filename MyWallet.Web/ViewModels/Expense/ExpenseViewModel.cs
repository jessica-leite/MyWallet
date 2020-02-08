using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Value { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date { get; set; }

        [DisplayName("Paid?")]
        public bool IsPaid { get; set; }
        public string Observation { get; set; }

        [Required]
        [DisplayName("Bank Account")]
        public int? BankAccountId { get; set; }

        [Required]
        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        // Auxiliar labels
        public string Category { get; set; }
        public string BankAccount { get; set; }
        public List<SelectListItem> SelectListBankAccount { get; set; }
        public List<SelectListItem> SelectListCategory { get; set; }
        public ExpenseViewModel()
        {
            SelectListBankAccount = new List<SelectListItem>();
            SelectListCategory = new List<SelectListItem>();
        }
        
    }
}