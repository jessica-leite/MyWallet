using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels.Context;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ContextController : BaseController
    {
        private UnitOfWork _unitOfWork;

        public ContextController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Context> listContext = _unitOfWork.ContextRepository.GetByUserId(GetCurrentUserId());
            List <ContextViewModel> viewModel = new List<ContextViewModel>();

            foreach (var context in listContext)
            {
                var contextVM = new ContextViewModel();
                contextVM.Id = context.Id;
                contextVM.Name = context.Name;

                viewModel.Add(contextVM);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(ContextViewModel contextViewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                context.Id = contextViewModel.Id;
                context.Name = contextViewModel.Name;
                context.IsMainContext = contextViewModel.IsMainContext;
                context.CurrencyTypeId = contextViewModel.CurrencyTypeId;
                context.CountryId = contextViewModel.CountryId;
                context.UserId = GetCurrentUserId(); 

                _unitOfWork.ContextRepository.Update(context);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                SendModelStateErrors();
                return View(contextViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var context = _unitOfWork.ContextRepository.GetById(id);
            var viewModel = new ContextViewModel()
            {
                Id = context.Id,
                Name = context.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ContextViewModel viewModel)
        {
            var context = new Context()
            {
                Id = viewModel.Id
            };
            _unitOfWork.ContextRepository.Delete(context);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}