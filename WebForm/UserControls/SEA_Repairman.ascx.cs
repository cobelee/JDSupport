using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SEA_Repairman : System.Web.UI.UserControl
{
    Tiyi.JD.BLL.RepairmanManage bll_RepairmanManage = new Tiyi.JD.BLL.RepairmanManage();

    public event RepairmanInsertedEventHandler RepairmanCreated;
    public event EventHandler Canceled;
    public event EventHandler Updated;
    public event EventHandler Deleted;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    #region 初始化加载
    public void Init_Load()
    {

    }
    #endregion

    #region 属性
    public Guid WxgId
    {
        get
        {
            Guid wxgId = Guid.Empty;
            Guid.TryParse(hfWxgId.Value, out wxgId);
            return wxgId;
        }
        set
        {
            hfWxgId.Value = value.ToString();
        }
    }

    #endregion

    #region 资源释放

    public override void Dispose()
    {
        bll_RepairmanManage.Dispose();
        base.Dispose();
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


    protected void View_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        string applicationReason = e.Values["tbApplicationReason"].ToString();
        if (string.IsNullOrEmpty(applicationReason))
        {
            e.Cancel = true;
        }
    }


    protected void formView_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        Guid wxgId = Guid.Empty;
        Guid.TryParse(hfWxgId.Value, out wxgId);

        if (e.CommandName == "UpdateRepairman")
        {

            Tiyi.JD.SQLServerDAL.Repairman record = bll_RepairmanManage.GetRepairmanById(wxgId);

            // 工号
            TextBox tbJobNumber = formView.FindControl("tbJobNumber") as TextBox;
            record.JobNumber = tbJobNumber.Text;

            // 姓名
            TextBox tbRealName = formView.FindControl("tbRealName") as TextBox;
            record.RealName = tbRealName.Text;

            // 手机号码
            TextBox tbMobilePhone = formView.FindControl("tbMobilePhone") as TextBox;
            record.MobilePhone = tbMobilePhone.Text;

            bll_RepairmanManage.UpdateRepairman(record);
            if (Updated != null)
            {
                Updated(this, new EventArgs());
            }

        }

        if (e.CommandName == "InsertRepairman")
        {
            Tiyi.JD.SQLServerDAL.Repairman record = new Tiyi.JD.SQLServerDAL.Repairman();

            // 工号
            TextBox tbJobNumber = formView.FindControl("tbJobNumber") as TextBox;
            record.JobNumber = tbJobNumber.Text;

            // 姓名
            TextBox tbRealName = formView.FindControl("tbRealName") as TextBox;
            record.RealName = tbRealName.Text;

            // 手机号码
            TextBox tbMobilePhone = formView.FindControl("tbMobilePhone") as TextBox;
            record.MobilePhone = tbMobilePhone.Text;

            Tiyi.JD.SQLServerDAL.Repairman user = bll_RepairmanManage.NewRepairman(record);
            if (RepairmanCreated != null)
            {
                hfWxgId.Value = user.WxgId.ToString();
                RepairmanInsertedEventArgs args = new RepairmanInsertedEventArgs(user);
                RepairmanCreated(this, args);
            }
        }

        if (e.CommandName == "DeleteRepairman")
        {
            bll_RepairmanManage.DeleteRepairman(wxgId);
            if (Deleted != null)
            {
                Deleted(this, new EventArgs());
            }
        }

        if (e.CommandName == "CancelUpdate" || e.CommandName == "CancelInsert")
        {
            if (Canceled != null)
            {
                Canceled(this, new EventArgs());
            }
        }
    }


    protected void formView_DataBound(object sender, EventArgs e)
    {
        //Populate_RepairmanTitle();
    }

}

public delegate void RepairmanInsertedEventHandler(object sender, RepairmanInsertedEventArgs e);

public class RepairmanInsertedEventArgs : EventArgs
{
    private Tiyi.JD.SQLServerDAL.Repairman _user;

    public RepairmanInsertedEventArgs(Tiyi.JD.SQLServerDAL.Repairman user)
    {
        this._user = user;
    }

    public Tiyi.JD.SQLServerDAL.Repairman Repairman
    {
        get { return _user; }
    }
}