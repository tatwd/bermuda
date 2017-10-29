<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>百慕大 - 登录</title>
    <link href="css/sign-container.css" rel="stylesheet" />
</head>
<body>
    <form id="signForm" runat="server">
    <div>
        <div class="logo">
            <img class="logo-img" src="../assets/bmd-logo.svg" height="58" alt="logo" />
            <h1 class="logo-text"><a href="../Default.aspx">百慕大</a></h1>
            <h2 class="logo-text">寻找你的寻找</h2>
        </div>

        <div class="container">
            <%--<div class="title-box"></div>--%>
            
            <div class="input-box">
                
                <div class="name">
                    <asp:TextBox ID="nameBox" runat="server" placeholder="用户名"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="notNullName" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </div>
                
                <div class="passwd">
                    <asp:TextBox ID="passwdBox" runat="server" TextMode="Password" placeholder="密码（6~20位）"></asp:TextBox>
                    <!-- 密码验证 -->
                    <asp:RequiredFieldValidator ID="notNull" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </div>
            </div>
            
            <div class="sign-box">
                <div class="sign-btn">
                    <asp:Button ID="signInBtn" runat="server" Text="登录" OnClick="signInBtn_Click"/>
                </div>
            </div>
            <div class="tip">
                <a href="SignUp.aspx">还没注册？马上注册！</a>
            </div>
        </div>

        <div class="label">
             <asp:Label ID="tipLabel" runat="server"></asp:Label> 
        </div>

    </div>
    </form>
</body>
</html>
<script src="js/sign-validator.js"></script>
