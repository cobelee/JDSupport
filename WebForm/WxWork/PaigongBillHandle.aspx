<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaigongBillHandle.aspx.cs" Inherits="WxWork_PaigongBillHandle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- meta使用viewport以确保页面可自由缩放 -->
    <meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1, user-scalable=no" />
    <!-- 引入 jQuery 库 -->
    <script src="http://apps.bdimg.com/libs/jquery/1.10.2/jquery.min.js"></script>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/jquery.mmenu.css" rel="stylesheet" />
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/plugins/jquery-ui/css/jquery-ui-1.10.4.min.css" rel="stylesheet" />
    <link href="../assets/plugins/chosen/css/chosen.css" rel="stylesheet" />
    <link href="../assets/css/style.min.css" rel="stylesheet" />
    <link href="../assets/css/add-ons.min.css" rel="stylesheet" />
    <title>处理派工单</title>
</head>
<body style="background-color: white;">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfPgId" runat="server" />
        <asp:HiddenField ID="hfBxId" runat="server" />

        <div class="panel-body">
            <h2>处理派工单</h2>
            <asp:MultiView ID="mvInfo" runat="server" ActiveViewIndex="0">
                <asp:View ID="ViewNotAccept" runat="server">
                    <div class="alert alert-info">
                        <h4 class="alert-heading">未接单!</h4>
                        <p>
                            报障时间：<asp:Literal ID="ltlBaoxiuDate" runat="server"></asp:Literal><br />
                            派工时间：<asp:Literal ID="ltlCreateDate" runat="server"></asp:Literal><br />
                            请尽快接单。<br />
                        </p>
                    </div>
                </asp:View>
                <asp:View ID="ViewHasAccept" runat="server">
                    <div class="alert alert-warning">
                        <h4 class="alert-heading">已接单!</h4>
                        <p>
                            报障时间：<asp:Literal ID="ltlBaoxiuDate2" runat="server"></asp:Literal><br />
                            派工时间：<asp:Literal ID="ltlCreateDate2" runat="server"></asp:Literal><br />
                            接单时间：<asp:Literal ID="ltlAcceptDate" runat="server"></asp:Literal><br />
                            请尽快安排上门维修
                        </p>
                    </div>
                </asp:View>
            </asp:MultiView>

            <ul class="list-group">
                <li class="list-group-item">设备管理号：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlProductSN" runat="server"></asp:Literal></span>
                </li>
                <li class="list-group-item">设备出厂编号：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlFixedSN" runat="server"></asp:Literal></span>
                </li>
                <li class="list-group-item">设备类型：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlAppType" runat="server"></asp:Literal>
            </span>
                </li>
                <li class="list-group-item">设备型号：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlModel" runat="server"></asp:Literal>
            </span>
                </li>
                <li class="list-group-item">出厂日期：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlProductDate" runat="server"></asp:Literal>
            </span>
                </li>
                <li class="list-group-item">安装日期：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlInstallDate" runat="server"></asp:Literal>
            </span></li>
                <li class="list-group-item">安装地址：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlAddress" runat="server"></asp:Literal>
            </span></li>
                <li class="list-group-item">反映故障：
            <span class="list-group-item-text" style="float: right;"><b>
                <asp:Literal ID="ltlFaultPhenomenon" runat="server"></asp:Literal></b>
            </span>
                </li>
                <li class="list-group-item">联系人：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlUser" runat="server"></asp:Literal>
            </span>
                </li>
                <li class="list-group-item">备注信息：
            <span class="list-group-item-text" style="float: right;">
                <asp:Literal ID="ltlRemark" runat="server"></asp:Literal>
            </span>
                </li>
            </ul>
            <div class="btn-group center">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewJiedan" runat="server">
                        <asp:Button ID="btnAccept" runat="server" Text="接单修理" CssClass="btn btn-primary" role="button"
                            CommandName="Accept" OnCommand="CommandButton_Click" OnClientClick='return confirm("确定要接单吗？")' />
                    </asp:View>
                    <asp:View ID="ViewComplete" runat="server">
                        <asp:Button ID="btnComplete" runat="server" Text="修理完毕" CssClass="btn btn-primary" role="button" CommandName="ToComplete" OnCommand="CommandButton_Click" />
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>

    </form>
</body>
</html>
