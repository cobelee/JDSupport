using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SEA_Fault : System.Web.UI.UserControl
{
    Tiyi.JD.BLL.FaultManage bll_faultManage = new Tiyi.JD.BLL.FaultManage();

    public event FaultInsertedEventHandler FaultCreated;
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
    public Guid FaultId
    {
        get
        {
            Guid faultId = Guid.Empty;
            Guid.TryParse(hfFaultId.Value, out faultId);
            return faultId;
        }
        set
        {
            hfFaultId.Value = value.ToString();
        }
    }

    #endregion

    #region 资源释放

    public override void Dispose()
    {
        bll_faultManage.Dispose();
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
        Guid faultId = Guid.Empty;
        Guid.TryParse(hfFaultId.Value, out faultId);

        if (e.CommandName == "UpdateFault")
        {

            Tiyi.JD.SQLServerDAL.Fault record = bll_faultManage.GetFaultById(faultId);

            // 故障描述
            TextBox tbFaultText = formView.FindControl("tbFaultText") as TextBox;
            record.FaultText = tbFaultText.Text;

            // 设备大类
            TextBox tbBigClass = formView.FindControl("tbBigClass") as TextBox;
            record.BigClass = tbBigClass.Text;


            bll_faultManage.UpdateFault(record);
            if (Updated != null)
            {
                Updated(this, new EventArgs());
            }

        }

        if (e.CommandName == "InsertFault")
        {
            Tiyi.JD.SQLServerDAL.Fault record = new Tiyi.JD.SQLServerDAL.Fault();

            // 故障描述
            TextBox tbFaultText = formView.FindControl("tbFaultText") as TextBox;
            record.FaultText = tbFaultText.Text;

            // 设备大类
            TextBox tbBigClass = formView.FindControl("tbBigClass") as TextBox;
            record.BigClass = tbBigClass.Text;


            Tiyi.JD.SQLServerDAL.Fault fault = bll_faultManage.NewFault(record);
            if (FaultCreated != null)
            {
                hfFaultId.Value = fault.FaultId.ToString();
                FaultInsertedEventArgs args = new FaultInsertedEventArgs(fault);
                FaultCreated(this, args);
            }
        }

        if (e.CommandName == "DeleteFault")
        {
            bll_faultManage.DeleteFault(faultId);
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
        //Populate_FaultTitle();
    }

}

public delegate void FaultInsertedEventHandler(object sender, FaultInsertedEventArgs e);

public class FaultInsertedEventArgs : EventArgs
{
    private Tiyi.JD.SQLServerDAL.Fault _fault;

    public FaultInsertedEventArgs(Tiyi.JD.SQLServerDAL.Fault fault)
    {
        this._fault = fault;
    }

    public Tiyi.JD.SQLServerDAL.Fault Fault
    {
        get { return _fault; }
    }
}