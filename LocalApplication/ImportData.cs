using LocalApplication.DTO;
using LocalApplication.Helpers;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;

namespace LocalApplication
{
    public partial class ImportData : Form
    {
        DBHelper DBHelper = new DBHelper();
        CompanyEmployee _employee = new CompanyEmployee();
        public ImportData(CompanyEmployee employee)
        {
            _employee = employee;
            InitializeComponent();
            GetUploadDataList();
        }

        private async void bntUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                _loader.Visible = true;

                var replicateHistoryDT = SaveReplicateHistory();
                var replicateHistory = await PostReplicateHistoryLive(replicateHistoryDT);

                for (int i = 1; i <= 11; i++)
                {
                    switch (i)
                    {
                        case 1:
                            await PostSiteDataLiveAsync(replicateHistory);
                            break;
                        case 2:
                            await PostCompanyEmployeeDataListAsync(replicateHistory);
                            break;
                        case 3:
                            await PostCustomerDataListAsync(replicateHistory);
                            break;
                        case 4:
                            await PostCriteriaBasketDataListAsync(replicateHistory);
                            break;
                        case 5:
                            await PostSubCriteriaBasketDataListAsync(replicateHistory);
                            break;
                        case 6:
                            await PostSubCriteriaBasketItemDataListAsync(replicateHistory);
                            break;
                        case 7:
                            await PostProjectDataLiveAsync(replicateHistory);
                            break;
                        case 8:
                            await PostImageProcessReqListAsync(replicateHistory);
                            break;
                        case 9:
                            await PostTextInImageDataListAsync(replicateHistory);
                            break;
                        case 10:
                            await PostBulkImageDataListAsync(replicateHistory);
                            break;
                        case 11:
                            await PostImageProcessDataLiveAsync(replicateHistory);
                            break;
                    }
                }
                UpdateReplicateHistoryForComplated(replicateHistory);

