<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="PwdReset.aspx.cs" Inherits="Bermuda.App.layout.PwdReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>document.title = '找回密码';</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    <div class="container">
        <div class="flex-col justify-center reset-pwd-container">

            <h2 class="text-center margin-tb-15">找回密码</h2>

            <asp:UpdatePanel ID="UpTextBox" class="input-container" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="NextStepBtn" EventName="Click"/>
                </Triggers>
                <ContentTemplate>
                
                    <asp:Panel ID="InputEmailPanel" runat="server" Visible="true">
                        <div class="flex-box">
                            <asp:TextBox runat="server" ID="InputEmail" CssClass="input-block" placeholder="请输入邮箱以接收验证码" TextMode="Email" autofocus></asp:TextBox>
                        </div>
                    </asp:Panel>
                
                    <asp:Panel ID="InputCodePanel" runat="server" Visible="false">
                        <div class="flex-box">
                            <div class="flex-box">
                                <asp:TextBox ID="InputCode" CssClass="input-block" runat="server" placeholder="请输入验证码" autofocus></asp:TextBox>
                            </div>
                            <div class="resend-code">
                                <asp:Button ID="SendCodeBtn" runat="server" Text="发送验证码" OnClick="SendCodeBtn_Click"/>
                                <asp:Timer ID="TimerSend" runat="server" Interval="1000" OnTick="TimerSend_Tick" Enabled="false"></asp:Timer>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="ResetPwdPanel" runat="server" Visible="false">
                        <div class="flex-box">
                            <asp:TextBox ID="NewPwd" CssClass="input-block" runat="server" placeholder="输入新密码" TextMode="Password" autofocus autoComplete="off"></asp:TextBox>
                        </div>
                        <div class="flex-box margin-tb-5">
                            <asp:TextBox ID="RepeatPwd" CssClass="input-block" runat="server" placeholder="重复密码" TextMode="Password" autofocus autoComplete="off"></asp:TextBox>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="TestPanel" runat="server" Visible="false">test panel</asp:Panel>
                
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpStepBtn" class="btn-container" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="flex-box">
                        <asp:Button ID="NextStepBtn" runat="server" data-step="1" active-panel-id="InputEmailPanel" Text="下一步" OnClick="NextStepBtn_Click"/>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- 提示信息 -->
    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>

</asp:Content>
