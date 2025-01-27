using LocalApplication.DTO;
using LocalApplication.Helpers;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace LocalApplication
{
    public partial class CertificateUpload : Form
    {
        DBHelper DBHelper = new DBHelper();
        public CertificateUpload()
        {
            InitializeComponent();
        }

        private async void btnFileUpload_Click(object sender, EventArgs e)
        {
            string[] jsonExtensions = { ".encrypted" };

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Encrypted files (*.encrypted)|*.encrypted";
                openFileDialog.Multiselect = false;

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    string selectedFilePath = openFileDialog.FileName;
                    txtCertificate.Text = selectedFilePath;

                    if (jsonExtensions.Contains(Path.GetExtension(selectedFilePath).ToLower()))
                    {
                        try
                        {
                            string encryptedContent = File.ReadAllText(selectedFilePath);
                            string jsonContent = DecryptString(encryptedContent, "your-encryption-key");

                            UploadDataVM data = JsonConvert.DeserializeObject<UploadDataVM>(jsonContent);

                            using (var connection = DBHelper.GetConnection())
                            {
                                var checkLive = await CheckProductKeyAsync(data.CompanySoftware.SoftwareKey, data.CompanySoftware.ProductKey);

                                if (checkLive != null && checkLive.IsActive != true)
                                {
                                    MessageBox.Show("Your product key already used..please try another software key...");
                                    return;
                                }

                                connection.Open();

                                // Insert User
                                string insertUserQuery = @"
                INSERT INTO AspNetUsers (Id,FirstName,MiddleName,LastName,UserName, NormalizedUserName, Email, NormalizedEmail, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
                VALUES (@Id,@FirstName,@MiddleName,@LastName,@UserName, @NormalizedUserName, @Email, @NormalizedEmail, @PasswordHash, @SecurityStamp, @ConcurrencyStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEnabled, @AccessFailedCount);
                SELECT SCOPE_IDENTITY();";

                                using (SqlCommand cmd = new SqlCommand(insertUserQuery, connection))
                                {
                                    string userId = Guid.NewGuid().ToString();
                                    cmd.Parameters.AddWithValue("@Id", userId);
                                    cmd.Parameters.AddWithValue("@FirstName", data.Users.FirstName);
                                    cmd.Parameters.AddWithValue("@MiddleName", data.Users.MiddleName);
                                    cmd.Parameters.AddWithValue("@LastName", data.Users.LastName);
                                    cmd.Parameters.AddWithValue("@UserName", data.Users.UserName);
                                    cmd.Parameters.AddWithValue("@NormalizedUserName", data.Users.NormalizedUserName);
                                    cmd.Parameters.AddWithValue("@Email", data.Users.Email);
                                    cmd.Parameters.AddWithValue("@NormalizedEmail", data.Users.NormalizedEmail);
                                    cmd.Parameters.AddWithValue("@PasswordHash", data.Users.PasswordHash);
                                    cmd.Parameters.AddWithValue("@SecurityStamp", data.Users.SecurityStamp);
                                    cmd.Parameters.AddWithValue("@ConcurrencyStamp", data.Users.ConcurrencyStamp);
                                    cmd.Parameters.AddWithValue("@PhoneNumber", data.Users.PhoneNumber);
                                    cmd.Parameters.AddWithValue("@PhoneNumberConfirmed", data.Users.PhoneNumberConfirmed);
                                    cmd.Parameters.AddWithValue("@TwoFactorEnabled", data.Users.TwoFactorEnabled);
                                    cmd.Parameters.AddWithValue("@LockoutEnabled", data.Users.LockoutEnabled);
                                    cmd.Parameters.AddWithValue("@AccessFailedCount", data.Users.AccessFailedCount);
                                    //cmd.Parameters.AddWithValue("@IsActive", data.Users.IsActive);

                                    cmd.ExecuteScalar();


                                    // Insert Company
                                    string insertCompanyQuery = @"
                    INSERT INTO Company (CompanyName, Description, OwnerName, UserId,NoOfSoftware,RegisterDate,ExpiryDate,IsNoOfImages,NoOfImages,IsSubscription,SubscriptionDays,SoftwareKey)
                    VALUES (@CompanyName, @Description, @OwnerName, @UserId,@NoOfSoftware,@RegisterDate,@ExpiryDate,@IsNoOfImages,@NoOfImages,@IsSubscription,@SubscriptionDays,@SoftwareKey);
                    SELECT SCOPE_IDENTITY();";

                                    using (SqlCommand companyCmd = new SqlCommand(insertCompanyQuery, connection))
                                    {
                                        companyCmd.Parameters.AddWithValue("@CompanyName", data.Company.CompanyName);
                                        companyCmd.Parameters.AddWithValue("@Description", data.Company.Description);
                                        companyCmd.Parameters.AddWithValue("@OwnerName", data.Company.OwnerName);
                                        companyCmd.Parameters.AddWithValue("@NoOfSoftware", data.Company.NoOfSoftware);
                                        companyCmd.Parameters.AddWithValue("@IsSubscription", data.Company.IsSubscription);
                                        companyCmd.Parameters.AddWithValue("@UserId", userId);
                                       
                                        companyCmd.Parameters.AddWithValue("@IsNoOfImages", data.Company.IsNoOfImages);
                                        companyCmd.Parameters.AddWithValue("@SoftwareKey", data.Company.SoftwareKey);
                                        if (data.Company.IsSubscription != false)
                                        {
                                            companyCmd.Parameters.AddWithValue("@NoOfImages", 0);
                                            companyCmd.Parameters.AddWithValue("@SubscriptionDays", data.Company.SubscriptionDays);
                                            companyCmd.Parameters.AddWithValue("@RegisterDate", data.Company.RegisterDate);
                                            companyCmd.Parameters.AddWithValue("@ExpiryDate", data.Company.RegisterDate.Value.AddDays(data.Company.SubscriptionDays));
                                        }

                                        if (data.Company.IsNoOfImages != false)
                                        {
                                            companyCmd.Parameters.AddWithValue("@SubscriptionDays", 0);
                                            companyCmd.Parameters.AddWithValue("@NoOfImages", data.Company.NoOfImages);
                                            companyCmd.Parameters.AddWithValue("@RegisterDate", DBNull.Value);
                                            companyCmd.Parameters.AddWithValue("@ExpiryDate", DBNull.Value);
                                        }

                                        int companyId = Convert.ToInt32(companyCmd.ExecuteScalar());

                                        // Insert SoftwareVersion
                                        foreach (var version in data.SoftwareVersion)
                                        {
                                            string insertSoftwareVersionQuery = @"
                            INSERT INTO SoftwareVersion (VersionName, IsActive)
                            VALUES (@VersionName, @IsActive);
                            SELECT SCOPE_IDENTITY();";

                                            using (SqlCommand versionCmd = new SqlCommand(insertSoftwareVersionQuery, connection))
                                            {
                                                versionCmd.Parameters.AddWithValue("@VersionName", version.VersionName);
                                                //  versionCmd.Parameters.AddWithValue("@PublishDate", DateTime.Now);
                                                versionCmd.Parameters.AddWithValue("@IsActive", version.IsActive);

                                                int versionId = Convert.ToInt32(versionCmd.ExecuteScalar());

                                                // Insert CompanySoftware
                                                string insertCompanySoftwareQuery = @"
                                INSERT INTO CompanySoftware (CompanyId, SoftwareVersionId, CompanySectionName, SoftwareKey,ProductKey, IsActive)
                                VALUES (@CompanyId, @SoftwareVersionId, @CompanySectionName, @SoftwareKey,@ProductKey, @IsActive);
                                SELECT SCOPE_IDENTITY();";

                                                using (SqlCommand companySoftwareCmd = new SqlCommand(insertCompanySoftwareQuery, connection))
                                                {
                                                    companySoftwareCmd.Parameters.AddWithValue("@CompanyId", companyId);
                                                    companySoftwareCmd.Parameters.AddWithValue("@SoftwareVersionId", versionId);
                                                    companySoftwareCmd.Parameters.AddWithValue("@CompanySectionName", data.CompanySoftware.CompanySectionName);
                                                    companySoftwareCmd.Parameters.AddWithValue("@SoftwareKey", data.CompanySoftware.SoftwareKey);
                                                    companySoftwareCmd.Parameters.AddWithValue("@IsActive", data.CompanySoftware.IsActive);
                                                    companySoftwareCmd.Parameters.AddWithValue("@ProductKey", data.CompanySoftware.ProductKey);

                                                    int companySoftwareId = Convert.ToInt32(companySoftwareCmd.ExecuteScalar());

                                                    // Insert CompanyAdmin
                                                    foreach (var admin in data.CompanyAdmin)
                                                    {
                                                        string insertCompanyAdminQuery = @"
                                        INSERT INTO CompanyAdmin (UserId, SoftwareId, Username, Password, IsActive, CompanyId, AdminCode)
                                        VALUES (@UserId, @SoftwareId, @Username, @Password, @IsActive, @CompanyId, @AdminCode);";

                                                        using (SqlCommand adminCmd = new SqlCommand(insertCompanyAdminQuery, connection))
                                                        {
                                                            adminCmd.Parameters.AddWithValue("@UserId", userId);
                                                            adminCmd.Parameters.AddWithValue("@SoftwareId", companySoftwareId);
                                                            adminCmd.Parameters.AddWithValue("@Username", admin.Username);
                                                            adminCmd.Parameters.AddWithValue("@Password", admin.Password);
                                                            adminCmd.Parameters.AddWithValue("@IsActive", admin.IsActive);
                                                            adminCmd.Parameters.AddWithValue("@CompanyId", companyId);
                                                            adminCmd.Parameters.AddWithValue("@AdminCode", admin.AdminCode);

                                                            adminCmd.ExecuteNonQuery();
                                                        }
                                                    }

                                                    // Insert DefectType
                                                    foreach (var defectType in data.DefectType)
                                                    {
                                                        string insertDefectTypeQuery = @"INSERT INTO DefectType (SoftwareId, CompanyId, Value)
                                                                                            VALUES (@SoftwareId, @CompanyId, @Value);";

                                                        using (SqlCommand defectCmd = new SqlCommand(insertDefectTypeQuery, connection))
                                                        {
                                                            defectCmd.Parameters.AddWithValue("@SoftwareId", companySoftwareId);
                                                            defectCmd.Parameters.AddWithValue("@CompanyId", companyId);
                                                            defectCmd.Parameters.AddWithValue("@Value", defectType.Value);

                                                            defectCmd.ExecuteNonQuery();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    connection.Close();
                                }
                            }

                            var updateResult = await UpdateStatusForCompanySoftware(data.CompanySoftware.SoftwareKey, data.CompanySoftware.ProductKey);
                            if (updateResult == true)
                            {
                                MessageBox.Show("Certificate Imported Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Certificate Imported Failed..", "Fail", MessageBoxButtons.CancelTryContinue, MessageBoxIcon.Error);

                            }

                            lblFileUpload.Visible = false;
                            btnFileUpload.Visible = false;
                            txtCertificate.Visible = false;
                            btnLogin.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while reading the JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected file is not a valid JSON file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show(); 
            this.Close(); 
        }

        private void lblBulkClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string DecryptString(string encryptedText, string key)
        {
            var fullCipher = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // Ensure key is 32 bytes
                byte[] iv = new byte[aes.BlockSize / 8];
                Array.Copy(fullCipher, 0, iv, 0, iv.Length);

                using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
                using (var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        private async Task<bool> UpdateStatusForCompanySoftware(string softwareKey, string productKey)
        {
            // Construct URL safely
            string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/UpdateStatusForCompanySoftwareAsync/{Uri.EscapeDataString(softwareKey)}/{Uri.EscapeDataString(productKey)}";

            try
            {
                // Reuse HttpClient by injecting via dependency injection in the constructor (or create a static instance)
                using (var client = new HttpClient())
                {
                    // Send the request and get the response
                    HttpResponseMessage response = await client.GetAsync(baseUrl);

                    // Ensure the response was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the response to a boolean value
                        var responseData = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<bool>(responseData);
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
            }
            catch (Exception ex)
            {
            }

            return false; // Return false if anything goes wrong
        }

        private async Task<CompanySoftwareVM> CheckProductKeyAsync(string softwareKey, string productKey)
        {
            // Construct URL safely
            string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/GetCompanySoftwareAsync/{Uri.EscapeDataString(softwareKey)}/{Uri.EscapeDataString(productKey)}";

            try
            {
                // Reuse HttpClient by injecting via dependency injection in the constructor (or create a static instance)
                using (var client = new HttpClient())
                {
                    // Send the request and get the response
                    HttpResponseMessage response = await client.GetAsync(baseUrl);

                    // Ensure the response was successful
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CompanySoftwareVM>(responseData);
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
            }
            catch (Exception ex)
            {
            }

            return new CompanySoftwareVM(); // Return false if anything goes wrong
        }

    }
}
