using LocalApplication.DTO;
using LocalApplication.Helpers;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace LocalApplication
{
    public partial class InspectionProcess : Form
    {
        readonly DBHelper DBHelper = new DBHelper();
        private readonly FileSystemWatcher watcher;
        private readonly HttpClient httpClient;
        private int softwareId = 0;
        private string moduleLocation = "";
        private string moduleSerialNo = "";
        private string imagePath = "";
        private string _outputFolder = "";
        private string _inputFolder = "";
        private string OnsiteImagePath = "";
        private string LastImagePath = "";
        private readonly CompanyEmployee _employee;
        private readonly bool isReverse = false;
        private double zoomFactor = 1.0;
        private const double ZoomIncrement = 0.1;
        private const int MinWidth = 100;
        private const int MinHeight = 100;

        public InspectionProcess(int projectId, CompanyEmployee companyEmployee, bool isLoad = false, int Id = 0)
        {
            InitializeComponent();
            lblProjectId.Text = Convert.ToString(projectId);
            softwareId = companyEmployee.SoftwareId;
            _employee = companyEmployee;
            pnlSetting.Visible = false;
            GetLastInsData(Id);
            GetSettingData();
            pictureBox1.MouseWheel += OnMouseWheel;
            if (Id > 0)
            {
                btnChangeStatus.Enabled = true;
                btnProcess.Enabled = false;
                btnNext.Enabled = false;
                btnRecapture.Enabled = true;
            }
            else
            {
                btnChangeStatus.Enabled = false;
            }
            pnlStatusChange.Visible = false;

            pictureBox2.Visible = false;
            //GetProjectDataCounter(projectId);
            if (isLoad)
            {
                btnNext.Text = "Start";
                btnNext.Enabled = true;
                btnProcess.Text = "Process";
                btnProcess.Enabled = false;
                btnRecapture.Enabled = false;
            }
            else
            {
                btnNext.Text = "Next";
            }

            if (!string.IsNullOrEmpty(_inputFolder) && Directory.Exists(_inputFolder))
            {
                watcher = new FileSystemWatcher
                {
                    Path = _inputFolder,
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                    Filter = "*.*"
                };
                watcher.Created += OnDirectoryChanged;
                watcher.Changed += OnDirectoryChanged;
                watcher.EnableRaisingEvents = true;
            }

            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8000/")
            };
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            //pnlOnSiteTesting.Visible = true;
            btnNext.BackColor = Color.Orange;
            btnRecapture.BackColor = Color.Lime;
            btnProcess.BackColor = Color.Lime;
            btnChangeStatus.BackColor = Color.Lime;

            btnRecapture.Enabled = true;
            if (!chkIsModuleLocation.Checked)
            {
                txtModuleLocation.Text = string.Empty;
                txtModuleSerialNo.Text = string.Empty;
                return;
            }

            if (moduleLocation == "" || moduleLocation == null)
            {
                pnlSetting.Visible = true;
                return;
            }

            string pattern = @"\d+$"; // Match one or more digits at the end of the string
            Match match = Regex.Match(moduleLocation, pattern);
            txtModuleSerialNo.Text = string.Empty;
            if (match.Success)
            {
                //int lastNumber = 0;

                int lastNumber = Convert.ToInt32(match.Value) + 1;

                if (!String.IsNullOrEmpty(txtModuleStart.Text)
                    && !String.IsNullOrEmpty(txtModuleEnd.Text))
                {

                    if (lastNumber >= Convert.ToInt32(txtModuleStart.Text)
                        && lastNumber <= Convert.ToInt32(txtModuleEnd.Text))
                    {
                        txtModuleLocation.Text = cmbINV_CB.SelectedItem + "-" + cmbCurrentValue.SelectedItem + "_STR-" + cmbCurrentSTRValue.SelectedItem + "_" + cmbPosition.SelectedItem + "_" + cmbEW.SelectedItem + "_" + lastNumber;

                        if (!String.IsNullOrEmpty(txtBlock.Text) && txtBlock.Text != "")
                        {
                            txtModuleLocation.Text = $"{txtBlock.Text}_" + cmbINV_CB.SelectedItem + "-" + cmbCurrentValue.SelectedItem + "_STR-" + cmbCurrentSTRValue.SelectedItem + "_" + cmbPosition.SelectedItem + "_" + cmbEW.SelectedItem + "_" + lastNumber;
                        }
                    }
                    else
                    {
                        pnlSetting.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Start With and End With cannot be empty.");
                }

            }
            else
            {
                MessageBox.Show("No number found at the end of the string.");
            }
        }

        private void picSetting_Click(object sender, EventArgs e)
        {
            //SettingForm settingForm = new SettingForm(Convert.ToInt32(lblProjectId.Text), _employee);
            //settingForm.Show();
            pnlSetting.Visible = true;

        }

        private void label14_Click(object sender, EventArgs e)
        {
            //pnlOnSiteTesting.Visible = false;
            txtModuleSerialNo.Text = string.Empty;
            txtModuleSerialNo.Text = string.Empty;
        }

        private void closePrefix_Click(object sender, EventArgs e)
        {
            // pnlPrifixPopup.Visible = false;
        }

        private bool isProcessing = false;
        private void OnDirectoryChanged(object sender, FileSystemEventArgs e)
        {
            if ((e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
                && !isProcessing && this.IsHandleCreated)
            {
                isProcessing = true;
                Task.Run(() =>
                {
                    // Wait for the file to be fully written
                    while (IsFileLocked(new FileInfo(e.FullPath)))
                    {
                        Thread.Sleep(100); // Check every 100ms if the file is accessible
                    }

                    // The file is now accessible
                    this.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            string filePath = e.FullPath;
                            if (IsValidImageFile(filePath))
                            {
                                using (Bitmap bitmap = new Bitmap(filePath))
                                {
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    pictureBox1.Image = new Bitmap(bitmap);
                                }

                                imagePath = filePath;
                                lblImageName.Text = Path.GetFileName(filePath);
                                btnNext.Enabled = false;
                                btnRecapture.Enabled = true;
                                btnChangeStatus.Enabled = false;
                                btnProcess.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Invalid image format.");
                                btnNext.Enabled = false;
                                btnRecapture.Enabled = true;
                                btnChangeStatus.Enabled = false;
                                btnProcess.Enabled = true;
                                btnProcess.Text = "Retry";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}");
                            btnNext.Enabled = false;
                            btnRecapture.Enabled = true;
                            btnChangeStatus.Enabled = false;
                            btnProcess.Enabled = true;
                            btnProcess.Text = "Retry";
                        }
                        finally
                        {
                            this.WindowState = FormWindowState.Maximized;
                            isProcessing = false;
                        }
                    });
                });
            }
        }

        private bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        private bool IsValidImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
                || extension.Equals(".JPG", StringComparison.OrdinalIgnoreCase)
                || extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)
                || extension.Equals(".JPEG", StringComparison.OrdinalIgnoreCase)
                || extension.Equals(".png", StringComparison.OrdinalIgnoreCase);
        }

        private void GetSettingData()
        {
            using (var connection = DBHelper.GetConnection())
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();

                try
                {
                    cmd.CommandText = "SELECT * FROM Setting WHERE ProjectId = @ProjectId";
                    cmd.Parameters.AddWithValue("@ProjectId", Convert.ToInt32(lblProjectId.Text));

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int invStart = reader["Inv_CB_Start"] != DBNull.Value ? Convert.ToInt32(reader["Inv_CB_Start"]) : 0;
                            int invEnd = reader["Inv_CB_End"] != DBNull.Value ? Convert.ToInt32(reader["Inv_CB_End"]) : 0;

                            for (int i = invStart; i <= invEnd; i++)
                            {
                                cmbCurrentValue.Items.Add(i);
                            }

                            int strStart = reader["Str_Start"] != DBNull.Value ? Convert.ToInt32(reader["Str_Start"]) : 0;
                            int strEnd = reader["Str_End"] != DBNull.Value ? Convert.ToInt32(reader["Str_End"]) : 0;

                            for (int i = strStart; i <= strEnd; i++)
                            {
                                cmbCurrentSTRValue.Items.Add(i);
                            }

                            _inputFolder = reader["InputPath"] != DBNull.Value ? reader["InputPath"].ToString() : string.Empty;
                            _outputFolder = reader["OutputPath"] != DBNull.Value ? reader["OutputPath"].ToString() : string.Empty;
                            cmbINV_CB.SelectedItem = reader["Module_INV_CB"] != DBNull.Value ? reader["Module_INV_CB"].ToString() : string.Empty;

                            cmbPosition.SelectedItem = reader["Position"] != DBNull.Value ? reader["Position"].ToString() : string.Empty;
                            cmbEW.SelectedItem = reader["Direction"] != DBNull.Value ? reader["Direction"].ToString() : string.Empty;
                            txtModuleStart.Text = reader["ModuleNo_Start"] != DBNull.Value ? reader["ModuleNo_Start"].ToString() : string.Empty;
                            txtModuleEnd.Text = reader["ModuleNo_End"] != DBNull.Value ? reader["ModuleNo_End"].ToString() : string.Empty;
                            lblID.Text = reader["Id"] != DBNull.Value ? reader["Id"].ToString() : string.Empty;

                            bool chkModuleLocation = reader["ModuleNo_End"] != DBNull.Value ? Convert.ToBoolean(reader["ModuleNo_End"]) : false;
                            chkIsModuleLocation.Checked = chkModuleLocation;

                            cmbCurrentValue.SelectedItem = reader["Current_Inv_CB_Value"] != DBNull.Value ? Convert.ToInt32(reader["Current_Inv_CB_Value"]) : (int?)null;
                            cmbCurrentSTRValue.SelectedItem = reader["Current_Str_Value"] != DBNull.Value ? Convert.ToInt32(reader["Current_Str_Value"]) : (int?)null;
                            txtBlock.Text = reader["Block"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Please set your input and output path...");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }
        }


        private void GetLastInsData(int Id = 0)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "";
                    if (Id > 0)
                    {
                        qry = "SELECT top 1 ipd.*,cc.CustomerName FROM ImageProcessData ipd Inner Join ProjectDetails pd On ipd.PDId=pd.Id Inner Join CompanyCustomer cc On pd.CustomerId=cc.Id where ipd.PDId=@PDId and ipd.Id=@Id and ipd.ImageResult IS NOT NULL";
                    }
                    else
                    {
                        qry = "SELECT top 1 ipd.*,cc.CustomerName FROM ImageProcessData ipd Inner Join ProjectDetails pd On ipd.PDId=pd.Id Inner Join CompanyCustomer cc On pd.CustomerId=cc.Id where ipd.PDId=@PDId and ipd.ImageResult IS NOT NULL order by ipd.Id desc";
                    }

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@PDId", Convert.ToInt32(lblProjectId.Text));
                        if (Id > 0)
                        {
                            cmd.Parameters.AddWithValue("@Id", Id);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                DataRow row = dt.Rows[0];
                                lblImageName.Text = row["ImageName"].ToString();
                                softwareId = Convert.ToInt32(row["SoftwareId"]);
                                moduleLocation = row["ModuleLocation"].ToString();
                                moduleSerialNo = row["ModuleSerialNo"].ToString();
                                lblProcessId.Text = row["Id"].ToString();
                                btnProcess.Text = "Process";
                                string outputPath = row["ImageOutputLocalPath"].ToString();
                                if (outputPath != null && outputPath != "")
                                {
                                    LastImagePath = outputPath;
                                    pictureBox1.Image = Image.FromFile(row["ImageOutputLocalPath"].ToString());
                                    pictureBox1.Width = pictureBox1.Image.Width;
                                    pictureBox1.Height = pictureBox1.Image.Height;
                                    zoomFactor = 1.0;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_employee.EmployeeType == SD.Operator)
            {
                DashboardEmployee employeeDashboard = new DashboardEmployee(_employee);
                this.Close();
                employeeDashboard.Show();
            }
            else if (_employee.EmployeeType == SD.Manager)
            {
                Dashboard employeeDashboard = new Dashboard(_employee);
                this.Close();
                employeeDashboard.Show();
            }
            else if (_employee.EmployeeType == SD.Admin)
            {
                DashboardAdmin employeeDashboard = new DashboardAdmin(_employee);
                this.Close();
                employeeDashboard.Show();
            }
        }

        private void btnCancelProcess_Click(object sender, EventArgs e)
        {
            //pnlOnSiteTesting.Visible = false;
            txtModuleSerialNo.Text = string.Empty;
            txtModuleLocation.Text = string.Empty;
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                btnNext.BackColor = Color.Lime;
                btnChangeStatus.BackColor = Color.Lime;
                btnRecapture.BackColor = Color.Lime;
                btnProcess.BackColor = Color.Orange;

                btnProcess.Enabled = false;
                pictureBox2.Visible = true;
                _loader.Visible = true;
                byte[] imageBytes = ImageToByteArray(imagePath);
                string fileName = Path.GetFileName(imagePath);

                MultipartFormDataContent formData = new MultipartFormDataContent
                {
                    { new StringContent(lblProcessId.Text), "id" },
                    { new ByteArrayContent(imageBytes), "imageBytes", fileName },
                    { new StringContent(softwareId.ToString()), "softwareId" },
                    { new StringContent(lblProjectId.Text), "projectId" },
                    { new StringContent(fileName), "imageName" },
                    { new StringContent(moduleLocation), "moduleLocation" },
                    { new StringContent(moduleSerialNo), "moduleSerialNo" },
                    { new StringContent(imagePath), "imageLocalPath" },
                    { new StringContent(DateTime.Now.ToString()), "Date" },
                    { new StringContent(ConfigurationName.GetConnectionString()), "connectionString" }
                };

                HttpResponseMessage response = await httpClient.PostAsync("inference/", formData);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<OnsiteResponseDTO>(responseContent);

                    string statusFolder;
                    switch (responseData.Status)
                    {
                        case "OK":
                            statusFolder = SD.Ok;
                            break;
                        case "Defective":
                            statusFolder = SD.Defective;
                            break;
                        case "WithinCriteria":
                            statusFolder = SD.WithinCriteria;
                            break;
                        default:
                            statusFolder = "Pending";
                            break;
                    }

                    string outputPath = Path.Combine(_outputFolder, statusFolder);
                    if (!Directory.Exists(outputPath))
                    {
                        Directory.CreateDirectory(outputPath);
                    }
                    string imageNameWithoutExtension = Path.GetFileNameWithoutExtension(responseData.Output_Image);
                    OnsiteImagePath = Path.Combine(outputPath, responseData.Output_Image);

                    using (Image img = ByteArrayToImage(responseData.Image_bytes))
                    {
                        img.Save(OnsiteImagePath);
                    }

                    saveImagePath(OnsiteImagePath, "", imageNameWithoutExtension);

                    pictureBox2.Visible = false;
                    _loader.Visible = false;
                    
                    lblStatus.Text = responseData.Status;
                    btnNext.Text = "Next";

                    btnRecapture.Enabled = false;
                    btnChangeStatus.Enabled = true;

                    btnNext.Enabled = true;

                    GetProcessImageData(Convert.ToInt32(lblProcessId.Text));
                    GetLastInsData();
                }
                else
                {
                    pictureBox2.Visible = false;
                    _loader.Visible = false;
                    btnNext.Enabled = true;
                    btnRecapture.Enabled = true;
                    MessageBox.Show($"Failed to call API. Status code: {response.StatusCode}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                pictureBox2.Visible = false;
                _loader.Visible = false;
                btnProcess.Text = "Retry";
                btnProcess.Enabled = true;
                btnChangeStatus.Enabled = false;
                btnRecapture.Enabled = true;
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ImageToByteArray(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void GetProcessImageData(int processId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT * FROM ImageProcessData WHERE Id = @processId";
                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@processId", processId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                DataRow row = dt.Rows[0];
                                //lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                                //lblImageName.Text = row["ImageName"].ToString();
                                //lblStatus.Text = row["ImageResult"].ToString();
                                //lblSeverityScore.Text = row["SeverityScore"].ToString();
                                lblProjectId.Text = row["PDId"].ToString();
                                softwareId = Convert.ToInt32(row["SoftwareId"]);
                                moduleLocation = row["ModuleLocation"].ToString();
                                moduleSerialNo = row["ModuleSerialNo"].ToString();
                                lblProcessId.Text = processId.ToString();

                                GetProjectDataCounter(Convert.ToInt32(lblProjectId.Text));
                                //IDChanged?.Invoke(this, Convert.ToInt32(lblProjectId.Text));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception, e.g., log it or show an error message
                }
            }
        }

        private void GetProjectDataCounter(int projectId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = @"SELECT ImageResult, COUNT(*) AS ResultCount
                                   FROM ImageProcessData
                                   WHERE PDId = @projectId 
                                   AND CAST(Date AS DATE) = CAST(GETDATE() AS DATE)
                                   GROUP BY ImageResult";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@projectId", projectId);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            da.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                string imageResult = row["ImageResult"].ToString();
                                int count = Convert.ToInt32(row["ResultCount"]);

                                switch (imageResult)
                                {
                                    case SD.Ok:
                                        lblOKCounter.Text = count.ToString();
                                        break;
                                    case SD.Defective:
                                        lblDefCounter.Text = count.ToString();
                                        break;
                                    case SD.WithinCriteria:
                                        lblWCCounter.Text = count.ToString();
                                        break;
                                }
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

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.Lime;
            btnRecapture.BackColor = Color.Lime;
            btnProcess.BackColor = Color.Lime;
            btnChangeStatus.BackColor = Color.Orange;

            pnlStatusChange.Visible = true;
            btnNext.Enabled = false;
            btnChangeStatus.Enabled = false;
            btnProcess.Enabled = false;
        }

        private void btnRecapture_Click(object sender, EventArgs e)
        {
            btnNext.BackColor = Color.Lime;
            btnRecapture.BackColor = Color.Orange;
            btnProcess.BackColor = Color.Lime;
            btnChangeStatus.BackColor = Color.Lime;

            btnNext.Enabled = false;
            btnChangeStatus.Enabled = false;
            btnProcess.Enabled = true;
            btnProcess.Text = "Process";
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtModuleLocation.Text) && String.IsNullOrEmpty(txtModuleSerialNo.Text))
            {
                MessageBox.Show("Please enter module location or serial no..");
                return;
            }   

            var result = SaveImageProcessData();
            if (result > 0)
            {
                lblProcessId.Text = result.ToString();

                btnProcess.Visible = true;
                btnNext.Enabled = false;
                btnChangeStatus.Enabled = false;
                moduleLocation = txtModuleLocation.Text;
                moduleSerialNo = txtModuleSerialNo.Text;

                //pnlOnSiteTesting.Visible = false;

                this.WindowState = FormWindowState.Minimized;

            }
            else
            {
                MessageBox.Show("Please enter proper details...!");
            }
        }

        private int SaveImageProcessData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                int processId = 0;
                connection.Open();

                SqlTransaction transaction = null;
                moduleLocation = txtModuleLocation.Text;
                moduleSerialNo = txtModuleSerialNo.Text;
                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert customer
                    using (var cmdInsertCustomer = new SqlCommand("INSERT INTO ImageProcessData (SoftwareId, PDId,ModuleSerialNo,ModuleLocation,CreatedBy,CreatedDate,AddBy,Date,EmployeeId) VALUES (@SoftwareId, @PDId,@ModuleSerialNo,@ModuleLocation,@CreatedBy,@CreatedDate,@AddBy,@Date,@EmployeeId); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertCustomer.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmdInsertCustomer.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmdInsertCustomer.Parameters.AddWithValue("@CreatedBy", _employee.UserId);
                        cmdInsertCustomer.Parameters.AddWithValue("@SoftwareId", softwareId);
                        cmdInsertCustomer.Parameters.AddWithValue("@PDId", Convert.ToInt32(lblProjectId.Text));
                        cmdInsertCustomer.Parameters.AddWithValue("@ModuleSerialNo", moduleSerialNo ?? DBNull.Value.ToString());
                        cmdInsertCustomer.Parameters.AddWithValue("@AddBy", "Live");
                        cmdInsertCustomer.Parameters.AddWithValue("@ModuleLocation", moduleLocation ?? DBNull.Value.ToString());
                        cmdInsertCustomer.Parameters.AddWithValue("@EmployeeId", _employee.Id);

                        processId = Convert.ToInt32(cmdInsertCustomer.ExecuteScalar());
                    }

                    transaction.Commit();
                    return processId;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return processId;
                }
            }
        }

        private async void UpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Select status..");
                    return;
                }

                if (comboBox1.SelectedItem.ToString() == lblStatus.Text)
                {
                    MessageBox.Show($"Status is already {lblStatus.Text}");
                    return;
                }

                _loader.Visible = true;
                btnProcess.Enabled = false;
                pictureBox2.Visible = true;
                pnlStatusChange.Visible = false;
                var oldFileName = LastImagePath;

                byte[] imageBytes = ImageToByteArray(oldFileName);
                string fileName = Path.GetFileName(oldFileName);

                using (MultipartFormDataContent formData = [])
                {
                    formData.Add(new StringContent(lblProcessId.Text), "id");
                    formData.Add(new ByteArrayContent(imageBytes), "imageBytes", fileName);
                    formData.Add(new StringContent(comboBox1.SelectedItem.ToString()), "statusname");
                    formData.Add(new StringContent(ConfigurationName.GetConnectionString()), "connectionString");

                    HttpResponseMessage response = await httpClient.PostAsync("changestatus/", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<OnsiteResponseDTO>(responseContent);

                        Image newImage = ByteArrayToImage(responseData.Image_bytes);
                        string statusFolder = comboBox1.SelectedItem.ToString();
                        string outputPath = Path.Combine(_outputFolder, statusFolder);

                        if (!Directory.Exists(outputPath))
                        {
                            Directory.CreateDirectory(outputPath);
                        }

                        string[] parts = lblImageName.Text.Split('.');
                        string newImageName = parts[0] + "_" + (string.IsNullOrEmpty(moduleLocation) ? moduleSerialNo : moduleLocation);
                        string imgPath = Path.Combine(outputPath, newImageName + ".jpg");

                        using (Image img = ByteArrayToImage(responseData.Image_bytes))
                        {
                            img.Save(imgPath);
                        }

                        saveImagePath(imgPath, comboBox1.SelectedItem.ToString(), lblImageName.Text);

                        pictureBox1.Image?.Dispose();  
                        pictureBox1.Image = null;
                        pictureBox1.Image = newImage;
                        LastImagePath = null;
                        LastImagePath = imgPath;
                        File.Delete(oldFileName);  

                        btnNext.Enabled = true;
                        btnChangeStatus.Enabled = false;
                        btnProcess.Text = "Process";
                        btnRecapture.Enabled = true;

                        GetProcessImageData(Convert.ToInt32(lblProcessId.Text));
                        GetLastInsData();

                        MessageBox.Show("Status has been changed successfully...");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to call API. Status code: {response.StatusCode}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnProcess.Text = "Retry";
                        btnProcess.Enabled = true;
                    }
                }

                _loader.Visible = false;
                pictureBox2.Visible = false;
            }
            catch (Exception ex)
            {
                _loader.Visible = false;
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelStatus_Click(object sender, EventArgs e)
        {
            pnlStatusChange.Visible = false;
        }

        private void saveImagePath(string outputpath, string status = "", string imageName = "")
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query;

                        if (!string.IsNullOrEmpty(imageName) && !string.IsNullOrEmpty(status))
                        {
                            query = "UPDATE ImageProcessData SET ImageOutputLocalPath=@ImageOutputLocalPath,ImageResult=@ImageResult WHERE Id=@Id";
                        }
                        else if (!string.IsNullOrEmpty(status) && string.IsNullOrEmpty(imageName))
                        {
                            query = "UPDATE ImageProcessData SET ImageOutputLocalPath=@ImageOutputLocalPath, ImageResult=@ImageResult WHERE Id=@Id";
                        }
                        else if (!string.IsNullOrEmpty(imageName) && string.IsNullOrEmpty(status))
                        {
                            query = "UPDATE ImageProcessData SET ImageOutputLocalPath=@ImageOutputLocalPath WHERE Id=@Id";
                        }
                        else
                        {
                            query = "UPDATE ImageProcessData SET ImageOutputLocalPath=@ImageOutputLocalPath WHERE Id=@Id";
                        }

                        using (var cmdInsertCustomer = new SqlCommand(query, connection, transaction))
                        {
                            cmdInsertCustomer.Parameters.AddWithValue("@ImageOutputLocalPath", outputpath);
                            cmdInsertCustomer.Parameters.AddWithValue("@Id", Convert.ToInt32(lblProcessId.Text));
                            if (!string.IsNullOrEmpty(status))
                            {
                                cmdInsertCustomer.Parameters.AddWithValue("@ImageResult", status);
                            }

                            cmdInsertCustomer.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        protected void OnMouseWheel(object sender, MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (pictureBox1.ClientRectangle.Contains(pictureBox1.PointToClient(Cursor.Position)))
            {
                if (e.Delta > 0)
                {
                    // Scroll up, zoom in
                    zoomFactor += ZoomIncrement;
                }
                else
                {
                    if (pictureBox1.Width > MinWidth && pictureBox1.Height > MinHeight)
                    {
                        zoomFactor -= ZoomIncrement;
                    }
                }

                ApplyZoom();
            }
        }

        private void ApplyZoom()
        {
            pictureBox1.Width = (int)(pictureBox1.Image.Width * zoomFactor);
            pictureBox1.Height = (int)(pictureBox1.Image.Height * zoomFactor);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int currentInvCbValue;
                if (!int.TryParse(cmbCurrentValue.SelectedItem?.ToString(), out currentInvCbValue))
                {
                    MessageBox.Show("Invalid Current INV CB Value selected.");
                    return;
                }

                int currentStrValue;
                if (!int.TryParse(cmbCurrentSTRValue.SelectedItem?.ToString(), out currentStrValue))
                {
                    MessageBox.Show("Invalid Current STR Value selected.");
                    return;
                }

                using (SqlConnection connection = DBHelper.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Setting SET Module_INV_CB=@Module_INV_CB, Current_Inv_CB_Value=@Current_Inv_CB_Value, Current_Str_Value=@Current_Str_Value, Direction=@Direction, Position=@Position, ModuleNo_Start=@ModuleNo_Start, ModuleNo_End=@ModuleNo_End, IsModuleLocation=@IsModuleLocation,Block=@Block WHERE Id = @Id";

                        command.Parameters.AddWithValue("@Id", Convert.ToInt32(lblID.Text));
                        command.Parameters.AddWithValue("@Module_INV_CB", cmbINV_CB.SelectedItem?.ToString() ?? string.Empty);
                        command.Parameters.AddWithValue("@Current_Inv_CB_Value", currentInvCbValue);
                        command.Parameters.AddWithValue("@Current_Str_Value", currentStrValue);
                        command.Parameters.AddWithValue("@Direction", cmbEW.SelectedItem?.ToString() ?? string.Empty);
                        command.Parameters.AddWithValue("@Position", cmbPosition.SelectedItem?.ToString() ?? string.Empty);
                        command.Parameters.AddWithValue("@ModuleNo_Start", txtModuleStart.Text);
                        command.Parameters.AddWithValue("@ModuleNo_End", txtModuleEnd.Text);
                        command.Parameters.AddWithValue("@IsModuleLocation", chkIsModuleLocation.Checked);
                        command.Parameters.AddWithValue("@Block", txtBlock.Text);

                        command.ExecuteNonQuery();
                    }
                }

                txtModuleLocation.Text = $"{cmbINV_CB.SelectedItem}-{cmbCurrentValue.SelectedItem}_STR-{cmbCurrentSTRValue.SelectedItem}_{cmbPosition.SelectedItem}_{cmbEW.SelectedItem}_{txtModuleStart.Text}";

                if (!String.IsNullOrEmpty(txtBlock.Text) && txtBlock.Text != "")
                    txtModuleLocation.Text = $"{txtBlock.Text}_{cmbINV_CB.SelectedItem}-{cmbCurrentValue.SelectedItem}_STR-{cmbCurrentSTRValue.SelectedItem}_{cmbPosition.SelectedItem}_{cmbEW.SelectedItem}_{txtModuleStart.Text}";

                MessageBox.Show("Data has been saved.");
                pnlSetting.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void btnCancelLocation_Click(object sender, EventArgs e)
        {
            pnlSetting.Hide();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            pnlSetting.Hide();
        }

        private void chkIsModuleLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsModuleLocation.Checked)
            {
                pnlModuleLocationFrm.Visible = true;
                cmbCurrentSTRValue.Enabled = true;
                cmbCurrentValue.Enabled = true;
                cmbEW.Enabled = true;
                cmbINV_CB.Enabled = true;
                cmbPosition.Enabled = true;
                txtBlock.Enabled = true;
            }
            else
            {
                pnlModuleLocationFrm.Visible = false;
                cmbCurrentSTRValue.Enabled = false;
                cmbCurrentValue.Enabled = false;
                cmbEW.Enabled = false;
                cmbINV_CB.Enabled = false;
                cmbPosition.Enabled = false;
                txtBlock.Enabled = false;


            }
        }
    }
}
