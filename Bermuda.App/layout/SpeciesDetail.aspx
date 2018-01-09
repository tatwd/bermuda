<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="SpeciesDetail.aspx.cs" Inherits="Bermuda.App.layout.SpeciesDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>document.title = '分类详情页';</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    <div class="container">
        <div class="flex-box species-detail">
            <!-- 话题信息 -->
            <asp:ListView ID="ListSpeciesInfo" runat="server">
                <LayoutTemplate>
                    <div class="col-3 order-2 margin-tb-15 species-head">
                        <asp:placeholder ID="itemPlaceHolder" runat="server"/>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="topic-img">
                        <div class="flex-box margin-center">
                            <img src='<%# Eval("Img") %>' alt="topic-img"/>
                        </div>
                    </div>
                    <div>
                        <h2 class="margin-tb-15 text-center"><%# Eval("Name") %></h2>
                        <div class="margin-lr-15 text-center">
                            <div class="fs-16">启示数</div>
                            <strong><%# Eval("NoticeCount") %></strong>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <asp:UpdatePanel ID="UpListNotice" class="col-9 order-1 margin-tb-15 species-main update-panel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="AllNotice" EventName="Click"/>
                    <asp:AsyncPostBackTrigger ControlID="LostNotice" EventName="Click"/>
                    <asp:AsyncPostBackTrigger ControlID="FoundNotice" EventName="Click"/>--%>
                </Triggers>

                <ContentTemplate>
                    <!-- 从失物招领中取出启示，按时间降序 -->
                    <asp:ListView ID="ListNotice" runat="server">
                        <LayoutTemplate>
                            <div class="list-box notice-list">
                                <div id="itemPlaceHolder" runat="server"></div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="item" id='<%# "notice-" + Eval("id") %>'>
                                <div class="flex-box">
                                    <div class="col-3 content">
                                        <h3>
                                            <%--<img src="assets/icon/status-0.svg" alt="status">--%>
                                            <a href='<%# "/layout/NoticeDetail.aspx?id=" + Eval("id") %>' target="_bank"><%# Eval("title") %></a>
                                        </h3>
                                        <p class="flex-box items-center fs-14"><img src="/assets/icon/place.svg" alt="icon-place"><%# Eval("place") %></p>
                                        <p class="flex-box items-center fs-14"><img src="/assets/icon/date.svg" alt="icon-date"><%# Eval("lf_date")%></p>
                                        <p class="flex-box items-center fs-14"><img src="/assets/icon/desc.svg" alt="icon-desc"><%# Eval("detail") %></p>
                                    </div>
                                    <div class="col-1 goods-img">
                                        <a class="link-img text-right" href="#">
                                            <img src='<%# Eval("img") %>' alt="goods-img"/>
                                        </a>
                                    </div>
                                </div>
                                <div class="flex-box user-meta">
                                    <div class="user flex-box items-center">
                                        <a class="link-img" href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'>
                                            <img src='<%# Eval("user_avatar") %>' alt="avatar"/>
                                        </a>
                                        <a href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'><%# Eval("user_name") %></a>
                                        <span class="margin-lr-15 fs-12">发布于 <%# Eval("publish_date", "{0:yyyy-MM-dd}") %></span>
                                    </div>
                                    <div class="flex-row meta">
                                        <a class="flex-box items-center cmnt" href="javascript:;">
                                            <img src="/assets/icon/cmnt.svg" alt="icon-cmnt"/>
                                            <span class="count"><%# Eval("cmnt_count") %></span>
                                        </a>
                                        <asp:UpdatePanel ID="UpTraceBtn" runat="server" class="trace" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                            <ContentTemplate>
                                                <a class="flex-box items-center" href="javascript:;">
                                                    <img src="/assets/icon/trace.svg" alt="icon-trace"/>
                                                    <asp:Button ID="TraceBtn" data-notice-id='<%# Eval("id") %>' runat="server" Text='<%# "追踪 · " + Eval("trace_count") %>'></asp:Button>
                                                </a>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- 提示信息 -->
    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
</asp:Content>
