using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A
{
    public partial class _default : BusinessCore.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.SSOAuthentication();
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            //Session.Abandon();
            Response.Redirect("http://www.passport.com/SignOut.aspx");
        }
    }
}