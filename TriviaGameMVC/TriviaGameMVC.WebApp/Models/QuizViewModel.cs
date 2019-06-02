using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using TriviaGameMVC.WebApp.ApiModels;

namespace TriviaGameMVC.WebApp.Models
{
    public class QuizViewModel
    {
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int GameModeId { get; set; }
        public int Score { get; set; }
        public DateTime QuizTime { get; set; }
        public string CategoryString { get; set; }
        public string GameModeString { get; set; }
    }
}
