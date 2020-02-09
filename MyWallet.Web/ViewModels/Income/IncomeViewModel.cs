using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels.Income
{
    public class IncomeViewModel
    {
        public IncomeViewModel()
        {
            SelectListBankAccount = new List<SelectListItem>();
            SelectListCategory = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Value { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [DisplayName("Received?")]
        public bool Received { get; set; }
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
    }
}