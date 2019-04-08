<%@ Page Title="数据批量导入" Language="C#" MasterPageFile="~/Shares/MasterPage2.master" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="Report_DataList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="../default.aspx">Home</a></li>
                <li><i class="fa fa-indent"></i><a href="DataList.aspx">报表管理</a></li>
                <li><i class="fa  fa-th-list"></i>设备保养报表</li>
            </ol>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>在用设备</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-setting"><i class="fa fa-rotate-right"></i></a>
                        <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="hfSearchMode" runat="server" Value="" />
                    <div class="col-md-1">
                        <asp:DropDownList ID="ddlCode" runat="server" class="form-control">
                            <asp:ListItem Text="设备管理号" Value="ProductSN"></asp:ListItem>
                            <asp:ListItem Text="厂方设备编号" Value="FixedSN"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <div class="input-group">
                            <asp:TextBox ID="tbQueryStr" runat="server" placeholder="查询字符串" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnQuery" runat="server" class="btn btn-default btn-success" Text="开始查询" OnClick="btnQuery_Click"></asp:Button>
                            </span>
                        </div>

                    </div>
                    <div class="col-md-2">
                        <div class="input-group">
                            <asp:DropDownList ID="ddlDepName" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:Button ID="btnQueryByDep" runat="server" class="btn btn-default btn-success" Text="开始查询" OnClick="btnQueryByDep_Click"></asp:Button>
                            </span>
                        </div>

                    </div>
                    <asp:Repeater ID="rptApp" runat="server">

                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable">
                                <thead>
                                    <tr>
                                        <th>设备管理号</th>
                                        <th>固定资产编号</th>
                                        <th>设备大类</th>
                                        <th>类型</th>
                                        <th>所属单位</th>
                                        <th>安装地址</th>
                                        <th>备注信息</th>
                                        <th>维保状态</th>
                                        <th>维保时间</th>
                                        <th>维保人</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ProductSN") %></td>
                                <td><%# Eval("AssetSN") %></td>
                                <td><%# Eval("BigClass") %></td>
                                <td><%# Eval("AppType") %></td>
                                <td><%# Eval("OwnerDepName") %></td>
                                <td><%# Eval("Address") %></td>
                                <td><%# Eval("Remark") %></td>
                                <td><%# Eval("WbContent") %></td>
                                <td><%# Eval("WbDate") %></td>
                                <td><%# Eval("WbRealName") %></td>
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


    <!-- inline scripts related to this page -->
    <script src="~/assets/js/pages/form-elements.js"></script>
</asp:Content>

