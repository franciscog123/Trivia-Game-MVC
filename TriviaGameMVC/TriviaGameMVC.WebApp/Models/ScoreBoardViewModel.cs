using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGameMVC.WebApp.Models
{
    public class ScoreBoardViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? CompletedQuizzes { get; set; }
        public int TotalScore { get; set; }
    }
}
