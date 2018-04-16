using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/* ********************************************
 * 批量数据导入功能
 * 将需要导入的数据转换成CVS文件，按行导入数据到数据库
 * 
 * */
public partial class DataBatchImport : System.Web.UI.Page
{
    Tiyi.JD.BLL.ApplianceManage bllApp = new Tiyi.JD.BLL.ApplianceManage();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        System.Web.HttpPostedFile file = fileUpload1.PostedFile;
        System.IO.Stream stream = file.InputStream;
        System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.Default);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string line = string.Empty;
        int lineNumber = 0;
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();

            lineNumber++;
            if (lineNumber == 1)
                continue;

            string[] arrayLine;
            arrayLine = line.Split(',');
            if (arrayLine == null || arrayLine.Count() < 2)
                continue;

            Tiyi.JD.SQLServerDAL.Appliance app = ConvertToEntity(arrayLine);
            bllApp.CreateApplianceNotSubmit(app);

            sb.AppendLine(line);
        }
        bllApp.SubmitChanges();

        Label1.Text = (lineNumber - 1).ToString();

    }

    /// <summary>
    /// 将数组转化为设备实体类。
    /// </summary>
    /// <param name="arrayLine"></param>
    /// <returns></returns>
    private Tiyi.JD.SQLServerDAL.Appliance ConvertToEntity(string[] arrayLine)
    {
        if (arrayLine == null || arrayLine.Count() < 17)
            return null;

        Tiyi.JD.SQLServerDAL.Appliance app = new Tiyi.JD.SQLServerDAL.Appliance();
        app.OwnerDepName = arrayLine[0];
        app.Address = arrayLine[1];
        app.AssetSN = arrayLine[2];
        app.BigClass = arrayLine[3];
        app.AppName = arrayLine[3];
        app.AppType = arrayLine[4];
        app.Model = arrayLine[5];
        app.PowerCold = arrayLine[6];
        app.PowerHot = arrayLine[7];
        app.Power = arrayLine[8];
        app.Factory = arrayLine[9];
        app.FixedSN = arrayLine[10];
        app.ProductSN = arrayLine[11];

        DateTime productDate;
        bool productDateResult = DateTime.TryParse(arrayLine[12], out productDate);
        if (productDateResult)
            app.ProductDate = productDate;

        DateTime installDate;
        bool installDateResult = DateTime.TryParse(arrayLine[13], out installDate);
        if (installDateResult)
            app.InstallationDate = installDate;

        app.IsScrapped = false;
        app.IsUsing = true;
        app.Remark = arrayLine[16];

        return app;
    }
}