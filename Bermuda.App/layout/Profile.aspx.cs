using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Bermuda.Model;
using Bermuda.Bll;

namespace Bermuda.App.layout
{
    public partial class Profile : System.Web.UI.Page
    {
        protected string ActiveControlId = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Display(); // display all data
            }

            ActiveControlId = GetActiveControlId(); // 获取初始显示控件 ID
        }

        /// <summary>
        /// 展示所有需展示的数据，首次加载时调用
        /// </summary>
        protected void Display()
        {
            DisplayUserInfo    ();
            DisplayNoticeCount ();
            DisplayCurrentCount();
            // DisplayGoodsCount  (); // maybe delete it!
            DisplayHelpingCount();
            DisplayGetbackCount();
            DisplayNoticeList  ();
            DisplayCurrentList ();
        }

        /// <summary>
        /// 展示用户信息
        /// </summary>
        protected void DisplayUserInfo()
        {
            try
            {
                List<User> list   = new List<User>();
                Int64      userId = GetUserId();

                if (userId == -1) // -1 表示既没有传参又没有用户登录
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }
                else
                {
                    list = UserService.GetUserById(userId);
                }

                if (list != null)
                {
                    ListUserInfo.DataSource = list;
                    ListUserInfo.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 展示用户发布的启示数量并显示
        /// </summary>
        protected void DisplayNoticeCount()
        {
            try
            {
                Int64 userId = GetUserId();

                if (userId == -1) // 无用户登录且 URL 不传参数
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }

                // 获取用户的发布的启示数量
                Int32 count = NoticeService.GetNoticeCountOfUser(userId);

                NoticeCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 展示用户发布的动态数量
        /// </summary>
        protected void DisplayCurrentCount()
        {
            try
            {
                Int64 userId = GetUserId();

                if (userId == -1)
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }

                // 获取用户发布的动态数量
                Int32 count = CurrentService.GetCurrentCountOfUser(userId);

                CurrentCount.Text = count.ToString();
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 展示用户拥有的物品数量
        /// </summary>
        protected void DisplayGoodsCount()
        {
            //try
            //{
            //    Int64 userId = GetUserId();

            //    if (userId == -1)
            //    {
            //        Response.Redirect("/layout/SignIn.aspx");
            //        return;
            //    }

            //    // 获取用户拥有的物品数量
            //    Int32 count = GoodsService.GetGoodsCountOfUser(userId);

            //    GoodsCount.Text = count.ToString();
            //}
            //catch (Exception ex)
            //{
            //    PromptInfo.Text = ex.Message;
            //}
        }

        /// <summary>
        /// 展示用户成功帮助别人的次数
        /// </summary>
        protected void DisplayHelpingCount()
        {
            // HelpingCount.InnerText = "0";

            try
            {
                Int64 userId = GetUserId();

                if (userId == -1)
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }

                HelpingCount.InnerText = NoticeService.GetHelpingCount(userId).ToString();
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }

        }

        /// <summary>
        /// 展示用户成功找回东西的次数
        /// </summary>
        protected void DisplayGetbackCount()
        {
            // BackingCount.InnerText = "0";

            try
            {
                Int64 userId = GetUserId();

                if (userId == -1)
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }

                BackingCount.InnerText = NoticeService.GetBackingCount(userId).ToString();
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 展示用户发布的所有的启示
        /// </summary>
        protected void DisplayNoticeList()
        {
            try
            {
                Int64 userId = GetUserId();

                if (userId == -1) // 无用户登录且 URL 不传参数
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }

                DataTable data = NoticeService.SelectNoticeByUserId(userId); // 展示全部

                if (data != null)
                {
                    ListNotice.DataSource = data;
                    ListNotice.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示用户发布的动态
        /// </summary>
        protected void DisplayCurrentList()
        {
            try
            {
                Int64 userId = GetUserId();

                if (userId == -1)
                {
                    Response.Redirect("/layout/SignIn.aspx");
                    return;
                }

                DataTable data = CurrentService.GetCurrentByUserId(userId);

                if (data != null)
                {
                    ListCurrent.DataSource = data;
                    ListCurrent.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示用户拥有的物品
        /// </summary>
        protected void DisplayGoodsList()
        {

        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns>是否登录</returns>
        protected Boolean IsSignIn()
        {
            return Session["User"] != null ? true : false;
        }

        /// <summary>
        /// 获取用户 ID, 优先使用查询字符串获取的 ID
        /// </summary>
        /// <returns>用户 ID, -1 表示无用户登录且 URL 不传参数</returns>
        protected Int64 GetUserId()
        {
            Int64 userId = GetUserIdOfQueryStr();

            if (userId == 0)
            {
                userId = GetUserIdOfSession();

                if (userId == 0)
                {
                    userId = -1; // 表示无用户登录且 URL 不传参数
                }
            }

            return userId;
        }
        
        /// <summary>
        /// 查询字符串获取用户 ID
        /// </summary>
        /// <returns>用户 ID</returns>
        protected Int64 GetUserIdOfQueryStr()
        {
            object _userId = Request.QueryString["id"];

            return _userId != null ? Convert.ToInt64(_userId) : 0;
        }

        /// <summary>
        /// 从会话变量中获取用户 ID
        /// </summary>
        /// <returns>用户 ID</returns>
        protected Int64 GetUserIdOfSession()
        {
            User user = GetSignInUser();

            return user != null ? user.Id: 0;

        }
        /// <summary>
        /// 获取登录用户对象
        /// </summary>
        /// <returns>User 对象或 null</returns>
        protected User GetSignInUser()
        {
            return Session["User"] != null ? (User)Session["User"] : null;
        }

        /// <summary>
        /// 过滤器点击事件 - 显示用户发布的启示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkNotice_Click(object sender, EventArgs e)
        {
            if (ActiveControlId != ListNotice.ID)
            {
                (GetActiveControl<ListView>()).Visible = false; // 已显示的隐藏

                // 要显示数据的控件先判断 Visible
                if (!ListNotice.Visible)
                {
                    ListNotice.Visible = true;
                }
                else
                {
                    DisplayNoticeList(); // 看首次加载是否已查询了数据库
                }

                // ListNotice.Visible = !ListNotice.Visible ? true : ListNotice.Visible;


                // 将设置为当前控件 ID
                SetActiveControlId(ListNotice.ID);
            }
        }

        /// <summary>
        /// 过滤器点击事件 - 显示用户发布的动态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkCurrent_Click(object sender, EventArgs e)
        {
            if (ActiveControlId != ListCurrent.ID)
            {
                GetActiveControl<ListView>().Visible = false;

                if (!ListCurrent.Visible)
                {
                    ListCurrent.Visible = true;
                }
                else
                {
                    DisplayCurrentList();
                }

                SetActiveControlId(ListCurrent.ID);
            }
        }

        /// <summary>
        /// 过滤器点击事件 - 显示用户拥有的物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkGoods_Click(object sender, EventArgs e)
        {
            //if (ActiveControlId != "EmptyData")
            //{
            //    GetActiveControl<ListView>().Visible = false;

            //    EmptyData.Visible = true;

            //    SetActiveControlId(EmptyData.ID);
            //}
        }

        /// <summary>
        /// 获取已显示的控件
        /// </summary>
        /// <typeparam name="T">控件类型</typeparam>
        /// <returns>控件对象</returns>
        protected T GetActiveControl<T>() where T : Control
        {
            string activeControlId = ListPanel.Attributes["active-control-id"];

            return ListPanel.FindControl(activeControlId) as T;
        }

        /// <summary>
        /// 从 ListPanel 的属性 active-control-id 中获取已显示的控件的 ID
        /// </summary>
        /// <returns>属性值 - 控件 ID</returns>
        protected string GetActiveControlId()
        {
            return ListPanel.Attributes["active-control-id"];
        }

        /// <summary>
        /// 设置要显示的控件的 ID - 设置 ListPanel 的属性 active-control-id 的值
        /// </summary>
        /// <param name="value">设置值</param>
        protected void SetActiveControlId(object value)
        {
            ListPanel.Attributes["active-control-id"] = value.ToString();
        }

        protected void ListUserInfo_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DisplaySomeBtn(e);
        }

        /// <summary>
        /// 主页的部分按钮设置 - 在绑定用户信息时触发
        /// </summary>
        /// <param name="e"></param>
        protected void DisplaySomeBtn(ListViewItemEventArgs e)
        {
            LinkButton toCurrentEdit = e.Item.FindControl("LinkCurrentEdit") as LinkButton;
            LinkButton toInfoEdit    = e.Item.FindControl("LinkInfoEdit") as LinkButton;
            Button     followBtn     = e.Item.FindControl("FollowBtn") as Button;

            Int64 queryStrId = GetUserIdOfQueryStr();
            Int64 sessionId  = GetUserIdOfSession();

            if (queryStrId != 0 && queryStrId != sessionId)     // 访问其他用户主页
            {
                toCurrentEdit.Visible = false;
                toInfoEdit.Visible    = false;
                followBtn.Visible     = true;
            }
            else if (sessionId != 0) // 访问本人主页
            {
                toCurrentEdit.Visible = true;
                toInfoEdit.Visible    = true;
                followBtn.Visible     = false;
            }
        }

        /// <summary>
        /// 追踪失物招领启示
        /// </summary>
        /// <param name="sender">点击按钮对象</param>
        /// <param name="e">事件参数</param>
        protected void TraceBtn_Click(object sender, EventArgs e)
        {
            if (!IsSignIn()) // 判断用户是否登录
            {
                Response.Redirect("layout/SignIn.aspx");
                return;
            }

            bool isTraced = false;
            Button btn = (Button)sender;

            if (!isTraced)
            {
                Int64 noticeId = !String.IsNullOrEmpty(btn.Attributes["data-notice-id"]) ? Int64.Parse(btn.Attributes["data-notice-id"]) : 0;

                if (noticeId == 0)
                {
                    return;
                }

                User user = (User)Session["User"];

                NoticeTrace trace = new NoticeTrace()
                {
                    NoticeId = noticeId,
                    UserId = user.Id,
                    TraceDate = DateTime.Now.ToLocalTime()
                };

                bool isOk = NoticeTraceService.AddNoticeTrace(trace);

                if (isOk)
                {
                    Int64 traceCount = NoticeService.GetFieldValue<Int64>(noticeId, "trace_count");

                    btn.Text = String.Format("追踪 · {0}", traceCount);
                }

            }
            else
            {
                // TODO: 取消追踪
            }
        }

        // 关注
        protected void FollowBtn_Click(object sender, EventArgs e)
        {
            if (!IsSignIn())
            {
                Response.Redirect("/layout/SignIn.aspx");
                return;
            }
            else
            {
                Button btn = (Button)sender;
                User user = (User)Session["User"];

                if (btn.Text.Trim() == "关注")
                {
                    string _followingId = btn.Attributes["data-user-id"].ToString();

                    long followingId = !String.IsNullOrEmpty(_followingId) ? long.Parse(_followingId) : 0;

                    if (followingId == 0 || followingId == user.Id) // 不能关注自己
                    {
                        return;
                    }


                    Follow follower = new Follow()
                    {
                        UserId = user.Id,
                        FollowingId = followingId
                    };

                    bool isOk = FollowService.Following(follower);

                    if (isOk)
                    {
                        btn.Text = "已关注";
                    }
                }
                else
                {
                    // TODO: 取消关注
                }
            }
        }
    }
}