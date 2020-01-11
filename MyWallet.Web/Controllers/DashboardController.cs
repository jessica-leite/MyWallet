using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = GetUserIdLogged();

            return View();
        }
    }
}