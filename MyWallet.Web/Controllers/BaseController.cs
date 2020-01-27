using MyWallet.Web.Util;
using MyWallet.Web.ViewModels.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        protected void SendModelStateErrors()
        {
            var errors = new List<ErrorViewModel>();
            foreach(var state in ModelState)
            {
                foreach (ModelError error in state.Value.Errors)
                    errors.Add(new ErrorViewModel { Message = error.ErrorMessage });
            }
            ViewBag.Errors = errors;
        }

        protected void SendModelStateErrors(string addMessage)
        {
            ModelState.AddModelError(string.Empty, addMessage);
            SendModelStateErrors();
        }
    }
}