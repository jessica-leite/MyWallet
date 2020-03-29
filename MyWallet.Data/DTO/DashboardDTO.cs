using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Data.DTO
{
    public class DashboardDTO
    {
        public decimal TotalCurrentMonthExpenses { get; set; }
        public decimal TotalCurrentMonthIncomes { get; set; }

        public IDictionary<string, decimal> AnnualExpensesByMonth { get; set; }
        public IDictionary<int, decimal> AnnualIncomesByMonth { get; set; }
        public IDictionary<string, decimal> MontlhyExpensesByCategory { get; set; }

        public DashboardDTO()
        {
            AnnualExpensesByMonth = new Dictionary<string, decimal>();
            MontlhyExpensesByCategory = new Dictionary<string, decimal>();
        }
    }
}
