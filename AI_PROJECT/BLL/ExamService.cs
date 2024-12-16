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

        public ExamService()
        {
            _examRepository = new ExamRepository();
            _questionRepository = new QuestionRepository();
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
    }
}

