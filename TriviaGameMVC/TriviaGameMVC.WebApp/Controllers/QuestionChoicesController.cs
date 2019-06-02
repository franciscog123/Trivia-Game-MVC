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
        //private readonly string _choiceUrl = "https://localhost:44394/api/choice";
        private readonly HttpClient _httpClient;

        public QuestionChoicesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: QuestionChoices
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuestionChoices/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: QuestionChoices/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionChoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionChoices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionChoices/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}