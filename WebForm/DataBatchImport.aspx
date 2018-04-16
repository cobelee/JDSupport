<%@ Page Title="数据批量导入" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataBatchImport.aspx.cs" Inherits="DataBatchImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i>数据批量导入</h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-indent"></i><a href="DataBatchImport.aspx">设备数据录入</a></li>
                <li><i class="fa  fa-th-list"></i>数据批量导入</li>
            </ol>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-indent red"></i><strong>CVS数据文件样例</strong></h2>
                </div>
                <div class="panel-body">
                    CVS数据文件样例说明
                </div>
            </div>
        </div>
        <!--.col-->
    </div>
    <!--.row-->

    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-indent red"></i><strong>批量上传</strong></h2>
                </div>
                <div class="panel-body">

                    <p>请选择文件上传</p>
                    <div enctype="multipart/form-data" class="form-horizontal ">

                        <div class="form-group">
                            <label class="col-md-3 control-label" for="file-input">选择CVS文件</label>
                            <div class="col-md-9">
                                <asp:FileUpload ID="fileUpload1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnUpload" runat="server" Text="数据上传" CssClass="btn btn-sm btn-success" OnClick="btnUpload_Click"></asp:Button>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <%--<button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-ban"></i>Reset</button>--%>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-indent red"></i><strong>CVS数据文件样例</strong></h2>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="nf-email">Email</label>
                        <input type="email" id="nf-email" name="nf-email" class="form-control" placeholder="Email address">
                        <span class="help-block">Please enter your email</span>
                    </div>
                    <div class="form-group">
                        <label for="nf-password">Password</label>
                        <input type="password" id="nf-password" name="nf-password" class="form-control" placeholder="Password">
                        <span class="help-block">Please enter your password</span>
                    </div>
                </div>
                <div class="panel-footer">
                    <%--<button type="submit" class="btn btn-sm btn-success"><i class="fa fa-dot-circle-o"></i>Submit</button>
                    <button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-ban"></i>Reset</button>--%>
                </div>
            </div>


        </div>
        <!--/.col-->
    </div>
    <!--/.row-->

    <!-- inline scripts related to this page -->
    <script src="assets/js/pages/form-elements.js"></script>
</asp:Content>

