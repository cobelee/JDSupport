<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BxdList.aspx.cs" Inherits="AD_BxdList" %>

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
        <div style="margin:10px;">
            <div class="row">

                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2><i class="fa fa-table red"></i><span class="break"></span><strong>用户报修进度跟踪</strong></h2>
                            <div class="panel-actions">
                                <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                                <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                            </div>
                        </div>

                        <div class="panel-body">
                            <asp:Repeater ID="rptBxd" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>#
                                                </th>
                                                <th style="width: 200px;">申请时间</th>
                                                <th>设备</th>
                                                <th>所在地址</th>
                                                <th>故障现象</th>
                                           
                                                <%--  <th>派工</th>--%>
                                                <th>状态</th>
                                          
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Container.ItemIndex+1 %>'></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Literal></td>
                                      
                                        <td>
                                            [<asp:Literal ID="ltlProductSN" runat="server" Text='<%# Eval("ProductSN") %>'></asp:Literal>]&nbsp;
                                            <asp:Literal ID="ltlBigClass" runat="server" Text='<%# Eval("BigClass") %>'></asp:Literal>-
                                    <asp:Literal ID="ltlAppType" runat="server" Text='<%# Eval("AppType") %>'></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlDepName" runat="server" Text='<%# Eval("DepName") %>'></asp:Literal>
                                            <asp:Literal ID="ltlAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="ltlFaultPhenomenon" runat="server" Text='<%# Eval("FaultPhenomenon") %>'></asp:Literal></td>
                                      
                                        <%--                                <td>
                                    <span class="label label-success">
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# GetIsPaidang(Eval("BxId").ToString()) ? "已派单" : "" %>'></asp:Literal></span>
                                </td>--%>
                                        <td>
                                            <span class="label label-success">
                                                <asp:Literal ID="ltlBillStatus" runat="server" Text='<%# Eval("BillStatus")%>'></asp:Literal></span>
                                        </td>
                                      
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                    </table>
                                </FooterTemplate>
                            </asp:Repeater>



                        </div>
                    </div>
                </div>
                <!--/col-->

            </div>
            <!--/row-->
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


