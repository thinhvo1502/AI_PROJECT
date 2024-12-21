using AI_PROJECT.DAL;
using AI_PROJECT.DAL.Models;
using AI_PROJECT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.BLL
{
    public class ExamService
    {
        private ExamRepository _examRepository;
        private QuestionRepository _questionRepository;
        private ExamHistoryRepository _examHistoryRepository;

        public ExamService()
        {
            _examRepository = new ExamRepository();
            _questionRepository = new QuestionRepository();
            _examHistoryRepository = new ExamHistoryRepository();
        }

        public int CreateExam(string examName, string description, int timeLimit, List<int> selectedQuestionIds)
        {
            if (string.IsNullOrWhiteSpace(examName))
            {
                throw new ArgumentException("Exam name cannot be empty.");
            }

            if (selectedQuestionIds == null || selectedQuestionIds.Count == 0)
            {
                throw new ArgumentException("At least one question must be selected.");
            }

            if (timeLimit <= 0)
            {
                throw new ArgumentException("Time limit must be greater than zero.");
            }

            var exam = new Exam
            {
                ExamName = examName,
                Description = description,
                TimeLimit = timeLimit,
                CreatedDate = DateTime.Now
            };

            var examId = _examRepository.CreateExam(exam);

            foreach (var questionId in selectedQuestionIds)
            {
                _examRepository.AddQuestionToExam(examId, questionId);
            }

            return examId;
        }

        public List<Question> GetQuestionsByCategory(int categoryId)
        {
            return _questionRepository.GetQuestionsByCategory(categoryId);
        }

        public List<Question> GetExamQuestions(int examId)
        {
            return _examRepository.GetExamQuestions(examId);
        }

        public int CalculateScore(int examId, Dictionary<int, string> userAnswers)
        {
            var examQuestions = GetExamQuestions(examId);
            int correctAnswers = 0;

            foreach (var question in examQuestions)
            {
                if (userAnswers.TryGetValue(question.QuestionID, out string userAnswer))
                {
                    if (userAnswer == question.CorrectAnswer)
                    {
                        correctAnswers++;
                    }
                }
            }

            return (int)Math.Round((double)correctAnswers / examQuestions.Count * 100);
        }

        public List<Exam> GetAllExams()
        {
            return _examRepository.GetAllExams();
        }

        public Exam GetExamById(int examId)
        {
            return _examRepository.GetExamById(examId);
        }

        public void SaveExamHistory(int userId, int examId, int score, int timeTaken)
        {
            var examHistory = new ExamHistory
            {
                UserID = userId,
                ExamID = examId,
                Score = score,
                DateTaken = DateTime.Now,
                TimeTaken = timeTaken
            };
            _examHistoryRepository.AddExamHistory(examHistory);
        }

        public List<ExamHistory> GetExamHistoryByUser(int userId)
        {
            return _examHistoryRepository.GetExamHistoryByUser(userId);
        }


        public void UpdateExam(int examId, string examName, string description, int timeLimit, List<int> selectedQuestionIds)
        {
            if (string.IsNullOrWhiteSpace(examName))
            {
                throw new ArgumentException("Exam name cannot be empty.");
            }

            if (selectedQuestionIds == null || selectedQuestionIds.Count == 0)
            {
                throw new ArgumentException("At least one question must be selected.");
            }

            if (timeLimit <= 0)
            {
                throw new ArgumentException("Time limit must be greater than zero.");
            }

            var exam = new Exam
            {
                ExamID = examId,
                ExamName = examName,
                Description = description,
                TimeLimit = timeLimit
            };

            _examRepository.UpdateExam(exam);
            _examRepository.UpdateExamQuestions(examId, selectedQuestionIds);
        }

        public void DeleteExam(int examId)
        {
            _examRepository.DeleteExam(examId);
        }

        public void DeleteQuestionFromExam(int examId, int questionId)
        {
            _examRepository.DeleteQuestionFromExam(examId, questionId);
        }

        public List<Question> GetAllQuestions()
        {
            return _questionRepository.GetAllQuestions();
        }
    }
}

