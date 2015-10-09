<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSO.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>疯狂老师办公平台登录系统</title>

    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.min.css">

    <link href="style/font-awesome.css" rel="stylesheet">
    <link href="style/animate.css" rel="stylesheet">
    <link href="style/style.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>
                <h1 class="logo-name">疯狂老师</h1>
            </div>
            <h3>Welcome to Login！</h3>
            <form class="m-t" role="form" id="form1" runat="server" autocomplete="off">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Enter your cell number" required autofocus ></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtPwd" TextMode="Password" CssClass="form-control" placeholder="Password" required></asp:TextBox>
                </div>
                <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary block full-width m-b" Text="Login" OnClick="btnLogin_Click"/>
                <a href="#"><small>Forgot password?</small></a>
            </form>
            <p class="m-t"><small>上海享学网络科技有限公司 &copy;2015</small> </p>
        </div>
    </div>    
    <!-- Mainly scripts -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.min.js"></script>
    <script src="//cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</body>
</html>
