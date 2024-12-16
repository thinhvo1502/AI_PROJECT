using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Repositories
{
    internal class UserRepository
    {
        private DatabaseContext _context;

        public UserRepository()
        {
            _context = new DatabaseContext();
        }

        public void AddUser(User user)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.ExecuteNonQuery();
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            PasswordHash = reader.GetString(2),
                            Role = reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }

    }
}
