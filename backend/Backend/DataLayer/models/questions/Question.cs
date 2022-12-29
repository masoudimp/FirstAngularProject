using DataLayer.models.users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.models.questions
{
    public class Question : Base
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
