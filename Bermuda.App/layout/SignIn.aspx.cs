using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bermuda.Model;
using Bermuda.Bll;

namespace Bermuda.App.layout
{
    public partial class SignIn : System.Web.UI.Page
    {
        User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCookie(); // 读取 Cookie
            }
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (Session["User"] != null) // 已经登录
                {
                    user = (User)Session["User"];
                    PromptInfo.Text = String.Format("{0}已经登录！", user.Name);
                    return;
                }

                try
                {
                    if (SignInBmd()) // 登录成功
                    {
                        Session["User"] = user;
                        PromptInfo.Text = ""; // 情空提示框

                        SetCookie(NameMail.Text.Trim(), Password.Text.Trim()); // 设置 Cookie

                        // SetCookieOfIsSignIn(true);

                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        PromptInfo.Text = "用户名或密码错误";

                        // SetCookieOfIsSignIn(false);
                    }
                }
                catch (Exception ex)
                {
                    PromptInfo.Text = ex.Message;

                    // SetCookieOfIsSignIn(false);
                }

            }
        }

        /// <summary>
        /// 获取登录的信息
        /// </summary>
        /// <returns>字符串列表</returns>
        protected List<string> GetSignInfo()
        {
            List<string> list = new List<string>()
            {
                NameMail.Text.Trim(),
                Password.Text.Trim()
            };

            return list;
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <returns>布尔值</returns>
        protected bool SignInBmd()
        {
            List<string> list= GetSignInfo();

            user = UserService.SignIn(list[0], list[1]);

            return user != null ? true : false;
        }

        /// <summary>
        /// 读取 Cookie 并设置到登录框
        /// </summary>
        protected void GetCookie()
        {
            HttpCookie cookie = Request.Cookies["SignInfo"];

            if (cookie != null)
            {
                NameMail.Text = Server.HtmlEncode(cookie.Values["NameMail"]);
                Password.Text = Server.HtmlEncode(cookie.Values["Password"]);
            }
        }

        /// <summary>
        /// 设置 Cookie
        /// </summary>
        /// <param name="nameMail">用户名或密码</param>
        /// <param name="password">密码</param>
        protected void SetCookie(string nameMail, string password)
        {
            if (RememberMeCb.Checked)
            {
                HttpCookie cookie = new HttpCookie("SignInfo");

                cookie.Values["NameMail"] = nameMail;
                cookie.Values["Password"] = password;

                cookie.Expires = DateTime.Now.AddHours(0.5); // 设置过期时间为 30 分钟

                Response.Cookies.Add(cookie);
            }
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