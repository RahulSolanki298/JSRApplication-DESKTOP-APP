using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;


namespace LocalApplication
{
    public partial class EmployeeRegister : Form
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();

        public EmployeeRegister(CompanyEmployee employee, int? employeeId = 0)
        {
            InitializeComponent();

            _employee = employee;

            this.ActiveControl = txtFirstName;

            cmbEmployeeType.SelectedIndex = 0;

            EditEmployee(Convert.ToInt32(employeeId));

            if (_employee.EmployeeType != SD.Admin)
            {
                cmbManageBy.Visible = false;
                lblManage.Visible = false;
            }
            else
            {
                BindEmployee();
            }

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            btnSaveEmployee.Enabled = false;
            var valid = IsValidProject();

            if (valid > 0)
            {
                MessageBox.Show("Please enter required feilds.");
                btnSaveEmployee.Enabled = true;
                return;
            }

            bool emailExists = await IsEmailExist(txtEmailId.Text);

            if (emailExists && String.IsNullOrEmpty(lblID.Text))
            {
                MessageBox.Show("Employee already registered.");
                btnSaveEmployee.Enabled = true;
                return;
            }


            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string emailId = txtEmailId.Text;
            string password = txtPassword.Text;
            bool isActive = chkIsActived.Checked;
            string selectedEmployeeType = cmbEmployeeType.SelectedIndex > 0 ? cmbEmployeeType.SelectedItem.ToString() : null;
            string selectedManageBy = cmbManageBy.SelectedIndex > 0 ? cmbManageBy.SelectedValue.ToString() : null;
            string userId = lblID.Text;

            var software = await GetCompanySoftwareAsync();

            using (SqlConnection connection = DBHelper.GetConnection())
            {
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;

                            if (!string.IsNullOrEmpty(userId))
                            {
                                command.CommandText = "UPDATE AspNetUsers SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, Email=@Email, UserName=@UserName WHERE Id = @Id";
                                command.Parameters.AddWithValue("@Id", userId);
                            }
                            else
                            {
                                command.CommandText = "INSERT INTO AspNetUsers (Id, FirstName, MiddleName, LastName, Email, UserName) VALUES (@Id, @FirstName, @MiddleName, @LastName, @Email, @UserName)";
                                userId = Guid.NewGuid().ToString();  // Generate a new GUID for the new user
                                command.Parameters.AddWithValue("@Id", userId);

                            }

                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@MiddleName", middleName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@Email", emailId);
                            command.Parameters.AddWithValue("@UserName", emailId);

                            await command.ExecuteNonQueryAsync();
                        }

                        using (SqlCommand employeeCommand = connection.CreateCommand())
                        {
                            employeeCommand.Transaction = transaction;
                            employeeCommand.CommandText = @"
MERGE CompanyEmployee AS target
USING (SELECT @UserId AS UserId) AS source
ON target.UserId = source.UserId
WHEN MATCHED THEN
    UPDATE SET IsActive = @IsActive, Password = @Password, Username = @Username, SoftwareId=@SoftwareId, EmployeeName=@EmployeeName, CompanyId=@CompanyId, UpdatedById=@UpdatedById, UpdatedDate=@UpdatedDate, ManageBy=@ManageBy,EmployeeType=@EmployeeType
WHEN NOT MATCHED THEN
    INSERT (UserId, IsActive, Password, Username, SoftwareId, EmployeeName, CompanyId, CreatedById, CreatedDate, ManageBy,EmployeeType) 
    VALUES (@UserId, @IsActive, @Password, @Username, @SoftwareId, @EmployeeName, @CompanyId, @CreatedById, @CreatedDate, @ManageBy,@EmployeeType);";

                            // Common parameters
                            employeeCommand.Parameters.AddWithValue("@UserId", userId);
                            employeeCommand.Parameters.AddWithValue("@IsActive", isActive);
                            employeeCommand.Parameters.AddWithValue("@Password", password);
                            employeeCommand.Parameters.AddWithValue("@Username", emailId);
                            employeeCommand.Parameters.AddWithValue("@SoftwareId", software.Id);
                            employeeCommand.Parameters.AddWithValue("@CompanyId", _employee.CompanyId);
                            employeeCommand.Parameters.AddWithValue("@EmployeeName", firstName + " " + lastName);
                            employeeCommand.Parameters.AddWithValue("@EmployeeType", selectedEmployeeType.ToString());
                            if (selectedEmployeeType.ToString() != SD.Admin && !string.IsNullOrEmpty(selectedManageBy))
                            {
                                employeeCommand.Parameters.AddWithValue("@ManageBy", Convert.ToInt32(selectedManageBy));
                            }
                            else
                            {
                                employeeCommand.Parameters.AddWithValue("@ManageBy", DBNull.Value);
                            }


                            // Conditional parameters
                            if (string.IsNullOrEmpty(lblID.Text))
                            {
                                employeeCommand.Parameters.AddWithValue("@CreatedById", _employee.UserId);
                                employeeCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                                // Set @UpdatedById and @UpdatedDate as null
                                employeeCommand.Parameters.AddWithValue("@UpdatedById", DBNull.Value);
                                employeeCommand.Parameters.AddWithValue("@UpdatedDate", DBNull.Value);
                            }
                            else
                            {
                                employeeCommand.Parameters.AddWithValue("@UpdatedById", _employee.UserId);
                                employeeCommand.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);

                                // Set @CreatedById and @CreatedDate as null
                                employeeCommand.Parameters.AddWithValue("@CreatedById", DBNull.Value);
                                employeeCommand.Parameters.AddWithValue("@CreatedDate", DBNull.Value);
                            }

