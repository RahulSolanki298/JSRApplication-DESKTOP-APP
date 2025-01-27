using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;

namespace LocalApplication
{
    public partial class Operators : Form
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public Operators(CompanyEmployee employee)
        {
            InitializeComponent();
            _employee = employee;
            getEmployeeList();
        }

        public void LoadData()
        {
            getEmployeeList();
        }

        public void getEmployeeList()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    //string qry = $"SELECT * from CompanyEmployee";
                    string qry = $"SELECT \r\n    main.Id AS EmployeeId,\r\n    main.EmployeeCode,\r\n    main.EmployeeName AS EmployeeName,\r\n    main.Username,\r\n    main.Password,\r\n    main.EmployeeType,\r\n    COALESCE(sub.EmployeeName, 'No Manager Assigned') AS ManagerName,\r\n    main.IsActive\r\nFROM \r\n    CompanyEmployee main\r\nINNER JOIN \r\n    CompanyEmployee sub ON main.ManageBy = sub.Id where main.EmployeeType='" + SD.Operator + "' and main.ManageBy='" + _employee.Id + "'";

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dtGridEmployee.DataSource = dt;
                }
                catch (Exception)
                {
                }
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeRegister empRegister = new EmployeeRegister(_employee);
            empRegister.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void dtGridEmployee_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtGridEmployee.Rows[e.RowIndex];
                pnlAdminDashboard.Show();
                empId.Text = row.Cells["Id"].Value.ToString();
            }
        }

        public CompanyEmployee AuthenticateUser(int employeeId)
        {
            CompanyEmployee Employee = new CompanyEmployee();

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CompanyEmployee WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", employeeId);
                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            var software = GetCompanySoftware();
                            Employee.Id = Convert.ToInt32(reader["Id"]);
                            Employee.UserId = reader["UserId"].ToString();
                            Employee.SoftwareId = software.Id;
                            Employee.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            return Employee;
                        }
                        else
                        {
                            return new CompanyEmployee();
                        }
                    }
                }
            }
        }

        public CompanySoftware GetCompanySoftware()
        {
            CompanySoftware software = new CompanySoftware();

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT top 1 * FROM CompanySoftware";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            software.Id = Convert.ToInt32(reader["Id"]);
                            software.CompanySectionName = reader["CompanySectionName"].ToString();
                            software.SoftwareKey = reader["SoftwareKey"].ToString();
                            software.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                            return software;
                        }
                        else
                        {
                            return new CompanySoftware();
                        }
                    }
                }
            }
        }

        private void picSetting_Click(object sender, EventArgs e)
        {
            getEmployeeList();
        }

        private bool VerifyAdmin()
        {
            try
            {
                //string baseUrl = "http://localhost:49061/api/ProjectDetails/VerifyAdmin";
                string baseUrl = "https://el.jsr-renewables.com/api/ProjectDetails/VerifyAdmin";
                var software = GetCompanySoftware();

                // Check if software data is retrieved successfully
                if (software == null)
                {
                    MessageBox.Show("Failed to retrieve software information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Create instance of HttpClient with timeout
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10); // Timeout after 10 seconds

                    // Prepare data to send
                    var employee = new AdminVerifyDTO
                    {
                        SoftwareKey = software.SoftwareKey,
                    };

                    // Serialize data to JSON
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        // Send POST request
                        HttpResponseMessage response = client.PostAsync(baseUrl, content).Result;

                        // Check response status
                        if (response.IsSuccessStatusCode)
                        {
                            // Successful response handling
                            string responseContent = response.Content.ReadAsStringAsync().Result;
                            MessageBox.Show("Verification successful: " + responseContent, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            // Error handling
                            MessageBox.Show("Verification failed. Server returned: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        // Handle HTTP request exception
                        // MessageBox.Show("Error occurred during HTTP request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminChangePassword changePasswordFrm = new AdminChangePassword(_employee);
            changePasswordFrm.Show();
        }

        private void replicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportData importData = new ImportData(_employee);
            importData.Show();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            pnlAdminDashboard.Visible = false;
        }

        private void cmbSelectEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            var employeeOption = cmbSelectEmployee.SelectedItem.ToString();
            if (employeeOption == "Edit")
            {
                EmployeeRegister employee = new EmployeeRegister(_employee, Convert.ToInt32(empId.Text));
                pnlAdminDashboard.Visible = false;
                employee.Show();
            }
            else if (employeeOption == "Delete")
            {
                DeleteEmployee(Convert.ToInt32(empId.Text));
            }
            else if (employeeOption == "Dashboard")
            {
                Dashboard dashboard = new Dashboard(AuthenticateUser(Convert.ToInt32(empId.Text)));
                pnlAdminDashboard.Visible = false;
                dashboard.Show();
            }
        }

        private void DeleteEmployee(int employeeId)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    // Get the UserId from the CompanyEmployee table
                    string getUserIdQuery = "SELECT UserId FROM CompanyEmployee WHERE Id = @Id";
                    string userId = null;

                    using (var getUserIdCommand = new SqlCommand(getUserIdQuery, connection))
                    {
                        getUserIdCommand.Parameters.AddWithValue("@Id", employeeId);
                        var result = getUserIdCommand.ExecuteScalar();

                        if (result != null)
                        {
                            userId = result.ToString();
                        }
                    }

                    if (userId != null)
                    {
                        // Delete the employee from CompanyEmployee table
                        string deleteEmployeeQuery = "DELETE FROM CompanyEmployee WHERE Id = @Id";
                        using (var deleteEmployeeCommand = new SqlCommand(deleteEmployeeQuery, connection))
                        {
                            deleteEmployeeCommand.Parameters.AddWithValue("@Id", employeeId);
                            deleteEmployeeCommand.ExecuteNonQuery();
                        }

                        string deleteUserQuery = "DELETE FROM AspNetUsers WHERE Id = @UserId";
                        using (var deleteUserCommand = new SqlCommand(deleteUserQuery, connection))
                        {
                            deleteUserCommand.Parameters.AddWithValue("@UserId", userId);
                            deleteUserCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Employee and user deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.");
                    }
                    getEmployeeList();
                    pnlAdminDashboard.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the employee and user: {ex.Message}");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (CloseCancel() == true)
            {
                Application.Exit();
            };
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to exit?";
            const string caption = "Cancel";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblBulkClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeRegister employeeRegister = new EmployeeRegister(_employee);
            employeeRegister.ShowDialog();
        }

        
    }
}
