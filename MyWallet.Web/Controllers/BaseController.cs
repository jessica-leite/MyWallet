using MyWallet.Web.Util;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected int GetCurrentUserId()
        {
            return GetUserToken().UserId;
        }

        protected int GetCurrentContextId()
        {
            return GetUserToken().MainContextId;
        }

        protected UserToken GetUserToken()
        {
            var userToken = JsonConvert.DeserializeObject<UserToken>(User.Identity.Name);
            return userToken;
        }
    }
}