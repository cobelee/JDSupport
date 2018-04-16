using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SEA_Paigong : System.Web.UI.UserControl
{
    Tiyi.JD.BLL.PaigongManage bll_Paigong = new Tiyi.JD.BLL.PaigongManage();
    Tiyi.JD.BLL.BaoxiuManage bll_baoxiu = new Tiyi.JD.BLL.BaoxiuManage();
    Tiyi.JD.BLL.RepairmanManage bll_wxg = new Tiyi.JD.BLL.RepairmanManage();
    Tiyi.Weixin.Work.SendMsgService ws_wxSender = new Tiyi.Weixin.Work.SendMsgService();

    public event PaigongBillInsertedEventHandler BillCreated;
    public event EventHandler Canceled;
    public event EventHandler Updated;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 属性
    public Guid PgId
    {
        get
        {
            Guid pgId = Guid.Empty;
            Guid.TryParse(hfPgId.Value, out pgId);
            return pgId;
        }
        set
        {
            hfPgId.Value = value.ToString();
        }

    }

    public Guid BxId
    {
        get
        {
            Guid bxId = Guid.Empty;
            Guid.TryParse(hfBxId.Value, out bxId);
            return bxId;
        }
        set
        {
            hfBxId.Value = value.ToString();
        }

    }
    #endregion

    /// <summary>
    /// 切换指定的数据输入模式。
    /// </summary>
    /// <param name="newMode"></param>
    public void ChangeMode(FormViewMode newMode)
    {
        formView.ChangeMode(newMode);
    }

    public void Init_Load(Guid pgId)
    {
        if (pgId != null && pgId != Guid.Empty)
        {
            this.PgId = pgId;
        }
    }

    public void Init_LoadBxId(Guid bxId)
    {
        if (bxId != null && bxId != Guid.Empty)
        {
            this.BxId = bxId;

        }
    }

    protected void AccountView_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        FormView formView = sender as FormView;

        //DropDownList ddlCurrencyList = formView.FindControl("ddlCurrencyType") as DropDownList;
        //if (ddlCurrencyList.SelectedIndex == 0)
        //{
        //    e.Cancel = true;
        //}
    }

    protected void PaigongBillView_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (Updated != null)
        {
            Updated(this, new EventArgs());
        }
    }


    protected void PaigongBillView_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        Guid bxId = Guid.Empty;
        Guid.TryParse(hfBxId.Value, out bxId);

        if (e.CommandName == "InsertBill")
        {
            Tiyi.JD.SQLServerDAL.BaoxiuBill bxBill = bll_baoxiu.GetBaoxiuBill(bxId);
            if (bxBill == null)
                return;

            Tiyi.JD.SQLServerDAL.PaigongBill pgBill = new Tiyi.JD.SQLServerDAL.PaigongBill();

            pgBill.BxId = bxBill.BxId;
            pgBill.AppId = bxBill.AppId;
            pgBill.ProductSN = bxBill.ProductSN;
            pgBill.BigClass = bxBill.BigClass;
            pgBill.AppType = bxBill.AppType;
            pgBill.DepName = bxBill.DepName;


            TextBox tbUserName = formView.FindControl("tbUserName") as TextBox;
            pgBill.UserName = tbUserName.Text;

            TextBox tbUserMobilePhone = formView.FindControl("tbUserMobilePhone") as TextBox;
            pgBill.UserMobilePhone = tbUserMobilePhone.Text;

            TextBox tbUserMobileShort = formView.FindControl("tbUserMobileShort") as TextBox;
            pgBill.UserMobileShort = tbUserMobileShort.Text;

            TextBox tbAddress = formView.FindControl("tbAddress") as TextBox;
            pgBill.Address = tbAddress.Text;

            TextBox tbFaultPhenomenon = formView.FindControl("tbFaultPhenomenon") as TextBox;
            pgBill.FaultPhenomenon = tbFaultPhenomenon.Text;

            TextBox tbRemark = formView.FindControl("tbRemark") as TextBox;
            pgBill.Remark = tbRemark.Text;

            DropDownList ddlWxg = formView.FindControl("ddlWxg") as DropDownList;
            Guid wxgId = Guid.Empty;
            Guid.TryParse(ddlWxg.SelectedValue, out wxgId);
            Tiyi.JD.SQLServerDAL.Repairman wxg = bll_wxg.GetRepairmanById(wxgId);
            if (wxg != null)
            {
                pgBill.WxgId = wxgId;
                pgBill.WxgRealName = wxg.RealName;
                pgBill.WxgMobilePhone = wxg.MobilePhone;
                pgBill.WxgMobileShort = wxg.MobileShort;
            }


            Tiyi.JD.SQLServerDAL.PaigongBill newBill = bll_Paigong.CreatePaigongBill(pgBill);
            if (newBill != null && BillCreated != null)
            {
                hfPgId.Value = newBill.PgId.ToString();
                BillInsertedEventArgs args = new BillInsertedEventArgs(newBill);
                BillCreated(this, args);
            }
        }

        if (e.CommandName == "UpdateBill")
        {
            Guid pgId = Guid.Empty;
            Guid.TryParse(hfPgId.Value, out pgId);
            Tiyi.JD.SQLServerDAL.PaigongBill pgBill = bll_Paigong.GetPaigongBill(pgId);

            TextBox tbUserName = formView.FindControl("tbUserName") as TextBox;
            pgBill.UserName = tbUserName.Text;

            TextBox tbUserMobilePhone = formView.FindControl("tbUserMobilePhone") as TextBox;
            pgBill.UserMobilePhone = tbUserMobilePhone.Text;

            TextBox tbUserMobileShort = formView.FindControl("tbUserMobileShort") as TextBox;
            pgBill.UserMobileShort = tbUserMobileShort.Text;

            TextBox tbAddress = formView.FindControl("tbAddress") as TextBox;
            pgBill.Address = tbAddress.Text;

            TextBox tbFaultPhenomenon = formView.FindControl("tbFaultPhenomenon") as TextBox;
            pgBill.FaultPhenomenon = tbFaultPhenomenon.Text;

            TextBox tbRemark = formView.FindControl("tbRemark") as TextBox;
            pgBill.Remark = tbRemark.Text;

            DropDownList ddlWxg = formView.FindControl("ddlWxg") as DropDownList;
            Guid wxgId = Guid.Empty;
            Guid.TryParse(ddlWxg.SelectedValue, out wxgId);
            Tiyi.JD.SQLServerDAL.Repairman wxg = bll_wxg.GetRepairmanById(wxgId);
            if (wxg != null)
            {
                pgBill.WxgId = wxgId;
                pgBill.WxgRealName = wxg.RealName;
                pgBill.WxgMobilePhone = wxg.MobilePhone;
                pgBill.WxgMobileShort = wxg.MobileShort;
            }

            bll_Paigong.UpdatePaigongBill(pgBill);
            if (Updated != null)
            {
                Updated(this, new EventArgs());
            }
        }

        if (e.CommandName == "InsertCancel" || e.CommandName == "UpdateCancel")
        {
            if (Updated != null)
            {
                Updated(this, new EventArgs());
            }
        }

        if (e.CommandName == "EditBill")
        {
            formView.ChangeMode(FormViewMode.Edit);
        }

        if (e.CommandName == "WxRemind")
        {
            Guid pgId = Guid.Empty;
            Guid.TryParse(hfPgId.Value, out pgId);
            Tiyi.JD.SQLServerDAL.PaigongBill pgBill = bll_Paigong.GetPaigongBill(pgId);

            Tiyi.Weixin.Work.Article article = new Tiyi.Weixin.Work.Article();
            article.Title = "收到维修派工单";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("设备类型：" + pgBill.BigClass + pgBill.AppType);
            sb.AppendLine("详细地址：" + pgBill.Address);
            sb.AppendLine("联系方式：" + pgBill.UserName + " " + pgBill.UserMobilePhone + " (短号：" + pgBill.UserMobileShort + ")");
            sb.AppendLine("派工时间：" + DateTime.Now.ToString() + "\n");
            sb.AppendLine("故障现象：" + pgBill.FaultPhenomenon);
            sb.AppendLine("备注信息：" + pgBill.Remark);
            article.Description = sb.ToString();
            article.Url = "";
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string articleJson = js.Serialize(article);
            ws_wxSender.SendArticleToUser("101527", articleJson, "34");

            Literal ltlSendWxResult = formView.FindControl("ltlSendWxResult") as Literal;
            ltlSendWxResult.Text = "微信提醒发送成功";
        }
    }

    protected void formView_DataBound(object sender, EventArgs e)
    {
        Populate_wxg();
        Populate_UserInfo();
    }

    public void Populate_wxg()
    {
        if (formView.CurrentMode == FormViewMode.Insert || formView.CurrentMode == FormViewMode.Edit)
        {
            DropDownList ddlWxg = formView.FindControl("ddlWxg") as DropDownList;
            var wxgs = bll_wxg.GetRepairman();
            ddlWxg.Items.Clear();         // 此句很重要，否则会导致多此加载下拉框数据的现象。
            foreach (Tiyi.JD.SQLServerDAL.Repairman item in wxgs)
            {
                ddlWxg.Items.Add(new ListItem(item.RealName, item.WxgId.ToString()));
            }
            if (wxgs.Count() > 0)
                ddlWxg.SelectedIndex = 0;


            if (formView.CurrentMode == FormViewMode.Edit)
            {
                HiddenField hfWxgId = formView.FindControl("hfWxgId") as HiddenField;
                foreach (ListItem item in ddlWxg.Items)
                {
                    if (hfWxgId.Value == item.Text)
                    {
                        ddlWxg.ClearSelection();           // 此句很重要，否则会产生出现多个项被选中的错误。
                        item.Selected = true;
                        break;
                    }
                }

            }
        }
    }

    public void Populate_UserInfo()
    {
        if (formView.CurrentMode == FormViewMode.Insert)
        {
            Guid bxId = Guid.Empty;
            Guid.TryParse(hfBxId.Value, out bxId);
            Tiyi.JD.SQLServerDAL.BaoxiuBill bxBill = bll_baoxiu.GetBaoxiuBill(bxId);
            if (bxBill == null)
                return;

            TextBox tbUserName = formView.FindControl("tbUserName") as TextBox;
            tbUserName.Text = bxBill.UserName;

            TextBox tbUserMobilePhone = formView.FindControl("tbUserMobilePhone") as TextBox;
            tbUserMobilePhone.Text = bxBill.UserMobilePhone;

            TextBox tbUserMobileShort = formView.FindControl("tbUserMobileShort") as TextBox;
            tbUserMobileShort.Text = bxBill.UserMobileShort;

            TextBox tbFaultPhenomenon = formView.FindControl("tbFaultPhenomenon") as TextBox;
            tbFaultPhenomenon.Text = bxBill.FaultPhenomenon;

            TextBox tbAddress = formView.FindControl("tbAddress") as TextBox;
            tbAddress.Text = bxBill.DepName + bxBill.Address;

        }
    }
}

public delegate void PaigongBillInsertedEventHandler(object sender, BillInsertedEventArgs e);

public class BillInsertedEventArgs : EventArgs
{
    private Tiyi.JD.SQLServerDAL.PaigongBill _bill;

    public BillInsertedEventArgs(Tiyi.JD.SQLServerDAL.PaigongBill bill)
    {
        this._bill = bill;
    }

    public Tiyi.JD.SQLServerDAL.PaigongBill PaigongBill
    {
        get { return _bill; }
    }
}