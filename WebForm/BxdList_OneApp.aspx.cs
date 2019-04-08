using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BxdList_OneApp : System.Web.UI.Page
{
    Tiyi.JD.BLL.BaoxiuManage bll_bxManage = new Tiyi.JD.BLL.BaoxiuManage();

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
            LoadBaoxiuBill(appId);
        }

    }

    private void LoadBaoxiuBill(Guid appId)
    {
        var bxds = from bxd in bll_bxManage.GetBaoxiuBill_ForOneApp(appId)
                   select bxd;

        rptBxd.DataSource = bxds;
        rptBxd.DataBind();
    }
    #endregion

    public bool GetIsPaidang(string strBxId)
    {
        Guid bxId = Guid.Empty;
        Guid.TryParse(strBxId, out bxId);
        return bll_bxManage.IsPaidang(bxId);
    }
}