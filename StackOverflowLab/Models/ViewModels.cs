using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowLab.Models
{
    public class QuestionAnswers
    {
        public Question quest { get; set; }
        public List<Answer> answers { get; set; }
    }
}
