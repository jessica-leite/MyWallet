using MyWallet.Service;
using MyWallet.Web.Util;
using MyWallet.Web.ViewModels.Shared;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWallet.Web.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDatabase = new UserService().GetByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);
                if (userDatabase == null)
                {
                    return View(loginViewModel);
                }

                CookieUtil.SetAuthCookie(userDatabase.Id, userDatabase.Name, userDatabase.GetTheMainContextId(), loginViewModel.RememberMe);
                return RedirectToAction("Index", "Dashboard");
            }

            return View(loginViewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}