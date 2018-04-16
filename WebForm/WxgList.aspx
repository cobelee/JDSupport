<%@ Page Title="创建维修工" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WxgList.aspx.cs" Inherits="WxgList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-cogs"></i><a href="WxgList.aspx">系统配置</a></li>
                <li><i class="fa  fa-group"></i>维修工管理</li>
            </ol>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>维修工管理</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-setting"><i class="fa fa-rotate-right"></i></a>
                        <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <div class=" btn-toolbar ">
                        <a href="WxgDetail.aspx" class="btn btn-default">创建新维修工</a>
                    </div>
                    <asp:Repeater ID="rptApp" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable">
                                <thead>
                                    <tr>
                                        <th>工号</th>
                                        <th>姓名</th>
                                        <th>手机号码</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("JobNumber") %></td>
                                <td><%# Eval("RealName") %></td>
                                <td><%# Eval("MobilePhone") %></td>
                                <td><a class="btn btn-success" href='<%# "WxgDetail.aspx?id=" + Eval("WxgId").ToString() + "&mode=ReadOnly" %>'>
                                    <i class="fa fa-list"></i>
                                </a>
                                    <a class="btn btn-info"href='<%# "WxgDetail.aspx?id=" + Eval("WxgId").ToString() + "&mode=Edit" %>'>
                                        <i class="fa fa-edit "></i>
                                    </a>
                                    <a class="btn btn-danger" href="table.html#">
                                        <i class="fa fa-trash-o "></i>

                                    </a></td>
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
    <script src="assets/js/pages/form-elements.js"></script>
</asp:Content>

