using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Tiyi.JD.BLL.RepairmanManage bll_wxg = new Tiyi.JD.BLL.RepairmanManage();
    Tiyi.JD.BLL.ApplianceManage bll_app = new Tiyi.JD.BLL.ApplianceManage();
    Tiyi.JD.BLL.BaoxiuManage bll_baoxiu = new Tiyi.JD.BLL.BaoxiuManage();
    Tiyi.JD.BLL.PaigongManage bll_Paigong = new Tiyi.JD.BLL.PaigongManage();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        Load_CountForApp();     // 设备总数
        Load_CountForWxg();     // 维修工总数
        Load_CountForBaoxiuBill();      // 获取报修单统计数据
        Load_CountForPgdBill();     //获取派工单统计数据
    }

    private void Load_CountForPgdBill()
    {
        ltlCount_Pgd_IsNotAccept.Text = bll_Paigong.GetCount(false, false).ToString();
        ltlCount_Pgd_IsAccept.Text = bll_Paigong.GetCount(true, false).ToString();
    }

    private void Load_CountForBaoxiuBill()
    {
        ltlCount_Bxd_IsNotAccept.Text = bll_baoxiu.GetCount(false, false).ToString();
        ltlCount_Bxd_IsAccept.Text = bll_baoxiu.GetCount(true, false).ToString();
    }

    /// <summary>
    /// 加载设备总数
    /// </summary>
    private void Load_CountForApp()
    {
        ltlCount_ForDevice.Text = bll_app.GetCount_Appliance().ToString();
    }

    /// <summary>
    /// 加载维修工总数
    /// </summary>
    private void Load_CountForWxg()
    {
        ltlCount_ForWxg.Text = bll_wxg.GetRepairmanSum().ToString();
    }
}