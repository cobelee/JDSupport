using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_DataList : System.Web.UI.Page
{
    Tiyi.JD.BLL.ApplianceManage bllApp = new Tiyi.JD.BLL.ApplianceManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        var corpList = bllApp.GetCorpNameList();
        foreach (string corp in corpList)
        {
            ListItem item = new ListItem(corp, corp);
            ddlDepName.Items.Add(item);
        }
        ddlDepName.Items.Insert(0, new ListItem("--- 选择公司 ---"));
        ddlDepName.SelectedIndex = 0;
    }

    private void LoadData()
    {
        var appes = bllApp.GetAppliance_IsUsing();
        rptApp.DataSource = appes;
        rptApp.DataBind();
    }

    private void Search(string searchMode, string queryStr)
    {
        Tiyi.JD.BLL.WeibaoManage bll_weibao = new Tiyi.JD.BLL.WeibaoManage();
        var appes = bllApp.GetAppliance_IsUsing();

        if (searchMode == "ProductSN" && !string.IsNullOrEmpty(queryStr))
        {
            appes = appes.Where(o => o.ProductSN == queryStr);
        }
        if (searchMode == "FixedSN" && !string.IsNullOrEmpty(queryStr))
        {
            appes = appes.Where(o => o.FixedSN.Contains(queryStr));
        }
        if (searchMode == "ByDep" && !string.IsNullOrEmpty(queryStr))
        {
            appes = appes.Where(o => o.OwnerDepName == queryStr);
        }

        List<WeibaoLogViewModel> logs = new List<WeibaoLogViewModel>();

        foreach (Tiyi.JD.SQLServerDAL.Appliance app in appes)
        {
            WeibaoLogViewModel log = new WeibaoLogViewModel();
            log.AppId = app.AppId;
            log.Address = app.Address;
            log.AppType = app.AppType;
            log.AssetSN = app.AssetSN;
            log.BigClass = app.BigClass;
            log.OwnerDepName = app.OwnerDepName;
            log.ProductSN = app.ProductSN;

            Tiyi.JD.SQLServerDAL.WeibaoLog wbLog = bll_weibao.GetLastWeibaoLog(log.AppId);
            if (wbLog != null)
            {
                log.WbContent = wbLog.WbContent;
                log.WbDate = wbLog.WbDate.Value;
                log.WbRealName = wbLog.WbRealName;
            }
            logs.Add(log);
        }

        rptApp.DataSource = logs;
        rptApp.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        hfSearchMode.Value = ddlCode.SelectedValue;
        Search(hfSearchMode.Value, tbQueryStr.Text);
    }

    protected void btnQueryByDep_Click(object sender, EventArgs e)
    {
        hfSearchMode.Value = "ByDep";
        Search(hfSearchMode.Value, ddlDepName.SelectedValue);
    }
}