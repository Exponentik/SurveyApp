using Microsoft.AspNetCore.Mvc;
using SurveyApp.Services.Interviews.Dto;
using SurveyApp.Services.Interviews.Interviews;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpPost]
        public async Task<ActionResult<InterviewDto>> CreateInterview(InterviewDto interviewDto)
        {
            var createdInterview = await _interviewService.CreateInterviewAsync(interviewDto);
            return CreatedAtAction(nameof(GetInterviewById), new { id = createdInterview.Id }, createdInterview);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewDto>> GetInterviewById(int id)
        {
            var interview = await _interviewService.GetInterviewByIdAsync(id);
            if (interview == null) return NotFound();
            return interview;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewDto>>> GetAllInterviews()
        {
            var interviews = await _interviewService.GetAllInterviewsAsync();
            return Ok(interviews);
        }
    }
}
