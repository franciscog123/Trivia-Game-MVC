using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGameMVC.WebApp.ApiModels
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public bool? Correct { get; set; }
        public string ChoiceString { get; set; }
    }
}
