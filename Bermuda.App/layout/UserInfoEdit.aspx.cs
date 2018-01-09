using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Bermuda.Model;
using Bermuda.Bll;
using Bermuda.Common;

namespace Bermuda.App.layout
{
    public partial class UserInfoEdit : System.Web.UI.Page
    {
        private const String URL_SIGN_IN = "~/layout/SignIn.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (BaseUtil.IsNullObj(Session["User"])) // 判断用户是否登录
                {
                    Response.Redirect(URL_SIGN_IN);
                    return;
                }

                Display();
            }
        }

        // 首次加载显示的数据
        protected void Display()
        {
            DisplayEditInfo();
        }

        // 显示代修改信息
        protected void DisplayEditInfo()
        {
            User user = BaseUtil.GetEntity<User>(Session["User"]);

            List<User> list = BaseUtil.GetEntityList<User>(user);

            EditInfoList.DataSource = list;
            EditInfoList.DataBind();
            
        }

        // 更新用户昵称
        protected void UpdateNameBtn_Click(object sender, EventArgs e)
        {
            Update<String>((Button)sender, "name");
        }

        // 更新手机号
        protected void UpdatePhoneNumberBtn_Click(object sender, EventArgs e)
        {
            Update<String>((Button)sender, "phone_number");
        }

        // 更新邮箱
        protected void UpdateEmailBtn_Click(object sender, EventArgs e)
        {
            Update<String>((Button)sender, "email");
        }

        // 更新身份类型
        protected void UpdateTypeBtn_Click(object sender, EventArgs e)
        {
            Update<String>((Button)sender, "type");
        }


        /// <summary>
        /// 更新会话变量 User
        /// </summary>
        /// <param name="userId"></param>
        protected void UpdateSessionUser(Int64 userId)
        {
            List<User> list = UserService.GetUserById(userId);

            Session["User"] = BaseUtil.GetFristEntityOfList(list);
        }

        /// <summary>
        /// 更新字段值
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="btn">按钮对象</param>
        /// <param name="field">字段名</param>
        protected void Update<T>(Button btn, String field)
        {
            Int64 userId   = BaseUtil.GetEntity<User>(Session["User"]).Id; // 用户 ID

            try
            {
                String  newValue    = String.Empty; // 新值
                String  iconOkIdStr = String.Empty; // 图标控件 ID 字符串
                Boolean isOk        = false;        // 是否修改成功

                switch (field)
                {
                    case "name":

                        newValue    = GetNewValue<String>(btn, "EditName");
                        isOk        = UserService.UpdateName(userId, newValue);
                        iconOkIdStr = "IconOk1";
                        break;
                        
                    case "phone_number":

                        newValue    = GetNewValue<String>(btn, "EditPhoneNumber");
                        isOk        = UserService.UpdatePhoneNumber(userId, newValue);
                        iconOkIdStr = "IconOk2";
                        break;

                    case "email":

                        newValue    = GetNewValue<String>(btn, "EditEmail");
                        isOk        = UserService.UpdateEmail(userId, newValue);
                        iconOkIdStr = "IconOk3";
                        break;

                    case "type":

                        newValue    = GetNewValue<String>(btn, "EditType");
                        isOk        = UserService.UpdateType(userId, newValue);
                        iconOkIdStr = "IconOk4";
                        break;

                    default:
                        break;
                }

                if (isOk && !String.IsNullOrEmpty(iconOkIdStr))
                {
                    ShowIconOk(btn, iconOkIdStr); // 显现图标

                    UpdateSessionUser(userId);    // 更新会话变量
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 获取对应字段的修改值
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="btn">按钮对象</param>
        /// <param name="field">字段名</param>
        /// <returns>修改值</returns>
        protected T GetNewValue<T>(Button btn, String textBoxIdStr)
        {
            TextBox textBox = (btn.Parent.FindControl(textBoxIdStr)) as TextBox;
            object  value   = textBox.Text.Trim();

            return (T)value;
        }

        /// <summary>
        /// 显现修改成功图标
        /// </summary>
        /// <param name="btn"></param>
        protected void ShowIconOk(Button btn, String iconOkIdStr)
        {
            (btn.Parent.FindControl(iconOkIdStr)).Visible = true;
        }
    }
}