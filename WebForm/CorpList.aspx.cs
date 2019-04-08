using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CorpList : System.Web.UI.Page
{
    Tiyi.JD.BLL.CorpManage bll_user = new Tiyi.JD.BLL.CorpManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        LoadData();
    }

    private void LoadData()
    {
        var corps = bll_user.GetCorporation();
        rptApp.DataSource = corps;
        rptApp.DataBind();
    }


}