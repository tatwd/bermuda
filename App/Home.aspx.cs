using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using Bll;

namespace App
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = UserService.SignIn("Bermuda", "bmd123456");

            string tip = (user != null) ? "成功" : "失败";

            Response.Write(tip + " - " + user.Name);
        }
    }
}