using DataLayer.Interfaces;
using DataLayer.models.questions;
using Service.Helpers;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class QuestionService : IQuestionService
    {

        #region Dependency Injection

        private readonly IQuestionRepository _questionRepository;
        private readonly IOptionRepository _optionRepository;

        public QuestionService(IQuestionRepository questionRepository, IOptionRepository optionRepository)
        {
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
        }

        #endregion

        public async Task<Question> AddQuestion(Question question)
        {

            var result = await _questionRepository.AddQuestion(question);

            if(result != null)
                return result;

            return null;
        }

        public async Task<bool> AddOptions(List<Option> options)
        {
            bool result = false;
            foreach (Option option in options)
            {
                var added = await _optionRepository.AddNewOption(option);
                result = added;
                if (!result)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public async Task<List<Question>> GetQuestions()
        {
            var result = await _questionRepository.GetAllQuestions();

            //Randomize Options' order
            foreach (Question question in result)
                question.Options = question.Options.RandomListOrders();

            return result.ToList();
        }

        public async Task<bool> IsAnswerCorrect(int answerId)
        {
            var option = await _optionRepository.GetOptionByOptionId(answerId);

            return option.IsCorrectAnswer;
        }

        public async Task<bool> DeleteQuestionByQuestionId(int questionId)
        {
            var result = await _questionRepository.DeleteQuestionByQuestionId(questionId);
            return result;
        }
    }
}
