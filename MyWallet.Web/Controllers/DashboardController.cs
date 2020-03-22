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
            var contextId = GetCurrentContextId();

            var viewModel = new DashboardViewModel();

            viewModel.TotalExpenses = _unitOfWork.ExpenseRepository.GetCurrentMonthTotalByContextId(contextId); 
            viewModel.TotalIncomes = _unitOfWork.IncomeRepository.GetCurrentMonthTotalByContextId(contextId);

            return View(viewModel);
        }
    }
}