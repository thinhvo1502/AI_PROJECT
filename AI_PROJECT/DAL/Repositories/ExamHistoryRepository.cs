using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.DAL.Repositories
{
    public class ExamHistoryRepository
    {
        private DatabaseContext _context;

        public ExamHistoryRepository()
        {
            _context = new DatabaseContext();
        }

        public void AddExamHistory(ExamHistory examHistory)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO ExamHistory (UserID, ExamID, Score, DateTaken, TimeTaken) " +
                    "VALUES (@UserID, @ExamID, @Score, @DateTaken, @TimeTaken)", connection);
                command.Parameters.AddWithValue("@UserID", examHistory.UserID);
                command.Parameters.AddWithValue("@ExamID", examHistory.ExamID);
                command.Parameters.AddWithValue("@Score", examHistory.Score);
                command.Parameters.AddWithValue("@DateTaken", examHistory.DateTaken);
                command.Parameters.AddWithValue("@TimeTaken", examHistory.TimeTaken);
                command.ExecuteNonQuery();
            }
        }

        public List<ExamHistory> GetExamHistoryByUser(int userId)
        {
            var examHistories = new List<ExamHistory>();
            using (var connection = _context.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "SELECT * FROM ExamHistory WHERE UserID = @UserID ORDER BY DateTaken DESC", connection);
                command.Parameters.AddWithValue("@UserID", userId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        examHistories.Add(new ExamHistory
                        {
                            HistoryID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            ExamID = reader.GetInt32(2),
                            Score = reader.GetInt32(3),
                            DateTaken = reader.GetDateTime(4),
                            TimeTaken = reader.GetInt32(5)
                        });
                    }
                }
            }
            return examHistories;
        }
    }
}
