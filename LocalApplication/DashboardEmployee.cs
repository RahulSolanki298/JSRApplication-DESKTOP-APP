using LocalApplication.DTO;
using LocalApplication.Helpers;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LocalApplication
{
    public partial class DashboardEmployee : Form
    {
        CompanyEmployee _employee = new CompanyEmployee();
        SeedData seedData = new SeedData();
        DBHelper DBHelper = new DBHelper();
        private string _outputFolder = "";
        private string _inputFolder = "";
        string OnsiteImagePath;
        private readonly HttpClient httpClient;
        string manufacturer = "";
        string testingDate = "";

        public DashboardEmployee(CompanyEmployee employee)
        {
            InitializeComponent();
            seedData.SeedDefectType(employee.SoftwareId);
            pictureBox3.Visible = false;
            _employee = employee;
            _loader.Visible = false;
            var soft=GetSoftwareData();
            GetCurrentProject();
            GetSettingData();
            if (lblProjectId.Text == "0")
            {
                MessageBox.Show("Please create project or select project from project list.");
            }
            GetLastInsData();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://127.0.0.1:8000/");
            seedData.SeedDefectType(_employee.SoftwareId);
            lblSoftware.Text = soft.CompanySectionName;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(lblProjectId.Text);
            SettingForm settingForm = new SettingForm(projectId, _employee);
            settingForm.Show();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectFM project = new ProjectFM(_employee);
            project.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(lblProjectId.Text);
            SettingForm settingForm = new SettingForm(projectId, _employee);
            settingForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetCurrentProject();
            GetSettingData();
            GetLastInsData();
            if (lblProjectId.Text == "0")
            {
                
                MessageBox.Show("Please create project or select project from project list.");
            }
        }

        private void GetProjectDataCounter(int projectId)
        {
            int total = 0;
            int pendingcounter = 0;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = @"SELECT ImageResult, COUNT(*) AS ResultCount
                           FROM ImageProcessData
                           WHERE PDId = @projectId
                           GROUP BY ImageResult";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@projectId", projectId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    string imageResult = row["ImageResult"].ToString();
                                    int count = Convert.ToInt32(row["ResultCount"]);

                                    switch (imageResult)
                                    {
                                        case SD.Ok:
                                            lblOk.Text = count.ToString();
                                            break;
                                        case SD.Defective:
                                            lblDefective.Text = count.ToString();
                                            break;
                                        case SD.WithinCriteria:
                                            lblWithinCriteria.Text = count.ToString();
                                            break;
                                        case SD.Pending:
                                            pendingcounter = count;
                                            lblPendingCounter.Text = count.ToString();
                                            break;
                                    }
                                }
                                total = Convert.ToInt32(lblOk.Text) + Convert.ToInt32(lblDefective.Text) + Convert.ToInt32(lblWithinCriteria.Text) + pendingcounter;
                                lblTotal.Text = total.ToString();
                            }
                            else
                            {
                                lblOk.Text = "0";
                                lblDefective.Text="0";
                                lblWithinCriteria.Text = "0";
                                lblPendingCounter.Text = "0";
                                lblTotal.Text = "0";
                            }

                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    MessageBox.Show($"Exception : {ex.Message}");
                }
            }
        }

        private void GetLastInsData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT ipd.*,cc.CustomerName FROM ImageProcessData ipd Inner Join ProjectDetails pd On ipd.PDId=pd.Id Inner Join CompanyCustomer cc On pd.CustomerId=cc.Id where ipd.PDId=@PDId order by ipd.Id desc";
                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@PDId", Convert.ToInt32(lblProjectId.Text));


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                DataRow row = dt.Rows[0];

                                string outputPath = row["ImageOutputLocalPath"].ToString();
                                if (outputPath != null && outputPath != "")
                                {
                                    picLastImage.Image = Image.FromFile(row["ImageOutputLocalPath"].ToString());
                                    lblLastImage.Text = row["ImageName"].ToString();
                                }

                                
                                //IDChanged?.Invoke(this, Convert.ToInt32(lblProjectId.Text));
                            }
                        }
                    }
                    GetProjectDataCounter(Convert.ToInt32(lblProjectId.Text));
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g., log it or show an error message
                }
            }
        }

        private async Task GetStatasticChart()
        {
            pictureBox3.Visible = false;
            pictureBox3.Image = null;
            try
            {
                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StringContent(lblProjectId.Text), "id");
                formData.Add(new StringContent(ConfigurationName.GetConnectionString()), "connectionString");

                HttpResponseMessage response = await httpClient.PostAsync("get_statistic/", formData);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<Image_Data>(responseContent);
                    using (Image img = ByteArrayToImage(responseData.statsimage))
                    {
                        string folderPath = Path.Combine(Application.StartupPath, "statsimage");
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        string statsImagePath = Path.Combine(folderPath, "statsimage.jpg");

                        // Save image to file
                        img.Save(statsImagePath);

                        // Load image into PictureBox
                        using (Image pictureBoxImage = Image.FromFile(statsImagePath))
                        {
                            pictureBox3.Image = new Bitmap(pictureBoxImage);
                        }

                        pictureBox3.Visible = true;
                        txtImageURL.Text = statsImagePath;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve image from the API.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                ms.Position = 0; // Reset the position to the beginning of the stream
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private DataTable getProjectData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT ipd.*,pd.WP_Product FROM ImageProcessData ipd Inner Join ProjectDetails pd on ipd.PDId=pd.Id WHERE ipd.PDId = {Convert.ToInt32(lblProjectId.Text)} and ipd.ImageResult in ('OK','Defective','WithinCriteria','Pending')";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void inspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(lblProjectId.Text);
            if (projectId > 0)
            {
                InspectionProcess insProcess = new InspectionProcess(projectId, _employee, true);
                this.Close();
                insProcess.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select project id");
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRegister customerRegister = new CustomerRegister(_employee);
            customerRegister.ShowDialog();
        }

        private async void btnChart_Click(object sender, EventArgs e)
        {
            if (lblProjectId.Text == "0")
            {
                MessageBox.Show("Please create project or select project from project list.");
                return;
            }
            await GetStatasticChart();
        }

        private void btnDownloadChart_Click(object sender, EventArgs e)
        {
            if (lblProjectId.Text == "0")
            {
                MessageBox.Show("Please create project or select project from project list.");
                return;
            }

            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string fileName = $"JSR-{lblCustomerName.Text}_{lblSiteName.Text}_{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}.jpg"; // Add timestamp to filename to make it unique
            string filePath = Path.Combine(downloadsFolder, fileName);

            string imageUrl = txtImageURL.Text; // Replace with your image URL

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(imageUrl, filePath);
                    MessageBox.Show("Image downloaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error downloading image: {ex.Message}");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picBulkImgs_Click(object sender, EventArgs e)
        {
            pnlBulkProcess.BackColor = Color.Lime;
            pnlDownload.BackColor = Color.WhiteSmoke;
            pnlProject.BackColor = Color.WhiteSmoke;
            pnlProcessResult.BackColor = Color.WhiteSmoke;

            ChangeStatusForm changeStatusForm = new ChangeStatusForm(Convert.ToInt32(lblProjectId.Text), _employee);
            changeStatusForm.ShowDialog();
        }

        private void picReport_Click(object sender, EventArgs e)
        {
            pnlBulkProcess.BackColor = Color.WhiteSmoke;
            pnlDownload.BackColor = Color.WhiteSmoke;
            pnlProject.BackColor = Color.WhiteSmoke;
            pnlProcessResult.BackColor = Color.Lime;

            ImageProcessData projectList = new ImageProcessData(_employee, Convert.ToInt32(lblProjectId.Text));
            projectList.ShowDialog();
        }

        private void picProject_Click(object sender, EventArgs e)
        {
            pnlBulkProcess.BackColor = Color.WhiteSmoke;
            pnlDownload.BackColor = Color.WhiteSmoke;
            pnlProject.BackColor = Color.Lime;
            pnlProcessResult.BackColor = Color.WhiteSmoke;

            ProjectList projectList = new ProjectList(_employee);
            projectList.ShowDialog();
        }

        private void criteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriteriaFM criteriaFM = new CriteriaFM(_employee);
            criteriaFM.ShowDialog();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList(_employee);
            projectList.ShowDialog();
        }


        #region private mathods

        private void GetCurrentProject()
        {

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select p.Id,p.Date,p.ManufacturerName,p.ProjectName,p.CriteriaBasketId,cust.CustomerName,c.CompanyName,s.Name as SiteName from ProjectDetails p " +
                        $"inner join CompanySoftware cs on p.SoftwareId=cs.Id" +
                        $" inner join Company c on cs.CompanyId=c.Id" +
                        $" inner join CompanyCustomer cust on p.CustomerId=cust.Id" +
                        $" inner join Site s on p.SiteId=s.Id where p.ProjectStatus='Pending'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        lblProjectId.Text = dt.Rows[0]["Id"].ToString();
                        lblProjectName.Text = dt.Rows[0]["ProjectName"].ToString();
                        lblSiteName.Text = dt.Rows[0]["SiteName"].ToString();
                        lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                        testingDate= dt.Rows[0]["Date"].ToString();
                        manufacturer = dt.Rows[0]["ManufacturerName"].ToString();
                        var basketId = Convert.ToInt32(dt.Rows[0]["CriteriaBasketId"].ToString());

                        GetSubCriteriaBasket(basketId);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void GetSubCriteriaBasket(int basketId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select top 1 cb.Id,cb.Name,acm.Id as SubCriteriaId from AcceptanceCriteriaMain acm inner join  CriteriaBasket cb on acm.CriteriaBasketId=cb.Id where acm.CriteriaBasketId={basketId} order by acm.Id desc";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        lblCriteriaName.Text = dt.Rows[0]["Name"].ToString();
                        var SubCriteriaId = Convert.ToInt32(dt.Rows[0]["SubCriteriaId"]);
                        GetSubCriteriaBasketData(SubCriteriaId);

                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void GetSubCriteriaBasketData(int subCriteriaId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select dt.Value as DefectType,ac.AcceptableMeasurement,ac.QuantityAcceptable from AcceptanceCriteria ac " +
                        $"inner join  AcceptanceCriteriaMain acm on ac.FactoryLineId=acm.Id inner join DefectType dt on ac.DefectTypeId=dt.Id " +
                        $"where ac.FactoryLineId={subCriteriaId}";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvData.DataSource = dt;
                    }
                }
                catch (Exception)
                {

                }
            }

        }

        private void GetSettingData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select * from Setting where ProjectId='{Convert.ToInt32(lblProjectId.Text)}'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        _inputFolder = dt.Rows[0]["InputPath"].ToString();
                        _outputFolder = dt.Rows[0]["OutputPath"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}");
                }
            }
        }

        private CompanySoftware GetSoftwareData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select * from CompanySoftware where Id=" + _employee.SoftwareId + "";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        var companySoftwareDT = new CompanySoftware()
                        {
                            Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString()),
                            SoftwareKey = dt.Rows[0]["SoftwareKey"].ToString(),
                            CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"].ToString()),
                            CompanySectionName = dt.Rows[0]["CompanySectionName"].ToString()
                        };
                        return companySoftwareDT;
                    }
                    return new CompanySoftware();
                }
                catch (Exception)
                {
                    return new CompanySoftware();
                }
            }
        }

        #endregion

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (CloseCancel() == true)
            {
                Application.Exit();
            };
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to exit?";
            const string caption = "Cancel";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(lblProjectId.Text);
            if (projectId > 0)
            {
                InspectionProcess insProcess = new InspectionProcess(projectId, _employee, true);
                this.Close();
                insProcess.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select project id");
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            pnlBulkProcess.BackColor = Color.WhiteSmoke;
            pnlDownload.BackColor = Color.Lime;
            pnlProject.BackColor = Color.WhiteSmoke;
            pnlProcessResult.BackColor = Color.WhiteSmoke;

            _loader.Visible = true;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (var excelPackage = new ExcelPackage())
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    WebClient webClient = new WebClient();
                    byte[] imageData = webClient.DownloadData("Resources/Logo.png");
                    Image logo = Image.FromStream(new MemoryStream(imageData));

                    float aspectRatio = (float)logo.Width / logo.Height;
                    int newWidth = 150;
                    int newHeight = (int)(newWidth / aspectRatio);
                    logo = new Bitmap(logo, newWidth, newHeight);

                    var logoFilePath = Path.Combine(Path.GetTempPath(), "Logo.png");
                    logo.Save(logoFilePath, System.Drawing.Imaging.ImageFormat.Png);
                    var logoExcel = worksheet.Drawings.AddPicture("Logo", new FileInfo(logoFilePath));
                    logoExcel.SetPosition(0, 0);
                    worksheet.Cells["A1:C3"].Merge = true;
                    worksheet.Cells["D1:E2"].Merge = true;
                    worksheet.Cells["D1:E2"].Value = "Site Name";

                    worksheet.Cells["F1:H2"].Merge = true;
                    worksheet.Cells["F1:H2"].Value = lblSiteName.Text;

                    worksheet.Cells["I1:I2"].Merge = true;
                    worksheet.Cells["I1:I2"].Value = "Testing Condition";

                    worksheet.Cells["J1:K2"].Merge = true;
                    worksheet.Cells["J1:K2"].Value = "On Structure EL Test";

                    worksheet.Cells["L1:L2"].Merge = true;
                    worksheet.Cells["L1:L2"].Value = "Testing Person";

                    worksheet.Cells["M1:N1"].Merge = true;
                    worksheet.Cells["M1:N1"].Value = "";

                    worksheet.Cells["D3:E3"].Merge = true;
                    worksheet.Cells["D3:E3"].Value = "Location";

                    worksheet.Cells["F3:H3"].Merge = true;
                    worksheet.Cells["F3:H3"].Value = "";
                    worksheet.Cells["I3"].Value = "Module Make";

                    worksheet.Cells["J3:K3"].Merge = true;
                    worksheet.Cells["J3:K3"].Value = manufacturer;

                    worksheet.Cells["l3"].Value = "Testing Date";

                    worksheet.Cells["m3:N3"].Merge = true;
                    worksheet.Cells["m3:N3"].Value = testingDate;

                    worksheet.Cells["a4:N4"].Merge = true;
                    worksheet.Cells["A4:N4"].Value = "EL Test Report";

                    worksheet.Cells["A5"].Value = "SR NO.";
                    worksheet.Cells["B5"].Value = "DATE.";

                    worksheet.Cells["C5"].Value = "Wattage."; 
                    worksheet.Cells["D5"].Value = "Module Serial No.";
                    worksheet.Cells["E5"].Value = "Module Location";
                    worksheet.Cells["F5"].Value = "Image Number";
                    worksheet.Cells["G5"].Value = "Result";
                    worksheet.Cells["H5"].Value = "Severity Score";
                    worksheet.Cells["I5"].Value = "Comment If Any";

                    var aquaColor = System.Drawing.ColorTranslator.FromHtml("#b7dee8");
                    using (var range = worksheet.Cells["D1:H3"])
                    {
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(aquaColor);
                        worksheet.Cells["D1:H3"].Style.Font.Size = 12;
                    }

                    var purpleColor = ColorTranslator.FromHtml("#ccc0da");
                    using (var range = worksheet.Cells["I1:K3"])
                    {
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(purpleColor);
                        worksheet.Cells["I1:K3"].Style.Font.Size = 12;
                    }

                    var oliveGreenColor = ColorTranslator.FromHtml("#d8e4bc");
                    using (var range = worksheet.Cells["L1:N3"])
                    {
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(oliveGreenColor);
                        worksheet.Cells["L1:N3"].Style.Font.Size = 12;
                    }

                    var orangeColor = ColorTranslator.FromHtml("#ffc000");
                    using (var range = worksheet.Cells["A4:N4"])
                    {
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells["A4:N4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells["A4:N4"].Style.Font.Size = 14;
                        range.Style.Fill.BackgroundColor.SetColor(orangeColor);
                    }

                    var cColor = ColorTranslator.FromHtml("#8db4e2");
                    using (var range = worksheet.Cells["A5:N5"])
                    {
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(cColor);
                        worksheet.Cells["A5:N5"].Style.Font.Size = 12;
                    }

                    // Set the data starting row
                    int startRow = 6;

                    // Set the data

                    var result = getProjectData();

                    int rowIndex = startRow;
                    int counter = 1;

                    foreach (DataRow row in result.Rows)
                    {
                        string imgModLocation = row["ModuleLocation"].ToString();

                        worksheet.Cells[rowIndex, 1].Value = counter;
                        worksheet.Cells[rowIndex, 2].Value =Convert.ToDateTime(row["Date"]).ToString("d");
                        
                        worksheet.Cells[rowIndex, 3].Value = row["WP_Product"];
                        worksheet.Cells[rowIndex, 4].Value = row["ModuleSerialNo"];
                        worksheet.Cells[rowIndex, 5].Value = row["ModuleLocation"];
                        worksheet.Cells[rowIndex, 6].Value = row["ImageName"];
                        worksheet.Cells[rowIndex, 7].Value = row["ImageResult"];
                        worksheet.Cells[rowIndex, 8].Value = row["SeverityScore"];
                        worksheet.Cells[rowIndex, 9].Value = "-";
                        // Add more columns as needed
                        rowIndex++;
                        counter++;
                    }

                    using (var range = worksheet.Cells["A1:N" + result.Rows.Count + 1])
                    {
                        range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }


                    worksheet.Cells.AutoFitColumns();

                    // Save the Excel file
                    string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                    string randomString = Path.GetRandomFileName().Replace(".", ""); // Get a random string
                    string fileName = $"JSR-{lblCustomerName.Text}_{lblSiteName.Text}_{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}.xlsx"; // Combine with current date and time
                    string filePath = Path.Combine(downloadsFolder, fileName);
                    FileInfo excelFile = new FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);

                    // Console.WriteLine($"Excel file saved to: {filePath}");
                    MessageBox.Show($"Excel file saved to: {filePath}");
                    _loader.Visible = false;
                }
            }
            catch (Exception ex)
            {
                _loader.Visible = false;
                MessageBox.Show($"Excel file saved to: {ex.Message}");
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePasswordFrm = new ChangePassword(_employee);
            changePasswordFrm.ShowDialog();
        }

        private void replicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportData importData = new ImportData(_employee);
            importData.ShowDialog();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
