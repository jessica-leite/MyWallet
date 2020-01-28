using System.Collections.Generic;

namespace MyWallet.Web.ViewModels.Income
{
    public class ListAllIncomeViewModel
    {
        public List<IncomeViewModel> IncomeList { get; set; }
        public string Currency { get; set; }

        public ListAllIncomeViewModel()
        {
            IncomeList = new List<IncomeViewModel>();
        }
    }
}