using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWallet.Web.ViewModels
{
    public class DashboardViewModel
    {
        public decimal TotalCurrentMonthExpenses { get; set; }
        public decimal TotalCurrentMonthIncomes { get; set; }

        public IDictionary<string, decimal> AnnualExpenses { get; set; }
        public IDictionary<string, decimal> AnnualIncomes { get; set; }

        public DashboardViewModel()
        {
            AnnualExpenses = new Dictionary<string, decimal>();
            AnnualIncomes = new Dictionary<string, decimal>();
        }
    }
}