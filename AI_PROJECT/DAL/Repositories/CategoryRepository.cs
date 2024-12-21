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

        public Category GetCategoryById(int categoryId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Categories WHERE CategoryID = @CategoryID", connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Category
                        {
                            CategoryID = reader.GetInt32(0),
                            CategoryName = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }

        public void UpdateCategory(Category category)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID", connection);
                command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCategoryAndRelatedRecords(int categoryId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Xóa các bản ghi liên quan trong bảng ExamQuestions
                        var deleteExamQuestionsCommand = new SqlCommand(
                            "DELETE FROM ExamQuestions WHERE QuestionID IN (SELECT QuestionID FROM Questions WHERE CategoryID = @CategoryID)",
                            connection, transaction);
                        deleteExamQuestionsCommand.Parameters.AddWithValue("@CategoryID", categoryId);
                        deleteExamQuestionsCommand.ExecuteNonQuery();

                        // Xóa các câu hỏi thuộc category
                        var deleteQuestionsCommand = new SqlCommand("DELETE FROM Questions WHERE CategoryID = @CategoryID", connection, transaction);
                        deleteQuestionsCommand.Parameters.AddWithValue("@CategoryID", categoryId);
                        deleteQuestionsCommand.ExecuteNonQuery();

                        // Xóa category
                        var deleteCategoryCommand = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @CategoryID", connection, transaction);
                        deleteCategoryCommand.Parameters.AddWithValue("@CategoryID", categoryId);
                        deleteCategoryCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
