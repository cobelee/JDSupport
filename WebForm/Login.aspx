<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn" ></asp:Login>
            <asp:Button ID="btnLogin" runat="server" Text="自己登录" OnClick="btnLogin_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:LoginName ID="LoginName1" runat="server" />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </div>
    </form>
</body>
</html>
