using LocalApplication.DTO;
using LocalApplication.Helpers;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace LocalApplication
{
    public partial class ChangeStatusForm : Form
    {
        private string _inputFolder = "";
        DBHelper DBHelper = new DBHelper();
        private string _outputFolder = "";
        int projectId = 0;
        string OnsiteImagePath;
        CompanyEmployee _employee = new CompanyEmployee();
        private readonly HttpClient httpClient;
        private CancellationTokenSource _cancellationTokenSource;
        private bool IsCancel = false;

        public ChangeStatusForm(int pid, CompanyEmployee employee)
        {
            projectId = pid;
            _employee = employee;
            InitializeComponent();
            GetSettingData();
            GetBulkInsertData();
            _loader.Visible = false;
            btnCancel.Enabled = false;

            if (!chkIsExcel.Checked)
            {
                lblExcelUpload.Visible = false;
                txtExcelUpload.Visible = false;
                btnExcelUpload.Visible = false;
            }

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://127.0.0.1:8000/");
        }

        private async void btnSaveBulkImage_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtInputFolder.Text))
            {
                MessageBox.Show("Please enter your input folder.");
                return;
            }

            btnCancel.Enabled = true;
            if (chkIsExcel.Checked)
            {
                await SaveImageProcessWithExcel();
            }
            else
            {
                await SaveImageProcessWithoutExcel();
            }
            btnCancel.Enabled = false;
        }

        private string UploadFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(Application.StartupPath, "BulkExcel", fileName);

            if (!Directory.Exists(Path.Combine(Application.StartupPath, "BulkExcel")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "BulkExcel"));
            }

            File.Copy(filePath, destinationPath, true);

            return destinationPath;
        }

        private void GetSettingData()
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

        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtExcelUpload.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnUploadInputFolder_Click(object sender, EventArgs e)
        {
            string[] imageExtensions = { ".jpg",".JPG",".jpeg",".png",".PNG",".JPEG" };

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    txtInputFolder.Text = folderDialog.SelectedPath;

                    int imageCount = Directory.GetFiles(txtInputFolder.Text)
                                               .Count(file => imageExtensions.Contains(Path.GetExtension(file).ToLower()));

                    lblNoOfImages.Text = imageCount.ToString();
                }
            }
        }

        private int SaveImageProcessData(ImageProcessDataDTO imageProcess)
        {
            //SaveBulkImage();
            using (var connection = DBHelper.GetConnection())
            {
                int processId = 0;
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    using (var cmdInsertCustomer = new SqlCommand("INSERT INTO ImageProcessData (Date,ImageName, SoftwareId, PDId,ModuleSerialNo,ModuleLocation,AddBy,BulkId,IsSuccess,ImageResult,EmployeeId) VALUES (@Date,@ImageName, @SoftwareId, @PDId,@ModuleSerialNo,@ModuleLocation,@AddBy,@BulkId,@IsSuccess,@ImageResult,@EmployeeId); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertCustomer.Parameters.AddWithValue("@Date", imageProcess.Date);
                        cmdInsertCustomer.Parameters.AddWithValue("@ImageName", imageProcess.ImageNumber);
                        cmdInsertCustomer.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertCustomer.Parameters.AddWithValue("@PDId", projectId);
                        cmdInsertCustomer.Parameters.AddWithValue("@ModuleSerialNo", imageProcess.ModuleSerialNo ?? DBNull.Value.ToString());
                        cmdInsertCustomer.Parameters.AddWithValue("@ModuleLocation", imageProcess.ModuleLocation ?? DBNull.Value.ToString());
                        cmdInsertCustomer.Parameters.AddWithValue("@AddBy", "Bulk");
                        cmdInsertCustomer.Parameters.AddWithValue("@BulkId", imageProcess.BulkId);
                        cmdInsertCustomer.Parameters.AddWithValue("@IsSuccess", 1);
                        cmdInsertCustomer.Parameters.AddWithValue("@ImageResult", SD.Pending);
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

        private async Task ImageProcessDT(ImageProcessDataDTO imageProcess, string imagePath)
        {
            try
            {
                byte[] imageBytes = ImageToByteArray(imagePath);
                string fileName = Path.GetFileName(imagePath);

                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StringContent(imageProcess.Id.ToString()), "id");
                formData.Add(new ByteArrayContent(imageBytes), "imageBytes", fileName);
                formData.Add(new StringContent(_employee.SoftwareId.ToString()), "softwareId");
                formData.Add(new StringContent(projectId.ToString()), "projectId");
                formData.Add(new StringContent(fileName), "imageName");
                formData.Add(new StringContent(imageProcess.ModuleLocation != null ? imageProcess.ModuleLocation : null), "moduleLocation");
                formData.Add(new StringContent(imageProcess.ModuleSerialNo != null ? imageProcess.ModuleSerialNo : null), "moduleSerialNo");
                formData.Add(new StringContent(imageProcess.Date?.ToString("yyyy-MM-ddTHH:mm:ss") ?? DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")), "Date");
                formData.Add(new StringContent(ConfigurationName.GetConnectionString()), "connectionString");

                HttpResponseMessage response = await httpClient.PostAsync("inference/", formData);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<OnsiteResponseDTO>(responseContent);

                    Image image = ByteArrayToImage(responseData.Image_bytes);

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
                            statusFolder = SD.Pending;
                            break;
                    }

                    string outputPath = Path.Combine(_outputFolder, statusFolder);
                    if (!Directory.Exists(outputPath))
                    {
                        Directory.CreateDirectory(outputPath);
                    }

                    OnsiteImagePath = Path.Combine(outputPath, responseData.Output_Image);

                    using (Image img = ByteArrayToImage(responseData.Image_bytes))
                    {
                        img.Save(OnsiteImagePath);
                    }
                    saveImagePath(OnsiteImagePath, responseData.Output_Image, imageProcess.Id.ToString());
                }
                else
                {
                    MessageBox.Show($"Failed to call API. Status code: {response.StatusCode}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
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

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void saveImagePath(string outputpath, string imageName = "", string id = "")
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query;
                        if (!string.IsNullOrEmpty(imageName))
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
                            cmdInsertCustomer.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
                            //if (!string.IsNullOrEmpty(imageName))
                            //{
                            //    cmdInsertCustomer.Parameters.AddWithValue("@ImageName", imageName);
                            //}
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

        private void lblBulkClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to stop process?", "Confirm Action",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                btnCancel.Enabled = false;
                _loader.Visible = false;
                Task.Delay(20000);
                IsCancel = true;
                _loader.Visible = true;
            }
        }

        private void UpdateBulkImage(int id, string process)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                int counter = 0;
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query;

                        // Use the same transaction for all SqlCommand objects
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.Transaction = transaction;

                            var qry = $"select * from BulkImageData where Id='{id}'";
                            cmd.CommandText = qry;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                if (process != SD.Complated && process != SD.Pause)
                                {
                                    counter = Convert.ToInt32(dt.Rows[0]["NoOfProcess"].ToString()) + 1;
                                }
                                else
                                {
                                    counter = Convert.ToInt32(dt.Rows[0]["NoOfProcess"].ToString());
                                }
                            }
                        }

                        query = "Update BulkImageData set NoOfProcess=@NoOfProcess,ProcessResult=@ProcessResult,UpdatedDate=@UpdatedDate where Id=@Id";
                        using (var cmdUpdateCustomer = new SqlCommand(query, connection, transaction))
                        {
                            cmdUpdateCustomer.Parameters.AddWithValue("@NoOfProcess", counter);
                            cmdUpdateCustomer.Parameters.AddWithValue("@ProcessResult", process);
                            cmdUpdateCustomer.Parameters.AddWithValue("@UpdatedDate", DateTime.Now.Date);
                            cmdUpdateCustomer.Parameters.AddWithValue("@Id", id);
                            cmdUpdateCustomer.ExecuteNonQuery(); // Use ExecuteNonQuery instead of ExecuteScalar
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        // Handle or log the exception as needed
                    }
                }
            }
        }

        private int AddBulkImage(string excelPath)
        {
            int BulkId = 0;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO BulkImageData(BulkProcessCode,InputFolder,ExcelFilePath, NoOfImages, NoOfProcess, ProcessResult, CreatedDate,PDId,BulkImageDataName,SoftwareId) OUTPUT INSERTED.Id VALUES (@BulkProcessCode,@InputFolder,@ExcelFilePath, @NoOfImages, @NoOfProcess, @ProcessResult, @CreatedDate,@PDId,@BulkImageDataName,@SoftwareId)";
                        using (var cmdInsertCustomer = new SqlCommand(query, connection, transaction))
                        {
                            cmdInsertCustomer.Parameters.AddWithValue("@BulkProcessCode", GenerateBulkProcessCode());
                            cmdInsertCustomer.Parameters.AddWithValue("@InputFolder", txtInputFolder.Text);
                            cmdInsertCustomer.Parameters.AddWithValue("@ExcelFilePath", excelPath ?? (object)DBNull.Value);
                            cmdInsertCustomer.Parameters.AddWithValue("@NoOfImages", Convert.ToInt32(lblNoOfImages.Text));
                            cmdInsertCustomer.Parameters.AddWithValue("@NoOfProcess", 0);
                            cmdInsertCustomer.Parameters.AddWithValue("@CreatedDate", DateTime.Now.Date);
                            cmdInsertCustomer.Parameters.AddWithValue("@ProcessResult", SD.Process);
                            cmdInsertCustomer.Parameters.AddWithValue("@PDId", projectId);
                            cmdInsertCustomer.Parameters.AddWithValue("@BulkImageDataName", $"JSR_BULK_{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}{DateTime.Now.Millisecond}");
                            cmdInsertCustomer.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);


                            BulkId = (int)cmdInsertCustomer.ExecuteScalar();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Log or handle the exception as needed
                        throw;
                    }
                }
            }
            return BulkId;
        }

        private void GetBulkImage(int id)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select * from BulkImageData where Id={id}";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (!String.IsNullOrEmpty(dt.Rows[0]["ExcelFilePath"].ToString()))
                        {
                            chkIsExcel.Checked = true;
                            txtExcelUpload.Text = dt.Rows[0]["ExcelFilePath"].ToString();
                        }
                        else
                        {
                            chkIsExcel.Checked = false;
                            txtExcelUpload.Text = string.Empty;
                        }
                        lblId.Text = dt.Rows[0]["Id"].ToString();
                        txtInputFolder.Text = dt.Rows[0]["InputFolder"].ToString();
                        lblProcessCounter.Text = dt.Rows[0]["NoOfProcess"].ToString();
                        lblNoOfImages.Text = dt.Rows[0]["NoOfImages"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}");
                }
            }
        }

        private void GetBulkInsertData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select Id,BulkProcessCode,NoOfImages,NoOfProcess,ProcessResult from BulkImageData Where PDId=" + projectId + " Order By Id Desc";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception : {ex.Message}");
                }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                lblId.Text = row.Cells["Id"].Value.ToString();
                GetBulkImage(Convert.ToInt32(lblId.Text));
            }
        }

        private async Task<bool> ProcessExcelFile(string filePath, int bulkId)
        {
            int processRowNo = 2;
            if (int.TryParse(lblProcessCounter.Text, out int counter) && counter > 0)
            {
                processRowNo += counter;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    DataTable dt = CreateDataTableFromWorksheet(worksheet);

                    for (int rowNum = processRowNo; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        if (IsCancel)
                        {
                            return false;
                        }

                        ImageProcessDataDTO processData = CreateImageProcessDataFromRow(worksheet.Cells, rowNum);
                        processData.BulkId = bulkId;
                        string imagePath = Path.Combine(_inputFolder, processData.ImageNumber);

                        if (!File.Exists(imagePath))
                        {
                            await HandleMissingImage(processData, bulkId);
                            continue;
                        }

                        try
                        {
                            int processId = SaveImageProcessData(processData);
                            processData.Id = processId;

                            await ImageProcessDT(processData, imagePath);
                            UpdateBulkImage(bulkId, SD.Process);
                            GetBulkImage(bulkId);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle any cleanup if necessary
                // LogException(ex);
                return false;
            }
            return true;
        }

        private DataTable CreateDataTableFromWorksheet(ExcelWorksheet worksheet)
        {
            DataTable dt = new DataTable();
            ExcelRange headerRow = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
            foreach (var cell in headerRow)
            {
                dt.Columns.Add(cell.Text);
            }
            return dt;
        }

        private ImageProcessDataDTO CreateImageProcessDataFromRow(ExcelRange cells, int rowNum)
        {
            ImageProcessDataDTO processData = new ImageProcessDataDTO();
            ExcelRange wsRow = cells[rowNum, 1, rowNum, cells.End.Column];
            int propertyIndex = 1;
            foreach (var cell in wsRow)
            {
                switch (propertyIndex)
                {
                    case 2:
                        processData.Date = !string.IsNullOrEmpty(cell.Text) ? Convert.ToDateTime(cell.Text) : DateTime.Now;
                        break;
                    case 3:
                        processData.ModuleLocation = !string.IsNullOrEmpty(cell.Text) ? cell.Text : DBNull.Value.ToString();
                        break;
                    case 4:
                        processData.ModuleSerialNo = !string.IsNullOrEmpty(cell.Text) ? cell.Text : DBNull.Value.ToString();
                        break;
                    case 5:
                        processData.ImageNumber = cell.Text;
                        break;
                }
                propertyIndex++;
            }
            return processData;
        }

        private async Task HandleMissingImage(ImageProcessDataDTO processData, int bulkId)
        {
            SaveImageProcessData(processData);
            UpdateBulkImage(bulkId, SD.Process);
            GetBulkImage(bulkId);
        }

        private string GenerateBulkProcessCode()
        {
            var today = DateTime.Now;

            var datePart = today.ToString("yyyyMMddHHmm");

            var uniquePart = Guid.NewGuid().ToString("N").Substring(0, 5); // Using first 6 characters of a GUID

            var code = $"{uniquePart}{datePart}";

            return code;
        }

        private async Task SaveImageProcessWithExcel()
        {
            _loader.Visible = true;
            btnSaveBulkImage.Enabled = false;
            try
            {
                string filePath = txtExcelUpload.Text;
                _inputFolder = txtInputFolder.Text;
                int bulkId = Convert.ToInt32(lblId.Text);
                if (bulkId == 0)
                {
                    string destinationPath = UploadFile(filePath);
                    bulkId = AddBulkImage(destinationPath);
                }

                var result = await ProcessExcelFile(filePath, bulkId);

                this.Hide();
                if (result == true)
                    UpdateBulkImage(bulkId, SD.Complated);
                else
                    UpdateBulkImage(bulkId, SD.Pause);

                GetBulkInsertData();
                IsCancel = false;
                dgvData.Visible = true;
                MessageBox.Show("Import successful!");
                btnCancel.Enabled = false;
                btnSaveBulkImage.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                btnSaveBulkImage.Enabled = true;
                pnlBulkInsert.Visible = false;
                _loader.Visible = false;
            }
        }

        private async Task SaveImageProcessWithoutExcel()
        {
            _loader.Visible = true;
            btnSaveBulkImage.Enabled = false;

            try
            {
                int processRowNo = 0;
                if (int.TryParse(lblProcessCounter.Text, out int counter) && counter > 0)
                {
                    processRowNo += counter;
                }
                _inputFolder = txtInputFolder.Text;
                int bulkId = GetOrCreateBulkId();

                string[] imageFiles = GetImageFiles();

                for (int i = processRowNo; i < imageFiles.Length; i++)
                {
                    if (IsCancel)
                    {
                        UpdateBulkImage(bulkId, SD.Pause);
                        FinalizeProcess();
                        return;
                    }

                    await ProcessImageFile(imageFiles[i], bulkId);
                }
                UpdateBulkImage(bulkId, SD.Complated);

                CompleteProcess();
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                FinalizeProcess();
            }
        }

        private int GetOrCreateBulkId()
        {
            int bulkId = Convert.ToInt32(lblId.Text);
            return bulkId == 0 ? AddBulkImage(null) : bulkId;
        }

        private string[] GetImageFiles()
        {
            return Directory.GetFiles(_inputFolder, "*.*", SearchOption.TopDirectoryOnly)
                            .Where(file => file.EndsWith(".JPG", StringComparison.OrdinalIgnoreCase) ||
                                            file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                            file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                            file.EndsWith(".PNG", StringComparison.OrdinalIgnoreCase) ||
                                            file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                           file.EndsWith(".JPEG", StringComparison.OrdinalIgnoreCase))
                            .ToArray();
        }

        private async Task ProcessImageFile(string file, int bulkId)
        {
            var imgName = Path.GetFileName(file);
            var processData = CreateImageProcessRow(imgName);
            processData.BulkId = bulkId;

            string imagePath = Path.Combine(_inputFolder, processData.ImageNumber);

            if (!File.Exists(imagePath))
            {
                await HandleMissingImage(processData, bulkId);
                return;
            }

            try
            {
                processData.Id = SaveImageProcessData(processData);
                await ImageProcessDT(processData, imagePath);
                UpdateBulkImage(bulkId, SD.Process);
                GetBulkImage(bulkId);
            }
            catch (Exception)
            {
                // Consider logging the exception
            }
        }

        private ImageProcessDataDTO CreateImageProcessRow(string imagePath)
        {
            return new ImageProcessDataDTO
            {
                ImageNumber = imagePath,
                ModuleSerialNo = imagePath,
                Date = DateTime.Now // or File.GetCreationTime(imagePath);
            };
        }

        private void CompleteProcess()
        {
            GetBulkInsertData();
            IsCancel = false;
            FinalizeProcess();
            MessageBox.Show("Import successful!");
        }

        private void FinalizeProcess()
        {
            _loader.Visible = false;
            btnSaveBulkImage.Enabled = true;
            dgvData.Visible = true; // Make sure this only shows after processing is done
            btnCancel.Enabled = false;
        }


        private void chkIsExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsExcel.Checked)
            {
                btnExcelUpload.Visible = true;
                lblExcelUpload.Visible = true;
                txtExcelUpload.Visible = true;
            }
            else
            {
                btnExcelUpload.Visible = false;
                lblExcelUpload.Visible = false;
                txtExcelUpload.Visible = false;
            }
        }
    }
}
