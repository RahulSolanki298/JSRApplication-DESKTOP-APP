using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class AdminChangePassword : Form
    {
        CompanyEmployee _employee = new CompanyEmployee();
        DBHelper DBHelper = new DBHelper();
        public AdminChangePassword(CompanyEmployee companyEmployee)
        {
            InitializeComponent();
            _employee = companyEmployee;
            lblEmployeeId.Text = _employee.Id.ToString();
            lblOldPassword.Text = _employee.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOldPassword.Text))
            {
                errOldPassword.Text = "Please enter old password.";
                errOldPassword.Visible = true;
                return;
            }
            else if (txtOldPassword.Text != lblOldPassword.Text)
            {
                errOldPassword.Text = "Please enter correct password.";
                errOldPassword.Visible = true;
                return;
            }
            else
            {
                errOldPassword.Visible = false;
            }

            if (String.IsNullOrEmpty(txtNewPassword.Text))
            {
                errNewPassword.Text = "Please enter new password.";
                errNewPassword.Visible = true;
                return;
            }
            else
            {
                errNewPassword.Visible = false;
            }

            if (String.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                errNewPassword.Text = "Please enter Repeat password.";
                errNewPassword.Visible = true;
            }
            else if (txtRepeatPassword.Text != txtNewPassword.Text)
            {
                errNewPassword.Text = "Password doesn't match with new password.";
                errNewPassword.Visible = true;
                return;
            }
            else
            {
                errNewPassword.Visible = false;
            }

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert customer
                    using (var cmdInsertCustomer = new SqlCommand("Update CompanyAdmin set Password=@Password where Id=@Id", connection, transaction))
                    {
                        cmdInsertCustomer.Parameters.AddWithValue("@Password", txtNewPassword.Text);
                        cmdInsertCustomer.Parameters.AddWithValue("@Id", lblEmployeeId.Text);

                        cmdInsertCustomer.ExecuteScalar();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                }
            }

            MessageBox.Show("Password has been changed.");

        }

    }
}
