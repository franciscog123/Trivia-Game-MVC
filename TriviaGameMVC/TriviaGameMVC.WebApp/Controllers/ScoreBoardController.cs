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
        private readonly string _boardsUrl = "https://localhost:44394/api/user/getscoreboards";
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

        // GET: ScoreBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScoreBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScoreBoard/Create
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

        // GET: ScoreBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScoreBoard/Edit/5
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

        // GET: ScoreBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScoreBoard/Delete/5
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