using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public int GetUserIdLogged()
        {
            return Convert.ToInt32(User.Identity.Name);
        }
    }
}