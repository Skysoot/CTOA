using BusinessCore.PassportServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BusinessCore
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Session["SignName"] == null) // 站内凭证不存在
            {
                string token = Request.QueryString["Token"];
                if (string.IsNullOrEmpty(token)) // 未曾登陆过或已登出
                {
                    string url = System.Web.Configuration.WebConfigurationManager.AppSettings["PassportSiteAddress"] +
                                "?BackUrl=" + System.Web.HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
                    Response.Redirect(url);
                }
                else
                {
                    PassportWebServiceSoapClient ws = new PassportWebServiceSoapClient();
                    if (ws.ValidateToken(token))
                    {
                        // 根据有效的token得到用户Alias，并设置站内凭证，即Session
                        Session["SignName"] = ws.GetSignNameByToken(token);
                        Response.Write("应用系统Session凭证已生成！");
                    }
                    else // 伪造的 Token、登出、cookie 失效
                    {
                        Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["PassportSiteAddress"]);
                    }
                }
            }
        }
    }
}
