﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataManuCreate : System.Web.UI.Page
{
    Tiyi.JD.BLL.ApplianceManage bllApp = new Tiyi.JD.BLL.ApplianceManage();
    Tiyi.JD.BLL.CorpManage bll_corp = new Tiyi.JD.BLL.CorpManage();

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
            hfAppId.Value = Request.QueryString["id"];
        }
    }


    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "ToEdit")
        {
            FormView1.ChangeMode(FormViewMode.Edit);

        }



        if (e.CommandName == "CreateApp")
        {
            FormView formView = sender as FormView;
            Guid appId = Guid.Empty;
            Guid.TryParse(hfAppId.Value, out appId);

            Tiyi.JD.SQLServerDAL.Appliance app = new Tiyi.JD.SQLServerDAL.Appliance();

            app.ProductSN = (formView.FindControl("tbProductSN") as TextBox).Text;
            app.BigClass = (formView.FindControl("tbBigClass") as TextBox).Text;
            app.AppName = app.BigClass;
            app.AppType = (formView.FindControl("tbAppType") as TextBox).Text;
            app.Model = (formView.FindControl("tbModel") as TextBox).Text;
            app.PowerCold = (formView.FindControl("tbPowerCold") as TextBox).Text;
            app.PowerHot = (formView.FindControl("tbPowerHot") as TextBox).Text;
            app.Power = (formView.FindControl("tbPower") as TextBox).Text;
            app.Factory = (formView.FindControl("tbFactory") as TextBox).Text;
            app.FixedSN = (formView.FindControl("tbFixedSN") as TextBox).Text;

            string productDateString = (formView.FindControl("tbProductDate") as TextBox).Text;
            DateTime productDate = new DateTime();
            DateTime.TryParse(productDateString, out productDate);
            if (productDate.Year > 2000)
                app.ProductDate = productDate;

            app.OwnerDepName = (formView.FindControl("ddlCorp") as DropDownList).SelectedItem.Text;
            app.AssetSN = (formView.FindControl("tbAssetSN") as TextBox).Text;
            app.Address = (formView.FindControl("tbAddress") as TextBox).Text;

            string installDateString = (formView.FindControl("tbInstallationDate") as TextBox).Text;
            DateTime installDate = new DateTime();
            DateTime.TryParse(installDateString, out installDate);
            if (installDate.Year > 2000)
                app.InstallationDate = installDate;

            CheckBox cbIsUsing = formView.FindControl("cbIsUsing") as CheckBox;
            app.IsUsing = cbIsUsing.Checked;

            string scrapDateString = (formView.FindControl("tbScrapDate") as TextBox).Text;
            DateTime scrapDate = new DateTime();
            DateTime.TryParse(scrapDateString, out scrapDate);
            if (scrapDate.Year > 2000)
                app.ScrapDate = scrapDate;

            app.Remark = (formView.FindControl("tbRemark") as TextBox).Text;

            Tiyi.JD.SQLServerDAL.Appliance appNew = bllApp.CreateAppliance(app);

            hfAppId.Value = appNew.AppId.ToString();

            FormView1.ChangeMode(FormViewMode.ReadOnly);

        }

        if (e.CommandName == "UpdateApp")
        {
            FormView formView = sender as FormView;
            Guid appId = Guid.Empty;
            Guid.TryParse(hfAppId.Value, out appId);

            Tiyi.JD.SQLServerDAL.Appliance app = bllApp.GetAppliance(appId);
            app.BigClass = (formView.FindControl("tbBigClass") as TextBox).Text;
            app.AppType = (formView.FindControl("tbAppType") as TextBox).Text;
            app.Model = (formView.FindControl("tbModel") as TextBox).Text;
            app.PowerCold = (formView.FindControl("tbPowerCold") as TextBox).Text;
            app.PowerHot = (formView.FindControl("tbPowerHot") as TextBox).Text;
            app.Power = (formView.FindControl("tbPower") as TextBox).Text;
            app.Factory = (formView.FindControl("tbFactory") as TextBox).Text;
            app.FixedSN = (formView.FindControl("tbFixedSN") as TextBox).Text;

            string productDateString = (formView.FindControl("tbProductDate") as TextBox).Text;
            DateTime productDate = new DateTime();
            DateTime.TryParse(productDateString, out productDate);
            if (productDate.Year > 2000)
                app.ProductDate = productDate;

            app.OwnerDepName = (formView.FindControl("tbOwnerDepName") as TextBox).Text;
            app.AssetSN = (formView.FindControl("tbAssetSN") as TextBox).Text;
            app.Address = (formView.FindControl("tbAddress") as TextBox).Text;

            string installDateString = (formView.FindControl("tbInstallationDate") as TextBox).Text;
            DateTime installDate = new DateTime();
            DateTime.TryParse(installDateString, out installDate);
            if (installDate.Year > 2000)
                app.InstallationDate = installDate;

            string scrapDateString = (formView.FindControl("tbScrapDate") as TextBox).Text;
            DateTime scrapDate = new DateTime();
            DateTime.TryParse(scrapDateString, out scrapDate);
            if (scrapDate.Year > 2000)
                app.ScrapDate = scrapDate;

            app.Remark = (formView.FindControl("tbRemark") as TextBox).Text;

            bllApp.UpdateAppliance(app);

            FormView1.ChangeMode(FormViewMode.ReadOnly);

        }

        if (e.CommandName == "CancelUpdate")
        {
            FormView1.ChangeMode(FormViewMode.ReadOnly);
        }
    }

    protected void FormView1_DataBound(object sender, EventArgs e)
    {
        FormView fv = sender as FormView;
        if (fv.CurrentMode == FormViewMode.Insert)
        {
            DropDownList ddlCorp = fv.FindControl("ddlCorp") as DropDownList;

            var corps = bll_corp.GetCorporation();
            ddlCorp.Items.Clear();
            foreach (Tiyi.JD.SQLServerDAL.Corporation corp in corps)
            {
                ListItem item = new ListItem(corp.CorpName, corp.CorpId.ToString());
                ddlCorp.Items.Add(item);
            }
            ddlCorp.Items.Insert(0, "请选择设备所在单位");
        }
    }
}