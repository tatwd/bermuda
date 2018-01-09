using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Bermuda.Model;
using Bermuda.Bll;
using Bermuda.Common;

namespace Bermuda.App.layout
{
    public partial class CurrentDetail : System.Web.UI.Page
    {

        private const String URL_HOME   = "~";
        private const String URL_SIGNIN = "~/layout/SignIn.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }

        /// <summary>
        /// 首次加载显示数据
        /// </summary>
        protected void Display()
        {
            DisplayCurrentDetail();
            DisplayCurrentCmnt  ();
        }

        /// <summary>
        /// 显示动态的详细内容
        /// </summary>
        protected void DisplayCurrentDetail()
        {
            try
            {
                DataTable data = GetDataOfCurrent();

                if (!IsNullObj(data))
                {
                    LvCurrentDetail.DataSource = data;
                    LvCurrentDetail.DataBind();
                }
                else
                {
                    Response.Redirect(URL_HOME); // 失败跳转首页
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 通过 ID 获取对应动态
        /// </summary>
        /// <returns>数据表或 null</returns>
        protected DataTable GetDataOfCurrent()
        {
            Int64 currentId = GetCurrentId();

            if (currentId >= 0)
            {
                return CurrentService.GetCurrentById(currentId);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询字符串获取动态 ID
        /// </summary>
        /// <returns>动态 ID</returns>
        protected Int64 GetCurrentId()
        {
            String _currentId = Request.QueryString["id"];

            return !String.IsNullOrEmpty(_currentId) ? Convert.ToInt64(_currentId) : 0;
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns>布尔值</returns>
        protected bool IsSignIn()
        {
            return !IsNullObj(Session["User"]) ? true : false;
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="session">为空返回 true, 否次返回 false</param>
        /// <returns></returns>
        protected bool IsNullObj(object session)
        {
            return session == null ? true : false;
        }

        /// <summary>
        /// 显示动态评论
        /// </summary>
        protected void DisplayCurrentCmnt()
        {
            try
            {
                Int64 currentId = GetCurrentId();

                if (currentId == 0)
                {
                    Response.Redirect(URL_HOME);
                    return;
                }

                DataTable data = CurrentCmntService.GetCurrentCmntByCurrentId(currentId); // 通过评论 ID 查评论数据

                if (data != null)
                {
                    LvComment.DataSource = data;
                    LvComment.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示动态评论的回复
        /// </summary>
        /// <param name="repeater">回复所在的控件对象</param>
        /// <param name="cmntId">评论 ID</param>
        protected void DisplayCurrentCmntReply(Repeater repeater, Int64 cmntId)
        {
            try
            {
                if (cmntId > 0)
                {
                    DataTable data = CurrentReplyService.GetCurrentReplyByCmntId(cmntId); // 通过回复 ID 查回复数据

                    if (data != null)
                    {
                        repeater.DataSource = data;
                        repeater.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                String msg = String.Format("获取评论 ID 为 {0} 的回复失败！ -> DisplayNoticeCmntReply()", cmntId);

                throw new Exception(msg);
            }
        }

        // 绑定回复
        protected void LvComment_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    HiddenField hiddenCmntId = e.Item.FindControl("HiddenCmntId") as HiddenField;
                    Repeater reptCmntReply = e.Item.FindControl("ReptCmntReply") as Repeater;

                    string _cmntId = hiddenCmntId.Value;
                    Int64 cmntId = !String.IsNullOrEmpty(_cmntId) ? Int64.Parse(_cmntId) : 0; // 获取评论编号

                    DisplayCurrentCmntReply(reptCmntReply, cmntId); // 显示回复数据
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        // 发评论
        protected void CmntBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string cmntText = CmntText.Text.ToString();
                Int64 currentId = GetCurrentId();

                if (!IsSignIn())
                {
                    Response.Redirect(URL_SIGNIN);
                    return;
                }

                User user = (User)Session["User"];

                if (currentId != 0)
                {
                    // 构建待插入对象
                    CurrentCmnt cmnt = new CurrentCmnt()
                    {
                        CurrentId = currentId,
                        UserId = user.Id,
                        Contents = cmntText,
                        CmntDate = DateTime.Now.ToLocalTime()
                    };

                    bool isOk = CurrentCmntService.AddCurrentCmnt(cmnt);

                    if (isOk)
                    {
                        DisplayCurrentCmnt(); // 从新显示评论区
                    }
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        // 发回复
        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            Button replyBtn = (Button)sender;
            HiddenField hiddenCmntId = replyBtn.Parent.FindControl("HiddenCmntId") as HiddenField;
            HiddenField hiddenAimsId = replyBtn.Parent.FindControl("HiddenAimsId") as HiddenField;
            TextBox replyText = replyBtn.Parent.FindControl("ReplyText") as TextBox;

            Panel cmntReplyPanel = replyBtn.Parent as Panel;
            Repeater repeateReply = cmntReplyPanel.Parent.FindControl("ReptCmntReply") as Repeater;

            try
            {
                if (!IsSignIn())
                {
                    Response.Redirect(URL_SIGNIN);
                    return;
                }

                User user = (User)Session["User"];

                CurrentReply currentReply = new CurrentReply()
                {
                    CmntId = Int64.Parse(hiddenCmntId.Value),
                    UserId = user.Id,
                    Contents = replyText.Text.Trim(),
                    ReplyDate = DateTime.Now.ToLocalTime(),
                };

                string _aimsId = hiddenAimsId.Value; // 获取回复目标编号

                if (!String.IsNullOrEmpty(_aimsId))
                {
                    Int64 aimsId = Int64.Parse(_aimsId);
                    currentReply.AimsId = aimsId;
                }

                // 添加回复记录到数据库
                bool isOk = CurrentReplyService.AddCurrentReply(currentReply);

                // 刷新评论区域
                if (isOk)
                {
                    replyText.Text = ""; // 清空输入框

                    DisplayCurrentCmntReply(repeateReply, currentReply.CmntId);
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        // 收藏动态
        protected void StarBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                if (!IsSignIn())
                {
                    Response.Redirect(URL_SIGNIN);
                    return;
                }

                Int64 userId = GetUserId();
                Int64 currentId = GetCurrentId();

                if (userId != 0 || currentId != 0)
                {
                    CurrentStar currentStar = new CurrentStar()
                    {
                        CurrentId = currentId,
                        UserId = userId,
                        StarDate = DateTime.Now.ToLocalTime()
                    };

                    Boolean isOk = CurrentStarService.AddCurrentStar(currentStar);

                    if (isOk)
                    {
                        btn.Text = "收藏成功";
                    }
                }

            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 获取用户 ID
        /// </summary>
        /// <returns></returns>
        protected Int64 GetUserId()
        {
            return IsSignIn() ? BaseUtil.GetEntity<User>(Session["User"]).Id : 0;
        }
    }
}