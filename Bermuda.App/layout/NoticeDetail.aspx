<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="NoticeDetail.aspx.cs" Inherits="Bermuda.App.layout.NoticeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>document.title = '启示详情页';</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    <div class="container">
        
        <!-- 显示启示具体内容 -->
        <asp:ListView ID="LvNoticeDetail" runat="server">
            <LayoutTemplate>
                <div id="itemPlaceHolder" runat="server"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="notice-detail">
                    <div class="main">
                        <div class="title">
                            <div class="flex-row items-center">
                                <h1><%# Eval("title") %></h1>
                                <span class="status">
                                    <i class="icon-angle-left"></i>
                                    <span><%# Eval("status") %></span>
                                </span>
                            </div>
                        </div>
                        <div class="user flex-box items-center">
                            <a href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'>
                                <img src='<%# Eval("user_avatar") %>' alt="user avatar"/>
                            </a>
                            <a class="margin-lr-10 fs-18" href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'><%# Eval("user_name") %></a>
                            <span class="fs-14">发表于 <%# Eval("publish_date", "{0:yyyy-MM-dd hh:mm}") %></span>
                        </div>
                        <div class="content">
                            <div>
                                <p>地点：<%# Eval("place") %></p>
                                <p>时间：<%# Eval("lf_date") %></p>
                                <p>联系方式：<%# Eval("contact_way") %></p>
                                <p>详细信息：<%# Eval("detail") %></p>
                            </div>
                            <div class="flex-box has-img">
                                <img src='<%# Eval("img") %>' class="goods-img" alt="goods-img"/>
                                <!--图片模态框 -->
                                <div id="zoom-container">
                                    <div class="flex-col flex-center">
                                        <i class="close">×</i>
                                        <img class="zoom-img" src='<%# Eval("img") %>'/>
                                        <div class="caption"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server" class="flex-box meta">
                        <ContentTemplate>
                            <asp:Button ID="TraceBtn" runat="server" Text="追踪" OnClick="TraceBtn_Click"/>
                            <span class="flex-box items-center">
                                <img src="../assets/icon/cmnt.svg" alt="icon-cmnt">
                                <span class="margin-lr-5"><%# Eval("cmnt_count") %></span>
                            </span>
                            <span class="flex-box items-center">
                                <svg t="1513132410646" class="icon" style="" viewBox="0 0 1443 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="9637" xmlns:xlink="http://www.w3.org/1999/xlink" width="20" height="16">
                                    <path d="M1439.014597 32.539483V26.927884l-1.130114-1.130114V21.316284l-1.130114-1.130114v-1.130113l-1.130113-1.130114h-1.130114l-1.130114-1.130114v-1.091144l-1.130114-1.130114-2.260227-2.260228v-1.091144l-1.130114-1.130114v-2.221258h-3.351372l-1.130114-1.130114h-2.260227l-1.130114-1.130114v-1.130113h-1.130114V3.195494H1418.633579l-1.130113-1.130114h-1.130114V1.130114h-4.481486V0H1403.045803l-1.130114 1.130114h-1.130114v1.130114h-2.260227l-1.130114 1.130113H1395.251915L22.592327 526.399208A34.448986 34.448986 0 0 0 2.367187 571.292004 37.566541 37.566541 0 0 0 23.527593 591.634053l411.906991 164.996613 42.632568 236.817292a35.072497 35.072497 0 0 0 39.281197 28.057998 30.279256 30.279256 0 0 0 19.095026-11.223199l152.6433-152.6433 310.8982 124.702211a35.072497 35.072497 0 0 0 44.892796-17.964913L1435.624256 50.504395l1.130113-1.130113V37.020969zM461.427201 691.356852l-332.214484-132.496099L1184.232392 155.994672z m71.82068 223.372836l-22.602276-130.196903 109.114435 43.762683z m462.411386-8.962972l-460.151159-184.091639L1324.522379 138.02976z m0 0" fill="#c66" p-id="9638"></path>
                                </svg>
                                <span class="margin-lr-5"><%# Eval("trace_count") %></span>
                            </span>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </ItemTemplate>
        </asp:ListView>

        <%----------
        -  评论区  -
        ----------%>
        <div id="comment-stuff" class="notice-comment">
            <asp:UpdatePanel ID="UpComment" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" class="comment">
                <ContentTemplate>

                    <%---------------
                    -  发表评论区域  - 
                    ---------------%>
                    <asp:UpdatePanel ID="UpCommentBtn" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" class="pub-cmnt">
                        <ContentTemplate>
                            <div class="cmnt-text">
                                <asp:TextBox ID="CmntText" runat="server" TextMode="MultiLine" Rows="4" placeholder="写下你的评论（140字以内）"></asp:TextBox>
                            </div>
                            <div class="cmnt-btn">
                                <asp:Button ID="CmntBtn" runat="server" Text="发表" OnClick="CmntBtn_Click"/>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <%-----------------------------
                    -  点击发表评论按钮触发此处更新  -
                    -----------------------------%> 
                    <asp:UpdatePanel runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CmntBtn" EventName="Click"/>
                        </Triggers>
                        <ContentTemplate>
                            <h3 class="count"><%= Bermuda.Bll.NoticeService.GetFieldValue<long>(GetNoticeId(), "cmnt_count") %> 条评论</h3>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <%-----------------------------
                    -  点击发表评论按钮触发此处更新  -
                    -----------------------------%>   
                    <asp:UpdatePanel ID="UpCommentList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" class="cmnt-list">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CmntBtn" EventName="Click"/>
                        </Triggers>
                        <ContentTemplate>
                            <asp:ListView ID="LvComment" runat="server" OnItemDataBound="LvComment_ItemDataBound">
                                <LayoutTemplate>
                                    <div id="itemPlaceHolder" runat="server"></div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div id='<%# "cmnt-" + Eval("id") %>' class="item">
                                        <div class="user">
                                            <a href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'>
                                                <img src='<%# Eval("user_avatar") %>' alt="avatar-img"/>
                                            </a>
                                        </div>
                                        <div class="content">
                                            <!-- 评论的内容 -->
                                            <div class="cmnt-text">
                                                <section>
                                                    <p><%# Eval("contents") %></p>
                                                </section>
                                                <div  class="meta flex-box">
                                                    <span class="date"><%# Eval("cmnt_date", "{0:yyyy-MM-dd HH:mm}") %></span>
                                                    <a class="flex-box items-center praise" href="javascript:;">
                                                        <img src="../assets/icon/praise.svg" alt="icon-praise">
                                                        <span>赞</span>
                                                    </a>
                                                    <a class="flex-box items-center reply" href="javascript:void(0);">
                                                        <img src="../assets/icon/reply.svg" alt="icon-reply">
                                                        <span>回复</span>
                                                    </a>
                                                </div>
                                            </div>
                                            
                                            <%----------------------------------- 
                                            -  此区域包含：评论的回复，回复编辑区  - 
                                            -----------------------------------%>
                                            <asp:Panel ID="CmntReplyPanel" runat="server">

                                                <%-- 评论的回复，被 LvComment 和 ReplyBtn 触发刷新 --%>
                                                <asp:UpdatePanel ID="UpReplyBtn" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" class="cmnt-reply">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="LvComment" EventName="ItemDataBound"/>
                                                        <asp:AsyncPostBackTrigger ControlID="ReplyBtn" EventName="Click"/>
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:Repeater ID="ReptCmntReply" runat="server">
                                                            <ItemTemplate>
                                                                <div class='<%# "reply-" + Eval("id") %>'>
                                                                    <div class="content">
                                                                        <div class="flex-box fs-14">
                                                                            <a class="name" href='<%# "/layout/Profile.aspx?id=" + Eval("user_id") %>'><%# Eval("user_name") %></a>：
                                                                            <section>
                                                                                <p class="text">
                                                                                    <a class="aims-user" href='<%# "/layout/Profile.aspx?id=" + Eval("aims_user_id") %>'><%# Eval("aims_user_name") %> </a>
                                                                                    <%# Eval("contents") %>
                                                                                </p>
                                                                            </section>
                                                                        </div>
                                                                        <div class="flex-box meta">
                                                                            <span class="date"><%# Eval("reply_date", "{0:yyyy-MM-dd HH:mm}") %></span>
                                                                            <a class="flex-box items-center praise" href="javascript:;">
                                                                                <img src="../assets/icon/praise.svg" alt="icon-praise">
                                                                                <span>赞</span>
                                                                            </a>
                                                                            <a class="flex-box items-center reply" data-aims-id='<%# Eval("id") %>' href="javascript:void(0);">
                                                                                <img src="../assets/icon/reply.svg" alt="icon-reply">
                                                                                <span>回复</span>
                                                                            </a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <%---------------
                                                -  发表评论区域  - 
                                                ---------------%>
                                                <asp:Panel ID="PubReply" runat="server" class="pub-reply hidden" Visible="true">
                                                    <%-- 评论 ID --%>
                                                    <asp:HiddenField ID="HiddenCmntId" Value='<%# Eval("id") %>' runat="server" Visible="false"/>

                                                    <%-- 回复目标 ID --%>
                                                    <asp:HiddenField ID="HiddenAimsId" runat="server"/>

                                                    <div class="reply-text">
                                                        <asp:TextBox ID="ReplyText" runat="server" TextMode="MultiLine" Rows="1" placeholder="写下你的回复（140 字以内）"></asp:TextBox>
                                                    </div>
                                                    <div class="cancel-btn">
                                                        <button class="cancel" type="button">取消</button>
                                                    </div>
                                                    <div class="reply-btn">
                                                        <asp:Button ID="ReplyBtn" runat="server" Text="回复" OnClick="ReplyBtn_Click"/>
                                                    </div>
                                                </asp:Panel>

                                            </asp:Panel>
                                        
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- 提示信息 -->
        <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
    </div>
    <script>
        /**
         * @desc 解决 UpdatePanel 控件异步刷新导致 Js 事件失效 -- 重新注册 Js 事件代码
         * @author _king
         */
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () { var u = function () { var n = document.getElementById("UserProfile"); return n ? !0 : !1 }; var f = document.getElementsByClassName("comment")[0], n, e, t, i, r; if (f) for (n = f.getElementsByClassName("item"), e = function (t) { var o = n[t].getElementsByClassName("meta"), i = n[t].getElementsByClassName("hidden")[0], c = n[t].getElementsByClassName("cmnt-reply")[0], f, s, a, h, l, r, e; if (!c) return { v: undefined }; for (f = c.getElementsByClassName("aims-user"), s = [], r = 0, e = f.length; r < e; r++) f[r].innerText.length === 0 && s.push(r); for (a = f.length, h = 0, s.forEach(function (n) { n = n - h; f[n].parentNode.removeChild(f[n]); h++ }), l = function (n) { var t = o[n].getElementsByClassName("reply")[0]; t.addEventListener("click", function () { var c = u(), s, h; if (!c) { v("/layout/SignIn.aspx"); return } i.classList.remove("hidden"); var f = o[n].parentElement.getElementsByClassName("name")[0], r = i.getElementsByTagName("textarea")[0], e = t.getAttribute("data-aims-id"); r.value = ""; e && (s = i.getElementsByTagName("input")[0], s.value = e); h = f ? "@" + f.innerText : "写下你的回复（140 字以内）"; r.setAttribute("placeholder", h); r.focus(); var l = setTimeout(function () { i.style.opacity = "1"; clearTimeout(l) }, 0), a = i.getElementsByClassName("cancel")[0], y = i.getElementsByClassName("reply-btn")[0].getElementsByTagName("input")[0]; a.addEventListener("click", function () { i.style.opacity = "0"; var n = setTimeout(function () { i.classList.add("hidden"); clearTimeout(n) }, 300) }, !1); y.addEventListener("click", function () { i.classList.add("hidden") }, !1) }, !1) }, r = 0, e = o.length; r < e; r++) l(r, e) }, t = 0, i = n.length; t < i; t++) if (r = e(t, i), typeof r == "object") return r.v });
    </script>
</asp:Content>
