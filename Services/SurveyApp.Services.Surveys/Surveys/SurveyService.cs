using SurveyApp.Context.Entities;
using SurveyApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyApp.Services.Surveys.Dto;
using Microsoft.EntityFrameworkCore;

namespace SurveyApp.Services.Surveys
{
    public class SurveyService : ISurveyService
    {
        private readonly AppDbContext _context;

        public SurveyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SurveyDto> CreateResultAsync(SurveyDto surveyDto)
        {
            var result = new Survey
            {
                Title = surveyDto.Title,
                Description = surveyDto.Description
            };

            _context.Surveys.Add(result);
            await _context.SaveChangesAsync();
            var survey = new SurveyDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description
            };
            return survey;
        }
        public async Task<SurveyDto> GetSurveyByIdAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            var result = survey == null ? null : new SurveyDto
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description
            };
            return result;
        }

        public async Task<IEnumerable<SurveyDto>> GetAllSurveysAsync()
        {
            var result = await _context.Surveys.Select(s => new SurveyDto 
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description 
            }).ToListAsync();
            return result;
        }
    }
}
