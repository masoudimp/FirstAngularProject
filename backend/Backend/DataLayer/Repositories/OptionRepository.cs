using DataLayer.context;
using DataLayer.Interfaces;
using DataLayer.models.questions;

namespace DataLayer.Repositories
{
    public class OptionRepository : IOptionRepository
    {

        #region Dependency Injection

        private readonly BackendGameContext _context;

        public OptionRepository(BackendGameContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<bool> AddNewOption(Option option)
        {
            try
            {
                await _context.AddAsync(option);
                await SaveChangeAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public async Task<bool> DeleteOptionsByQuestionId(int questionId)
        {
            return true;
        }
        public async Task<Option> GetOptionByOptionId(int optionId)
        {
            var option = _context.Options.Where(o => o.OptionId == optionId).FirstOrDefault();
            return option;
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
