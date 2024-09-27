using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApp.Services.Questions;
using SurveyApp.Services.Questions.Questions.Dto;

namespace SurveyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("survey/{surveyId}")]
        public async Task<IActionResult> GetQuestionsBySurveyId(int surveyId)
        {
            var questions = await _questionService.GetQuestionsBySurveyIdAsync(surveyId);
            if (questions == null || !questions.Any())
            {
                return NotFound();
            }
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionDto questionDto)
        {
            if (questionDto == null || string.IsNullOrWhiteSpace(questionDto.Text))
            {
                return BadRequest("Question cannot be null or empty.");
            }

            var createdQuestion = await _questionService.CreateQuestionAsync(questionDto);
            return CreatedAtAction(nameof(GetQuestionById), new { id = createdQuestion.Id }, createdQuestion);
        }
    }
}
