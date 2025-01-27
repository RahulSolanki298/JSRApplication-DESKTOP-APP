using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class ImageProcessUC : UserControl
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        private int projectId = 0;
        public ImageProcessUC(int PId, CompanyEmployee employee)
        {
            InitializeComponent();
            _employee = employee;
            projectId = PId;
            if (_employee.EmployeeType == SD.Operator)
            {
                btnSave.Enabled = false;
            }

            if (projectId > 0)
            {
                GetEditData(projectId);
            }
        }

        private void chkExposure_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkExposure.Checked)
            //{
            //    txtExposureSet.Visible = true;
            //}
            //else
            //{
            //    txtExposureSet.Visible = false;
            //}
        }

        private void chkImageRename_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkImageRename.Checked)
            //{
            //    cmbRename.Visible = true;
            //}
            //else
            //{
            //    cmbRename.Visible = false;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!IsValidProjectData())
            //{
            //    MessageBox.Show("Please fill in all required fields.");
            //    return;
            //}

            if (lblID.Text != "0")
            {
                var result = UpdateProject();
                if (result == true)
                {
                    MessageBox.Show("Image process request updated successfully");
                }
                else
                {
                    MessageBox.Show("Something is wrong.");
                }
            }
            else
            {
                var result = AddProject();
                if (result == true)
                {
                    MessageBox.Show("Image process request added successfully");
                }
                else
                {
                    MessageBox.Show("Something is wrong.");
                }
            }
        }
        private bool AddProject()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert project
                    using (var cmdInsertProject = new SqlCommand("INSERT INTO ImageProcessReq (PDId,SoftwareId, IsExposureSet,IsDefectMarking,IsPerspectiveCorrection,IsRename,IsTextInImage,IsImageFullScreen,IsSeverityScore) " +
                        "VALUES (@PDId,@SoftwareId, @IsExposureSet,@IsDefectMarking,@IsPerspectiveCorrection,@IsRename,@IsTextInImage,@IsImageFullScreen,@IsSeverityScore); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@PDId", projectId);
                        cmdInsertProject.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertProject.Parameters.AddWithValue("@IsExposureSet", chkExposure.Checked ? 1 : 0);
                        //if (chkExposure.Checked)
                        //{
                        //    cmdInsertProject.Parameters.AddWithValue("@ExposureSetValue", txtExposureSet.Text);
                        //}
                        //else
                        //{
                        //    cmdInsertProject.Parameters.AddWithValue("@ExposureSetValue", "-");
                        //}
                        cmdInsertProject.Parameters.AddWithValue("@IsDefectMarking", chkDefect.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsPerspectiveCorrection", chkPerspective.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsRename", chkImageRename.Checked ? 1 : 0);
                        // cmdInsertProject.Parameters.AddWithValue("@RenameWith", cmbRename.SelectedItem);
                        cmdInsertProject.Parameters.AddWithValue("@IsTextInImage", chkIsertImages.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsImageFullScreen", ImageFullScreen.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsSeverityScore", chkSeverity.Checked ? 1 : 0);
                        var ImageProcessId = Convert.ToInt32(cmdInsertProject.ExecuteScalar());
                        lblID.Text = ImageProcessId.ToString();
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

        private bool UpdateProject()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert project
                    using (var cmdInsertProject = new SqlCommand("UPDATE ImageProcessReq set PDId=@PDId,SoftwareId=@SoftwareId, IsExposureSet=@IsExposureSet,IsDefectMarking=@IsDefectMarking,IsPerspectiveCorrection=@IsPerspectiveCorrection,IsRename=@IsRename,IsTextInImage=@IsTextInImage,IsImageFullScreen=@IsImageFullScreen,IsSeverityScore=@IsSeverityScore where Id=@Id", connection, transaction))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                        cmdInsertProject.Parameters.AddWithValue("@PDId", projectId);
                        cmdInsertProject.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertProject.Parameters.AddWithValue("@IsExposureSet", chkExposure.Checked ? 1 : 0);
                        //if (chkExposure.Checked)
                        //{
                        //    cmdInsertProject.Parameters.AddWithValue("@ExposureSetValue", txtExposureSet.Text);
                        //}
                        //else
                        //{
                        //    cmdInsertProject.Parameters.AddWithValue("@ExposureSetValue", "-");
                        //}
                        cmdInsertProject.Parameters.AddWithValue("@IsDefectMarking", chkDefect.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsPerspectiveCorrection", chkPerspective.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsRename", chkImageRename.Checked ? 1 : 0);
                        //cmdInsertProject.Parameters.AddWithValue("@RenameWith", cmbRename.SelectedItem);
                        cmdInsertProject.Parameters.AddWithValue("@IsTextInImage", chkIsertImages.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsImageFullScreen", ImageFullScreen.Checked ? 1 : 0);
                        cmdInsertProject.Parameters.AddWithValue("@IsSeverityScore", chkSeverity.Checked ? 1 : 0);
                        var ImageProcessId = Convert.ToInt32(cmdInsertProject.ExecuteScalar());
                        lblID.Text = ImageProcessId.ToString();
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

        private bool IsValidProjectData()
        {
            if (chkExposure.Checked && string.IsNullOrEmpty(txtExposureSet.Text))
            {
                MessageBox.Show("Exposure Set is required.");
                return false;
            }

            return true;
        }

        private void GetEditData(int projectId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT * FROM ImageProcessReq WHERE PDId = @projectId";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblID.Text = row["Id"].ToString();
                        chkExposure.Checked = Convert.ToBoolean(row["IsExposureSet"]);
                        txtExposureSet.Text = row["ExposureSetValue"].ToString();
                        chkDefect.Checked = Convert.ToBoolean(row["IsDefectMarking"]);
                        chkPerspective.Checked = Convert.ToBoolean(row["IsPerspectiveCorrection"]);
                        chkImageRename.Checked = Convert.ToBoolean(row["IsRename"]);
                        ImageFullScreen.Checked = Convert.ToBoolean(row["IsImageFullScreen"]);
                        chkSeverity.Checked = Convert.ToBoolean(row["IsSeverityScore"]);
                        chkIsertImages.Checked = Convert.ToBoolean(row["IsTextInImage"]);

                        string renameWith = row["RenameWith"].ToString();
                        foreach (var item in cmbRename.Items)
                        {
                            if (item.ToString() == renameWith)
                            {
                                cmbRename.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked == true)
            {
                chkExposure.Checked = true;
                chkDefect.Checked = true;
                chkImageRename.Checked = true;
                chkIsertImages.Checked = true;
                chkPerspective.Checked = true;
                chkSeverity.Checked = true;
                ImageFullScreen.Checked = true;
            }
            else
            {
                chkExposure.Checked = false;
                chkDefect.Checked = false;
                chkImageRename.Checked = false;
                chkIsertImages.Checked = false;
                chkPerspective.Checked = false;
                chkSeverity.Checked = false;
                ImageFullScreen.Checked = false;
            }
        }
    }
}
