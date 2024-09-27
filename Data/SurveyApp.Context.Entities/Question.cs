using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Context.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Text { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
