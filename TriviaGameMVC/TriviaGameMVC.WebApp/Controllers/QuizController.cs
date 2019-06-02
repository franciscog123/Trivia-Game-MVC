using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using TriviaGameMVC.WebApp.ApiModels;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly string _usersUrl= "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/user/GetUserByEmail/";
        private readonly string _email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        private readonly string _userQuizzes = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/quiz/getquizzesbyuser/";
        private readonly string _gameModes = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/gamemode";
        private readonly string _categories = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/question/getcategories";
        private readonly HttpClient _httpClient;

        public QuizController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Quiz
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage gameModesResponse = await _httpClient.GetAsync(_gameModes);
            if(!gameModesResponse.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }
            IEnumerable<GameMode> gameModes = await gameModesResponse.Content.ReadAsAsync<IEnumerable<GameMode>>();

            HttpResponseMessage categoriesResponse = await _httpClient.GetAsync(_categories);
            if (!categoriesResponse.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }
            IEnumerable<Category> categories = await categoriesResponse.Content.ReadAsAsync<IEnumerable<Category>>();
            //IEnumerable<Category> categories = await categoriesResponse.Content.ReadAsAsync<IEnumerable<Category>>,IEnumerable<MediaTypeFormatter>>;
            //ReadAsAsync(HttpContent, Type, IEnumerable<MediaTypeFormatter>)
            var email = User.Claims.First(c => c.Type==_email).Value;
            HttpResponseMessage response = await _httpClient.GetAsync(_usersUrl + email);

            if(!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }
            User user = await response.Content.ReadAsAsync<User>();
            int userId = user.UserId;

            HttpResponseMessage quizzesResponse = await _httpClient.GetAsync(_userQuizzes + userId);
            if(!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }

            IEnumerable<Quiz> quizzes = await quizzesResponse.Content.ReadAsAsync<IEnumerable<Quiz>>();
            //IEnumerable<Quiz> quizzes = await quizzesResponse.Content.ReadAsAsync<IEnumerable<Quiz>>(new List<JsonMediaTypeFormatter>() {});
            //IEnumerable<Quiz> quizzes = await quizzesResponse.Content.ReadAsAsync<IEnumerable<Quiz>>(<new List<MediaTypeFormatter>()>);
            IEnumerable<QuizViewModel> model = quizzes.Select(Mapper.Map);

            var modelList = model.ToList();
            for(int i=0;i<modelList.Count();i++)
            {

                modelList[i].CategoryString = categories.First(x => x.CategoryId == modelList[i].CategoryId).CategoryString;
                modelList[i].GameModeString = gameModes.First(x => x.GameModeId == modelList[i].GameModeId).GameModeString;
            }
            model = modelList;
            return View(model);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quiz/Edit/5
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

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Quiz/Delete/5
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