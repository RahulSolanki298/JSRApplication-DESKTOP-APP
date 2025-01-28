using LocalApplication.Helpers;
using System.Data.SqlClient;
using System.Data;
using LocalApplication.DTO;

namespace LocalApplication
{
    public partial class ImageProcessData : Form
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public ImageProcessData(CompanyEmployee employee, int? pId = 0)
        {
            InitializeComponent();
            this._employee = employee;
            lblProjectId.Text = pId.ToString();
            //txtFromDate.MinDate = DateTime.Today;
            //txtToDate.MinDate = DateTime.Today;

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
                    string qry = $"SELECT Id, CONVERT(VARCHAR(10), Date, 105) AS Date,ModuleSerialNo,ModuleLocation,ImageName,ImageResult,SeverityScore,ModuleCountName,DefectData,Crack,TreeCrack,DeadCell,DarkArea,OpenSoldering,FingerInteruption,BackSheetCut,IsSuccess FROM ImageProcessData WHERE PDId = {Convert.ToInt32(lblProjectId.Text)}";

                    if (!string.IsNullOrEmpty(statusFilter))
                    {
                        qry += " AND ImageResult = @ImageResult";
                    }

                    if (startDateFilter.HasValue)
                    {
                        qry += " AND Date >= @StartDate";
                    }

                    if (endDateFilter.HasValue)
                    {
                        qry += " And Date <= @EndDate";
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
                        cmd.Parameters.AddWithValue("@ImageResult", statusFilter);
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

        private void gvProjectList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.Close();
                DataGridViewRow row = gvProjectList.Rows[e.RowIndex];

                if (!String.IsNullOrEmpty(row.Cells["Id"].Value.ToString()))
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    InspectionProcess pd = new InspectionProcess(Convert.ToInt32(lblProjectId.Text), _employee, false, id);
                    pd.Show();
                }
            }
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
