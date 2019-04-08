using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bxd_Cancel : System.Web.UI.Page
{
    Tiyi.JD.BLL.BaoxiuManage bll_bxdManage = new Tiyi.JD.BLL.BaoxiuManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        if (Request.QueryString["id"] != null)
        {
            hfBxdId.Value = Request.QueryString["id"];
            Guid bxdId = Guid.Empty;
            Guid.TryParse(hfBxdId.Value, out bxdId);
            LoadBillInfo(bxdId);
        }
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

    protected void CommandButton_Click(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "CancelBill")
        {
            Guid bxdId = Guid.Empty;
            Guid.TryParse(hfBxdId.Value, out bxdId);
            Tiyi.JD.SQLServerDAL.BaoxiuBill bill = bll_bxdManage.GetBaoxiuBill(bxdId);
            bill.HandleResult = "管理员取消了此报修单，原因：" + tbHandleResult.Text;
            bill.IsCanceled = true;
            bill.IsCompleted = true;
            bll_bxdManage.UpdateBaoxiuBill(bill);
            Response.Redirect("BxdList.aspx");
        }

        if (e.CommandName == "GoBack")
        {

            Response.Redirect("BxdList.aspx");
        }
    }
}