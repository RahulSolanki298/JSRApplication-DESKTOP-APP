using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class CustomerRegister : Form
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public event EventHandler CustomerSaved;

        public CustomerRegister(CompanyEmployee employee)
        {
            InitializeComponent();
            _employee = employee;
            BindGrid();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCustomerName.Text) && txtCustomerName.Text == "")
            {

                MessageBox.Show("Invalid Input.");
            }
            else
            {

                using (SqlConnection connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    if (Convert.ToInt32(lblID.Text) > 0)
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE CompanyCustomer set CustomerName=@CustomerName,AboutCustomer=@AboutCustomer,IsActive=@IsActive WHERE Id = @Id";
                            command.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                            command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                            command.Parameters.AddWithValue("@AboutCustomer", txtAboutCustomer.Text);
                            command.Parameters.AddWithValue("@IsActive", chkIsActived.Checked ? true : false);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO CompanyCustomer(CustomerName,SoftwareId,AboutCustomer,CompanyId,IsActive)values(@CustomerName,@SoftwareId,@AboutCustomer,@CompanyId,@IsActive)";
                            command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                            command.Parameters.AddWithValue("@AboutCustomer", txtAboutCustomer.Text);
                            command.Parameters.AddWithValue("@IsActive", chkIsActived.Checked ? true : false);
                            command.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                            command.Parameters.AddWithValue("@CompanyId", _employee.CompanyId);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                CustomerSaved?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Customer name has been saved.");
                BindGrid();
                clear();
                this.Close();
            }
        }

        private void BindGrid()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT Id,CustomerName,IsActive from CompanyCustomer WHERE SoftwareId = {_employee.SoftwareId} Order by Id  Desc";

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCustomer.DataSource = dt;
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }
        }

        private void GetEditData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT * from CompanyCustomer WHERE Id = {Convert.ToInt32(lblID.Text)}";

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                        txtAboutCustomer.Text = dt.Rows[0]["AboutCustomer"].ToString();
                        chkIsActived.Checked = dt.Rows[0]["IsActive"].ToString() == "True" ? true : false;
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }
        }

        private void clear()
        {
            txtAboutCustomer.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            chkIsActived.Checked = false;
            lblID.Text = "0";
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                lblID.Text = row.Cells["Id"].Value.ToString();
                GetEditData();
            }
        }

        
    }
}
