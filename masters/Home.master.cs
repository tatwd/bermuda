using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_Home : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null && Session["Username"].ToString() != "")
        {
            SignInBox.Style.Value = "display: none";
            SignUpBox.Style.Value = "display: none";

            UserAvatar.Style.Value = "display: block;font-size:0"; // 显示头像

        }
        else
        {
            UserAvatar.Style.Value = "display: none";
        }
    }
}
