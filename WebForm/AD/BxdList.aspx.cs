using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AD_BxdList : System.Web.UI.Page
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
        LoadData();
    }

    private void LoadData()
    {
        var bxds = from bxd in bll_bxManage.GetBaoxiuBill_IsNotCompleted()
                   where bxd.IsCanceled == false
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