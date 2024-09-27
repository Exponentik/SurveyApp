using SurveyApp.Services.Interviews.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Interviews.Interviews
{
    public interface IInterviewService
    {
        Task<InterviewDto> CreateInterviewAsync(InterviewDto interviewDto);
        Task<InterviewDto> GetInterviewByIdAsync(int id);
        Task<IEnumerable<InterviewDto>> GetAllInterviewsAsync();
    }
}
