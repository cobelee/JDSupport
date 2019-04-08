using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CorpDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SEA_Corporation1.CorporationCreated += SEA_Corporation1_CorpCreated;
        SEA_Corporation1.Canceled += SEA_Corporation1_Canceled;
        SEA_Corporation1.Deleted += SEA_Corporation1_Deleted;
        SEA_Corporation1.Updated += SEA_Corporation1_Updated;
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void SEA_Corporation1_Updated(object sender, EventArgs e)
    {
        SEA_Corporation1.ChangeMode(FormViewMode.ReadOnly);

    }

    private void SEA_Corporation1_Deleted(object sender, EventArgs e)
    {
        Response.Redirect("CorpList.aspx");
    }

    private void SEA_Corporation1_Canceled(object sender, EventArgs e)
    {
        SEA_Corporation1.ChangeMode(FormViewMode.ReadOnly);
    }

    private void SEA_Corporation1_CorpCreated(object sender, CorporationInsertedEventArgs e)
    {
        Response.Redirect("CorpList.aspx");
    }

    private void Init_Load()
    {
        if (Request.QueryString["id"] != null)
        {
            hfCorpId.Value = Request.QueryString["id"];
            Guid corpId = Guid.Empty;
            Guid.TryParse(hfCorpId.Value, out corpId);
            SEA_Corporation1.CorpId = corpId;
        }

        if (Request.QueryString["mode"] == "ReadOnly")
        {
            SEA_Corporation1.ChangeMode(FormViewMode.ReadOnly);
        }

        if (Request.QueryString["mode"] == "Edit")
        {
            SEA_Corporation1.ChangeMode(FormViewMode.Edit);
        }
    }
}