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
    public partial class NoticeDetail : System.Web.UI.Page
    {
        private const String URL_SIGNIN = "~/layout/SignIn.aspx"; // 登录页路径

        protected void Page_Load(object sender, EventArgs e)
        {
            LockInput();

            if (!IsPostBack)
            {
                Display();
            }
        }

        /// <summary>
        /// 显示所以数据 - 首次加载时调用
        /// </summary>
        protected void Display()
        {
            DisplayNoticeDetail();
            DisplayNoticeCmnt  ();
        }

        /// <summary>
        /// 显示启示详情
        /// </summary>
        protected void DisplayNoticeDetail()
        {
            try
            {
                long id = GetNoticeId();

                if (id == 0)
                {
                    Response.Redirect("~/");
                    return;
                }

                DataTable data = NoticeService.SelectNoticeById(id);

                if (data != null)
                {
                    LvNoticeDetail.DataSource = data;
                    LvNoticeDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示启示评论
        /// </summary>
        protected void DisplayNoticeCmnt()
        {
            try
            {
                long id = GetNoticeId();

                if (id == 0)
                {
                    Response.Redirect("~/");
                    return;
                }

                DataTable data = NoticeCmntService.GetNoticeCmntById(id);

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
        /// 显示失物招领启示评论的回复
        /// </summary>
        /// <param name="repeater">回复所在的控件对象</param>
        /// <param name="cmntId">评论 ID</param>
        protected void DisplayNoticeCmntReply(Repeater repeater, Int64 cmntId)
        {
            try
            {
                if (cmntId > 0)
                {
                    DataTable data = NoticeReplyService.GetNoticeReplyById(cmntId);

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

        /// <summary>
        /// 评论回复绑定事件 - 绑定评论时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LvComment_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    HiddenField hiddenCmntId  = e.Item.FindControl("HiddenCmntId")  as HiddenField;
                    Repeater    reptCmntReply = e.Item.FindControl("ReptCmntReply") as Repeater;

                    string _cmntId = hiddenCmntId.Value;
                    long   cmntId  = !String.IsNullOrEmpty(_cmntId) ? long.Parse(_cmntId) : 0; // 获取评论编号

                    DisplayNoticeCmntReply(reptCmntReply, cmntId);
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 评论按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmntBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string cmntText = CmntText.Text.ToString();
                Int64 noticeId = GetNoticeId();

                if (!IsSignIn())
                {
                    Response.Redirect(URL_SIGNIN);
                    return;
                }

                User user = (User)Session["User"];

                if (noticeId != 0)
                {
                    // 构建待插入对象
                    NoticeCmnt cmnt = new NoticeCmnt()
                    {
                        NoticeId = noticeId,
                        UserId   = user.Id,
                        Contents = cmntText,
                        CmntDate = DateTime.Now.ToLocalTime()
                    };

                    bool isOk = NoticeCmntService.AddNoticeCmnt(cmnt);

                    if (isOk)
                    {
                        DisplayNoticeCmnt(); // 从新显示评论区
                    }
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 提交评论回复按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            Button      replyBtn     = (Button)sender;
            HiddenField hiddenCmntId = replyBtn.Parent.FindControl("HiddenCmntId") as HiddenField;
            HiddenField hiddenAimsId = replyBtn.Parent.FindControl("HiddenAimsId") as HiddenField;
            TextBox     replyText    = replyBtn.Parent.FindControl("ReplyText")    as TextBox;

            Panel       cmntReplyPanel = replyBtn.Parent as Panel;
            Repeater    repeateReply   = cmntReplyPanel.Parent.FindControl("ReptCmntReply") as Repeater;

            try
            {
                if (!IsSignIn())
                {
                    Response.Redirect(URL_SIGNIN);
                    return;
                }

                User user = (User)Session["User"];

                NoticeReply noticeReply = new NoticeReply()
                {
                    CmntId    = Int64.Parse(hiddenCmntId.Value),
                    UserId    = user.Id,
                    Contents  = replyText.Text.Trim(),
                    ReplyDate = DateTime.Now.ToLocalTime(),
                };

                string _aimsId = hiddenAimsId.Value; // 获取回复目标编号

                if (!String.IsNullOrEmpty(_aimsId))
                {
                    Int64 aimsId = Int64.Parse(_aimsId);
                    noticeReply.AimsId = aimsId;
                }

                // 添加回复记录到数据库
                bool isOk = NoticeReplyService.AddNoticeReply(noticeReply);

                // 刷新评论区域
                if (isOk)
                {
                    replyText.Text = ""; // 清空输入框

                    DisplayNoticeCmntReply(repeateReply, noticeReply.CmntId);
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }

        }

        /// <summary>
        /// 查询字符串操作 - 获取启示编号
        /// </summary>
        /// <returns>启示编号</returns>
        protected long GetNoticeId()
        {
            try
            {
                // 注意类型转换
                long id = !String.IsNullOrEmpty(Request.QueryString["id"]) ? long.Parse(Request.QueryString["id"]) : 0;

                return id;
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
                return 0;
            }
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns>布尔值</returns>
        protected bool IsSignIn()
        {
            return Session["User"] != null ? true : false;
        }
        
        /// <summary>
        /// 未登录时，锁定输入框
        /// </summary>
        protected void LockInput()
        {
            if (!IsSignIn())
            {
                CmntText.Enabled = false;
            }
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        protected void Reflash()
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void TraceBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                if (!IsSignIn())
                {
                    return;
                }

                Int64 noticeId = GetNoticeId();
                Int64 userId = GetUserId();

                if (noticeId != 0 || userId!= 0)
                {
                    NoticeTrace trace = new NoticeTrace()
                    {
                        NoticeId = noticeId,
                        UserId = userId,
                        TraceDate = DateTime.Now.ToLocalTime()
                    };

                    bool isOk = NoticeTraceService.AddNoticeTrace(trace);

                    if (isOk)
                    {
                        // Int64 traceCount = NoticeService.GetFieldValue<Int64>(noticeId, "trace_count");

                        btn.Text = "已追踪";
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