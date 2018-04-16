using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bxd_WorkOrder : System.Web.UI.Page
{
    Tiyi.JD.BLL.ApplianceManage bll_appManage = new Tiyi.JD.BLL.ApplianceManage();
    Tiyi.JD.BLL.BaoxiuManage bll_bxdManage = new Tiyi.JD.BLL.BaoxiuManage();
    Tiyi.JD.BLL.RepairmanManage bll_wxg = new Tiyi.JD.BLL.RepairmanManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        SEA_Paigong1.BillCreated += SEA_Paigong1_BillCreated;
        SEA_Paigong1.Updated += SEA_Paigong1_Updated;
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void SEA_Paigong1_Updated(object sender, EventArgs e)
    {
        SEA_Paigong1.ChangeMode(FormViewMode.ReadOnly);
    }

    private void SEA_Paigong1_BillCreated(object sender, BillInsertedEventArgs e)
    {
        SEA_Paigong1.ChangeMode(FormViewMode.ReadOnly);
    }

    private void Init_Load()
    {
        if (Request.QueryString["id"] != null)
        {
            hfBxId.Value = Request.QueryString["id"];
            Guid bxId = Guid.Empty;
            Guid.TryParse(hfBxId.Value, out bxId);
            Tiyi.JD.SQLServerDAL.BaoxiuBill bill = bll_bxdManage.GetBaoxiuBill(bxId);
            LoadAppInfo(bill.AppId);
            LoadBillInfo(bxId);

            if (bll_bxdManage.IsPaidang(bxId))
            {
                SEA_Paigong1.ChangeMode(FormViewMode.ReadOnly);
                Tiyi.JD.SQLServerDAL.PaigongBill pgBill = bll_bxdManage.GetPgBill_ByBxId(bxId);
                SEA_Paigong1.Init_Load(pgBill.PgId);
            }
            else
            {
                SEA_Paigong1.ChangeMode(FormViewMode.Insert);
                SEA_Paigong1.Init_LoadBxId(bxId);
            }

        }

        Load_Wxg();
    }

    private void Load_Wxg()
    {
        var wxgs = bll_wxg.GetRepairman();
        rptApp.DataSource = wxgs;
        rptApp.DataBind();
    }

    private void LoadAppInfo(Guid appId)
    {
        Tiyi.JD.SQLServerDAL.Appliance app = bll_appManage.GetAppliance(appId);
        if (app == null)
            return;

        ltlProductSN.Text = app.ProductSN;
        ltlApp.Text = app.BigClass + " " + app.AppType;
        ltlModel.Text = app.Model;
        ltlFactory.Text = app.Factory;
        ltlFixedSN.Text = app.FixedSN;
        if (app.ProductDate == null)
            ltlInstallationDate.Text = "空";
        else
            ltlInstallationDate.Text = string.Format("{0:yyyy-MM-dd}", app.ProductDate);
    }

    public void LoadBillInfo(Guid bxId)
    {
        Tiyi.JD.SQLServerDAL.BaoxiuBill bill = bll_bxdManage.GetBaoxiuBill(bxId);
        if (bill == null)
            return;

        ltlProductSN.Text = bill.ProductSN;
        ltlApp.Text = bill.BigClass + " " + bill.AppType;
        ltlAddress.Text = bill.DepName + bill.Address;
        ltlUserName.Text = bill.UserName;
        ltlUserMobilePhone.Text = bill.UserMobilePhone;
    }


}