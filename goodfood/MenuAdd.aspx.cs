using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace goodfood
{
    public partial class MenuAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "administrator")
            {
                Response.Redirect("Login.aspx");
            }

            string selectedValue = ddImage.SelectedValue;
            ShowImages();
            ddImage.SelectedValue = selectedValue;
        }

        private void ShowImages()
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/images/menu images/"));

            ArrayList imageList = new ArrayList();

            foreach(string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
                imageList.Add(imageName);
            }

            ddImage.DataSource = imageList;
            ddImage.DataBind();
        }

        private void ClearTextFields()
        {
            txtName.Text = "";
            txtType.Text = "";
            txtPrice.Text = "";
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/images/menu images/")+filename);
                lblResult.Text = "Image" + filename + "successfully uploaded";
            }
            catch (Exception)
            {
                lblResult.Text = "Upload Failed!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string type = txtType.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                string image = "../images/menu images/" + ddImage.SelectedValue;

                Menu menu = new Menu(name, type, price, image);
                ConnectionClass.AddMenu(menu);
                lblResult.Text = "Upload Successfully!";
                ClearTextFields();

            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed";
            }
        }
    }
}