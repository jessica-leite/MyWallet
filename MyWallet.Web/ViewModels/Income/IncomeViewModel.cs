using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWallet.Web.ViewModels.Income
{
    public class IncomeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Value { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [DisplayName("Received?")]
        public bool Received { get; set; }
        public DateTime CreationDate { get; set; }
        public string Observation { get; set; }

        public int ContextId { get; set; }
        public string Context { get; set; }

        [Required]
        [DisplayName("Bank Account")]
        public int BankAccountId { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        // Auxiliar labels
        public string Category { get; set; }
        public string BankAccount { get; set; }
    }
}