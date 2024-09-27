using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Context.Entities
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int QuestionId { get; set; }
        public List<int> AnswerIds { get; set; } = new List<int>();
        public Interview Interview { get; set; }
        public Question Question { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
