using Microsoft.EntityFrameworkCore;
using SurveyApp.Context;
using SurveyApp.Context.Entities;
using SurveyApp.Services.Results.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Results
{
    public class ResultService : IResultService
    {
        private readonly AppDbContext _context;

        public ResultService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateResultAsync(ResultDto resultDto)
        {
            var result = new Result
            {
                InterviewId = resultDto.InterviewId,
                QuestionId = resultDto.QuestionId,
                AnswerIds = resultDto.AnswerIds 
            };

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            var nextQuestion = await _context.Questions
                .Where(q => q.Id > resultDto.QuestionId) 
                .OrderBy(q => q.Id)
                .FirstOrDefaultAsync();

            return nextQuestion.Id;
        }
        public async Task<IEnumerable<ResultDto>> GetResultsByInterviewIdAsync(int interviewId)
        {
            return await _context.Results
                .Where(r => r.InterviewId == interviewId)
                .Select(r => new ResultDto { Id = r.Id, InterviewId = r.InterviewId, QuestionId = r.QuestionId, AnswerIds = r.AnswerIds })
                .ToListAsync();
        }
    }
}
