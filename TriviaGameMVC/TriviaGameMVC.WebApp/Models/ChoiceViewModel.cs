using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGameMVC.WebApp.Models
{
    public class ChoiceViewModel
    {
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public bool Correct { get; set; }
        [Required]
        public string ChoiceString { get; set; }
    }
}
