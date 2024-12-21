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

        public List<Question> GetAllQuestions()
        {
            var questions = new List<Question>();
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Questions", connection);
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

        public void UpdateQuestion(Question question)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Questions SET CategoryID = @CategoryID, QuestionText = @QuestionText, CorrectAnswer = @CorrectAnswer, WrongAnswer1 = @WrongAnswer1, WrongAnswer2 = @WrongAnswer2, WrongAnswer3 = @WrongAnswer3 WHERE QuestionID = @QuestionID", connection);
                command.Parameters.AddWithValue("@QuestionID", question.QuestionID);
                command.Parameters.AddWithValue("@CategoryID", question.CategoryID);
                command.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                command.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);
                command.Parameters.AddWithValue("@WrongAnswer1", question.WrongAnswer1);
                command.Parameters.AddWithValue("@WrongAnswer2", question.WrongAnswer2);
                command.Parameters.AddWithValue("@WrongAnswer3", question.WrongAnswer3);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteQuestion(int questionId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Questions WHERE QuestionID = @QuestionID", connection);
                command.Parameters.AddWithValue("@QuestionID", questionId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteQuestionAndRelatedRecords(int questionId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Xóa các bản ghi liên quan trong bảng ExamQuestions
                        var deleteExamQuestionsCommand = new SqlCommand("DELETE FROM ExamQuestions WHERE QuestionID = @QuestionID", connection, transaction);
                        deleteExamQuestionsCommand.Parameters.AddWithValue("@QuestionID", questionId);
                        deleteExamQuestionsCommand.ExecuteNonQuery();

                        // Xóa câu hỏi
                        var deleteQuestionCommand = new SqlCommand("DELETE FROM Questions WHERE QuestionID = @QuestionID", connection, transaction);
                        deleteQuestionCommand.Parameters.AddWithValue("@QuestionID", questionId);
                        deleteQuestionCommand.ExecuteNonQuery();

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
