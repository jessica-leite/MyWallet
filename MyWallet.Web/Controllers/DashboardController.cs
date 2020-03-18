using System;
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
            var viewModel = new DashboardViewModel();
            viewModel.TotalExpenses = _unitOfWork.ExpenseRepository
                .GetTotalByContextAndDate(1, new DateTime(2020,01,05), new DateTime(2020,01,27));

            viewModel.TotalIncomes = _unitOfWork.IncomeRepository
                .GetTotalByContextAndDate(1, new DateTime(2019, 10, 01), new DateTime(2019, 10, 01));

            return View(viewModel);
        }
    }
}