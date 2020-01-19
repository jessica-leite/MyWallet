using Newtonsoft.Json;
using System.Web.Security;

namespace MyWallet.Web.Util
{
    public class CookieUtil
    {
        public static string GetUserToken(int userId, string userName, int mainContextId)
        {
            var userToken = new UserToken()
            {
                UserId = userId,
                Name = userName,
                MainContextId = mainContextId
            };

            var jsonToken = JsonConvert.SerializeObject(userToken);
            return jsonToken;
        }

        public static void SetAuthCookie(int userId, string userName, int mainContextId, bool? rememberMe = null)
        {
            string jsonToken = GetUserToken(userId, userName, mainContextId);
            FormsAuthentication.SetAuthCookie(jsonToken, rememberMe.GetValueOrDefault());
        }
    }
}