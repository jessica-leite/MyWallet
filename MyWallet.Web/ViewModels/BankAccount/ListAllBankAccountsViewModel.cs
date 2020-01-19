using System.Collections.Generic;

namespace MyWallet.Web.ViewModels.BankAccount
{
    public class ListAllBankAccountsViewModel
    {
        public List<BankAccountViewModel> BankAccounts { get; set; }

        public ListAllBankAccountsViewModel()
        {
            BankAccounts = new List<BankAccountViewModel>();
        }
    }
}