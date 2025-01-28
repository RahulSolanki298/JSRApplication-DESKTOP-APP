using LocalApplication.Helpers;
using System.Data.SqlClient;
using System.Data;
using LocalApplication.DTO;
using System.Security.Cryptography;

namespace LocalApplication
{
    public partial class ProjectList : Form
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public ProjectList(CompanyEmployee employee)
        {
            InitializeComponent();
            this._employee = employee;

            txtFromDate.ValueChanged += txtFromDate_ValueChanged;
            BindGrid(null, null, null);
        }

        private void BindGrid(DateTime? startDateFilter, DateTime? endDateFilter, string statusFilter)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT pd.Id, pd.ProjectName, c.CustomerName, pd.ManufacturerName,s.Name as SiteName, pd.StartDate, pd.EndDate, pd.ProjectStatus FROM ProjectDetails pd INNER JOIN CompanyCustomer c ON pd.CustomerId = c.Id INNER JOIN Site s on pd.SiteId=s.Id WHERE pd.SoftwareId = {_employee.SoftwareId}";

                    if (startDateFilter.HasValue)
                    {
                        qry += " AND pd.StartDate >= @StartDate";
                    }

                    if (endDateFilter.HasValue)
                    {
                        qry += " AND pd.EndDate <= @EndDate";
                    }

                    if (!string.IsNullOrEmpty(statusFilter))
                    {
                        qry += " AND pd.ProjectStatus = @ProjectStatus";
                    }

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    if (startDateFilter.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDateFilter.Value);
                    }

                    if (endDateFilter.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@EndDate", endDateFilter.Value);
                    }

                    if (!string.IsNullOrEmpty(statusFilter))
                    {
                        cmd.Parameters.AddWithValue("@ProjectStatus", statusFilter);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvProjectList.DataSource = dt;
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }
        }

        private void gvProjectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvProjectList.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                ProjectFM pd = new ProjectFM(_employee, id);
                pd.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            BindGrid(null, null, SD.Pending);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), cmbProjectStatus.Text);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFromDate_ValueChanged(object sender, EventArgs e)
        {
            txtToDate.MinDate = txtFromDate.Value;

            // Optional: If the selected EndDate is less than StartDate, adjust it automatically
            if (txtToDate.Value < txtFromDate.Value)
            {
                txtToDate.Value = txtFromDate.Value;
            }
        }
    }
}
