using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxgList : System.Web.UI.Page
{
    Tiyi.JD.BLL.RepairmanManage bll_user = new Tiyi.JD.BLL.RepairmanManage();

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
        var users = bll_user.GetRepairman();
        rptApp.DataSource = users;
        rptApp.DataBind();
    }


}