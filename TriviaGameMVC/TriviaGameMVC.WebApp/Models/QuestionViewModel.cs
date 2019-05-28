using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGameMVC.WebApp.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string QuestionString { get; set; }
        public int Value { get; set; }
    }
}
