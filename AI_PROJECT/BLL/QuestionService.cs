using AI_PROJECT.DAL.Models;
using AI_PROJECT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.BLL
{
    public class QuestionService
    {
        private QuestionRepository _questionRepository;

        public QuestionService()
        {
            _questionRepository = new QuestionRepository();
        }

        public void AddQuestion(Question question)
        {
            if (string.IsNullOrWhiteSpace(question.QuestionText))
            {
                throw new System.ArgumentException("Question text cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(question.CorrectAnswer))
            {
                throw new System.ArgumentException("Correct answer cannot be empty.");
            }
            _questionRepository.AddQuestion(question);
        }

        public List<Question> GetQuestionsByCategory(int categoryId)
        {
            return _questionRepository.GetQuestionsByCategory(categoryId);
        }

        public List<Question> GetAllQuestions()
        {
            return _questionRepository.GetAllQuestions();
        }

        public void UpdateQuestion(Question question)
        {
            if (string.IsNullOrWhiteSpace(question.QuestionText))
            {
                throw new System.ArgumentException("Question text cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(question.CorrectAnswer))
            {
                throw new System.ArgumentException("Correct answer cannot be empty.");
            }
            _questionRepository.UpdateQuestion(question);
        }

        public void DeleteQuestion(int questionId)
        {
            try
            {
                _questionRepository.DeleteQuestionAndRelatedRecords(questionId);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("An error occurred while deleting the question. It may be in use in an exam.", ex);
            }
        }
    }
}

