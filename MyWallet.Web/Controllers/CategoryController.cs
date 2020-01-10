using MyWallet.Data.Domain;
using MyWallet.Service;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class CategoryController : Controller
    {

        private CategoryService _categoryService = new CategoryService();

        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _categoryService.Edit(category);
            return RedirectToAction("Index");
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