using SurveyApp.Services.Questions.Questions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Questions
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsBySurveyIdAsync(int surveyId);
        Task<QuestionDto> GetQuestionByIdAsync(int id);
        Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto);
    }

}
