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
    public partial class TopicList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }

        protected void Display()
        {
            // Test();
            DisplayTopicList();
        }

        /// <summary>
        /// 展示所有的话题
        /// </summary>
        protected void DisplayTopicList()
        {
            try
            {
                List<Topic> list = TopicService.GetAllTopic();

                if (list != null)
                {
                    LvTopicGroupCard.DataSource = list;
                    LvTopicGroupCard.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }

        protected void Test()
        {
            try
            {
                List<Topic> list = TopicService.GetAllTopic();

            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
            }
        }
    }
}