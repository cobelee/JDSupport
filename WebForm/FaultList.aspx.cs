using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FaultList : System.Web.UI.Page
{
    Tiyi.JD.BLL.FaultManage bll_fault = new Tiyi.JD.BLL.FaultManage();

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
        var faults = bll_fault.GetFault();
        rptApp.DataSource = faults;
        rptApp.DataBind();
    }


}