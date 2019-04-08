using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataList : System.Web.UI.Page
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
        rptApp.DataSource = appes;
        rptApp.DataBind();
    }

    private void Research()
    {
        string queryStr = tbQueryStr.Text;
        if (string.IsNullOrEmpty(queryStr))
        {
            hfSearchMode.Value = "ByDep";
            Search(hfSearchMode.Value, ddlDepName.SelectedValue);
        }
        else
            Search(hfSearchMode.Value, tbQueryStr.Text);
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        hfSearchMode.Value = ddlCode.SelectedValue;
        Search(hfSearchMode.Value, tbQueryStr.Text);
    }

    protected void btnQueryByDep_Click(object sender, EventArgs e)
    {
        hfSearchMode.Value = "ByDep";
        tbQueryStr.Text = "";
        Search(hfSearchMode.Value, ddlDepName.SelectedValue);
    }

    protected void rptApp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteData")
        {
            Guid appId = Guid.Empty;
            Guid.TryParse(e.CommandArgument.ToString(), out appId);

            if (appId == Guid.Empty)
                return;

            bllApp.DeleteAppliance(appId);
            Research();
        }
    }
}