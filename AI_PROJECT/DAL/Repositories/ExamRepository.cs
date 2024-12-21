using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Repositories
{
    public class ExamRepository
    {
        private DatabaseContext _context;

        public ExamRepository()
        {
            _context = new DatabaseContext();
        }

        public int CreateExam(Exam exam)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Exams (ExamName, Description, TimeLimit, CreatedDate) OUTPUT INSERTED.ExamID VALUES (@ExamName, @Description, @TimeLimit, @CreatedDate)", connection);
                command.Parameters.AddWithValue("@ExamName", exam.ExamName);
                command.Parameters.AddWithValue("@Description", exam.Description);
                command.Parameters.AddWithValue("@TimeLimit", exam.TimeLimit);
                command.Parameters.AddWithValue("@CreatedDate", exam.CreatedDate);
                return (int)command.ExecuteScalar();
            }
        }

        public void AddQuestionToExam(int examId, int questionId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO ExamQuestions (ExamID, QuestionID) VALUES (@ExamID, @QuestionID)", connection);
                command.Parameters.AddWithValue("@ExamID", examId);
                command.Parameters.AddWithValue("@QuestionID", questionId);
                command.ExecuteNonQuery();
            }
        }

        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Exams", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamID = reader.GetInt32(0),
                            ExamName = reader.GetString(1),
                            Description = reader.GetString(3),
                            TimeLimit = reader.GetInt32(4),
                            CreatedDate = reader.GetDateTime(2)
                        });
                    }
                }
            }
            return exams;
        }

        public Exam GetExamById(int examId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Exams WHERE ExamID = @ExamID", connection);
                command.Parameters.AddWithValue("@ExamID", examId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Exam
                        {
                            ExamID = reader.GetInt32(0),
                            ExamName = reader.GetString(1),
                            Description = reader.GetString(3),
                            TimeLimit = reader.GetInt32(4),
                            CreatedDate = reader.GetDateTime(2)
                        };
                    }
                }
            }
            return null;
        }

        public List<Question> GetExamQuestions(int examId)
        {
            var questions = new List<Question>();
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(@"
            SELECT q.* FROM Questions q
            INNER JOIN ExamQuestions eq ON q.QuestionID = eq.QuestionID
            WHERE eq.ExamID = @ExamID", connection);
                command.Parameters.AddWithValue("@ExamID", examId);
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

        public void UpdateExam(Exam exam)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Exams SET ExamName = @ExamName, Description = @Description, TimeLimit = @TimeLimit WHERE ExamID = @ExamID",
                    connection);
                command.Parameters.AddWithValue("@ExamID", exam.ExamID);
                command.Parameters.AddWithValue("@ExamName", exam.ExamName);
                command.Parameters.AddWithValue("@Description", exam.Description);
                command.Parameters.AddWithValue("@TimeLimit", exam.TimeLimit);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateExamQuestions(int examId, List<int> questionIds)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Delete existing questions for this exam
                        var deleteCommand = new SqlCommand("DELETE FROM ExamQuestions WHERE ExamID = @ExamID", connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@ExamID", examId);
                        deleteCommand.ExecuteNonQuery();

                        // Add new questions
                        foreach (var questionId in questionIds)
                        {
                            var insertCommand = new SqlCommand(
                                "INSERT INTO ExamQuestions (ExamID, QuestionID) VALUES (@ExamID, @QuestionID)",
                                connection, transaction);
                            insertCommand.Parameters.AddWithValue("@ExamID", examId);
                            insertCommand.Parameters.AddWithValue("@QuestionID", questionId);
                            insertCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void DeleteExam(int examId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Delete exam questions
                        var deleteQuestionsCommand = new SqlCommand("DELETE FROM ExamQuestions WHERE ExamID = @ExamID", connection, transaction);
                        deleteQuestionsCommand.Parameters.AddWithValue("@ExamID", examId);
                        deleteQuestionsCommand.ExecuteNonQuery();

                        // Delete exam history
                        var deleteHistoryCommand = new SqlCommand("DELETE FROM ExamHistory WHERE ExamID = @ExamID", connection, transaction);
                        deleteHistoryCommand.Parameters.AddWithValue("@ExamID", examId);
                        deleteHistoryCommand.ExecuteNonQuery();

                        // Delete exam
                        var deleteExamCommand = new SqlCommand("DELETE FROM Exams WHERE ExamID = @ExamID", connection, transaction);
                        deleteExamCommand.Parameters.AddWithValue("@ExamID", examId);
                        deleteExamCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void DeleteQuestionFromExam(int examId, int questionId)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM ExamQuestions WHERE ExamID = @ExamID AND QuestionID = @QuestionID",
                    connection);
                command.Parameters.AddWithValue("@ExamID", examId);
                command.Parameters.AddWithValue("@QuestionID", questionId);
                command.ExecuteNonQuery();
            }
        }


    }
}
