using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaGameMVC.WebApp.ApiModels;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    [Authorize]
    public class QuestionChoicesController : Controller
    {
        private readonly string _choiceUrl = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/choice";
        private readonly HttpClient _httpClient;
        private readonly string _questionChoicesUrl = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/choice/getquestionchoices/";

        public QuestionChoicesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: QuestionChoices
        public async Task<ActionResult> Index(int questionId)
        {
            var model = new QuestionChoicesViewModel
            {
                QuestionId = questionId
            };
            HttpResponseMessage response = await _httpClient.GetAsync(_questionChoicesUrl + questionId);
            if(!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }

            IEnumerable<Choice> choices = await response.Content.ReadAsAsync<IEnumerable<Choice>>();
            IEnumerable<ChoiceViewModel> choiceModels = choices.Select(Mapper.Map);
            model.Choices = choiceModels.ToList();
            return View(model);
        }

        // GET: QuestionChoices/Create
        public ActionResult Create(int lastQuesId)
        {
            var model = new QuestionChoicesViewModel
            {
                QuestionId = lastQuesId
            };
            return View(model);
        }

        // POST: QuestionChoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionChoicesViewModel collection)
        {
            try
            {
                //var choiceList = new List<ChoiceViewModel>(4);
                for (var i=0;i<4;i++)
                {
                    var choice = new Choice
                    {
                        QuestionId=collection.QuestionId,
                        Correct=(collection.Choices[i].Correct),
                        ChoiceString=collection.Choices[i].ChoiceString
                    };

                    HttpResponseMessage response = await _httpClient.PostAsync(
                    _choiceUrl, choice, new JsonMediaTypeFormatter());

                    if (!response.IsSuccessStatusCode)
                    {
                        ModelState.TryAddModelError("", "Invalid data");
                        return View(collection);
                    }
                }
                return RedirectToAction(nameof(Index), "Question");
            }
            catch
            {
                return View(collection);
            }
        }
    }
}