<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="UserInfoEdit.aspx.cs" Inherits="Bermuda.App.layout.UserInfoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.title = '修改个人资料'
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HoldContainer" runat="server">
     <div class="container">
        <div class="edit-info-container">

            <h2 class="text-center edit-head">修改个人资料</h2>

            <asp:UpdatePanel runat="server" class="edit-main">
                <ContentTemplate>
                    <asp:ListView runat="server" ID="EditInfoList">
                        <LayoutTemplate>
                            <div class="edit-items">
                                <div id="itemPlaceHolder" runat="server"></div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="item justify-center edit-avatar">
                                <span>
                                    <img src='<%# Eval("Avatar") %>' alt="avatar"/>
                                </span>
                            </div>

                            <div class="item edit-name">
                                <span class="col-3 fs-16 text-right self-start margin-tb-2">昵称：</span>
                                <div class="col-9 flex-col">
                                    <div class="col-8 flex-box items-center">
                                        <asp:TextBox ID="EditName" runat="server" Text='<%# Eval("Name") %>' CssClass="update-text" placeholder="昵称" Enabled="false" data-updated="false"></asp:TextBox>
                                        <i id="IconOk1" class="icon-ok" runat="server" visible="false"></i>
                                        <span><a class="fs-14 show-edit-btn" href="javascript:void(0);">修改</a></span>
                                    </div>
                                    <div class="col-2 edit-btns">
                                        <span><asp:Button ID="UpdateNameBtn" CssClass="submit-btn" runat="server" Text="确定" OnClick="UpdateNameBtn_Click"/></span>
                                        <a class="fs-14 cancel-btn" href="javascript:void(0);">取消</a>
                                    </div>
                                </div>
                            </div>

                            <div class="item edit-phone">
                                <span class="col-3 fs-16 text-right self-start margin-tb-2">手机号：</span>
                                <div class="col-9 flex-col">
                                    <div class="col-8 flex-box items-center">
                                        <asp:TextBox ID="EditPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>' CssClass="update-text" placeholder="手机号" Enabled="false"></asp:TextBox>
                                        <i id="IconOk2" class="icon-ok" runat="server" visible="false"></i>
                                        <span><a class="fs-14 show-edit-btn" href="javascript:void(0);">修改</a></span>
                                    </div>
                                    <div class="col-2 edit-btns">
                                        <span><asp:Button ID="UpdatePhoneNumberBtn" CssClass="submit-btn" runat="server" Text="确定" OnClick="UpdatePhoneNumberBtn_Click"/></span>
                                        <a class="fs-14 cancel-btn" href="javascript:void(0);">取消</a>
                                    </div>
                                </div>
                            </div>

                            <div class="item edit-email">
                                <span class="col-3 fs-16 text-right self-start margin-tb-2">邮箱：</span>
                                <div class="col-9 flex-col">
                                    <div class="col-8 flex-box items-center">
                                        <asp:TextBox ID="EditEmail" runat="server" Text='<%# Eval("Email") %>' CssClass="update-text"  placeholder="邮箱" TextMode="Email" Enabled="false"></asp:TextBox>
                                        <i id="IconOk3" class="icon-ok" runat="server" visible="false"></i>
                                        <span><a class="fs-14 show-edit-btn" href="javascript:void(0);">修改</a></span>
                                    </div>
                                    <div class="col-2 edit-btns">
                                        <span><asp:Button ID="UpdateEmailBtn" CssClass="submit-btn" runat="server" Text="确定" OnClick="UpdateEmailBtn_Click"/></span>
                                        <a class="fs-14 cancel-btn" href="javascript:void(0);">取消</a>
                                    </div>

                                </div>
                            </div>

                            <div class="item edit-type">
                                <span class="col-3 fs-16 text-right self-start margin-tb-2">身份类型：</span>
                                <div class="col-9 flex-col">
                                    <div class="col-8 flex-box items-center">
                                        <asp:TextBox ID="EditType" runat="server" Text='<%# Eval("Type") %>' CssClass="update-text" placeholder="身份类型" Enabled="false"></asp:TextBox>
                                        <i id="IconOk4" class="icon-ok" runat="server" visible="false"></i>
                                        <span><a class="fs-14 show-edit-btn" href="javascript:void(0);">修改</a></span>
                                    </div>
                                    <div class="col-2 edit-btns">
                                        <span><asp:Button ID="UpdateTypeBtn" runat="server" CssClass="submit-btn"  Text="确定" OnClick="UpdateTypeBtn_Click"/></span>
                                        <a class="fs-14 cancel-btn" href="javascript:void(0);">取消</a>
                                    </div>
                                </div>
                        
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script>
        var ManageEditStuff = function () {
            var editItems = document.querySelector('.edit-items');

            if (!editItems) {
                return;
            }

            var items     = editItems.querySelectorAll('.item');
            var itemsArr  = Array.prototype.slice.call(items);

            itemsArr.forEach(function (item) {
                var textBox = item.querySelector('input');
                var showEditBtn = item.querySelector('.show-edit-btn');
                var cancelBtn = item.querySelector('.cancel-btn');
                var noneBlock = item.querySelector('.edit-btns');

                if (!textBox || !showEditBtn || !noneBlock) {
                    return;
                }

                showEditBtn.addEventListener('click', function () {

                    textBox.removeAttribute('disabled');
                    textBox.focus();
                    noneBlock.classList.add('show-btn');
                    showEditBtn.classList.add('none-block');

                }, false);

                var olderValue = textBox.value;

                cancelBtn.addEventListener('click', function () {
                    textBox.disabled = true;
                    textBox.value = olderValue; // 还原值

                    noneBlock.classList.remove('show-btn');
                    showEditBtn.classList.remove('none-block');
                }, false);

            });
        };

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ManageEditStuff);
        
        ManageEditStuff();
    </script>
</asp:Content>
