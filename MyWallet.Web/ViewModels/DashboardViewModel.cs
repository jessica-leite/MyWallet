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

        public string[] Months { get; set; }

        public IDictionary<int, decimal> Expenses { get; set; }

        public DashboardViewModel()
        {
            Expenses = new Dictionary<int, decimal>();
        }
    }
}