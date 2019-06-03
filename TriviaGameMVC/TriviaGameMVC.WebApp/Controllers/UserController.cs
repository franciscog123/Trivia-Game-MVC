using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaGameMVC.WebApp.ApiModels;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    public class UserController : Controller
    {
        //private readonly string _usersUrl = "https://localhost:44394/api/user";
        private readonly string _usersUrl = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/user";

        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Authorize]
        // GET: User
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_usersUrl);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error", new ErrorViewModel());
            }

            //deserialize from JSON
            IEnumerable<User> users = await response.Content.ReadAsAsync<IEnumerable<User>>();
            IEnumerable<UserViewModel> model = users.Select(Mapper.Map);
            return View(model);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel viewModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                var user = new User
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    CompletedQuizzes = 0
                };

                HttpResponseMessage response = await _httpClient.PostAsync(_usersUrl, user, new JsonMediaTypeFormatter());

                if(!response.IsSuccessStatusCode)
                {
                    ModelState.TryAddModelError("", "Invalid data");
                    return View(viewModel);
                }
                if(!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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