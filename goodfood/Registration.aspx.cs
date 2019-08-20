using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace goodfood
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
                
                User user = new User(txtName.Text, txtPassword.Text, txtEmail.Text, "user");
                lblResult.Text=ConnectionClass.RegisterUser(user);
                
                
         
        }
    }
}