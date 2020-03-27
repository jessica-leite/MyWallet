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

            var expensesGroupByMonth = _unitOfWork.ExpenseRepository.GetAnnualExpensesByContextId(contextId);
            var incomesGroupByMonth = _unitOfWork.IncomeRepository.GetAnnualIncomesByContextId(contextId);
            
            viewModel.TotalCurrentMonthIncomes = incomesGroupByMonth[DateTime.Now.Month];
            viewModel.TotalCurrentMonthExpenses = expensesGroupByMonth[DateTime.Now.Month];

            var format = new DateTimeFormatInfo();
            foreach (var item in expensesGroupByMonth)
            {
                viewModel.AnnualExpenses.Add(format.GetMonthName(item.Key), item.Value);
            }

            foreach (var item in incomesGroupByMonth)
            {
                viewModel.AnnualIncomes.Add(format.GetMonthName(item.Key), item.Value);
            }


            return View(viewModel);
        }
    }
}