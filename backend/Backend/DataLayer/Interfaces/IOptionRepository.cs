using DataLayer.models.questions;

namespace DataLayer.Interfaces
{
    public interface IOptionRepository
    {
        Task<bool> AddNewOption(Option option);
        Task<Option> GetOptionByOptionId(int optionId);
    }
}
