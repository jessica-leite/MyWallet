using MyWallet.Data.Domain;
using MyWallet.Service;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class CategoryController : Controller
    {

        CategoryService categoryService = new CategoryService();

        public ActionResult Index()
        {
            var categories = categoryService.GetAll();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.Add(category);
            return RedirectToAction("Index");
        }
    }
}