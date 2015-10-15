<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webform1.aspx.cs" Inherits="A._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="webform1.aspx">网站A</a> | <a href="http://www.b.com/webform1.aspx">网站B</a><br />
        <asp:Button runat="server" ID="btnSignOut" Text="单点登出" OnClick="btnSignOut_Click" />
    </div>
    </form>
</body>
</html>
