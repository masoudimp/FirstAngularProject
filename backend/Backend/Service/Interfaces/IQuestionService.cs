using DataLayer.models.questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> AddQuestion(Question question);
        Task<bool> AddOptions(List<Option> options);
        Task<List<Question>> GetQuestions();
        Task<bool> DeleteQuestionByQuestionId(int questionId);
        Task<bool> IsAnswerCorrect(int answerId);
    }
}
