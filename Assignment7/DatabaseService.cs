using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Assignment7.Models;

namespace Assignment7
{
    public class DatabaseService
    {
        // Change the Server value to the SQL Server instance used on your computer.
        private const string ConnectionString =
            "Server=localhost;Database=SaccoDB;Integrated Security=True;TrustServerCertificate=True;";

        public async Task<Staff> AuthenticateStaffAsync(string email, string password)
        {
            const string sql = @"
                SELECT TOP 1 StaffId, FullName, Email, Role
                FROM dbo.Staff
                WHERE Email = @Email
                  AND PasswordHash = @PasswordHash
                  AND IsActive = 1;";

            byte[] passwordHash = CreateSha256Hash(password);

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email.Trim();
                command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 32).Value = passwordHash;

                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (!await reader.ReadAsync())
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

        private static byte[] CreateSha256Hash(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(value ?? string.Empty));
            }
        }
    }
}
