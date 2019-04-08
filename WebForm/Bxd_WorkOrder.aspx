<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bxd_WorkOrder.aspx.cs" Inherits="Bxd_WorkOrder" %>

<%@ Register TagPrefix="user" TagName="SEA_Paigong" Src="~/UserControls/SEA_Paigong.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfBxId" runat="server" />
    <asp:HiddenField ID="hfAppId" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i>派工</h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-cogs"></i><a href="BxdList.aspx">设备维修管理</a></li>
                <li><i class="fa  fa-group"></i>派工</li>
            </ol>
        </div>
    </div>

    <div class="row profile">

        <div class="col-md-5">

            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row text-center">
                        <div class="col-xs-4">
                            <div>
                                <strong>
                                    <asp:Literal ID="ltlInstallationDate" runat="server"></asp:Literal></strong>
                            </div>
                            <div><small>安装日期</small></div>
                        </div>
                        <!--/.col-->
                        <div class="col-xs-4">
                            <div><strong>3？</strong></div>
                            <div><small>已维修</small></div>
                        </div>
                        <!--/.col-->
                        <div class="col-xs-4">
                            <div><strong>1024天？</strong></div>
                            <div><small>已运行</small></div>
                        </div>
                        <!--/.col-->
                    </div>
                    <!--/.row-->

                    <hr>

                    <h4><strong>设备信息</strong></h4>

                    <ul class="profile-details">
                        <li>
                            <div><i class="fa fa-thumbs-up"></i>设备管理号</div>
                            <asp:Literal ID="ltlProductSN" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-building-o"></i>设备</div>
                            <asp:Literal ID="ltlApp" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-building-o"></i>型号</div>
                            <asp:Literal ID="ltlModel" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-building-o"></i>制造商</div>
                            <asp:Literal ID="ltlFactory" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-building-o"></i>厂方设备编号</div>
                            <asp:Literal ID="ltlFixedSN" runat="server"></asp:Literal>
                        </li>
                    </ul>

                    <hr>

                    <h4><strong>联系信息</strong></h4>

                    <ul class="profile-details">
                        <li>
                            <div><i class="fa fa-phone"></i>联系人</div>
                            <asp:Literal ID="ltlUserName" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-tablet"></i>手机号码</div>
                            <asp:Literal ID="ltlUserMobilePhone" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-envelope"></i>短号</div>
                            <asp:Literal ID="ltlUserMobileShort" runat="server"></asp:Literal>
                        </li>
                        <li>
                            <div><i class="fa fa-map-marker"></i>安装地址</div>
                            <asp:Literal ID="ltlDepName" runat="server"></asp:Literal><br />
                            <asp:Literal ID="ltlAddress" runat="server"></asp:Literal><br />
                        </li>
                        <li>
                            <div><i class="fa fa-map-marker"></i>备注信息</div>
                            <asp:Literal ID="ltlRemark" runat="server"></asp:Literal><br />
                        </li>
                    </ul>

                </div>

            </div>

        </div>
        <!--/.col-->

        <div class="col-md-7">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-heart-o red"></i><strong>派工</strong></h2>
                </div>
                <div class="panel-body">
                    <user:SEA_Paigong ID="SEA_Paigong1" runat="server" />
                </div>
            </div>


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-heart-o red"></i><strong>维修工状态</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:Repeater ID="rptWxg" runat="server" OnItemDataBound="rptWxg_ItemDataBound">
                        <HeaderTemplate>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>姓名</th>
                                        <th>工号</th>
                                        <th>手机号码</th>
                                        <th>接单数</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("RealName") %></td>
                                <td><%# Eval("JobNumber") %></td>
                                <td><%# Eval("MobilePhone") %></td>
                                <td>
                                    <asp:Literal ID="ltlCountOf_AB" runat="server" Text="0"></asp:Literal></td>
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
        <!--/.col-->

    </div>
    <!--/.row profile-->
</asp:Content>

