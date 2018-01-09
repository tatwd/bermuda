<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="Bermuda.App.layout.TopicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.title = '所有话题';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
    <div class="container">
        <div class="topic-list">
            <div class="list-head">
                <img src="/assets/icon/tag.svg" alt="icon-tag">
                <h2>热门话题</h2>
            </div>

            <asp:ListView ID="LvTopicGroupCard" runat="server" GroupItemCount="3">
                <LayoutTemplate>
                    <div class="list-main">
                        <div id="groupPlaceHolder" runat="server"></div>
                    </div>
                </LayoutTemplate>
                <GroupTemplate>

                    <div class="card-box topic-card">
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"/>
                    </div>
                    
                </GroupTemplate>
                <ItemTemplate>
                    <div class="item">
                        <div class="content">
                            <div class="topic-img">
                                <a href='<%# "/layout/TopicDetail.aspx?id=" + Eval("Id") %>'>
                                    <img src='<%# Eval("Img") %>' alt="topic img"/>
                                </a>
                            </div>
                            <div class="text-center topic-desc">
                                <h3 class="margin-tb-15"><%# Eval("Name") %></h3>
                                <div class="margin-tb-15 fs-16 detail"><%# Eval("Detail")%></div>
                                
                                <div class="margin-tb-15">
                                    <a class="link-btn" href="CurrentEdit.aspx">参与</a>
                                </div>
                                <div class="fs-14">已有 <%# Eval("JoinCount") %> 篇动态参与</div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <!-- 提示信息 -->
    <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
    
    <script>
        var details = document.querySelectorAll('.detail');
        
        for (var i = 0, len = details.length; i < len; i++) {
            var text = details[i].innerText;

            if (text.length > 20) {
                text = text.substring(0, 20) + '...'
            }
            
            details[i].innerText = text;
        }

    </script>
</asp:Content>
