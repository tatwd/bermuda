using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using DbKit;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void checkPasswdLength_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // validator in server
        // not be used

        if (args.Value.Length < 6 || args.Value.Length > 20)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    // 注册按钮事件
    protected void signUpBtn_Click(object sender, EventArgs e)
    {
        if (this.IsValid) // 验证通过
        {
            AddUser(); // 添加用户
        }
    }

    // 添加用户
    protected void AddUser()
    {
        //string sql = "insert into [user_info]([username], [email], [phone_num], [password]) values(@username, @email, @phone_num, @password)";

        string sql = String.Format("select * from [user_info] where [username] = '{0}'", nameBox.Text.Trim());

        string[] parameters = (string[])getUserInfo(); // 获取用户数据

        try
        {
            Connector conn = ConnectorFactory.GetConnector("TestDb");

            if (!conn.HasData(sql)) // 判断用户是否已经注册
            {
                conn.ManageDataOffMode("insert", "user_info", parameters); // 插入用户数据

                Response.Redirect("~/Default.aspx"); // 重定向到首页
            }
            else
            {
                tipLabel.Text = "该用户已被注册！";
            }
        }
        catch (Exception ex)
        {
            tipLabel.Text = ex.Message;
        }

    }

    // 获取用户信息，返回SQL语句
    protected object[] getUserInfo()
    {
        string username = nameBox.Text.Trim(),
               email    = emailBox.Text.Trim(),
               phoneNum = phoneBox.Text.Trim(),
               password = passwdBox.Text.Trim();

        string[] userInfo = { username, email, phoneNum, password };

        return userInfo;
    }
}