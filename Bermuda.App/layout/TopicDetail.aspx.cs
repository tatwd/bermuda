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
    public partial class TopicDetail : System.Web.UI.Page
    {
        private const String URL_HOME = "~";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }

        /// <summary>
        /// 首次加载展示数据
        /// </summary>
        protected void Display()
        {
            DisplayTopicInfo     ();
            DisplayCurrentOfTopic();
        }

        /// <summary>
        /// 展示对应的话题信息
        /// </summary>
        protected void DisplayTopicInfo()
        {
            try
            {
                DataTable data = GetDataOfTopic();

                if (data != null)
                {
                    ListTopicInfo.DataSource = data;
                    ListTopicInfo.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;

                Response.Redirect(URL_HOME); // 跳转首页
            }
        }

        /// <summary>
        /// 根据话题 ID 展示动态
        /// </summary>
        protected void DisplayCurrentOfTopic()
        {
            try
            {
                DataTable data = GetDataOfCurrrent();

                if (data != null)
                {
                    ListCurrent.DataSource = data;
                    ListCurrent.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;

                Response.Redirect(URL_HOME); // 跳转首页
            }
        }

        /// <summary>
        /// 根据话题 ID 获取对应话题信息
        /// </summary>
        /// <returns>数据表或 null</returns>
        protected DataTable GetDataOfTopic()
        {
            DataTable data = null;

            Int64 topicId = GetTopicId();

            if (topicId > 0)
            {
                data = TopicService.GetTopicById(topicId);
            }
            else
            {
                throw new Exception("传递 URL 参数错误，话题 ID 格式不正确, 获取动态数据失败 -> GetDataOfTopic()");
            }

            return data;
        }


        /// <summary>
        /// 根据话题 ID 获取动态
        /// </summary>
        /// <returns>数据表或 null</returns>
        protected DataTable GetDataOfCurrrent()
        {
            DataTable data = null;

            Int64 topicId = GetTopicId();

            if (topicId > 0)
            {
                data = CurrentService.GetCurrentByTopicId(topicId);
            }
            else
            {
                throw new Exception("传递 URL 参数错误，话题 ID 格式不正确, 获取动态数据失败 -> GetDataOfCurrrent()");
            }

            return data;
        }

        /// <summary>
        /// 获取话题 ID
        /// </summary>
        /// <returns>话题 ID 或 0</returns>
        protected Int64 GetTopicId()
        {
            String _topicId = GetQueryStr("id");

            return _topicId != null ? Convert.ToInt64(_topicId) : 0;
        }

        /// <summary>
        /// 获取 URL 是否传递参数
        /// </summary>
        /// <param name="queryStrName">查询参数名</param>
        /// <returns>参数值或 null</returns>
        protected String GetQueryStr(String queryStrName)
        {
            return !String.IsNullOrEmpty(Request.QueryString[queryStrName]) ? Request.QueryString[queryStrName] : null;
        }
    }
}