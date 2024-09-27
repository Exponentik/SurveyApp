using SurveyApp.Services.Answers.Dto;

namespace SurveyApp.Services.Answers
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerDto>> GetAnswersByQuestionIdAsync(int questionId);
        Task<AnswerDto> CreateAnswerAsync(AnswerDto answerDto);
        Task<AnswerDto> GetAnswerByIdAsync(int id);
    }
}
