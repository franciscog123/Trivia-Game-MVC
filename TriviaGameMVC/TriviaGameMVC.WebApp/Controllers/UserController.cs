using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaGameMVC.WebApp.ApiModels;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //private readonly string _usersUrl = "https://localhost:44394/api/user";
        private readonly string _usersUrl = "https://1904-guerrerof-triviagameapi.azurewebsites.net/api/user";

        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {

            /*var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);*/
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