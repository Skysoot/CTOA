using CTOA.PassportWebServiceReference;
using System.Web.Mvc;

namespace CTOA.Controllers
{
    public class BaseController : Controller
    {
        protected string SignName;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
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
                        this.SignName = ws.GetSignNameByToken(token);
                        Session["SignName"] = this.SignName;
                    }
                    else // 伪造的 Token、登出、cookie 失效
                    {
                        Response.Redirect(System.Web.Configuration.WebConfigurationManager.AppSettings["PassportSiteAddress"]);
                    }
                }
            }
            else
            {
                this.SignName = Session["SignName"].ToString();
            }
            ViewBag.SignName = this.SignName;
        }
    }
}