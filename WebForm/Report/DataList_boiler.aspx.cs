using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_DataList_Boiler : System.Web.UI.Page
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
        var corpList = bllApp.GetCorpNameList("开水炉");
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
        var appes = bllApp.GetAppliance_IsUsing().Where(o => o.BigClass == "开水炉");
        rptApp.DataSource = appes;
        rptApp.DataBind();
    }

    private void Search(string searchMode, string queryStr)
    {
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
            appes = appes.Where(o => o.BigClass=="开水炉" && o.OwnerDepName == queryStr);
        }
        rptApp.DataSource = appes;
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