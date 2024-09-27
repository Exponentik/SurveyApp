using SurveyApp.Services.Results.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Results
{
    public interface IResultService
    {
        Task<int> CreateResultAsync(ResultDto resultDto);
        Task<IEnumerable<ResultDto>> GetResultsByInterviewIdAsync(int interviewId);
    }
}
