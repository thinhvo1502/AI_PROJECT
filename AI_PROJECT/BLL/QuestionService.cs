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
    }
}

