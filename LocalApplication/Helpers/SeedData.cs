using System.Data;
using System.Data.SqlClient;

namespace LocalApplication.Helpers
{
    public class SeedData
    {
        DBHelper DBHelper = new DBHelper();

        public bool CheckDataAvailble()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT * from AspNetUsers";

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }
            return false;
        }

        public bool Seed()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT * from AspNetUsers";

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }
            return false;
        }

        public bool SeedDefectType(int softwareId)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = $"SELECT * from DefectType where SoftwareId={softwareId}";

                    SqlCommand cmd = new SqlCommand(qry, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {

                        addDefectType(softwareId);

                        return true;
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }
            return false;

        }

        private void addDefectType(int softwareId)
        {
            var defectTypes = new string[]
            {
                "Cell Crack",
                "Tree / Branch crack",
                "Dead Cell",
                "Dark Spot",
                "Finger Interruption",
                "Open Soldering",
                "Backsheet Cut"
            };

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var defectType in defectTypes)
                        {
                            string checkQuery = "SELECT COUNT(*) FROM DefectType WHERE SoftwareId = @SoftwareId";
                            using (var checkCmd = new SqlCommand(checkQuery, connection, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@SoftwareId", softwareId);
                                int count = (int)checkCmd.ExecuteScalar();

                                if (count == 0)
                                {
                                    string insertQuery = "INSERT INTO DefectType (DefectName,SoftwareId) VALUES (@DefectName,@SoftwareId)";
                                    using (var insertCmd = new SqlCommand(insertQuery, connection, transaction))
                                    {
                                        insertCmd.Parameters.AddWithValue("@DefectName", defectType);
                                        insertCmd.Parameters.AddWithValue("@SoftwareId", softwareId);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Log the exception or handle it as needed
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public string GetUserIdByUserName(string userName)
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    string qry = "SELECT Id FROM AspNetUsers WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(qry, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions
                }
            }
            return null; // Return null if no user is found
        }


    }
}
