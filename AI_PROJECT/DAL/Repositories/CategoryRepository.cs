using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Repositories
{
    internal class CategoryRepository
    {
        private DatabaseContext _context;

        public CategoryRepository()
        {
            _context = new DatabaseContext();
        }

        public List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Categories", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryID = reader.GetInt32(0),
                            CategoryName = reader.GetString(1)
                        });
                    }
                }
            }
            return categories;
        }

        public void AddCategory(Category category)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", connection);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.ExecuteNonQuery();
            }
        }
    }
}
