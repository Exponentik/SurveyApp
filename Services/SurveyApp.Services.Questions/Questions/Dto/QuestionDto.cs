using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyApp.Services.Answers.Dto;
namespace SurveyApp.Services.Questions.Questions.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int SurveyId { get; set; }
    }
}
