using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxWork_PaigongBillHandle : System.Web.UI.Page
{
    Tiyi.JD.BLL.PaigongManage bll_paigong = new Tiyi.JD.BLL.PaigongManage();
    Tiyi.JD.BLL.ApplianceManage bll_app = new Tiyi.JD.BLL.ApplianceManage();
    Tiyi.JD.BLL.BaoxiuManage bll_baoxiu = new Tiyi.JD.BLL.BaoxiuManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (Request.QueryString["PgId"] != null)
        {
            hfPgId.Value = Request.QueryString["PgId"];
            Load_PaigongBill();
        }
    }


    private void Load_PaigongBill()
    {
        Guid pgId = Guid.Empty;
        Guid.TryParse(hfPgId.Value, out pgId);

        if (pgId == Guid.Empty)
            return;

        Tiyi.JD.SQLServerDAL.PaigongBill bill = bll_paigong.GetPaigongBill(pgId);
        if (bill == null)
            return;

        hfBxId.Value = bill.BxId.ToString();

        ltlProductSN.Text = bill.ProductSN;
        ltlAppType.Text = bill.BigClass + bill.AppType;
        ltlAddress.Text = bill.Address;
        ltlFaultPhenomenon.Text = bill.FaultPhenomenon;
        ltlUser.Text = bill.UserName + " " + bill.WxgMobileShort;
        ltlRemark.Text = bill.Remark;
        ltlCreateDate.Text = bill.CreateDate.Value.ToString();
        ltlCreateDate2.Text = bill.CreateDate.Value.ToString();

        // 加载客户报修时间。
        Tiyi.JD.SQLServerDAL.BaoxiuBill bxBill = bll_baoxiu.GetBaoxiuBill(bill.BxId);
        if (bxBill != null)
        {
            ltlBaoxiuDate.Text = bxBill.CreateDate.ToString();
            ltlBaoxiuDate2.Text = bxBill.CreateDate.ToString();
        }

        // 根据派工单的接单状态信息，设置按钮
        if (bill.IsAccept)
        {
            ltlAcceptDate.Text = bill.AcceptDate.Value.ToString();
            MultiView1.SetActiveView(ViewComplete);
            mvInfo.SetActiveView(ViewHasAccept);
        }
        else
            MultiView1.SetActiveView(ViewJiedan);

        Tiyi.JD.SQLServerDAL.Appliance app = bll_app.GetAppliance(bill.AppId);
        if (app == null)
            return;
        ltlModel.Text = app.Model;

        if (app.ProductDate != null)
            ltlProductDate.Text = app.ProductDate.Value.ToShortDateString();
        if (app.InstallationDate != null)
            ltlInstallDate.Text = app.InstallationDate.Value.ToShortDateString();

        ltlFixedSN.Text = app.FixedSN;

    }

    protected void CommandButton_Click(object sender, CommandEventArgs e)
    {
        Guid pgId = Guid.Empty;
        Guid.TryParse(hfPgId.Value, out pgId);

        if (pgId == Guid.Empty)
            return;

        Tiyi.JD.SQLServerDAL.PaigongBill pgBill = bll_paigong.GetPaigongBill(pgId);
        if (pgBill == null)
            return;

        if (e.CommandName == "Accept")
        {
            pgBill.IsAccept = true;
            pgBill.AcceptDate = DateTime.Now;

            Tiyi.JD.SQLServerDAL.BaoxiuBill bxBill = bll_baoxiu.GetBaoxiuBill(pgBill.BxId);
            if (bxBill != null)
            {
                bxBill.BillStatus = "已接单";
                bll_baoxiu.SubmitChanges();
            }

            bll_paigong.SubmitChanges();
            MultiView1.SetActiveView(ViewComplete);
            mvInfo.SetActiveView(ViewHasAccept);
        }

        if (e.CommandName == "ToComplete")
        {

        }
    }
}