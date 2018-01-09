<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="TopicDetail.aspx.cs" Inherits="Bermuda.App.layout.TopicDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.title = '话题详情页';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">

    <div class="container">
        <div class="flex-box topic-detail">
            <!-- 话题信息 -->
            <asp:ListView ID="ListTopicInfo" runat="server">
                <LayoutTemplate>
                    <div class="col-3 order-2 margin-tb-15 topic-head">
                        <asp:placeholder ID="itemPlaceHolder" runat="server"/>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="topic-img">
                        <div class="flex-box margin-center">
                            <img src='<%# Eval("img") %>' alt="topic-img"/>
                        </div>
                    </div>
                    <div>
                        <h2 class="margin-tb-15 text-center"><%# Eval("name") %></h2>
                        <div class="margin-tb-10 text-center fs-14"><%# Eval("detail") %> - <a href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>' target="_blank"><%# "@" + Eval("user_name") %></a></div>
                        <div class="margin-lr-15 text-center">
                            <div class="fs-16">参与度</div>
                            <strong><%# Eval("join_count") %></strong>
                        </div>
                    </div>
                    <div class="text-center">
                        <a class="link-btn fs-14 margin-tb-15" href="CurrentEdit.aspx">我要参与</a>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <!-- 动态列表 -->
            <div class="col-9 order-1 margin-tb-15 topic-main">
                <asp:ListView ID="ListCurrent" runat="server">
                    <LayoutTemplate>
                        <div class="list-box current-list">
                            <div id="itemPlaceHolder" runat="server"></div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div id="current-1" class="item">
                            <div class="user">
                                <a class="author" href="#">
                                    <img class="avatar" src="/assets/avatar-tmp.svg" alt="avatar"/>
                                    <span class="margin-lr-10 fs-14 name"><%# Eval("user_name") %></span>
                                </a>
                                <span class="fs-12">发表于 <%# Eval("publish_date", "{0:yyyy-MM-dd}") %></span>
                            </div>
                            <div class="content">
                                <h3 class="title">
                                    <a href='<%# "/layout/CurrentDetail.aspx?id=" + Eval("id") %>'><%# Eval("title") %></a>
                                </h3>
                                <div class="main">
                                    <div class="fs-15"><%# Eval("contents") %></div>
                                </div>
                            </div>
                            <div class="meta">
                                <a class="flex-box items-center praise" href="javascript:;">
                                    <img src="/assets/icon/heart.svg" alt="icon-praise"/>
                                    <span class="fs-14 count"><%# Eval("praise_count") %></span>
                                </a>
                                <a class="flex-box items-center margin-lr-10 cmnt" href="javascript:;">
                                    <img src="/assets/icon/cmnt.svg" alt="icon-cmnt"/>
                                    <span class="fs-14 count"><%# Eval("cmnt_count") %></span>
                                </a>
                                <a class="flex-box items-center star" href="javascript:;">
                                    <img src="/assets/icon/star.svg" alt="icon-star"/>
                                    <span class="fs-14 count"><%# Eval("star_count") %></span>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <!-- 提示信息 -->
    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
</asp:Content>
