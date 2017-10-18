<%@ Page Title="" Language="C#" MasterPageFile="~/masters/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="demo" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
</asp:Content>

<asp:Content ID="ContentContainer" ContentPlaceHolderID="HoldContainer" Runat="Server">
    <!-- 轮播 -->
    <div class="dogo-caro">
        <!-- 
            轮播项目
            图片以后从数据库中取出
            <asp:image>暂无ID 
            -->
        <div class="caro-items">
            <div class="item active">
                <a href="#"><asp:image runat="server" ImageUrl="assets/caro-img/item-1.svg" alt="caro-img-1" /></a>
            </div>
            <div class="item">
                <a href="#"><asp:image runat="server" ImageUrl="assets/caro-img/item-2.svg" alt="caro-img-2" /></a>
            </div>
            <div class="item">
                <a href="#"><asp:image runat="server" ImageUrl="assets/caro-img/item-3.svg" alt="caro-img-3" /></a>
            </div>
        </div>

        <!-- 轮播控制 -->
        <a class="caro-ctrls ctrl-left" href="javascript:void(0);">
            <i class="icon-ctrl-left"></i>
        </a>
        <a class="caro-ctrls ctrl-right" href="javascript:void(0);">
            <i class="icon-ctrl-right"></i>
        </a>

        <!-- 轮播指标 -->
        <div class="caro-index">
            <span class="index active"></span>
            <span class="index"></span>
            <span class="index"></span>
        </div>
    </div>

    <!-- 寻物启示列表 -->
    <div class="note-container">
        <div class="asidebar list">
            <div class="note-tags">

                <!--
                    数据来源于数据库
                    ID未取 
                    -->
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>校园卡</div>
                </asp:HyperLink>
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>准考证</div>
                </asp:HyperLink>
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>U盘</div>
                </asp:HyperLink>
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>钱</div>
                </asp:HyperLink><asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>书本</div>
                </asp:HyperLink>
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>手机</div>
                </asp:HyperLink>
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>钥匙</div>
                </asp:HyperLink>
                <asp:HyperLink runat="server" CssClass="tag-btn">
                    <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg"/>
                    <div>钱包</div>
                </asp:HyperLink>

                <asp:HyperLink runat="server" CssClass="tag-more-btn">
                    <div>更多常丢之物</div>
                </asp:HyperLink>
            </div>

            <div class="note-list">
                <!-- <h3>失物招领启示列表</h3> -->
                <!--
                    数据来源于数据库
                    ID未取 
                    -->
                <section class="note-1">
                    <!-- 标题 -->
                    <h3 class="title">
                        <asp:HyperLink runat="server">寻找校园卡</asp:HyperLink>
                    </h3>
                    
                    <!-- 作者 -->
                    <div class="author">
                        <%--<a href="#" class="avatar">
                            <asp:Image runat="server" ImageUrl=""/>
                        </a>--%>
                        <a href="#" class="name">小明</a>
                        <asp:Label runat="server" CssClass="date">2017-10-15</asp:Label>
                    </div>
                    
                    <!-- 内容 -->
                    <p class="content">
                        <asp:Label runat="server">本人丢失校院卡</asp:Label>
                        <asp:Image runat="server" ImageUrl=""/>
                    </p>
                    <div class="meta">
                        <asp:Label runat="server" CssClass="status">已找回</asp:Label>
                    </div>
                </section>

                <section class="note-2">
                    <h3 class="title">
                        <asp:HyperLink runat="server">寻找校园卡</asp:HyperLink>
                    </h3>
                    <div class="author">
                        <%--<a href="#" class="avatar">
                            <asp:Image runat="server" ImageUrl=""/>
                        </a>--%>
                        <a href="#" class="name">小明</a>
                        <asp:Label runat="server" CssClass="date">2017-10-15</asp:Label>
                    </div>
                    <p class="content">
                        <asp:Label runat="server">本人丢失校院卡</asp:Label>
                        <asp:Image runat="server" ImageUrl=""/>
                    </p>
                    <div class="meta">
                        <asp:Label runat="server" CssClass="status">已找回</asp:Label>
                    </div>
                </section>

                <section class="note-3">
                    <h3 class="title">
                        <asp:HyperLink runat="server">寻找校园卡</asp:HyperLink>
                    </h3>
                    <div class="author">
                        <%--<a href="#" class="avatar">
                            <asp:Image runat="server" ImageUrl=""/>
                        </a>--%>
                        <a href="#" class="name">小明</a>
                        <asp:Label runat="server" CssClass="date">2017-10-15</asp:Label>
                    </div>
                    <p class="content">
                        <asp:Label runat="server">本人丢失校院卡</asp:Label>
                        <asp:Image runat="server" ImageUrl=""/>
                    </p>
                    <div class="meta">
                        <asp:Label runat="server" CssClass="status">已找回</asp:Label>
                    </div>
                </section>

                <section class="note-4">
                    <h3 class="title">
                        <asp:HyperLink runat="server">寻找校园卡</asp:HyperLink>
                    </h3>
                    <div class="author">
                        <%--<a href="#" class="avatar">
                            <asp:Image runat="server" ImageUrl=""/>
                        </a>--%>
                        <a href="#" class="name">小明</a>
                        <asp:Label runat="server" CssClass="date">2017-10-15</asp:Label>
                    </div>
                    <p class="content">
                        <asp:Label runat="server">本人丢失校院卡</asp:Label>
                        <asp:Image runat="server" ImageUrl=""/>
                    </p>
                    <div class="meta">
                        <asp:Label runat="server" CssClass="status">已找回</asp:Label>
                    </div>
                </section>

                <section class="note-4">
                    <h3 class="title">
                        <asp:HyperLink runat="server">寻找校园卡</asp:HyperLink>
                    </h3>
                    <div class="author">
                        <%--<a href="#" class="avatar">
                            <asp:Image runat="server" ImageUrl=""/>
                        </a>--%>
                        <a href="#" class="name">小明</a>
                        <asp:Label runat="server" CssClass="date">2017-10-15</asp:Label>
                    </div>
                    <p class="content">
                        <asp:Label runat="server">本人丢失校院卡</asp:Label>
                        <asp:Image runat="server" ImageUrl=""/>
                    </p>
                    <div class="meta">
                        <asp:Label runat="server" CssClass="status">已找回</asp:Label>
                    </div>
                </section>

                <section class="note-4">
                    <h3 class="title">
                        <asp:HyperLink runat="server">寻找校园卡</asp:HyperLink>
                    </h3>
                    <div class="author">
                        <%--<a href="#" class="avatar">
                            <asp:Image runat="server" ImageUrl=""/>
                        </a>--%>
                        <a href="#" class="name">小明</a>
                        <asp:Label runat="server" CssClass="date">2017-10-15</asp:Label>
                    </div>
                    <p class="content">
                        <asp:Label runat="server">本人丢失校院卡</asp:Label>
                        <asp:Image runat="server" ImageUrl=""/>
                    </p>
                    <div class="meta">
                        <asp:Label runat="server" CssClass="status">已找回</asp:Label>
                    </div>
                </section>

                <div class="load-more">
                    <!--
                        Ajax请求 
                        -->
                    <a href="#">加载更多</a>
                </div>

            </div>
        </div>
        <div class="asidebar top">
            <div class="top">
                <h3 class="top-title">助人榜 TOP 10</h3>
                <div class="top-box">
                    <!-- 
                        数据取于数据库
                        ID未加
                        -->

                    <div class="top-1">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">48</asp:Label>
                    </div>
                    <div class="top-2">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">47</asp:Label>
                    </div>
                    <div class="top-3">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">36</asp:Label>
                    </div>
                    <div class="top-4">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">35</asp:Label>
                    </div>
                    <div class="top-5">
                        <a class="avatar"  href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">28</asp:Label>
                    </div>
                    <div class="top-6">
                        <a class="avatar"  href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">27</asp:Label>
                    </div>
                    <div class="top-7">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">26</asp:Label>
                    </div>
                    <div class="top-8">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">25</asp:Label>
                    </div>
                    <div class="top-9">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">24</asp:Label>
                    </div>
                    <div class="top-10">
                        <a class="avatar" href="#">
                            <asp:Image runat="server" ImageUrl="assets/tag-tmp.svg" AlternateText="avatar"/>
                        </a>
                        <asp:Label runat="server" CssClass="name">小明</asp:Label>
                        <asp:Label runat="server" CssClass="help-num">20</asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

