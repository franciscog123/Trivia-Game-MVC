using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaGameMVC.WebApp.ApiModels;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    public class ScoreBoardController : Controller
    {
        private readonly string _boardsUrl = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/user/getscoreboards";

        private readonly HttpClient _httpClient;
        
        public ScoreBoardController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: ScoreBoard
        public async Task<ActionResult> Index()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(_boardsUrl);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }

            IEnumerable<ScoreBoard> boards = await response.Content.ReadAsAsync<IEnumerable<ScoreBoard>>();
            IEnumerable<ScoreBoardViewModel> model = boards.Select(Mapper.Map);
            return View(model);
        }
    }
}