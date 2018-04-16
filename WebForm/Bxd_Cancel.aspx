<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bxd_Cancel.aspx.cs" Inherits="Bxd_Cancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfBxdId" runat="server" Value="" />

    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-indent red"></i><strong>你确定要取消报修单吗？</strong></h2>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal ">
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                设备管理号
                            </label>
                            <div class="col-md-9">
                                <p class="form-control-static">
                                    <asp:Literal ID="ltlProductSN" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                设备
                            </label>
                            <div class="col-md-9">
                                <p class="form-control-static">
                                    <asp:Literal ID="ltlApp" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                所在地址
                            </label>
                            <div class="col-md-9">
                                <p class="form-control-static">
                                    <asp:Literal ID="ltlAddress" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                联系人
                            </label>
                            <div class="col-md-9">
                                <p class="form-control-static">
                                    <asp:Literal ID="ltlUserName" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                联系电话
                            </label>
                            <div class="col-md-9">
                                <p class="form-control-static">
                                    <asp:Literal ID="ltlUserMobilePhone" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="textarea-input">请输入取消原因</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="tbHandleResult" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="取消客户报修单的理由.."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnCancelBill" runat="server" Text="确定取消报修单" class="btn btn-sm btn-success" CommandName="CancelBill" OnCommand="CommandButton_Click" />
                    <asp:Button ID="btnGoBack1" runat="server" Text="返回前页" CssClass="btn btn-sm btn-info" CommandName="GoBack" OnCommand="CommandButton_Click" />
                </div>
            </div>
        </div>

        <!--/.col-->
    </div>
    <!--/.row-->
</asp:Content>

