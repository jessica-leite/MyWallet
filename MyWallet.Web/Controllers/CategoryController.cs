using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Category;
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
            var category = new Category()
            {
                Name = createCategoryViewModel.Name,
                ContextId = GetCurrentContextId()
            };
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);

            var categoryViewModel = new EditCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ContextId = category.ContextId
            };

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Id = categoryViewModel.Id,
                    Name = categoryViewModel.Name,
                    ContextId = categoryViewModel.ContextId
                };
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(categoryViewModel);
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }
    }
}