using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL
{
    internal class DatabaseContext
    {
        private readonly string connectionString = @"Data Source=DESKTOP-R74P066\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true; // Kết nối thành công
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                return false; // Kết nối thất bại
            }
        }
    }
}
