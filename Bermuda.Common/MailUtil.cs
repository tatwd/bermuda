using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Bermuda.Common
{
    /// <summary>
    /// 邮件工具类 - 定义了一些邮件相关的方法
    /// </summary>
    public class MailUtil
    {
        // 从配置文件中读取发件人邮箱及 SMTP 服务器密码
        //
        // 注意配置名
        //
        private static readonly string Email   = ConfigurationManager.AppSettings["Email"].ToString();
        private static readonly string SmtpPwd = ConfigurationManager.AppSettings["SmtpPwd"].ToString();

        /// <summary>
        /// 发送邮件 - 基于 SMTP 服务
        /// </summary>
        /// <param name="title">邮件标题</param>
        /// <param name="content">内容</param>
        /// <param name="toEmail">收件人邮箱</param>
        public static void SendMail(string title, string content, string toEmail)
        {
            // 获取 smtp 服务器地址 
            // eg. smtp.qq.com
            string smtpHost = String.Format("smtp.{0}", Email.Substring(Email.IndexOf('@') + 1));

            SmtpClient client = new SmtpClient(smtpHost, 25);

            client.EnableSsl             = true;
            client.UseDefaultCredentials = false;
            client.Credentials           = new NetworkCredential(Email, SmtpPwd);
            client.DeliveryMethod        = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage(Email, toEmail, title, content);

            message.IsBodyHtml      = false;
            message.BodyEncoding    = Encoding.GetEncoding("UTF-8");
            message.SubjectEncoding = Encoding.GetEncoding("UTF-8");
            message.Priority        = MailPriority.High;              // 指定邮件优先级

            try
            {
                client.Send(message); // 开始发送
            }
            catch (Exception)
            {
                throw new Exception("发送验证码失败：Bll.Mail.MailService.SendMail()");
            }
        }
    }
}
