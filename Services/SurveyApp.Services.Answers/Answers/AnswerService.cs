using Microsoft.EntityFrameworkCore;
using SurveyApp.Context.Entities;
using SurveyApp.Context;
using SurveyApp.Services.Answers;
using SurveyApp.Services.Answers.Dto;

public class AnswerService : IAnswerService
{
    private readonly AppDbContext _context;

    public AnswerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AnswerDto>> GetAnswersByQuestionIdAsync(int questionId)
    {
        var answers = await _context.Answers
            .Where(a => a.QuestionId == questionId)
            .ToListAsync();

        // Преобразование Answer в AnswerDto вручную
        return answers.Select(a => new AnswerDto
        {
            Id = a.Id,
            Text = a.Text,
            QuestionId = questionId
        }).ToList();
    }

    public async Task<AnswerDto> CreateAnswerAsync(AnswerDto answerDto)
    {
        var answer = new Answer
        {
            Text = answerDto.Text,
            QuestionId = answerDto.QuestionId,
            IsCorrect = answerDto.IsCorrect
        };

        _context.Answers.Add(answer);
        await _context.SaveChangesAsync();
        answerDto.Id = answer.Id;
        return answerDto;
    }

    public async Task<AnswerDto> GetAnswerByIdAsync(int id)
    {
        var answer = await _context.Answers.FindAsync(id);
        return answer == null ? null : new AnswerDto { Id = answer.Id, Text = answer.Text, IsCorrect = answer.IsCorrect, QuestionId = answer.QuestionId };
    }
}
