<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SEA_Corporation.ascx.cs"
    Inherits="UserControls_SEA_Corporation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:HiddenField ID="hfCorpId" runat="server" />
<asp:FormView ID="formView" runat="server" CaptionAlign="Left" Width="100%"
    DataSourceID="ods1" OnItemInserting="View_ItemInserting" OnItemCommand="formView_ItemCommand"
    OnDataBound="formView_DataBound" DefaultMode="Insert">
    <EditItemTemplate>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">公司名称</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbCorpName" runat="server" class="form-control" placeholder="公司名称" Text='<%# Eval("CorpName") %>'></asp:TextBox>
                    <span class="help-block">公司名称，指设备所属单位</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">联系人姓名</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbLinkmanName" runat="server" class="form-control" placeholder="联系人姓名" Text='<%# Eval("LinkmanName") %>'></asp:TextBox>
                    <span class="help-block">各公司设备管理联系人姓名</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">电话</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbTelephone" runat="server" class="form-control" placeholder="桌面固定电话号码" Text='<%# Eval("Telephone") %>'></asp:TextBox>
                    <span class="help-block">桌面固定电话号码。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">手机号码</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbMobilePhone" runat="server" class="form-control" placeholder="手机号码" Text='<%# Eval("MobilePhone") %>'></asp:TextBox>
                    <span class="help-block">用于接收各类短信信息。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">炼化短号</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbMobileShort" runat="server" class="form-control" placeholder="炼化短号" Text='<%# Eval("MobileShort") %>'></asp:TextBox>
                    <span class="help-block">用于日常业务联系。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">Email</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="炼化短号" Text='<%# Eval("Email") %>'></asp:TextBox>
                    <span class="help-block">用于接收系统报告。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input"></label>
                <div class="col-md-9">
                    <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CssClass="btn btn-sm btn-success"
                        CommandName="UpdateCorp" Text="更新" />
                    &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False"
                        CssClass="btn btn-sm btn-success" CommandName="CancelUpdate" Text="取消" />
                </div>
            </div>
        </div>
    </EditItemTemplate>
    <InsertItemTemplate>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">公司名称</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbCorpName" runat="server" class="form-control" placeholder="公司名称" Text='<%# Eval("CorpName") %>'></asp:TextBox>
                    <span class="help-block">公司名称，指设备所属单位</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">联系人姓名</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbLinkmanName" runat="server" class="form-control" placeholder="联系人姓名" Text='<%# Eval("LinkmanName") %>'></asp:TextBox>
                    <span class="help-block">各公司设备管理联系人姓名</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">电话</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbTelephone" runat="server" class="form-control" placeholder="桌面固定电话号码" Text='<%# Eval("Telephone") %>'></asp:TextBox>
                    <span class="help-block">桌面固定电话号码。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">手机号码</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbMobilePhone" runat="server" class="form-control" placeholder="手机号码" Text='<%# Eval("MobilePhone") %>'></asp:TextBox>
                    <span class="help-block">用于接收各类短信信息。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">炼化短号</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbMobileShort" runat="server" class="form-control" placeholder="炼化短号" Text='<%# Eval("MobileShort") %>'></asp:TextBox>
                    <span class="help-block">用于日常业务联系。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">Email</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="炼化短号" Text='<%# Eval("Email") %>'></asp:TextBox>
                    <span class="help-block">用于接收系统报告。</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input"></label>
                <div class="col-md-9">
                    <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="InsertCorp"
                        Text="添加" CssClass="btn btn-sm btn-success" />
                    &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False"
                        CommandName="CancelInsert" Text="取消" CssClass="btn btn-sm btn-success" />
                </div>
            </div>
        </div>
    </InsertItemTemplate>
    <InsertRowStyle Width="400px" />
    <ItemTemplate>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">公司名称</label>
                <div class="col-md-9">
                    <p class="form-control-static"><%# Eval("CorpName") %></p>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">联系人姓名</label>
                <div class="col-md-9">
                    <p class="form-control-static"><%# Eval("LinkmanName") %></p>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">手机号码</label>
                <div class="col-md-9">

                    <p class="form-control-static"><%# Eval("MobilePhone") %></p>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">炼化短号</label>
                <div class="col-md-9">

                    <p class="form-control-static"><%# Eval("MobileShort") %></p>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input"></label>
                <div class="col-md-9">
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CssClass="btn btn-sm btn-success" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="DeleteCorporation"
                        Text="删除" CssClass="btn btn-sm btn-success" />
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetCorporationById" TypeName="Tiyi.JD.BLL.CorpManage">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfCorpId" Name="CorpId" PropertyName="Value"
            DbType="Guid" />
    </SelectParameters>
</asp:ObjectDataSource>
