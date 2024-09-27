using Microsoft.AspNetCore.Mvc;
using SurveyApp.Services.Results;
using SurveyApp.Services.Results.Dto;
using SurveyApp.Services.Results;
using System.Threading.Tasks;

namespace SurveyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultsController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveResult([FromBody] ResultDto resultDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nextQuestion = await _resultService.CreateResultAsync(resultDto);
            return Ok(nextQuestion); 
        }
        [HttpGet("interview/{interviewId}")]
        public async Task<ActionResult<IEnumerable<ResultDto>>> GetResultsByInterviewId(int interviewId)
        {
            var results = await _resultService.GetResultsByInterviewIdAsync(interviewId);
            return Ok(results);
        }
    }
}
