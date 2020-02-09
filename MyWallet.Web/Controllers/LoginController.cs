using MyWallet.Data.Repository;
using MyWallet.Web.Util;
using MyWallet.Web.ViewModels.Shared;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWallet.Web.Controllers
{
    public class LoginController : BaseController
    {
        private UnitOfWork _unitOfWork;

        public LoginController()
        {
            _unitOfWork = new UnitOfWork();
        }

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
                var userDatabase = _unitOfWork.UserRepository.GetByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);
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

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}