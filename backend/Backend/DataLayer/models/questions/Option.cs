using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.models.questions
{
    public class Option : Base
    {
        [Key]
        public int OptionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
