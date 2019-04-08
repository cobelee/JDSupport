<%@ Page Title="客户公司详情" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CorpDetail.aspx.cs" Inherits="CorpDetail" %>

<%@ Register TagPrefix="user" TagName="SEA_Corporation" Src="~/UserControls/SEA_Corporation.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-cogs"></i><a href="WxgList.aspx">系统配置</a></li>
                <li><i class="fa  fa-group"></i>客户公司详情</li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>设备客户公司及各公司业务联系人</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-setting"><i class="fa fa-rotate-right"></i></a>
                        <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="hfCorpId" runat="server" />

                    <user:SEA_Corporation ID="SEA_Corporation1" runat="server" />

                </div>
                <div class="panel-footer">
                    <a href="CorpList.aspx" class="btn btn-default"><< 返回客户公司列表</a>
                </div>
            </div>
        </div>
        <!--/col-->

    </div>
    <!--/row-->


    <!-- inline scripts related to this page -->
    <script src="assets/js/pages/form-elements.js"></script>
</asp:Content>

