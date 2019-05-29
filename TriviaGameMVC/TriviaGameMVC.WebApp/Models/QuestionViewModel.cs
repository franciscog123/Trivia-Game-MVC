using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TriviaGameMVC.WebApp.ApiModels;

namespace TriviaGameMVC.WebApp.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string QuestionString { get; set; }
        [Required]
        public int Value { get; set; }
        public List<Category> Categories { get; set; }
    }
}
