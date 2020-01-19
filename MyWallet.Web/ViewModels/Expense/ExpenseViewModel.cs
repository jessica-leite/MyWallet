using MyWallet.Web.ViewModels.BankAccount;
using MyWallet.Web.ViewModels.Category;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyWallet.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }
        public string Observation { get; set; }

        [Required]
        public int BankAccountId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Auxiliar labels
        public string Category { get; set; }
        public string BankAccount { get; set; }
    }
}