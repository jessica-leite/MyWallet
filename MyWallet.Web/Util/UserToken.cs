using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWallet.Web.Util
{
    public class UserToken
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int MainContextId { get; set; }
    }
}