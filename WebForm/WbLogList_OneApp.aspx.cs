using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WbLogList_OneApp : System.Web.UI.Page
{
    Tiyi.JD.BLL.WeibaoManage bll_wbLog = new Tiyi.JD.BLL.WeibaoManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    #region 初始化加载

    private void Init_Load()
    {
        if (Request.QueryString["id"] != null)
        {
            Guid appId = Guid.Empty;
            Guid.TryParse(Request.QueryString["id"], out appId);
            if (appId == Guid.Empty)
                return;
            LoadWbLog(appId);
        }

    }

    private void LoadWbLog(Guid appId)
    {
        var bxds = from bxd in bll_wbLog.GetWeibaoLog(appId)
                   select bxd;

        rptBxd.DataSource = bxds;
        rptBxd.DataBind();
    }
    #endregion


}