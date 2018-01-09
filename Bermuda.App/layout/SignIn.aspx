<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Bermuda.App.layout.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width"/>
    
    <link rel="shortcut icon" href="../favicon.ico"/>
    <title>登录</title>
    
    <link rel="stylesheet" href="../dist/css/dogo.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- Ajax 脚本管理器 -->
        <asp:ScriptManager ID="SignInScriptManager" runat="server"></asp:ScriptManager>

        <div class="header sign-header">
            <div class="sign-logo text-center">
                <div class="logo-img"><a href="../Home.aspx"><img src="../assets/logo.svg" alt="logo img"/></a></div>
            </div>
        </div>
        <div class="mainer">
            <div class="container">
                <div class="sign-container">
                    <div class="sign-head text-center">
                        <h1>百慕大</h1>
                        <h2>寻找你的寻找</h2>
                    </div>
                    <div class="sign-body">
                        <div class="sign-input">
                            <div class="item">
                                <asp:TextBox ID="NameMail" CssClass="input-block" runat="server" placeholder="用户名" autofocus="autofocus"></asp:TextBox>
                                <!-- 验证不为空 -->
                                <asp:RequiredFieldValidator ID="RfvNamMail" CssClass="validator" runat="server" ErrorMessage="请输入用户名" ControlToValidate="NameMail" Display="Dynamic" SetFocusOnError="true">
                                    <span>请输入用户名</span>
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="item">
                                <asp:TextBox ID="Password" CssClass="input-block" runat="server" placeholder="密码" TextMode="Password"></asp:TextBox>
                                <!-- 验证不为空 -->
                                <asp:RequiredFieldValidator ID="RfvPassword" CssClass="validator" runat="server" ErrorMessage="请输入用户名" ControlToValidate="Password" Display="Dynamic" SetFocusOnError="true">
                                    <span>请输入密码</span>
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="remember-forget">
                            <div class="remember-me">
                                <asp:CheckBox ID="RememberMeCb" runat="server" Checked="false"/>
                                <span>记住我</span>
                            </div>
                            <div class="forget-pwd">
                                <a href="/layout/PwdReset.aspx">忘记密码？</a>
                            </div>
                        </div>
                        <div class="sign-btn">
                            <div>
                                <asp:UpdatePanel ID="UpSignBtn" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="SignInBtn" CssClass="input-block" runat="server" Text="登录" OnClick="SignInBtn_Click"></asp:Button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="goto-signup text-center">
                            <a href="SignUp.aspx">没有账号？马上注册！</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer">
            <asp:UpdatePanel ID="UpPromptInfo" runat="server">
                <ContentTemplate>
                    <!-- 提示信息 -->
                    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="SignInBtn"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
    <canvas id="canvas"></canvas>
</body>
</html>
<script src="../dist/js/dogo.min.js"></script>