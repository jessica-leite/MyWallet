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
            if (GetUserToken() == null)
                return View();

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDatabase = new UserService().GetByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);
                if (userDatabase == null)
                {
                    SendModelStateErrors("Email or Password is invalid");
                    return View(loginViewModel);
                }

                CookieUtil.SetAuthCookie(userDatabase.Id, userDatabase.Name, userDatabase.GetTheMainContextId(), loginViewModel.RememberMe);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                SendModelStateErrors();
                return View(loginViewModel);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}