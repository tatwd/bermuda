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
    public partial class SignUp : System.Web.UI.Page
    {
        // 验证码
        private static int Code { set; get; }

        // 倒计时 60s
        private static int second = 60;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SendVerifyCode_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            if (IsValid)
            {
                try
                {
                    Code = random.Next(100000, 999999);                        // 随机产生 6 位数的验证码

                    string toEmail = Email.Text.Trim();                        // 获取注册人邮箱
                    string title   = "[百慕大]欢迎您注册百慕大，点击查看验证码";
                    string content = String.Format("您的验证码是：{0}", Code);

                    MailUtil.SendMail(title, content, toEmail);             // 发送邮件

                    TimerSend.Enabled      = true;
                    SendVerifyCode.Enabled = false;                            // 计时状态禁用按钮点击
                }
                catch (Exception ex)
                {
                    PromptInfo.Text = ex.Message;
                }
            }

        }

        /// <summary>
        /// 注册按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            List<string> list = GetSignUpInfo();

            User user = new User()
            {
                Name  = list[0],
                Email = list[1],
                Pwd   = list[2]
            };

            try
            {
                int code = !String.IsNullOrEmpty(VerifyCode.Text.Trim()) ? int.Parse(VerifyCode.Text.Trim()) : 0;

                if ( code == Code) // 判断验证码是否正确
                {
                    bool isOk = UserService.SignUp(user);

                    PromptInfo.Text = isOk ? "注册成功，马上登录！" : "注册失败！";
                }
                else
                {
                    PromptInfo.Text = "验证码错误";
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
            finally
            {
                StopTimer(); // 停止倒计时
            }
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

            SendVerifyCode.Text = String.Format("{0} 秒后重发", second);
            second--;
        }

        /// <summary>
        /// 停止验证码倒计时
        /// </summary>
        protected void StopTimer()
        {
            TimerSend.Enabled      = false;
            SendVerifyCode.Text    = "重新发送";
            SendVerifyCode.Enabled = true;
            second                 = 60;
        }

        /// <summary>
        /// 获取注册的信息
        /// </summary>
        /// <returns>字符串列表</returns>
        protected List<string> GetSignUpInfo()
        {
            List<string> list = new List<string>()
            {
                Username.Text.Trim(),
                Email.Text.Trim(),
                Password.Text.Trim()
            };

            return list;
        }
    }
}