                _loader.Visible = false;
                this.Enabled = true;
                GetUploadDataList();
                MessageBox.Show("Image Process Data Import Successfully...");

            }
            catch (Exception ex)
            {
                _loader.Visible = false;
                this.Enabled = true;
                Console.WriteLine($"Error occurred during upload: {ex.Message}");
            }
        }

        #region Bulk Data Upload
        /// <summary>
        /// Uploaded all data to live server
        /// </summary>
        /// <returns></returns>

        private async Task<bool> PostProjectDataLive(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-Project-Details";

                using (HttpClient client = new HttpClient())
                {
                    var data = GetProjectDetailsDataList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            //UpdateProjectDetailsStatus(data);

                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProjectDetailsVM>>(responseContent);

                            await UpdateProjectDetailsStatusAsync(updatedData);


                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ProjectDetailsVM> GetProjectDetailsDataList(ReplicateHistoryVM replicateHistory)
        {
            List<ProjectDetailsVM> projectDetailsList = new List<ProjectDetailsVM>();

            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT pd.Id, pd.ProjectName, pd.ModuleMatrix, pd.ElementWith, cs.SoftwareKey,
                       ce.EmployeeName,ce.EmployeeCode, com.CompanyName, c.CustomerName, pd.ManufacturerName,
                       s.Name as SiteName, pd.StartDate, pd.EndDate, pd.ProjectStatus,
                       pd.WP_Product, pd.Date, pd.Shift, pd.ManufacturerName as ManufacturingBy,
                       cbsk.Name as CriteriaBasketName, scbsk.BasketName as SubCriteriaBasketName,
                       pd.CellSize,pd.ReplicateStatus,pd.ReplicateId
                FROM ProjectDetails pd
                INNER JOIN CompanyCustomer c ON pd.CustomerId = c.Id
                INNER JOIN CompanyEmployee ce ON pd.EmployeeId = ce.Id
                INNER JOIN Site s ON pd.SiteId = s.Id
                INNER JOIN CompanySoftware cs ON pd.SoftwareId = cs.Id
                INNER JOIN Company com ON cs.CompanyId = com.Id
                LEFT JOIN CriteriaBasket cbsk ON pd.CriteriaBasketId = cbsk.Id
                LEFT JOIN AcceptanceCriteriaMain scbsk ON pd.SubCriteriaBasketId = scbsk.Id
                WHERE pd.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        ProjectDetailsVM projectDetails = new ProjectDetailsVM
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            ProjectName = row["ProjectName"].ToString(),
                            ModuleMatrix = row["ModuleMatrix"].ToString(),
                            ElementWith = row["ElementWith"].ToString(),
                            Softwarekey = row["SoftwareKey"].ToString(),
                            EmployeeName = row["EmployeeName"].ToString(),
                            CompanyName = row["CompanyName"].ToString(),
                            CustomerName = row["CustomerName"].ToString(),
                            ManufacturerName = row["ManufacturerName"].ToString(),
                            SiteName = row["SiteName"].ToString(),
                            WP_Product = row["WP_Product"].ToString(),
                            Date = Convert.ToDateTime(row["Date"]).Date,
                            Shift = row["Shift"].ToString(),
                            ManufacturingBy = row["ManufacturingBy"].ToString(),
                            CriteriaBasketName = row["CriteriaBasketName"].ToString(),
                            SubCriteriaBasketName = row["SubCriteriaBasketName"].ToString(),
                            CellSize = Convert.ToInt32(row["CellSize"]),
                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                            EmployeeCode = row["EmployeeCode"].ToString(),
                            ProjectStatus = row["ProjectStatus"].ToString(),
                            StartDate = Convert.ToDateTime(row["StartDate"]).Date,
                            EndDate = Convert.ToDateTime(row["EndDate"]).Date,
                            ReplicateHistoryCode = replicateHistory.ReplicateCode,
                            ReplicateHistoryId = replicateHistory.Id,
                            ReplicateId = row["ReplicateId"].ToString(),
                        };
                        UpdateProjectDetailsStatusForReplicate(projectDetails);
                        projectDetailsList.Add(projectDetails);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }

            return projectDetailsList;
        }

        public async Task UpdateProjectDetailsStatusAsync(List<ProjectDetailsVM> projectDetailsList)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync(); // Open the connection asynchronously

                    foreach (var projectDetails in projectDetailsList)
                    {
                        string qry = "UPDATE ProjectDetails SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId WHERE Id = @Id";

                        using (var cmd = new SqlCommand(qry, connection))
                        {
                            cmd.Parameters.AddWithValue("@ReplicateStatus", projectDetails.ReplicateStatus);
                            cmd.Parameters.AddWithValue("@ReplicateId", projectDetails.ReplicateId);
                            cmd.Parameters.AddWithValue("@Id", projectDetails.Id);

                            await cmd.ExecuteNonQueryAsync(); // Execute the query asynchronously
                        }
                    }

                    await connection.CloseAsync(); // Close the connection asynchronously
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating project details status", ex);
            }
        }


        public void UpdateProjectDetailsStatusForReplicate(ProjectDetailsVM projectDetails)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = "UPDATE ProjectDetails SET ReplicateHistoryId = @ReplicateHistoryId WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@ReplicateHistoryId", projectDetails.ReplicateHistoryId);
                        cmd.Parameters.AddWithValue("@Id", projectDetails.Id);

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating project details status", ex);
            }
        }

        private async Task<bool> PostImageProcessDataLive(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-Image-Process";

                using (HttpClient client = new HttpClient())
                {
                    var data = GetImageProcessDataListLive(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageProcessDataVM>>(responseContent);

                            await UpdateImageProcessStatusAsync(updatedData);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<ImageProcessDataVM> GetImageProcessDataListLive(ReplicateHistoryVM replicateHistory)
        {
            List<ImageProcessDataVM> imageDataList = new List<ImageProcessDataVM>();

            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
SELECT DISTINCT
    imgDT.Id, bid.BulkProcessCode, imgDT.Date, pd.ProjectName, imgDT.ModuleSerialNo, imgDT.ModuleLocation,
    imgDT.CreatedDate, imgDT.UpdatedDate, imgDT.ImageName, imgDT.ImageResult, imgDT.SeverityScore, 
    imgDT.ModuleCountName, imgDT.DefectData, imgDT.Crack, imgDT.TreeCrack, imgDT.DeadCell, imgDT.DarkArea, 
    imgDT.OpenSoldering, imgDT.FingerInteruption, imgDT.BackSheetCut, ce.EmployeeName, ce.EmployeeCode, 
    cs.SoftwareKey, imgDT.IsSuccess, com.CompanyName, imgDT.ReplicateStatus, imgDT.ReplicateId
FROM ImageProcessData imgDT
INNER JOIN ProjectDetails pd ON imgDT.PDId = pd.Id
INNER JOIN CompanySoftware cs ON pd.SoftwareId = cs.Id
INNER JOIN Company com ON cs.CompanyId = com.Id
INNER JOIN CompanyEmployee ce ON imgDT.EmployeeId = ce.Id
INNER JOIN BulkImageData bid ON imgDT.BulkId = bid.Id
WHERE imgDT.ReplicateStatus IS NULL AND imgDT.ImageResult IS NOT NULL

UNION

SELECT DISTINCT
    imgDT.Id, NULL AS BulkProcessCode, imgDT.Date, pd.ProjectName, imgDT.ModuleSerialNo, imgDT.ModuleLocation,
    imgDT.CreatedDate, imgDT.UpdatedDate, imgDT.ImageName, imgDT.ImageResult, imgDT.SeverityScore, 
    imgDT.ModuleCountName, imgDT.DefectData, imgDT.Crack, imgDT.TreeCrack, imgDT.DeadCell, imgDT.DarkArea, 
    imgDT.OpenSoldering, imgDT.FingerInteruption, imgDT.BackSheetCut, ce.EmployeeName, ce.EmployeeCode, 
    cs.SoftwareKey, imgDT.IsSuccess, com.CompanyName, imgDT.ReplicateStatus, imgDT.ReplicateId
FROM ImageProcessData imgDT
INNER JOIN ProjectDetails pd ON imgDT.PDId = pd.Id
INNER JOIN CompanySoftware cs ON pd.SoftwareId = cs.Id
INNER JOIN Company com ON cs.CompanyId = com.Id
INNER JOIN CompanyEmployee ce ON imgDT.EmployeeId = ce.Id
LEFT JOIN BulkImageData bid ON imgDT.BulkId = bid.Id
WHERE bid.Id IS NULL AND imgDT.ReplicateStatus IS NULL AND imgDT.ImageResult IS NOT NULL;
";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        ImageProcessDataVM imageData = new ImageProcessDataVM
                        {
                            Id = row.Field<int>("Id"),
                            BulkProcessCode = row.Field<string>("BulkProcessCode"),
                            Date = row.Field<DateTime>("Date"),
                            ProjectDetailsName = row.Field<string>("ProjectName"),
                            ModuleSerialNo = row.Field<string>("ModuleSerialNo"),
                            ModuleLocation = row.Field<string>("ModuleLocation"),
                            ImageName = row.Field<string>("ImageName"),
                            ImageResult = row.Field<string>("ImageResult"),
                            SeverityScore = row.Field<string>("SeverityScore"),
                            ModuleCountName = row.Field<string>("ModuleCountName"),
                            DefectData = row.Field<string>("DefectData"),
                            Crack = row.Field<int?>("Crack") ?? 0,
                            TreeCrack = row.Field<int?>("TreeCrack") ?? 0,
                            DeadCell = row.Field<int?>("DeadCell") ?? 0,
                            DarkArea = row.Field<int?>("DarkArea") ?? 0,
                            OpenSoldering = row.Field<int?>("OpenSoldering") ?? 0,
                            FingerInteruption = row.Field<int?>("FingerInteruption") ?? 0,
                            BackSheetCut = row.Field<int?>("BackSheetCut") ?? 0,
                            EmployeeName = row.Field<string>("EmployeeName"),
                            EmployeeCode = row.Field<string>("EmployeeCode"),
                            SoftwareKey = row.Field<string>("SoftwareKey"),
                            CreatedDate = row.Field<DateTime?>("CreatedDate"),
                            UpdatedDate = row.Field<DateTime?>("UpdatedDate"),
                            IsSuccess = row.Field<bool?>("IsSuccess") ?? false,
                            CompanyName = row.Field<string>("CompanyName"),
                            ReplicateStatus = row.Field<string>("ReplicateStatus"),
                            ReplicateHistoryId = replicateHistory.Id,
                            ReplicateHistoryCode = replicateHistory.ReplicateCode
                        };

                        imageDataList.Add(imageData);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching image process data", ex);
            }

            return imageDataList;
        }
        public async Task UpdateImageProcessStatusAsync(List<ImageProcessDataVM> imgProcessList)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync(); // Open connection asynchronously

                    foreach (var imgProcess in imgProcessList)
                    {
                        string qry = "UPDATE ImageProcessData SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId WHERE Id = @Id";

                        using (var cmd = new SqlCommand(qry, connection))
                        {
                            cmd.Parameters.AddWithValue("@ReplicateStatus", imgProcess.ReplicateStatus);
                            cmd.Parameters.AddWithValue("@ReplicateId", imgProcess.ReplicateId);
                            cmd.Parameters.AddWithValue("@Id", imgProcess.Id);

                            await cmd.ExecuteNonQueryAsync(); // Execute the query asynchronously
                        }
                    }

                    await connection.CloseAsync(); // Close connection asynchronously
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating project details status", ex);
            }
        }

        private async Task PostSiteDataLiveAsync(ReplicateHistoryVM replicateHistory)
        {
            await Task.Run(() => PostSiteDataLive(replicateHistory));
        }
        private async Task PostCompanyEmployeeDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostCompanyEmployeeDataList(replicateHistory));
        }
        private async Task PostCustomerDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostCustomerDataList(replicateHistory));
        }
        private async Task PostCriteriaBasketDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostCriteriaBasketDataList(replicateHistory));
        }
        private async Task PostSubCriteriaBasketDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostSubCriteriaBasketDataList(replicateHistory));
        }
        private async Task PostSubCriteriaBasketItemDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostSubCriteriaBasketItemDataList(replicateHistory));
        }
        private async Task PostProjectDataLiveAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostProjectDataLive(replicateHistory));
        }
        private async Task PostImageProcessDataLiveAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostImageProcessDataLive(replicateHistory));
        }
        private async Task PostImageProcessReqListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostImageProcessReqList(replicateHistory));
        }
        private async Task PostTextInImageDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            // Your implementation here
            await Task.Run(() => PostTextInImageDataList(replicateHistory));
        }
        private async Task PostBulkImageDataListAsync(ReplicateHistoryVM replicateHistory)
        {
            await Task.Run(() => PostBulkImageDataList(replicateHistory));
        }

        public List<SiteVM> GetSiteList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                List<SiteVM> sites = new List<SiteVM>();
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT s.Id,cs.SoftwareKey, s.Name as SiteName,s.ReplicateStatus,s.ReplicateId
                FROM Site s
                INNER JOIN CompanySoftware cs ON s.SoftwareId = cs.Id
                WHERE s.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            SiteVM site = new SiteVM
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                Name = row["SiteName"].ToString(),
                                SoftwareKey = row["SoftwareKey"].ToString(),
                                ReplicateStatus = row["ReplicateStatus"].ToString(),
                                ReplicateId = row["ReplicateId"].ToString(),
                                ReplicateHistoryCode = replicateHistory.ReplicateCode,
                                ReplicateHistoryId = replicateHistory.Id
                            };
                            UpdateSiteForReplicate(site);
                            sites.Add(site);
                        }
                    }

                    connection.Close();
                    return sites;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }
        }

        private async Task<bool> PostSiteDataLive(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-Sites";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetSiteList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedSites = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SiteVM>>(responseContent);

                            UpdateSiteStatus(updatedSites);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void UpdateSiteStatus(List<SiteVM> updatedSites)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    foreach (var site in updatedSites)
                    {
                        string qry = @"
                    UPDATE Site
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(qry, connection);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", site.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@ReplicateId", site.ReplicateId);
                        cmd.Parameters.AddWithValue("@Id", site.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void UpdateSiteForReplicate(SiteVM updatedSites)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                    UPDATE Site
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", updatedSites.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", updatedSites.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<bool> PostCustomerDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-Customers";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetCompanyCustomerList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedCompanyCustomer = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CompanyCustomerVM>>(responseContent);

                            await UpdateCompanyCustomerAsync(updatedCompanyCustomer);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<CompanyCustomerVM> GetCompanyCustomerList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                List<CompanyCustomerVM> customer = new List<CompanyCustomerVM>();
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT cust.Id,cs.SoftwareKey,cust.CustomerName,c.CompanyName,cust.AboutCustomer,cust.IsActive,cust.ReplicateStatus,cust.ReplicateId
                FROM CompanyCustomer cust
                INNER JOIN CompanySoftware cs ON cust.SoftwareId = cs.Id                
                INNER JOIN Company c ON  cust.CompanyId=c.Id
                WHERE cust.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        CompanyCustomerVM companyCustomer = new CompanyCustomerVM
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            SoftwareKey = row["SoftwareKey"].ToString(),
                            CustomerName = row["CustomerName"].ToString(),
                            CompanyName = row["CompanyName"].ToString(),
                            AboutCustomer = row["AboutCustomer"].ToString(),
                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                            ReplicateId = row["ReplicateId"].ToString(),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            ReplicateHistoryCode = replicateHistory.ReplicateCode,
                            ReplicateHistoryId = replicateHistory.Id
                        };
                        UpdateCompanyCustomerForReplicate(companyCustomer);
                        customer.Add(companyCustomer);
                    }

                    connection.Close();
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }
        }

        private void UpdateCompanyCustomerForReplicate(CompanyCustomerVM companyCustomer)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                    UPDATE CompanyCustomer
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", companyCustomer.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", companyCustomer.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async Task UpdateCompanyCustomerAsync(List<CompanyCustomerVM> updatedCustomer)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync(); // Open the connection asynchronously

                    foreach (var customer in updatedCustomer)
                    {
                        string qry = @"
                UPDATE CompanyCustomer
                SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(qry, connection))
                        {
                            cmd.Parameters.AddWithValue("@ReplicateStatus", customer.ReplicateStatus);
                            cmd.Parameters.AddWithValue("@ReplicateId", customer.ReplicateId);
                            cmd.Parameters.AddWithValue("@Id", customer.Id);

                            await cmd.ExecuteNonQueryAsync(); // Execute the query asynchronously
                        }
                    }

                    await connection.CloseAsync(); // Close the connection asynchronously
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task<bool> PostCompanyEmployeeDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-CompanyEmployee";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetCompanyEmployeeList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedCompanyEmployee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CompanyEmployeeVM>>(responseContent);

                            await UpdateCompanyEmployeeAsync(updatedCompanyEmployee);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<CompanyEmployeeVM> GetCompanyEmployeeList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                List<CompanyEmployeeVM> employeeList = new List<CompanyEmployeeVM>();
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"SELECT emp.Id,
                    cs.SoftwareKey,
                    emp.EmployeeCode,
                    emp.EmployeeName,
                    per.FirstName,
                    per.MiddleName,
                    per.LastName,
                    emp.EmployeeType,
                    emp.Username,
                    emp.Password,
                    emp.IsActive,
                    emp.ReplicateStatus,
                    emp.ReplicateId,
                    memp.UserName as ManageBy,
                    cusr.UserName as CreatedBy,
                    updt.UserName as UpdatedBy,
                    emp.UpdatedDate,
                    emp.CreatedDate
            FROM CompanyEmployee emp
            INNER JOIN AspNetUsers per ON emp.UserId = per.Id
            INNER JOIN CompanySoftware cs ON emp.SoftwareId = cs.Id
            LEFT JOIN CompanyEmployee memp ON emp.ManageBy = memp.Id
            LEFT JOIN AspNetUsers cusr ON emp.CreatedById = cusr.Id                
            LEFT JOIN AspNetUsers updt ON emp.UpdatedById = updt.Id
            WHERE emp.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        CompanyEmployeeVM companyEmployee = new CompanyEmployeeVM
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            SoftwareKey = row["SoftwareKey"].ToString(),
                            EmployeeCode = row["EmployeeCode"].ToString(),
                            FirstName= row["FirstName"].ToString(),
                            LastName= row["LastName"].ToString(),
                            MiddleName= row["MiddleName"].ToString(),
                            EmployeeType = row["EmployeeType"].ToString(),
                            EmployeeName = row["EmployeeName"].ToString(),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            Username = row["Username"].ToString(),
                            Password = row["Password"].ToString(),
                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                            ReplicateId = row["ReplicateId"].ToString(),
                            CreatedById = row["CreatedBy"] != DBNull.Value ? row["CreatedBy"].ToString() : null,
                            CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : (DateTime?)null,
                            UpdatedById = row["UpdatedBy"] != DBNull.Value ? row["UpdatedBy"].ToString() : null,
                            UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : (DateTime?)null,
                            ManageBy = row["ManageBy"] != DBNull.Value ? row["ManageBy"].ToString() : null,
                            ReplicateHistoryId = replicateHistory.Id,
                            ReplicateHistoryCode = replicateHistory.ReplicateCode
                        };
                        UpdateEmployeeForReplicate(companyEmployee);
                        employeeList.Add(companyEmployee);
                    }

                    connection.Close();
                    return employeeList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }
        }

        private async Task UpdateCompanyEmployeeAsync(List<CompanyEmployeeVM> updatedEmployee)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync(); // Open the connection asynchronously

                    foreach (var employee in updatedEmployee)
                    {
                        string qry = @"
                UPDATE CompanyEmployee
                SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId, EmployeeCode = @EmployeeCode
                WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(qry, connection))
                        {
                            // Add parameters
                            cmd.Parameters.AddWithValue("@ReplicateStatus", employee.ReplicateStatus);
                            cmd.Parameters.AddWithValue("@ReplicateId", employee.ReplicateId);
                            cmd.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
                            cmd.Parameters.AddWithValue("@Id", employee.Id);

                            // Execute the query asynchronously
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    await connection.CloseAsync(); // Close the connection asynchronously
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateEmployeeForReplicate(CompanyEmployeeVM employee)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();


                    string qry = @"
                    UPDATE CompanyEmployee
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", employee.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", employee.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> PostCriteriaBasketDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-CriteriaBasket";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetCriteriaBasketList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedCriteriaBaskets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CriteriaBasketVM>>(responseContent);

                            await UpdateCriteriaBasketAsync(updatedCriteriaBaskets);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<CriteriaBasketVM> GetCriteriaBasketList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                List<CriteriaBasketVM> criteriaBaskets = new List<CriteriaBasketVM>();
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT cb.Id,cs.SoftwareKey,cb.Name,cb.ReplicateId,cb.ReplicateStatus
                FROM CriteriaBasket cb
                INNER JOIN CompanySoftware cs ON cb.SoftwareId = cs.Id   
                WHERE cb.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        CriteriaBasketVM basket = new CriteriaBasketVM
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            SoftwareKey = row["SoftwareKey"].ToString(),
                            Name = row["Name"].ToString(),
                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                            ReplicateId = row["ReplicateId"].ToString(),
                            ReplicateHistoryCode = replicateHistory.ReplicateCode,
                            ReplicateHistoryId = replicateHistory.Id
                        };
                        UpdateCriteriaBasketForReplicate(basket);
                        criteriaBaskets.Add(basket);
                    }

                    connection.Close();
                    return criteriaBaskets;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }
        }

        private async Task UpdateCriteriaBasketAsync(List<CriteriaBasketVM> updatedBasket)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    await connection.OpenAsync(); // Asynchronously open the connection

                    foreach (var basket in updatedBasket)
                    {
                        string qry = @"
                    UPDATE CriteriaBasket
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        using (var cmd = new SqlCommand(qry, connection))
                        {
                            cmd.Parameters.AddWithValue("@ReplicateStatus", basket.ReplicateStatus);
                            cmd.Parameters.AddWithValue("@ReplicateId", basket.ReplicateId);
                            cmd.Parameters.AddWithValue("@Id", basket.Id);

                            await cmd.ExecuteNonQueryAsync(); // Execute the query asynchronously
                        }
                    }

                    await connection.CloseAsync(); // Asynchronously close the connection
                }
            }
            catch (Exception ex)
            {
                // Handle the error (log it or display a message as per your needs)
            }
        }


        private void UpdateCriteriaBasketForReplicate(CriteriaBasketVM criteriaBasket)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();


                    string qry = @"
                    UPDATE CriteriaBasket
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", criteriaBasket.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", criteriaBasket.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> PostSubCriteriaBasketDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-SubCriteriaBasket";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetAccetanceCriteriaBasketList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedCriteriaBaskets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AcceptanceCriteriaMainVM>>(responseContent);

                            UpdateSubCriteriaBasket(updatedCriteriaBaskets);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<AcceptanceCriteriaMainVM> GetAccetanceCriteriaBasketList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                List<AcceptanceCriteriaMainVM> criteriaBasketsMain = new List<AcceptanceCriteriaMainVM>();
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT acm.Id,acm.BasketName,acm.AcceptanceOptions,cb.Name as CriteriaBasketName,acm.ReplicateId,acm.ReplicateStatus,cs.SoftwareKey
                FROM AcceptanceCriteriaMain acm
                INNER JOIN CriteriaBasket cb ON acm.CriteriaBasketId = cb.Id                
                INNER JOIN CompanySoftware cs ON acm.SoftwareId = cs.Id
                WHERE acm.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        AcceptanceCriteriaMainVM subBasket = new AcceptanceCriteriaMainVM
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            BasketName = row["BasketName"].ToString(),
                            AcceptanceOptions = row["AcceptanceOptions"].ToString(),
                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                            ReplicateId = row["ReplicateId"].ToString(),
                            CriteriaBasketName = row["CriteriaBasketName"].ToString(),
                            SoftwareKey = row["SoftwareKey"].ToString(),
                            ReplicateHistoryCode = replicateHistory.ReplicateCode,
                            ReplicateHistoryId = replicateHistory.Id
                        };
                        UpdateSubCriteriaBasketForReplicate(subBasket);
                        criteriaBasketsMain.Add(subBasket);
                    }
                    connection.Close();
                    return criteriaBasketsMain;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }
        }

        private void UpdateSubCriteriaBasket(List<AcceptanceCriteriaMainVM> updatedBasket)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    foreach (var basket in updatedBasket)
                    {
                        string qry = @"
                    UPDATE AcceptanceCriteriaMain
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(qry, connection);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", basket.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@ReplicateId", basket.ReplicateId);
                        cmd.Parameters.AddWithValue("@Id", basket.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSubCriteriaBasketForReplicate(AcceptanceCriteriaMainVM acceptanceCriteria)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();


                    string qry = @"
                    UPDATE AcceptanceCriteriaMain
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", acceptanceCriteria.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", acceptanceCriteria.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> PostSubCriteriaBasketItemDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-SubCriteriaBasket-Items";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetAccetanceCriteriaBasketItemsList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedCriteriaBaskets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AcceptanceCriteriaVM>>(responseContent);

                            UpdateSubCriteriaItemsBasket(updatedCriteriaBaskets);

                            //MessageBox.Show("Sub Criteria Basket Items Import successful: " + responseContent, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("Sub Criteria Basket Items Import failed. Server returned: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<AcceptanceCriteriaVM> GetAccetanceCriteriaBasketItemsList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                List<AcceptanceCriteriaVM> criteriaBasketsMain = new List<AcceptanceCriteriaVM>();
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT ac.Id,acm.BasketName as FactoryLineName,cs.SoftwareKey,dt.Value as DefectTypeName,ac.UnitOfMeasurement,ac.AcceptableMeasurement,ac.QuantityAcceptable,ac.ReplicateId,ac.ReplicateStatus
                FROM AcceptanceCriteria ac
                INNER JOIN AcceptanceCriteriaMain acm ON ac.FactoryLineId = acm.Id
                INNER JOIN DefectType dt ON ac.DefectTypeId = dt.Id                
                INNER JOIN CompanySoftware cs ON acm.SoftwareId = cs.Id
                WHERE ac.ReplicateStatus IS NULL";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        AcceptanceCriteriaVM subBasket = new AcceptanceCriteriaVM
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                            ReplicateId = row["ReplicateId"].ToString(),
                            DefectTypeName = row["DefectTypeName"].ToString(),
                            UnitOfMeasurement = row["UnitOfMeasurement"].ToString(),
                            FactoryLineName = row["FactoryLineName"].ToString(),
                            QuantityAcceptable = row["QuantityAcceptable"].ToString(),
                            AcceptableMeasurement = row["AcceptableMeasurement"].ToString(),
                            SoftwareKey = row["SoftwareKey"].ToString(),
                            ReplicateHistoryId = replicateHistory.Id,
                            ReplicateHistoryCode = replicateHistory.ReplicateCode
                        };
                        UpdateSubCriteriaItemsBasketForReplicate(subBasket);
                        criteriaBasketsMain.Add(subBasket);
                    }

                    connection.Close();
                    return criteriaBasketsMain;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }
        }

        private void UpdateSubCriteriaItemsBasket(List<AcceptanceCriteriaVM> updatedBasket)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    foreach (var basket in updatedBasket)
                    {
                        string qry = @"
                    UPDATE AcceptanceCriteria
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(qry, connection);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", basket.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@ReplicateId", basket.ReplicateId);
                        cmd.Parameters.AddWithValue("@Id", basket.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSubCriteriaItemsBasketForReplicate(AcceptanceCriteriaVM acceptanceCriteria)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                    UPDATE AcceptanceCriteria
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", acceptanceCriteria.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", acceptanceCriteria.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> PostTextInImageDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-TextInImage";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetTextInImageDataList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedCriteriaBaskets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TextInImageVM>>(responseContent);

                            UpdateTextInImage(updatedCriteriaBaskets);

                            //MessageBox.Show("Sub Criteria Basket Items Import successful: " + responseContent, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("Sub Criteria Basket Items Import failed. Server returned: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        private List<TextInImageVM> GetTextInImageDataList(ReplicateHistoryVM replicateHistory)
        {
            List<TextInImageVM> txtInImageList = new List<TextInImageVM>();
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
            SELECT txt.Id, txt.IsImageName, txt.WPOfProduct, txt.DateAndShift, txt.IsManufacturer, 
                   txt.ManufacturingPlantAndLine, txt.SiteName, txt.CustomerName, txt.CriteriaName, 
                   soft.SoftwareKey, p.ProjectName, txt.ReplicateId, txt.ReplicateStatus
            FROM TextInImage txt
            INNER JOIN ProjectDetails p ON txt.PDId = p.Id
            INNER JOIN CompanySoftware soft ON txt.SoftwareId = soft.Id
            WHERE txt.ReplicateStatus IS NULL";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    try
                                    {
                                        TextInImageVM subBasket = new TextInImageVM
                                        {
                                            Id = Convert.ToInt32(row["Id"]),
                                            IsImageName = Convert.ToBoolean(row["IsImageName"]),
                                            WPOfProduct = Convert.ToBoolean(row["WPOfProduct"]),
                                            DateAndShift = Convert.ToBoolean(row["DateAndShift"]),
                                            IsManufacturer = Convert.ToBoolean(row["IsManufacturer"]),
                                            ManufacturingPlantAndLine = Convert.ToBoolean(row["ManufacturingPlantAndLine"]),
                                            SiteName = Convert.ToBoolean(row["SiteName"]),
                                            CustomerName = Convert.ToBoolean(row["CustomerName"]),
                                            CriteriaName = Convert.ToBoolean(row["CriteriaName"]),
                                            SoftwareKey = row["SoftwareKey"].ToString(),
                                            ProjectName = row["ProjectName"].ToString(),
                                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                                            ReplicateId = row["ReplicateId"].ToString(),
                                            ReplicateHistoryCode = replicateHistory.ReplicateCode,
                                            ReplicateHistoryId = replicateHistory.Id
                                        };
                                        UpdateTextInImageForReplicate(subBasket);
                                        txtInImageList.Add(subBasket);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log the error details for debugging
                                        Console.WriteLine($"Error converting row: {ex.Message}");
                                        // Optionally, you could rethrow the exception or continue
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }

            return txtInImageList;
        }

        private void UpdateTextInImage(List<TextInImageVM> textInImages)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    foreach (var basket in textInImages)
                    {
                        string qry = @"
                    UPDATE TextInImage
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(qry, connection);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", basket.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@ReplicateId", basket.ReplicateId);
                        cmd.Parameters.AddWithValue("@Id", basket.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTextInImageForReplicate(TextInImageVM textInImages)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();


                    string qry = @"
                    UPDATE TextInImage
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", textInImages.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", textInImages.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> PostImageProcessReqList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-ImageProcessRequest";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetImageProcessReqList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedImageProcessReqs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageProcessReqVM>>(responseContent);

                            UpdateImageProcessReq(updatedImageProcessReqs);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        private List<ImageProcessReqVM> GetImageProcessReqList(ReplicateHistoryVM replicateHistory)
        {
            List<ImageProcessReqVM> imageProcessReqList = new List<ImageProcessReqVM>();
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
            SELECT img.Id, img.IsExposureSet, img.ExposureSetValue, img.IsDefectMarking, img.IsPerspectiveCorrection, img.IsRename, img.RenameWith, img.IsTextInImage, img.TextInImage, img.IsImageFullScreen,img.IsSeverityScore,img.AcceptanceCriteria,
                   soft.SoftwareKey, p.ProjectName, img.ReplicateId, img.ReplicateStatus
            FROM ImageProcessReq img
            INNER JOIN ProjectDetails p ON img.PDId = p.Id
            INNER JOIN CompanySoftware soft ON img.SoftwareId = soft.Id
            WHERE img.ReplicateStatus IS NULL";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    try
                                    {
                                        ImageProcessReqVM imgProcess = new ImageProcessReqVM
                                        {
                                            Id = Convert.ToInt32(row["Id"]),
                                            IsExposureSet = Convert.ToBoolean(row["IsExposureSet"]),
                                            ExposureSetValue = row["ExposureSetValue"].ToString(),
                                            IsDefectMarking = Convert.ToBoolean(row["IsDefectMarking"]),
                                            IsPerspectiveCorrection = Convert.ToBoolean(row["IsPerspectiveCorrection"]),
                                            IsRename = Convert.ToBoolean(row["IsRename"]),
                                            RenameWith = row["RenameWith"].ToString(),
                                            TextInImage = row["TextInImage"].ToString(),
                                            IsTextInImage = Convert.ToBoolean(row["IsTextInImage"]),
                                            IsImageFullScreen = Convert.ToBoolean(row["IsImageFullScreen"]),
                                            IsSeverityScore = Convert.ToBoolean(row["IsSeverityScore"]),
                                            SoftwareKey = row["SoftwareKey"].ToString(),
                                            ProjectName = row["ProjectName"].ToString(),
                                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                                            ReplicateId = row["ReplicateId"].ToString(),
                                            AcceptanceCriteria = row["AcceptanceCriteria"].ToString(),
                                            ReplicateHistoryId = replicateHistory.Id,
                                            ReplicateHistoryCode = replicateHistory.ReplicateCode
                                        };
                                        UpdateImageProcessReqForReplicate(imgProcess);
                                        imageProcessReqList.Add(imgProcess);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log the error details for debugging
                                        Console.WriteLine($"Error converting row: {ex.Message}");
                                        // Optionally, you could rethrow the exception or continue
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }

            return imageProcessReqList;
        }

        private void UpdateImageProcessReq(List<ImageProcessReqVM> imgProcessReqs)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    foreach (var requests in imgProcessReqs)
                    {
                        string qry = @"
                    UPDATE ImageProcessReq
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(qry, connection);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", requests.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@ReplicateId", requests.ReplicateId);
                        cmd.Parameters.AddWithValue("@Id", requests.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateImageProcessReqForReplicate(ImageProcessReqVM imgProcessReqs)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();


                    string qry = @"
                    UPDATE ImageProcessReq
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", imgProcessReqs.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", imgProcessReqs.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<bool> PostBulkImageDataList(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-BulkImageData";


                using (HttpClient client = new HttpClient())
                {
                    var data = GetBulkImageDataList(replicateHistory);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedBulkImageData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BulkImageDataVM>>(responseContent);

                            UpdateBulkImageData(updatedBulkImageData);

                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        private List<BulkImageDataVM> GetBulkImageDataList(ReplicateHistoryVM replicateHistory)
        {
            List<BulkImageDataVM> bulkImageDataList = new List<BulkImageDataVM>();
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                                        SELECT 
                                b.Id, 
                                b.BulkProcessCode,
                                b.BulkImageDataName, 
                                b.ExcelFilePath, 
                                b.NoOfImages, 
                                b.NoOfProcess, 
                                b.ProcessResult, 
                                b.InputFolder, 
                                b.CreatedDate, 
                                b.UpdatedDate,
                                p.ProjectName, 
                                b.ReplicateId, 
                                b.ReplicateStatus,
                                soft.SoftwareKey
                            FROM 
                                BulkImageData b
                            INNER JOIN 
                                ProjectDetails p 
                                ON b.PDId = p.Id
                            INNER JOIN 
                                CompanySoftware soft
                                ON b.SoftwareId = soft.Id
                            WHERE 
                                b.ReplicateStatus IS NULL";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    try
                                    {
                                        BulkImageDataVM bulkImageData = new BulkImageDataVM
                                        {
                                            Id = Convert.ToInt32(row["Id"]),
                                            BulkProcessCode = row["BulkProcessCode"].ToString(),
                                            BulkImageDataName = row["BulkImageDataName"].ToString(),
                                            ExcelFilePath = row["ExcelFilePath"].ToString(),
                                            NoOfProcess = Convert.ToInt32(row["NoOfProcess"].ToString()),
                                            NoOfImages = Convert.ToInt32(row["NoOfImages"].ToString()),
                                            ProcessResult = row["ProcessResult"].ToString(),
                                            InputFolder = row["InputFolder"].ToString(),
                                            ProjectName = row["ProjectName"].ToString(),
                                            ReplicateStatus = row["ReplicateStatus"].ToString(),
                                            ReplicateId = row["ReplicateId"].ToString(),
                                            ReplicateHistoryId = replicateHistory.Id,
                                            ReplicateHistoryCode = replicateHistory.ReplicateCode,
                                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]).Date,
                                            UpdatedDate = Convert.ToDateTime(row["UpdatedDate"]).Date,
                                            SoftwareKey = row["SoftwareKey"].ToString()
                                        };
                                        UpdateBulkImageDataForReplicate(bulkImageData);
                                        bulkImageDataList.Add(bulkImageData);
                                    }
                                    catch (Exception ex)
                                    {
                                        // Log the error details for debugging
                                        Console.WriteLine($"Error converting row: {ex.Message}");
                                        // Optionally, you could rethrow the exception or continue
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project details", ex);
            }

            return bulkImageDataList;
        }

        private void UpdateBulkImageData(List<BulkImageDataVM> bulkImageDataList)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    foreach (var requests in bulkImageDataList)
                    {
                        string qry = @"
                    UPDATE BulkImageData
                    SET ReplicateStatus = @ReplicateStatus, ReplicateId = @ReplicateId
                    WHERE Id = @Id";

                        SqlCommand cmd = new SqlCommand(qry, connection);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", requests.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@ReplicateId", requests.ReplicateId);
                        cmd.Parameters.AddWithValue("@Id", requests.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBulkImageDataForReplicate(BulkImageDataVM bulkImageData)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();


                    string qry = @"
                    UPDATE BulkImageData
                    SET ReplicateHistoryId = @ReplicateHistoryId
                    WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@ReplicateHistoryId", bulkImageData.ReplicateHistoryId);
                    cmd.Parameters.AddWithValue("@Id", bulkImageData.Id);

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error occurred while updating site status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected async void btnImport_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            _loader.Visible = true;
            var software = GetSoftwareData();
            string softwareKey = software.SoftwareKey;

            if (string.IsNullOrEmpty(softwareKey))
            {
                MessageBox.Show("Please enter a software key.");
                return;
            }

            string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/GetSoftwareData/{softwareKey}";

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(baseUrl);

                    response.EnsureSuccessStatusCode();

                    var responseData = await response.Content.ReadAsStringAsync();

                    var updatedData = JsonConvert.DeserializeObject<ImportAllData>(responseData);

                    for (int i = 1; i <= 11; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                await SaveEmployee(updatedData.CompanyEmployeeList);
                                break;
                            case 2:
                                await SaveSiteAsync(updatedData.SiteList);
                                break;
                            case 3:
                                await SaveCustomer(updatedData.CompanyCustomerList);
                                break;
                            case 4:
                                await SaveCriteria(updatedData.CriteriaBasketList);
                                break;
                            case 5:
                                await SaveSubCriteria(updatedData.AcceptanceCriteriaMainList);
                                break;
                            case 6:
                                await SaveSubCriteriaItems(updatedData.AcceptanceCriteriaList);
                                break;
                            case 7:
                                await SaveProjectDetails(updatedData.ProjectDetailsList);
                                break;
                            case 8:
                                await SaveTextInImage(updatedData.TextInImageList);
                                break;
                            case 9:
                                await SaveImageProcessRequests(updatedData.ImageProcessReqList);
                                break;
                            case 10:
                                await SaveBulkImageData(updatedData.BulkImageDataList);
                                break;
                            case 11:
                                await SaveImgProcessList(updatedData.ImageProcessDataList);
                                break;

                        }

                    }
                    MessageBox.Show("Image Process Data Import Successfully...");

                }
                catch (HttpRequestException httpRequestException)
                {
                    // Handle HTTP request errors
                    MessageBox.Show($"Request error: {httpRequestException.Message}", "Error");
                }
                catch (Exception ex)
                {
                    // Handle other types of errors
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            }

            _loader.Visible = false;
            this.Enabled = true;
        }

        #region Save All Data

        private async Task SaveSiteAsync(List<SiteVM> sites)
        {
            using (var connection = DBHelper.GetConnection())
            {
                await connection.OpenAsync();

                // Using statement to ensure the transaction is disposed of properly
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var site in sites)
                        {
                            // Check if a site with the given ReplicateId exists
                            using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM Site WHERE ReplicateId = @ReplicateId AND ReplicateStatus = @ReplicateStatus", connection, transaction))
                            {
                                cmdCheckExists.Parameters.Add("@ReplicateId", SqlDbType.VarChar).Value = site.ReplicateId;
                                cmdCheckExists.Parameters.Add("@ReplicateStatus", SqlDbType.VarChar).Value = site.ReplicateStatus;
                                int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                                if (count == 0)
                                {
                                    // Site does not exist, insert it
                                    using (var cmdInsertSite = new SqlCommand("INSERT INTO Site (Name, SoftwareId, ReplicateId, ReplicateStatus) VALUES (@Name, @SoftwareId, @ReplicateId, @ReplicateStatus);", connection, transaction))
                                    {
                                        cmdInsertSite.Parameters.Add("@Name", SqlDbType.VarChar).Value = site.Name;
                                        cmdInsertSite.Parameters.Add("@SoftwareId", SqlDbType.Int).Value = _employee.SoftwareId;
                                        cmdInsertSite.Parameters.Add("@ReplicateId", SqlDbType.VarChar).Value = site.ReplicateId;
                                        cmdInsertSite.Parameters.Add("@ReplicateStatus", SqlDbType.VarChar).Value = site.ReplicateStatus;

                                        await cmdInsertSite.ExecuteNonQueryAsync();
                                    }
                                }
                            }
                        }

                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        // Consider logging the exception details here for diagnostics
                        throw; // Rethrow the exception to preserve the stack trace
                    }
                }
            }
        }

        private async Task<bool> SaveEmployee(List<CompanyEmployeeVM> employees)
        {
            using (var connection = DBHelper.GetConnection())
            {
                await connection.OpenAsync();
                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var employee in employees)
                    {
                        // Check if the employee already exists
                        var employeeExists = await CheckEmployeeExists(connection, transaction, employee);

                        if (!employeeExists)
                        {
                            var userId = Guid.NewGuid().ToString();  // Generate a new GUID for the new user

                            // Insert new user into AspNetUsers
                            await InsertUser(connection, transaction, userId, employee);

                            // Upsert employee into CompanyEmployee
                            await UpsertEmployee(connection, transaction, userId, employee);
                        }
                    }

                    await transaction.CommitAsync();
                    this.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        await transaction.RollbackAsync();
                    }
                    return false;
                }
            }
        }

        private async Task<bool> CheckEmployeeExists(SqlConnection connection, SqlTransaction transaction, CompanyEmployeeVM employee)
        {
            using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM CompanyEmployee WHERE EmployeeCode=@EmployeeCode AND ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
            {
                cmdCheckExists.Parameters.AddWithValue("@ReplicateId", employee.ReplicateId);
                cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", employee.ReplicateStatus);
                cmdCheckExists.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);

                int count = (int)await cmdCheckExists.ExecuteScalarAsync();
                return count > 0;
            }
        }

        private async Task InsertUser(SqlConnection connection, SqlTransaction transaction, string userId, CompanyEmployeeVM employee)
        {
            using (var cmdInsertUser = new SqlCommand("INSERT INTO AspNetUsers (Id, FirstName,MiddleName,LastName, Email, UserName) VALUES (@Id, @FirstName,@MiddleName,@LastName, @Email, @UserName)", connection, transaction))
            {
                cmdInsertUser.Parameters.AddWithValue("@Id", userId);
                cmdInsertUser.Parameters.AddWithValue("@FirstName", employee.FirstName != null ? employee.FirstName : DBNull.Value);
                cmdInsertUser.Parameters.AddWithValue("@MiddleName", employee.MiddleName != null ? employee.MiddleName : DBNull.Value);
                cmdInsertUser.Parameters.AddWithValue("@LastName", employee.LastName != null ? employee.LastName : DBNull.Value);
                cmdInsertUser.Parameters.AddWithValue("@Email", employee.Username);
                cmdInsertUser.Parameters.AddWithValue("@UserName", employee.Username);

                await cmdInsertUser.ExecuteNonQueryAsync();
            }
        }

        private async Task UpsertEmployee(SqlConnection connection, SqlTransaction transaction, string userId, CompanyEmployeeVM employee)
        {
            try
            {
                using (var cmdUpsertEmployee = new SqlCommand(@"
        MERGE CompanyEmployee AS target
        USING (SELECT @UserId AS UserId) AS source
        ON target.UserId = source.UserId
        WHEN MATCHED THEN
            UPDATE SET IsActive = @IsActive, Password = @Password, Username = @Username, SoftwareId = @SoftwareId, EmployeeName = @EmployeeName, CompanyId = @CompanyId, EmployeeCode = @EmployeeCode, UpdatedDate = @UpdatedDate, ManageBy = @ManageBy, CreatedDate = @CreatedDate, EmployeeType = @EmployeeType
        WHEN NOT MATCHED THEN
            INSERT (UserId, IsActive, Password, Username, SoftwareId, EmployeeName, CompanyId, ReplicateId, ReplicateStatus, EmployeeCode, CreatedDate, ManageBy, EmployeeType, UpdatedDate) 
            VALUES (@UserId, @IsActive, @Password, @Username, @SoftwareId, @EmployeeName, @CompanyId, @ReplicateId, @ReplicateStatus, @EmployeeCode, @CreatedDate, @ManageBy, @EmployeeType, @UpdatedDate);", connection, transaction))
                {
                    cmdUpsertEmployee.Parameters.AddWithValue("@UserId", userId);
                    cmdUpsertEmployee.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    cmdUpsertEmployee.Parameters.AddWithValue("@Password", employee.Password);
                    cmdUpsertEmployee.Parameters.AddWithValue("@Username", employee.Username);
                    cmdUpsertEmployee.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                    cmdUpsertEmployee.Parameters.AddWithValue("@CompanyId", _employee.CompanyId);
                    cmdUpsertEmployee.Parameters.AddWithValue("@EmployeeName", employee.FirstName + " " + employee.LastName);
                    cmdUpsertEmployee.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
                    cmdUpsertEmployee.Parameters.AddWithValue("@ReplicateId", employee.ReplicateId);
                    cmdUpsertEmployee.Parameters.AddWithValue("@ReplicateStatus", employee.ReplicateStatus);
                    cmdUpsertEmployee.Parameters.AddWithValue("@CreatedDate", employee.CreatedDate);
                    cmdUpsertEmployee.Parameters.AddWithValue("@UpdatedDate", employee.UpdatedDate != null ? employee.UpdatedDate : DBNull.Value);
                    cmdUpsertEmployee.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType != null ? employee.EmployeeType : SD.Operator);

                    if (!string.IsNullOrEmpty(employee.ManageBy))
                    {
                        var employeeId = GetEmployeeIdByCode(null, employee.ManageBy);
                        cmdUpsertEmployee.Parameters.AddWithValue("@ManageBy", employeeId);
                    }
                    else
                    {
                        cmdUpsertEmployee.Parameters.AddWithValue("@ManageBy", DBNull.Value);
                    }

                    await cmdUpsertEmployee.ExecuteNonQueryAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task<bool> SaveCustomer(List<CompanyCustomerVM> customerList)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var customer in customerList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM CompanyCustomer WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", customer.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", customer.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO CompanyCustomer (CustomerName, AboutCustomer, SoftwareId,CompanyId,IsActive,ReplicateId,ReplicateStatus) VALUES (@CustomerName, @AboutCustomer, @SoftwareId,@CompanyId,@IsActive,@ReplicateId,@ReplicateStatus)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                                    cmdInsertUser.Parameters.AddWithValue("@AboutCustomer", customer.AboutCustomer);
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@CompanyId", _employee.CompanyId);
                                    cmdInsertUser.Parameters.AddWithValue("@IsActive", customer.IsActive);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", customer.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", customer.ReplicateStatus);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveCriteria(List<CriteriaBasketVM> criteriaList)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var criteria in criteriaList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM CriteriaBasket WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", criteria.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", criteria.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO CriteriaBasket (Name, SoftwareId,ReplicateId,ReplicateStatus) VALUES (@Name, @SoftwareId,@ReplicateId,@ReplicateStatus)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@Name", criteria.Name);
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", criteria.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", criteria.ReplicateStatus);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveSubCriteria(List<AcceptanceCriteriaMainVM> subCriteriaList)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var subCriteria in subCriteriaList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM AcceptanceCriteriaMain WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", subCriteria.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", subCriteria.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO AcceptanceCriteriaMain (BasketName, AcceptanceOptions,CriteriaBasketId,SoftwareId,ReplicateId,ReplicateStatus) VALUES (@BasketName, @AcceptanceOptions,@CriteriaBasketId,@SoftwareId,@ReplicateId,@ReplicateStatus)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@BasketName", subCriteria.BasketName);
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@AcceptanceOptions", subCriteria.AcceptanceOptions == null ? DBNull.Value : subCriteria.AcceptanceOptions);
                                    cmdInsertUser.Parameters.AddWithValue("@CriteriaBasketId", GetCriteriaByName(subCriteria.CriteriaBasketName));
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", subCriteria.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", subCriteria.ReplicateStatus);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveSubCriteriaItems(List<AcceptanceCriteriaVM> subCriteriaItemList)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var subCriteria in subCriteriaItemList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM AcceptanceCriteria WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", subCriteria.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", subCriteria.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO AcceptanceCriteria (DefectTypeId, UnitOfMeasurement,AcceptableMeasurement,QuantityAcceptable,FactoryLineId,ReplicateId,ReplicateStatus) VALUES (@DefectTypeId, @UnitOfMeasurement,@AcceptableMeasurement,@QuantityAcceptable,@FactoryLineId,@ReplicateId,@ReplicateStatus)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@DefectTypeId", BindDefectTypeByName(subCriteria.DefectTypeName));
                                    cmdInsertUser.Parameters.AddWithValue("@UnitOfMeasurement", subCriteria.UnitOfMeasurement);
                                    cmdInsertUser.Parameters.AddWithValue("@AcceptableMeasurement", subCriteria.AcceptableMeasurement);
                                    cmdInsertUser.Parameters.AddWithValue("@QuantityAcceptable", subCriteria.QuantityAcceptable);
                                    cmdInsertUser.Parameters.AddWithValue("@FactoryLineId", GetSubCriteriaByName(subCriteria.FactoryLineName));
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", subCriteria.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", subCriteria.ReplicateStatus);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private int GetCriteriaByName(string criteriaName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select Id from CriteriaBasket where Name=@Name";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@Name", criteriaName);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
                return 0;

            }
        }

        private int GetSiteByName(string siteName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select Id from Site where Name=@Name";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@Name", siteName);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
                return 0;

            }
        }

        private int GetEmployeeIdByCode(string employeeCode, string username = null)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = string.Empty;
                    if (!string.IsNullOrEmpty(username))
                    {
                        qry = "select Id from CompanyEmployee where Username=@Username";
                    }
                    else
                    {
                        qry = "select Id from CompanyEmployee where EmployeeCode=@EmployeeCode";
                    }
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    if (username != null)
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@EmployeeCode", employeeCode);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
                return 0;

            }
        }

        private string GetUserIdByUserName(string username)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "SELECT Id FROM AspNetUsers WHERE UserName=@UserName";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);

                        cmd.CommandTimeout = 60;

                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Exception: " + ex.Message);
                }
                return string.Empty;
            }
        }

        private int GetSubCriteriaByName(string subCriteriaName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select Id from AcceptanceCriteriaMain where BasketName=@BasketName";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@BasketName", subCriteriaName);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
                return 0;

            }
        }

        private int BindDefectTypeByName(string defectName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select Id,Value from DefectType where Value='{defectName}'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return Convert.ToInt32(dt.Rows[0]["Id"].ToString());

                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        private int BindProjectIdByName(string projectName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select Id from ProjectDetails where ProjectName='{projectName}'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return Convert.ToInt32(dt.Rows[0]["Id"].ToString());

                    }
                    return 0;

                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        private int GetCompanyCustomerByName(string customerName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = "select Id from CompanyCustomer where CustomerName=@CustomerName";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                }
                return 0;

            }
        }

        private async Task<bool> SaveProjectDetails(List<ProjectDetailsVM> projectDetailsList)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var project in projectDetailsList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT * FROM ProjectDetails WHERE ReplicateId = @ReplicateId", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", project.ReplicateId);

                            var count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO ProjectDetails (SoftwareId, EmployeeId, ProjectName, WP_Product, Date, Shift, ManufacturerName, ManufacturingBy, CustomerId, CriteriaBasketId, SubCriteriaBasketId, ModuleMatrix, ElementWith, CellSize, SiteId, ReplicateId, ReplicateStatus, ProjectStatus,StartDate,EndDate) VALUES (@SoftwareId, @EmployeeId, @ProjectName, @WP_Product, @Date, @Shift, @ManufacturerName, @ManufacturingBy, @CustomerId, @CriteriaBasketId, @SubCriteriaBasketId, @ModuleMatrix, @ElementWith, @CellSize, @SiteId, @ReplicateId, @ReplicateStatus, @ProjectStatus,@StartDate,@EndDate)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@EmployeeId", GetEmployeeIdByCode(project.EmployeeCode));
                                    cmdInsertUser.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                                    cmdInsertUser.Parameters.AddWithValue("@WP_Product", project.WP_Product);
                                    cmdInsertUser.Parameters.AddWithValue("@StartDate", project.StartDate);
                                    cmdInsertUser.Parameters.AddWithValue("@EndDate", project.EndDate);
                                    cmdInsertUser.Parameters.AddWithValue("@Date", project.Date);
                                    cmdInsertUser.Parameters.AddWithValue("@Shift", project.Shift);
                                    cmdInsertUser.Parameters.AddWithValue("@ManufacturerName", project.ManufacturerName);
                                    cmdInsertUser.Parameters.AddWithValue("@ManufacturingBy", project.ManufacturingBy);
                                    cmdInsertUser.Parameters.AddWithValue("@CustomerId", GetCompanyCustomerByName(project.CustomerName));
                                    cmdInsertUser.Parameters.AddWithValue("@CriteriaBasketId", GetCriteriaByName(project.CriteriaBasketName));
                                    cmdInsertUser.Parameters.AddWithValue("@SubCriteriaBasketId", GetSubCriteriaByName(project.SubCriteriaBasketName));
                                    cmdInsertUser.Parameters.AddWithValue("@ModuleMatrix", project.ModuleMatrix);
                                    cmdInsertUser.Parameters.AddWithValue("@ElementWith", project.ElementWith);
                                    cmdInsertUser.Parameters.AddWithValue("@CellSize", project.CellSize);
                                    cmdInsertUser.Parameters.AddWithValue("@SiteId", GetSiteByName(project.SiteName));
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", project.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", project.ReplicateStatus);
                                    cmdInsertUser.Parameters.AddWithValue("@ProjectStatus", project.ProjectStatus != null ? project.ProjectStatus : DBNull.Value);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                            else
                            {
                                using (var cmdInsertUser = new SqlCommand("Update ProjectDetails SET ProjectName=@ProjectName, WP_Product=@WP_Product, Date=@Date, Shift=@Shift, ManufacturerName=@ManufacturerName, ManufacturingBy=@ManufacturingBy, CustomerId=@CustomerId, CriteriaBasketId=@CriteriaBasketId, SubCriteriaBasketId=@SubCriteriaBasketId, ModuleMatrix=@ModuleMatrix, ElementWith=@ElementWith, CellSize=@CellSize, SiteId=@SiteId, ReplicateId=@ReplicateId, ReplicateStatus=@ReplicateStatus, ProjectStatus=@ProjectStatus,StartDate=@StartDate,EndDate=@EndDate WHERE Id=@Id", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                                    cmdInsertUser.Parameters.AddWithValue("@WP_Product", project.WP_Product);
                                    cmdInsertUser.Parameters.AddWithValue("@StartDate", project.StartDate);
                                    cmdInsertUser.Parameters.AddWithValue("@EndDate", project.EndDate);
                                    cmdInsertUser.Parameters.AddWithValue("@Date", project.Date);
                                    cmdInsertUser.Parameters.AddWithValue("@Shift", project.Shift);
                                    cmdInsertUser.Parameters.AddWithValue("@ManufacturerName", project.ManufacturerName);
                                    cmdInsertUser.Parameters.AddWithValue("@ManufacturingBy", project.ManufacturingBy);
                                    cmdInsertUser.Parameters.AddWithValue("@CustomerId", GetCompanyCustomerByName(project.CustomerName));
                                    cmdInsertUser.Parameters.AddWithValue("@CriteriaBasketId", GetCriteriaByName(project.CriteriaBasketName));
                                    cmdInsertUser.Parameters.AddWithValue("@SubCriteriaBasketId", GetSubCriteriaByName(project.SubCriteriaBasketName));
                                    cmdInsertUser.Parameters.AddWithValue("@ModuleMatrix", project.ModuleMatrix);
                                    cmdInsertUser.Parameters.AddWithValue("@ElementWith", project.ElementWith);
                                    cmdInsertUser.Parameters.AddWithValue("@CellSize", project.CellSize);
                                    cmdInsertUser.Parameters.AddWithValue("@SiteId", GetSiteByName(project.SiteName));
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", project.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", project.ReplicateStatus);
                                    cmdInsertUser.Parameters.AddWithValue("@ProjectStatus", project.ProjectStatus != null ? project.ProjectStatus : DBNull.Value);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }

                            }
                        }
                    }


                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveTextInImage(List<TextInImageVM> textInImageList)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var txtImage in textInImageList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM TextInImage WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", txtImage.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", txtImage.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO TextInImage (IsImageName, WPOfProduct,DateAndShift,IsManufacturer,ManufacturingPlantAndLine,SiteName,CustomerName,CriteriaName,SoftwareId,PDId,ReplicateId,ReplicateStatus) VALUES (@IsImageName,@WPOfProduct,@DateAndShift,@IsManufacturer,@ManufacturingPlantAndLine,@SiteName,@CustomerName,@CriteriaName,@SoftwareId,@PDId,@ReplicateId,@ReplicateStatus)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@IsImageName", txtImage.IsImageName);
                                    cmdInsertUser.Parameters.AddWithValue("@WPOfProduct", txtImage.WPOfProduct);
                                    cmdInsertUser.Parameters.AddWithValue("@DateAndShift", txtImage.DateAndShift);
                                    cmdInsertUser.Parameters.AddWithValue("@IsManufacturer", txtImage.IsManufacturer);
                                    cmdInsertUser.Parameters.AddWithValue("@ManufacturingPlantAndLine", txtImage.ManufacturingPlantAndLine);
                                    cmdInsertUser.Parameters.AddWithValue("@SiteName", txtImage.SiteName);
                                    cmdInsertUser.Parameters.AddWithValue("@CustomerName", txtImage.CustomerName);
                                    cmdInsertUser.Parameters.AddWithValue("@CriteriaName", txtImage.CriteriaName);
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@PDId", BindProjectIdByName(txtImage.ProjectName));
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", txtImage.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", txtImage.ReplicateStatus);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveImageProcessRequests(List<ImageProcessReqVM> imageProcessReqVMs)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var imgReq in imageProcessReqVMs)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM ImageProcessReq WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", imgReq.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", imgReq.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand("INSERT INTO ImageProcessReq (IsExposureSet, ExposureSetValue,IsDefectMarking,IsPerspectiveCorrection,IsRename,RenameWith,IsTextInImage,TextInImage,IsImageFullScreen,IsSeverityScore,AcceptanceCriteria,SoftwareId,PDId,ReplicateId,ReplicateStatus) VALUES " +
                                                                                                       "(@IsExposureSet, @ExposureSetValue,@IsDefectMarking,@IsPerspectiveCorrection,@IsRename,@RenameWith,@IsTextInImage,@TextInImage,@IsImageFullScreen,@IsSeverityScore,@AcceptanceCriteria,@SoftwareId,@PDId,@ReplicateId,@ReplicateStatus)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@IsExposureSet", imgReq.IsExposureSet);
                                    cmdInsertUser.Parameters.AddWithValue("@ExposureSetValue", imgReq.ExposureSetValue);
                                    cmdInsertUser.Parameters.AddWithValue("@IsDefectMarking", imgReq.IsDefectMarking);
                                    cmdInsertUser.Parameters.AddWithValue("@IsPerspectiveCorrection", imgReq.IsPerspectiveCorrection);
                                    cmdInsertUser.Parameters.AddWithValue("@IsRename", imgReq.IsRename);
                                    cmdInsertUser.Parameters.AddWithValue("@RenameWith", imgReq.RenameWith);
                                    cmdInsertUser.Parameters.AddWithValue("@IsTextInImage", imgReq.IsTextInImage);
                                    cmdInsertUser.Parameters.AddWithValue("@TextInImage", imgReq.TextInImage);
                                    cmdInsertUser.Parameters.AddWithValue("@IsImageFullScreen", imgReq.IsImageFullScreen);
                                    cmdInsertUser.Parameters.AddWithValue("@IsSeverityScore", imgReq.IsSeverityScore);
                                    cmdInsertUser.Parameters.AddWithValue("@AcceptanceCriteria", imgReq.AcceptanceCriteria);
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@PDId", BindProjectIdByName(imgReq.ProjectName));
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", imgReq.ReplicateId);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", imgReq.ReplicateStatus);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveBulkImageData(List<BulkImageDataVM> bulkImages)
        {
            var userId = string.Empty;
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var bulkImage in bulkImages)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM BulkImageData WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", bulkImage.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", bulkImage.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                using (var cmdInsertUser = new SqlCommand(
    "INSERT INTO BulkImageData (BulkProcessCode,ExcelFilePath, NoOfImages, NoOfProcess, CreatedDate, UpdatedDate, ProcessResult, InputFolder, BulkImageDataName, PDId, ReplicateId, ReplicateStatus,SoftwareId) " +
    "VALUES (@BulkProcessCode,@ExcelFilePath, @NoOfImages, @NoOfProcess, @CreatedDate, @UpdatedDate, @ProcessResult, @InputFolder, @BulkImageDataName, @PDId, @ReplicateId, @ReplicateStatus,@SoftwareId)",
    connection, transaction))
                                {
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@BulkProcessCode", SqlDbType.NVarChar, 50) { Value = bulkImage.BulkProcessCode ?? (object)DBNull.Value });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@ExcelFilePath", SqlDbType.NVarChar, 255) { Value = bulkImage.ExcelFilePath ?? (object)DBNull.Value });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@NoOfImages", SqlDbType.Int) { Value = bulkImage.NoOfImages });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@NoOfProcess", SqlDbType.Int) { Value = bulkImage.NoOfProcess });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@ProcessResult", SqlDbType.NVarChar, 255) { Value = bulkImage.ProcessResult ?? (object)DBNull.Value });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@InputFolder", SqlDbType.NVarChar, 255) { Value = bulkImage.InputFolder ?? (object)DBNull.Value });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@BulkImageDataName", SqlDbType.NVarChar, 255) { Value = bulkImage.BulkImageDataName != null ? bulkImage.BulkImageDataName : DBNull.Value });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@PDId", SqlDbType.Int) { Value = BindProjectIdByName(bulkImage.ProjectName) });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@ReplicateId", SqlDbType.NVarChar, 255) { Value = bulkImage.ReplicateId });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@ReplicateStatus", SqlDbType.NVarChar, 255) { Value = bulkImage.ReplicateStatus ?? (object)DBNull.Value });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime) { Value = DateTime.Now });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@UpdatedDate", SqlDbType.DateTime) { Value = DateTime.Now });
                                    cmdInsertUser.Parameters.Add(new SqlParameter("@SoftwareId", SqlDbType.Int) { Value = _employee.SoftwareId });

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }


                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private async Task<bool> SaveImgProcessList(List<ImageProcessDataVM> imgProcessList)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    foreach (var bulkImage in imgProcessList)
                    {
                        using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM ImageProcessData WHERE ReplicateId = @ReplicateId AND ReplicateStatus=@ReplicateStatus", connection, transaction))
                        {
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateId", bulkImage.ReplicateId);
                            cmdCheckExists.Parameters.AddWithValue("@ReplicateStatus", bulkImage.ReplicateStatus);

                            int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                            if (count == 0)
                            {
                                int employeeId = GetEmployeeIdByCode(bulkImage.EmployeeCode);

                                if (employeeId == 0)
                                {
                                    // Handle the case where employeeId is not found
                                    //Console.WriteLine($"EmployeeId not found for EmployeeCode: {bulkImage.EmployeeCode}");
                                    continue;
                                }

                                using (var cmdInsertUser = new SqlCommand(@"
INSERT INTO ImageProcessData (
    Date,
    PDId,
    ModuleSerialNo,
    ModuleLocation,
    ImageName,
    ImageResult,
    SeverityScore,
    ModuleCountName,
    DefectData,
    Crack,
    TreeCrack,
    DeadCell,
    DarkArea,
    OpenSoldering,
    FingerInteruption,
    BackSheetCut,
    EmployeeId,
    SoftwareId,
    IsSuccess,
    ReplicateId,
    ReplicateStatus
) VALUES (
    @Date,
    @PDId,
    @ModuleSerialNo,
    @ModuleLocation,
    @ImageName,
    @ImageResult,
    @SeverityScore,
    @ModuleCountName,
    @DefectData,
    @Crack,
    @TreeCrack,
    @DeadCell,
    @DarkArea,
    @OpenSoldering,
    @FingerInteruption,
    @BackSheetCut,
    @EmployeeId,
    @SoftwareId,
    @IsSuccess,
    @ReplicateId,
    @ReplicateStatus
)", connection, transaction))
                                {
                                    cmdInsertUser.Parameters.AddWithValue("@Date", bulkImage.Date.Date);
                                    cmdInsertUser.Parameters.AddWithValue("@PDId", BindProjectIdByName(bulkImage.ProjectDetailsName));
                                    cmdInsertUser.Parameters.AddWithValue("@ModuleSerialNo", bulkImage.ModuleSerialNo ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@ModuleLocation", bulkImage.ModuleLocation ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@ImageName", bulkImage.ImageName ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@ImageResult", bulkImage.ImageResult ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@SeverityScore", bulkImage.SeverityScore ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@ModuleCountName", bulkImage.ModuleCountName ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@DefectData", bulkImage.DefectData ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@Crack", bulkImage.Crack ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@TreeCrack", bulkImage.TreeCrack ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@DeadCell", bulkImage.DeadCell ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@DarkArea", bulkImage.DarkArea ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@OpenSoldering", bulkImage.OpenSoldering ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@FingerInteruption", bulkImage.FingerInteruption ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@BackSheetCut", bulkImage.BackSheetCut ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@EmployeeId", employeeId);
                                    cmdInsertUser.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                                    cmdInsertUser.Parameters.AddWithValue("@IsSuccess", bulkImage.IsSuccess);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateId", bulkImage.ReplicateId ?? (object)DBNull.Value);
                                    cmdInsertUser.Parameters.AddWithValue("@ReplicateStatus", bulkImage.ReplicateStatus ?? (object)DBNull.Value);

                                    await cmdInsertUser.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        #endregion

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

        private ReplicateHistory SaveReplicateHistory()
        {
            var replicateHistory = new ReplicateHistory();
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;
                int newId = 0;

                try
                {
                    transaction = connection.BeginTransaction();

                    using (var cmdInsertSite = new SqlCommand(
                        @"INSERT INTO ReplicateHistory 
                    (ReplicateTitle, ReplicateBy, ReplicateDate, ReplicateId, ReplicateStatus, SoftwareId, HistoryStatus) 
                VALUES 
                    (@ReplicateTitle, @ReplicateBy, @ReplicateDate, @ReplicateId, @ReplicateStatus, @SoftwareId, @HistoryStatus);
                SELECT SCOPE_IDENTITY();", connection, transaction))
                    {
                        replicateHistory.ReplicateTitle = $"Data Upload on {DateTime.Now.ToString("f")}";
                        replicateHistory.ReplicateDate = DateTime.Now;
                        replicateHistory.SoftwareId = _employee.SoftwareId;
                        replicateHistory.ReplicateBy = _employee.UserId;
                        replicateHistory.ReplicateCode = GenerateReplicateCode();
                        replicateHistory.HistoryStatus = SD.StartUpload;


                        cmdInsertSite.Parameters.AddWithValue("@ReplicateTitle", replicateHistory.ReplicateTitle);
                        cmdInsertSite.Parameters.AddWithValue("@ReplicateBy", replicateHistory.ReplicateBy);
                        cmdInsertSite.Parameters.AddWithValue("@ReplicateDate", replicateHistory.ReplicateDate);
                        cmdInsertSite.Parameters.AddWithValue("@ReplicateId", DBNull.Value);
                        cmdInsertSite.Parameters.AddWithValue("@ReplicateStatus", DBNull.Value);
                        cmdInsertSite.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                        cmdInsertSite.Parameters.AddWithValue("@HistoryStatus", replicateHistory.HistoryStatus);
                        cmdInsertSite.Parameters.AddWithValue("@ReplicateCode", replicateHistory.ReplicateCode);

                        newId = Convert.ToInt32(cmdInsertSite.ExecuteScalar());
                        replicateHistory.Id = newId;

                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    throw;
                }

                return replicateHistory;
            }
        }

        private async Task<ReplicateHistoryVM> PostReplicateHistoryLive(ReplicateHistory replicateHistory)
        {
            try
            {
                string baseUrl = $"{SD.ApiUrlBasePath}/api/ProjectDetails/Upload-ReplicateHistory";

                var software = GetSoftwareData();
                using (HttpClient client = new HttpClient())
                {
                    var history = new ReplicateHistoryVM();
                    history.Id = replicateHistory.Id;
                    history.ReplicateCode = replicateHistory.ReplicateCode;
                    history.ReplicateDate = replicateHistory.ReplicateDate;
                    history.ReplicateStatus = replicateHistory.ReplicateStatus;
                    history.SoftwareKey = software.SoftwareKey;
                    history.ReplicateBy = _employee.Username;
                    history.HistoryStatus = replicateHistory.HistoryStatus;
                    history.ReplicateTitle = replicateHistory.ReplicateTitle;

                    if (history == null)
                    {
                        return new ReplicateHistoryVM();
                    }

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(history);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {

                        HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var updatedReplicateHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<ReplicateHistoryVM>(responseContent);

                            UpdateReplicateHistoryStatus(updatedReplicateHistory);

                            return updatedReplicateHistory;
                        }
                        else
                        {
                            return new ReplicateHistoryVM();
                        }

                    }
                    catch (Exception ex)
                    {
                        return new ReplicateHistoryVM();
                    }
                }
            }
            catch (Exception)
            {

                return new ReplicateHistoryVM();
            }
        }

        public void UpdateReplicateHistoryStatus(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = "UPDATE ReplicateHistory SET ReplicateId = @ReplicateId,ReplicateStatus=@ReplicateStatus WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@ReplicateId", replicateHistory.ReplicateId);
                        cmd.Parameters.AddWithValue("@ReplicateStatus", replicateHistory.ReplicateStatus);
                        cmd.Parameters.AddWithValue("@Id", replicateHistory.Id);

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating project details status", ex);
            }
        }

        public void UpdateReplicateHistoryForComplated(ReplicateHistoryVM replicateHistory)
        {
            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = "UPDATE ReplicateHistory SET HistoryStatus=@HistoryStatus WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@HistoryStatus", SD.Complated);
                        cmd.Parameters.AddWithValue("@Id", replicateHistory.Id);

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating project details status", ex);
            }
        }

        public void GetUploadDataList()
        {
            List<ReplicateHistoryVM> projectDetailsList = new List<ReplicateHistoryVM>();

            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    string qry = @"
                SELECT rh.Id,rh.ReplicateDate,rh.ReplicateTitle,usr.UserName as ReplicateBy,rh.ReplicateCode,rh.HistoryStatus from ReplicateHistory rh Inner Join AspNetUsers usr On rh.ReplicateBy=usr.Id Order By Id Desc";

                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dtGridView.DataSource = dt;

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching Replicate History", ex);
            }

        }

        private string GenerateReplicateCode()
        {
            var today = DateTime.Now;

            var datePart = today.ToString("yyyyMMdd");

            var uniquePart = Guid.NewGuid().ToString("N").Substring(0, 8); // Using first 6 characters of a GUID

            var code = $"{datePart}{uniquePart}";

            return code;
        }

        private async Task SaveReplicateHistoryAsync(List<ReplicateHistoryVM> histories)
        {
            using (var connection = DBHelper.GetConnection())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var replicateHistory in histories)
                        {
                            using (var cmdCheckExists = new SqlCommand("SELECT COUNT(1) FROM ReplicateHistory WHERE ReplicateId = @ReplicateId AND ReplicateStatus = @ReplicateStatus", connection, transaction))
                            {
                                cmdCheckExists.Parameters.Add(new SqlParameter("@ReplicateId", SqlDbType.VarChar) { Value = replicateHistory.ReplicateId });
                                cmdCheckExists.Parameters.Add(new SqlParameter("@ReplicateStatus", SqlDbType.VarChar) { Value = replicateHistory.ReplicateStatus });

                                int count = (int)await cmdCheckExists.ExecuteScalarAsync();

                                if (count == 0)
                                {
                                    using (var cmdInsertReplicate = new SqlCommand("INSERT INTO ReplicateHistory (ReplicateTitle,ReplicateBy, ReplicateDate, ReplicateId, ReplicateStatus, SoftwareId, HistoryStatus, ReplicateCode) VALUES (@ReplicateTitle,@ReplicateBy, @ReplicateDate, @ReplicateId, @ReplicateStatus, @SoftwareId, @HistoryStatus, @ReplicateCode);SELECT SCOPE_IDENTITY();", connection, transaction))
                                    {
                                        var user = new SeedData();
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@ReplicateTitle", SqlDbType.VarChar) { Value = replicateHistory.ReplicateTitle });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@ReplicateDate", SqlDbType.DateTime) { Value = replicateHistory.ReplicateDate });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@ReplicateId", SqlDbType.VarChar) { Value = replicateHistory.ReplicateId });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@ReplicateStatus", SqlDbType.VarChar) { Value = replicateHistory.ReplicateStatus });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@SoftwareId", SqlDbType.Int) { Value = _employee.SoftwareId });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@HistoryStatus", SqlDbType.VarChar) { Value = replicateHistory.HistoryStatus });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@ReplicateCode", SqlDbType.VarChar) { Value = replicateHistory.ReplicateCode });
                                        cmdInsertReplicate.Parameters.Add(new SqlParameter("@ReplicateBy", SqlDbType.VarChar) { Value = user.GetUserIdByUserName(replicateHistory.ReplicateBy) });

                                        int newId = Convert.ToInt32(await cmdInsertReplicate.ExecuteScalarAsync());
                                    }
                                }
                            }
                        }

                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }

    }
}
