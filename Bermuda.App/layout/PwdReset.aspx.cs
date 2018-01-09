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
    public partial class PwdReset : System.Web.UI.Page
    {

        // 验证码
        private static int Code { set; get; }

        // 倒计时 60s
        private static int second = 60;

        private const String URL_SIGN_IN = "~/layout/SignIn.aspx";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

        }

        protected void NextStepBtn_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            String step = GetStep();

            switch (step)
            {
                case "1": // 第 1 步 - 输邮箱

                    User user = GetUserByEmail();

                    if (user != null)
                    {
                        HidePanel(InputEmailPanel);
                        ShowPanel(InputCodePanel);
                        SetStep("2");
                    }
                    else
                    {
                        PromptInfo.Text = "你的邮箱有问题！";
                    }

                    break;

                case "2": // 第 2 步 - 验证码

                    if (VerifyCode())
                    {
                        HidePanel(InputCodePanel);
                        ShowPanel(ResetPwdPanel);
                        SetStep("3");
                    }
                    else
                    {
                        PromptInfo.Text = "验证码错误";
                    }

                    break;

                case "3": // 第 3 步 - 改密码

                    ResetPwd(); // 重设密码

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 重设密码
        /// </summary>
        protected void ResetPwd()
        {
            String newPwd = NewPwd.Text.Trim();

            try
            {
                //User user = (User)ViewState["TmpUser"]; // 进行到这，此变量不为空，不要判断为空

                User user = GetUserByEmail();

                Boolean isOk = UserService.UpdatePwd(user.Id, newPwd);

                if (isOk)
                {
                    Response.Redirect(URL_SIGN_IN);
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }


        /// <summary>
        /// 隐藏 Panel
        /// </summary>
        /// <param name="panel">Panel 控件对象</param>
        protected void HidePanel(Panel panel)
        {
            panel.Visible = false;
        }

        /// <summary>
        /// 显示 Panel
        /// </summary>
        /// <param name="panel">Panel 控件对象</param>
        protected void ShowPanel(Panel panel)
        {
            panel.Visible = true;
        }

        /// <summary>
        /// 获取步骤
        /// </summary>
        /// <returns>步骤字符串</returns>
        protected String GetStep()
        {
            String _step = NextStepBtn.Attributes["data-step"];
            return !String.IsNullOrEmpty(_step) ? _step : "0";
        }

        /// <summary>
        /// 设置步骤
        /// </summary>
        /// <param name="step">步骤字符串</param>
        protected void SetStep(String step)
        {
            NextStepBtn.Attributes["data-step"] = step;
        }

        /// <summary>
        /// 核对验证码
        /// </summary>
        /// <returns></returns>
        protected Boolean VerifyCode()
        {
            Int64 inputCode = Convert.ToInt32(InputCode.Text.Trim());

            if (inputCode == Code)
            {
                Code = 0; // 重置验证码
                return true;
            }
            else
            {
                return false;
            }

            // return inputCode == Code ? true : false;
        }

        /// <summary>
        /// 通过邮箱获取用户对象
        /// </summary>
        /// <returns>用户对象或 null</returns>
        protected User GetUserByEmail()
        {
            string toEmail = InputEmail.Text.Trim();

            User user = UserService.GetUserByEmail(toEmail);

            return user != null ? user : null;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        protected Boolean SendCode()
        {
            Boolean isOk = false;
            Random random = new Random();

            try
            {
                Code = random.Next(100000, 999999);                        // 随机产生 6 位数的验证码

                string toEmail = GetUserByEmail().Email;                   // 获取注册人邮箱

                string title   = "[百慕大]您正在重设密码，点击查看验证码";
                string content = String.Format("您的验证码是：{0}", Code);

                MailUtil.SendMail(title, content, toEmail);                // 发送邮件

                TimerSend.Enabled   = true;
                SendCodeBtn.Enabled = false;                               // 计时状态禁用按钮点击

                isOk = true;
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }

            return isOk;
        }

        /// <summary>
        /// 验证码重新发送计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TimerSend_Tick(object sender, EventArgs e)
        {
            if (second == 0)
            {
                StopTimer();
                return;
            }

            SendCodeBtn.Text = String.Format("{0} 秒后重发", second);
            second--;
        }

        /// <summary>
        /// 停止验证码倒计时
        /// </summary>
        protected void StopTimer()
        {
            TimerSend.Enabled = false;
            SendCodeBtn.Text = "重新发送";
            SendCodeBtn.Enabled = true;
            second = 60;
        }

        protected void SendCodeBtn_Click(object sender, EventArgs e)
        {
            SendCode(); // 重发验证码
        }
    }
}