using DataLayer.context;
using DataLayer.Interfaces;
using DataLayer.models.questions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {

        #region Dependency Injection

        private readonly BackendGameContext _context;

        public QuestionRepository(BackendGameContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<Question> AddQuestion(Question question)
        {
            await _context.AddAsync(question);
            try
            {
                await SaveChangesAsync();
                return question;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            var result = _context.Questions.Include(o => o.Options);
            return result;
        }

        public Question GetQuestionByQuestionId(int questionId)
        {
            return _context.Questions
                .Include(o => o.Options)
                .FirstOrDefault(x => x.QuestionId == questionId);
        }

        public async Task<bool> DeleteQuestionByQuestionId(int questionId)
        {
            var question = GetQuestionByQuestionId(questionId);
            question.IsDelete = true;

            try
            {
                await SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
