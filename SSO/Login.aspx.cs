using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSO.Passport.Class;


namespace SSO
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Passport.Token"];
                if (cookie != null) // 有cookie则登陆过，URL发送令牌回去
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["BackUrl"]))
                    {
                        string backUrl = HttpUtility.UrlDecode(Request.QueryString["BackUrl"]) + "?Token=" + cookie.Value;
                        Response.Redirect(backUrl);
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // 模拟数据库验证通过
            string uName = txtName.Text.Trim();
            string uPwd = txtPwd.Text.Trim();
            if (uName == uPwd)
            {
                // 创建登录凭证      
                UserInfo user = new UserInfo();
                user.Alias = uName;
                user.HTTP_USER_AGENT = Request.UserAgent;
                user.UserIp = Request.UserHostAddress;
                user.ExpireDate = DateTime.Now.AddMinutes(double.Parse(System.Configuration.ConfigurationManager.AppSettings["CookieTimeout"]));
                string token = Guid.NewGuid().ToString("N").ToUpper();
                CacheManager.InsertToken(token, user);

                // 设置主站cookie
                HttpCookie cookie = new HttpCookie("Passport.Token");
                cookie.Value = token;
                cookie.Domain = "www.passport.com";
                //cookie.Domain = "localhost";
                cookie.Expires = DateTime.Now.AddMinutes(double.Parse(System.Configuration.ConfigurationManager.AppSettings["CookieTimeout"]));
                Response.AppendCookie(cookie);

                // 跳转回来访页面或OA平台主页
                if (Request.QueryString["BackUrl"] != null)
                {
                    Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["BackUrl"]) + "?Token=" + token);
                }
                else
                {
                    Response.Write("返回OA平台系统！");
                }
            }
        }

        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns></returns>
        public string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            // 最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PassportWebService pws = new PassportWebService();
            Response.Write(pws.CountCacheMember());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //HttpCookie aCookie;
            //string cookieName;
            //int limit = Request.Cookies.Count;
            //for (int i = 0; i < limit; i++)
            //{
            //    cookieName = Request.Cookies[i].Name;
            //    aCookie = new HttpCookie(cookieName);
            //    aCookie.Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies.Add(aCookie);
            //}

            HttpCookie cookie = new HttpCookie("Passport.Token");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.AppendCookie(cookie);
            Response.Flush();

            //if (Request.Cookies["Passport.Token"] != null)
            //{
            //    Response.Cookies["Passport.Token"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies["Passport.Token"].Values.Clear();
            //}
            //Response.Flush();
            //Response.End();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SSO.PassportWebService service = new PassportWebService();
            Response.Write(service.GetToken());
        }
    }
}