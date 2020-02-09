using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = GetCurrentUserId();

            return View();
        }
    }
}