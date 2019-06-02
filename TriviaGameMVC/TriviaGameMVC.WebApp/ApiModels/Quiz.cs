using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace TriviaGameMVC.WebApp.ApiModels
{
    public class Quiz
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
