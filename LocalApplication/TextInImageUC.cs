using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class TextInImageUC : UserControl
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        private int projectId = 0;

        public TextInImageUC(int PId, CompanyEmployee employee)
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

        private void TextInImageUC_Load(object sender, EventArgs e)
        {

        }

        private void chkImageName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkWP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDTS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkManufacturer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkManufacturing_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkSiteName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkCriteriaBasket_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "0")
            {
                var result = AddTextToImage();
                if (result == true)
                {
                    MessageBox.Show("Text in image added successfully");
                }
                else
                {
                    MessageBox.Show("Something is wrong.");
                }
            }
            else
            {
                var result = UpdateTextToImage();
                if (result == true)
                {
                    MessageBox.Show("Text in image request updated successfully");
                }
                else
                {
                    MessageBox.Show("Something is wrong.");
                }
            }

        }

        private bool AddTextToImage()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert project
                    using (var cmdInsertProject = new SqlCommand("INSERT INTO TextInImage (PDId,SoftwareId, IsImageName,WPOfProduct,DateAndShift,IsManufacturer,ManufacturingPlantAndLine,SiteName,CustomerName,CriteriaName) " +
                        "VALUES (@PDId,@SoftwareId, @IsImageName,@WPOfProduct,@DateAndShift,@IsManufacturer,@ManufacturingPlantAndLine,@SiteName,@CustomerName,@CriteriaName); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@PDId", projectId);
                        cmdInsertProject.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertProject.Parameters.AddWithValue("@IsImageName", chkImageName.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@WPOfProduct", chkWP.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@DateAndShift", chkDTS.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@IsManufacturer", chkManufacturer.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@ManufacturingPlantAndLine", chkManufacturing.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@SiteName", chkSiteName.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@CustomerName", chkCustomerName.Checked ? true : false);
                        cmdInsertProject.Parameters.AddWithValue("@CriteriaName", chkCriteriaBasket.Checked ? true : false);
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

        private bool UpdateTextToImage()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var cmdUpdateText = new SqlCommand("UPDATE TextInImage SET IsImageName=@IsImageName,WPOfProduct=@WPOfProduct,DateAndShift=@DateAndShift,IsManufacturer=@IsManufacturer,ManufacturingPlantAndLine=@ManufacturingPlantAndLine,SiteName=@SiteName,CustomerName=@CustomerName,CriteriaName=@CriteriaName where Id=@Id", connection, transaction))
                        {
                            cmdUpdateText.Parameters.AddWithValue("@WPOfProduct", chkWP.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@DateAndShift", chkDTS.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@IsManufacturer", chkManufacturer.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@ManufacturingPlantAndLine", chkManufacturing.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@SiteName", chkSiteName.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@CustomerName", chkCustomerName.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@CriteriaName", chkCriteriaBasket.Checked);
                            cmdUpdateText.Parameters.AddWithValue("@IsImageName", chkImageName.Checked);
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


        private void GetEditData(int projectId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select * from TextInImage where PDId=@projectId";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@projectId", projectId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblID.Text = row["Id"].ToString();
                        chkImageName.Checked = Convert.ToBoolean(row["IsImageName"]);
                        chkWP.Checked = Convert.ToBoolean(row["WPOfProduct"]);
                        chkDTS.Checked = Convert.ToBoolean(row["DateAndShift"]);
                        chkManufacturer.Checked = Convert.ToBoolean(row["IsManufacturer"]);
                        chkManufacturing.Checked = Convert.ToBoolean(row["ManufacturingPlantAndLine"]);
                        chkSiteName.Checked = Convert.ToBoolean(row["SiteName"]);
                        chkCustomerName.Checked = Convert.ToBoolean(row["CustomerName"]);
                        chkCriteriaBasket.Checked = Convert.ToBoolean(row["CriteriaName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked == true)
            {
                chkImageName.Checked = true;
                chkManufacturer.Checked = true;
                chkManufacturing.Checked = true;
                chkSiteName.Checked = true;
                chkWP.Checked = true;
                chkCriteriaBasket.Checked = true;
                chkCustomerName.Checked = true;
                chkDTS.Checked = true;
            }
            else
            {
                chkImageName.Checked = false;
                chkManufacturer.Checked = false;
                chkManufacturing.Checked = false;
                chkSiteName.Checked = false;
                chkWP.Checked = false;
                chkCustomerName.Checked = false;
                chkDTS.Checked = false;
                chkCriteriaBasket.Checked = false;
            }
        }
    }
}
