using DataLayer.models.questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> AddQuestion(Question question);
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<bool> DeleteQuestionByQuestionId(int questionId);
    }
}
