using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using The_PIG_Dice_Game_Application.Models;

namespace The_PIG_Dice_Game_Application.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
       public IActionResult Index()
        {
            var sess = new GameSession(HttpContext.Session);
            
            var game = sess.GetGame();

            if (game.IsGameOver)
            {
                TempData["message"] = $"{game.CurrentPlayerName} wins!";

            }
            return View(game);
        }
        [HttpGet]

        public IActionResult newGame()
        {
            var sess = new GameSession(HttpContext.Session);

            var game = sess.GetGame();

            game.NewGame();
            sess.SetGame(game);
            return RedirectToAction("Index");

        }
        [HttpGet]

        public RedirectToActionResult Roll()
        {
            var sess = new GameSession(HttpContext.Session);

            var game = sess.GetGame();

            game.Roll();
            sess.SetGame(game);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public RedirectToActionResult Hold()
        {
            var sess = new GameSession(HttpContext.Session);

            var game = sess.GetGame();

            game.Hold();
            sess.SetGame(game);
            return RedirectToAction("Index");
        }
    }
}
