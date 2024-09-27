using Microsoft.AspNetCore.Mvc;
using SurveyApp.Services.Surveys;
using SurveyApp.Services.Surveys.Dto;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveResult([FromBody] SurveyDto surveyDto)
        {
            var survey = await _surveyService.CreateResultAsync(surveyDto);
            return Ok(survey);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyDto>> GetSurveyById(int id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);
            if (survey == null) return NotFound();
            return survey;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyDto>>> GetAllSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return Ok(surveys);
        }
    }
}
