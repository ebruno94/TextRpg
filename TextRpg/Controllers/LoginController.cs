using Microsoft.AspNetCore.Mvc;
using TextRpg.Models;
using System.Collections.Generic;

namespace TextRpg.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("/Login/Form")]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost("/Login/Create")]
        public ActionResult Create()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            Game.SetGameUser(GameUser.Find(GameUser.Login(username, password)));
            Game.GetGameUser().SetCharacter(Character.Find(Game.GetGameUser().GetId()));

            return RedirectToAction("Display", "User");
        }
    }
}
