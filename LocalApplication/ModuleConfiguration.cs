using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class ModuleConfiguration : UserControl
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public event EventHandler<int> IDChanged;
        int projectId = 0;

        public ModuleConfiguration(CompanyEmployee employee, int? pId = 0)
        {
            InitializeComponent();
            _employee = employee;
            cmbModuleSetting.SelectedIndex = 0;
            if (pId > 0)
            {
                projectId = (int)pId;
                IsExist(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var Validate = Validation();
            if (Validate == false)
            {
                return;
            }
            if (IsExist(false))
            {
                UpdateSetting();
            }
            else
            {
                InsertSetting();
            }
            MessageBox.Show("Setting saved successfully.");
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

        public void InsertSetting()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Setting (SoftwareId, ProjectId, InputPath, OutputPath,Module_INV_CB,Inv_CB_Start,Inv_CB_End,Str_Start,Str_End,ModuleNo_Start,ModuleNo_End) VALUES (@SoftwareId, @ProjectId, @InputPath, @OutputPath,@Module_INV_CB,@Inv_CB_Start,@Inv_CB_End,@Str_Start,@Str_End,@ModuleNo_Start,@ModuleNo_End)";
                    command.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@InputPath", txtInputPath.Text);
                    command.Parameters.AddWithValue("@OutputPath", txtOutputFolder.Text);
                    command.Parameters.AddWithValue("@Module_INV_CB", cmbModuleSetting.SelectedText);
                    command.Parameters.AddWithValue("@Inv_CB_Start", txtStart.Text);
                    command.Parameters.AddWithValue("@Inv_CB_End", txtEnd.Text);
                    command.Parameters.AddWithValue("@Str_Start", txtStrStart.Text);
                    command.Parameters.AddWithValue("@Str_End", txtStrEnd.Text);
                    //command.Parameters.AddWithValue("@Position", cmbPosition.SelectedText);
                    command.Parameters.AddWithValue("@ModuleNo_Start", txtModuleStart.Text);
                    command.Parameters.AddWithValue("@ModuleNo_End", txtModuleEnd.Text);
                    command.ExecuteNonQuery();
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
                    command.CommandText = "UPDATE Setting SET InputPath = @InputPath, OutputPath = @OutputPath,Module_INV_CB=@Module_INV_CB,Inv_CB_Start=@Inv_CB_Start,Inv_CB_End=@Inv_CB_End,Str_Start=@Str_Start,Str_End=@Str_End,ModuleNo_Start=@ModuleNo_Start,ModuleNo_End=@ModuleNo_End WHERE Id = @Id";
                    command.Parameters.AddWithValue("@InputPath", txtInputPath.Text);
                    command.Parameters.AddWithValue("@OutputPath", txtOutputFolder.Text);
                    command.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                    command.Parameters.AddWithValue("@Module_INV_CB", cmbModuleSetting.SelectedItem);
                    command.Parameters.AddWithValue("@Inv_CB_Start", txtStart.Text);
                    command.Parameters.AddWithValue("@Inv_CB_End", txtEnd.Text);
                    command.Parameters.AddWithValue("@Str_Start", txtStrStart.Text);
                    command.Parameters.AddWithValue("@Str_End", txtStrEnd.Text);
                    //command.Parameters.AddWithValue("@Position", cmbPosition.SelectedItem);
                    command.Parameters.AddWithValue("@ModuleNo_Start", txtModuleStart.Text);
                    command.Parameters.AddWithValue("@ModuleNo_End", txtModuleEnd.Text);
                    command.ExecuteNonQuery();
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
                            cmbModuleSetting.SelectedItem = dt.Rows[0]["Module_INV_CB"].ToString();
                            //cmbPosition.SelectedItem = dt.Rows[0]["Position"].ToString();
                            txtStart.Text = dt.Rows[0]["Inv_CB_Start"].ToString();
                            txtEnd.Text = dt.Rows[0]["Inv_CB_End"].ToString();
                            txtStrStart.Text = dt.Rows[0]["Str_Start"].ToString();
                            txtStrEnd.Text = dt.Rows[0]["Str_End"].ToString();
                            txtModuleStart.Text = dt.Rows[0]["ModuleNo_Start"].ToString();
                            txtModuleEnd.Text = dt.Rows[0]["ModuleNo_End"].ToString();
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

        private bool Validation()
        {

            int startValue, endValue;

            if(String.IsNullOrEmpty(txtStart.Text)
                && String.IsNullOrEmpty(txtEnd.Text))
            {
                return true;
            }

            if (!int.TryParse(txtStart.Text, out startValue))
            {
                MessageBox.Show("Please enter a valid integer in the Start textbox.");
                return false;
            }

            if (!int.TryParse(txtEnd.Text, out endValue))
            {
                MessageBox.Show("Please enter a valid integer in the End textbox.");
                return false;
            }

            if (startValue >= endValue)
            {
                MessageBox.Show("The Start value must be smaller than the End value.");
                return false;
            }

            int strStartVal = 0;
            int strEndVal = 0;

            if (String.IsNullOrEmpty(txtStrStart.Text)
                && String.IsNullOrEmpty(txtStrEnd.Text))
            {
                return true;
            }

            if (!int.TryParse(txtStrStart.Text, out strStartVal))
            {
                MessageBox.Show("Please enter a valid integer in the Start textbox.");
                return false;
            }

            if (!int.TryParse(txtStrEnd.Text, out strEndVal))
            {
                MessageBox.Show("Please enter a valid integer in the End textbox.");
                return false;
            }

            if (strStartVal >= strEndVal)
            {
                MessageBox.Show("The Start value must be smaller than the End value.");
                return false;
            }

            var strModuleStart = 0;
            var strModuleEnd = 0;

            if (String.IsNullOrEmpty(txtModuleStart.Text)
                && String.IsNullOrEmpty(txtModuleEnd.Text))
            {
                return true;
            }

            if (!int.TryParse(txtModuleStart.Text, out strModuleStart))
            {
                MessageBox.Show("Please enter a valid integer in the Start textbox.");
                return false;
            }

            if (!int.TryParse(txtModuleEnd.Text, out strModuleEnd))
            {
                MessageBox.Show("Please enter a valid integer in the End textbox.");
                return false;
            }

            if (strModuleStart >= strModuleEnd)
            {
                MessageBox.Show("The Start value must be smaller than the End value.");
                return false;
            }
            return true;

        }
    }
}
