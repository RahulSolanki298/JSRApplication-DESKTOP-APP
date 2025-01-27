using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LocalApplication.Helpers
{
    public static class ConfigurationName
    {
        public static string GetConnectionString()
        {
            string dataDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string databaseFile = "Data\\local_database_jsr.mdf";
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Path.Combine(dataDirectory, databaseFile)};Integrated Security=True;";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            builder["Server"] = "(LocalDB)\\MSSQLLocalDB";
            builder["Integrated Security"] = true;
            
            return builder.ConnectionString;
        }
    }
}
