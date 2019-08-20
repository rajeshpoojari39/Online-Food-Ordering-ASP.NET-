using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace goodfood
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["login"] != null)
            {
                lblLogin.Text = "Welcome" + Session["login"].ToString();
                lblLogin.Visible =true;
                LinkButton1.Text = "Logout";
            }
            else
            {
                
                lblLogin.Visible = false;
                LinkButton1.Text = "Login";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (LinkButton1.Text == "Login")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Clear();
                Response.Redirect("HomePage.aspx");
            }

        }
    }
}