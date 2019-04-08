<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WbLogList_OneApp.aspx.cs" Inherits="WbLogList_OneApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfAppId" runat="server" />
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-cogs"></i><a href="BxdList.aspx">设备维修管理</a></li>
                <li><i class="fa  fa-group"></i>设备报修单</li>
            </ol>
        </div>
    </div>

    <div class="row">

        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>设备报修历史</strong></h2>
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
                                        <th style="width: 200px;">维保时间</th>
                                        <th style="width: 100px;">设备管理号</th>
                                        <th>设备</th>
                                        <th>维保内容</th>
                                        <th>备注信息</th>
                                        <th>维保人</th>
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
                                    <asp:Literal ID="ltlCreateDate" runat="server" Text='<%# Eval("WbDate") %>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlProductSN" runat="server" Text='<%# Eval("ProductSN") %>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlBigClass" runat="server" Text='<%# Eval("BigClass") %>'></asp:Literal>-
                                    <asp:Literal ID="ltlAppType" runat="server" Text='<%# Eval("AppType") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlDepName" runat="server" Text='<%# Eval("WbContent") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlFaultPhenomenon" runat="server" Text='<%# Eval("Remark") %>'></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="ltlUserName" runat="server" Text='<%# Eval("WbRealName") %>'></asp:Literal>
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

