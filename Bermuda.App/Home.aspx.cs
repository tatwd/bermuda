using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using Bermuda.Model;
using Bermuda.Bll;

namespace Bermuda.App
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 避免页的回发应发异常
            {
                Display(); // display all data
            }
        }

        /// <summary>
        /// 首次加载显示数据
        /// </summary>
        protected void Display()
        {
            DisplaySomeControls();  // 设置部分按钮的显示
            DisplayHotTopic    ();  // 显示前 7 条热门话题
            DisplayNotice      ();  // 显示前 6 条失物招领启示
            DisplayHotSpecies  ();  // 显示失物招领热门种类
            DisplayHotCurrent  ();  // 显示前 5 条热门动态
            DisplayBmdTop      ();  // 显示前 10 条助人排行榜
        }

        /// <summary>
        /// 设置部分控件的显示
        /// </summary>
        protected void DisplaySomeControls()
        {
            if (IsSignIn())
            {
                LinkSignIn.Visible      = false;
                LinkSignUp.Visible      = false;

                LinkTopicEdit.Visible   = true;
                LinkCurrentEdit.Visible = true;

                TopicEditPanel.Visible  = true;
            }
        }

        /// <summary>
        /// 显示前 7 条话题
        /// </summary>
        /// <param name="number">话题数</param>
        protected void DisplayHotTopic()
        {
            try
            {
                List<Topic> listTopic = TopicService.GetTopicByTop(10); // 显示前 6 条热门话题

                if (listTopic != null)
                {
                    ListHotTopic.DataSource = listTopic;
                    ListHotTopic.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示失物招领启示
        /// </summary>
        protected void DisplayNotice()
        {
            try
            {
                DataTable data = NoticeService.SelectNotice(10); // 前 10 条

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
        /// 显示失物招领启示热门分类
        /// </summary>
        protected void DisplayHotSpecies()
        {
            try
            {
                List<Species> listSpecies = SpeciesService.GetHotSpecies();

                if (listSpecies != null)
                {
                    LvHotSpecies.DataSource = listSpecies;
                    LvHotSpecies.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示前 5 条热门动态
        /// </summary>
        protected void DisplayHotCurrent()
        {
            try
            {
                DataTable data = CurrentService.GetHotCurrent();

                if (data != null)
                {
                    LvHotCurrent.DataSource = data;
                    LvHotCurrent.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 获取助人排行榜，按帮助别人成功找回物品的次数排
        /// </summary>
        protected void DisplayBmdTop()
        {
            try
            {
                DataTable data = NoticeService.GetBmdTop();

                if(data != null)
                {
                    LvBmdTop.DataSource = data;
                    LvBmdTop.DataBind();
                }

            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 显示前 6 条寻物启示
        /// </summary>
        protected void DisplayLostNotice()
        {
            try
            {
                DataTable data = NoticeService.SelectLostNotice(6); // 前 6 条

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
        /// 显示前 6 条招领启示
        /// </summary>
        protected void DisplayFoundNotice()
        {
            try
            {
                DataTable data = NoticeService.SelectFoundNotice(6); // 前 6 条

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

            bool   isTraced = false;
            Button btn      = (Button)sender;

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
                    NoticeId  = noticeId,
                    UserId    = user.Id,
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

        /// <summary>
        /// 关注其他用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FollowBtn_Click(object sender, EventArgs e)
        {
            if (!IsSignIn())
            {
                Response.Redirect("/layout/SignIn.aspx");
                return;
            }
            else
            {
                Button btn  = (Button)sender;
                User   user = (User)Session["User"];

                if (btn.Text.Trim() == "关注")
                {
                    string _followingId = btn.Attributes["data-user-id"].ToString();

                    Int64 followingId = !String.IsNullOrEmpty(_followingId) ? Int64.Parse(_followingId) : 0;

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
        
        /// <summary>
        /// 点击显示所有启示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AllNotice_OnClick(object sender, EventArgs e)
        {
            DisplayNotice();
        }

        /// <summary>
        /// 点击显示寻物启示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LostNotice_OnClick(object sender, EventArgs e)
        {
            DisplayLostNotice();
        }

        /// <summary>
        /// 点击显示招领启示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FoundNotice_OnClick(object sender, EventArgs e)
        {
            DisplayFoundNotice();
        }

        /// <summary>
        /// 点击提交话题进行审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitTopic_Click(object sender, EventArgs e)
        {
            try
            {
                Topic topic = GetAddingTopic();

                if (topic != null)
                {
                    Boolean isOk = TopicService.AddTopic(topic);

                    if (isOk)
                    {
                        Response.Redirect(Request.Url.ToString()); // 刷新本页
                    }
                }
                else
                {
                    PromptInfo.Text = "申请创建失败，请按要求填写信息！";
                }

            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 获取待添加的话题对象
        /// </summary>
        /// <returns>话题对象</returns>
        protected Topic GetAddingTopic()
        {

            User user = GetSignInUser();

            if (user == null) // 未登录
            {
                return null;
            }

            String   name       = TopicName.Text.Trim();
            Int64    userId     = user.Id;
            String   detail     = TopicDetail.Text.Trim();
            DateTime createDate = DateTime.Now.ToLocalTime();
            String   img        = ListToString(UploadImg());

            if (img == null) // 上传图片失败
            {
                return null;
            }

            Topic topic = new Topic()
            {
                Name       = name,
                UserId     = userId,
                Detail     = detail,
                CreateDate = createDate,
                Img        = img
            };

            return topic; 
        }

        /// <summary>
        /// 上传图片到服务器并获取上传图片路径列表
        /// </summary>
        /// <returns>列表</returns>
        protected List<string> UploadImg()
        {
            List<string> imgList = new List<string>();

            HttpFileCollection files = Request.Files;
            User               user  = GetSignInUser();

            if (user == null)
            {
                Response.Redirect("~/layout/SignIn.aspx");
                return imgList; // 空列表
            }

            string serverPath = String.Format("~/public/img/{0}/", user.Id); // e.g. `~/public/img/10002/`
            string filePath = Server.MapPath(serverPath);                  // e.g. `E:\\workspce\\projects\\Bermuda\\App\\public\\img\\1002\\`
            StringBuilder fileName = new StringBuilder();

            if (!System.IO.Directory.Exists(filePath)) // 判断该目录是否存在
            {
                System.IO.Directory.CreateDirectory(filePath);
            }

            if (files.Count != 0)
            {
                for (int i = 0, length = files.Count; i < length; i++)
                {
                    // 重命名图片，避免重复
                    string _date = DateTime.Now.ToString("yyyyMMddHHmmssff");
                    fileName.AppendFormat("{0}-{1}", _date, files[i].FileName); // e.g. `2017122611411457-xxx.png`

                    string path = String.Format("/public/img/{0}/{1}", user.Id, fileName.ToString()); // e.g. `/public/img/10002/2017122611411457-xxx.png`
                    imgList.Add(path);

                    string virPath = String.Format("{0}{1}", filePath, fileName); // e.g. `E:\\workspce\\projects\\Bermuda\\App\\public\\img\\1002\\2017122611411457-xxx.png`
                    files[0].SaveAs(virPath);

                    fileName.Clear(); // 清空文件名字符串
                }
            }

            return imgList;
        }

        /// <summary>
        /// 列表转化成字符串，以逗号分割
        /// </summary>
        /// <param name="list">列表对象</param>
        /// <returns>字符串</returns>
        protected string ListToString(List<string> list)
        {
            StringBuilder str = new StringBuilder();

            if (list.Count == 0) // 列表为空
            {
                return null;
            }

            foreach (string item in list)
            {
                if (str.Length == 0)
                {
                    str.Append(item);
                }
                else
                {
                    string _str = String.Format(",{0}", item);

                    str.Append(_str);
                }
            }

            return str.ToString();
        }

        /// <summary>
        /// 获取登录的用户
        /// </summary>
        /// <returns>用户对象</returns>
        protected User GetSignInUser()
        {
            return Session["User"] != null ? (User)Session["User"] : null;
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns>布尔值</returns>
        protected bool IsSignIn()
        {
            return Session["User"] != null ? true : false;
        }
    }
}