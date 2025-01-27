using LocalApplication.DTO;
using LocalApplication.Helpers;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;

namespace LocalApplication
{
    public partial class OnSiteTesting : UserControl
    {
        private readonly HttpClient httpClient;
        private FileSystemWatcher watcher;
        private int projectId = 0;
        CompanyEmployee _employee = new CompanyEmployee();
        private bool isFullScreen = false;
        string OnsiteImagePath = "";
        DBHelper DBHelper = new DBHelper();

        public OnSiteTesting(int PId, CompanyEmployee employee)
        {
            InitializeComponent();
            DefaultForm();
            _employee = employee;
            projectId = PId;
            pnlChangeStatus.Visible = false;
            btnNxt.Visible = false;
            // Initialize the FileSystemWatcher
            watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\DELL\Pictures\DslrDashboard\";
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Changed += OnDirectoryChanged;
            watcher.EnableRaisingEvents = true;

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://127.0.0.1:8000/");
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            var result = SaveImageProcessData();
            if (result > 0)
            {
                //pnlStep1.Visible = false;
                //tblProcessButtons.Visible = false;
                //pnlShowImage.Visible = true;

                //pnlShowImage.Invalidate();
                //pnlShowImage.Update();

                txtImgName.Text = txtImageName.Text;
                lblProcessId.Text = result.ToString();

                bool IsMinimized = true;

                //InsProcess insProcess = new InsProcess();
                //insProcess.ShowDialog();

                Form parentForm = this.FindForm();
                parentForm.WindowState = FormWindowState.Minimized;
            }
            else
            {
                MessageBox.Show("Please enter proper details...!");
            }

        }

        private void pnlShowImage_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            parentForm.WindowState = FormWindowState.Maximized;
        }

