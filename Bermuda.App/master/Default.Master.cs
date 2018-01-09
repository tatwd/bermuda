using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bermuda.Model;

namespace Bermuda.App.master
{
    public partial class Default : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowUserPacel(); // 显示用户面板并设置头像
            }
        }

        /// <summary>
        /// 注销退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SignOutBtn_Click(object sender, EventArgs e)
        {
            Session["User"] = null;

            DisplayUserProfile(false); // 隐藏用户面板

            // SetCookieOfIsSignIn(false); // 改变登录状态的 cookie

            Response.Redirect(Request.Url.ToString()); // 刷新当前页面
        }

        /// <summary>
        /// 发布按钮事件，未登录时跳转到登录页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PublishBtn_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/layout/SignIn.aspx");
            }
            else
            {
                Response.Redirect("~/layout/Publish.aspx");
            }
        }

        /// <summary>
        /// 显示用户面板并设置头像
        /// </summary>
        protected void ShowUserPacel()
        {
            if (Session["User"] != null)
            {
                DisplayUserProfile(true); // 显示用户面板

                User user = (User)Session["User"];
                UserAvatar.ImageUrl = user.Avatar; // 设置用户头像
            }
        }

        /// <summary>
        /// 显示用户面板
        /// </summary>
        /// <param name="visible">true: 显示, false: 隐藏</param>
        protected void DisplayUserProfile(bool visible)
        {
            UserProfile.Visible = visible;
        }

        /// <summary>
        /// 使用 Cookie 保存登录状态
        /// </summary>
        /// <param name="boolValue">布尔值</param>
        protected void SetCookieOfIsSignIn(bool boolValue)
        {
            HttpCookie isSignIn = Request.Cookies["IsSignIn"];

            if (isSignIn == null)
            {
                //HttpCookie isSignIn = new HttpCookie("IsSignIn")
                //{
                //    Value = boolValue.ToString()
                //};

                isSignIn.Value = boolValue.ToString();

                isSignIn.Expires = DateTime.Now.AddHours(0.5); // 设置过期时间为 30 分钟

                Response.Cookies.Add(isSignIn);
            }
            else
            {
                isSignIn.Value = boolValue.ToString();

                isSignIn.Expires = DateTime.Now.AddHours(0.5); // 设置过期时间为 30 分钟

                Response.Cookies.Set(isSignIn); // 更新
            }
        }
    }
}