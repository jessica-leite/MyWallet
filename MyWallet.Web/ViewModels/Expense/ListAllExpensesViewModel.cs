using System.Collections.Generic;

namespace MyWallet.Web.ViewModels.Expense
{
    public class ListAllExpensesViewModel
    {
        public List<ExpenseViewModel> Expenses { get; set; }
        public string Currency { get; set; }

        public ListAllExpensesViewModel()
        {
            Expenses = new List<ExpenseViewModel>();
        }
    }
}