        private async void OnDirectoryChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //InsProcess insProcess = new InsProcess(true, lblProcessId.Text, txtOutputFolder.Text);
                    //insProcess.ShowDialog();
                });
            }
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            btnProcess.Visible = false;
            txtImagePath.Visible = false;
            txtImgName.Visible = false;
            string imagePath = txtImagePath.Text;
            txtImageName.Text = Path.GetFileName(imagePath);

            byte[] imageBytes = ImageToByteArray(imagePath);
            string fileName = Path.GetFileName(imagePath);
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new ByteArrayContent(imageBytes), "imageBytes", fileName);
            formData.Add(new StringContent(_employee.SoftwareId.ToString()), "softwareId");
            formData.Add(new StringContent(projectId.ToString()), "projectId");
            formData.Add(new StringContent(txtImgName.Text), "imageName");
            formData.Add(new StringContent(txtLocation.Text), "moduleLocation");
            formData.Add(new StringContent(txtModuleSerialNo.Text), "moduleSerialNo");
            formData.Add(new StringContent(ConfigurationName.GetConnectionString()), "connectionString");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync("inference/", formData);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var responseData = JsonConvert.DeserializeObject<OnsiteResponseDTO>(responseContent);

                    Image image = ByteArrayToImage(responseData.Image_bytes);

                    string outputPath = txtOutputFolder.Text;
                    if (responseData.Status == "Ok")
                    {
                        outputPath = Path.Combine(outputPath, "Ok");
                    }
                    else if (responseData.Status == "Defective")
                    {
                        outputPath = Path.Combine(outputPath, "Defective");
                    }
                    else if (responseData.Status == "WithinCriteria")
                    {
                        outputPath = Path.Combine(outputPath, "WithinCriteria");
                    }

                    if (!Directory.Exists(outputPath))
                    {
                        Directory.CreateDirectory(outputPath);
                    }

                    OnsiteImagePath = Path.Combine(outputPath, txtImgName.Text);
                    image.Save(OnsiteImagePath);

                    tblProcessButtons.Visible = true;
                    btnProcess.Visible = false;
                    txtImgName.Visible = false;
                    pictureBox1.Image = image;

                    lblDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
                    lblImageName.Text = txtImgName.Text;
                    lblStatus.Text = responseData.Status;
                    lblCriteriaName.Text = "test-criteria";

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

        private int SaveImageProcessData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                int processId = 0;
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert customer
                    using (var cmdInsertCustomer = new SqlCommand("INSERT INTO ImageProcessData (ImageName, SoftwareId, PDId,ModuleSerialNo,ModuleLocation) VALUES (@ImageName, @SoftwareId, @PDId,@ModuleSerialNo,@ModuleLocation); SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        cmdInsertCustomer.Parameters.AddWithValue("@ImageName", txtImageName.Text);
                        cmdInsertCustomer.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertCustomer.Parameters.AddWithValue("@PDId", projectId);
                        cmdInsertCustomer.Parameters.AddWithValue("@ModuleSerialNo", txtModuleSerialNo.Text ?? DBNull.Value.ToString());
                        cmdInsertCustomer.Parameters.AddWithValue("@ModuleLocation", txtLocation.Text ?? DBNull.Value.ToString());
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

        private void OnSiteTesting_Load(object sender, EventArgs e)
        {
            DefaultForm();
        }

        public void DefaultForm()
        {
            // Step-1 
            pnlShowImage.Visible = false;
            pnlStep1.Visible = true;
            txtImageName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtModuleSerialNo.Text = string.Empty;
        }

        private void btnRecapture_Click(object sender, EventArgs e)
        {
            pnlStep1.Visible = false;
            tblProcessButtons.Visible = false;
            pnlShowImage.Visible = true;
            btnProcess.Visible = true;

            pnlShowImage.Invalidate();
            pnlShowImage.Update();

            txtImgName.Text = txtImageName.Text;
            Form parentForm = this.FindForm();
            parentForm.WindowState = FormWindowState.Minimized;
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            pnlChangeStatus.Visible = true;
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void ToggleFullScreen()
        {
            Form parentForm = this.FindForm();

            if (isFullScreen)
            {
                parentForm.FormBorderStyle = FormBorderStyle.Sizable;
                parentForm.WindowState = FormWindowState.Normal;
                isFullScreen = false;
            }
            else
            {
                parentForm.FormBorderStyle = FormBorderStyle.None;
                parentForm.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }

            // SetPictureBoxSizeMode();
        }

        private void SetPictureBoxSizeMode()
        {
            Form parentForm = this.FindForm();
            if (isFullScreen)
            {
                pictureBox1.Dock = DockStyle.Fill;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Dock = DockStyle.None;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentStatus = lblStatus.Text;
            string currentFolderPath = Path.Combine(txtOutputFolder.Text, currentStatus);
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert customer
                    using (var cmdUpdateImgProcess = new SqlCommand("Update ImageProcessData set ImageResult=@ImageResult where Id=@Id", connection, transaction))
                    {
                        cmdUpdateImgProcess.Parameters.AddWithValue("@ImageResult", cmbStatus.SelectedItem.ToString());
                        cmdUpdateImgProcess.Parameters.AddWithValue("@Id", Convert.ToInt32(lblProcessId.Text));
                        cmdUpdateImgProcess.ExecuteNonQuery();
                        lblStatus.Text = cmbStatus.SelectedItem.ToString();
                    }
                    MessageBox.Show("Status has been changed.");
                    transaction.Commit();

                    string newFolderPath = Path.Combine(txtOutputFolder.Text, cmbStatus.SelectedItem.ToString());
                    if (Directory.Exists(currentFolderPath))
                    {
                        // Check if the new folder exists, create it if it doesn't
                        if (!Directory.Exists(newFolderPath))
                        {
                            Directory.CreateDirectory(newFolderPath);
                        }

                        // Get the image file name
                        string imageName = Path.GetFileName(OnsiteImagePath);

                        // Move the image file to the new folder
                        string newImagePath = Path.Combine(newFolderPath, imageName);
                        File.Move(OnsiteImagePath, newImagePath);

                        // Update the status label or perform any other necessary actions
                        lblStatus.Text = cmbStatus.SelectedItem.ToString();
                    }
                    else
                    {
                        // Handle the case where the current folder doesn't exist
                        MessageBox.Show("Current status folder not found!");
                    }

                    pnlChangeStatus.Visible = false;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Exception : {ex.Message}");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlChangeStatus.Visible = false;
        }

        private void btnNxt_Click(object sender, EventArgs e)
        {
            pnlShowImage.Visible = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
