using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using Bermuda.Model;
using Bermuda.Bll;

namespace Bermuda.App.layout
{
    public partial class Publish : System.Web.UI.Page
    {
        private const String URL_SIGN_IN = "~/layout/SignIn.aspx";
        private const String URL_HOME    = "~/Home.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect(URL_SIGN_IN);
            }
        }

        /// <summary>
        /// 发布启示按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PubNotice_Click(object sender, EventArgs e)
        {
            try
            {
                Notice notice = GetAddingNotice();

                if (notice != null)
                {
                    bool isOk = NoticeService.AddNotice(notice); // 添加到数据库

                    if (isOk)
                    {
                        Response.Redirect(URL_HOME);
                    }
                }
            }
            catch (Exception ex)
            {
                PromptInfo.Text = ex.Message;
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
        /// 从 Session 变量中获取用户对象
        /// </summary>
        /// <returns>User 对象</returns>
        protected User GetUser()
        {
            return (User)Session["User"];
        }

        /// <summary>
        /// 从页面获取要添加的启示对象，此方法的使用必须在用户登录之后使用
        /// </summary>
        /// <returns>实体对象</returns>
        protected Notice GetAddingNotice()
        {
            User user = GetUser();

            Int64    userId      = user.Id;
            Int64    speciesId   = Int64.Parse(GoodSpecies.SelectedValue); // test data
            string   type        = NoticeTypeList.SelectedValue;
            string   title       = NoticeTitle.Text.Trim();
            string   place       = NoticePlace.Text.Trim();
            string   lfDate      = LfDate.Text.Trim();
            string   img         = ListToString(UploadImg());  // 上传图片后获取上传的图片路径
            string   contactWay  = ContactWay.Text.Trim();
            string   detail      = NoticeDetail.Text.Trim();
            DateTime publishDate = DateTime.Now.ToLocalTime();

            Notice notice = new Notice()
            {
                UserId      = userId,
                SpeciesId   = speciesId,
                Type        = type, 
                Title       = title,
                Place       = place,
                LfDate      = lfDate,
                Img         = img,
                ContactWay  = contactWay,
                Detail      = detail,
                PublishDate = publishDate
            };

            return notice;
        }

        /// <summary>
        /// 上传图片到服务器并获取上传图片路径列表
        /// </summary>
        /// <returns>列表</returns>
        protected List<string> UploadImg()
        {
            List<string> imgList = new List<string>();

            HttpFileCollection files      = Request.Files;
            User               user       = GetUser();
            string             serverPath = String.Format("~/public/img/{0}/", user.Id); // e.g. `~/public/img/10002/`
            string             filePath   = Server.MapPath(serverPath);                  // e.g. `E:\\workspce\\projects\\Bermuda\\App\\public\\img\\1002\\`
            StringBuilder      fileName   = new StringBuilder();

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
    }
}