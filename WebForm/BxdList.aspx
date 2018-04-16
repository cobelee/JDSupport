<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BxdList.aspx.cs" Inherits="BxdList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-cogs"></i><a href="BxdList.aspx">报修单列表</a></li>
                <li><i class="fa  fa-group"></i>设备报修单</li>
            </ol>
        </div>
    </div>

    <div class="row">

        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>设备报修单</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-setting"><i class="fa fa-rotate-right"></i></a>
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
                                        <th style="width: 100px;">设备管理号</th>
                                        <th>设备</th>
                                        <th>所在地址</th>
                                        <th>故障现象</th>
                                        <th>联系人</th>
                                        <th>派工状态</th>
                                        <td>操作</td>
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
                                    <asp:Literal ID="ltlProductSN" runat="server" Text='<%# Eval("ProductSN") %>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlBigClass" runat="server" Text='<%# Eval("BigClass") %>'></asp:Literal>-
                                    <asp:Literal ID="ltlAppType" runat="server" Text='<%# Eval("AppType") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlDepName" runat="server" Text='<%# Eval("DepName") %>'></asp:Literal>
                                    <asp:Literal ID="ltlAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlFaultPhenomenon" runat="server" Text='<%# Eval("FaultPhenomenon") %>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Literal>
                                    <asp:Literal ID="ltlUserMobilePhone" runat="server" Text='<%# Eval("UserMobilePhone") %>'></asp:Literal>
                                </td>
                                <td>
                                    <span class="label label-success">
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# GetIsPaidang(Eval("BxId").ToString()) ? "已派单" : "" %>'></asp:Literal></span>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <asp:HyperLink ID="btnAccept" runat="server" CssClass="btn btn-primary btn-sm" Text="受理" NavigateUrl='<%# "Bxd_WorkOrder.aspx?id=" + Eval("BxId") %>'></asp:HyperLink>
                                        <button type="button" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown">
                                            <span class="caret"></span>
                                            <span class="sr-only">Toggle Dropdown</span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Bxd_Cancel.aspx?id=" + Eval("BxId") %>'>取消维修单</asp:HyperLink></li>
                                        </ul>
                                    </div>
                                    <!-- /btn-group -->
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
</asp:Content>

