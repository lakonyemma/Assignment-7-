using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Assignment7.Models;

namespace Assignment7
{
    public class DatabaseService
    {
        // Replace Server and Database with your SQL Server details before running.
        private const string ConnectionString =
            "Server=localhost;Database=SaccoDB;Integrated Security=True;TrustServerCertificate=True;";

        public async Task<Staff> AuthenticateStaffAsync(string email, string password)
        {
            const string sql = @"
                SELECT TOP 1 StaffId, FullName, Email, Role
                FROM Staff
                WHERE Email = @Email AND PasswordHash = @PasswordHash AND IsActive = 1;";

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Email", email.Trim());
                command.Parameters.AddWithValue("@PasswordHash", password);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (!reader.Read())
                        return null;

                    return new Staff
                    {
                        StaffId = reader.GetInt32(reader.GetOrdinal("StaffId")),
                        FullName = reader.GetString(reader.GetOrdinal("FullName")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Role = reader.GetString(reader.GetOrdinal("Role"))
                    };
                }
            }
        }
    }
}
