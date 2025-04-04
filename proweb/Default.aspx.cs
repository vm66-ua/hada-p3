using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proweb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.Items.Clear();
                ddlCategory.Items.Add(new ListItem("Computing", "1"));
                ddlCategory.Items.Add(new ListItem("Telephony", "2"));
                ddlCategory.Items.Add(new ListItem("Gaming", "3"));
                ddlCategory.Items.Add(new ListItem("Home appliances", "4"));
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string code = txtCode.Text.Trim();
                string name = txtName.Text.Trim();
                int amount = int.Parse(txtAmount.Text);
                int category = Convert.ToInt32(ddlCategory.SelectedValue);
                float price = float.Parse(txtPrice.Text);
                DateTime creationDate = DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", null);

                if (code.Length == 0 || code.Length > 16)
                {
                    lblMessage.Text = "Code must be between 1 and 16 characters.";
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Products WHERE code = @code", connection);
                    checkCmd.Parameters.AddWithValue("@code", code);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        lblMessage.Text = "A product with this code already exists.";
                        return;
                    }

                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO Products (name, code, amount, price, category, creationDate) " +
                        "VALUES (@name, @code, @amount, @price, @category, @creationDate)", connection);

                    insertCmd.Parameters.AddWithValue("@name", name);
                    insertCmd.Parameters.AddWithValue("@code", code);
                    insertCmd.Parameters.AddWithValue("@amount", amount);
                    insertCmd.Parameters.AddWithValue("@price", price);
                    insertCmd.Parameters.AddWithValue("@category", category);
                    insertCmd.Parameters.AddWithValue("@creationDate", creationDate);

                    insertCmd.ExecuteNonQuery();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product created successfully.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string name = txtName.Text.Trim();
            int amount = int.Parse(txtAmount.Text);
            int category = Convert.ToInt32(ddlCategory.SelectedValue);
            float price = float.Parse(txtPrice.Text);
            DateTime creationDate = DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", null);
            string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Products SET name=@name, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code", connection);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@creationDate", creationDate);
                cmd.Parameters.AddWithValue("@code", code);

                int rows = cmd.ExecuteNonQuery();
                lblMessage.ForeColor = rows > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMessage.Text = rows > 0 ? "Product updated." : "Product not found.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE code=@code", connection);
                cmd.Parameters.AddWithValue("@code", code);
                int rows = cmd.ExecuteNonQuery();

                lblMessage.ForeColor = rows > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblMessage.Text = rows > 0 ? "Product deleted." : "Product not found.";
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE code = @code", connection);
                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["name"].ToString();
                    txtAmount.Text = reader["amount"].ToString();
                    txtPrice.Text = reader["price"].ToString();
                    ddlCategory.SelectedValue = reader["category"].ToString();
                    txtCreationDate.Text = Convert.ToDateTime(reader["creationDate"]).ToString("dd/MM/yyyy HH:mm:ss");
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Product found.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Product not found.";
                }
            }
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY code ASC", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtCode.Text = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                    txtAmount.Text = reader["amount"].ToString();
                    txtPrice.Text = reader["price"].ToString();
                    ddlCategory.SelectedValue = reader["category"].ToString();
                    txtCreationDate.Text = Convert.ToDateTime(reader["creationDate"]).ToString("dd/MM/yyyy HH:mm:ss");
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "First product loaded.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "No products found.";
                }
            }
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products WHERE code < @code ORDER BY code DESC", connection);
                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtCode.Text = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                    txtAmount.Text = reader["amount"].ToString();
                    txtPrice.Text = reader["price"].ToString();
                    ddlCategory.SelectedValue = reader["category"].ToString();
                    txtCreationDate.Text = Convert.ToDateTime(reader["creationDate"]).ToString("dd/MM/yyyy HH:mm:ss");
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Previous product loaded.";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "No previous product found.";
                }
            }
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["BDConexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC", connection);
                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtCode.Text = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                    txtAmount.Text = reader["amount"].ToString();
                    txtPrice.Text = reader["price"].ToString();
                    ddlCategory.SelectedValue = reader["category"].ToString();
                    txtCreationDate.Text = Convert.ToDateTime(reader["creationDate"]).ToString("dd/MM/yyyy HH:mm:ss");
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
}
