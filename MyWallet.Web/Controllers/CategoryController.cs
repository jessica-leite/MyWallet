using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels.Category;
using System.Linq;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private UnitOfWork _unitOfWork;

        public CategoryController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepository.GetByContextId(GetCurrentContextId());

            var listAllCategoriesViewModel = new ListAllCategoriesViewModel();
            foreach (var category in categories)
            {
                var categoryViewModel = new CategoryViewModel();
                categoryViewModel.Name = category.Name;
                categoryViewModel.Id = category.Id;

                listAllCategoriesViewModel.Categories.Add(categoryViewModel);
            }

            return View(listAllCategoriesViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel createCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = createCategoryViewModel.Name,
                    ContextId = GetCurrentContextId()
                };
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                SendModelStateErrors();
                return View(createCategoryViewModel);
            }

        }

        public ActionResult Edit(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
            };

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Id = categoryViewModel.Id,
                    Name = categoryViewModel.Name,
                    ContextId = GetCurrentContextId()
                };
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                SendModelStateErrors();
                return View(categoryViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            var viewModel = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(CategoryViewModel categoryViewModel)
        {
            var category = new Category()
            {
                Id = categoryViewModel.Id,
            };
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public JsonResult GetAllByContextId(int? contextId)
        {
            var id = contextId.HasValue ? contextId.Value : GetCurrentContextId();

            var listCategory = _unitOfWork.CategoryRepository.GetByContextId(id);

            var json = listCategory.Select(c => new
            {
                c.Id,
                c.Name
            });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}