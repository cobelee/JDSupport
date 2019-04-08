using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxWork_WeibaoReg : System.Web.UI.Page
{
    Tiyi.JD.BLL.ApplianceManage bll_app = new Tiyi.JD.BLL.ApplianceManage();
    Tiyi.JD.BLL.WeibaoManage bll_weibao = new Tiyi.JD.BLL.WeibaoManage();
    Tiyi.JD.BLL.RepairmanManage bll_repaireman = new Tiyi.JD.BLL.RepairmanManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (User.Identity.IsAuthenticated)
        {
            hfJobNumber.Value = User.Identity.Name;
            bool isRepairman = bll_repaireman.ExistUser(hfJobNumber.Value);
            hfIsRepaireman.Value = isRepairman ? "True" : "False";
            if (isRepairman)
            {
                Tiyi.JD.SQLServerDAL.Repairman repairman = bll_repaireman.GetRepairmanByJobNumber(hfJobNumber.Value);
                ltlWbRealName.Text = repairman.RealName;
            }
        }
    }

    protected void Init_Input()
    {
        tbProductSN.Text = "";
        ltlProductSN.Text = "空";
        ltlAppType.Text = "空";
        ltlAddress.Text = "空";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (hfIsRepaireman.Value == "False") {
            MultiView1.SetActiveView(viewNotMaintainer);
            return;
        }

        string productSN = tbProductSN.Text;
        if (productSN.Length < 4)
            return;

        Tiyi.JD.SQLServerDAL.Appliance app = bll_app.GetAppliance(productSN);
        if (app == null)
            return;

        Tiyi.JD.SQLServerDAL.WeibaoLog wbLog = new Tiyi.JD.SQLServerDAL.WeibaoLog();
        wbLog.AppId = app.AppId;
        wbLog.FixedSN = app.FixedSN;
        wbLog.AssetSN = app.AssetSN;
        wbLog.ProductSN = app.ProductSN;
        wbLog.BigClass = app.BigClass;
        wbLog.AppType = app.AppType;
        wbLog.OwerDepName = app.OwnerDepName;
        wbLog.Address = app.Address;
        wbLog.WbContent = "维保完成";
        wbLog.Remark = tbRemark.Text;

        wbLog.WbJobNumber = hfJobNumber.Value;
        wbLog.WbRealName = ltlWbRealName.Text;

        bll_weibao.CreateWeibaoLog(wbLog);

        MultiView1.SetActiveView(viewResult);
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(viewInput);
        Init_Input();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbProductSN.Text))
            return;

        string productSN = tbProductSN.Text;
        Tiyi.JD.SQLServerDAL.Appliance app = bll_app.GetAppliance(productSN);
        if (app == null)
        {
            MultiView2.SetActiveView(viewNotFound);
        }
        else
        {
            MultiView2.SetActiveView(view1);
            ltlProductSN.Text = app.ProductSN;
            ltlAppType.Text = app.BigClass + app.AppType;
            ltlAddress.Text = app.OwnerDepName + app.Address;
        }

    }
}