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
    public class QuestionController : Controller
    {
        private readonly string _questionsUrl = "https://localhost:44394/api/question";
        private readonly HttpClient _httpClient;

        public QuestionController (HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        // GET: Question
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_questionsUrl);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }

            //deserialize from JSON
            IEnumerable<Question> questions = await response.Content.ReadAsAsync<IEnumerable<Question>>();
            IEnumerable<QuestionViewModel> model = questions.Select(Mapper.Map);
            return View(model);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        // GET: Question/Create
        [Authorize]
        public ActionResult Create()
        {
            //TODO make this method async, get list of categories from db and display them 
            //as drop down list in create form
            /*if (User.IsInRole("Administrator"))
            {
                var model = new QuestionViewModel
                {

                };
                return View(model);
            }*/
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create(QuestionViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                var question = new Question
                {
                    CategoryId = viewModel.CategoryId,
                    QuestionString = viewModel.QuestionString,
                    Value = viewModel.Value
                };
                HttpResponseMessage response = await _httpClient.PostAsync(
                    _questionsUrl, question, new JsonMediaTypeFormatter());

                if(!response.IsSuccessStatusCode)
                {
                    ModelState.TryAddModelError("","Invalid data");
                    return View(viewModel);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
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