using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGameMVC.WebApp.Models
{
    public class QuestionChoicesViewModel
    {
        public int QuestionId { get; set; }
        public List<ChoiceViewModel> Choices { get; set; }
    }
}
