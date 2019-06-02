using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaGameMVC.WebApp.Models;

namespace TriviaGameMVC.WebApp.Controllers
{
    [Authorize]
    public class PlayGameController : Controller
    {
        // GET: PlayGame
        public ActionResult Index()
        {
            PlayGameViewModel model = new PlayGameViewModel();
            
            return View(model);
        }
    }
}