using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using DbKit;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["Username"] = ""; // 首次加载设置会话变量为空

        }

        //tipLabel.Text = Session["Username"].ToString();
    }

    protected void signInBtn_Click(object sender, EventArgs e)
    {

        if (this.IsValid) // 验证通过
        {
            QueryUser(); // 查询用户
        }
    }

    // 查询用户
    protected void QueryUser()
    {
        string username = nameBox.Text.Trim();
        string password = passwdBox.Text.Trim();

        // string sql = String.Format("select * from [user_info] where [username] = '{0}' and [password] = '{1}'", username, password);

        string sql = "select * from [user_info] where [username] = @username and [password] = @password";

        SqlParameter[] parameters = new SqlParameter[] // 设置参数
        {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
        };

        try
        {
            Connector conn = ConnecterFactory.GetConnector("TestDb");

            conn.Connect();

            if (!isLogined())
            {
                if (conn.HasData(sql, parameters)) // 判断用户是否已经注册
                {
                    // tipLabel.Text = "登录成功！";

                    Session["Username"] = username; // session变量保存用户名
                     
                    Response.Redirect("~/Default.aspx"); // 重定向到首页
                }
            }
            else
            {
                tipLabel.Text = "尊敬的" + Session["Username"].ToString() + "，你已经登录！";
            }

            conn.CloseAll();
        }
        catch (Exception ex)
        {
            tipLabel.Text = ex.Message;
        }
    }

    // 判断用户是否已经登录
    protected bool isLogined()
    {
        return (Session["Username"] == null || Session["Username"].ToString() == "") ? false : true;
    }
}