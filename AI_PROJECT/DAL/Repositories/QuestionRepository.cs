using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Repositories
{
    internal class QuestionRepository
    {
        private DatabaseContext _context;

        public QuestionRepository()
        {
            _context = new DatabaseContext();
        }

        public void AddQuestion(Question question)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Questions (CategoryID, QuestionText, CorrectAnswer, WrongAnswer1, WrongAnswer2, WrongAnswer3) VALUES (@CategoryID, @QuestionText, @CorrectAnswer, @WrongAnswer1, @WrongAnswer2, @WrongAnswer3)", connection);
                command.Parameters.AddWithValue("@CategoryID", question.CategoryID);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@WrongAnswer1", question.WrongAnswer1);
                command.Parameters.AddWithValue("@WrongAnswer2", question.WrongAnswer2);
                command.Parameters.AddWithValue("@WrongAnswer3", question.WrongAnswer3);
                command.ExecuteNonQuery();
            }
        }

        public List<Question> GetQuestionsByCategory(int categoryId)
        {
            var questions = new List<Question>();
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Questions WHERE CategoryID = @CategoryID", connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            QuestionID = reader.GetInt32(0),
                            CategoryID = reader.GetInt32(1),
                            QuestionText = reader.GetString(2),
                            CorrectAnswer = reader.GetString(3),
                            WrongAnswer1 = reader.GetString(4),
                            WrongAnswer2 = reader.GetString(5),
                            WrongAnswer3 = reader.GetString(6)
                        });
                    }
                }
            }
            return questions;
        }
    }
}
