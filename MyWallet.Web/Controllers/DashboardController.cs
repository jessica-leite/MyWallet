using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var contextId = GetCurrentContextId();

            var viewModel = new DashboardViewModel();

            viewModel.TotalCurrentMonthExpenses = _unitOfWork.ExpenseRepository.GetCurrentMonthTotalByContextId(contextId); 
            viewModel.TotalCurrentMonthIncomes = _unitOfWork.IncomeRepository.GetCurrentMonthTotalByContextId(contextId);

            var expensesGroupByMonth = _unitOfWork.ExpenseRepository.GetAnnualExpensesByContextId(contextId);

            var months = new List<string>();
            foreach (var item in expensesGroupByMonth)
            {
                var format = new DateTimeFormatInfo();
                var monthName = format.GetMonthName(item.Key);
                months.Add(monthName);
            }

            viewModel.Months = months.ToArray();
            viewModel.Expenses = expensesGroupByMonth;

            return View(viewModel);
        }
    }
}