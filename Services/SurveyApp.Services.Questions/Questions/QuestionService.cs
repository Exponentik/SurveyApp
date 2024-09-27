using Microsoft.EntityFrameworkCore;
using SurveyApp.Context.Entities;
using SurveyApp.Context;
using SurveyApp.Services.Questions.Questions.Dto;
using SurveyApp.Services.Questions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyApp.Services.Answers.Dto;

public class QuestionService : IQuestionService
{
    private readonly AppDbContext _context;

    public QuestionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<QuestionDto>> GetQuestionsBySurveyIdAsync(int surveyId)
    {
        var questions = await _context.Questions
            .Where(q => q.SurveyId == surveyId)
            .ToListAsync();

        return questions.Select(q => new QuestionDto
        {
            Id = q.Id,
            Text = q.Text,
            SurveyId = q.SurveyId
        }).ToList();
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(int id)
    {
        var question = await _context.Questions
            .Include(q => q.Answers) 
            .FirstOrDefaultAsync(q => q.Id == id);
        if (question == null) return null;

        return new QuestionDto
        {
            Id = question.Id,
            Text = question.Text,
            SurveyId = question.SurveyId,
        };
    }

    public async Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto)
    {
        var question = new Question
        {
            Text = questionDto.Text,
            SurveyId = questionDto.SurveyId
        };

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return new QuestionDto
        {
            Id = question.Id,
            Text = question.Text,
            SurveyId = question.SurveyId
        };
    }
}
