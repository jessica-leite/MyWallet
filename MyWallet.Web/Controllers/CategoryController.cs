using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Category;
using System.Linq;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private CategoryService _categoryService = new CategoryService();

        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();

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
                _categoryService.Add(category);
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
            var category = _categoryService.GetById(id);

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
                _categoryService.Update(category);
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
            var category = _categoryService.GetById(id);
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
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }

        public JsonResult GetAllByContextId(int? contextId)
        {
            var id = contextId.HasValue ? contextId.Value : GetCurrentContextId();

            var listCategory = _categoryService.GetByContextId(id);

            var json = listCategory.Select(c => new
            {
                c.Id,
                c.Name
            });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}