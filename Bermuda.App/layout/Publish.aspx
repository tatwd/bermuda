<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="Bermuda.App.layout.Publish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.title = '发布启示';
    </script>
    <link href="../assets/selector/css/selector.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    <div class="container">
        <div class="pub-notice">
            <div class="flex-center upload-img">
                <img class="icon-upload-img" src="../assets/icon/upload-img.svg" alt="upload-img"/>
                <input class="input-block upload-input" name="uplaod" type="file" runat="server"/>
            </div>
            <div class="notice-info">
                <div class="title">
                    <asp:TextBox ID="NoticeTitle" runat="server" placeholder="标题" TextMode="MultiLine" Rows="1"/>
                </div>
                <div class="type">
                    <asp:RadioButtonList ID="NoticeTypeList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="寻物启示">寻物启示</asp:ListItem>
                        <asp:ListItem Value="招领启示">招领启示</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="species">
                    <asp:DropDownList ID="GoodSpecies" runat="server">
                        <asp:ListItem Value="NULL" disabled selected>请选种类</asp:ListItem>
                        <asp:ListItem Value="1">钱</asp:ListItem>
                        <asp:ListItem Value="2">卡类</asp:ListItem>
                        <asp:ListItem Value="3">证件</asp:ListItem>
                        <asp:ListItem Value="4">饰品</asp:ListItem>
                        <asp:ListItem Value="5">箱包</asp:ListItem>
                        <asp:ListItem Value="6">文具</asp:ListItem>
                        <asp:ListItem Value="7">图书</asp:ListItem>
                        <asp:ListItem Value="8">生活用具</asp:ListItem>
                        <asp:ListItem Value="9">电子数码</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="place">
                    <asp:TextBox ID="NoticePlace" runat="server" placeholder="地点"></asp:TextBox>
                </div>
                <div class="date">
                    <asp:TextBox ID="LfDate" runat="server" placeholder="时间"></asp:TextBox>
                </div>
                <div class="contact-way">
                    <asp:TextBox ID="ContactWay" runat="server" placeholder="联系方式（手机、QQ、微信等）"></asp:TextBox>
                </div>
                <div class="detail">
                    <asp:TextBox ID="NoticeDetail" runat="server" placeholder="详细信息(140字以内)" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <div class="text-center pub-btn">
                <asp:Button ID="PubNotice" runat="server" Text="发布启示" OnClick="PubNotice_Click"/>
            </div>
        </div>
        
        <!-- 提示信息 -->
        <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
    </div>
    <script src="../assets/selector/js/selector.min.js"></script>
</asp:Content>
