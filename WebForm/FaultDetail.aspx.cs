using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FaultDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SEA_Fault1.FaultCreated += SEA_Fault1_FaultCreated;
        SEA_Fault1.Canceled += SEA_Fault1_Canceled;
        SEA_Fault1.Deleted += SEA_Fault1_Deleted;
        SEA_Fault1.Updated += SEA_Fault1_Updated;
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void SEA_Fault1_Updated(object sender, EventArgs e)
    {
        SEA_Fault1.ChangeMode(FormViewMode.ReadOnly);

    }

    private void SEA_Fault1_Deleted(object sender, EventArgs e)
    {
        Response.Redirect("FaultList.aspx");
    }

    private void SEA_Fault1_Canceled(object sender, EventArgs e)
    {
        SEA_Fault1.ChangeMode(FormViewMode.ReadOnly);
    }

    private void SEA_Fault1_FaultCreated(object sender, FaultInsertedEventArgs e)
    {
        Response.Redirect("FaultList.aspx");
    }

    private void Init_Load()
    {
        if (Request.QueryString["id"] != null)
        {
            hfFaultId.Value = Request.QueryString["id"];
            Guid faultId = Guid.Empty;
            Guid.TryParse(hfFaultId.Value, out faultId);
            SEA_Fault1.FaultId = faultId;
        }

        if (Request.QueryString["mode"] == "ReadOnly")
        {
            SEA_Fault1.ChangeMode(FormViewMode.ReadOnly);
        }

        if (Request.QueryString["mode"] == "Edit")
        {
            SEA_Fault1.ChangeMode(FormViewMode.Edit);
        }
    }
}