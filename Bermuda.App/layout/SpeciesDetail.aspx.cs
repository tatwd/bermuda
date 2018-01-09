using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bermuda.Model;
using Bermuda.Bll;
using System.Data;

namespace Bermuda.App.layout
{
    public partial class SpeciesDetail : System.Web.UI.Page
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
            DisplaySpeciesInfo    ();
            DisplayNoticeOfSpecies();
        }

        /// <summary>
        /// 展示对应的种类信息
        /// </summary>
        protected void DisplaySpeciesInfo()
        {
            try
            {
                List<Species> list = GetDataOfSpecies();

                if (list != null)
                {
                    ListSpeciesInfo.DataSource = list;
                    ListSpeciesInfo.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
                Response.Redirect(URL_HOME); // 跳转首页
            }
        }

        /// <summary>
        /// 展示对应种类的启示
        /// </summary>
        protected void DisplayNoticeOfSpecies()
        {
            try
            {
                DataTable data = GetDataOfNotice();

                if (data != null)
                {
                    ListNotice.DataSource = data;
                    ListNotice.DataBind();
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
                Response.Redirect(URL_HOME); // 跳转首页
            }
        }

        /// <summary>
        /// 获取对应种类的对象列表
        /// </summary>
        /// <returns>种类对象列表或 null</returns>
        protected List<Species> GetDataOfSpecies()
        {
            List<Species> list = null;

            Int64 speciesId = GetSpeciesId();

            if (speciesId > 0)
            {
                list = SpeciesService.GetSpeciesById(speciesId);
            }
            else
            {
                throw new Exception("传递 URL 参数错误，话题 ID 格式不正确, 获取动态数据失败 -> GetDataOfSpecies()");
            }

            return list;
        }

        /// <summary>
        /// 获取对应种类 ID 的所有启示
        /// </summary>
        /// <returns>数据表或 null</returns>
        protected DataTable GetDataOfNotice()
        {
            DataTable data = null;

            Int64 speciesId = GetSpeciesId();

            if (speciesId > 0)
            {
                data = NoticeService.SelectNoticeBySpeciesId(speciesId);
            }
            else
            {
                throw new Exception("传递 URL 参数错误，话题 ID 格式不正确, 获取动态数据失败 -> GetDataOfNotice()");
            }

            return data;
        }

        /// <summary>
        /// 获取种类 ID
        /// </summary>
        /// <returns>种类 ID 或 0</returns>
        protected Int64 GetSpeciesId()
        {
            String _speciesId = GetQueryStr("id");

            return _speciesId != null ? Convert.ToInt64(_speciesId) : 0;
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