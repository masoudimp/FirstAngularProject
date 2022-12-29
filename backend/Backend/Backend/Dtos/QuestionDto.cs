using DataLayer.models.questions;

namespace Backend.api.Dtos
{
    public class AddQuestionRequestDto
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
    }

    public class AddQuestionResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Text { get; set; }
    }

    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}
