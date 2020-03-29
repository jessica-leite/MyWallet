using MyWallet.Data.DTO;
using MyWallet.Data.Repository;
using System;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var contextId = GetCurrentContextId();

            var dashboardDTO = new DashboardDTO();

            dashboardDTO = _unitOfWork.ExpenseRepository.GetAnnualExpensesByMonthAndContextIdAndCategory(contextId, dashboardDTO);
            dashboardDTO.AnnualIncomesByMonth = _unitOfWork.IncomeRepository.GetAnnualIncomesByMonthAndContextId(contextId);
            dashboardDTO.TotalCurrentMonthIncomes = dashboardDTO.AnnualIncomesByMonth[DateTime.Now.Month];
            
            return View(dashboardDTO);
        }
    }
}