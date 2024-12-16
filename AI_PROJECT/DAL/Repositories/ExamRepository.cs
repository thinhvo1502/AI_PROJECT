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
                            Description = reader.GetString(2),
                            TimeLimit = reader.GetInt32(3),
                            CreatedDate = reader.GetDateTime(4)
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

    }
}
