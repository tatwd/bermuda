<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Bermuda.App.layout.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.title = '用户主页 - 百慕大';
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    <div class="container profile-container">
        <asp:UpdatePanel ID="UpProfilePage" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>

                <asp:ListView ID="ListUserInfo" runat="server" OnItemDataBound="ListUserInfo_ItemDataBound">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"/>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="flex-box profile-header">
                            <div class="col-1 avatar">
                                <div>
                                    <img src='<%# Eval("Avatar") %>' alt="user avatar"/>
                                </div>
                            </div>
                            <div class="col-11 flex-col content">
                                <h2 class="flex-box user-info">
                                    <span class="name"><%# Eval("Name") %></span>
                                    <!--<span class="desc">个人描述</span>-->
                                </h2>
                                <div class="flex-box items-center bottom">
                                    <div class="left">
                                        <!--<span class="user-sex">
                                            <svg viewBox="0 0 12 16" class="" fill="#9fadc7" aria-hidden="true" style="height: 16px; width: 14px;"><title></title><g><path d="M6 0C2.962 0 .5 2.462.5 5.5c0 2.69 1.932 4.93 4.485 5.407-.003.702.01 1.087.01 1.087H3C1.667 12 1.667 14 3 14s1.996-.006 1.996-.006v1c0 1.346 2.004 1.346 1.998 0-.006-1.346 0-1 0-1S7.658 14 8.997 14c1.34 0 1.34-2-.006-2.006H6.996s-.003-.548-.003-1.083C9.555 10.446 11.5 8.2 11.5 5.5 11.5 2.462 9.038 0 6 0zM2.25 5.55C2.25 3.48 3.93 1.8 6 1.8c2.07 0 3.75 1.68 3.75 3.75C9.75 7.62 8.07 9.3 6 9.3c-2.07 0-3.75-1.68-3.75-3.75z" fill-rule="evenodd"></path></g></svg>
                                        </span>-->
                                        <span>男</span>
                                        <a class="margin-lr-10" href="#">关注 · <span class="count"><%# Eval("FollowingCount") %></span></a>
                                        <a href="#">粉丝 · <span class="count"><%# Eval("FollowerCount") %></span></a>
                                    </div>
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" class="right">
                                        <ContentTemplate>
                                            <span class="flex-box">
                                                <asp:LinkButton ID="LinkCurrentEdit" runat="server" class="link-btn fs-14 edit-current" href="/layout/CurrentEdit.aspx">写动态</asp:LinkButton>
                                            </span>
                                            <span class="flex-box">
                                                <asp:Button ID="FollowBtn" CssClass="bmd-btn" Text="关注" data-user-id='<%# Eval("Id") %>' runat="server" OnClick="FollowBtn_Click"/>
                                                <asp:LinkButton ID="LinkInfoEdit" runat="server" class="link-btn fs-14 edit-info" href="/layout/UserInfoEdit.aspx">编辑个人资料</asp:LinkButton>
                                            </span>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

                <div class="flex-box profile-mainer">
                    <div class="col-8 sidebar-left">
                        <asp:UpdatePanel ID="FilterCondition" class="left-header" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <ul class="tablist">
                                    <li class="item">
                                        <asp:LinkButton ID="LinkNotice" runat="server" class="active" OnClick="LinkNotice_Click">
                                            启示 <asp:Label ID="NoticeCount" CssClass="count" runat="server"></asp:Label>
                                        </asp:LinkButton></li>
                                    <li class="item">
                                        <asp:LinkButton ID="LinkCurrent" runat="server" OnClick="LinkCurrent_Click">
                                            动态 <asp:Label ID="CurrentCount" CssClass="count" runat="server"></asp:Label>
                                        </asp:LinkButton></li>
                                    <%--<li class="item">
                                        <asp:LinkButton ID="LinkGoods" runat="server" OnClick="LinkGoods_Click">
                                            背包 <asp:Label ID="GoodsCount" CssClass="count" runat="server"></asp:Label>
                                        </asp:LinkButton>
                                    </li>--%>
                                    <li class="item">
                                        <a id="More" class="" href="javascript:void(0);">
                                            更多
                                            <%--<span class="flex-inline-box items-center icon-more" style="margin-left: 4px;">
                                                <svg viewBox="0 0 10 6" class="Icon ProfileMain-tabIcon Icon--arrow" aria-hidden="true" style="height: 16px; width: 10px;"><title></title><g><path d="M8.716.217L5.002 4 1.285.218C.99-.072.514-.072.22.218c-.294.29-.294.76 0 1.052l4.25 4.512c.292.29.77.29 1.063 0L9.78 1.27c.293-.29.293-.76 0-1.052-.295-.29-.77-.29-1.063 0z"></path></g></svg>
                                            </span>--%>
                                        </a>
                                    </li>
                                </ul>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        <asp:UpdatePanel ID="UpList" class="left-list" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="LinkNotice" EventName="Click"/>
                                <asp:AsyncPostBackTrigger ControlID="LinkCurrent" EventName="Click"/>
                                <%--<asp:AsyncPostBackTrigger ControlID="LinkGoods" EventName="Click"/>--%>
                            </Triggers>
                            <ContentTemplate>
                                <asp:Panel ID="ListPanel" runat="server" active-control-id="ListNotice">
                                    <!-- 启示列表 -->
                                    <asp:ListView ID="ListNotice" runat="server">
                                        <LayoutTemplate>
                                            <div class="list-box notice-list">
                                                <div id="itemPlaceHolder" runat="server"></div>
                                            </div>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <div id='<%# "notice-" + Eval("id") %>' class="item">
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
                                                        <a class="link-img" href='<%# "/layout/NoticeDetail.aspx?id=" + Eval("id") %>'>
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
                                                        <asp:UpdatePanel ID="UpTraceBtn" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True" class="trace">
                                                            <ContentTemplate>
                                                                <a class="flex-box items-center" href="javascript:;">
                                                                    <img src="/assets/icon/trace.svg" alt="icon-trace"/>
                                                                    <asp:Button ID="TraceBtn" data-notice-id='<%# Eval("id") %>' runat="server" Text='<%# "追踪 · " + Eval("trace_count") %>' Enabled="true" OnClick="TraceBtn_Click"></asp:Button>
                                                                </a>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                
                                    <!-- 动态列表 --->
                                    <asp:ListView ID="ListCurrent" runat="server" Visible="false">
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
                                                    
                                                    <%--<a class="fs-12 topic-name" href="#"><%# Eval("topic_name") %></a>--%>

                                                    <a class="flex-box items-center margin-lr-10 praise" href="javascript:;">
                                                        <img src="/assets/icon/heart.svg" alt="icon-praise"/>
                                                        <span class="fs-14 count"><%# Eval("praise_count") %></span>
                                                    </a>
                                                    <a class="flex-box items-center cmnt" href="javascript:;">
                                                        <img src="/assets/icon/cmnt.svg" alt="icon-cmnt"/>
                                                        <span class="fs-14 count"><%# Eval("cmnt_count") %></span>
                                                    </a>
                                                    <a class="flex-box items-center margin-lr-10 star" href="javascript:;">
                                                        <img src="/assets/icon/star.svg" alt="icon-star"/>
                                                        <span class="fs-14 count"><%# Eval("star_count") %></span>
                                                    </a>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>

                                    <!-- 物品列表 -->

                                    <!-- 无数据测试控件 -->
                                    <asp:Panel ID="EmptyData" runat="server" Visible="false">无数据</asp:Panel>
                                </asp:Panel>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-4 sidebar-right">
                        <div class="flex-box">
                            <a class="col-6 text-center helping" href="javascript:void(0);">
                                <div>帮助了</div>
                                <strong id="HelpingCount" runat="server"></strong>
                            </a>
                            <a class="col-6 text-center backing" href="javascript:void(0);">
                                <div>找回了</div>
                                <strong id="BackingCount" runat="server"></strong>
                            </a>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- 提示信息 -->
    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
</asp:Content>
