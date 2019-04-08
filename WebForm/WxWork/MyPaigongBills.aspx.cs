using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxWork_MyPaigongBills : System.Web.UI.Page
{
    Tiyi.JD.BLL.RepairmanManage bll_repaireMan = new Tiyi.JD.BLL.RepairmanManage();
    Tiyi.JD.BLL.PaigongManage bll_paigong = new Tiyi.JD.BLL.PaigongManage();

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

            if (bll_repaireMan.ExistUser(hfJobNumber.Value))
            {
                Tiyi.JD.SQLServerDAL.Repairman user = bll_repaireMan.GetRepairmanByJobNumber(hfJobNumber.Value);
                if (user == null)
                    return;

                hfWxgId.Value = user.WxgId.ToString();

                Load_PaigongBill();
            }
        }
    }

    private void Load_PaigongBill()
    {
        Guid wxgId = Guid.Empty;
        Guid.TryParse(hfWxgId.Value, out wxgId);
        var bills = bll_paigong.GetPaigongBill(wxgId, false);
        rptPaigong.DataSource = bills;
        rptPaigong.DataBind();
    }

    protected void rptPaigong_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Tiyi.JD.SQLServerDAL.PaigongBill bill = e.Item.DataItem as Tiyi.JD.SQLServerDAL.PaigongBill;
            Literal ltlJiedanStatus = e.Item.FindControl("ltlJiedanStatus") as Literal;
            if (bill.IsAccept)
                ltlJiedanStatus.Text = " <b>(已接单维修)</b>";
            else
                ltlJiedanStatus.Text = " (派工时间：" + bill.CreateDate.Value.ToShortDateString() + ")";
        }
    }
}