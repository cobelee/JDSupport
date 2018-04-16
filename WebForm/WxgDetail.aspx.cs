using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxgDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SEA_Repairman1.RepairmanCreated += SEA_Repairman1_RepairmanCreated;
        SEA_Repairman1.Canceled += SEA_Repairman1_Canceled;
        SEA_Repairman1.Deleted += SEA_Repairman1_Deleted;
        SEA_Repairman1.Updated += SEA_Repairman1_Updated;
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void SEA_Repairman1_Updated(object sender, EventArgs e)
    {
        SEA_Repairman1.ChangeMode(FormViewMode.ReadOnly);

    }

    private void SEA_Repairman1_Deleted(object sender, EventArgs e)
    {
        Response.Redirect("WxgList.aspx");
    }

    private void SEA_Repairman1_Canceled(object sender, EventArgs e)
    {
        SEA_Repairman1.ChangeMode(FormViewMode.ReadOnly);
    }

    private void SEA_Repairman1_RepairmanCreated(object sender, RepairmanInsertedEventArgs e)
    {
        Response.Redirect("WxgList.aspx");
    }

    private void Init_Load()
    {
        if (Request.QueryString["id"] != null)
        {
            hfAppId.Value = Request.QueryString["id"];
            Guid wxgId = Guid.Empty;
            Guid.TryParse(hfAppId.Value, out wxgId);
            SEA_Repairman1.WxgId = wxgId;
        }

        if (Request.QueryString["mode"] == "ReadOnly")
        {
            SEA_Repairman1.ChangeMode(FormViewMode.ReadOnly);
        }

        if (Request.QueryString["mode"] == "Edit")
        {
            SEA_Repairman1.ChangeMode(FormViewMode.Edit);
        }
    }
}