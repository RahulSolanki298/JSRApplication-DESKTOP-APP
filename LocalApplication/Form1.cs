using LocalApplication.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using LocalApplication.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Data;

namespace LocalApplication
{
    public partial class Form1 : Form
    {
        DBHelper DBHelper = new DBHelper();

        public Form1()
        {
            InitializeComponent();
            var comp = GetCompany();
            var ImageCount = GetImageDataCounter();
            if (comp.IsNoOfImages != false && comp.NoOfImages >= ImageCount 
                || comp.ExpiryDate.HasValue 
                && comp.ExpiryDate.Value.Date <= DateTime.Now.Date)
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }

            lblUsername.Visible = false;
            lblPassword.Visible = false;
            loader.Visible = false;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //loader.Visible = true;

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (chkAdmin.Checked == true)
                {
                    var response = DBHelper.AuthenticateAdmin(username, password);

                    if (response.Id > 0)
                    {
                        lblUsername.Visible = false;
                        lblPassword.Visible = false;
                        this.Hide();

                        DashboardAdmin dashboard = new DashboardAdmin(response);
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                    //loader.Visible = false;
                    return;
                }

                if (username != "" && password != "")
                {
                    var response = DBHelper.AuthenticateUser(username, password);
                    if (response.Id > 0 && response.SoftwareId > 0)
                    {
                        lblUsername.Visible = false;
                        lblPassword.Visible = false;
                        this.Hide();

                        if (response.EmployeeType == SD.Manager)
                        {
                            Dashboard dashboard = new Dashboard(response);
                            dashboard.Show();
                        }
                        else
                        {
                            DashboardEmployee dashboard = new DashboardEmployee(response);
                            dashboard.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                }
                else
                {
                    lblUsername.Visible = true;
                    lblPassword.Visible = true;
                }
                //loader.Visible = false;
            }
            catch (Exception ex)
            {
                //loader.Visible = false;
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }


        private CompanyVM GetCompany()
        {
            CompanyVM company = new CompanyVM();

            using (SqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT TOP 1 * FROM Company";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            company.Id = Convert.ToInt32(reader["Id"]);
                            company.CompanyName = reader["CompanyName"].ToString();
                            company.SoftwareKey = reader["SoftwareKey"].ToString();
                            company.RegisterDate = DBHelper.GetNullableDateTime(reader["RegisterDate"]);
                            company.ExpiryDate = DBHelper.GetNullableDateTime(reader["ExpiryDate"]);
                            company.NoOfSoftware = Convert.ToInt32(reader["NoOfSoftware"]);
                            company.IsNoOfImages = Convert.ToBoolean(reader["IsNoOfImages"]);
                            company.NoOfImages = Convert.ToInt32(reader["NoOfImages"]);
                            company.IsSubscription = Convert.ToBoolean(reader["IsSubscription"]);
                            company.SubscriptionDays = Convert.ToInt32(reader["SubscriptionDays"]);
                            company.OwnerName = reader["OwnerName"].ToString();
                        }
                    }
                }
            }

            return company;
        }

        private int GetImageDataCounter()
        {
            int total = 0;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = @"SELECT ImageResult, COUNT(*) AS ResultCount
                           FROM ImageProcessData
                           GROUP BY ImageResult";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);

                            // Initialize counters
                            int defectiveCount = 0;
                            int withinCriteriaCount = 0;
                            int okCount = 0;

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    string imageResult = row["ImageResult"].ToString();
                                    int count = Convert.ToInt32(row["ResultCount"]);

                                    switch (imageResult)
                                    {
                                        case SD.Ok:
                                            okCount = count;
                                            break;
                                        case SD.Defective:
                                            defectiveCount = count;
                                            break;
                                        case SD.WithinCriteria:
                                            withinCriteriaCount = count;
                                            break;
                                        case SD.Pending:
                                            break;
                                    }
                                }

                                total = okCount + defectiveCount + withinCriteriaCount;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }

            return total;
        }

    }

}

