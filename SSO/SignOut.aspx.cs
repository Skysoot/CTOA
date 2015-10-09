using SSO.Passport.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSO
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Passport.Token"];
            if (cookie != null)
            {
                if (CacheManager.RemoveToken(cookie.Value))
                {
                    SubSiteSignOut();

                    cookie.Expires = DateTime.Now.AddYears(-1);
                    Response.AppendCookie(cookie);

                    //Response.Redirect("http://www.passport.com");
                }
            }
        }

        private void SubSiteSignOut()
        {
            //Server.Transfer("http://www.b.com/quit.aspx");
            //string url = "http://www.a.com/Quit.aspx";
            //HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            //request.GetResponse();
        }
    }
}