                            await employeeCommand.ExecuteNonQueryAsync();
                        }


                        transaction.Commit();
                        MessageBox.Show("Employee registered successfully!");

                        DashboardAdmin dashboardAdmin = Application.OpenForms.OfType<DashboardAdmin>().FirstOrDefault();
                        if (dashboardAdmin != null)
                        {
                            dashboardAdmin.LoadData();
                        }

                        Operators opr = Application.OpenForms.OfType<Operators>().FirstOrDefault();
                        if (opr != null)
                        {
                            opr.LoadData();
                        }

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    btnSaveEmployee.Enabled = true;

                }
            }
        }

        private async Task<CompanySoftware> GetCompanySoftwareAsync()
        {
            CompanySoftware software = new CompanySoftware();

            using (SqlConnection connection = DBHelper.GetConnection())
            {
                await connection.OpenAsync();
                string query = "SELECT TOP 1 * FROM CompanySoftware";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            software.Id = Convert.ToInt32(reader["Id"]);
                            software.CompanySectionName = reader["CompanySectionName"].ToString();
                            software.SoftwareKey = reader["SoftwareKey"].ToString();
                            software.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                        }
                    }
                }
            }

            return software;
        }

        private int IsValidProject()
        {
            int errorCounter = 0;

            if (string.IsNullOrEmpty(txtEmailId.Text))
            {
                errorCounter++;
                errEmail.Visible = true;
            }
            else
            {
                errEmail.Visible = false;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorCounter++;
                errFirstName.Visible = true;
            }
            else
            {
                errFirstName.Visible = false;
            }

            if (string.IsNullOrEmpty(txtMiddleName.Text))
            {
                errorCounter++;
                errMiddleName.Visible = true;
            }
            else
            {
                errMiddleName.Visible = false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorCounter++;
                errLastName.Visible = true;
            }
            else
            {
                errLastName.Visible = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorCounter++;
                errPassword.Visible = true;
            }
            else
            {
                errPassword.Visible = false;
            }

            if (cmbEmployeeType.SelectedIndex == 0)
            {
                errorCounter++;
                lblEmployeeType.Visible = true;
            }
            else
            {
                lblEmployeeType.Visible = false;
            }

            return errorCounter;
        }

        private async Task<bool> IsEmailExist(string emailId)
        {
            try
            {
                using (SqlConnection connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync();

                    string query = "SELECT COUNT(1) FROM CompanyEmployee WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", emailId);

                        int count = (int)await command.ExecuteScalarAsync();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception or handle it as per your requirement
                throw new Exception("An error occurred while checking the email existence.", ex);
            }
        }

        private async Task EditEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync();

                    string query = "SELECT usr.Id, usr.FirstName, usr.MiddleName, usr.LastName, usr.Email, emp.Password, emp.IsActive, emp.EmployeeType " +
                                   "FROM CompanyEmployee emp " +
                                   "INNER JOIN AspNetUsers usr ON emp.UserId = usr.Id " +
                                   "WHERE emp.Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", employeeId);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                lblID.Text = reader["Id"].ToString();
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtMiddleName.Text = reader["MiddleName"].ToString();
                                txtLastName.Text = reader["LastName"].ToString();
                                txtEmailId.Text = reader["Email"].ToString();
                                txtPassword.Text = reader["Password"].ToString();
                                chkIsActived.Checked = Convert.ToBoolean(reader["IsActive"]);
                                cmbEmployeeType.SelectedItem = reader["EmployeeType"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the employee details.", ex);
            }
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtMiddleName.Focus();
            }
        }

        private void txtMiddleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtEmailId.Focus();
            }
        }

        private void txtEmailId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                chkIsActived.Focus();
            }
        }

        private void chkIsActived_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnSaveEmployee.Focus();
            }
        }

        public void BindEmployee()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT Id, EmployeeName FROM CompanyEmployee WHERE SoftwareId = @SoftwareId AND EmployeeType = @EmployeeType ORDER BY Id DESC";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                    cmd.Parameters.AddWithValue("@EmployeeType", SD.Manager);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Create a new DataRow with default values
                        DataRow newRow = dt.NewRow();
                        newRow["Id"] = 0;
                        newRow["EmployeeName"] = "Select Manage";

                        // Insert the new row at the top
                        dt.Rows.InsertAt(newRow, 0);

                        // Bind the DataTable to the ComboBox
                        cmbManageBy.DataSource = dt;
                        cmbManageBy.DisplayMember = "EmployeeName";
                        cmbManageBy.ValueMember = "Id";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployeeType.SelectedItem.ToString() == "Operator")
            {
                BindEmployee();
                cmbManageBy.Visible = true;
                lblManage.Visible = true;
            }
            else
            {
                cmbManageBy.Visible = false;
                lblManage.Visible = false;
            }

        }
    }
}