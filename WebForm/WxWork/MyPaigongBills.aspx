<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyPaigongBills.aspx.cs" Inherits="WxWork_MyPaigongBills" %>

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
    <title>我的派工单</title>
</head>
<body style="background-color: white;">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfJobNumber" runat="server" />
        <asp:HiddenField ID="hfWxgId" runat="server" />
        <div class="panel-body">
            <div class="panel-group" id="accordion">
                <asp:Repeater ID="rptPaigong" runat="server" OnItemDataBound="rptPaigong_ItemDataBound">
                    <HeaderTemplate>
                        <h3>我的派工单</h3>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href='<%# "ui-elements.html#collapse" + Container.ItemIndex.ToString() %>'>
                                        <%# Eval("BigClass") + " " + Eval("ProductSN")  %> <asp:Literal ID="ltlJiedanStatus" runat="server"></asp:Literal>
                                    </a>
                                </h4>
                            </div>
                            <div id='<%# "collapse" + Container.ItemIndex.ToString() %>' class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <ul class="list-group">
                                        <li class="list-group-item">设备管理号：
            <span class="list-group-item-text" style="float: right;"><%# Eval("ProductSN") %></span>
                                        </li>
                                        <li class="list-group-item">设备类型：
            <span class="list-group-item-text" style="float: right;"><%# Eval("BigClass").ToString() + Eval("AppType").ToString() %>
            </span>
                                        </li>
                                        <li class="list-group-item">安装地址：
            <span class="list-group-item-text" style="float: right;"><%# Eval("DepName").ToString() + Eval("Address").ToString() %>

            </span></li>
                                        <li class="list-group-item">反映故障：
            <span class="list-group-item-text" style="float: right;"><b><%# Eval("FaultPhenomenon") %></b>
            </span>
                                        </li>
                                        <li class="list-group-item">联系人：
            <span class="list-group-item-text" style="float: right;"><%# Eval("UserName").ToString() + " " + Eval("UserMobileShort") %>
            </span>
                                        </li>
                                        <li class="list-group-item">备注信息：
            <span class="list-group-item-text" style="float: right;"><%# Eval("Remark").ToString() %>
            </span>
                                        </li>
                                    </ul>
                                    <a href='<%# "PaigongBillHandle.aspx?pgid=" + Eval("PgId").ToString()  %>' class="btn btn-primary">处理派工单</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>

            </div>

        </div>
    </form>

    <!-- start: JavaScript-->
    <!--[if !IE]>-->

    <script src="assets/js/jquery-2.1.1.min.js"></script>

    <!--<![endif]-->

    <!--[if IE]>
	
		<script src="assets/js/jquery-1.11.1.min.js"></script>
	
	<![endif]-->

    <!--[if !IE]>-->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='../assets/js/jquery-2.1.1.min.js'>" + "<" + "/script>");
    </script>

    <!--<![endif]-->

    <!--[if IE]>
	
		<script type="text/javascript">
	 	window.jQuery || document.write("<script src='../assets/js/jquery-1.11.1.min.js'>"+"<"+"/script>");
		</script>
		
	<![endif]-->
    <script src="../assets/js/jquery-migrate-1.2.1.min.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>


    <!-- page scripts -->
    <script src="../assets/plugins/jquery-ui/js/jquery-ui-1.10.4.min.js"></script>
    <script src="../assets/plugins/raphael/raphael.min.js"></script>

    <!-- theme scripts -->
    <script src="../assets/js/SmoothScroll.js"></script>
    <script src="../assets/js/jquery.mmenu.min.js"></script>
    <script src="../assets/js/core.min.js"></script>

    <!-- inline scripts related to this page -->
    <script src="../assets/js/pages/ui-elements.js"></script>

    <!-- end: JavaScript-->
</body>
</html>
