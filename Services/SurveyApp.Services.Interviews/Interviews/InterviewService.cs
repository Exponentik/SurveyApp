using Microsoft.EntityFrameworkCore;
using SurveyApp.Context;
using SurveyApp.Context.Entities;
using SurveyApp.Services.Interviews.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Interviews.Interviews
{
    public class InterviewService : IInterviewService
    {
        private readonly AppDbContext _context;

        public InterviewService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<InterviewDto> CreateInterviewAsync(InterviewDto interviewDto)
        {
            var interview = new Interview { SurveyId = interviewDto.SurveyId };
            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync();
            interviewDto.Id = interview.Id;
            return interviewDto;
        }

        public async Task<InterviewDto> GetInterviewByIdAsync(int id)
        {
            var interview = await _context.Interviews.FindAsync(id);
            var result = interview == null ? null : new InterviewDto 
            { 
                Id = interview.Id, 
                SurveyId = interview.SurveyId 
            };
            return result;
        }

        public async Task<IEnumerable<InterviewDto>> GetAllInterviewsAsync()
        {
            var result = await _context.Interviews.Select(i => new InterviewDto 
            { 
                Id = i.Id, 
                SurveyId = i.SurveyId 
            }).ToListAsync();
            return result;
        }
    }
}
