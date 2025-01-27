using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class SettingForm : Form
    {
        CompanyEmployee _employee = new CompanyEmployee();
        DBHelper DBHelper = new DBHelper();
        private int projectId = 0;
        public SettingForm(int PId, CompanyEmployee employee)
        {
            InitializeComponent();
            _employee = employee;
            projectId = PId;
            IsExist(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsExist(false))
            {
                // Update
                UpdateSetting();
            }
            else
            {
                // Insert
                InsertSetting();
            }
            MessageBox.Show("Setting saved successfully.");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    txtOutputFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnInputUpload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    txtInputPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private bool IsExist(bool isLoad)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select * from Setting where ProjectId='{projectId}'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (isLoad)
                        {
                            txtInputPath.Text = dt.Rows[0]["InputPath"].ToString();
                            txtOutputFolder.Text = dt.Rows[0]["OutputPath"].ToString();
                            lblID.Text = dt.Rows[0]["Id"].ToString();
                        }

                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}");
                    return false;
                }
            }


        }

        public void UpdateSetting()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Setting SET InputPath = @InputPath, OutputPath = @OutputPath WHERE Id = @Id";
                    command.Parameters.AddWithValue("@InputPath", txtInputPath.Text);
                    command.Parameters.AddWithValue("@OutputPath", txtOutputFolder.Text);
                    command.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertSetting()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Setting (SoftwareId, ProjectId, InputPath, OutputPath) VALUES (@SoftwareId, @ProjectId, @InputPath, @OutputPath)";
                    command.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@InputPath", txtInputPath.Text);
                    command.Parameters.AddWithValue("@OutputPath", txtOutputFolder.Text);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
