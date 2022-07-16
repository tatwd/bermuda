<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Bermuda.App.layout.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width"/>
    
    <link rel="shortcut icon" href="../favicon.ico"/>
    <title>注册</title>
    
    <link rel="stylesheet" href="../dist/css/dogo.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- Ajax 脚本管理器 -->
        <asp:ScriptManager ID="SignUpScriptManager" runat="server"></asp:ScriptManager>
        
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
                            <div  class="item">
                                <asp:TextBox ID="Username" CssClass="input-block" runat="server" placeholder="用户名" autofocus="autofocus"></asp:TextBox>
                                <!-- 验证不为空 -->
                                <asp:RequiredFieldValidator ID="RfvUsername" CssClass="validator" runat="server" ControlToValidate="Username" Display="Dynamic" SetFocusOnError="true">
                                    <span>请输入用户名</span>
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="item">
                                <asp:TextBox ID="Email" CssClass="input-block" runat="server" placeholder="邮箱"></asp:TextBox>
                                <!-- 验证不为空 -->
                                <asp:RequiredFieldValidator ID="RfvEmail" CssClass="validator" runat="server" ControlToValidate="Email" Display="Dynamic" SetFocusOnError="true">
                                    <span>请输入邮箱</span>
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RevEmail" runat="server" CssClass="validator" ControlToValidate="Email" Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    <span>请输入有效的邮箱</span>
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="item">
                                <asp:TextBox ID="Password" CssClass="input-block" runat="server" placeholder="密码（不少于 6 位）" TextMode="Password"></asp:TextBox>
                                <!-- 验证不为空 -->
                                <asp:RequiredFieldValidator ID="RfvPassword" CssClass="validator" runat="server" ControlToValidate="Password" Display="Dynamic" SetFocusOnError="true">
                                    <span>请输入密码</span>
                                </asp:RequiredFieldValidator>
                                <!-- 验证密码位数 -->
                                <script>var validatePwdLength = function (src, args) { args.IsValid = args.Value.length >= 6 ? true : false; };</script>
                                <asp:CustomValidator ID="CvPassword" CssClass="validator" runat="server" ControlToValidate="Password" Display="Dynamic" ClientValidationFunction="validatePwdLength" SetFocusOnError="true">
                                    <span>密码不少于 6 位</span>
                                </asp:CustomValidator>
                            </div>
                            <div class="item">
                                <asp:TextBox ID="RepeatPwd" CssClass="input-block" runat="server" placeholder="重复密码" TextMode="Password"></asp:TextBox>
                                <!-- 验证不为空 -->
                                <asp:RequiredFieldValidator ID="RfvRepeatPwd" CssClass="validator" runat="server" ControlToValidate="RepeatPwd" Display="Dynamic" SetFocusOnError="true">
                                    <span>请重复输入密码</span>
                                </asp:RequiredFieldValidator>
                                <!-- 验证密码是否相等 -->
                                <asp:CompareValidator ID="CvRepeatPwd" CssClass="validator" runat="server" ControlToCompare="Password" ControlToValidate="RepeatPwd">
                                    <span>密码不一致</span>
                                </asp:CompareValidator>
                            </div>
                        </div>

                        <!-- 验证码 -->
                        <div class="verify-code">
                            <div class="code-input">
                                <asp:TextBox ID="VerifyCode" CssClass="input-block" runat="server" placeholder="输入验证码"></asp:TextBox>
                            </div>
                            <!-- Ajax UpdatePanel -->
                            <asp:UpdatePanel ID="UpVerifyCode" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="SendVerifyCode" CssClass="code-send" runat="server" Text="邮箱接收验证码" OnClick="SendVerifyCode_Click"/>
                                    <asp:Timer ID="TimerSend" runat="server" Interval="1000" OnTick="TimerSend_Tick" Enabled="false"></asp:Timer>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="sign-btn">
                            <div>
                                <%--<asp:Button ID="SignUpBtn" CssClass="input-block" runat="server" Text="注册" OnClick="SignUpBtn_Click"></asp:Button>--%>
                                <asp:UpdatePanel ID="UpSignBtn" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="SignUpBtn" CssClass="input-block" runat="server" Text="注册" OnClick="SignUpBtn_Click"></asp:Button>
                                        <%--<div class="sign-prompt text-center pos-center"><asp:label runat="server" id="promptinfo"></asp:label></div>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="goto-signin text-center">
                            <a href="SignIn.aspx">已有账号？马上登录！</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer">
            <!-- 提示信息 -->
            <asp:UpdatePanel ID="UpPromptInfo" runat="server">
                <ContentTemplate>
                    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="SignUpBtn"/>
                    <%--<asp:AsyncPostBackTrigger ControlID="SignUpBtn"/>--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
    <canvas id="canvas"></canvas>
</body>
</html>
<script src="../dist/js/dogo.min.js"></script>