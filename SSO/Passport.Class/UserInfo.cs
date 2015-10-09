using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSO.Passport.Class
{
    public class UserInfo
    {
        public string Alias { get; set; }

        public string HTTP_USER_AGENT { get; set; }

        public string UserIp { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}