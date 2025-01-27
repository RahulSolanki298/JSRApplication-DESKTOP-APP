using System.Data.SqlClient;
using System.IO;

namespace LocalApplication.Helpers
{
    public class ConnectionStringInitilize
    {
        public void Initialize()
        {
            string dataDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string databaseFile = "Data\\local_database_jsr.mdf";
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Path.Combine(dataDirectory, databaseFile)};Integrated Security=True;";
            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\DotNet\\JSR\\JSR_PROJECT\\LocalApplication\\Data\\local_database_jsr.mdf;Integrated Security=True";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            builder["Server"] = "(LocalDB)\\MSSQLLocalDB";
            builder["Integrated Security"] = true;

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            try
            {
                connection.Open();
                // Connection is open, do something...
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
