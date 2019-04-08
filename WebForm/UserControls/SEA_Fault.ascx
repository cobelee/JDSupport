<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SEA_Fault.ascx.cs"
    Inherits="UserControls_SEA_Fault" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:HiddenField ID="hfFaultId" runat="server" />
<asp:FormView ID="formView" runat="server" CaptionAlign="Left" Width="100%"
    DataSourceID="ods1" OnItemInserting="View_ItemInserting" OnItemCommand="formView_ItemCommand"
    OnDataBound="formView_DataBound" DefaultMode="Insert">
    <EditItemTemplate>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">故障描述</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbFaultText" runat="server" class="form-control" placeholder="故障描述" Text='<%# Eval("FaultText") %>'></asp:TextBox>
                    <span class="help-block">用户能观察到的设备故障现象描述</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">设备大类</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbBigClass" runat="server" class="form-control" placeholder="设备大类" Text='<%# Eval("BigClass") %>'></asp:TextBox>
                    <span class="help-block">系统中定义的设备大类，如空调</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input"></label>
                <div class="col-md-9">
                    <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CssClass="btn btn-sm btn-success"
                        CommandName="UpdateFault" Text="更新" />
                    &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False"
                        CssClass="btn btn-sm btn-success" CommandName="CancelUpdate" Text="取消" />
                </div>
            </div>
        </div>
    </EditItemTemplate>
    <InsertItemTemplate>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">故障描述</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbFaultText" runat="server" class="form-control" placeholder="故障描述" Text='<%# Eval("FaultText") %>'></asp:TextBox>
                    <span class="help-block">用户能观察到的设备故障现象描述</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">设备大类</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbBigClass" runat="server" class="form-control" placeholder="设备大类" Text='<%# Eval("BigClass") %>'></asp:TextBox>
                    <span class="help-block">系统中定义的设备大类，如空调</span>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input"></label>
                <div class="col-md-9">
                    <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="InsertFault"
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
                <label class="col-md-3 control-label" for="text-input">故障描述</label>
                <div class="col-md-9">
                    <p class="form-control-static"><%# Eval("FaultText") %></p>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input">设备大类</label>
                <div class="col-md-9">
                    <p class="form-control-static"><%# Eval("BigClass") %></p>
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-md-3 control-label" for="text-input"></label>
                <div class="col-md-9">
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="编辑" CssClass="btn btn-sm btn-success" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="DeleteFaultoration"
                        Text="删除" CssClass="btn btn-sm btn-success" />
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetFaultById" TypeName="Tiyi.JD.BLL.FaultManage">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfFaultId" Name="FaultId" PropertyName="Value"
            DbType="Guid" />
    </SelectParameters>
</asp:ObjectDataSource>
