<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WeibaoReg.aspx.cs" Inherits="WxWork_WeibaoReg" %>

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
    <title>设备维保登记</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfJobNumber" runat="server" />
        <asp:HiddenField ID="hfIsRepaireman" runat="server" Value="False" />
        <div class="panel panel-default">
            <%--            <div class="panel-heading">
                <i class="fa fa-indent red"></i>&nbsp;<strong>设备维保登记</strong>
            </div>--%>
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewInput" runat="server">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <p>设备管理号：设备上贴的二维码标签上面的4位数字</p>
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="btn btn-primary"><i class="fa fa-search"></i>&nbsp;Search</button>

                                        </span>
                                        <asp:TextBox ID="tbProductSN" runat="server" class="form-control" placeholder="设备管理号"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSearch" runat="server" Text="查找" type="button" class="btn btn-success" OnClick="btnSearch_Click" />
                                        </span>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="1">
                            <asp:View ID="view1" runat="server">
                                <div class="row header">
                                    <div class="col-sm-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                设备详情
                                            </div>
                                            <div class="panel-body">
                                                <p>
                                                    设备管理号:<strong><asp:Literal ID="ltlProductSN" runat="server"></asp:Literal>
                                                    </strong>
                                                </p>
                                                <p>
                                                    设备类型: <strong>
                                                        <asp:Literal ID="ltlAppType" runat="server"></asp:Literal></strong>
                                                </p>
                                                <p>
                                                    安装地址: <strong>
                                                        <asp:Literal ID="ltlAddress" runat="server"></asp:Literal></strong>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <!--/col-->

                                </div>
                                <!--/row-->


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                维保登记
                                            </div>
                                            <div class="panel-body">
                                                <div class="form-horizontal ">
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label" for="textarea-input">备注信息</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="tbRemark" runat="server" TextMode="MultiLine" Rows="2" Text="维保完成" placeholder="维保内容" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-md-3 control-label" for="textarea-input">维保人：<asp:Literal ID="ltlWbRealName" runat="server" Text=""></asp:Literal></label>
                                                        <div class="col-md-3">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-footer">
                                                <asp:Button ID="btnSave" runat="server" Text="保存维保信息" class="btn btn-sm btn-success" OnClick="btnSave_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--/.row-->
                            </asp:View>
                            <asp:View ID="viewNotFound" runat="server">
                                <div class="text-center">
                                    <h1><i class="fa   fa-search-minus" style="font-size: 3em; color: #cecece;"></i></h1>
                                    <h2>未找到设备</h2>
                                    <p>要输入新的设备管理号，继续查找</p>
                                </div>
                            </asp:View>
                        </asp:MultiView>



                    </asp:View>
                    <asp:View ID="viewResult" runat="server">
                        <div class="text-center">
                            <h1><i class="fa  fa-check-circle-o" style="font-size: 3em; color: limegreen;"></i></h1>
                            <h2>完成</h2>
                            <p>要维保下一台设备，请点击继续.</p>
                            <a href="#">
                                <asp:Button ID="btnContinue" runat="server" Text="&nbsp;&nbsp;继续&nbsp;&nbsp;" CssClass="btn btn-default" OnClick="btnContinue_Click" />
                            </a>
                        </div>
                    </asp:View>
                    <asp:View ID="viewNotMaintainer" runat="server">
                        <div class="text-center">
                            <h1><i class="fa  fa-exclamation-circle" style="font-size: 3em; color: crimson;"></i></h1>
                            <h2>错误</h2>
                            <p>您不是维保技术人员，无法录入维保信息.</p>
                            <a href="#">
                                <asp:Button ID="Button1" runat="server" Text="&nbsp;&nbsp;继续&nbsp;&nbsp;" CssClass="btn btn-default" OnClick="btnContinue_Click" />
                            </a>
                        </div>
                    </asp:View>
                </asp:MultiView>

            </div>
        </div>


    </form>
</body>
</html>
