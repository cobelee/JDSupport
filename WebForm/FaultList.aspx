<%@ Page Title="管理用户故障描述" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FaultList.aspx.cs" Inherits="FaultList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-cogs"></i><a href="WxgList.aspx">系统配置</a></li>
                <li><i class="fa  fa-group"></i>用户故障描述</li>
            </ol>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>配置用户故障描述</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-setting"><i class="fa fa-rotate-right"></i></a>
                        <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="alert alert-info">
                        <button type="button" class="close" data-dismiss="alert">×</button>
                        <strong>提示!</strong> 以下是系统预设的用户故障描述信息，当用户在手机上发起报修申请时，可以在申请页中直接选择设备故障现象，避免了手动输入。
                    </div>
                    <div class=" btn-toolbar ">
                        <a href="FaultDetail.aspx" class="btn btn-default">创建新故障描述</a>
                    </div>
                    <asp:Repeater ID="rptApp" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable">
                                <thead>
                                    <tr>
                                        <th style="width: 30px;">#</th>
                                        <th>用户故障描述</th>
                                        <th>设备大类</th>

                                        <th style="width: 200px;">操作</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Container.ItemIndex+1 %>'></asp:Literal>
                                </td>
                                <td><%# Eval("FaultText") %></td>
                                <td><%# Eval("BigClass") %></td>

                                <td><a class="btn btn-success" href='<%# "FaultDetail.aspx?id=" + Eval("FaultId").ToString() + "&mode=ReadOnly" %>'>
                                    <i class="fa fa-list"></i>
                                </a>
                                    <a class="btn btn-info" href='<%# "FaultDetail.aspx?id=" + Eval("FaultId").ToString() + "&mode=Edit" %>'>
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

