<%@ Page Title="数据批量导入" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataDetail.aspx.cs" Inherits="DataDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-laptop"></i></h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                <li><i class="fa fa-indent"></i><a href="DataList.aspx">在用设备管理</a></li>
                <li><i class="fa  fa-th-list"></i>设备详情</li>
            </ol>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2><i class="fa fa-table red"></i><span class="break"></span><strong>设备详情</strong></h2>
                    <div class="panel-actions">
                        <a href="table.html#" class="btn-setting"><i class="fa fa-rotate-right"></i></a>
                        <a href="table.html#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                        <a href="table.html#" class="btn-close"><i class="fa fa-times"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:HiddenField ID="hfAppId" runat="server" />
                    <asp:FormView ID="FormView1" runat="server" RenderOuterTable="False" OnItemCommand="FormView1_ItemCommand" DataSourceID="odsApp">
                        <ItemTemplate>
                            <div class="form-horizontal ">
                                <div class="form-group">
                                    <label class="col-md-3 control-label">设备管理号</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("ProductSN") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">设备大类</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("BigClass") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">设备小类</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("AppType") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">型号规格</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("Model") %></p>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-3 control-label">制冷量(KW)</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("PowerCold") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">制热量(KW)</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("PowerHot") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">功率(KW)</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("Power") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">品牌</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("Factory") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">设备出厂编号</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("FixedSN") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">出厂日期</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("ProductDate") %></p>
                                    </div>
                                </div>

                                <hr />
                                <div class="form-group">
                                    <label class="col-md-3 control-label" style="color: cornflowerblue;">安装信息</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">设备所属单位</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("OwnerDepName") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">固定资产号</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("AssetSN") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">安装地址</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("Address") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">安装日期</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("InstallationDate") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">在用标记</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Convert.ToBoolean(Eval("ScrapDate")) ? "在用" : "未在用" %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">计划报废日期</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("ScrapDate") %></p>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group">
                                    <label class="col-md-3 control-label">备注信息</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Eval("Remark") %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label"></label>
                                    <div class="col-md-9">
                                        <p class="form-control-static">
                                            <asp:Button ID="btnEdit" runat="server" Text="修改设备信息" CssClass="btn btn-sm btn-success" CommandName="ToEdit" CommandArgument='<%# Eval("AppId") %>' />
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div class="form-horizontal ">
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">设备管理号</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbProductSN" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("ProductSN") %>'></asp:TextBox>
                                        <span class="help-block">设备管理号由家电服务部编制，用于设备的管理。</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">设备大类</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbBigClass" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("BigClass") %>'></asp:TextBox>
                                        <span class="help-block">若是空调设备，设备大类一律为“空调”，不作更改。</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">设备小类</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbAppType" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("AppType") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">型号规格</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbModel" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("Model") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">制冷量(KW)</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbPowerCold" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("PowerCold") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">制热量(KW)</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbPowerHot" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("PowerHot") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">功率(KW)</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbPower" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("Power") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">品牌</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbFactory" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("Factory") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">设备出厂编号</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbFixedSN" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("FixedSN") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">出厂日期</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbProductDate" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("ProductDate") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group">
                                    <label class="col-md-3 control-label" style="color: cornflowerblue;">安装信息</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">设备所属单位</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbOwnerDepName" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("OwnerDepName") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">固定资产号</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbAssetSN" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("AssetSN") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">安装地址</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbAddress" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("Address") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">安装日期</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbInstallationDate" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("InstallationDate") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">在用标记</label>
                                    <div class="col-md-9">
                                        <p class="form-control-static"><%# Convert.ToBoolean(Eval("ScrapDate")) ? "在用" : "未在用" %></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">计划报废日期</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbScrapDate" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("ScrapDate") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group">
                                    <label class="col-md-3 control-label" for="text-input">备注信息</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="tbRemark" runat="server" class="form-control" placeholder="Text"
                                            Text='<%# Eval("Remark") %>'></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group">
                                    <label class="col-md-3 control-label"></label>
                                    <div class="col-md-9">
                                        <p class="form-control-static">
                                            <asp:Button ID="btnUpdate" runat="server" Text="更新设备信息" CssClass="btn btn-sm btn-success" CommandName="UpdateApp" CommandArgument='<%# Eval("AppId") %>' />
                                            <asp:Button ID="btnCancel" runat="server" Text="取消更新" CssClass="btn btn-sm btn-info" CommandName="CancelUpdate" CommandArgument='<%# Eval("AppId") %>' />
                                        </p>
                                    </div>
                                </div>


                            </div>
                        </EditItemTemplate>
                    </asp:FormView>

                    <asp:ObjectDataSource ID="odsApp" runat="server" SelectMethod="GetAppliance" TypeName="Tiyi.JD.BLL.ApplianceManage">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfAppId" DbType="Guid" Name="appId" PropertyName="Value" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                </div>
                <div class="panel-footer">
                </div>
            </div>
        </div>
        <!--/col-->

    </div>
    <!--/row-->


    <!-- inline scripts related to this page -->
    <script src="assets/js/pages/form-elements.js"></script>
</asp:Content>

