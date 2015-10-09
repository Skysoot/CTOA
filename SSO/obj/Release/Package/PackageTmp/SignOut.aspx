<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignOut.aspx.cs" Inherits="SSO.SignOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <iframe src="http://www.a.com/quit.aspx" style="display:none"></iframe>
        <iframe src="http://www.b.com/quit.aspx" style="display:none"></iframe>
    </div>
    </form>    
    <script>
        setTimeout(function () {
            window.location.href = "http://www.passport.com";
        }, 500);
    </script>
</body>    
</html>
