using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    public class ChoiceController : Controller
    {
        // GET: Choice
        public ActionResult Index()
        {
            return View();
        }

        // GET: Choice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Choice/Create
        public ActionResult Create(int lastQuesId)
        {
            var model = new ChoiceViewModel
            {
                QuestionId = lastQuesId
            };
            return View(model);
        }

        // POST: Choice/Create
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

        // GET: Choice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Choice/Edit/5
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

        // GET: Choice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Choice/Delete/5
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