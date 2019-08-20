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
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateControls();
        }

        private void GenerateControls()
        {
            
            ArrayList menuList = ConnectionClass.GetMenuByType("%");

            foreach (Menu menu in menuList)
            {
                
                Panel menuPanel = new Panel();
                Image image = new Image { ImageUrl = menu.image, CssClass = "ProductsImage" };
                Literal literal = new Literal { Text = "<br />" };
                Literal literal2 = new Literal { Text = "<br />" };
                Label lblName = new Label { Text = menu.name, CssClass = "ProductsName" };
                Label lblPrice = new Label
                {
                    Text = String.Format("{0:0.00}", menu.price + "<br />"),
                    CssClass = "ProductsPrice"
                };
                TextBox textBox = new TextBox
                {
                    ID = menu.id.ToString(),
                    CssClass = "ProductsTextBox",
                    Width = 60,
                    Text = "0"
                };

                
                RegularExpressionValidator regex = new RegularExpressionValidator
                {
                    ValidationExpression = "^[0-9]*",
                    ControlToValidate = textBox.ID,
                    ErrorMessage = "Please enter a number."
                };
                menuPanel.Controls.Add(image);
                menuPanel.Controls.Add(literal);
                menuPanel.Controls.Add(lblName);
                menuPanel.Controls.Add(literal2);
                menuPanel.Controls.Add(lblPrice);
                menuPanel.Controls.Add(textBox);
                menuPanel.Controls.Add(regex);

                pnlProducts.Controls.Add(menuPanel);
            }
        }
        private ArrayList GetOrders()
        {
            
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            ControlFinder<TextBox> cf = new ControlFinder<TextBox>();
            cf.FindChildControlsRecursive(cph);
            var textBoxList = cf.FoundControls;

            
            ArrayList orderList = new ArrayList();

            foreach (TextBox textBox in textBoxList)
            {
                
                if (textBox.Text != "")
                {
                    int amountOfOrders = Convert.ToInt32(textBox.Text);

                    
                    if (amountOfOrders > 0)
                    {
                        Menu menu = ConnectionClass.GetMenuById(Convert.ToInt32(textBox.ID));
                        Order order = new Order(
                            Session["login"].ToString(), menu.name, amountOfOrders, menu.price, DateTime.Now, false);

                        
                        orderList.Add(order);
                    }
                }
            }
            return orderList;
        }
        private void GenerateReview()
        {
            double totalAmount = 0;
            ArrayList orderList = GetOrders();
            Session["orders"] = orderList;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<h3>Please review your order</h3>");

            
            foreach (Order order in orderList)
            {
                double totalRow = order.Price * order.Amount;
                sb.Append(String.Format(@"<tr>
                                            <td width = '50px'>{0} X </td>
                                            <td width = '200px'>{1} ({2})</td>
                                            <td>{3}</td><td>Rs</td>
                                        </tr>", order.Amount, order.Product, order.Price, String.Format("{0:0.00}", totalRow)));
                totalAmount = totalAmount + totalRow;
            }
            sb.Append(String.Format(@"<tr>
                                        <td><b>Total: </b></td>
                                        <td><b>{0} Rs </b></td>
                                      </tr>", totalAmount));
            sb.Append("</table>");

            
            lblResult.Text = sb.ToString();
            lblResult.Visible = true;
            btnOk.Visible = true;
            btnCancel.Visible = true;
        }

        private void SendOrder()
        {
            ArrayList orderList = (ArrayList)Session["orders"];
            ConnectionClass.AddOrders(orderList);
            Session["orders"] = null;
        }

        private void Authenticate()
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Authenticate();
            SendOrder();

            lblResult.Text = "Your order has been placed, thank you for shopping at Good Food";
            btnOk.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["orders"] = null;
            btnOk.Visible = false;
            btnCancel.Visible = false;
            lblResult.Visible = false;
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Authenticate();
            GenerateReview();
        }
    }

}