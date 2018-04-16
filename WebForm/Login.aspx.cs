using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Senparc.Weixin.Work;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.OAuth2;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser("101527", "233892"))
        {
            Label1.Text = "登录成功";
            
        }
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        FormsAuthentication.GetRedirectUrl("101527", true);
    }
}