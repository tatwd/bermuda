using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Bermuda.Model;
using Bermuda.Bll;

namespace Bermuda.App.layout
{
    public partial class CurrentEdit : System.Web.UI.Page
    {
        private const String URL_SIGN_IN        = "~/layout/SignIn.aspx";
        private const String URL_HOME           = "~";
        private const String URL_PROFILE        = "~/layout/Profile.aspx";
        private const String URL_CURRENT_DETAIL = "~/layout/CurrentDetail.aspx?id=";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // 只有登录了的用户才能访问到这个页面

                if (!IsSignIn()) // 用于测试
                {
                    Response.Redirect(URL_SIGN_IN);
                    return;
                }

                GetTopicSelectItem();
            }
        }

        /// <summary>
        /// 提交按钮点击事件 - 添加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                Current current = GetAddingCurrent();

                bool isOk = CurrentService.AddCurrent(current);

                if (isOk)
                {
                    Int64 currentId = GetCurrentId(current);

                    if (!AddTopicJoin(currentId))
                    {
                        PromptInfo.Text = "添加话题参与失败";
                        return;
                    }
                    else
                    {
                        Response.Redirect(URL_CURRENT_DETAIL + currentId); // 跳转到动态详情页
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }

        }

        /// <summary>
        /// 获取待添加的动态对象
        /// </summary>
        /// <returns>动态对象</returns>
        protected Current GetAddingCurrent()
        {
            Int64  userId  = GetSignInUserId();
            String content = GetCurrentContent();

            Current current = new Current()
            {
                UserId      = userId,
                Title       = CurrentTitleInput.Text.Trim(),
                Contents    = content,
                PublishDate = DateTime.Now.ToLocalTime()
            };

            return current;
        }

        /// <summary>
        /// 获取刚添加的动态 ID
        /// </summary>
        /// <param name="current">实体对象</param>
        /// <returns>动态ID, -1 表示获取失败</returns>
        protected Int64 GetCurrentId(Current current)
        {
            Int64 currentId = 0;

            try
            {
                currentId = CurrentService.GetAddingCurrentId(current);
            }
            catch (Exception ex)
            {
                currentId = -1;
                PromptInfo.Text = ex.Message;
            }

            return currentId;
        }

        /// <summary>
        /// 添加话题参与记录
        /// </summary>
        /// <param name="currentId">动态 ID</param>
        /// <returns>是否成功</returns>
        protected bool AddTopicJoin(Int64 currentId)
        {
            List<Int64> topicIdList = GetSelectedTopicId();

            try
            {
                foreach (Int64 topicId in topicIdList)
                {
                    TopicJoin topicJoin = new TopicJoin()
                    {
                        CurrentId = currentId,
                        TopicId = topicId
                    };

                    return TopicJoinService.AddTopicJoin(topicJoin);
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// 获取用户 ID
        /// </summary>
        /// <returns>用户 ID</returns>
        protected Int64 GetSignInUserId()
        {
            return GetSignInUser().Id;
        }

        /// <summary>
        /// 获取登录的用户
        /// </summary>
        /// <returns>用户对象</returns>
        protected User GetSignInUser()
        {
            return (User)Session["User"];
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
        /// 获取动态的内容
        /// </summary>
        /// <returns>字符串构建对象</returns>
        protected String GetCurrentContent()
        {
            return new StringBuilder(CurrentContent.Text.Trim()).ToString();
        }

        /// <summary>
        /// 获取所有话题选择项，并绑定到 ListBox
        /// </summary>
        protected void GetTopicSelectItem()
        {
            try
            {
                DataTable data = TopicService.GetTopicNameAndId();

                if (data != null)
                {
                    LbTopic.DataSource = data.DefaultView;
                    LbTopic.DataValueField = "id";
                    LbTopic.DataTextField = "name";
                    LbTopic.DataBind();
                }

            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }


        }

        /// <summary>
        /// 获取选中的话题 ID
        /// </summary>
        /// <returns>话题 ID列表</returns>
        protected List<Int64> GetSelectedTopicId()
        {
            List<Int64> selectedTopicIdList = new List<Int64>();

            foreach (ListItem item in LbTopic.Items)
            {
                if (item.Selected)
                {
                    Int64 _id = Convert.ToInt64(item.Value);

                    selectedTopicIdList.Add(_id);
                }
            }

            return selectedTopicIdList;
        }
    }
}