<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>百慕大 - 注册</title>
    <link href="css/sign-container.css" rel="stylesheet" />
    <script>
        var checkLength = function (source, args) {
            (args.Value.length < 6 || args.Value.length > 20) ? args.IsValid = false : args.IsValid = true;
        };
    </script>
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
            <div class="input-box">
                
                <div class="name">
                    <asp:TextBox ID="nameBox" runat="server" placeholder="用户名"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="notNullName" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </div>
                
                <div class="email">
                    <asp:TextBox ID="emailBox" runat="server" TextMode="Email" placeholder="邮箱"></asp:TextBox>
                    <!-- 邮箱验证 -->
                    <asp:RequiredFieldValidator ID="notNullEmail" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"> </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="checkEmail" CssClass="validator" runat="server" ControlToValidate="emailBox" ErrorMessage="请输入正确的邮箱" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                
                <div class="phone">
                    <asp:TextBox ID="phoneBox" runat="server" TextMode="Phone" placeholder="手机号"></asp:TextBox>
                    <!-- 手机号码验证 -->
                    <asp:RequiredFieldValidator ID="notNullPhone" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="checkPhone" CssClass="validator" runat="server" ControlToValidate="phoneBox" ErrorMessage="请输入正确的手机号" ValidationExpression="^1(3|4|5|7|8)\d{9}$"></asp:RegularExpressionValidator>
                </div>
                
                <div class="passwd">
                    <asp:TextBox ID="passwdBox" runat="server" TextMode="Password" placeholder="密码（6~20位）"></asp:TextBox>
                    <!-- 密码验证 -->
                    <asp:RequiredFieldValidator ID="notNull" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="checkPasswdLength" CssClass="validator" runat="server" ControlToValidate="passwdBox" ErrorMessage="请输入6~20位的密码" ClientValidationFunction="checkLength"></asp:CustomValidator>
                    <!--OnServerValidate="checkPasswdLength_ServerValidate"--> 
                </div>
                
                <div class="confirm-passwd">
                    <asp:TextBox ID="confirmPasswdBox" runat="server" TextMode="Password" placeholder="确认密码"></asp:TextBox>
                    <!-- 确认密码验证 -->
                    <asp:RequiredFieldValidator ID="notNullConfirm" CssClass="validator" runat="server" ControlToValidate="passwdBox" Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="confirmPasswd" CssClass="validator" runat="server" ControlToCompare="passwdBox" ControlToValidate="confirmPasswdBox" ErrorMessage="密码输入不一致"></asp:CompareValidator>
                </div>
            </div>
            
            <div class="sign-box">
                <div class="sign-btn">
                    <asp:Button ID="signUpBtn" runat="server" Text="注册" OnClick="signUpBtn_Click" />
                </div>
            </div>

            <div class="tip">
                <a href="SignIn.aspx">已有账号？马上登录！</a>
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
