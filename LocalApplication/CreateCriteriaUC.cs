using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class CreateCriteriaUC : UserControl
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        private int projectId = 0;
        public event EventHandler<int> IDChanged;
        public CreateCriteriaUC(CompanyEmployee employee, int criteriaId = 0)
        {
            InitializeComponent();
            _employee = employee;
            projectId = criteriaId;
            clear();
            BindGrid();
            if (projectId > 0)
            {
                GetEditData(projectId);
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "0")
            {
                var result = AddCriteriaBasket();
                if (result == true)
                {
                    MessageBox.Show("Criteria basket added successfully");
                }
            }
            else
            {
                var result = UpdateCriteriaBasket();
                if (result == true)
                {
                    MessageBox.Show("Criteria basket updated successfully");
                }
            }
            BindGrid();
            clear();
        }

        private bool AddCriteriaBasket()
        {
            if (String.IsNullOrEmpty(txtBasketName.Text))
            {
                errCriteriaBasket.Text = "Please enter basket name.";
                errCriteriaBasket.Visible = true;
                return false;
            }
            else if (IsExistCriteria(txtBasketName.Text))
            {
                errCriteriaBasket.Visible = true;
                return false;
            }

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert project
                    using (var cmdInsertProject = new SqlCommand("INSERT INTO CriteriaBasket (Name,SoftwareId) VALUES (@Name,@SoftwareId); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@Name", txtBasketName.Text);
                        cmdInsertProject.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        var ImageProcessId = Convert.ToInt32(cmdInsertProject.ExecuteScalar());
                        lblID.Text = ImageProcessId.ToString();
                        IDChanged?.Invoke(this, ImageProcessId);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private bool UpdateCriteriaBasket()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var cmdUpdateText = new SqlCommand("UPDATE CriteriaBasket SET Name=@Name where Id=@Id", connection, transaction))
                        {
                            cmdUpdateText.Parameters.AddWithValue("@Name", txtBasketName.Text);
                            cmdUpdateText.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                            cmdUpdateText.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }


        private void GetEditData(int Id)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select Id,Name from CriteriaBasket where Id=@Id";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblID.Text = row["Id"].ToString();
                        txtBasketName.Text = row["Name"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
            }
        }

        private void BindGrid()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT Id,Name from CriteriaBasket Order by Id Desc";

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

        private bool IsExistCriteria(string criteriaName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select * from CriteriaBasket where Name=@Name";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@Name", criteriaName);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
                return false;

            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];

                if (!String.IsNullOrEmpty(row.Cells["Id"].Value.ToString()))
                {
                    lblID.Text = row.Cells["Id"].Value.ToString();
                    GetEditData(Convert.ToInt32(lblID.Text));
                    btnSave.Enabled = false;
                    IDChanged?.Invoke(this, Convert.ToInt32(lblID.Text));
                }
            }
        }

        private void clear()
        {
            txtBasketName.Text = "";
            lblID.Text = "0";
            btnSave.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
