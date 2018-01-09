<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Bermuda.App.Home"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script>document.title = '百慕大 - 寻找你的寻找';</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    
    <div class="sidebar">
        <div class="container flex-box items-center">
            <div class="col-2 flex-col slogan">
                <h2>寻找你的寻找</h2>
                <p>一切执于对美好校园生活的凝练</p>
            </div>
            <div class="col-1 flex-col juin-us">
                <div class="sign-up">
                    <asp:LinkButton ID="LinkSignUp" runat="server" class="link-btn" href="/layout/SignUp.aspx">加入我们</asp:LinkButton>
                    <asp:LinkButton ID="LinkTopicEdit" runat="server" class="link-btn create-topic" href="javascript:void(0);" Visible="false">创建话题</asp:LinkButton>
                </div>
                <div class="sign-in">
                    <asp:LinkButton ID="LinkSignIn" runat="server" class="link-btn" href="/layout/SignIn.aspx">马上登录</asp:LinkButton>
                    <asp:LinkButton ID="LinkCurrentEdit" runat="server" class="link-btn" href="/layout/CurrentEdit.aspx" Visible="false">发表动态</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <div class="container flex-col">
        <%-----------------------------
        -  从话题表取出参与度前六的话题  -
        -----------------------------%>
        <asp:ListView ID="ListHotTopic" runat="server">
            <LayoutTemplate>
                <div class="hot-topic">
                    <div class="card-box caro-slider">
                        <div id="itemPlaceHolder" runat="server"></div>
                    </div>
                 </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="item" style='<%# String.Format("background:url({0}) no-repeat center center;background-size:auto 120%;", Eval("img")) %>'>
                    <div class="flex-center">
                        <a class="flex-center" href='<%# "/layout/TopicDetail.aspx?id=" + Eval("Id") %>'><%# Eval("Name") %></a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        
        <div class="flex-box-inline">
            <div class="col-8">
                <%-------------
                -  条件过滤器  -
                -------------%>
                <asp:UpdatePanel ID="UpListFilter" class="filter" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <ul class="tablist">
                            <li class="item">
                                <span><asp:Button class="active-btn" ID="AllNotice" OnClick="AllNotice_OnClick" runat="server" Text="全部"></asp:Button></span>
                            </li>
                            <li class="item">
                                <span><asp:Button ID="LostNotice" OnClick="LostNotice_OnClick" runat="server" Text="寻物启示"></asp:Button></span>
                            </li>
                            <li class="item">
                                <span><asp:Button ID="FoundNotice" OnClick="FoundNotice_OnClick" runat="server" Text="招领启示"></asp:Button></span>
                            </li>
                        </ul>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%-- -----------------------------------------------------------
                -  让 UpListFilter 中的控件按钮来触发此 UpdatePanel 中的内容更新  -
                --------------------------------------------------------------%>
                <asp:UpdatePanel ID="UpListNotice" class="update-panel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="AllNotice" EventName="Click"/>
                        <asp:AsyncPostBackTrigger ControlID="LostNotice" EventName="Click"/>
                        <asp:AsyncPostBackTrigger ControlID="FoundNotice" EventName="Click"/>
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
                                            <a class="flex-box items-center cmnt" href='<%# "/layout/NoticeDetail.aspx?id=" + Eval("id") %>'>
                                                <img src="/assets/icon/cmnt.svg" alt="icon-cmnt"/>
                                                <span class="count"><%# Eval("cmnt_count") %></span>
                                            </a>
                                            <asp:UpdatePanel ID="UpTraceBtn" runat="server" class="trace" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                                <ContentTemplate>
                                                    <a class="flex-box items-center" href="javascript:;">
                                                        <img src="/assets/icon/trace.svg" alt="icon-trace"/>
                                                        <asp:Button ID="TraceBtn" data-notice-id='<%# Eval("id") %>' runat="server" Text='<%# "追踪 · " + Eval("trace_count") %>' OnClick="TraceBtn_Click"></asp:Button>
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

            <div class="col-4 hot-top">
                <%-----------
                -  热门种类  -
                -----------%>
                <asp:ListView ID="LvHotSpecies" runat="server">
                    <LayoutTemplate>
                        <div class="hot-species">
                            <div class="flex-box items-center title fs-15">
                                <img src="assets/icon/tag.svg" alt="icon-tag">物以类聚</div>
                            <div class="wrap-card body">
                                <a id="itemPlaceHolder" runat="server"></a>
                                <%--<a class="more" href="/layout/SpeciesAll.aspx">更多分类<i class="icon-angle-right"></i>--%>
                                </a>
                            </div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <a class="item" href='<%# "/layout/SpeciesDetail.aspx?id=" + Eval("Id") %>'>
                            <img class="col-1" src='<%# Eval("Img") %>' alt=""/>
                            <span class="col-1"><%# Eval("Name") %></span>
                        </a>
                    </ItemTemplate>
                </asp:ListView>
                
                <%-----------
                -  热门动态  -
                -----------%>
                <asp:Listview ID="LvHotCurrent" runat="server">
                    <LayoutTemplate>
                        <div class="hot-current">
                            <div class="flex-box items-center title fs-15">
                                <img src="assets/icon/fire.svg" alt="icon-fire">热门动态</div>
                            <div class="body">
                                <div id="itemPlaceHolder" runat="server"></div>
                                <div class="text-center fs-14 more">
                                    <a href="layout/Current.aspx">查看全部</a>
                                </div>
                            </div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="item">
                            <div class="current-title fs-14">
                                <a href='<%# "layout/CurrentDetail.aspx?id=" + Eval("current_id") %>'><%# Eval("current_title") %></a>
                            </div>
                            <div class="user-info fs-12">
                                <span class="user-name"><a href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'><%# "@" + Eval("user_name") %></a></span>
                                <span class="praise-count">- 赞 · <%# Eval("praise_count") %></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Listview>
                
                <%-----------
                -  用户排行  -
                -----------%>
                <asp:ListView ID="LvBmdTop" runat="server">
                    <LayoutTemplate>
                        <div class="bmd-top">
                            <div class="flex-box items-center title fs-15">
                                <img src="assets/icon/talent.svg" alt="icon-talent">百慕达人</div>
                            <div class="body">
                                <div id="itemPlaceHolder" runat="server"></div>
                            </div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="item flex-box items-center">
                            <a class="col-2 flex-box items-center user" href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'>
                                <img src='<%# Eval("user_avatar") %>' alt="avatar"/>
                                <span class="name"><%# Eval("user_name") %></span>
                            </a>
                            <span class="col-1 help-count">助人 · <%# Eval("help_count") %></span>
                            <asp:UpdatePanel ID="UpBmdTop" runat="server" ChildrenAsTriggers="True" RenderMode="Inline" class="col-1 text-right follow-btn">
                                <ContentTemplate>
                                    <asp:Button ID="FollowBtn" data-user-id='<%# Eval("user_id") %>' runat="server" Text="关注" OnClick="FollowBtn_Click"/>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>

    </div>
    
    <%-----------
    -  创建话题  -
    -----------%>
    <asp:Panel ID="TopicEditPanel" runat="server" Visible="false" class="topic-edit-container">
        <div class="edit-topic">
            <i class="icon-close">x</i>
            <div class="flex-center upload-img">
                <img class="icon-upload-img" src="../assets/icon/upload-img.svg" alt="upload-img"/>
                <input class="input-block upload-input" name="uplaod" type="file" runat="server"/>
            </div>
            <div class="topic-info">
                <div class="title">
                    <asp:TextBox ID="TopicName" runat="server" placeholder="话题名" TextMode="MultiLine" Rows="1"/>
                </div>
                <div class="detail">
                    <asp:TextBox ID="TopicDetail" runat="server" placeholder="详细信息(50字以内)" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
            </div>
            <div class="text-center pub-btn">
                <asp:Button ID="SubmitTopic" runat="server" Text="申请创建" OnClick="SubmitTopic_Click"/>
            </div>
        </div>
    </asp:Panel>

    <!-- 提示信息 -->
    <div class="container prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
</asp:Content>
