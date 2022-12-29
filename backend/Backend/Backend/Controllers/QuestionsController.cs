using Backend.api.Dtos;
using DataLayer.models.questions;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Backend.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<AddQuestionResponseDto> Post([FromBody] AddQuestionRequestDto question)
        {

            if (!ModelState.IsValid)
                return null;

            var newQuestion = new Question
            {
                CreationDate = DateTime.Now,
                IsDelete = false,
                Text = question.Question,
                UserId = 2, //This is only for test, I already created a user with the Id 2 in my local DB
            };

            var result = await _service.AddQuestion(newQuestion);

            var options = new List<Option>();


            options.Add(new Option
            {
                CreationDate = DateTime.Now,
                IsCorrectAnswer = true,
                QuestionId = result.QuestionId,
                Text = question.CorrectAnswer
            });
            options.Add(new Option
            {
                CreationDate = DateTime.Now,
                IsCorrectAnswer = false,
                QuestionId = result.QuestionId,
                Text = question.Option1
            });
            options.Add(new Option
            {
                CreationDate = DateTime.Now,
                IsCorrectAnswer = false,
                QuestionId = result.QuestionId,
                Text = question.Option2
            });
            options.Add(new Option
            {
                CreationDate = DateTime.Now,
                IsCorrectAnswer = false,
                QuestionId = result.QuestionId,
                Text = question.Option3
            });
            
            var optionsAdded = await _service.AddOptions(options);

            return new AddQuestionResponseDto
            {
                IsSuccess = result != null ? true : false,
                Text = (result == null || !optionsAdded) ? "Error occured" : result.Text
            };

            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetQuestions();

            List<QuestionDto> questions = result
                .OrderByDescending(q => q.CreationDate)
                .Select(q => new QuestionDto
                {
                    Question = q.Text,
                    QuestionId = q.QuestionId,
                    Options = q.Options.Select(o => new OptionDto
                    {
                        OptionId = o.OptionId,
                        Text = o.Text
                    }).ToList()
                })
                .ToList();

            return Ok(questions);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int questionId)
        {
            var result = await _service.DeleteQuestionByQuestionId(questionId);
            return Ok(result);
        }

        [HttpPost("CheckAnswer")]
        public async Task<IActionResult> CheckAnswer([FromBody] AnswerRequestDto answer)
        {
            var result = await _service.IsAnswerCorrect(answer.AnswerId);
            return Ok((result)
                ?new AnswerResponseDto { Result = "Great, your answer is correct" } 
                : new AnswerResponseDto { Result = "Oops, wrong answer, try again" });
        }
    }
}
