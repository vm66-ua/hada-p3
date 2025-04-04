using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using library; // Referencia al proyecto library
using System.Collections.Generic;

namespace proweb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ENCategory> categories = new CADCategory().ReadAll(); 

                ddlCategory.Items.Clear();
                foreach (ENCategory cat in categories)
                {
                    ddlCategory.Items.Add(new ListItem(cat.Name, cat.Id.ToString()));
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct product = new ENProduct(txtCode.Text.Trim(), txtName.Text.Trim(), int.Parse(txtAmount.Text), float.Parse(txtPrice.Text), Convert.ToInt32(ddlCategory.SelectedValue), DateTime.Parse(txtCreationDate.Text));

                if (product.Create())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product created successfully.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Failed to create product.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct product = new ENProduct(txtCode.Text.Trim(), txtName.Text.Trim(), int.Parse(txtAmount.Text), float.Parse(txtPrice.Text), Convert.ToInt32(ddlCategory.SelectedValue), DateTime.Parse(txtCreationDate.Text));
                if (product.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product updated successfully.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Failed to update product.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct product = new ENProduct();
                product.Code = txtCode.Text.Trim();

                if (product.Delete())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product deleted successfully.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Product not found.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();

            if (product.Read())
            {
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString();
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("yyyy-MM-ddTHH:mm");
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Product found.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Product not found.";
            }
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();

            if (product.ReadFirst())
            {
                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString();
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("yyyy-MM-ddTHH:mm");
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "First product loaded.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No products found.";
            }
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();

            if (product.ReadPrev())
            {
                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString();
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("yyyy-MM-ddTHH:mm");
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Previous product loaded.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No previous product found.";
            }
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();

            if (product.ReadNext())
            {
                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString();
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("yyyy-MM-ddTHH:mm");
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Next product loaded.";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No next product found.";
            }
        }
    }
}
