using MyWallet.Data.DTO.Report;
using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels.Report;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ReportController : BaseController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var viewModel = GetViewModelWithFilters();

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index(ReportFilterDTO filterDTO)
        {
            var contextId = GetCurrentContextId();

            filterDTO.ContextId = contextId;

            var entries = _unitOfWork.ReportRepository.GetByFilter(filterDTO);

            var viewModel = GetViewModelWithFilters();
            viewModel.CurrencySymbol = _unitOfWork.CurrencyTypeRepository.GetCurrencySymbolByContextId(contextId);
            viewModel.Entries = entries;

            return View(viewModel);
        }

        private ReportFilterViewModel GetViewModelWithFilters()
        {
            var contextId = GetCurrentContextId();
            var viewModel = new ReportFilterViewModel();

            var categories = _unitOfWork.CategoryRepository.GetByContextId(contextId);
            foreach (var item in categories)
            {
                viewModel.SelectListCategory.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            var bankAccounts = _unitOfWork.BankAccountRepository.GetByContextId(contextId);
            foreach (var item in bankAccounts)
            {
                viewModel.SelectListBankAccount.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            viewModel.SelectListType.Add(new SelectListItem { Text = "Expense", Value = "1" });
            viewModel.SelectListType.Add(new SelectListItem { Text = "Income", Value = "2" });

            viewModel.SelectListSituation.Add(new SelectListItem { Text = "Paid", Value = "true" });
            viewModel.SelectListSituation.Add(new SelectListItem { Text = "Unpaid", Value = "false" });

            return viewModel;
        }
    }
}