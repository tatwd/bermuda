<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentEdit.aspx.cs" Inherits="Bermuda.App.layout.CurrentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>动态编辑页</title>
    <link href="../dist/css/dogo.min.css" rel="stylesheet" />
</head>
<body>
    <form id="CurrentEditForm" runat="server">
    <div>
        <!-- Ajax 控件管理 -->
        <asp:ScriptManager ID="PageScriptManager" runat="server"></asp:ScriptManager>
        
        <div class="flex-box">
            <div class="col-2 current-logo">
                <a href="/">
                    <img src="../assets/logo.svg" alt="bmd-logo"/>
                </a>
            </div>
            <div class="col-8 editor-container">
                <div class="text-center editor-header">
                    <h2>寻找你的寻找</h2>
                </div>
                <div class="input-title">
                    <div class="flex-box">
                        <asp:TextBox ID="CurrentTitleInput" CssClass="input-block" runat="server" TextMode="MultiLine" placeholder="标题" Rows="1"></asp:TextBox>
                    </div>
                </div>
                <div class="rich-editor">
                    <!-- 初始化富文本编辑器 -->
                    <div id="wang-editor">
                        <p>请输入内容</p>
                    </div>

                    <!-- 保存动态的内容，以传到服务器 -->
                    <asp:TextBox ID="CurrentContent" CssClass="none-block" TextMode="MultiLine" runat="server"></asp:TextBox>

                    <script src="../assets/rich-editor/wang-editor/dist/wangEditor.min.js"></script>
                    <script>
                        var Eidtor = window.wangEditor;

                        var editor = new Eidtor('#wang-editor');

                        editor.customConfig.uploadImgShowBase64 = true;   // 使用 base64 保存图片
                        // editor.customConfig.withCredentials = true

                        // 自定义配置颜色（字体颜色、背景色）
                        editor.customConfig.colors = ['#000000', '#eeece0', '#1c487f', '#4d80bf', '#c24f4a', '#8baa4a', '#7b5ba1', '#46acc8', '#f9963b', '#ffffff'];

                        editor.customConfig.menus = [
                            'head',           // 标题
                            'bold',           // 粗体
                            'italic',         // 斜体
                            'underline',      // 下划线
                            'strikeThrough',  // 删除线
                            'foreColor',      // 文字颜色
                            //'backColor',    // 背景颜色
                            'link',           // 插入链接
                            //'list',         // 列表
                            'justify',        // 对齐方式
                            'quote',          // 引用
                            'emoticon',       // 表情
                            'image',          // 插入图片
                            //'table',        // 表格
                            //'video',        // 插入视频
                            //'code',         // 插入代码
                            'undo',           // 撤销
                            'redo'            // 重复
                        ];

                        var $textarea = document.querySelector('#CurrentContent');

                        editor.customConfig.onchange = function (html) {
                            $textarea.value = html; // 监控变化，同步更新到 textarea
                        };

                        editor.create();

                        // 初始化 textarea 的值
                        $textarea.value = editor.txt.html();

                        // custom style by js

                        var textContainer = document.querySelector('.w-e-text-container');
                        var toolBar = document.querySelector('.w-e-toolbar');

                        textContainer.style.border = '0px';
                        textContainer.style.borderRadio = '3px';
                        textContainer.style.height = '100%';
                        toolBar.style.border = 'none';

                    </script>
                </div>
            </div>
            <asp:UpdatePanel ID="UpPubCurrent" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server" class="col-2 current-pub-container">
                <ContentTemplate>
                    
                    <asp:UpdatePanel ID="UpPubBtn" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" class="pub-btn">
                        <ContentTemplate>
                            <button id="pub-current-btn">发表</button>
                            <%--<script>
                                var pubBtn = $get('pub-current-btn');
                                var textarea = $get('CurrentContent');

                                textarea.onchange = function () {
                                    pubBtn.removeAttribute("disabled");;
                                };

                            </script>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="select-topic">
                        <i class="icon-angle-top icon"></i>
                        <div class="title">
                            <span class="fs-14">选择话题能更好地分享你的动态哦！你最多可以选择 3 个话题。</span>
                        </div>
                        <div class="selected-items"></div>
                        <div class="search-input">
                            <div class="flex-box">
                                <asp:TextBox ID="SearchTopic" runat="server" TextMode="Search" placeholder="搜索话题" autofocus autocomplete="off"></asp:TextBox>
                            </div>
                            
                            <div class="search-items">
                                <asp:ListBox ID="LbTopic" runat="server" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                        </div>
                        
                        <div class="text-center submit-btn">
                            <span><button class="cancel-btn">取消</button></span>
                            <span><asp:Button ID="SubmitCurrent" runat="server" OnClick="SubmitCurrent_Click" Text="确定"/></span>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- 提示信息 -->
        <div class="prompt text-center"><asp:Label runat="server" ID="PromptInfo"></asp:Label></div>
    </div>
    </form>
</body>
</html>
<script src="../dist/js/dogo.min.js"></script>
