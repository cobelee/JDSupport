<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SEA_Paigong.ascx.cs"
    Inherits="UserControls_SEA_Paigong" %>
<asp:HiddenField ID="hfPgId" runat="server" />
<asp:HiddenField ID="hfBxId" runat="server" />
<asp:FormView ID="formView" runat="server" Caption="银行账户列表" CaptionAlign="Left" DataSourceID="odsAccount"
    OnItemInserting="AccountView_ItemInserting" OnItemUpdated="PaigongBillView_ItemUpdated"
    OnItemCommand="PaigongBillView_ItemCommand" RenderOuterTable="False" DefaultMode="ReadOnly" OnDataBound="formView_DataBound">
    <EditItemTemplate>
        <div class="form-horizontal" role="form">
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbUserName">用户姓名</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbUserName" runat="server" CssClass="form-control" placeholder="用户姓名"
                        Text='<%# Eval("UserName") %>'></asp:TextBox>
                    <span class="help-block">设备使用人，报修人姓名</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbUserMobilePhone">手机长号</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbUserMobilePhone" runat="server" CssClass="form-control" placeholder="手机长号"
                        Text='<%# Eval("UserMobilePhone") %>'></asp:TextBox>
                    <span class="help-block">设备使用人，报修人手机长号</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbUserMobileShort">手机短号</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbUserMobileShort" runat="server" CssClass="form-control" placeholder="手机短号"
                        Text='<%# Eval("UserMobileShort") %>'></asp:TextBox>
                    <span class="help-block">设备使用人，报修人手机短号</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbAddress">详细地址</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control" placeholder="设备所在的详细地址"
                        Text='<%# Eval("Address") %>'></asp:TextBox>
                    <span class="help-block">设备所在的详细地址</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbFaultPhenomenon">设备故障现象</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbFaultPhenomenon" runat="server" TextMode="MultiLine" Rows="4" class="form-control"
                        placeholder="设备故障现象描述" Text='<%# Eval("FaultPhenomenon") %>'></asp:TextBox>
                </div>
            </div>
            <hr />
            <div class="form-group">
                <label class="col-md-3 control-label" for="ddlWxg">指定维修工</label>
                <div class="col-md-9">
                    <asp:HiddenField ID="hfWxgId" runat="server" Value='<%# Eval("WxgId") %>' />
                    <asp:DropDownList ID="ddlWxg" runat="server" class="form-control" size="1"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbRemark">备注信息</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbRemark" runat="server" TextMode="MultiLine" Rows="4" class="form-control"
                        placeholder="派工单备注信息" Text='<%# Eval("Remark") %>'></asp:TextBox>
                </div>
            </div>
            <div class="form-group pull-right">
                <asp:Button ID="UpdateButton" runat="server" Text="保存派工单" CssClass="btn btn-primary" CommandName="UpdateBill" />
                <asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False"
                    CommandName="UpdateCancel" Text="取消" CssClass="btn btn-info" />
            </div>

        </div>
    </EditItemTemplate>
    <InsertItemTemplate>
        <div class="form-horizontal" role="form">
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbUserName">用户姓名</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbUserName" runat="server" CssClass="form-control" placeholder="用户姓名"></asp:TextBox>
                    <span class="help-block">设备使用人，报修人姓名</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbUserMobilePhone">手机长号</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbUserMobilePhone" runat="server" CssClass="form-control" placeholder="手机长号"></asp:TextBox>
                    <span class="help-block">设备使用人，报修人手机长号</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbUserMobileShort">手机短号</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbUserMobileShort" runat="server" CssClass="form-control" placeholder="手机短号"></asp:TextBox>
                    <span class="help-block">设备使用人，报修人手机短号</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbAddress">详细地址</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control" placeholder="设备所在的详细地址"></asp:TextBox>
                    <span class="help-block">设备所在的详细地址</span>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbFaultPhenomenon">设备故障现象</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbFaultPhenomenon" runat="server" TextMode="MultiLine" Rows="4" class="form-control" placeholder="设备故障现象描述"></asp:TextBox>
                </div>
            </div>
            <hr />
            <div class="form-group">
                <label class="col-md-3 control-label" for="ddlWxg">指定维修工</label>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlWxg" runat="server" class="form-control" size="1"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label" for="tbRemark">备注信息</label>
                <div class="col-md-9">
                    <asp:TextBox ID="tbRemark" runat="server" TextMode="MultiLine" Rows="4" class="form-control" placeholder="派工单备注信息"></asp:TextBox>
                </div>
            </div>
            <div class="form-group pull-right">
                <asp:Button ID="Button1" runat="server" Text="创建派工单" CssClass="btn btn-primary" CommandName="InsertBill" />
                <asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False"
                    CommandName="InsertCancel" Text="取消" CssClass="btn btn-info" />
            </div>

        </div>

    </InsertItemTemplate>
    <ItemTemplate>
        <div class="form-horizontal" role="form">
            <div class="form-group">

                <label class="col-md-3 control-label">用户姓名</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="tbUserRealName" runat="server" Text='<%# Eval("UserName") %>'></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">手机长号</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="TextBox1" runat="server" Text='<%# Eval("UserMobilePhone") %>'></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">手机短号</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("UserMobileShort") %>'></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">详细地址</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("Address") %>'></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">设备故障现象</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("FaultPhenomenon") %>'></asp:Literal>
                    </p>
                </div>
            </div>
            <hr />
            <div class="form-group">
                <label class="col-md-3 control-label">指定维修工</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("WxgRealName") %>'></asp:Literal>
                        <asp:HiddenField ID="hfWxgId" runat="server" Value='<%# Eval("WxgId") %>' />
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">备注信息</label>
                <div class="col-md-9">
                    <p>
                        <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Remark") %>'></asp:Literal>
                    </p>
                </div>
            </div>
            <div class="form-group pull-left">
                <asp:Button ID="Button2" runat="server" Text="提醒修理工接单" CssClass="btn btn-primary" CommandName="WxRemind" />&nbsp;&nbsp;
                <asp:Literal ID="ltlSendWxResult" runat="server"></asp:Literal>
            </div>
            <div class="form-group pull-right">
                <asp:Button ID="Button1" runat="server" Text="修改派工单" CssClass="btn btn-primary" CommandName="EditBill" />
            </div>

        </div>
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsAccount" runat="server" DataObjectTypeName="Tiyi.JD.SQLServerDAL.PaigongBill"
    InsertMethod="CreatePaigongBill" SelectMethod="GetPaigongBill" TypeName="Tiyi.JD.BLL.PaigongManage"
    UpdateMethod="UpdatePaigongBill">
    <SelectParameters>
        <asp:ControlParameter ControlID="hfPgId" Name="pgId" PropertyName="Value" DbType="Guid" />
    </SelectParameters>
</asp:ObjectDataSource>
