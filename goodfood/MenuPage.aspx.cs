using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace goodfood
{
    public partial class MenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }
        private void FillPage()
        {
            ArrayList menuList = new ArrayList();
            if (!IsPostBack)
            {
                menuList = ConnectionClass.GetMenuByType("%");
            }
            else
            {
                menuList = ConnectionClass.GetMenuByType(DropDownList1.SelectedValue);
            }
            StringBuilder sb = new StringBuilder();
            
            foreach (Menu menu in menuList)
            {
                sb.Append(string.Format(@"<table class='menuTable'>
                <tr>
                    <th rowspan='3' width='150px'><img runat='server' src='{3}' /></th>
                    <th width='50px'> Name:</th>
                    <td>{0}</td>
                <tr>

                <tr>
                    <th>Type:</th>
                    <td>{1}<td>
                <tr>

                <tr>
                    <th>Price:</th>
                    <td>{2} Rs<td>
                <tr>

              </table>",
                        menu.name, menu.type, menu.price, menu.image));

                lblOutput.Text = sb.ToString();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPage();
        }
    }
}