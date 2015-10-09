using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SSO.Passport.Class;

namespace SSO
{
    /// <summary>
    /// PassportWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.Passport.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PassportWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetToken()
        {
            if (HttpContext.Current.Request.Cookies["Passport.Token"] != null)
            {
                string token = HttpContext.Current.Request.Cookies["Passport.Token"].Value;
                if (ValidateToken(token))
                {
                    return token;
                }
            }
            return null;
        }

        [WebMethod]
        public bool ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            if (HttpContext.Current.Cache["PASSPORT.TOKEN"] == null)
            {
                return false;
            }

            Dictionary<string, UserInfo> dict = HttpContext.Current.Cache["PASSPORT.TOKEN"] as Dictionary<string, UserInfo>;
            try
            {
                UserInfo user = dict[token];
                bool flag = user.HTTP_USER_AGENT == HttpContext.Current.Request.UserAgent
                    && user.UserIp == HttpContext.Current.Request.UserHostAddress;
                return true;

            }
            catch
            {

            }
            return false;
        }

        [WebMethod]
        public string GetSignNameByToken(string token)
        {
            return (HttpContext.Current.Cache["PASSPORT.TOKEN"] as Dictionary<string, UserInfo>)[token].Alias;
        }

        [WebMethod]
        public Int32 CountCacheMember()
        {
            var data = HttpContext.Current.Cache["PASSPORT.TOKEN"] as Dictionary<string, UserInfo>;
            return data == null ? 0 : data.Count;
        }
    }
}
