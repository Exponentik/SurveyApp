using Microsoft.EntityFrameworkCore;
using SurveyApp.Context;
using SurveyApp.Services.Answers;
using SurveyApp.Services.Interviews.Interviews;
using SurveyApp.Services.Questions;
using SurveyApp.Services.Results;
using SurveyApp.Services.Surveys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContextFactory<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.ExecuteSqlRaw("CREATE SCHEMA IF NOT EXISTS public;");
    context.Database.Migrate();
}
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
