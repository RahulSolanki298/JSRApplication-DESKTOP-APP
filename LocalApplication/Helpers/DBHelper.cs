using LocalApplication.DTO;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

namespace LocalApplication.Helpers
{
    public class DBHelper
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationName.GetConnectionString());
        }
        public CompanyEmployee AuthenticateUser(string username, string password)
        {
            CompanyEmployee Employee = new CompanyEmployee();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM CompanyEmployee WHERE Username = @Username AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            Employee.Id = Convert.ToInt32(reader["Id"]);
                            Employee.UserId = reader["UserId"].ToString();
                            Employee.SoftwareId = Convert.ToInt32(reader["SoftwareId"]);
                            Employee.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            Employee.EmployeeCode = reader["EmployeeCode"].ToString();
                            Employee.Password = reader["Password"].ToString();
                            Employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                            Employee.EmployeeType = reader["EmployeeType"].ToString();
                            Employee.Username = username;
                            return Employee;
                        }
                        else
                        {
                            return new CompanyEmployee();
                        }
                    }
                }
            }
        }

        public CompanyEmployee AuthenticateAdmin(string username, string password)
        {
            CompanyEmployee Employee = new CompanyEmployee();

            using (var connection = GetConnection())
            {
                connection.Open();

                var query = "SELECT * FROM CompanyAdmin WHERE UserName = @Username AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Employee.Id = Convert.ToInt32(reader["Id"]);
                            Employee.UserId = reader["UserId"].ToString();
                            Employee.Username = username;
                            Employee.SoftwareId = Convert.ToInt32(reader["SoftwareId"]);
                            Employee.IsActive = true;
                            Employee.Password = reader["Password"].ToString();
                            Employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                            Employee.EmployeeType = SD.Admin;
                            return Employee;
                        }
                    }
                }
            }

            return new CompanyEmployee();
        }

        public DateTime? GetNullableDateTime(object value)
        {
            return value != DBNull.Value ? Convert.ToDateTime(value) : (DateTime?)null;
        }

    }
}
