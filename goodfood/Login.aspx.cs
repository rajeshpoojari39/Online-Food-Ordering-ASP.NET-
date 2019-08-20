using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace goodfood
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = ConnectionClass.LoginUser(txtLogin.Text, txtPassword.Text);

            if(user !=null)
            {
                Session["login"] = user.Name;
                Session["type"] = user.Type;

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblError.Text = "Login Failed";
            }
        }

        
    }
}