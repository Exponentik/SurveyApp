using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyApp.Services.Surveys.Dto;

namespace SurveyApp.Services.Surveys
{
    public interface ISurveyService
    {
        Task<SurveyDto> CreateResultAsync(SurveyDto surveyDto);
        Task<SurveyDto> GetSurveyByIdAsync(int id);
        Task<IEnumerable<SurveyDto>> GetAllSurveysAsync();

    }
}
