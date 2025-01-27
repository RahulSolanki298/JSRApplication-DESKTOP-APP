using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LocalApplication
{
    public partial class ProductDetailsUC : UserControl
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public event EventHandler<int> IDChanged;

        public ProductDetailsUC(CompanyEmployee employee, int? pId = 0)
        {
            InitializeComponent();
            _employee = employee;
            dtStartDate.MinDate = DateTime.Today;
            dtEndDate.MinDate = DateTime.Today;

            dtStartDate.ValueChanged += DtStartDate_ValueChanged;


            BindCustomerData();
            BindCustomerBasket();
            BindSite();
            if (pId > 0)
            {
                lblID.Text = pId.ToString();
                EditProject((int)pId);
            }
        }

        private bool AddProject()
        {

            UpdateStateForAllProject();
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();


                    // Insert project
                    using (var cmdInsertProject = new SqlCommand("INSERT INTO ProjectDetails (ProjectName,SoftwareId, WP_Product, Date, Shift, ManufacturerName, ManufacturingBy, CustomerId, CriteriaBasketId, ModuleMatrix, ElementWith, CellSize, SiteId,ProjectStatus,StartDate,EndDate,SubCriteriaBasketId,EmployeeId) VALUES (@ProjectName,@SoftwareId, @WP_Product, @Date, @Shift, @ManufacturerName, @ManufacturingBy, @CustomerId, @CriteriaBasketId, @ModuleMatrix, @ElementWith, @CellSize, @SiteId,@ProjectStatus,@StartDate,@EndDate,@SubCriteriaBasketId,@EmployeeId); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                        cmdInsertProject.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertProject.Parameters.AddWithValue("@WP_Product", txtWP.Text);
                        cmdInsertProject.Parameters.AddWithValue("@Date", dtDate.Value);
                        cmdInsertProject.Parameters.AddWithValue("@Shift", txtShift.Text);
                        cmdInsertProject.Parameters.AddWithValue("@ManufacturerName", txtManufacturer.Text ?? DBNull.Value.ToString());
                        cmdInsertProject.Parameters.AddWithValue("@ManufacturingBy", txtPlantAndLine.Text ?? DBNull.Value.ToString());
                        cmdInsertProject.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(cmbCustomerName.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@CriteriaBasketId", Convert.ToInt32(cmbBasket.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@ModuleMatrix", txtLength.Text + "*" + txtWidth.Text);
                        cmdInsertProject.Parameters.AddWithValue("@ElementWith", cmbOption.Text);
                        cmdInsertProject.Parameters.AddWithValue("@CellSize", txtCellSize.Text);
                        cmdInsertProject.Parameters.AddWithValue("@SiteId", Convert.ToInt32(cmbSite.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(dtStartDate.Text));
                        cmdInsertProject.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(dtEndDate.Text));
                        cmdInsertProject.Parameters.AddWithValue("@ProjectStatus", cmbChangeStatus.Text);
                        cmdInsertProject.Parameters.AddWithValue("@SubCriteriaBasketId", Convert.ToInt32(cmbSubBasket.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@EmployeeId", _employee.Id);
                        var productId = Convert.ToInt32(cmdInsertProject.ExecuteScalar());
                        lblID.Text = productId.ToString();
                        IDChanged?.Invoke(this, productId);
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
            if (cmbChangeStatus.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select status option...");
                return false;
            }
            if (cmbChangeStatus.SelectedItem.ToString() == SD.Pending)
            {
                UpdateStateForAllProject();
            }


            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {

                    using (var cmdInsertProject = new SqlCommand("UPDATE ProjectDetails set ProjectName=@ProjectName,WP_Product=@WP_Product, Date=@Date, Shift=@Shift, ManufacturerName=@ManufacturerName, ManufacturingBy=@ManufacturingBy, CriteriaBasketId=@CriteriaBasketId, ModuleMatrix=@ModuleMatrix, ElementWith=@ElementWith, CellSize=@CellSize, SiteId=@SiteId,ProjectStatus=@ProjectStatus,CustomerId=@CustomerId,SubCriteriaBasketId=@SubCriteriaBasketId,ReplicateStatus=@ReplicateStatus where Id=@Id", connection))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                        cmdInsertProject.Parameters.AddWithValue("@WP_Product", txtWP.Text);
                        cmdInsertProject.Parameters.AddWithValue("@Date", dtDate.Value);
                        cmdInsertProject.Parameters.AddWithValue("@Shift", txtShift.Text);
                        cmdInsertProject.Parameters.AddWithValue("@ManufacturerName", txtManufacturer.Text);
                        cmdInsertProject.Parameters.AddWithValue("@ManufacturingBy", txtPlantAndLine.Text);
                        cmdInsertProject.Parameters.AddWithValue("@CriteriaBasketId", Convert.ToInt32(cmbBasket.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@ModuleMatrix", txtLength.Text + "*" + txtWidth.Text);
                        cmdInsertProject.Parameters.AddWithValue("@ElementWith", cmbOption.Text);
                        cmdInsertProject.Parameters.AddWithValue("@CellSize", txtCellSize.Text);
                        cmdInsertProject.Parameters.AddWithValue("@SiteId", Convert.ToInt32(cmbSite.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@ProjectStatus", cmbChangeStatus.Text);
                        cmdInsertProject.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                        cmdInsertProject.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(cmbCustomerName.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@SubCriteriaBasketId", Convert.ToInt32(cmbSubBasket.SelectedValue));
                        cmdInsertProject.Parameters.AddWithValue("@ReplicateStatus", DBNull.Value);
                        cmdInsertProject.ExecuteNonQuery();
                        cmdInsertProject.ExecuteScalar();

                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void EditProject(int pdID)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select p.Id,p.ProjectName,c.Id as CustomerId,c.CustomerName,p.WP_Product,p.Date,p.Shift,p.ManufacturerName,p.ManufacturingBy,p.ModuleMatrix,p.ElementWith,p.CellSize,p.ProjectStatus,site.Id as SiteId,p.CriteriaBasketId,p.SubCriteriaBasketId from ProjectDetails p inner join CompanyCustomer c on p.CustomerId=c.Id inner join Site site on p.SiteId=site.Id inner join CriteriaBasket cb on p.CriteriaBasketId=cb.Id where p.Id='{pdID}'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        lblID.Text = dt.Rows[0]["Id"].ToString();
                        txtProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                        txtShift.Text = dt.Rows[0]["Shift"].ToString();
                        var customerId = dt.Rows[0]["CustomerId"].ToString();
                        cmbCustomerName.SelectedValue = customerId;
                        dtDate.Text = dt.Rows[0]["Date"].ToString();
                        txtWP.Text = dt.Rows[0]["WP_Product"].ToString();
                        txtManufacturer.Text = dt.Rows[0]["ManufacturerName"].ToString();
                        txtPlantAndLine.Text = dt.Rows[0]["ManufacturingBy"].ToString();
                        var BasketId = dt.Rows[0]["CriteriaBasketId"].ToString();
                        cmbBasket.SelectedValue = BasketId;
                        var SubBasketId = dt.Rows[0]["SubCriteriaBasketId"].ToString();
                        cmbSubBasket.SelectedValue = SubBasketId;
                        var SiteId = dt.Rows[0]["SiteId"].ToString();
                        cmbSite.SelectedValue = SiteId;
                        var moduleMatrix = dt.Rows[0]["ModuleMatrix"].ToString();
                        var result = moduleMatrix.Split("*");
                        txtLength.Text = result[0];
                        txtWidth.Text = result[1];
                        txtCellSize.Text = dt.Rows[0]["CellSize"].ToString();
                        string projectStatus = dt.Rows[0]["ProjectStatus"].ToString();
                        if (cmbChangeStatus.Items.Contains(projectStatus))
                        {
                            cmbChangeStatus.SelectedItem = projectStatus;
                        }
                        else
                        {
                            cmbChangeStatus.Items.Add(projectStatus);
                            cmbChangeStatus.SelectedItem = projectStatus;
                        }

                        var elementWithValue = dt.Rows[0]["ElementWith"].ToString();
                        foreach (var item in cmbOption.Items)
                        {
                            if (item.ToString() == elementWithValue)
                            {
                                cmbOption.SelectedItem = item;
                                break;
                            }
                        }

                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var valid = IsValidProject();

            if (valid > 0)
            {
                MessageBox.Show("Please fill required project details.");
            }
            else
            {
                if (lblID.Text == "0")
                {
                    AddProject();
                }
                else
                {
                    UpdateProject();
                }
                MessageBox.Show("Project has been saved successfully.");
            }
        }

        private void lblAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerRegister customerRegister = new CustomerRegister(_employee);
            customerRegister.ShowDialog();
        }

        public void BindCustomerData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT Id, CustomerName FROM CompanyCustomer WHERE SoftwareId = @SoftwareId Order By Id Desc";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbCustomerName.DataSource = dt;
                        cmbCustomerName.DisplayMember = "CustomerName"; 
                        cmbCustomerName.ValueMember = "Id"; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindCustomerData();
        }

        public void BindCustomerBasket()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT Id,Name FROM CriteriaBasket Order By Id Desc";
                    SqlCommand cmd = new SqlCommand(qry, connection);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbBasket.DataSource = dt;
                        cmbBasket.DisplayMember = "Name"; 
                        cmbBasket.ValueMember = "Id"; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void lblAddBasket_Click(object sender, EventArgs e)
        {
            try
            {
                CriteriaFM criteriaFM = new CriteriaFM(_employee);
                criteriaFM.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void refBasket_Click(object sender, EventArgs e)
        {
            BindCustomerBasket();
        }

        private void btnCloseBasket_Click(object sender, EventArgs e)
        {
            cmbBasket.Visible = true;
            lblAddBasket.Visible = true;
            refBasket.Visible = true;
        }

        private void lblSaveSite_Click(object sender, EventArgs e)
        {
            txtSiteName.Visible = true;
            btnSiteClose.Visible = true;
            lblAddSite.Visible = true;

            lblSaveSite.Visible = false;
            cmbSite.Visible = false;

        }

        private void btnSiteClose_Click(object sender, EventArgs e)
        {
            txtSiteName.Visible = false;
            btnSiteClose.Visible = false;
            lblAddSite.Visible = false;

            lblSaveSite.Visible = true;
            cmbSite.Visible = true;

        }

        private void lblAddSite_Click(object sender, EventArgs e)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    int customerId;
                    using (var cmdInsertCustomer = new SqlCommand("INSERT INTO Site (Name,SoftwareId) VALUES (@Name,@SoftwareId); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertCustomer.Parameters.AddWithValue("@Name", txtSiteName.Text);
                        cmdInsertCustomer.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        customerId = Convert.ToInt32(cmdInsertCustomer.ExecuteScalar());
                    }

                    txtSiteName.Visible = false;
                    btnSiteClose.Visible = false;
                    lblAddSite.Visible = false;

                    lblSaveSite.Visible = true;
                    cmbSite.Visible = true;
                    txtSiteName.Text = string.Empty;
                    transaction.Commit();
                    BindSite();
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                }
            }
        }

        public void BindSite()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT Id,Name FROM Site where SoftwareId=@SoftwareId Order By Id Desc";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbSite.DataSource = dt;
                        cmbSite.DisplayMember = "Name";
                        cmbSite.ValueMember = "Id";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        private void cmbBasket_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedVal = cmbBasket.SelectedValue;

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT Id,BasketName FROM AcceptanceCriteriaMain where CriteriaBasketId=@CriteriaBasketId";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@CriteriaBasketId", Convert.ToInt32(selectedVal));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbSubBasket.DataSource = dt;
                        cmbSubBasket.DisplayMember = "BasketName"; 
                        cmbSubBasket.ValueMember = "Id"; 
                        cmbSubBasket.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }

        private bool UpdateStateForAllProject()
        {
            if (cmbChangeStatus.SelectedItem.ToString() != SD.Pending)
            {
                MessageBox.Show("Please select status option...");
                return false;
            }
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {

                    using (var cmdInsertProject = new SqlCommand("UPDATE ProjectDetails set ProjectStatus=@ProjectStatus where SoftwareId=@SoftwareId and ProjectStatus=@ProjectStatusId", connection))
                    {
                        cmdInsertProject.Parameters.AddWithValue("@ProjectStatus", SD.Hold);
                        cmdInsertProject.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertProject.Parameters.AddWithValue("@ProjectStatusId", cmbChangeStatus.SelectedItem);
                        cmdInsertProject.ExecuteNonQuery();
                        cmdInsertProject.ExecuteScalar();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        private int IsValidProject()
        {
            int errorCounter = 0;

            if (String.IsNullOrEmpty(txtProjectName.Text))
            {
                errorCounter++;
                errProject.Visible = true;
            }
            else
            {
                errProject.Visible = false;
            }

            if (String.IsNullOrEmpty(txtWP.Text))
            {
                errorCounter++;
                errWP.Visible = true;
            }
            else if (!int.TryParse(txtWP.Text, out int cellSize))
            {
                errorCounter++;
                errWP.Text = "Please enter product wattage (int).";
                errWP.Visible = true;
            }
            else
            {
                errWP.Visible = false;
            }

            if (cmbSite.SelectedItem == null || String.IsNullOrEmpty(cmbSite.SelectedItem.ToString()))
            {
                errorCounter++;
                errSiteName.Visible = true;
            }
            else
            {
                errSiteName.Visible = false;
            }

            if (String.IsNullOrEmpty(cmbOption.Text))
            {
                errCellType.Visible = true;
                errorCounter++;
            }
            else
            {
                errCellType.Visible = false;
            }

            if (String.IsNullOrEmpty(txtCellSize.Text))
            {
                errorCounter++;
                errCellSize.Visible = true;
            }
            else if (!int.TryParse(txtCellSize.Text, out int cellSize))
            {
                errorCounter++;
                errCellSize.Text = "Please enter a valid integer value.";
                errCellSize.Visible = true;
            }
            else
            {
                errCellSize.Visible = false;
            }

            if (String.IsNullOrEmpty(txtLength.Text))
            {
                errorCounter++;
                errNoOfStrings.Visible = true;
            }
            else if (!int.TryParse(txtLength.Text, out int cellSize))
            {
                errorCounter++;
                errNoOfStrings.Text = "Please enter a valid integer value.";
                errNoOfStrings.Visible = true;
            }
            else
            {
                errNoOfStrings.Visible = false;
            }

            if (String.IsNullOrEmpty(txtWidth.Text))
            {
                errorCounter++;
                errCellsInString.Visible = true;
            }
            else if (!int.TryParse(txtWidth.Text, out int cellSize))
            {
                errorCounter++;
                errCellsInString.Text = "Please enter a valid integer value.";
                errCellsInString.Visible = true;
            }
            else
            {
                errCellsInString.Visible = false;
            }

            if (cmbChangeStatus.SelectedItem == null || String.IsNullOrEmpty(cmbChangeStatus.SelectedItem.ToString()))
            {
                errorCounter++;
                errStatus.Visible = true;
            }
            else
            {
                errStatus.Visible = false;
            }

            if (cmbCustomerName.SelectedItem == null || String.IsNullOrEmpty(cmbCustomerName.SelectedItem.ToString()))
            {
                errCustomer.Visible = true;
                errorCounter++;
            }
            else
            {
                errCustomer.Visible = false;
            }

            // Return false if there are no errors (errorCounter == 0)
            return errorCounter;
        }

        private void txtProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtWP.Focus();
            }
        }

        private void txtShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtShift.Focus();
            }
        }

        private void DtStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Update the MinDate of dtEndDate to match dtStartDate's Value
            dtEndDate.MinDate = dtStartDate.Value;

            // Optional: If the selected EndDate is less than StartDate, adjust it automatically
            if (dtEndDate.Value < dtStartDate.Value)
            {
                dtEndDate.Value = dtStartDate.Value;
            }
        }
    }
}
